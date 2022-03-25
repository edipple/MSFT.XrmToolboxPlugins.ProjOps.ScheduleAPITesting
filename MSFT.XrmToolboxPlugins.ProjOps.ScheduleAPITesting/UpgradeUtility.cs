using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MSCPS.F12FSMigration {
  public class UpgradeUtility {
    //private const int StoredProcBatchSize = 10000;
    //private const int MaxRowsProcessed = 50 * 1000 * 1000;

    private List<Guid> pluginsDisabled;
    private List<Guid> pluginsEnabled;
    private List<Guid> workflowsDisabled;
    private List<Guid> workflowsEnabled;
    private IOrganizationService crmTargetSvc;
    private IOrganizationService crmSourceSvc;
    private string logFilePath = "";

    private const string agreementBookingRecurrancePatter = @"<root><pattern><period>daily</period><option>every</option><days every='1'></days></pattern><range><start>{START}</start><option>endAfter</option><end>1</end></range><datas/></root>";

    #region FetchXML Queries
    private const string resourceRequirements = @"<fetch no-lock='true'>
                                                        <entity name='msdyn_resourcerequirement' >
                                                            <attribute name='msdyn_timetopromised' />
                                                            <attribute name='createdon' />
                                                            <attribute name='msdyn_requirementrelationshipid' />
                                                            <attribute name='msdyn_status' />
                                                            <attribute name='msdyn_city' />
                                                            <attribute name='msdyn_calendarid' />
                                                            <attribute name='msdyn_requeststatus' />
                                                            <attribute name='msdyn_type' />
                                                            <attribute name='msdyn_timewindowend' />
                                                            <attribute name='msdyn_resourcetype' />
                                                            <attribute name='msdyn_territory' />
                                                            <attribute name='msdyn_timegroup' />
                                                            <attribute name='msdyn_workhourtemplate' />
                                                            <attribute name='msdyn_resourcerequirementid' />
                                                            <attribute name='msdyn_stateorprovince' />
                                                            <attribute name='msdyn_todate' />
                                                            <attribute name='msdyn_effort' />
                                                            <attribute name='msdyn_pooltype' />
                                                            <attribute name='msdyn_timewindowstart' />
                                                            <attribute name='msdyn_name' />
                                                            <attribute name='msdyn_fulfilledduration' />
                                                            <attribute name='msdyn_projectid' />
                                                            <attribute name='msdyn_priority' />
                                                            <attribute name='msdyn_country' />
                                                            <attribute name='msdyn_remainingduration' />
                                                            <attribute name='msdyn_isprimary' />
                                                            <attribute name='transactioncurrencyid' />
                                                            <attribute name='msdyn_fromdate' />
                                                            <attribute name='msdyn_timefrompromised' />
                                                            <attribute name='msdyn_worklocation' />
                                                            <attribute name='msdyn_latitude' />
                                                            <attribute name='msdyn_percentage' />
                                                            <attribute name='msdyn_workorder' />
                                                            <attribute name='msdyn_proposedduration' />
                                                            <attribute name='msdyn_longitude' />
                                                            <attribute name='msdyn_duration' />
                                                            <filter type='and' >
                                                                <condition attribute='msdyn_istemplate' operator='eq' value='0' />
                                                            </filter>
                                                        </entity>
                                                      </fetch>";

    private const string agreementInvoiceSetupSystemJobFailures = @"<fetch no-lock='true' >
                                                                          <entity name='asyncoperation' >
                                                                            <attribute name='asyncoperationid' />
                                                                            <attribute name='name' />
                                                                            <attribute name='regardingobjectid' />
                                                                            <attribute name='operationtype' />
                                                                            <attribute name='statuscode' />
                                                                            <attribute name='ownerid' />
                                                                            <attribute name='startedon' />
                                                                            <attribute name='statecode' />
                                                                            <attribute name='postponeuntil' />
                                                                            <attribute name='createdon' />
                                                                            <attribute name='completedon' />
                                                                            <attribute name='owningextensionid' />
                                                                            <attribute name='messagename' />
                                                                            <attribute name='message' />
                                                                            <attribute name='friendlymessage' />
                                                                            <attribute name='errorcode' />
                                                                            <order attribute='name' descending='false' />
                                                                            <order attribute='completedon' descending='true' />
                                                                            <filter type='and' >
                                                                              <condition attribute='recurrencestarttime' operator='null' />
                                                                              <condition attribute='statuscode' operator='eq' value='31' />
                                                                              <condition attribute='operationtype' operator='not-in' >
                                                                                <value>13</value>
                                                                                <value>23</value>
                                                                                <value>8</value>
                                                                                <value>2</value>
                                                                                <value>22</value>
                                                                                <value>18</value>
                                                                                <value>57</value>
                                                                                <value>71</value>
                                                                                <value>19</value>
                                                                                <value>16</value>
                                                                                <value>26</value>
                                                                                <value>21</value>
                                                                                <value>32</value>
                                                                                <value>73</value>
                                                                                <value>58</value>
                                                                                <value>40</value>
                                                                                <value>69</value>
                                                                              </condition>
                                                                              <condition attribute='startedon' operator='on-or-after' value='{STARTDATE}' />
                                                                              <condition attribute='startedon' operator='on-or-before' value='{ENDDATE}' />
                                                                            </filter>
                                                                            <link-entity name='msdyn_agreementinvoicesetup' from='msdyn_agreementinvoicesetupid' to='regardingobjectid' link-type='inner' alias='le' >
                                                                            </link-entity>
                                                                          </entity>
                                                                        </fetch>";

    private const string workflowLookupAgreementExpireFetchXml = @"<fetch no-lock='true' >
                                                                         <entity name='workflow' >
                                                                           <attribute name='workflowid' />
                                                                           <attribute name='name' />
                                                                           <attribute name='type' />
                                                                           <attribute name='ownerid' />
                                                                           <attribute name='activeworkflowid' />
                                                                           <filter type='and' >
                                                                             <condition attribute='type' operator='eq' value='1' />
                                                                             <condition attribute='rendererobjecttypecode' operator='null' />
                                                                             <condition attribute='category' operator='eq' value='0' />
                                                                             <condition attribute='name' operator='eq' value='Field Service - Mark Agreement as Expired' />
                                                                           </filter>
                                                                         </entity>
                                                                       </fetch>";

    private const string agreementBookingSetupFetchXml = @"<fetch no-lock='true' >
                                                                 <entity name='msdyn_agreementbookingsetup' >
                                                                   <attribute name='msdyn_postponegenerationuntil' />
                                                                   <attribute name='msdyn_agreement' />
                                                                   <attribute name='ownerid' />
                                                                   <attribute name='msdyn_name' />
                                                                   <attribute name='msdyn_agreementbookingsetupid' />
                                                                   <filter>
                                                                     <condition attribute='msdyn_agreement' operator='eq' value='{AGREEMENTID}' />
                                                                   </filter>
                                                                 </entity>
                                                               </fetch>";

    private const string agreementInvoiceSetupFetchXml = @"<fetch no-lock='true' >
                                                                 <entity name='msdyn_agreementinvoicesetup' >
                                                                   <attribute name='msdyn_postponegenerationuntil' />
                                                                   <attribute name='msdyn_agreement' />
                                                                   <attribute name='ownerid' />
                                                                   <attribute name='msdyn_name' />
                                                                   <attribute name='msdyn_agreementinvoicesetupid' />
                                                                   <filter>
                                                                     <condition attribute='msdyn_agreement' operator='eq' value='{AGREEMENTID}' />
                                                                   </filter>
                                                                 </entity>
                                                               </fetch>";

    private const string agreementExpireWorkflowFetchXml = @"<fetch no-lock='true' >
                                                           <entity name='asyncoperation' >
                                                             <attribute name='primaryentitytype' />
                                                             <attribute name='regardingobjectid' />
                                                             <attribute name='owningextensionid' />
                                                             <attribute name='name' />
                                                             <filter type='and' >
                                                               <condition attribute='regardingobjectid' operator='eq' value='{AGREEMENTID}' />
                                                               <condition attribute='statuscode' operator='eq' value='10' />
                                                               <condition attribute='name' operator='eq' value='Field Service - Mark Agreement as Expired' />
                                                             </filter>
                                                           </entity>
                                                         </fetch>";

    private const string agreementProcessFetchXml = @"<fetch no-lock='true' >
                                                                  <entity name='asyncoperation' >
                                                                    <attribute name='primaryentitytype' />
                                                                    <attribute name='regardingobjectid' />
                                                                    <attribute name='owningextensionid' />
                                                                    <attribute name='name' />
                                                                    <filter type='and' >
                                                                      <condition attribute='ownerid' operator='eq' value='{USERID}' />
                                                                      <condition attribute='statuscode' operator='eq' value='10' />
                                                                      <filter type='or' >
                                                                        <condition attribute='name' operator='eq' value='Field Service - Mark Agreement as Expired' />
                                                                        <condition attribute='name' operator='eq' value='Field Service - Generate Agreement Booking Dates' />
                                                                        <condition attribute='name' operator='eq' value='Field Service - Generate Agreement Invoice Dates' />
                                                                        <condition attribute='name' operator='eq' value='Field Service - Generate Work Order for Agreement Booking Date' />
                                                                        <condition attribute='name' operator='eq' value='Field Service - Generate Invoice for Agreement Invoice Date' />
                                                                      </filter>
                                                                    </filter>
                                                                    <link-entity name='msdyn_agreement' from='msdyn_agreementid' to='regardingobjectid' link-type='outer' alias='ag1' >
                                                                      <attribute name='ownerid' />
                                                                      <attribute name='msdyn_name' />
                                                                      <attribute name='msdyn_agreementid' />
                                                                    </link-entity>
                                                                    <link-entity name='msdyn_agreementbookingsetup' from='msdyn_agreementbookingsetupid' to='regardingobjectid' link-type='outer' alias='abs' >
                                                                      <link-entity name='msdyn_agreement' from='msdyn_agreementid' to='msdyn_agreement' link-type='outer' alias='ag2' >
                                                                        <attribute name='ownerid' />
                                                                        <attribute name='msdyn_agreementid' />
                                                                        <attribute name='msdyn_name' />
                                                                      </link-entity>
                                                                    </link-entity>
                                                                    <link-entity name='msdyn_agreementinvoicesetup' from='msdyn_agreementinvoicesetupid' to='regardingobjectid' link-type='outer' alias='ais' >
                                                                      <link-entity name='msdyn_agreement' from='msdyn_agreementid' to='msdyn_agreement' link-type='outer' alias='ag3' >
                                                                        <attribute name='ownerid' />
                                                                        <attribute name='msdyn_agreementid' />
                                                                        <attribute name='msdyn_name' />
                                                                      </link-entity>
                                                                    </link-entity>
                                                                    <link-entity name='msdyn_agreementbookingdate' from='msdyn_agreementbookingdateid' to='regardingobjectid' link-type='outer' alias='abd' >
                                                                      <link-entity name='msdyn_agreement' from='msdyn_agreementid' to='msdyn_agreement' link-type='outer' alias='ag4' >
                                                                        <attribute name='ownerid' />
                                                                        <attribute name='msdyn_agreementid' />
                                                                        <attribute name='msdyn_name' />
                                                                      </link-entity>
                                                                    </link-entity>
                                                                    <link-entity name='msdyn_agreementinvoicedate' from='msdyn_agreementinvoicedateid' to='regardingobjectid' link-type='outer' alias='aid' >
                                                                      <link-entity name='msdyn_agreement' from='msdyn_agreementid' to='msdyn_agreement' link-type='outer' alias='ag5' >
                                                                        <attribute name='ownerid' />
                                                                        <attribute name='msdyn_agreementid' />
                                                                        <attribute name='msdyn_name' />
                                                                      </link-entity>
                                                                    </link-entity>
                                                                  </entity>
                                                                </fetch>";

    private const string activeAgreementBookingSetupFetchXml = @"<entity name='msdyn_agreementbookingsetup' >
                                                                   <attribute name='msdyn_generatewodaysinadvance' />
                                                                   <attribute name='msdyn_postponegenerationuntil' />
                                                                   <attribute name='statecode' />
                                                                   <attribute name='msdyn_recurrencesettings' />
                                                                   <attribute name='msdyn_agreement' />
                                                                   <attribute name='msdyn_agreementname' />
                                                                   <attribute name='msdyn_name' />
                                                                   <attribute name='statuscode' />
                                                                   <attribute name='msdyn_agreementbookingsetupid' />
                                                                   <attribute name='msdyn_revision' />
                                                                   <link-entity name='msdyn_agreement' from='msdyn_agreementid' to='msdyn_agreement' >
                                                                     <filter>
                                                                       <condition attribute='statecode' operator='eq' value='0' />
                                                                     </filter>
                                                                   </link-entity>
                                                                 </entity>
                                                               </fetch>";

    private const string userByDomainNameFetchXml = @"<fetch>
                                                            <entity name='systemuser' >
                                                              <attribute name='systemuserid' />
                                                              <attribute name='domainname' />
                                                              <attribute name='businessunitid' />
                                                              <attribute name='fullname' />
                                                              <filter>
                                                                <condition attribute='domainname' operator='eq' value='{DOMAINNAME}' />
                                                              </filter>
                                                            </entity>
                                                          </fetch>";

    private const string currencyFetchXml = @"<fetch>
                                                    <entity name='transactioncurrency'>
                                                      <attribute name='currencysymbol' />
                                                      <attribute name='transactioncurrencyid' />
                                                      <attribute name='organizationid' />
                                                      <attribute name='currencyprecision' />
                                                      <attribute name='isocurrencycode' />
                                                      <attribute name='currencyname' />
                                                    </entity>
                                                  </fetch>";

    private const string bussinessUnitAllFetchXml = @"<fetch>
                                                          <entity name='businessunit' >
                                                            <attribute name='name' />
                                                            <attribute name='businessunitid' />
                                                          </entity>
                                                        </fetch>";

    private const string uomAllFetchXml = @"<fetch>
                                              <entity name='uom'>
                                                <attribute name='organizationid' />
                                                <attribute name='isschedulebaseuom' />
                                                <attribute name='createdby' />
                                                <attribute name='quantity' />
                                                <attribute name='name' />
                                                <attribute name='createdon' />
                                                <attribute name='uomscheduleid' />
                                                <attribute name='uomid' />
                                                <attribute name='baseuom' />
                                              </entity>
                                            </fetch>";

    private const string uomFetchByNameXml = @"<fetch>
                                                 <entity name='uom'>
                                                   <all-attributes/>
                                                   <filter type='and' >
                                                     <condition attribute='name' operator='eq' value='{NAME}' />
                                                   </filter>
                                                 </entity>
                                               </fetch>";

    private const string uomScheduleAllFetchXml = @"<fetch>
                                                      <entity name='uomschedule'>
                                                        <all-attributes/>
                                                      </entity>
                                                    </fetch>";

    private const string userSettingsFetchXml = @"<fetch>
                                                        <entity name='usersettings'>                                                        
                                                          <attribute name='timezonecode' />
                                                          <attribute name='uilanguageid' />
                                                          <attribute name='transactioncurrencyid' />
                                                          <attribute name='localeid' />
                                                          <filter>
                                                            <condition attribute='systemuserid' operator='eq' value='{USERID}' />
                                                          </filter>
                                                        </entity>
                                                      </fetch>";

    private const string userAssignedRolesFetchXml = @"<fetch>
                                                             <entity name='systemuserroles' >
                                                               <attribute name='systemuserroleid' />
                                                               <attribute name='roleid' />
                                                               <attribute name='systemuserid' />
                                                               <filter>
                                                                 <condition attribute='systemuserid' operator='eq' value='{USERID}' />
                                                               </filter>
                                                               <link-entity name='role' from='roleid' to='roleid' link-type='outer' alias='ur'>
                                                                 <attribute name='name' />
                                                                 <attribute name='businessunitid' />
                                                                 <attribute name='roleid' />
                                                                 <attribute name='roleidunique' />
                                                                 <attribute name='organizationid' />
                                                                 <attribute name='parentroleid' />
                                                                 <attribute name='parentrootroleid' />
                                                               </link-entity>
                                                             </entity>
                                                           </fetch>";

    private const string teamAssignedRolesFetchXml = @"<fetch>
                                                     <entity name='teamroles' >
                                                       <attribute name='roleid' />
                                                       <attribute name='teamid' />
                                                       <attribute name='teamroleid' />
                                                       <filter>
                                                         <condition attribute='teamid' operator='eq' value='{TEAMID}' />
                                                       </filter>
                                                       <link-entity name='role' from='roleid' to='roleid' link-type='outer' alias='ur'>
                                                         <attribute name='name' />
                                                         <attribute name='businessunitid' />
                                                         <attribute name='roleid' />
                                                         <attribute name='roleidunique' />
                                                         <attribute name='organizationid' />
                                                         <attribute name='parentroleid' />
                                                         <attribute name='parentrootroleid' />
                                                       </link-entity>
                                                     </entity>
                                                   </fetch>";

    private const string securityRolesFetchXml = @"<fetch>
                                                         <entity name='role' >
                                                           <attribute name='name' />
                                                           <attribute name='organizationid' />
                                                           <attribute name='businessunitid' />
                                                           <attribute name='roleid' />
                                                           <attribute name='roleidunique' />
                                                           <attribute name='parentrootroleid' />                                                          
                                                         </entity>
                                                       </fetch>";

    private const string teamsFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                 <entity name='team'>
                                                    <attribute name='name' />
                                                    <attribute name='businessunitid' />
                                                    <attribute name='teamid' />
                                                    <attribute name='teamtype' />
                                                    <attribute name='teamtype' />
                                                    <attribute name='systemmanaged' />
                                                    <attribute name='isdefault' />
                                                    <attribute name='emailaddress' />
                                                    <attribute name='transactioncurrencyid' />
                                                    <attribute name='administratorid' />
                                                    <filter type='and'>
                                                        <condition attribute='teamtype' operator='eq' value='0' />
                                                    </filter>
                                                </entity>
                                              </fetch>";

    private const string teamRolesFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' >
                                                    <entity name='teamroles' >
                                                        <attribute name='roleid' />
                                                        <attribute name='teamid' />
                                                        <attribute name='teamroleid' />
                                                        <link-entity name='team' from='teamid' to='teamid' alias='t' >
                                                            <attribute name='teamid' />
                                                            <attribute name='name' />
                                                            <attribute name='businessunitid' />
                                                            <attribute name='emailaddress' />
                                                            <attribute name='organizationid' />
                                                            <filter>
                                                                <condition attribute='teamtype' operator='eq' value='0' />
                                                            </filter>
                                                        </link-entity>
                                                        <link-entity name='role' from='roleid' to='roleid' alias='tr' >
                                                            <attribute name='name' />
                                                            <attribute name='businessunitid' />
                                                            <attribute name='roleid' />
                                                            <attribute name='roleidunique' />
                                                        </link-entity>
                                                    </entity>
                                                   </fetch>";

    private const string userRolesFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                     <entity name='systemuserroles' >
                                                        <attribute name='systemuserroleid' />
                                                        <attribute name='roleid' />
                                                        <attribute name='systemuserid' />
                                                        <link-entity name='systemuser' from='systemuserid' to='systemuserid' alias='su' >
                                                            <attribute name='systemuserid' />
                                                            <attribute name='domainname' />
                                                            <attribute name='fullname' />
                                                            <attribute name='isdisabled' />
                                                            {FILTER}
                                                        </link-entity>
                                                        <link-entity name='role' from='roleid' to='roleid' link-type='inner' alias='ur' >
                                                            <attribute name='name' />
                                                            <attribute name='businessunitid' />
                                                            <attribute name='roleid' />
                                                            <attribute name='roleidunique' />
                                                            <attribute name='parentrootroleid' />
                                                        </link-entity>
                                                     </entity>
                                                   </fetch>";

    private const string businessUnitFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                        <entity name='businessunit'>
                                                            <attribute name='name' />
                                                            <attribute name='parentbusinessunitid' />
                                                            <attribute name='businessunitid' />
                                                            <filter type='and'>
                                                                <condition attribute='name' operator='eq' value='{BUNAME}' />
                                                            </filter>
                                                        </entity>
                                                     </fetch>";

    private const string filterDisabledUsersFetchXml = @"<filter><condition attribute='isdisabled' operator='eq' value='0' /></filter>";

    private const string filterUnLicensedUsersFetchXml = @"<filter><condition attribute='islicensed' operator='eq' value='1' /></filter>";

    // Filter for only enabled AND licensed users.
    private const string filterUnLicensedAndDisabledFetchXml = @"<filter type='and'>
                                                                   <condition attribute='islicensed' operator='eq' value='1' />
                                                                   <condition attribute='isdisabled' operator='eq' value='0' />
                                                                 </filter>";

    private const string teammembershipFetchXml = @"<fetch>
                                                          <entity name='teammembership'>
                                                            <attribute name='teammembershipid' />
                                                            <attribute name='teamid' />
                                                            <attribute name='systemuserid' />
                                                            <link-entity name='systemuser' from='systemuserid' to='systemuserid' alias='su' >
                                                              <attribute name='systemuserid' />
                                                              <attribute name='domainname' />
                                                              <attribute name='fullname' />
                                                              <attribute name='businessunitid' />
                                                              <attribute name='isdisabled' />
                                                            </link-entity>
                                                            <link-entity name='team' from='teamid' to='teamid' alias='t' >
                                                              <filter>
                                                                <condition attribute='teamtype' operator='eq' value='0' />
                                                              </filter>
                                                            </link-entity>
                                                          </entity>
                                                        </fetch>";

    private const string systemUserMappingFetchXml = @"<fetch>
                                                         <entity name='systemuser' >
                                                           <attribute name='internalemailaddress' />
                                                           <attribute name='territoryid' />
                                                           <attribute name='disabledreason' />
                                                           <attribute name='lastname' />
                                                           <attribute name='firstname' />
                                                           <attribute name='systemuserid' />
                                                           <attribute name='organizationid' />
                                                           <attribute name='siteid' />
                                                           <attribute name='domainname' />
                                                           <attribute name='parentsystemuserid' />
                                                           <attribute name='businessunitid' />
                                                           <attribute name='fullname' />
                                                           <attribute name='isdisabled' />
                                                           <attribute name='islicensed' />
                                                           <attribute name='identityid' />
                                                         </entity>
													                             </fetch>";

    
    // Query specific to OTIS UK
    private const string systemUsersFetchXml = @"<fetch>
                                                       <entity name='systemuser' >
                                                         <attribute name='internalemailaddress' />
                                                         <attribute name='territoryid' />
                                                         <attribute name='disabledreason' />
                                                         <attribute name='lastname' />
                                                         <attribute name='firstname' />
                                                         <attribute name='systemuserid' />
                                                         <attribute name='organizationid' />
                                                         <attribute name='siteid' />
                                                         <attribute name='domainname' />
                                                         <attribute name='parentsystemuserid' />
                                                         <attribute name='businessunitid' />
                                                         <attribute name='fullname' />
                                                         <attribute name='isdisabled' />
                                                         <attribute name='islicensed' />
                                                         <attribute name='identityid' />
                                                         {FILTER}
                                                         <link-entity name='usersettings' from='systemuserid' to='systemuserid' alias='sus' >
                                                           <attribute name='uilanguageid' />
                                                           <attribute name='timezonecode' />
                                                           <attribute name='localeid' />
                                                           <attribute name='transactioncurrencyid' />
                                                         </link-entity>
                                                       </entity>
													 </fetch>";

    private const string mobileProjectsFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                            <entity name='resco_mobileproject'>
                                                                <attribute name='resco_mobileprojectid' />
                                                                <attribute name='resco_name' />
                                                                <attribute name='createdon' />
                                                                <attribute name='resco_type' />
                                                                <attribute name='statuscode' />
                                                                <attribute name='statecode' />
                                                                <attribute name='resco_rootmobileprojectid' />
                                                                <attribute name='resco_roleid' />
                                                                <attribute name='resco_publishedversion' />
                                                                <attribute name='resco_publishedon' />
                                                                <attribute name='resco_priority' />
                                                                <attribute name='resco_parents' />
                                                                <attribute name='modifiedon' />
                                                                <attribute name='modifiedby' />
                                                                <attribute name='resco_isdirty' />
                                                                <attribute name='createdby' />
                                                                <order attribute='resco_name' descending='false' />
                                                            </entity>
                                                        </fetch>";

    private const string mobileDataFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                         <entity name='resco_mobiledata'>
                                                           <attribute name='resco_mobiledataid' />
                                                           <attribute name='resco_regardingobjectid' />
                                                           <attribute name='createdon' />
                                                           <attribute name='statuscode' />
                                                           <attribute name='statecode' />
                                                           <attribute name='resco_sequencenumber' />
                                                           <attribute name='modifiedon' />
                                                           <attribute name='modifiedby' />
                                                           <attribute name='resco_data' />
                                                           <attribute name='createdby' />
                                                           <order attribute='resco_regardingobjectid' descending='false' />
                                                           <filter type='and'>
                                                             <condition attribute='resco_regardingobjectid' operator='eq' value='{REGARDINGOBJECTID}' />
                                                           </filter>
                                                         </entity>
                                                       </fetch>";

    private const string woFetchXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                <entity name='msdyn_workorder'>
                                                    <attribute name='msdyn_name' />
                                                    <attribute name='createdon' />
                                                    <attribute name='msdyn_serviceaccount' />
                                                    <attribute name='msdyn_workorderid' />
                                                    <attribute name='msdyn_worklocation' />
                                                    <attribute name='msdyn_timewindowstart' />
                                                    <attribute name='msdyn_timewindowend' />
                                                    <attribute name='msdyn_timetopromised' />
                                                    <attribute name='msdyn_timegroup' />
                                                    <attribute name='msdyn_timefrompromised' />
                                                    <attribute name='msdyn_taxcode' />
                                                    <attribute name='msdyn_taxable' />
                                                    <attribute name='msdyn_systemstatus' />
                                                    <attribute name='msdyn_substatus' />
                                                    <attribute name='msdyn_serviceterritory' />
                                                    <attribute name='msdyn_servicerequest' />
                                                    <attribute name='msdyn_priority' />
                                                    <attribute name='msdyn_longitude' />
                                                    <attribute name='msdyn_latitude' />
                                                    <attribute name='msdyn_datewindowstart' />
                                                    <attribute name='msdyn_datewindowend' />
                                                    <attribute name='f12fs_f12fsrelatedrecordscreated' />
                                                    <attribute name='msdyn_preferredresource' />
                                                    <attribute name='ownerid' />
                                                    <attribute name='statecode' />
                                                    <attribute name='statuscode' />
                                                    {FILTERRECORDSCREATED}
                                                    {FILTERCOMPLETED}
                                                </entity>
                                            </fetch>";

    private const string primaryRequirementtXml = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                            <entity name='msdyn_resourcerequirement'>
                                                                <attribute name='msdyn_resourcerequirementid' />
                                                                <attribute name='msdyn_name' />
                                                                <filter type='and'>
                                                                    <condition attribute='msdyn_isprimary' operator='eq' value='1' />
                                                                    <condition attribute='msdyn_workorder' operator='eq' uitype='msdyn_workorder' value='{WOGUID}' />
                                                                </filter>
                                                            </entity>
                                                        </fetch>";

    private const string fetchxmlWOBookingMetadata = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                            <entity name='msdyn_bookingsetupmetadata'>
                                                                <attribute name='msdyn_bookingsetupmetadataid' />
                                                                <attribute name='msdyn_entitylogicalname' />                                                         
                                                                <filter type='and'>
                                                                    <condition attribute='msdyn_entitylogicalname' operator='eq' value='msdyn_workorder' />
                                                                </filter>
                                                            </entity>
                                                           </fetch>";

    private const string fetchXmlWOCharacteristics = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                            <entity name='msdyn_workordercharacteristic'>
                                                                <attribute name='createdon' />
                                                                <attribute name='msdyn_workorderincident' />
                                                                <attribute name='msdyn_ratingvalue' />
                                                                <attribute name='msdyn_characteristic' />
                                                                <attribute name='msdyn_workordercharacteristicid' />
                                                                <attribute name='msdyn_workorder' />
                                                                <attribute name='msdyn_name' />
                                                                <attribute name='msdyn_internalflags' />
                                                                <attribute name='statuscode' />
                                                                <attribute name='statecode' />
                                                                <filter type='and'>
                                                                    <condition attribute='msdyn_workorder' operator='eq' uitype='msdyn_workorder' value='{WOGUID}' />
                                                                </filter>
                                                            </entity>
                                                           </fetch>";

    private const string fetchXmlWOIncidents = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                        <entity name='msdyn_workorderincident'>
                                                          <attribute name='msdyn_name' />
                                                          <attribute name='msdyn_workorder' />
                                                          <attribute name='msdyn_workorderincidentid' />
                                                          <attribute name='msdyn_resourcerequirement' />
                                                          <attribute name='ownerid' />
                                                          <filter type='and'>
                                                            <condition attribute='msdyn_workorder' operator='eq' uitype='msdyn_workorder' value='{WOGUID}' />
                                                            <condition attribute='msdyn_resourcerequirement' operator='null' />
                                                          </filter>
                                                        </entity>
                                                      </fetch>";

    private const string fetchXmlWOBookings = @"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                                                        <entity name='bookableresourcebooking'>
                                                            <attribute name='createdon' />
                                                            <attribute name='starttime' />
                                                            <attribute name='resource' />
                                                            <attribute name='endtime' />
                                                            <attribute name='duration' />
                                                            <attribute name='bookingtype' />
                                                            <attribute name='bookingstatus' />
                                                            <attribute name='bookableresourcebookingid' />
                                                            <attribute name='statuscode' />
                                                            <attribute name='statecode' />
                                                            <attribute name='ownerid' />
                                                            <attribute name='name' />
                                                            <attribute name='msdyn_workorder' />
                                                            <attribute name='msdyn_totaldurationinprogress' />
                                                            <attribute name='msdyn_totalcost' />
                                                            <attribute name='msdyn_totalbreakduration' />
                                                            <attribute name='msdyn_totalbillableduration' />
                                                            <attribute name='msdyn_resourcerequirement' />
                                                            <attribute name='msdyn_longitude' />
                                                            <attribute name='msdyn_latitude' />
                                                            <attribute name='msdyn_estimatedtravelduration' />
                                                            <attribute name='msdyn_estimatedarrivaltime' />
                                                            <attribute name='msdyn_bookingsetupmetadataid' />
                                                            <attribute name='msdyn_bookingmethod' />
                                                            <attribute name='msdyn_actualtravelduration' />
                                                            <attribute name='msdyn_actualarrivaltime' />
                                                            <filter type='and'>
                                                                <condition attribute='msdyn_workorder' operator='eq' uitype='msdyn_workorder' value='{WOGUID}' />
                                                            </filter>
                                                        </entity>
                                                    </fetch>";
    #endregion

    public IOrganizationService TargetService {
      get { return crmTargetSvc; }
      set { crmTargetSvc = value; }
    }

    public IOrganizationService SourceService {
      get { return crmSourceSvc; }
      set { crmSourceSvc = value; }
    }

    private UpgradeUtility() { }

    public UpgradeUtility(IOrganizationService svcTarget, IOrganizationService svcSource) {
      crmTargetSvc = svcTarget;
      crmSourceSvc = svcSource;
      pluginsDisabled = new List<Guid>();
      pluginsEnabled = new List<Guid>();
      workflowsDisabled = new List<Guid>();
      workflowsEnabled = new List<Guid>();
    }

    public EntityMetadata[] RetrieveTargetEntityList() {
      RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest() {
        EntityFilters = EntityFilters.Entity,
        RetrieveAsIfPublished = true
      };
      RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)crmTargetSvc.Execute(request);
      return response.EntityMetadata;
    }

    public EntityMetadata[] RetrieveSourceEntityList() {
      RetrieveAllEntitiesRequest request = new RetrieveAllEntitiesRequest() {
        EntityFilters = EntityFilters.Entity,
        RetrieveAsIfPublished = true
      };
      RetrieveAllEntitiesResponse response = (RetrieveAllEntitiesResponse)crmSourceSvc.Execute(request);
      return response.EntityMetadata;
    }

    public Entity RetrieveTargetWOBookingMetadata() {
      List<Entity> bookingMetadataRecords = RetrieveAllTargetRecords(fetchxmlWOBookingMetadata);
      // assume the record was retrieved and only one record was retrieved.
      return bookingMetadataRecords[0];
    }

    public void DisableAllTargetPluginsAndWorkFlowsByEntity(BackgroundWorker worker, string entityName) {
      if (!DeactivateAllTargetWorkflowsByEntity(worker, entityName)) {
        throw new InvalidOperationException($"Error disabeling workflows for entity: {entityName}");
      }

      if (worker.CancellationPending)
        return;

      //_logger.Log("Disable all plugins on " + entityName);
      if (!DisableAllTargetPluginsByEntity(worker, entityName)) {
        throw new InvalidOperationException($"Error disabeling Plugin Steps for entity: {entityName}");
      }
    }

    #region Workflow Functions
    public List<Workflow> RetrieveTargetWorkflowList(string entityName) {
      var workflows = new List<Workflow>();
      EntityCollection results = null;
      int entityObjectTypeCode = this.GetTargetEntityObjectTypeCode(entityName);
      results = RetrieveTargetWorkflows(entityObjectTypeCode);

      if (results != null) {
        workflows.AddRange(results.Entities
            .Select(entity => new Workflow {
              Id = entity.Id,
              Name = entity.GetAttributeValue<string>("name"),
              State = entity.GetAttributeValue<OptionSetValue>("statecode").Value == 1
                    ? ActivationState.Active
                    : ActivationState.Inactive,
              WorkFlowCategory = entity.GetAttributeValue<OptionSetValue>("category").Value == 0 ? WorkflowCategory.Workflow :
                    entity.GetAttributeValue<OptionSetValue>("category").Value == 1 ? WorkflowCategory.Dialog :
                    entity.GetAttributeValue<OptionSetValue>("category").Value == 2 ? WorkflowCategory.BusinessRule :
                    entity.GetAttributeValue<OptionSetValue>("category").Value == 3 ? WorkflowCategory.Action : WorkflowCategory.BusinessProcessFlow,
              PrimaryEntity = entity.GetAttributeValue<string>("primaryentity"),
              IsManaged = entity.GetAttributeValue<bool>("ismanaged") ? "Managed" : "Unmanaged",
              Entity = entity
            }));
      }
      return workflows;
    }

    internal int Percent(int current, int total) {
      int percentComplete = 0;
      try {
        percentComplete = (int)(0.5f + ((100f * current) / total));
      }
      catch { percentComplete = 0; }
      return percentComplete;
    }

    public List<Workflow> RetrieveTargetWorkflowList(ActivationState state) {
      var workflows = new List<Workflow>();
      EntityCollection results = null;
      int stateCode = state == ActivationState.Active ? 1 : 0;

      try {
        string fetchXML = string.Format(@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                  <entity name='workflow'>
                    <all-attributes/>
                      <filter type='and'>
                        <condition attribute='type' operator='eq' value='1' />
                        <condition attribute='rendererobjecttypecode' operator='null' />
                        <condition attribute='category' operator='in'>
                          <value>0</value>
                          <value>2</value>
                        </condition>
                        STATEFILTER
                      </filter>                                  
                  </entity>
                </fetch>");

        if (state == ActivationState.All) {
          fetchXML = fetchXML.Replace("STATEFILTER", "");
        }
        else {
          fetchXML = fetchXML.Replace("STATEFILTER", $"<condition attribute='statecode' operator='eq' value='{stateCode}' />");
        }

        //query.Criteria.AddCondition("rendererobjecttypecode", ConditionOperator.Null); // BUG#732849 - Filter system-generated workflows (e.g. SLA feature)
        //query.Criteria.AddCondition("category", ConditionOperator.In, new object[] { 0, 2 }); // BUG#734732 - Filter BPF, Action, and Dialog workflow categories

        results = crmTargetSvc.RetrieveMultiple(new FetchExpression(fetchXML));
      }
      catch (Exception ex) {
        throw ex;
      }

      // Convert results to Workflow type
      if (results != null) {
        workflows.AddRange(results.Entities
            .Select(entity => new Workflow {
              Id = entity.Id,
              Name = entity.GetAttributeValue<string>("name"),
              State = entity.GetAttributeValue<OptionSetValue>("statecode").Value == 1
                    ? ActivationState.Active
                    : ActivationState.Inactive,
              WorkFlowCategory = entity.GetAttributeValue<OptionSetValue>("category").Value == 0 ? WorkflowCategory.Workflow :
                    entity.GetAttributeValue<OptionSetValue>("category").Value == 1 ? WorkflowCategory.Dialog :
                    entity.GetAttributeValue<OptionSetValue>("category").Value == 2 ? WorkflowCategory.BusinessRule :
                    entity.GetAttributeValue<OptionSetValue>("category").Value == 3 ? WorkflowCategory.Action : WorkflowCategory.BusinessProcessFlow,
              PrimaryEntity = entity.GetAttributeValue<string>("primaryentity"),
              IsManaged = entity.GetAttributeValue<bool>("ismanaged") ? "Managed" : "Unmanaged",
              Entity = entity
            }));
      }
      return workflows;
    }

    public EntityCollection RetrieveTargetWorkflows(int entityObjectTypeCode) {
      if (entityObjectTypeCode == null || entityObjectTypeCode == -1)
        throw new Exception("Unable to load workflows, entityObjectTypeCode is not specified.");

      string fetchXML = $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                  <entity name='workflow'>
                    <all-attributes/>
                      <filter type='and'>
                        <condition attribute='type' operator='eq' value='1' />
                        <condition attribute='primaryentity' operator='eq' value='{entityObjectTypeCode}' /> 
                      </filter>                                  
                  </entity>
                </fetch>";
      try {
        var results = crmTargetSvc.RetrieveMultiple(new FetchExpression(fetchXML));
        return results;
      }
      catch (Exception e) {
        var results = new EntityCollection();
        return results;
      }
    }

    public bool ActivateAllTargetWorkflowsByEntity(BackgroundWorker worker, string workflowPrimaryEntityName) {
      if (string.IsNullOrEmpty(workflowPrimaryEntityName)) { throw new System.ArgumentException("Value can not be null or empty", workflowPrimaryEntityName); }

      try {
        int iCounter = 0;
        int percent = 0;
        var entityObjectTypeCode = GetTargetEntityObjectTypeCode(workflowPrimaryEntityName);
        if (entityObjectTypeCode == -1) { throw new System.ArgumentException("ObjectTypeCode can not be null", "entityObjectTypeCode"); }
        var workflows = RetrieveTargetWorkflows(entityObjectTypeCode);
        foreach (var workflow in workflows.Entities) {
          if (worker.CancellationPending)
            break;
          iCounter++;
          percent = Percent(iCounter, workflows.Entities.Count);
          worker.ReportProgress(percent);
          ActivateTargetWorkflow(workflow.Id);
        }
      }
      catch (Exception e) { throw new SystemException(e.Message); }
      return true;
    }

    public bool ActivateTargetWorkflow(Guid _workflowGuidID) {
      if (_workflowGuidID == null) { throw new System.ArgumentException("Parameter can not be null.", "workflowId"); }
      try {
        var activateRequest = new SetStateRequest {
          EntityMoniker = new EntityReference
                  ("workflow", _workflowGuidID),
          State = new OptionSetValue((int)WorkflowState.Activated),
          Status = new OptionSetValue((int)WorkflowStatus.Activated)
        };

        crmTargetSvc.Execute(activateRequest);

        if (workflowsDisabled.Contains(_workflowGuidID))
          workflowsDisabled.Remove(_workflowGuidID);
        else
          workflowsEnabled.Add(_workflowGuidID);

        return true;
      }
      catch (Exception e) {
        return false;
      }
    }

    public bool DeactivateAllTargetWorkflowsByEntity(BackgroundWorker worker, string workflowPrimaryEntityName) {
      if (string.IsNullOrEmpty(workflowPrimaryEntityName)) { throw new System.ArgumentException("Value can not be null or empty", workflowPrimaryEntityName); }

      try {
        int iCounter = 0;
        int percent = 0;
        var entityObjectTypeCode = GetTargetEntityObjectTypeCode(workflowPrimaryEntityName);
        if (entityObjectTypeCode == -1) { throw new System.ArgumentException("ObjectTypeCode can not be null", "entityObjectTypeCode"); }
        var workflows = RetrieveTargetWorkflows(entityObjectTypeCode);
        foreach (var workflow in workflows.Entities) {
          if (worker.CancellationPending)
            break;
          iCounter++;
          percent = Percent(iCounter, workflows.Entities.Count);
          worker.ReportProgress(percent);
          DeactivateTargetWorkflow(workflow.Id);
        }
      }
      catch (Exception e) { throw new SystemException(e.Message); }
      return true;
    }

    public bool DeactivateTargetWorkflow(Guid workflowGuidId) {
      if (workflowGuidId == null) { throw new System.ArgumentException("Parameter can not be null.", "workflowId"); }
      try {
        SetStateRequest deactivateRequest = new SetStateRequest {
          EntityMoniker =
                new EntityReference("workflow", workflowGuidId),
          State = new OptionSetValue((int)WorkflowState.Draft),
          Status = new OptionSetValue((int)WorkflowStatus.Draft)
        };

        crmTargetSvc.Execute(deactivateRequest);

        if (workflowsEnabled.Contains(workflowGuidId))
          workflowsEnabled.Remove(workflowGuidId);
        else
          workflowsDisabled.Add(workflowGuidId);

        return true;
      }
      catch (Exception e) {
        return false;
      }
    }

    public bool ReturnTargetWorkflowsToOriginalState() {
      try {
        foreach (var id in workflowsDisabled) {
          SetStateRequest setStateReq = new SetStateRequest {
            EntityMoniker =
             new EntityReference("workflow", id),
            State = new OptionSetValue((int)WorkflowState.Activated),
            Status = new OptionSetValue((int)WorkflowStatus.Activated)
          };
          crmTargetSvc.Execute(setStateReq);
        }
        workflowsDisabled.Clear();

        foreach (var id in workflowsEnabled) {
          SetStateRequest setStateReq = new SetStateRequest {
            EntityMoniker =
              new EntityReference("workflow", id),
            State = new OptionSetValue((int)WorkflowState.Draft),
            Status = new OptionSetValue((int)WorkflowStatus.Draft)
          };
          crmTargetSvc.Execute(setStateReq);
        }
        workflowsEnabled.Clear();

        return true;
      }
      catch (Exception e) {
        return false;
      }
    }
    #endregion

    #region Plugin Functions
    public List<PluginStep> RetrieveTargetPluginStepList(string entityName) {
      var plugins = new List<PluginStep>();
      int entityTypeCode = GetTargetEntityObjectTypeCode(entityName);
      EntityCollection results = RetrieveTargetPluginSteps(entityTypeCode);

      // Convert results to Plugin type
      if (results != null) {
        plugins.AddRange(results.Entities
            .Select(entity => new PluginStep {
              Id = entity.Id,
              Name = entity.GetAttributeValue<string>("name"),
              State = entity.GetAttributeValue<OptionSetValue>("statecode").Value == 0
                    ? ActivationState.Active
                    : ActivationState.Inactive,
              EventHandler = entity.GetAttributeValue<EntityReference>("eventhandler").Name,
              IsManaged = entity.GetAttributeValue<bool>("ismanaged") ? "Managed" : "Unmanaged",
              PrimaryEntity = entity.GetAttributeValue<AliasedValue>("a1.primaryobjecttypecode").Value.ToString(),
              Entity = entity
            }));
      }
      return plugins;
    }

    public List<PluginStep> RetrieveTargetPluginStepList(ActivationState state) {
      var plugins = new List<PluginStep>();
      EntityCollection results = null;

      try {
        int stateCode = state == ActivationState.Active ? 0 : 1;
        string fetchXML = $@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                  <entity name='sdkmessageprocessingstep'>
                    <all-attributes/>
                        <filter type='and'>
                            <condition attribute='ishidden' operator='eq' value='0' />
                            STATEFILTER                            
                        </filter>
                        <link-entity name='sdkmessagefilter' from='sdkmessagefilterid' to='sdkmessagefilterid' alias='a1'>
                          <attribute name='secondaryobjecttypecode' />
                          <attribute name='primaryobjecttypecode' />
                        </link-entity>
                  </entity>
                </fetch>";

        //<condition attribute='stage' operator='ne' value='30' />
        //query.Criteria.AddCondition("iscustomizable", ConditionOperator.Equal, true);
        //query.Criteria.AddCondition("ishidden", ConditionOperator.Equal, false);

        if (state == ActivationState.All) {
          fetchXML = fetchXML.Replace("SATEFILTER", "");
        }
        else {
          fetchXML = fetchXML.Replace("STATEFILTER", $"<condition value='{stateCode}' operator='eq' attribute='statecode' />");
        }
        results = crmTargetSvc.RetrieveMultiple(new FetchExpression(fetchXML));
      }
      catch (Exception ex) {
        throw ex;
      }

      // Convert results to Plugin type
      if (results != null) {
        plugins.AddRange(results.Entities
            .Select(entity => new PluginStep {
              Id = entity.Id,
              Name = entity.GetAttributeValue<string>("name"),
              State = entity.GetAttributeValue<OptionSetValue>("statecode").Value == 0
                    ? ActivationState.Active
                    : ActivationState.Inactive,
              EventHandler = entity.GetAttributeValue<EntityReference>("eventhandler").Name,
              IsManaged = entity.GetAttributeValue<bool>("ismanaged") ? "Managed" : "Unmanaged",
              PrimaryEntity = entity.GetAttributeValue<AliasedValue>("a1.primaryobjecttypecode").Value.ToString(),
              Entity = entity
            }));
      }
      return plugins;
    }

    private EntityCollection RetrieveTargetPluginSteps(int entityObjectTypeCode) {
      string fetchXML = string.Format(@"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false'>
                  <entity name='sdkmessageprocessingstep'>
                    <all-attributes/>
                        <filter type='and'>
                            <condition attribute='ishidden' operator='eq' value='0' />                  
                        </filter>
                        <link-entity name='sdkmessagefilter' from='sdkmessagefilterid' to='sdkmessagefilterid' alias='a1'>
                          <attribute name='secondaryobjecttypecode' />
                          <attribute name='primaryobjecttypecode' />
                              <filter type='and'>
                                <condition attribute='primaryobjecttypecode' operator='eq' value='{0}' />
                              </filter>
                        </link-entity>
                  </entity>
                </fetch>", entityObjectTypeCode);
      //<condition value='0' operator='eq' attribute='statecode'/>  
      //<condition attribute='stage' operator='ne' value='30' />  
      try {
        return crmTargetSvc.RetrieveMultiple(new FetchExpression(fetchXML));
      }
      catch (Exception e) {
        EntityCollection empty = new EntityCollection();
        return empty;
      }
    }

    public bool DisableAllTargetPluginsByEntity(BackgroundWorker worker, string entityLogicalName) {
      try {
        int iCounter = 0;
        int percent = 0;
        var objectTypeCode = GetTargetEntityObjectTypeCode(entityLogicalName);
        if (objectTypeCode == -1) { throw new System.ArgumentException("ObjectTypeCode can not be -1", "objectTypeCode"); }

        var messages = RetrieveTargetPluginSteps(objectTypeCode);

        foreach (var entity in messages.Entities) {
          if (worker.CancellationPending)
            break;
          iCounter++;
          percent = Percent(iCounter, messages.Entities.Count);
          worker.ReportProgress(percent);
          DisableTargetPlugin(entity.Id);
        }
      }
      catch (Exception e) {
        throw new SystemException(e.Message);
      }
      return true;
    }

    public bool DisableTargetPlugin(Guid pluginGuidId) {
      if (pluginGuidId == null) { throw new System.ArgumentException("Parameter can not be null.", "guidID"); }
      try {
        crmTargetSvc.Execute(new SetStateRequest {
          EntityMoniker = new EntityReference("sdkmessageprocessingstep", pluginGuidId),
          State = new OptionSetValue((int)PluginState.Disabled),
          Status = new OptionSetValue((int)PluginStatus.Disabled)
        });

        if (pluginsEnabled.Contains(pluginGuidId))
          pluginsEnabled.Remove(pluginGuidId);
        else
          pluginsDisabled.Add(pluginGuidId);
        return true;
      }
      catch (Exception e) {
        return false;
      }
    }

    public bool EnableAllTargetPluginsByEntity(BackgroundWorker worker, string entityLogicalName) {
      try {
        int iCounter = 0;
        int percent = 0;
        var objectTypeCode = GetTargetEntityObjectTypeCode(entityLogicalName);
        if (objectTypeCode == -1) { throw new System.ArgumentException("ObjectTypeCode can not be -1", "objectTypeCode"); }

        var messages = RetrieveTargetPluginSteps(objectTypeCode);

        foreach (var entity in messages.Entities) {
          if (worker.CancellationPending)
            break;
          iCounter++;
          percent = Percent(iCounter, messages.Entities.Count);
          worker.ReportProgress(percent);
          EnableTargetPlugin(entity.Id);
        }
      }
      catch (Exception e) {
        throw new SystemException(e.Message);
      }
      return true;
    }

    public bool EnableTargetPlugin(Guid pluginGuidId) {
      try {
        crmTargetSvc.Execute(new SetStateRequest {
          EntityMoniker = new EntityReference("sdkmessageprocessingstep", pluginGuidId),
          State = new OptionSetValue((int)PluginState.Enabled),
          Status = new OptionSetValue((int)PluginStatus.Enabled)
        });
        if (pluginsDisabled.Contains(pluginGuidId))
          pluginsDisabled.Remove(pluginGuidId);
        else
          pluginsEnabled.Add(pluginGuidId);
        return true;
      }
      catch (Exception e) {
        return false;
      }
    }

    public bool ReturnTargetPluginsToOriginalState() {
      try {
        foreach (var id in pluginsDisabled) {
          crmTargetSvc.Execute(new SetStateRequest {
            EntityMoniker = new EntityReference("sdkmessageprocessingstep", id),
            State = new OptionSetValue((int)PluginState.Enabled),
            Status = new OptionSetValue((int)PluginStatus.Enabled)
          });
        }
        pluginsDisabled = new List<Guid>();
        foreach (var id in pluginsEnabled) {
          crmTargetSvc.Execute(new SetStateRequest {
            EntityMoniker = new EntityReference("sdkmessageprocessingstep", id),
            State = new OptionSetValue((int)PluginState.Disabled),
            Status = new OptionSetValue((int)PluginStatus.Disabled)
          });
        }
        pluginsEnabled = new List<Guid>();
        return true;
      }
      catch (Exception e) {
        return false;
      }
    }
    #endregion

    public List<Entity> RetrieveAllSourceTeams() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(teamsFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetTeams() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(teamsFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceTeamSecurity() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(teamRolesFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetTeamSecurity() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(teamRolesFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceUsers(bool hideDisabled, bool hideUnlicensed) {
      string fetchXml = "";

      if (crmSourceSvc != null) {
        // hide both disabled and unlicensed
        if (hideDisabled && hideUnlicensed) {
          fetchXml = systemUsersFetchXml.Replace("{FILTER}", filterUnLicensedAndDisabledFetchXml);
        }
        // hide disabled
        else if (hideDisabled && !hideUnlicensed) {
          fetchXml = systemUsersFetchXml.Replace("{FILTER}", filterDisabledUsersFetchXml);
        }
        // hide unlicensed
        else if (!hideDisabled && hideUnlicensed) {
          fetchXml = systemUsersFetchXml.Replace("{FILTER}", filterUnLicensedUsersFetchXml);
        }
        // hide NOTHING
        else {
          fetchXml = systemUsersFetchXml.Replace("{FILTER}", "");
        }

        
        return RetrieveAllSourceRecords(fetchXml);
      }
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetUsers() {
      if (crmTargetSvc != null) {
        return RetrieveAllTargetRecords(systemUsersFetchXml.Replace("{FILTER}", ""));
      }
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetCurrencies() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(currencyFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceCurrencies() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(currencyFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveTargetAgreementFailedJobs(DateTime start, DateTime end) {
      if (crmTargetSvc != null) {
        return RetrieveAllTargetRecords(agreementInvoiceSetupSystemJobFailures.Replace("{START}", start.ToShortDateString()).Replace("{END}", end.ToShortDateString()));
      }
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetBusinessUnits() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(bussinessUnitAllFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceBusinessUnits() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(bussinessUnitAllFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceUOM() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(uomAllFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetUOM() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(uomAllFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceUOMSchedule() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(uomScheduleAllFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetUOMSchedule() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(uomScheduleAllFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceRoles() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(securityRolesFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveActiveTargetBookingSetups() {
      if (crmSourceSvc != null)
        return RetrieveAllTargetRecords(activeAgreementBookingSetupFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetRoles() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(securityRolesFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceUserSecurity(bool hideDisabled) {
      if (crmSourceSvc != null) {
        string fetchXml = hideDisabled ? userRolesFetchXml.Replace("{FILTER}", filterDisabledUsersFetchXml) : userRolesFetchXml.Replace("{FILTER}", "");
        return RetrieveAllSourceRecords(fetchXml);
      }
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetUserSecurity() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(userRolesFetchXml.Replace("{FILTER}", ""));
      else
        return null;
    }

    public List<Entity> RetrieveTargetUserAssignedRoles(Guid userId) {
      if (crmTargetSvc != null) {
        string xml = userAssignedRolesFetchXml.Replace("{USERID}", userId.ToString());
        return RetrieveAllTargetRecords(xml);
      }
      else
        return null;
    }

    public List<Entity> RetrieveTargetTeamAssignedRoles(Guid teamId) {
      if (crmTargetSvc != null) {
        string xml = teamAssignedRolesFetchXml.Replace("{TEAMID}", teamId.ToString());
        return RetrieveAllTargetRecords(xml);
      }
      else
        return null;
    }

    public void UpdateTargetBookingSetup(Entity bookingSetup, int dayOfWeek, string startDate) {
      string pattern = agreementBookingRecurrancePatter.Replace("{DAYOFWEEK}", dayOfWeek.ToString()).Replace("{START}", startDate);

      if (bookingSetup.Contains("msdyn_recurrencesettings"))
        bookingSetup["msdyn_recurrencesettings"] = pattern;
      else
        bookingSetup.Attributes.Add("msdyn_recurrencesettings", pattern);

      if (bookingSetup.Contains("msdyn_postponegenerationuntil"))
        bookingSetup["msdyn_postponegenerationuntil"] = DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0));
      else
        bookingSetup.Attributes.Add("msdyn_postponegenerationuntil", DateTime.Now.Subtract(new TimeSpan(1, 0, 0, 0)));

      //if (bookingSetup.Contains("msdyn_revision"))
      //    bookingSetup["msdyn_revision"] = bookingSetup.GetAttributeValue<int>("msdyn_revision") + 1;

      crmTargetSvc.Update(bookingSetup);

      //int iTotalProcessed = 0;
      //int iCurrent = 0;

      //var updateRequests = new ExecuteMultipleRequest() {
      //    Settings = new ExecuteMultipleSettings() {
      //        ContinueOnError = true,
      //        ReturnResponses = true
      //    },
      //    Requests = new OrganizationRequestCollection()
      //};

      //foreach (Entity e in bookingSetups) {
      //    iCurrent++;
      //    iTotalProcessed++;

      //    if (e.Contains("msdyn_recurrencesettings"))
      //        e["msdyn_recurrencesettings"] = pattern;
      //    else
      //        e.Attributes.Add("msdyn_recurrencesettings", pattern);

      //    if (e.Contains("msdyn_revision"))
      //        e["msdyn_revision"] = e.GetAttributeValue<int>("msdyn_revision") + 1;

      //    UpdateRequest ur = new UpdateRequest() {
      //        Target = e
      //    };

      //    if (iCurrent == 25) {
      //        //(ExecuteMultipleResponse)crmSvc.Execute(setStateRequests);
      //        var resp = (ExecuteMultipleResponse)crmTargetSvc.Execute(updateRequests);
      //        if (resp.IsFaulted) {
      //            string error = "Yes";
      //            // log the errors here.
      //        }
      //        updateRequests.Requests.Clear();
      //        iCurrent = 0;
      //    }
      //}

      //if (updateRequests.Requests.Count > 0) {
      //    var resp = (ExecuteMultipleResponse)crmTargetSvc.Execute(updateRequests);
      //    if (resp.IsFaulted) {
      //        string error = "Yes";
      //        // log the errors here.
      //    }
      //}
    }

    public void CreateTargetWorkOrderRelatedRecords(BackgroundWorker bw, CreateWorkOrderRelatedRecordsArgs args) {
      Guid requirementId = Guid.Empty;
      Guid requirementCharacteristicId = Guid.Empty;
      Guid requirementResourcePreferenceId = Guid.Empty;
      Entity newRequirement = null;

      // First make sure all work orders have a resource requirement created.

      // Since the work order entity does not have a lookup to a resource requirement where that lookup will ALWAYS contain a value
      // we are going to use a rather inefficient process.   We will look at every single work order in the system where the custom
      // attribute "f12fs_f12fsrelatedrecordscreated" is false.
      string fetchXml = woFetchXml;
      if (args.IgnoreRelatedRecordsCreatedFlag)
        fetchXml = fetchXml.Replace("{FILTERRECORDSCREATED}", "");
      else
        fetchXml = fetchXml.Replace("{FILTERRECORDSCREATED}", "<filter type='and'><condition attribute='f12fs_f12fsrelatedrecordscreated' operator='ne' value='1' /></filter>");

      if (args.ProcessCompletedWorkOrders)
        fetchXml = fetchXml.Replace("{FILTERCOMPLETED}", "");
      else
        fetchXml = fetchXml.Replace("{FILTERCOMPLETED}", "<condition attribute='msdyn_systemstatus' operator='not-in'><value>690970005</value><value>690970004</value></condition>"); // TODO: Add logic to filter out Completed work orders.

      bw.ReportProgress(0, "Retrieving list of work orders, this may take a few minutes...");
      List<Entity> workOrdersToProcess = RetrieveAllTargetRecords(fetchXml);
      Entity woBookingMetadataEntity = RetrieveTargetWOBookingMetadata();
      int iCounter = 0;
      int percent = 0;
      string processingMessage;

      bw.ReportProgress(0, "Disabeling Workflows and Plugin Steps for entity: msdyn_resourcerequirement");
      DisableAllTargetPluginsAndWorkFlowsByEntity(bw, "msdyn_resourcerequirement");

      bw.ReportProgress(0, "Disabeling Workflows and Plugin Steps for entity: msdyn_requirementcharacteristic");
      DisableAllTargetPluginsAndWorkFlowsByEntity(bw, "msdyn_requirementcharacteristic");

      bw.ReportProgress(0, "Disabeling Workflows and Plugin Steps for entity: msdyn_requirementresourcepreference");
      DisableAllTargetPluginsAndWorkFlowsByEntity(bw, "msdyn_requirementresourcepreference");

      bw.ReportProgress(0, "Disabeling Workflows and Plugin Steps for entity: msdyn_workorderincident");
      DisableAllTargetPluginsAndWorkFlowsByEntity(bw, "msdyn_workorderincident");

      bw.ReportProgress(0, "Disabeling Workflows and Plugin Steps for entity: bookableresourcebooking");
      DisableAllTargetPluginsAndWorkFlowsByEntity(bw, "bookableresourcebooking");

      bw.ReportProgress(0, "Disabeling Workflows and Plugin Steps for entity: msdyn_workorder");
      DisableAllTargetPluginsAndWorkFlowsByEntity(bw, "msdyn_workorder");

      if (bw.CancellationPending)
        return;

      // Now the part that takes a long time.  Check each work order for a primary resource requirement.
      foreach (Entity wo in workOrdersToProcess) {
        iCounter++;
        percent = (int)Math.Truncate((decimal)((iCounter / workOrdersToProcess.Count) * 100));
        processingMessage = $"Processing work order: {wo["msdyn_name"]} | {iCounter} of {workOrdersToProcess.Count}";

        bw.ReportProgress(percent, processingMessage);

        if (bw.CancellationPending)
          return;

        // get the work orders primary resource requirement
        List<Entity> relatedRequirements = RetrieveAllTargetRecords(primaryRequirementtXml.Replace("WOGUID", wo.Id.ToString()));
        if (relatedRequirements != null && relatedRequirements.Count > 0) {
          Entity woToUpdate = new Entity(wo.LogicalName, wo.Id);

          // this work order already has a primary resource requirement.   Update the work order so we do not process it again
          // TODO: Could add code to ensure the requirement and other records are configured correctly.  For now I am just assuming that if the resource requirement
          //       record exists then everything is ok.
          woToUpdate.Attributes.Add("f12fs_f12fsrelatedrecordscreated", true);
          crmTargetSvc.Update(woToUpdate);
        }
        else {
          //bw.ReportProgress(percent, $"{processingMessage} - Getting work order related records to be updated");
          List<Entity> relatedWOCharacteristics = RetrieveAllTargetRecords(fetchXmlWOCharacteristics.Replace("WOGUID", wo.Id.ToString()));
          List<Entity> relatedWOBookings = RetrieveAllTargetRecords(fetchXmlWOBookings.Replace("WOGUID", wo.Id.ToString()));
          List<Entity> relatedWOIncidents = RetrieveAllTargetRecords(fetchXmlWOIncidents.Replace("WOGUID", wo.Id.ToString()));

          //bw.ReportProgress(percent, $"{processingMessage} - Creating Resource Requirement");

          try {
            newRequirement = CreateTargetResourceRequirement(bw, wo, woBookingMetadataEntity, relatedWOIncidents, relatedWOBookings);

            if (requirementId == Guid.Empty)
              continue;

            if (wo.GetAttributeValue<OptionSetValue>("statecode").Value == 1) {
              SetStateRequest setReq = new SetStateRequest() {
                State = new OptionSetValue(1),
                Status = new OptionSetValue(2),
                EntityMoniker = new EntityReference(newRequirement.LogicalName, requirementId)
              };

              try {
                SetStateResponse setResp = (SetStateResponse)crmTargetSvc.Execute(setReq);
              }
              catch (Exception ex2) {
                // unable to set the state.   Again just delete the resource requirement which will delete all child records and we can re-process 
                // uuuuggghhhh another nested try catch.
                try {
                  crmTargetSvc.Delete(newRequirement.LogicalName, requirementId);
                  bw.ReportProgress(percent, $"{processingMessage} - Error creating resource requirement: {ex2.Message},  Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                catch (Exception ex3) {
                  // delete failed.  Tell the user that they need to delete it.
                  bw.ReportProgress(percent, $"{processingMessage} - Error creating resource requirement: {ex3.Message},  Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                finally {
                  requirementId = Guid.Empty; // set the id to Guid.Empty so we continue to the next WO.
                }
              }
            }

            if (requirementId == Guid.Empty)
              continue;

            // Create requirement characteristics                    
            if (relatedWOCharacteristics.Count > 0) {
              //bw.ReportProgress(percent, $"{processingMessage} - Creating {relatedWOCharacteristics.Count} requirement characteristic recordss");
              foreach (Entity chrs in relatedWOCharacteristics) {
                Entity requirementCharacteristic = new Entity("msdyn_requirementcharacteristic");
                requirementCharacteristic.Attributes.Add("msdyn_name", chrs.GetAttributeValue<string>("msdyn_name"));
                requirementCharacteristic.Attributes.Add("msdyn_characteristic", chrs.GetAttributeValue<EntityReference>("msdyn_characteristic"));
                requirementCharacteristic.Attributes.Add("msdyn_ratingvalue", chrs.GetAttributeValue<EntityReference>("msdyn_ratingvalue"));
                requirementCharacteristic.Attributes.Add("msdyn_workorder", chrs.GetAttributeValue<EntityReference>("msdyn_workorder"));
                requirementCharacteristic.Attributes.Add("msdyn_workorderincident", chrs.GetAttributeValue<EntityReference>("msdyn_workorderincident"));
                requirementCharacteristic.Attributes.Add("msdyn_resourcerequirement", new EntityReference("msdyn_resourcerequirement", requirementId));
                requirementCharacteristic.Attributes.Add("ownerid", wo.GetAttributeValue<EntityReference>("ownerid"));

                try {
                  requirementCharacteristicId = crmTargetSvc.Create(requirementCharacteristic);
                }
                catch (Exception ex) {
                  bw.ReportProgress(percent, $"{processingMessage} - Error creating requirement characteristics: {ex.Message}, Error creating requirement: {ex.Message}");

                  // try to delete the requirement that was created so we can re-process the work order.
                  // yes all these nested try catch blocks are ugly but this code is not about elegance rather just getting the job done :(
                  try {
                    crmTargetSvc.Delete(newRequirement.LogicalName, requirementId);
                  }
                  catch (Exception ex1) {
                    // could not delete the requirement that was created.  Tell the user to do.
                    bw.ReportProgress(percent, $"{processingMessage} - Error creating requirement characteristics: {ex1.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                  }
                  finally {
                    requirementId = Guid.Empty;
                  }
                }

                if (requirementId == Guid.Empty)
                  continue;

                if (wo.GetAttributeValue<OptionSetValue>("statecode").Value == 1) {
                  SetStateRequest setReq = new SetStateRequest() {
                    State = new OptionSetValue(1),
                    Status = new OptionSetValue(2),
                    EntityMoniker = new EntityReference("msdyn_requirementcharacteristic", requirementCharacteristicId)
                  };

                  try {
                    SetStateResponse setResp = (SetStateResponse)crmTargetSvc.Execute(setReq);
                  }
                  catch (Exception ex2) {
                    // unable to set the state.   Again just delete the resource requirement which will delete all child records and we can re-process 
                    // uuuuggghhhh another nested try catch.
                    try {
                      crmTargetSvc.Delete(newRequirement.LogicalName, requirementId);
                      bw.ReportProgress(percent, $"{processingMessage} - Error setting statecode on requirement characteristics: {ex2.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                    }
                    catch (Exception ex3) {
                      // delete failed.  Tell the user that they need to delete it.
                      bw.ReportProgress(percent, $"{processingMessage} - Error setting statecode on requirement characteristics: {ex3.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                    }
                    finally {
                      requirementId = Guid.Empty;
                    }
                  }
                }

                if (requirementId == Guid.Empty)
                  continue;
              }
            }

            // Create Preferred Requirement Resource Preference
            if (wo.Attributes.ContainsKey("msdyn_preferredresource")) {
              //bw.ReportProgress(percent, $"{processingMessage} - Creating Preferred Requirement Resoure Preference Record");
              Entity requirementResourcePreference = new Entity("msdyn_requirementresourcepreference");
              requirementResourcePreference.Attributes.Add("msdyn_preferencetype", RequirementResourcePreferenceType.Preferred);
              requirementResourcePreference.Attributes.Add("msdyn_workorder", new EntityReference("msdyn_workorder", wo.Id));
              requirementResourcePreference.Attributes.Add("msdyn_bookableresource", wo.GetAttributeValue<EntityReference>("msdyn_preferredresource"));
              requirementResourcePreference.Attributes.Add("msdyn_cascade", false);
              requirementResourcePreference.Attributes.Add("msdyn_name", crmTargetSvc.Retrieve("bookableresource", wo.GetAttributeValue<EntityReference>("msdyn_preferredresource").Id, new ColumnSet("name")).GetAttributeValue<string>("name"));
              requirementResourcePreference.Attributes.Add("msdyn_resourcerequirement", new EntityReference("msdyn_resourcerequirement", requirementId));
              requirementResourcePreference.Attributes.Add("ownerid", wo.GetAttributeValue<EntityReference>("ownerid"));
              requirementResourcePreferenceId = new Guid();
              try {
                requirementResourcePreferenceId = crmTargetSvc.Create(requirementResourcePreference);
              }
              catch (Exception ex) {
                bw.ReportProgress(percent, $"{processingMessage} - Error: {ex.Message},  Error creating resource preference record: {ex.Message}");

                // try to delete the requirement that was created so we can re-process the work order.
                // yes all these nested try catch blocks are ugly but this code is not about elegance rather just getting the job done :(
                try {
                  crmTargetSvc.Delete(newRequirement.LogicalName, requirementId);
                  bw.ReportProgress(percent, $"{processingMessage} - Error creating requirement resource preference: {ex.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                catch (Exception ex1) {
                  // could not delete the requirement that was created.  Tell the user to do.
                  bw.ReportProgress(percent, $"{processingMessage} - Error creating requirement resource preference: {ex1.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                finally {
                  requirementId = Guid.Empty;
                }
              }
              if (requirementId == Guid.Empty)
                continue;

              if (wo.GetAttributeValue<OptionSetValue>("statecode").Value == 1) {
                SetStateRequest setReq = new SetStateRequest() {
                  State = new OptionSetValue(1),
                  Status = new OptionSetValue(2),
                  EntityMoniker = new EntityReference("msdyn_requirementresourcepreference", requirementResourcePreferenceId)
                };

                try {
                  SetStateResponse setResp = (SetStateResponse)crmTargetSvc.Execute(setReq);
                }
                catch (Exception ex2) {
                  // unable to set the state.   Again just delete the resource requirement which will delete all child records and we can re-process 
                  // uuuuggghhhh another nested try catch.
                  try {
                    crmTargetSvc.Delete(newRequirement.LogicalName, requirementId);
                    bw.ReportProgress(percent, $"{processingMessage} - Error setting statecode on requirement resource preference: {ex2.Message},  Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                  }
                  catch (Exception ex3) {
                    // delete failed.  Tell the user that they need to delete it.
                    bw.ReportProgress(percent, $"{processingMessage} - Error setting statecode on requirement resource preference: {ex3.Message},  Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                  }
                  finally {
                    requirementId = Guid.Empty;
                  }
                }
              }
              if (requirementId == Guid.Empty)
                continue;
            }

            // link work order incident and booking record with requirement

            foreach (Entity incident in relatedWOIncidents) {
              Entity incidentToUpdate = new Entity(incident.LogicalName, incident.Id);
              incidentToUpdate.Attributes.Add("msdyn_resourcerequirement", new EntityReference(newRequirement.LogicalName, requirementId));

              try {
                crmTargetSvc.Update(incidentToUpdate);
              }
              catch (Exception ex) {
                // unable to link the work order incident to the requirement.   Let's once again delete the resource requirement so we can re-process everything
                // once the user fixes the issue.

                // yes another darn nested try/catch.  Wish I had the time to clean this crap up but it gets the job done.
                try {
                  crmTargetSvc.Delete(newRequirement.LogicalName, requirementId);
                  bw.ReportProgress(percent, $"{processingMessage} - Error updating work order incident: {ex.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                catch (Exception ex2) {
                  bw.ReportProgress(percent, $"{processingMessage} - Error updating work order incident: {ex2.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                finally {
                  requirementId = Guid.Empty;
                }
              }
              if (requirementId == Guid.Empty)
                break; // stop processing work order incident records
            }
            if (requirementId == Guid.Empty)
              continue;

            // Update bookings and link them to the Booking Setup Metadata record.                   
            foreach (Entity booking in relatedWOBookings) {
              Entity bookingToUpdate = new Entity(booking.LogicalName, booking.Id);
              bookingToUpdate.Attributes.Add("msdyn_resourcerequirement", new EntityReference(newRequirement.LogicalName, requirementId));
              bookingToUpdate.Attributes.Add("msdyn_bookingsetupmetadataid", woBookingMetadataEntity.ToEntityReference());

              try {
                crmTargetSvc.Update(bookingToUpdate);
              }
              catch (Exception ex) {
                // unable to link the booking to the requirement and booking setup metadata.   Let's once again delete the resource requirement so we can re-process everything
                // once the user fixes the issue.

                // yes another darn nested try/catch.  Wish I had the time to clean this crap up but it gets the job done.
                try {
                  crmTargetSvc.Delete(newRequirement.LogicalName, requirementId);
                  bw.ReportProgress(percent, $"{processingMessage} - Error updating bookable resource booking: {ex.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                catch (Exception ex2) {
                  bw.ReportProgress(percent, $"{processingMessage} - Error updating bookable resource booking: {ex2.Message}, Please delete the resource requirement for Work Order: {wo["msdyn_name"]}");
                }
                finally {
                  requirementId = Guid.Empty;
                }
              }
              if (requirementId == Guid.Empty)
                break; // stop processing bookings
            }
            if (requirementId == Guid.Empty)
              continue;

            // Update teh work order to indicate that the resource requirement record has been created.
            Entity woToUpdate = new Entity(wo.LogicalName, wo.Id);
            woToUpdate.Attributes.Add("f12fs_f12fsrelatedrecordscreated", true);
            crmTargetSvc.Update(woToUpdate);
          }
          catch (Exception ex) {
            bw.ReportProgress(percent, $"{processingMessage} - Error processing work order: {ex.Message}.  Please ensure a resource requirement does not exist for the work order.");
          }
        }
      }
      bw.ReportProgress(percent, "Enabeling plugin steps");
      if (bw.CancellationPending)
        return;
      ReturnTargetPluginsToOriginalState();

      bw.ReportProgress(percent, "Activating workflows");
      if (bw.CancellationPending)
        return;
      ReturnTargetWorkflowsToOriginalState();
    }

    private Entity GetTargetUser(Guid source_userid) {
      Entity user = null;
      Entity sourceUser = crmSourceSvc.Retrieve("systemuser", source_userid, new ColumnSet("domainname"));
      List<Entity> targetUsers = RetrieveAllTargetRecords(userByDomainNameFetchXml.Replace("{DOMAINNAME}", sourceUser.GetAttributeValue<string>("domainname")));
      if (targetUsers != null && targetUsers.Count() > 0) {
        user = targetUsers[0];
      }
      return user;
    }

    public UserSettingSyncResult SyncTargetUser(Entity source_entity, Entity target_entity, bool syncBU, bool syncSettings, bool syncUser, Guid? target_buid, Guid? target_transactioncurrencyid, Guid? target_parentuserid) {
      // update the user record first
      Entity targetUser = null;
      Entity targetUserSettings = null;
      string step = "Updating user information";
      targetUser = crmTargetSvc.Retrieve("systemuser", target_entity.Id, new ColumnSet(//"utc_employee", - Chubb specific
                                                                                       //"utc_countrybusinessunit", - Chubb specific
                                                                                       "businessunitid",
                                                                                       "parentsystemuserid",
                                                                                       "territoryid",
                                                                                       "internalemailaddress"));
      if (syncBU) {
        step = "Changing Business Unit";
        if (target_buid != null && target_buid.HasValue) {
          try {
            if (targetUser.GetAttributeValue<EntityReference>("businessunitid").Id != target_buid) {
              // try to change the users business unit.
              SetBusinessSystemUserRequest req = new SetBusinessSystemUserRequest();
              //business unit to assign user to
              req.BusinessId = target_buid.Value;

              //user to re-assign
              req.UserId = targetUser.Id;

              //can be a different team or systemuser, used to reassign records owned by person
              req.ReassignPrincipal = new EntityReference("systemuser", targetUser.Id);
              SetBusinessSystemUserResponse resp = (SetBusinessSystemUserResponse)crmTargetSvc.Execute(req);
              return new UserSettingSyncResult() {
                IsError = false
              };
            }
          }
          catch (Exception ex2) {
            return new UserSettingSyncResult() {
              ex = ex2,
              Step = step,
              TargetSettings = targetUserSettings,
              TargetUser = targetUser,
              IsError = true
            };
          }
        }
      }

      if (syncUser) {
        try {
          // Chubb Specific attribute
          //if (source_entity.Contains("utc_employee")) {
          //    if (targetUser.Contains("utc_employee"))
          //        targetUser["utc_employee"] = source_entity.GetAttributeValue<EntityReference>("utc_employee");
          //    else
          //        targetUser.Attributes.Add("utc_employee", source_entity.GetAttributeValue<EntityReference>("utc_employee"));
          //}
          //else if (targetUser.Contains("utc_employee"))
          //    targetUser["utc_employee"] = null;

          //if (source_entity.Contains("utc_countrybusinessunit")) {
          //    if (targetUser.Contains("utc_countrybusinessunit"))
          //        targetUser["utc_countrybusinessunit"] = source_entity.GetAttributeValue<EntityReference>("utc_countrybusinessunit");
          //    else
          //        targetUser.Attributes.Add("utc_countrybusinessunit", source_entity.GetAttributeValue<EntityReference>("utc_countrybusinessunit"));
          //}
          //else if (targetUser.Contains("utc_countrybusinessunit"))
          //    targetUser["utc_countrybusinessunit"] = null;

          if (target_parentuserid != null && target_parentuserid.HasValue) {
            // No need to make the call to CRM to get the target user which is the parentsystem user.  If a target_parentuserid has been passed in we can simply use it.
            if (targetUser.Contains("parentsystemuserid"))
              targetUser["parentsystemuserid"] = new EntityReference("systemuser", target_parentuserid.Value);
            else
              targetUser.Attributes.Add("parentsystemuserid", new EntityReference("systemuser", target_parentuserid.Value));
          }
          else if (targetUser.Contains("parentsystemuserid"))
            targetUser["parentsystemuserid"] = null;

          if (source_entity.Contains("territoryid")) {
            if (targetUser.Contains("territoryid"))
              targetUser["territoryid"] = source_entity.GetAttributeValue<EntityReference>("territoryid");
            else
              targetUser.Attributes.Add("territoryid", source_entity.GetAttributeValue<EntityReference>("territoryid"));
          }
          else if (targetUser.Contains("territoryid"))
            targetUser["territoryid"] = null;

          if (source_entity.Contains("internalemailaddress")) {
            if (targetUser.Contains("internalemailaddress"))
              targetUser["internalemailaddress"] = source_entity.GetAttributeValue<string>("internalemailaddress");
            else
              targetUser.Attributes.Add("internalemailaddress", source_entity.GetAttributeValue<EntityReference>("internalemailaddress"));
          }
          else if (targetUser.Contains("internalemailaddress"))
            targetUser["internalemailaddress"] = null;

          crmTargetSvc.Update(targetUser);
        }
        catch (Exception ex1) {
          return new UserSettingSyncResult() {
            ex = ex1,
            Step = step,
            TargetSettings = targetUserSettings,
            TargetUser = targetUser,
            IsError = true
          };
        }
      }

      if (syncSettings) {
        step = "Changing User Settings";
        try {
          targetUserSettings = ParseUserSettings(source_entity.Id, target_entity.Id, target_transactioncurrencyid);
          crmTargetSvc.Update(targetUserSettings);
        }
        catch (Exception ex3) {
          return new UserSettingSyncResult() {
            ex = ex3,
            Step = step,
            TargetSettings = targetUserSettings,
            TargetUser = targetUser,
            IsError = true
          };
        }
      }

      return new UserSettingSyncResult() {
        IsError = false
      };
    }

    private Entity ParseUserSettings(Guid sourceUserId, Guid targetUserId, Guid? target_transactioncurrencyid) {
      // get the settings for user from source user id.
      Entity sourceUserSettings = null;
      Entity targetUserSettings = null;

      List<Entity> colSource = RetrieveAllSourceRecords(userSettingsFetchXml.Replace("{USERID}", sourceUserId.ToString()));
      if (colSource != null && colSource.Count > 0)
        sourceUserSettings = colSource.FirstOrDefault();
      else
        return null;

      // get the settings for the target user id.
      List<Entity> colTarget = RetrieveAllTargetRecords(userSettingsFetchXml.Replace("{USERID}", targetUserId.ToString()));
      if (colTarget != null && colTarget.Count > 0)
        targetUserSettings = new Entity("usersettings", colTarget.FirstOrDefault().Id);
      else
        return null;

      if (sourceUserSettings.Contains(UserSettings.Fields.TimeZoneCode)) {
        targetUserSettings.Attributes.Add(UserSettings.Fields.TimeZoneCode, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.TimeZoneCode));
      }

      if (sourceUserSettings.Contains(UserSettings.Fields.UILanguageId)) {
        targetUserSettings.Attributes.Add(UserSettings.Fields.UILanguageId, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.UILanguageId));
      }

      if (target_transactioncurrencyid != null && target_transactioncurrencyid.HasValue) {
        if (sourceUserSettings.Contains(UserSettings.Fields.TransactionCurrencyId)) {
          targetUserSettings.Attributes.Add(UserSettings.Fields.TransactionCurrencyId, new EntityReference("transactioncurrency", target_transactioncurrencyid.Value));
        }
      }

      if (sourceUserSettings.Contains(UserSettings.Fields.LocaleId)) {
        targetUserSettings.Attributes.Add(UserSettings.Fields.LocaleId, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.LocaleId));
      }

      #region settigns not processed
      //if (sourceUserSettings.Contains(UserSettings.Fields.WorkdayStartTime)) {
      //    targetUserSettings.Attributes.Add(UserSettings.Fields.WorkdayStartTime, sourceUserSettings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStartTime));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.WorkdayStopTime)) {
      //    targetUserSettings.Attributes.Add(UserSettings.Fields.WorkdayStopTime, sourceUserSettings.GetAttributeValue<string>(UserSettings.Fields.WorkdayStopTime));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.HelpLanguageId)) {
      //    targetUserSettings.Attributes.Add(UserSettings.Fields.HelpLanguageId, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.HelpLanguageId));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.AdvancedFindStartupMode)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.AdvancedFindStartupMode))
      //        targetUserSettings[UserSettings.Fields.AdvancedFindStartupMode] = sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.AdvancedFindStartupMode);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.AdvancedFindStartupMode, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.AdvancedFindStartupMode));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.AutoCreateContactOnPromote)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.AutoCreateContactOnPromote))
      //        targetUserSettings[UserSettings.Fields.AutoCreateContactOnPromote] = sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.AutoCreateContactOnPromote);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.AutoCreateContactOnPromote, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.AutoCreateContactOnPromote));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.DefaultCalendarView)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.DefaultCalendarView))
      //        targetUserSettings[UserSettings.Fields.DefaultCalendarView] = sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.DefaultCalendarView);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.DefaultCalendarView, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.DefaultCalendarView));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.IncomingEmailFilteringMethod)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.IncomingEmailFilteringMethod))
      //        targetUserSettings[UserSettings.Fields.IncomingEmailFilteringMethod] = sourceUserSettings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.IncomingEmailFilteringMethod).Value;
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.IncomingEmailFilteringMethod, sourceUserSettings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.IncomingEmailFilteringMethod).Value);
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.ReportScriptErrors)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.ReportScriptErrors))
      //        targetUserSettings[UserSettings.Fields.ReportScriptErrors] = sourceUserSettings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.ReportScriptErrors).Value;
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.ReportScriptErrors, sourceUserSettings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.ReportScriptErrors).Value);
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.DefaultSearchExperience)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.DefaultSearchExperience))
      //        targetUserSettings[UserSettings.Fields.DefaultSearchExperience] = sourceUserSettings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.DefaultSearchExperience).Value;
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.DefaultSearchExperience, sourceUserSettings.GetAttributeValue<OptionSetValue>(UserSettings.Fields.DefaultSearchExperience).Value);
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.IsSendAsAllowed)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.IsSendAsAllowed))
      //        targetUserSettings[UserSettings.Fields.IsSendAsAllowed] = sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.IsSendAsAllowed);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.IsSendAsAllowed, sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.IsSendAsAllowed));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.PagingLimit)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.PagingLimit))
      //        targetUserSettings[UserSettings.Fields.PagingLimit] = sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.PagingLimit);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.PagingLimit, sourceUserSettings.GetAttributeValue<int>(UserSettings.Fields.PagingLimit));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.GetStartedPaneContentEnabled)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.GetStartedPaneContentEnabled))
      //        targetUserSettings[UserSettings.Fields.GetStartedPaneContentEnabled] = sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.GetStartedPaneContentEnabled);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.GetStartedPaneContentEnabled, sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.GetStartedPaneContentEnabled));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.UseCrmFormForAppointment)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.UseCrmFormForAppointment))
      //        targetUserSettings[UserSettings.Fields.UseCrmFormForAppointment] = sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForAppointment);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.UseCrmFormForAppointment, sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForAppointment));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.UseCrmFormForContact)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.UseCrmFormForContact))
      //        targetUserSettings[UserSettings.Fields.UseCrmFormForContact] = sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForContact);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.UseCrmFormForContact, sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForContact));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.UseCrmFormForEmail)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.UseCrmFormForEmail))
      //        targetUserSettings[UserSettings.Fields.UseCrmFormForEmail] = sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForEmail);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.UseCrmFormForEmail, sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForEmail));
      //}

      //if (sourceUserSettings.Contains(UserSettings.Fields.UseCrmFormForTask)) {
      //    if (targetUserSettings.Contains(UserSettings.Fields.UseCrmFormForTask))
      //        targetUserSettings[UserSettings.Fields.UseCrmFormForTask] = sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForTask);
      //    else
      //        targetUserSettings.Attributes.Add(UserSettings.Fields.UseCrmFormForTask, sourceUserSettings.GetAttributeValue<bool>(UserSettings.Fields.UseCrmFormForTask));
      //}
      #endregion

      return targetUserSettings;
    }

    public string DeleteTargetRecords(BackgroundWorker worker, ref dsFSMigration ds) {
      string errorMessage = "";

      var deleteRequests = new ExecuteMultipleRequest() {
        Settings = new ExecuteMultipleSettings() {
          ContinueOnError = true,
          ReturnResponses = true
        },
        Requests = new OrganizationRequestCollection()
      };

      int iCurrent = 0;
      int iProcessed = 0;
      int iTotal = ds.dtDeletedRecords.Count;
      foreach (var dr in ds.dtDeletedRecords) {
        iCurrent++;
        iProcessed++;
        DeleteRequest delRequest = new DeleteRequest() {
          Target = new EntityReference(dr.entitylogicalname, dr.Id) {
            Name = dr.Name
          }
        };
        deleteRequests.Requests.Add(delRequest);

        if (deleteRequests.Requests.Count == 25) {
          worker.ReportProgress(this.Percent(iProcessed, iTotal), $"Deleting Records {iProcessed - iCurrent} thru {iProcessed} of {iTotal}");
          var resp = (ExecuteMultipleResponse)crmTargetSvc.Execute(deleteRequests);
          if (resp.IsFaulted) {
            foreach (var responseItem in resp.Responses) {
              if (responseItem.Fault != null) {
                errorMessage += $"Error deleting record: {((DeleteRequest)deleteRequests.Requests[responseItem.RequestIndex]).Target.Name}, Message: {responseItem.Fault.Message}{Environment.NewLine}======================{Environment.NewLine}";
              }
            }
          }
          deleteRequests.Requests.Clear();
          iCurrent = 0;
        }
      }

      if (deleteRequests.Requests.Count > 0) {
        worker.ReportProgress(this.Percent(iProcessed, iTotal), $"Deleting Records {iProcessed - iCurrent} thru {iProcessed} of {iTotal}");
        var resp = (ExecuteMultipleResponse)crmTargetSvc.Execute(deleteRequests);
        if (resp.IsFaulted) {
          foreach (var responseItem in resp.Responses) {
            if (responseItem.Fault != null) {
              errorMessage += $"Error deleting record: {((DeleteRequest)deleteRequests.Requests[responseItem.RequestIndex]).Target.Name}, Message: {responseItem.Fault.Message}{Environment.NewLine}======================{Environment.NewLine}";
            }
          }
        }
      }
      return errorMessage;
    }

    public string UpdateTargetBookingSetups(BackgroundWorker worker, List<Entity> bookingSetups, string startDate) {
      string errorMessage = "";
      string pattern = agreementBookingRecurrancePatter.Replace("{START}", startDate);

      var updateRequests = new ExecuteMultipleRequest() {
        Settings = new ExecuteMultipleSettings() {
          ContinueOnError = true,
          ReturnResponses = true
        },
        Requests = new OrganizationRequestCollection()
      };

      int iCurrent = 0;
      int iProcessed = 0;
      int iTotal = bookingSetups.Count;
      foreach (var ent in bookingSetups) {
        iCurrent++;
        iProcessed++;
        if (worker.CancellationPending) {
          break;
        }

        // create a new Entity object to update so we only pass the recurrence settings attribute.
        Entity updateEnt = new Entity(ent.LogicalName, ent.Id);
        updateEnt.Attributes.Add("msdyn_recurrencesettings", pattern);

        UpdateRequest updRequest = new UpdateRequest() {
          Target = updateEnt
        };

        updateRequests.Requests.Add(updRequest);
        if (updateRequests.Requests.Count == 25) {
          worker.ReportProgress(this.Percent(iProcessed, iTotal), $"Updating Records {iProcessed - iCurrent} thru {iProcessed} of {iTotal}");
          var resp = (ExecuteMultipleResponse)crmTargetSvc.Execute(updateRequests);
          if (resp.IsFaulted) {
            foreach (var responseItem in resp.Responses) {
              if (responseItem.Fault != null) {
                errorMessage += $"Error updating record: {((UpdateRequest)updateRequests.Requests[responseItem.RequestIndex]).Target.Id}, Message: {responseItem.Fault.Message}{Environment.NewLine}======================{Environment.NewLine}";
              }
            }
          }
          updateRequests.Requests.Clear();
          iCurrent = 0;
        }
      }

      if (updateRequests.Requests.Count > 0) {
        worker.ReportProgress(this.Percent(iProcessed, iTotal), $"Updating Records {iProcessed - iCurrent} thru {iProcessed} of {iTotal}");
        var resp = (ExecuteMultipleResponse)crmTargetSvc.Execute(updateRequests);
        if (resp.IsFaulted) {
          foreach (var responseItem in resp.Responses) {
            if (responseItem.Fault != null) {
              errorMessage += $"Error updating record: {((UpdateRequest)updateRequests.Requests[responseItem.RequestIndex]).Target.Id}, Message: {responseItem.Fault.Message}{Environment.NewLine}======================{Environment.NewLine}";
            }
          }
        }
      }
      return errorMessage;
    }

    public Entity CreateTargetStubUser(BackgroundWorker bw, Guid id, string domainname, string internalemailaddress, string firstname, string lastname, Guid sourceBusinessUnitId) {
      Guid targetBusinessUnitId = Guid.Empty;
      Guid newUserId = Guid.Empty;

      string newDomainName = domainname;

      // see if there is a business unit with same id in target.
      try {
        Entity targetBU = crmTargetSvc.Retrieve("businessunit", sourceBusinessUnitId, new ColumnSet(true));
        targetBusinessUnitId = targetBU.Id;
      }
      catch {
        // assume it was not found.   Get the source BU and see if target has a BU with the same name.
        Entity sourceBU = crmSourceSvc.Retrieve("businessunit", sourceBusinessUnitId, new ColumnSet(true));
        List<Entity> targetBUs = this.RetrieveAllTargetRecords(businessUnitFetchXml.Replace("{BUNAME}", sourceBU.GetAttributeValue<string>("name")));
        if (targetBUs == null || targetBUs.Count < 1)
          throw new Exception($"Business Unit: {sourceBU.GetAttributeValue<string>("name")} does not exist in target org.");
        targetBusinessUnitId = targetBUs[0].Id;
      }

      // try to create the user with the original source values.
      Entity newUser = new Entity("systemuser"); //, id);
      newUser.Attributes.Add("domainname", domainname);
      newUser.Attributes.Add("firstname", firstname);
      newUser.Attributes.Add("lastname", lastname);
      newUser.Attributes.Add("internalemailaddress", internalemailaddress);
      newUser.Attributes.Add("businessunitid", new EntityReference("businessunit", targetBusinessUnitId));
      newUser.Attributes.Add("nickname", "stub-fsmigration");
      try {
        newUserId = crmTargetSvc.Create(newUser);
      }
      catch (Exception ex) {
        // try to create using the domainname as the internalemailaddress
        newUser.Attributes["internalemailaddress"] = domainname;
        newUserId = crmTargetSvc.Create(newUser);
      }

      newUser.Id = newUserId;
      // retrieve the new user from target to get the fullname attribute and second confirmation that it worked.
      return newUser; // crmTargetSvc.Retrieve("systemuser", id, new ColumnSet(true));  // Yes I know you should never retrieve all columns.
    }

    public Entity CreateTargetUOMSchedule(BackgroundWorker bw, Guid id, string name, string description, string baseuomname) {
      Entity newUOMSchedule = new Entity("uomschedule", id);
      newUOMSchedule.Attributes.Add("description", description);
      newUOMSchedule.Attributes.Add("baseuomname", baseuomname);
      newUOMSchedule.Attributes.Add("name", name);
      
      try {
        crmTargetSvc.Create(newUOMSchedule);
      }
      catch (Exception ex) {
        // try to create using the domainname as the internalemailaddress
        throw ex;
      }

      // retrieve the new user from target to get the fullname attribute and second confirmation that it worked.
      return crmTargetSvc.Retrieve("uomschedule", id, new ColumnSet(true));  // Yes I know you should never retrieve all columns.
    }

    public Entity CreateTargetUOM(BackgroundWorker bw, Guid id, string name, decimal qty, Guid? source_uomscheduleid, Guid? source_baseuomid, bool isScheduleBaseUom) {
      Entity sourceUOMSchedule = null;
      Entity sourceBaseUOM = null;
      Entity targetUOMSchedule = null;
      Entity targetBaseUOM = null;

      // Ok very simple way of doing this but it will get the job done.

      // First be sure we are not creating a duplicate UOM
      List<Entity> matchingTargetUOMs = RetrieveAllTargetRecords(uomFetchByNameXml.Replace("{NAME}", name));
      if (matchingTargetUOMs != null && matchingTargetUOMs.Count > 0)
        throw new Exception($"WARNING: UOM with name {name} already exists in target environemnt, skipping the create");

      // Get the UOM Schedule from the source environment.
      if (source_uomscheduleid != null) {
        sourceUOMSchedule = crmSourceSvc.Retrieve("uomschedule", source_uomscheduleid.Value, new ColumnSet(true));
        if (sourceUOMSchedule == null)
          throw new Exception($"Unable to retrieve UOM Schedule from source with Id: {source_uomscheduleid}");

        // Get the matching target UOM Schedule.  This should match by GUID as the tooling will need the GUIDs to match as well.
        targetUOMSchedule = crmTargetSvc.Retrieve("uomschedule", sourceUOMSchedule.Id, new ColumnSet(true));
        if (targetUOMSchedule == null)
          throw new Exception($"ERROR: Unable to find matching UOM Schedule in target with Id: {source_uomscheduleid}, name: {sourceUOMSchedule.GetAttributeValue<string>("name")}");
      }

      // Get the UOM from the source environment
      if (source_baseuomid != null) {
        sourceBaseUOM = crmSourceSvc.Retrieve("uom", source_baseuomid.Value, new ColumnSet(true));
        if (sourceBaseUOM == null)
          throw new Exception($"Unable to retrieve UOM from source with Id: {source_baseuomid}");

        // get the target UOM.  This can match by name.  Try to get the UOM with same Id first then try by name
        try {
          targetBaseUOM = crmTargetSvc.Retrieve("uom", sourceBaseUOM.Id, new ColumnSet(true));
        }
        catch (Exception ex) {
          // do nothing here.  It is ok if we are not able to find the UOM by id.  We will check by name next.
        }
        if (targetBaseUOM == null) {
          // try to lookup by name.
         List<Entity> targetUOMs = RetrieveAllTargetRecords(uomFetchByNameXml.Replace("{NAME}", sourceBaseUOM.GetAttributeValue<string>("name")));
         if (targetUOMs == null || targetUOMs.Count == 0)
            throw new Exception($"ERROR: Unable to find target base UOM with name {sourceBaseUOM.GetAttributeValue<string>("name")}");
          targetBaseUOM = targetUOMs.First<Entity>();
        }
      }

      Entity newUOM = new Entity("uom", id);
      newUOM.Attributes.Add("name", name);
      newUOM.Attributes.Add("quantity", qty);
      newUOM.Attributes.Add("isschedulebaseuom", isScheduleBaseUom);
      if (targetBaseUOM != null) newUOM.Attributes.Add("baseuom", new EntityReference("uom", targetBaseUOM.Id));
      if (targetUOMSchedule != null) newUOM.Attributes.Add("uomscheduleid", new EntityReference("uomschedule", targetUOMSchedule.Id));



      try {
        crmTargetSvc.Create(newUOM);
      }
      catch (Exception ex) {
        // try to create using the domainname as the internalemailaddress
        throw ex;
      }

      // retrieve the new user from target to get the fullname attribute and second confirmation that it worked.
      return crmTargetSvc.Retrieve("uomschedule", id, new ColumnSet(true));  // Yes I know you should never retrieve all columns.
    }

    public string StartMarkAgreementAsExpiredWorkflow() {
      throw new NotImplementedException("This Feature Has Not Been Enabled.");

      //Guid workflowMarkAgreementAsExpired = new Guid("8ff808d0-b082-443f-9fbd-0f48baa2e985");

      //QueryExpression query = new QueryExpression {
      //    EntityName = "msdyn_agreement",
      //    ColumnSet = new ColumnSet("msdyn_agreementid")
      //};
      //query.Criteria.AddCondition("msdyn_systemstatus", ConditionOperator.Equal, 690970001);

      //var workflowRequest = new ExecuteWorkflowRequest {
      //    WorkflowId = workflowID,
      //    EntityId = entity.Id,
      //    //RequestId = this.InstanceId,
      //    //RequestName = "FieldOneMigrationTool - Post Data Migration Task : Execute workflow"
      //};
      //workflowRequests.Add(workflowRequest);

      return ""; // ExecuteWorkflow(TargetService, query, workflowMarkAgreementAsExpired);
    }

    public Entity CreateTargetResourceRequirement(BackgroundWorker bw, Entity wo, Entity woBookingMetadataEntity, List<Entity> relatedWOIncidents, List<Entity> relatedWOBookings) {
      Entity newRequirement = new Entity("msdyn_resourcerequirement");

      try {
        int totalEstimatedDuration = 0;
        Guid requirementId = Guid.Empty;

        foreach (Entity woincident in relatedWOIncidents) {
          totalEstimatedDuration += woincident.GetAttributeValue<int?>("msdyn_estimatedduration") != null ? woincident.GetAttributeValue<int?>("").Value : 0;
        }

        var requirementFulfilledDuration = 0;
        foreach (Entity booking in relatedWOBookings) {
          var bookingDuration = booking.GetAttributeValue<int?>("duration");
          var bookingActualTravelDuration = booking.GetAttributeValue<int?>("msdyn_actualtravelduration");
          var bookingEstimatedTravelDuration = booking.GetAttributeValue<int?>("msdyn_estimatedtravelduration");
          var bookingFulfilledDuration = 0;

          if (bookingDuration.GetValueOrDefault(0) != 0) {
            if (bookingActualTravelDuration != null)
              bookingFulfilledDuration = bookingDuration.Value - bookingActualTravelDuration.Value;
            else if (bookingEstimatedTravelDuration.GetValueOrDefault(0) != 0)
              bookingFulfilledDuration = bookingDuration.Value - bookingEstimatedTravelDuration.Value;
            else
              bookingFulfilledDuration = bookingDuration.Value;
          }
          else
            bookingFulfilledDuration = 0;

          requirementFulfilledDuration += bookingFulfilledDuration < 0 ? 0 : bookingFulfilledDuration;
        }

        var requirementDuration = totalEstimatedDuration;
        var requirementRemainingDuration = requirementDuration > requirementFulfilledDuration ? requirementDuration - requirementFulfilledDuration : 0;

        // work order does not have a primary resource requirement, lets create it.
        if (requirementDuration > 0)
          newRequirement.Attributes.Add("msdyn_duration", requirementDuration);
        if (requirementFulfilledDuration > 0)
          newRequirement.Attributes.Add("msdyn_fulfilledduration", requirementFulfilledDuration);
        if (requirementRemainingDuration > 0)
          newRequirement.Attributes.Add("msdyn_remainingduration", requirementRemainingDuration);
        newRequirement.Attributes.Add("msdyn_fromdate", wo.GetAttributeValue<DateTime?>("msdyn_datewindowstart"));
        newRequirement.Attributes.Add("msdyn_todate", wo.GetAttributeValue<DateTime?>("msdyn_datewindowend"));
        newRequirement.Attributes.Add("msdyn_priority", wo.GetAttributeValue<EntityReference>("msdyn_priority"));
        newRequirement.Attributes.Add("msdyn_timegroup", wo.GetAttributeValue<EntityReference>("msdyn_timegroup"));
        newRequirement.Attributes.Add("msdyn_timefrompromised", wo.GetAttributeValue<DateTime?>("msdyn_timefrompromised"));
        newRequirement.Attributes.Add("msdyn_timetopromised", wo.GetAttributeValue<DateTime?>("msdyn_timetopromised"));
        newRequirement.Attributes.Add("msdyn_timewindowstart", wo.GetAttributeValue<DateTime?>("msdyn_timewindowstart"));
        newRequirement.Attributes.Add("msdyn_timewindowend", wo.GetAttributeValue<DateTime?>("msdyn_timewindowend"));
        newRequirement.Attributes.Add("msdyn_worklocation", wo.GetAttributeValue<OptionSetValue>("msdyn_worklocation"));
        newRequirement.Attributes.Add("msdyn_latitude", wo.GetAttributeValue<double?>("msdyn_latitude"));
        newRequirement.Attributes.Add("msdyn_longitude", wo.GetAttributeValue<double?>("msdyn_longitude"));
        newRequirement.Attributes.Add("msdyn_territory", wo.GetAttributeValue<EntityReference>("msdyn_serviceterritory"));
        newRequirement.Attributes.Add("msdyn_workorder", new EntityReference("msdyn_workorder", wo.Id));
        newRequirement.Attributes.Add("msdyn_isprimary", true);
        newRequirement.Attributes.Add("msdyn_status", RequirementStatusCoreStatus.ActiveReference);
        newRequirement.Attributes.Add("msdyn_name", wo.GetAttributeValue<string>("msdyn_name"));
        newRequirement.Attributes.Add("ownerid", wo.GetAttributeValue<EntityReference>("ownerid"));
        newRequirement.Attributes.Add("msdyn_bookingsetupmetadataid", woBookingMetadataEntity.ToEntityReference());
        try {
          requirementId = crmTargetSvc.Create(newRequirement);
        }
        catch (Exception ex) {
          requirementId = Guid.Empty;
          throw ex;
        }
      }
      catch (Exception ex) {
        throw ex;
      }

      return newRequirement;
    }

    public int GetTargetRecordCount(string entityname, string fetchFilter) {
      int recordCount = 0;
      try {
        string fetchXml = $"<fetch version='1.0' output-format='xml-platform' mapping='logical' distinct='false' no-lock='true'>";
        fetchXml += $"  <entity name='{entityname}'>";
        fetchXml += fetchFilter;
        fetchXml += $"</entity></fetch>";

        QueryExpression qe = ConvertToTargetQueryExpression(fetchXml);
        qe.PageInfo = new PagingInfo() {
          Count = 5000,
          PageNumber = 1
        };

        // get the first page of results.
        EntityCollection colPage = null;
        colPage = crmTargetSvc.RetrieveMultiple(qe);
        recordCount = colPage.Entities.Count;

        while (colPage.MoreRecords) {
          qe.PageInfo.PagingCookie = colPage.PagingCookie;
          qe.PageInfo.PageNumber++;
          colPage.Entities.Clear();
          colPage = crmTargetSvc.RetrieveMultiple(qe);
          recordCount += colPage.Entities.Count;
        }
      }
      catch (Exception ex) {
        //ex.Dump();
        throw ex;
      }
      return recordCount;
    }

    public List<Entity> RetrieveAllSourceMappingUsers() {
      if (crmTargetSvc != null)
        return RetrieveAllSourceRecords(systemUserMappingFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetMappingUsers() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(systemUserMappingFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceRequirements() {
      if (crmSourceSvc != null)
        return RetrieveAllSourceRecords(resourceRequirements);
      else
        return null;
    }

    public List<Entity> RetrieveTargetSystemJobsForUser(Guid userId) {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(agreementProcessFetchXml.Replace("{USERID}", userId.ToString()));
      else
        return null;
    }

    public List<Entity> RetrieveAllSourceTeamMembership() {
      if (crmTargetSvc != null)
        return RetrieveAllSourceRecords(teammembershipFetchXml);
      else
        return null;
    }

    public List<Entity> RetrieveAllTargetTeamMembership() {
      if (crmTargetSvc != null)
        return RetrieveAllTargetRecords(teammembershipFetchXml);
      else
        return null;
    }

    private List<Entity> RetrieveAllRecords(IOrganizationService svc, QueryExpression qe) {
      List<Entity> col = new List<Entity>();

      qe.PageInfo = new PagingInfo() {
        Count = 5000,
        PageNumber = 1
      };

      // get the first page of results.
      EntityCollection colPage = null;
      colPage = svc.RetrieveMultiple(qe);

      if (colPage == null || colPage.Entities == null || colPage.Entities.Count == 0)
        return col;

      int i = 0;
      foreach (Entity ent in colPage.Entities) {
        col.Add(ent);
      }

      if (!colPage.MoreRecords)
        return col; // no more records just return what we have.

      while (colPage.MoreRecords) {
        qe.PageInfo.PagingCookie = colPage.PagingCookie;
        qe.PageInfo.PageNumber++;
        colPage = svc.RetrieveMultiple(qe);
        foreach (Entity ent in colPage.Entities) {
          col.Add(ent);
        }
      }
      return col;
    }

    public List<Entity> RetrieveAllTargetRecords(QueryExpression qe) {
      return RetrieveAllRecords(crmTargetSvc, qe);
    }

    public List<Entity> RetrieveAllSourceRecords(QueryExpression qe) {
      return RetrieveAllRecords(crmSourceSvc, qe);
    }

    public List<Entity> RetrieveAllTargetRecords(string fetchXml) {
      List<Entity> col = new List<Entity>();
      return RetrieveAllTargetRecords(ConvertToTargetQueryExpression(fetchXml));
    }

    public List<Entity> RetrieveAllSourceRecords(string fetchXml) {
      List<Entity> col = new List<Entity>();
      return RetrieveAllSourceRecords(ConvertToSourceQueryExpression(fetchXml));
    }



    public QueryExpression ConvertToTargetQueryExpression(string fetchXml) {
      FetchExpression fetchClosedBookings = new FetchExpression(fetchXml);
      var conversionRequest = new FetchXmlToQueryExpressionRequest {
        FetchXml = fetchClosedBookings.Query
      };
      var conversionResponse = (FetchXmlToQueryExpressionResponse)crmTargetSvc.Execute(conversionRequest);
      QueryExpression qe = conversionResponse.Query;
      return qe;
    }

    public QueryExpression ConvertToSourceQueryExpression(string fetchXml) {
      FetchExpression fetchClosedBookings = new FetchExpression(fetchXml);
      var conversionRequest = new FetchXmlToQueryExpressionRequest {
        FetchXml = fetchClosedBookings.Query
      };
      var conversionResponse = (FetchXmlToQueryExpressionResponse)crmSourceSvc.Execute(conversionRequest);
      QueryExpression qe = conversionResponse.Query;
      return qe;
    }

    public string TargetAddRolesToUser(Guid userId, List<Guid> roleIds, bool clearTargetRoles) {
      DisassociateResponse disResponse;
      AssociateResponse asResponse;
      string results = "";
      try {
        if (clearTargetRoles) {
          disResponse = this.RemoveRolesFromPrincipal(crmTargetSvc, "systemuser", userId);
          if (disResponse.Results.Count() > 0) {
            results = "Error removing target roles: ";
            foreach (var x in disResponse.Results) {
              results += $"Key: {x.Key}, Value: {x.Value} | ";
            }
            return results;
          }
        }
      }
      catch (Exception ex) {
        throw new Exception($"Error clearing target roles from userId: {userId}, Message: {ex.Message}", ex);
      }

      try {
        asResponse = AddRolesToPrincipal(crmTargetSvc, "systemuser", userId, roleIds);
        if (asResponse.Results.Count() > 0) {
          results = "Error adding target roles: ";
          foreach (var x in asResponse.Results) {
            results += $"Key: {x.Key}, Value: {x.Value} | ";
          }
          return results;
        }
      }
      catch (Exception ex) {
        throw new Exception($"Error assigning roles to userId: {userId}, Message: {ex.Message}", ex);
      }
      return results;
    }

    public string TargetAddRolesToTeam(Guid teamId, List<Guid> roleIds, bool clearTargetRoles) {
      DisassociateResponse disResponse;
      AssociateResponse asResponse;
      string results = "";
      try {
        if (clearTargetRoles) {
          disResponse = this.RemoveRolesFromPrincipal(crmTargetSvc, "team", teamId);
          if (disResponse.Results.Count() > 0) {
            results = "Error removing target roles: ";
            foreach (var x in disResponse.Results) {
              results += $"Key: {x.Key}, Value: {x.Value} | ";
            }
            return results;
          }
        }
      }
      catch (Exception ex) {
        throw new Exception($"Error clearing target roles from teamId: {teamId}, Message: {ex.Message}", ex);
      }

      try {
        asResponse = AddRolesToPrincipal(crmTargetSvc, "team", teamId, roleIds);
        if (asResponse.Results.Count() > 0) {
          results = "Error adding target roles: ";
          foreach (var x in asResponse.Results) {
            results += $"Key: {x.Key}, Value: {x.Value} | ";
          }
          return results;
        }
      }
      catch (Exception ex) {
        throw new Exception($"Error assigning roles to teamId: {teamId}, Message: {ex.Message}", ex);
      }
      return results;
    }

    private DisassociateResponse RemoveRolesFromPrincipal(IOrganizationService svc, string principalLogicalName, Guid principalId) {
      List<Entity> assignedRoles = null;
      if (principalLogicalName == "systemuser")
        assignedRoles = RetrieveTargetUserAssignedRoles(principalId);
      else
        assignedRoles = RetrieveTargetTeamAssignedRoles(principalId);

      DisassociateRequest disassociateRequest = new DisassociateRequest() {
        Target = new EntityReference(principalLogicalName, principalId),
        Relationship = new Relationship(principalLogicalName + "roles_association"),
        RelatedEntities = new EntityReferenceCollection()
      };

      foreach (Entity assignedRole in assignedRoles) {
        disassociateRequest.RelatedEntities.Add(new EntityReference("role", assignedRole.GetAttributeValue<Guid>("roleid")));
      }
      return (DisassociateResponse)svc.Execute(disassociateRequest);
    }

    public string TargetResetWorkflows(Guid agreementid) {
      string errorMessage = "";
      // get the workflowid for the Agreement Expire WF.
      Entity expwf = RetrieveAllTargetRecords(workflowLookupAgreementExpireFetchXml).FirstOrDefault();

      // First find the async job for Agreement Expire and restart it.
      List<Entity> agreementExpireWorkflows = RetrieveAllTargetRecords(agreementExpireWorkflowFetchXml.Replace("{AGREEMENTID}", agreementid.ToString()));
      if (agreementExpireWorkflows != null && agreementExpireWorkflows.Count > 0) {
        // there should only be one but lets allow for multiple.
        try {
          foreach (Entity expireWF in agreementExpireWorkflows) {
            // Cancel the running workflow.
            expireWF.Attributes["statecode"] = new OptionSetValue(3);
            expireWF.Attributes["statuscode"] = new OptionSetValue(32);
            crmTargetSvc.Update(expireWF);

            // now restart the same workflow, this will get it running as current user.
            var workflowRequest = new ExecuteWorkflowRequest {
              WorkflowId = expwf.Id,
              EntityId = agreementid
            };
            ExecuteWorkflowResponse resp = (ExecuteWorkflowResponse)crmTargetSvc.Execute(workflowRequest);
            // TODO: Add code to check for an error.
          }
        }
        catch (Exception ex) {
          errorMessage += $"Exception canceling Agreement Expire Workflow: {ex.Message}{Environment.NewLine}";
        }
      }

      // Get all Agreement Schedule Setups and update the PGU attribute.
      try {
        var bookingSetups = RetrieveAllTargetRecords(agreementBookingSetupFetchXml.Replace("{AGREEMENTID}", agreementid.ToString()));
        foreach (Entity ent in bookingSetups) {
          ent.Attributes["msdyn_postponegenerationuntil"] = DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0, 0));
          crmTargetSvc.Update(ent);
        }
      }
      catch (Exception ex) {
        errorMessage += $"Exception setting PGU on booking setup records: {ex.Message}{Environment.NewLine}";
      }

      // Get all the Agreement Invoice Setups and update the PGU attribute.
      try {
        var invoiceSetups = RetrieveAllTargetRecords(agreementInvoiceSetupFetchXml.Replace("{AGREEMENTID}", agreementid.ToString()));
        foreach (Entity ent in invoiceSetups) {
          ent.Attributes["msdyn_postponegenerationuntil"] = DateTime.UtcNow.Subtract(new TimeSpan(1, 0, 0, 0));
          crmTargetSvc.Update(ent);
        }
      }
      catch (Exception ex) {
        errorMessage += $"Exception setting PGU on invoice setup records: {ex.Message}{Environment.NewLine}";
      }

      return errorMessage;
    }


    private AssociateResponse AddRolesToPrincipal(IOrganizationService svc, string principalLogicalName, Guid principalId, List<Guid> roleIds) {

      AssociateRequest associateRequest = new AssociateRequest() {
        Target = new EntityReference(principalLogicalName, principalId),
        Relationship = new Relationship(principalLogicalName + "roles_association"),
        RelatedEntities = new EntityReferenceCollection()
      };

      foreach (var rid in roleIds) {
        associateRequest.RelatedEntities.Add(new EntityReference("role", rid));
      }
      return (AssociateResponse)svc.Execute(associateRequest);
    }

    internal string TargetAddMembersToTeam(Guid teamid, List<Guid> usersToAdd, List<Guid> usersToRemove) {
      string errorMessage = "";

      try {
        if (usersToRemove != null && usersToRemove.Count > 0) {
          RemoveMembersTeamRequest removeMemberRequest = new RemoveMembersTeamRequest() {
            MemberIds = usersToRemove.ToArray(),
            TeamId = teamid
          };
          RemoveMembersTeamResponse removeResp = (RemoveMembersTeamResponse)crmTargetSvc.Execute(removeMemberRequest);
          // TODO Add logic to parse results.
        }
      }
      catch (Exception ex) {
        errorMessage += $"ERROR removing existing team members: {ex.Message}";
      }
      // there was an error return.
      if (errorMessage != "")
        return errorMessage;

      AddMembersTeamResponse addResp;
      foreach (var x in usersToAdd) {
        try {

          AddMembersTeamRequest addMemberRequest = new AddMembersTeamRequest() {
            TeamId = teamid,
            MemberIds = new Guid[] { x }
          };

          // TESTING
          //var x = crmTargetSvc.Retrieve("systemuser", usersToAdd[0], new ColumnSet(false));

          //addMemberRequest.MemberIds[0] = x;
          addResp = (AddMembersTeamResponse)crmTargetSvc.Execute(addMemberRequest);

          // TODO Add logic to parse results.
        }
        catch (Exception ex) {
          errorMessage += $"ERROR: {ex.Message}";
        }
      }

      return errorMessage;
    }

    // this function does NOT handle attributes that are
    // different between source and target.  Those must be dealt with outside of this function.
    // if there attributes that you do not want to be modified in the target entity remove them
    // from the source entity attributes collection before calling this function.
    public bool TransformTargetEntity(List<AttributeMetadata> sourceAttributeMetadata, List<AttributeMetadata> targetAttributeMetadata, Entity sourceEntity, ref Entity targetEntity) {
      try {
        string attributeName = "";
        bool targetAttributeIsValid = false;

        // set all related attributes so targetIncident data will mach sourceIncident data.
        foreach (AttributeMetadata attr in sourceAttributeMetadata) {
          // the following is a set of attributes that need to be handled outside of this function.
          // if there are additional attributes that should be ignored then remove them from the
          // sourceEntity before calling this function.  This will ensure they are not processed here.
          if (attr.LogicalName.ToLower() == "id" ||
              attr.LogicalName.ToLower() == "createdon" ||
              attr.LogicalName.ToLower() == "createdby" ||
              attr.LogicalName.ToLower() == "overriddencreatedon" ||
              attr.LogicalName.ToLower() == "createdonbehalfby" ||
              attr.LogicalName.ToLower() == "ownerid" ||
              attr.LogicalName.ToLower() == "statecode" ||
              attr.LogicalName.ToLower() == "statuscode" ||
              attr.LogicalName.ToLower() == "modifiedby" ||
              attr.LogicalName.ToLower() == "modifiedon"
              )
            continue;

          if (attr.IsValidForUpdate.HasValue && attr.IsValidForUpdate.Value &&
              attr.IsValidForCreate.HasValue && attr.IsValidForCreate.Value) {
            attributeName = attr.LogicalName;

            targetAttributeIsValid = false;
            foreach (AttributeMetadata targetAttr in targetAttributeMetadata) {
              if (targetAttr.LogicalName == attributeName) {
                targetAttributeIsValid = true;
                break;
              }
            }

            if (!targetAttributeIsValid)
              continue;

            if (sourceEntity.Attributes.ContainsKey(attributeName)) {

              switch (attr.AttributeType) {
                case AttributeTypeCode.BigInt:
                case AttributeTypeCode.Integer:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<int>(attributeName);
                    var targetVAlue = targetEntity.GetAttributeValue<int>(attributeName);
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<int>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<int>(attributeName));
                  break;

                case AttributeTypeCode.Boolean:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<bool>(attributeName);
                    var targetVAlue = targetEntity.GetAttributeValue<bool>(attributeName);
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<bool>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<bool>(attributeName));
                  break;

                case AttributeTypeCode.Customer:
                case AttributeTypeCode.Lookup:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<EntityReference>(attributeName).Id;
                    var targetVAlue = targetEntity.GetAttributeValue<EntityReference>(attributeName).Id;
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<EntityReference>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<EntityReference>(attributeName));
                  break;

                case AttributeTypeCode.DateTime:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<DateTime>(attributeName);
                    var targetVAlue = targetEntity.GetAttributeValue<DateTime>(attributeName);
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<DateTime>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<DateTime>(attributeName));
                  break;

                case AttributeTypeCode.Decimal:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<decimal>(attributeName);
                    var targetVAlue = targetEntity.GetAttributeValue<decimal>(attributeName);
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<decimal>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<decimal>(attributeName));
                  break;

                case AttributeTypeCode.Double:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<double>(attributeName);
                    var targetVAlue = targetEntity.GetAttributeValue<double>(attributeName);
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<double>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<double>(attributeName));
                  break;

                case AttributeTypeCode.Memo:
                case AttributeTypeCode.String:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<string>(attributeName);
                    var targetVAlue = targetEntity.GetAttributeValue<string>(attributeName);
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<string>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<string>(attributeName));
                  break;

                case AttributeTypeCode.Money:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<Money>(attributeName).Value;
                    var targetVAlue = targetEntity.GetAttributeValue<Money>(attributeName).Value;
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<Money>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<Money>(attributeName));
                  break;

                case AttributeTypeCode.Picklist:
                  if (targetEntity.Contains(attributeName)) {
                    // see if the attribute is a match, if it is then remove it from the collection.
                    var sourceValue = sourceEntity.GetAttributeValue<OptionSetValue>(attributeName).Value;
                    var targetVAlue = targetEntity.GetAttributeValue<OptionSetValue>(attributeName).Value;
                    if (sourceValue == targetVAlue)
                      targetEntity.Attributes.Remove(attributeName);
                    else
                      targetEntity.Attributes[attributeName] = sourceEntity.GetAttributeValue<OptionSetValue>(attributeName);
                  }
                  else
                    targetEntity.Attributes.Add(attributeName, sourceEntity.GetAttributeValue<OptionSetValue>(attributeName));
                  break;
              }
            }
          }
        }
      }
      catch (Exception ex) {
        //Console.WriteLine($"ERROR transforming entity, Error Message: {ex.Message}");
        //ex.Dump();
        return false;
      }
      return true;
    }

    public int GetTargetEntityObjectTypeCode(string entityLogicalName) {
      if (string.IsNullOrEmpty(entityLogicalName)) { throw new System.ArgumentException("String can not be null", "entityName"); }

      try {
        RetrieveEntityRequest entityRequest = new RetrieveEntityRequest();
        entityRequest.LogicalName = entityLogicalName;
        RetrieveEntityResponse entityResponse = (RetrieveEntityResponse)crmTargetSvc.Execute(entityRequest);
        return entityResponse.EntityMetadata.ObjectTypeCode.Value;
      }
      catch (Exception e) {
        return -1;
      }
    }
  }

  public class MobileProject {
    public Guid resco_mobileprojectid { get; set; }
    public string resco_name { get; set; }
    public string resco_parents { get; set; }
    public int resco_priority { get; set; }
    public DateTime? resco_publishedon { get; set; }
    public int resco_publishedversion { get; set; }
    public Guid resco_roleid { get; set; }
    public Guid resco_rootmobileprojectid { get; set; }
    public int resco_type { get; set; }
  }

  public class UserSettingSyncResult {
    public string Step { get; set; }
    public Entity TargetUser { get; set; }
    public Entity SourceUser { get; set; }
    public Entity TargetSettings { get; set; }
    public Exception ex { get; set; }
    public bool IsError { get; set; }
  }

  public class MobileData {
    public Guid resco_mobiledataid { get; set; }
    public string resco_regardingobjectid { get; set; }
    public int resco_sequencenumber { get; set; }
    public string resco_data { get; set; }

  }

  public class UserSettings {
    public static class Fields {
      public const string AddressBookSyncInterval = "addressbooksyncinterval";
      public const string AdvancedFindStartupMode = "advancedfindstartupmode";
      public const string AllowEmailCredentials = "allowemailcredentials";
      public const string AMDesignator = "amdesignator";
      public const string AutoCreateContactOnPromote = "autocreatecontactonpromote";
      public const string BusinessUnitId = "businessunitid";
      public const string CalendarType = "calendartype";
      public const string CreatedBy = "createdby";
      public const string CreatedOn = "createdon";
      public const string CreatedOnBehalfBy = "createdonbehalfby";
      public const string CurrencyDecimalPrecision = "currencydecimalprecision";
      public const string CurrencyFormatCode = "currencyformatcode";
      public const string CurrencySymbol = "currencysymbol";
      public const string DataValidationModeForExportToExcel = "datavalidationmodeforexporttoexcel";
      public const string DateFormatCode = "dateformatcode";
      public const string DateFormatString = "dateformatstring";
      public const string DateSeparator = "dateseparator";
      public const string DecimalSymbol = "decimalsymbol";
      public const string DefaultCalendarView = "defaultcalendarview";
      public const string DefaultCountryCode = "defaultcountrycode";
      public const string DefaultDashboardId = "defaultdashboardid";
      public const string DefaultSearchExperience = "defaultsearchexperience";
      public const string EmailPassword = "emailpassword";
      public const string EmailUsername = "emailusername";
      public const string EntityFormMode = "entityformmode";
      public const string FullNameConventionCode = "fullnameconventioncode";
      public const string GetStartedPaneContentEnabled = "getstartedpanecontentenabled";
      public const string HelpLanguageId = "helplanguageid";
      public const string HomepageArea = "homepagearea";
      public const string HomepageLayout = "homepagelayout";
      public const string HomepageSubarea = "homepagesubarea";
      public const string IgnoreUnsolicitedEmail = "ignoreunsolicitedemail";
      public const string IncomingEmailFilteringMethod = "incomingemailfilteringmethod";
      public const string IsAppsForCrmAlertDismissed = "isappsforcrmalertdismissed";
      public const string IsAutoDataCaptureEnabled = "isautodatacaptureenabled";
      public const string IsDefaultCountryCodeCheckEnabled = "isdefaultcountrycodecheckenabled";
      public const string IsDuplicateDetectionEnabledWhenGoingOnline = "isduplicatedetectionenabledwhengoingonline";
      public const string IsGuidedHelpEnabled = "isguidedhelpenabled";
      public const string IsResourceBookingExchangeSyncEnabled = "isresourcebookingexchangesyncenabled";
      public const string IsSendAsAllowed = "issendasallowed";
      public const string LastAlertsViewedTime = "lastalertsviewedtime";
      public const string LocaleId = "localeid";
      public const string LongDateFormatCode = "longdateformatcode";
      public const string ModifiedBy = "modifiedby";
      public const string ModifiedOn = "modifiedon";
      public const string ModifiedOnBehalfBy = "modifiedonbehalfby";
      public const string NegativeCurrencyFormatCode = "negativecurrencyformatcode";
      public const string NegativeFormatCode = "negativeformatcode";
      public const string NextTrackingNumber = "nexttrackingnumber";
      public const string NumberGroupFormat = "numbergroupformat";
      public const string NumberSeparator = "numberseparator";
      public const string OfflineSyncInterval = "offlinesyncinterval";
      public const string OutlookSyncInterval = "outlooksyncinterval";
      public const string PagingLimit = "paginglimit";
      public const string PersonalizationSettings = "personalizationsettings";
      public const string PMDesignator = "pmdesignator";
      public const string PricingDecimalPrecision = "pricingdecimalprecision";
      public const string ReportScriptErrors = "reportscripterrors";
      public const string ResourceBookingExchangeSyncVersion = "resourcebookingexchangesyncversion";
      public const string ShowWeekNumber = "showweeknumber";
      public const string SplitViewState = "splitviewstate";
      public const string SyncContactCompany = "synccontactcompany";
      public const string SystemUserId = "systemuserid";
      public const string Id = "systemuserid";
      public const string TimeFormatCode = "timeformatcode";
      public const string TimeFormatString = "timeformatstring";
      public const string TimeSeparator = "timeseparator";
      public const string TimeZoneBias = "timezonebias";
      public const string TimeZoneCode = "timezonecode";
      public const string TimeZoneDaylightBias = "timezonedaylightbias";
      public const string TimeZoneDaylightDay = "timezonedaylightday";
      public const string TimeZoneDaylightDayOfWeek = "timezonedaylightdayofweek";
      public const string TimeZoneDaylightHour = "timezonedaylighthour";
      public const string TimeZoneDaylightMinute = "timezonedaylightminute";
      public const string TimeZoneDaylightMonth = "timezonedaylightmonth";
      public const string TimeZoneDaylightSecond = "timezonedaylightsecond";
      public const string TimeZoneDaylightYear = "timezonedaylightyear";
      public const string TimeZoneStandardBias = "timezonestandardbias";
      public const string TimeZoneStandardDay = "timezonestandardday";
      public const string TimeZoneStandardDayOfWeek = "timezonestandarddayofweek";
      public const string TimeZoneStandardHour = "timezonestandardhour";
      public const string TimeZoneStandardMinute = "timezonestandardminute";
      public const string TimeZoneStandardMonth = "timezonestandardmonth";
      public const string TimeZoneStandardSecond = "timezonestandardsecond";
      public const string TimeZoneStandardYear = "timezonestandardyear";
      public const string TrackingTokenId = "trackingtokenid";
      public const string TransactionCurrencyId = "transactioncurrencyid";
      public const string UILanguageId = "uilanguageid";
      public const string UseCrmFormForAppointment = "usecrmformforappointment";
      public const string UseCrmFormForContact = "usecrmformforcontact";
      public const string UseCrmFormForEmail = "usecrmformforemail";
      public const string UseCrmFormForTask = "usecrmformfortask";
      public const string UseImageStrips = "useimagestrips";
      public const string UserProfile = "userprofile";
      public const string VersionNumber = "versionnumber";
      public const string VisualizationPaneLayout = "visualizationpanelayout";
      public const string WorkdayStartTime = "workdaystarttime";
      public const string WorkdayStopTime = "workdaystoptime";
      public const string lk_usersettings_createdonbehalfby = "lk_usersettings_createdonbehalfby";
      public const string lk_usersettings_modifiedonbehalfby = "lk_usersettings_modifiedonbehalfby";
      public const string lk_usersettingsbase_createdby = "lk_usersettingsbase_createdby";
      public const string lk_usersettingsbase_modifiedby = "lk_usersettingsbase_modifiedby";
      public const string transactioncurrency_usersettings = "transactioncurrency_usersettings";
      public const string user_settings = "user_settings";
    }
  }
  public static class RequirementStatusCoreStatus {
    public static readonly EntityReference ActiveReference = new EntityReference("msdyn_requirementstatus", new Guid("F1F20CAE-4A76-44EB-BE6D-DB346BA57013"));
    public static readonly EntityReference CompletedReference = new EntityReference("msdyn_requirementstatus", new Guid("3D6F40B1-0FB5-40D3-8F12-6CD30F67BCAD"));
    public static readonly EntityReference CanceledReference = new EntityReference("msdyn_requirementstatus", new Guid("BD1445BF-9948-4C93-86D3-6D0D08E99B3B"));

    public static readonly IReadOnlyDictionary<OptionSetValue, Guid> RequirementStatusIdMap = new ReadOnlyDictionary<OptionSetValue, Guid>(
        new Dictionary<OptionSetValue, Guid>
        {
                { RequirementStatus.Active, ActiveReference.Id },
                { RequirementStatus.Completed, CompletedReference.Id },
                { RequirementStatus.Canceled, CanceledReference.Id }
        });
  }

  public static class RequirementStatus {
    public static readonly OptionSetValue Active = new OptionSetValue(690970000);
    public static readonly OptionSetValue Completed = new OptionSetValue(690970001);
    public static readonly OptionSetValue Canceled = new OptionSetValue(690970002);
  }

  public static class RequirementResourcePreferenceType {
    public static readonly OptionSetValue Preferred = new OptionSetValue(690970000);
    public static readonly OptionSetValue Restricted = new OptionSetValue(690970001);
  }

  public class CreateWorkOrderRelatedRecordsArgs {
    public bool IgnoreRelatedRecordsCreatedFlag { get; set; }
    public bool ProcessCompletedWorkOrders { get; set; }
  }

  public class ValidateDataArgs {
    public string sourceEntityLogicalName { get; set; }
    public string sourcePrimaryNameAttribute { get; set; }
    public string targetEntityLogicalName { get; set; }
    public string targetPrimaryNameAttribute { get; set; }
  }
}
