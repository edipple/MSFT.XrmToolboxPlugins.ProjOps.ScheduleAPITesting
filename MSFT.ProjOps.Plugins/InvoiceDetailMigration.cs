using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.ServiceModel;
using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using MSCPS.FieldSericeMigration.Plugins.ProxyClasses;

namespace MSCPS.FieldSericeMigration.Plugins {
    public partial class InvoiceDetailMigration : BasePlugin {
        public InvoiceDetailMigration(string unsecureConfig, string secureConfig) : base(unsecureConfig, secureConfig) {
            // Register for any specific events by instantiating a new instance of the 'PluginEvent' class and registering it
            base.RegisteredEvents.Add(new PluginEvent() {
                Stage = eStage.PostOperation,
                MessageName = MessageNames.Update,
                EntityName = EntityNames.invoicedetail,
                PluginAction = ExecutePluginLogic
            });
        }
        public void ExecutePluginLogic(IServiceProvider serviceProvider) {
            // Use a 'using' statement to dispose of the service context properly
            // To use a specific early bound entity replace the 'Entity' below with the appropriate class type
            using (var localContext = new LocalPluginContext<invoicedetail>(serviceProvider)) {
                if (localContext.Depth > 1) {
                    localContext.Trace($"Plugin Depth is: {localContext.Depth}, skipping execution");
                    return;
                }
                    
                try {
                    localContext.Trace("Getting the target entity as an invoicedetail entity.");
                    invoicedetail invdetail = localContext.TargetEntity.ToProxy<invoicedetail>();
                 
                    // Only do this if the targetEntity does NOT have a productid value.
                    if (invdetail.productid == null) {
                        if (invdetail.msdyn_agreementinvoiceproduct != null) {
                            msdyn_agreementinvoiceproduct agreementInvoiceProduct = invdetail.msdyn_agreementinvoiceproduct.RetrieveProxy<msdyn_agreementinvoiceproduct>(localContext.OrganizationService, new ColumnSet("msdyn_product", "msdyn_unit"));
                            invdetail.productid = agreementInvoiceProduct.msdyn_product;
                            invdetail.uomid = agreementInvoiceProduct.msdyn_unit;
                            invdetail.Update(localContext.OrganizationService);
                        }
                        else if (invdetail.msdyn_workorderproductid != null) {
                            msdyn_workorderproduct woProduct = invdetail.msdyn_workorderproductid.RetrieveProxy<msdyn_workorderproduct>(localContext.OrganizationService, new ColumnSet(msdyn_workorderproduct.Properties.msdyn_product, msdyn_workorderproduct.Properties.msdyn_unit));
                            invdetail.productid = woProduct.msdyn_product;
                            invdetail.uomid = woProduct.msdyn_unit;
                            invdetail.Update(localContext.OrganizationService);
                        }
                        else if (invdetail.msdyn_workorderserviceid != null) {
                            msdyn_workorderservice woService = invdetail.msdyn_workorderserviceid.RetrieveProxy<msdyn_workorderservice>(localContext.OrganizationService, msdyn_workorderservice.Properties.msdyn_service, msdyn_workorderservice.Properties.msdyn_unit);
                            invdetail.productid = woService.msdyn_service;
                            invdetail.uomid = woService.msdyn_unit;
                            invdetail.Update(localContext.OrganizationService);
                        }                       
                    }
                }
                catch (Exception ex) {
                    // for now just throw the exception so the Trace Logging in CRM will see it.
                    // Trace Logging in CRM should be set to Exception only when data sync of invoice/invoicedetail is running.
                    throw ex;
                }
            }
        }
    }
}
