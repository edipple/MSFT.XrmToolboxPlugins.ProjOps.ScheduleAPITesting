using System.Collections.Specialized;

namespace MSCPS.F12FSMigration {
    partial class F12FSMigrationPluginControl {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
      System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
      this.toolStripMenu = new System.Windows.Forms.ToolStrip();
      this.tsbClose = new System.Windows.Forms.ToolStripButton();
      this.tssSeparator1 = new System.Windows.Forms.ToolStripSeparator();
      this.tsbOpenLogFile = new System.Windows.Forms.ToolStripButton();
      this.tsbCancelOperation = new System.Windows.Forms.ToolStripButton();
      this.tabMain = new System.Windows.Forms.TabControl();
      this.tpProcessManagement = new System.Windows.Forms.TabPage();
      this.lblInfo = new System.Windows.Forms.Label();
      this.btnEnableAllProcessesByEntity = new System.Windows.Forms.Button();
      this.btnRetriaveAllProcessesByEntity = new System.Windows.Forms.Button();
      this.btnDisableAllProcessesByEntity = new System.Windows.Forms.Button();
      this.label4 = new System.Windows.Forms.Label();
      this.cbEntityList = new System.Windows.Forms.ComboBox();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.dgWorkflows = new System.Windows.Forms.DataGridView();
      this.State = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.WFName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.PrimaryEntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.IsManaged = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dsProcesses = new System.Data.DataSet();
      this.dtWorkflows = new System.Data.DataTable();
      this.dcWFId = new System.Data.DataColumn();
      this.dcWFState = new System.Data.DataColumn();
      this.dcWFName = new System.Data.DataColumn();
      this.dcWFPrimaryEntity = new System.Data.DataColumn();
      this.dcWFIsManaged = new System.Data.DataColumn();
      this.dtPluginSteps = new System.Data.DataTable();
      this.dcPSId = new System.Data.DataColumn();
      this.dcPSState = new System.Data.DataColumn();
      this.dcPSName = new System.Data.DataColumn();
      this.dcPSIsManaged = new System.Data.DataColumn();
      this.dcPSPrimaryEntity = new System.Data.DataColumn();
      this.label1 = new System.Windows.Forms.Label();
      this.btnEnableSelectedWorkflows = new System.Windows.Forms.Button();
      this.btnDisableSelectedWorkflows = new System.Windows.Forms.Button();
      this.dgPluginSteps = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.PSName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.label2 = new System.Windows.Forms.Label();
      this.btnEnableSelectedPluginSteps = new System.Windows.Forms.Button();
      this.btnDisableSelectPluginSteps = new System.Windows.Forms.Button();
      this.btnDisableAllProcesses = new System.Windows.Forms.Button();
      this.btnRetriveProcesses = new System.Windows.Forms.Button();
      this.tpPreDataMigration = new System.Windows.Forms.TabPage();
      this.tcUserManagement = new System.Windows.Forms.TabControl();
      this.tpBUMapping = new System.Windows.Forms.TabPage();
      this.dgBUMapping = new System.Windows.Forms.DataGridView();
      this.sourcebuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcebunameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_buid = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetbunameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dsFSMigrationBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.dsFSMigration = new MSCPS.F12FSMigration.dsFSMigration();
      this.btnLoadBUMapping = new System.Windows.Forms.Button();
      this.btnSaveBUMapping = new System.Windows.Forms.Button();
      this.btnMapBU = new System.Windows.Forms.Button();
      this.tpCurrencyMapping = new System.Windows.Forms.TabPage();
      this.dgCurrenyMapping = new System.Windows.Forms.DataGridView();
      this.sourcetransactioncurrencyidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourceisocurrencycodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcecurrencysymbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targettransactioncurrencyidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetisocurrencycodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetcurrencynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetcurrencysymbolDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnLoadCurrencyMapping = new System.Windows.Forms.Button();
      this.btnSaveCurrencyMapping = new System.Windows.Forms.Button();
      this.btnCurrencyMapping = new System.Windows.Forms.Button();
      this.tpRoleMapping = new System.Windows.Forms.TabPage();
      this.dgRoleMapping = new System.Windows.Forms.DataGridView();
      this.source_businessunitname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourceroleidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcerolenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_parentrootroleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_businessunitname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetroleidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetrolenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dtSecurityRoleMappingBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.btnSaveRoleMappings = new System.Windows.Forms.Button();
      this.btnLoadRoleMappings = new System.Windows.Forms.Button();
      this.btnMapRoles = new System.Windows.Forms.Button();
      this.tpStubUsers = new System.Windows.Forms.TabPage();
      this.cbStubUsersHideUnlicensed = new System.Windows.Forms.CheckBox();
      this.cbHideWithSPRole = new System.Windows.Forms.CheckBox();
      this.cbCreate_z_StubUser = new System.Windows.Forms.CheckBox();
      this.cbUserSnycSettings = new System.Windows.Forms.CheckBox();
      this.cbUserSnycUserInfo = new System.Windows.Forms.CheckBox();
      this.cbStubUsersHideMatchingBU = new System.Windows.Forms.CheckBox();
      this.cbStubUsersHideDisabled = new System.Windows.Forms.CheckBox();
      this.cbSyncSettings = new System.Windows.Forms.CheckBox();
      this.cbUserSnycBusinessUnit = new System.Windows.Forms.CheckBox();
      this.btnSyncUserSettings = new System.Windows.Forms.Button();
      this.dgSystemUsers = new System.Windows.Forms.DataGridView();
      this.IsInTarget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.target_bumatch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.MissingSPRole = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.AddZ_StubToTarget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.AddStubToTarget = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.SyncSettings = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewCheckBoxColumn3 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.source_islicensed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcedomainDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_identitiyid = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.fullname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_parentsystemusername = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_territoryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_transactioncurrencyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewCheckBoxColumn4 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.target_islicensed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_DomainName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_identityid = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_FullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_parentsystemusername = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_territoryname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_transactioncurrencyname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.cbHideInTarget = new System.Windows.Forms.CheckBox();
      this.btnLoadSourceUsers = new System.Windows.Forms.Button();
      this.lblUsersTotalInfo = new System.Windows.Forms.Label();
      this.cbAddStubUsersCheckUncheck = new System.Windows.Forms.CheckBox();
      this.btnCreateStubUsers = new System.Windows.Forms.Button();
      this.tpUserSecurity = new System.Windows.Forms.TabPage();
      this.cbUserSecurityHideUnLicensed = new System.Windows.Forms.CheckBox();
      this.cbUserSecurityHideDisabled = new System.Windows.Forms.CheckBox();
      this.ckClearTargetRoles = new System.Windows.Forms.CheckBox();
      this.ckUserSecurityCheckUncheck = new System.Windows.Forms.CheckBox();
      this.scUserSecurityMain = new System.Windows.Forms.SplitContainer();
      this.dgUserSecurity = new System.Windows.Forms.DataGridView();
      this.SyncRoles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.ClearTargetRoles = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.RolesMatch = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.source_IsDisabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.source_buname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_domainname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcerolenamesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_IsDisabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.target_buname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetrolenamesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.scUserSecurityRoles = new System.Windows.Forms.SplitContainer();
      this.lblSourceUserRoles = new System.Windows.Forms.Label();
      this.dgSourceUserRoles = new System.Windows.Forms.DataGridView();
      this.source_roleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_rolename = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.lblTargetUserRoles = new System.Windows.Forms.Label();
      this.dgTargetUserRoles = new System.Windows.Forms.DataGridView();
      this.target_roleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_rolename = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnSyncSecurityRoles = new System.Windows.Forms.Button();
      this.btnCompareSecurityRoles = new System.Windows.Forms.Button();
      this.tpTeamMembership = new System.Windows.Forms.TabPage();
      this.splitContainer4 = new System.Windows.Forms.SplitContainer();
      this.btnSyncTeamMembers = new System.Windows.Forms.Button();
      this.cbClearTargetMembersCheckUncheck = new System.Windows.Forms.CheckBox();
      this.cbSyncTeamMembersCheckUncheck = new System.Windows.Forms.CheckBox();
      this.dgTeamMembership = new System.Windows.Forms.DataGridView();
      this.dataGridViewCheckBoxColumn6 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewCheckBoxColumn5 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.target_isdefault = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.sourceteamidDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetteamidDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnTeamMembershipLoadTeams = new System.Windows.Forms.Button();
      this.splitContainer5 = new System.Windows.Forms.SplitContainer();
      this.label14 = new System.Windows.Forms.Label();
      this.dgSourceTeamMembership = new System.Windows.Forms.DataGridView();
      this.sourceteamidDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourceuseridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourceusernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.source_userisdisabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dtSourceTeamMembershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.label15 = new System.Windows.Forms.Label();
      this.dgTargetTeamMembership = new System.Windows.Forms.DataGridView();
      this.target_teamid = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_teamname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetuseridDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_username = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.target_userisdisabled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dtTargetTeamMembershipBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.btnTeamAddUserLoadTeams = new System.Windows.Forms.Button();
      this.tpTeamSecurity = new System.Windows.Forms.TabPage();
      this.scTeamSecurityMain = new System.Windows.Forms.SplitContainer();
      this.dgTeamSecurity = new System.Windows.Forms.DataGridView();
      this.rolesMatchDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.syncRolesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.clearTargetRolesDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.sourcebusinessunitidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcebunameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourceteamidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcerolenamesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetbusinessunitidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetbunameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetteamidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetrolenamesDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.scTeamSecurityRoles = new System.Windows.Forms.SplitContainer();
      this.label11 = new System.Windows.Forms.Label();
      this.dgSourceTeamRoles = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.label12 = new System.Windows.Forms.Label();
      this.dgTargetTeamRoles = new System.Windows.Forms.DataGridView();
      this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ckClearTeamTargetRoles = new System.Windows.Forms.CheckBox();
      this.ckTeamSecurityCheckUncheck = new System.Windows.Forms.CheckBox();
      this.btnTeamSyncRoles = new System.Windows.Forms.Button();
      this.btnCompareTeamSecurity = new System.Windows.Forms.Button();
      this.tpUOMSync = new System.Windows.Forms.TabPage();
      this.splitContainerUOM = new System.Windows.Forms.SplitContainer();
      this.panel1 = new System.Windows.Forms.Panel();
      this.label20 = new System.Windows.Forms.Label();
      this.dgUOMSchedule = new System.Windows.Forms.DataGridView();
      this.dataGridViewCheckBoxColumn8 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewCheckBoxColumn9 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.sourcecreatedbyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcecreatedonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.sourcenameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.targetnameDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnCreateTargetUOMSchedule = new System.Windows.Forms.Button();
      this.btnMapUOMSchedule = new System.Windows.Forms.Button();
      this.panel2 = new System.Windows.Forms.Panel();
      this.label21 = new System.Windows.Forms.Label();
      this.dgUOM = new System.Windows.Forms.DataGridView();
      this.dataGridViewCheckBoxColumn11 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewCheckBoxColumn12 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewCheckBoxColumn10 = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnCreateTargetUOM = new System.Windows.Forms.Button();
      this.btnMapUOM = new System.Windows.Forms.Button();
      this.tpDataCleanup = new System.Windows.Forms.TabPage();
      this.splitContainer6 = new System.Windows.Forms.SplitContainer();
      this.dgDataCleanupResults = new System.Windows.Forms.DataGridView();
      this.entitylogicalname = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.idDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.splitContainer7 = new System.Windows.Forms.SplitContainer();
      this.txtDataCleanupSourceFetchXml = new System.Windows.Forms.TextBox();
      this.label16 = new System.Windows.Forms.Label();
      this.txtDataCleanupTargetFetchXml = new System.Windows.Forms.TextBox();
      this.label17 = new System.Windows.Forms.Label();
      this.btnDataCleanupCreateTestData = new System.Windows.Forms.Button();
      this.btnDataCleanupDeleteRecords = new System.Windows.Forms.Button();
      this.label10 = new System.Windows.Forms.Label();
      this.txtDataCleanupTargetAttribute = new System.Windows.Forms.TextBox();
      this.label9 = new System.Windows.Forms.Label();
      this.txtDataCleanupSourceAttribute = new System.Windows.Forms.TextBox();
      this.btnDataCleanupLoadTargetEntities = new System.Windows.Forms.Button();
      this.btnDataCleanupLoadSourceEntities = new System.Windows.Forms.Button();
      this.cbDataCleanupTargetEntityList = new System.Windows.Forms.ComboBox();
      this.label8 = new System.Windows.Forms.Label();
      this.btnDataCleanupValidateRecords = new System.Windows.Forms.Button();
      this.cbDataCleanupSourceEntityList = new System.Windows.Forms.ComboBox();
      this.label7 = new System.Windows.Forms.Label();
      this.label6 = new System.Windows.Forms.Label();
      this.tpAgreementProcessing = new System.Windows.Forms.TabPage();
      this.tcAgreementProcessing = new System.Windows.Forms.TabControl();
      this.tpAgreementWorkflowReset = new System.Windows.Forms.TabPage();
      this.btnAgreementWorkflowReset = new System.Windows.Forms.Button();
      this.btnAgreementWorkflowResetSearch = new System.Windows.Forms.Button();
      this.dgAgreementWorkflowResetAgreements = new System.Windows.Forms.DataGridView();
      this.agreementnameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.agreementidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.btnAgreementWorkflowResetRefreshUsers = new System.Windows.Forms.Button();
      this.label18 = new System.Windows.Forms.Label();
      this.cbAgreementWorkFlowResetUsers = new System.Windows.Forms.ComboBox();
      this.tpAgreementFailures = new System.Windows.Forms.TabPage();
      this.lbl1 = new System.Windows.Forms.Label();
      this.dtpAgreementFailuresEnd = new System.Windows.Forms.DateTimePicker();
      this.label19 = new System.Windows.Forms.Label();
      this.dtpAgreementFailuresStart = new System.Windows.Forms.DateTimePicker();
      this.btnAgreementFailuresLoad = new System.Windows.Forms.Button();
      this.splitContainer8 = new System.Windows.Forms.SplitContainer();
      this.dgAreementFailuresSystemJobs = new System.Windows.Forms.DataGridView();
      this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.regardingobjectidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.regardingobjectnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.operationtypenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.startedonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.completedonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.ownernameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.owningextensionnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.errorcodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.messagenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.friendlynameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.messageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.postponeuntilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.primaryentitytypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.statuscodenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.dtAgreementFailuresBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.pgAgreementObjectDetails = new System.Windows.Forms.PropertyGrid();
      this.tpAgreementPerfTesting = new System.Windows.Forms.TabPage();
      this.scAgreementProcessing = new System.Windows.Forms.SplitContainer();
      this.lblBookingSetupTotalRecords = new System.Windows.Forms.Label();
      this.cbBookingSetupCheckUncheck = new System.Windows.Forms.CheckBox();
      this.btnBookingSetupUpdate = new System.Windows.Forms.Button();
      this.dpBookingSetupStartDate = new System.Windows.Forms.DateTimePicker();
      this.dgBookingSetup = new System.Windows.Forms.DataGridView();
      this.UpdateAgreement = new System.Windows.Forms.DataGridViewCheckBoxColumn();
      this.msdynnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.msdynrecurrencesettingsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.msdynrevisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.msdynpostponegenerationuntilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.agreementNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.msdynagreementDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
      this.label5 = new System.Windows.Forms.Label();
      this.btnRetrieveBookingSetup = new System.Windows.Forms.Button();
      this.tpAgreementPostDataMigration = new System.Windows.Forms.TabPage();
      this.splitContainer1 = new System.Windows.Forms.SplitContainer();
      this.btnAgreementResetInvoiceSetup = new System.Windows.Forms.Button();
      this.btnAgreementResetBookingSetup = new System.Windows.Forms.Button();
      this.txtAgreementProcessingResults = new System.Windows.Forms.TextBox();
      this.btnAgreementMarkExpired = new System.Windows.Forms.Button();
      this.splitContainer3 = new System.Windows.Forms.SplitContainer();
      this.label3 = new System.Windows.Forms.Label();
      this.label13 = new System.Windows.Forms.Label();
      this.tpPostDataMigration = new System.Windows.Forms.TabPage();
      this.splitContainerPostDataMigration = new System.Windows.Forms.SplitContainer();
      this.cbProcessClosedWorkOrders = new System.Windows.Forms.CheckBox();
      this.cbProcessAllWorkOrders = new System.Windows.Forms.CheckBox();
      this.btnResourceRequirements = new System.Windows.Forms.Button();
      this.tbPostDataMigrationResults = new System.Windows.Forms.TextBox();
      this.tpEntityCompare = new System.Windows.Forms.TabPage();
      this.dtSourceRequirementsBindingSource = new System.Windows.Forms.BindingSource(this.components);
      this.dsMobileProjects = new System.Data.DataSet();
      this.dtMobileProject = new System.Data.DataTable();
      this.dc_resco_mobileprojectid = new System.Data.DataColumn();
      this.dc_resco_name = new System.Data.DataColumn();
      this.dc_resco_parents = new System.Data.DataColumn();
      this.dc_resco_priority = new System.Data.DataColumn();
      this.dc_resco_publishedon = new System.Data.DataColumn();
      this.dc_resco_publishedversion = new System.Data.DataColumn();
      this.dc_resco_roleid = new System.Data.DataColumn();
      this.dc_resco_rootmobileprojectid = new System.Data.DataColumn();
      this.dc_resco_type = new System.Data.DataColumn();
      this.bindingSourceConnections = new System.Windows.Forms.BindingSource(this.components);
      this.splitContainerMain = new System.Windows.Forms.SplitContainer();
      this.txtErrorInfo = new System.Windows.Forms.TextBox();
      this.btnConnectSourceOrg = new System.Windows.Forms.Button();
      this.btnConnectTargetOrg = new System.Windows.Forms.Button();
      this.textSourceConnection = new System.Windows.Forms.TextBox();
      this.textTargetConnection = new System.Windows.Forms.TextBox();
      this.dialogFSMigrationToolingPath = new System.Windows.Forms.FolderBrowserDialog();
      this.filedlgSaveMapping = new System.Windows.Forms.SaveFileDialog();
      this.filedlgOpenRoleMapping = new System.Windows.Forms.OpenFileDialog();
      this.btnAddSPRole = new System.Windows.Forms.Button();
      this.toolStripMenu.SuspendLayout();
      this.tabMain.SuspendLayout();
      this.tpProcessManagement.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgWorkflows)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsProcesses)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtWorkflows)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtPluginSteps)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgPluginSteps)).BeginInit();
      this.tpPreDataMigration.SuspendLayout();
      this.tcUserManagement.SuspendLayout();
      this.tpBUMapping.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgBUMapping)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsFSMigrationBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsFSMigration)).BeginInit();
      this.tpCurrencyMapping.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgCurrenyMapping)).BeginInit();
      this.tpRoleMapping.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgRoleMapping)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtSecurityRoleMappingBindingSource)).BeginInit();
      this.tpStubUsers.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgSystemUsers)).BeginInit();
      this.tpUserSecurity.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scUserSecurityMain)).BeginInit();
      this.scUserSecurityMain.Panel1.SuspendLayout();
      this.scUserSecurityMain.Panel2.SuspendLayout();
      this.scUserSecurityMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgUserSecurity)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.scUserSecurityRoles)).BeginInit();
      this.scUserSecurityRoles.Panel1.SuspendLayout();
      this.scUserSecurityRoles.Panel2.SuspendLayout();
      this.scUserSecurityRoles.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgSourceUserRoles)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgTargetUserRoles)).BeginInit();
      this.tpTeamMembership.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
      this.splitContainer4.Panel1.SuspendLayout();
      this.splitContainer4.Panel2.SuspendLayout();
      this.splitContainer4.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamMembership)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
      this.splitContainer5.Panel1.SuspendLayout();
      this.splitContainer5.Panel2.SuspendLayout();
      this.splitContainer5.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgSourceTeamMembership)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtSourceTeamMembershipBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgTargetTeamMembership)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtTargetTeamMembershipBindingSource)).BeginInit();
      this.tpTeamSecurity.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scTeamSecurityMain)).BeginInit();
      this.scTeamSecurityMain.Panel1.SuspendLayout();
      this.scTeamSecurityMain.Panel2.SuspendLayout();
      this.scTeamSecurityMain.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamSecurity)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.scTeamSecurityRoles)).BeginInit();
      this.scTeamSecurityRoles.Panel1.SuspendLayout();
      this.scTeamSecurityRoles.Panel2.SuspendLayout();
      this.scTeamSecurityRoles.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgSourceTeamRoles)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgTargetTeamRoles)).BeginInit();
      this.tpUOMSync.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerUOM)).BeginInit();
      this.splitContainerUOM.Panel1.SuspendLayout();
      this.splitContainerUOM.Panel2.SuspendLayout();
      this.splitContainerUOM.SuspendLayout();
      this.panel1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgUOMSchedule)).BeginInit();
      this.panel2.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgUOM)).BeginInit();
      this.tpDataCleanup.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).BeginInit();
      this.splitContainer6.Panel1.SuspendLayout();
      this.splitContainer6.Panel2.SuspendLayout();
      this.splitContainer6.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgDataCleanupResults)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).BeginInit();
      this.splitContainer7.Panel1.SuspendLayout();
      this.splitContainer7.Panel2.SuspendLayout();
      this.splitContainer7.SuspendLayout();
      this.tpAgreementProcessing.SuspendLayout();
      this.tcAgreementProcessing.SuspendLayout();
      this.tpAgreementWorkflowReset.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgAgreementWorkflowResetAgreements)).BeginInit();
      this.tpAgreementFailures.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).BeginInit();
      this.splitContainer8.Panel1.SuspendLayout();
      this.splitContainer8.Panel2.SuspendLayout();
      this.splitContainer8.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgAreementFailuresSystemJobs)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtAgreementFailuresBindingSource)).BeginInit();
      this.tpAgreementPerfTesting.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scAgreementProcessing)).BeginInit();
      this.scAgreementProcessing.Panel1.SuspendLayout();
      this.scAgreementProcessing.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgBookingSetup)).BeginInit();
      this.tpAgreementPostDataMigration.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
      this.splitContainer1.Panel1.SuspendLayout();
      this.splitContainer1.Panel2.SuspendLayout();
      this.splitContainer1.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
      this.splitContainer3.Panel1.SuspendLayout();
      this.splitContainer3.Panel2.SuspendLayout();
      this.splitContainer3.SuspendLayout();
      this.tpPostDataMigration.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerPostDataMigration)).BeginInit();
      this.splitContainerPostDataMigration.Panel1.SuspendLayout();
      this.splitContainerPostDataMigration.Panel2.SuspendLayout();
      this.splitContainerPostDataMigration.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dtSourceRequirementsBindingSource)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsMobileProjects)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtMobileProject)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSourceConnections)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).BeginInit();
      this.splitContainerMain.Panel1.SuspendLayout();
      this.splitContainerMain.Panel2.SuspendLayout();
      this.splitContainerMain.SuspendLayout();
      this.SuspendLayout();
      // 
      // toolStripMenu
      // 
      this.toolStripMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
      this.toolStripMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbClose,
            this.tssSeparator1,
            this.tsbOpenLogFile,
            this.tsbCancelOperation});
      this.toolStripMenu.Location = new System.Drawing.Point(0, 0);
      this.toolStripMenu.Name = "toolStripMenu";
      this.toolStripMenu.Size = new System.Drawing.Size(1937, 31);
      this.toolStripMenu.TabIndex = 4;
      this.toolStripMenu.Text = "toolStrip1";
      // 
      // tsbClose
      // 
      this.tsbClose.Image = global::MSCPS.F12FSMigration.Properties.Resources.Close_red_16x;
      this.tsbClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.tsbClose.Name = "tsbClose";
      this.tsbClose.Size = new System.Drawing.Size(73, 28);
      this.tsbClose.Text = "Close";
      this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
      // 
      // tssSeparator1
      // 
      this.tssSeparator1.Name = "tssSeparator1";
      this.tssSeparator1.Size = new System.Drawing.Size(6, 31);
      // 
      // tsbOpenLogFile
      // 
      this.tsbOpenLogFile.Image = global::MSCPS.F12FSMigration.Properties.Resources.OpenFile_16x;
      this.tsbOpenLogFile.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbOpenLogFile.Name = "tsbOpenLogFile";
      this.tsbOpenLogFile.Size = new System.Drawing.Size(129, 28);
      this.tsbOpenLogFile.Text = "Open Log File";
      this.tsbOpenLogFile.Click += new System.EventHandler(this.tsbOpenLogFile_Click);
      // 
      // tsbCancelOperation
      // 
      this.tsbCancelOperation.Enabled = false;
      this.tsbCancelOperation.Image = global::MSCPS.F12FSMigration.Properties.Resources.ASX_Cancel_blue_16x;
      this.tsbCancelOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.tsbCancelOperation.Name = "tsbCancelOperation";
      this.tsbCancelOperation.Size = new System.Drawing.Size(152, 28);
      this.tsbCancelOperation.Text = "Cancel Operation";
      this.tsbCancelOperation.ToolTipText = "Cancel current operation";
      this.tsbCancelOperation.Click += new System.EventHandler(this.tsbCancelOperation_Click);
      this.tsbCancelOperation.EnabledChanged += new System.EventHandler(this.tsbCancelOperation_EnabledChanged);
      // 
      // tabMain
      // 
      this.tabMain.Controls.Add(this.tpProcessManagement);
      this.tabMain.Controls.Add(this.tpPreDataMigration);
      this.tabMain.Controls.Add(this.tpDataCleanup);
      this.tabMain.Controls.Add(this.tpAgreementProcessing);
      this.tabMain.Controls.Add(this.tpPostDataMigration);
      this.tabMain.Controls.Add(this.tpEntityCompare);
      this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tabMain.Location = new System.Drawing.Point(0, 0);
      this.tabMain.Margin = new System.Windows.Forms.Padding(4);
      this.tabMain.Name = "tabMain";
      this.tabMain.SelectedIndex = 0;
      this.tabMain.Size = new System.Drawing.Size(1708, 930);
      this.tabMain.TabIndex = 5;
      // 
      // tpProcessManagement
      // 
      this.tpProcessManagement.Controls.Add(this.lblInfo);
      this.tpProcessManagement.Controls.Add(this.btnEnableAllProcessesByEntity);
      this.tpProcessManagement.Controls.Add(this.btnRetriaveAllProcessesByEntity);
      this.tpProcessManagement.Controls.Add(this.btnDisableAllProcessesByEntity);
      this.tpProcessManagement.Controls.Add(this.label4);
      this.tpProcessManagement.Controls.Add(this.cbEntityList);
      this.tpProcessManagement.Controls.Add(this.splitContainer2);
      this.tpProcessManagement.Controls.Add(this.btnDisableAllProcesses);
      this.tpProcessManagement.Controls.Add(this.btnRetriveProcesses);
      this.tpProcessManagement.Location = new System.Drawing.Point(4, 25);
      this.tpProcessManagement.Margin = new System.Windows.Forms.Padding(4);
      this.tpProcessManagement.Name = "tpProcessManagement";
      this.tpProcessManagement.Size = new System.Drawing.Size(1700, 901);
      this.tpProcessManagement.TabIndex = 3;
      this.tpProcessManagement.Text = "Process Management";
      this.tpProcessManagement.UseVisualStyleBackColor = true;
      // 
      // lblInfo
      // 
      this.lblInfo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
      this.lblInfo.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
      this.lblInfo.Location = new System.Drawing.Point(0, 0);
      this.lblInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblInfo.Name = "lblInfo";
      this.lblInfo.Size = new System.Drawing.Size(1700, 20);
      this.lblInfo.TabIndex = 10;
      this.lblInfo.Text = "All commands run against Target Connection";
      this.lblInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btnEnableAllProcessesByEntity
      // 
      this.btnEnableAllProcessesByEntity.Location = new System.Drawing.Point(1092, 25);
      this.btnEnableAllProcessesByEntity.Margin = new System.Windows.Forms.Padding(4);
      this.btnEnableAllProcessesByEntity.Name = "btnEnableAllProcessesByEntity";
      this.btnEnableAllProcessesByEntity.Size = new System.Drawing.Size(209, 28);
      this.btnEnableAllProcessesByEntity.TabIndex = 9;
      this.btnEnableAllProcessesByEntity.Text = "Enable All By Entity";
      this.btnEnableAllProcessesByEntity.UseVisualStyleBackColor = true;
      this.btnEnableAllProcessesByEntity.Click += new System.EventHandler(this.btnEnableAllProcessesByEntity_Click);
      // 
      // btnRetriaveAllProcessesByEntity
      // 
      this.btnRetriaveAllProcessesByEntity.Location = new System.Drawing.Point(657, 25);
      this.btnRetriaveAllProcessesByEntity.Margin = new System.Windows.Forms.Padding(4);
      this.btnRetriaveAllProcessesByEntity.Name = "btnRetriaveAllProcessesByEntity";
      this.btnRetriaveAllProcessesByEntity.Size = new System.Drawing.Size(209, 28);
      this.btnRetriaveAllProcessesByEntity.TabIndex = 9;
      this.btnRetriaveAllProcessesByEntity.Text = "Retrieve All By Entity";
      this.btnRetriaveAllProcessesByEntity.UseVisualStyleBackColor = true;
      this.btnRetriaveAllProcessesByEntity.Click += new System.EventHandler(this.btnRetriaveAllProcessesByEntity_Click);
      // 
      // btnDisableAllProcessesByEntity
      // 
      this.btnDisableAllProcessesByEntity.Location = new System.Drawing.Point(875, 25);
      this.btnDisableAllProcessesByEntity.Margin = new System.Windows.Forms.Padding(4);
      this.btnDisableAllProcessesByEntity.Name = "btnDisableAllProcessesByEntity";
      this.btnDisableAllProcessesByEntity.Size = new System.Drawing.Size(209, 28);
      this.btnDisableAllProcessesByEntity.TabIndex = 9;
      this.btnDisableAllProcessesByEntity.Text = "Disable All By Entity";
      this.btnDisableAllProcessesByEntity.UseVisualStyleBackColor = true;
      this.btnDisableAllProcessesByEntity.Click += new System.EventHandler(this.btnDisableAllProcessesByEntity_Click);
      // 
      // label4
      // 
      this.label4.AutoSize = true;
      this.label4.Location = new System.Drawing.Point(328, 31);
      this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label4.Name = "label4";
      this.label4.Size = new System.Drawing.Size(43, 17);
      this.label4.TabIndex = 8;
      this.label4.Text = "Entity";
      // 
      // cbEntityList
      // 
      this.cbEntityList.FormattingEnabled = true;
      this.cbEntityList.Location = new System.Drawing.Point(383, 26);
      this.cbEntityList.Margin = new System.Windows.Forms.Padding(4);
      this.cbEntityList.Name = "cbEntityList";
      this.cbEntityList.Size = new System.Drawing.Size(261, 24);
      this.cbEntityList.Sorted = true;
      this.cbEntityList.TabIndex = 7;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer2.Location = new System.Drawing.Point(4, 57);
      this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.dgWorkflows);
      this.splitContainer2.Panel1.Controls.Add(this.label1);
      this.splitContainer2.Panel1.Controls.Add(this.btnEnableSelectedWorkflows);
      this.splitContainer2.Panel1.Controls.Add(this.btnDisableSelectedWorkflows);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.dgPluginSteps);
      this.splitContainer2.Panel2.Controls.Add(this.label2);
      this.splitContainer2.Panel2.Controls.Add(this.btnEnableSelectedPluginSteps);
      this.splitContainer2.Panel2.Controls.Add(this.btnDisableSelectPluginSteps);
      this.splitContainer2.Size = new System.Drawing.Size(1847, 752);
      this.splitContainer2.SplitterDistance = 838;
      this.splitContainer2.SplitterWidth = 5;
      this.splitContainer2.TabIndex = 6;
      // 
      // dgWorkflows
      // 
      this.dgWorkflows.AllowUserToAddRows = false;
      this.dgWorkflows.AllowUserToDeleteRows = false;
      this.dgWorkflows.AllowUserToResizeRows = false;
      this.dgWorkflows.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgWorkflows.AutoGenerateColumns = false;
      this.dgWorkflows.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgWorkflows.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgWorkflows.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.State,
            this.WFName,
            this.PrimaryEntity,
            this.IsManaged,
            this.idDataGridViewTextBoxColumn});
      this.dgWorkflows.DataMember = "Workflows";
      this.dgWorkflows.DataSource = this.dsProcesses;
      this.dgWorkflows.Location = new System.Drawing.Point(11, 41);
      this.dgWorkflows.Margin = new System.Windows.Forms.Padding(4);
      this.dgWorkflows.Name = "dgWorkflows";
      this.dgWorkflows.ReadOnly = true;
      this.dgWorkflows.RowHeadersVisible = false;
      this.dgWorkflows.RowHeadersWidth = 51;
      this.dgWorkflows.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgWorkflows.ShowCellErrors = false;
      this.dgWorkflows.ShowEditingIcon = false;
      this.dgWorkflows.ShowRowErrors = false;
      this.dgWorkflows.Size = new System.Drawing.Size(822, 706);
      this.dgWorkflows.TabIndex = 1;
      // 
      // State
      // 
      this.State.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.State.DataPropertyName = "State";
      this.State.HeaderText = "State";
      this.State.MinimumWidth = 6;
      this.State.Name = "State";
      this.State.ReadOnly = true;
      this.State.Width = 70;
      // 
      // WFName
      // 
      this.WFName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.WFName.DataPropertyName = "WFName";
      this.WFName.HeaderText = "Name";
      this.WFName.MinimumWidth = 6;
      this.WFName.Name = "WFName";
      this.WFName.ReadOnly = true;
      // 
      // PrimaryEntity
      // 
      this.PrimaryEntity.DataPropertyName = "PrimaryEntity";
      this.PrimaryEntity.HeaderText = "PrimaryEntity";
      this.PrimaryEntity.MinimumWidth = 6;
      this.PrimaryEntity.Name = "PrimaryEntity";
      this.PrimaryEntity.ReadOnly = true;
      // 
      // IsManaged
      // 
      this.IsManaged.DataPropertyName = "IsManaged";
      this.IsManaged.HeaderText = "IsManaged";
      this.IsManaged.MinimumWidth = 6;
      this.IsManaged.Name = "IsManaged";
      this.IsManaged.ReadOnly = true;
      // 
      // idDataGridViewTextBoxColumn
      // 
      this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
      this.idDataGridViewTextBoxColumn.HeaderText = "Id";
      this.idDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
      this.idDataGridViewTextBoxColumn.ReadOnly = true;
      this.idDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.idDataGridViewTextBoxColumn.Visible = false;
      // 
      // dsProcesses
      // 
      this.dsProcesses.DataSetName = "dsProcesses";
      this.dsProcesses.Tables.AddRange(new System.Data.DataTable[] {
            this.dtWorkflows,
            this.dtPluginSteps});
      // 
      // dtWorkflows
      // 
      this.dtWorkflows.Columns.AddRange(new System.Data.DataColumn[] {
            this.dcWFId,
            this.dcWFState,
            this.dcWFName,
            this.dcWFPrimaryEntity,
            this.dcWFIsManaged});
      this.dtWorkflows.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
      this.dtWorkflows.PrimaryKey = new System.Data.DataColumn[] {
        this.dcWFId};
      this.dtWorkflows.TableName = "Workflows";
      // 
      // dcWFId
      // 
      this.dcWFId.AllowDBNull = false;
      this.dcWFId.ColumnName = "Id";
      this.dcWFId.DataType = typeof(System.Guid);
      // 
      // dcWFState
      // 
      this.dcWFState.AllowDBNull = false;
      this.dcWFState.ColumnName = "State";
      // 
      // dcWFName
      // 
      this.dcWFName.AllowDBNull = false;
      this.dcWFName.Caption = "Name";
      this.dcWFName.ColumnName = "WFName";
      // 
      // dcWFPrimaryEntity
      // 
      this.dcWFPrimaryEntity.ColumnName = "PrimaryEntity";
      // 
      // dcWFIsManaged
      // 
      this.dcWFIsManaged.ColumnName = "IsManaged";
      // 
      // dtPluginSteps
      // 
      this.dtPluginSteps.Columns.AddRange(new System.Data.DataColumn[] {
            this.dcPSId,
            this.dcPSState,
            this.dcPSName,
            this.dcPSIsManaged,
            this.dcPSPrimaryEntity});
      this.dtPluginSteps.Constraints.AddRange(new System.Data.Constraint[] {
            new System.Data.UniqueConstraint("Constraint1", new string[] {
                        "Id"}, true)});
      this.dtPluginSteps.PrimaryKey = new System.Data.DataColumn[] {
        this.dcPSId};
      this.dtPluginSteps.TableName = "PluginSteps";
      // 
      // dcPSId
      // 
      this.dcPSId.AllowDBNull = false;
      this.dcPSId.ColumnName = "Id";
      this.dcPSId.DataType = typeof(System.Guid);
      // 
      // dcPSState
      // 
      this.dcPSState.AllowDBNull = false;
      this.dcPSState.ColumnName = "State";
      // 
      // dcPSName
      // 
      this.dcPSName.AllowDBNull = false;
      this.dcPSName.ColumnName = "PSName";
      // 
      // dcPSIsManaged
      // 
      this.dcPSIsManaged.ColumnName = "IsManaged";
      // 
      // dcPSPrimaryEntity
      // 
      this.dcPSPrimaryEntity.Caption = "PrimaryEntity";
      this.dcPSPrimaryEntity.ColumnName = "PrimaryEntity";
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(7, 11);
      this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(72, 17);
      this.label1.TabIndex = 0;
      this.label1.Text = "Workflows";
      // 
      // btnEnableSelectedWorkflows
      // 
      this.btnEnableSelectedWorkflows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEnableSelectedWorkflows.Location = new System.Drawing.Point(425, 5);
      this.btnEnableSelectedWorkflows.Margin = new System.Windows.Forms.Padding(4);
      this.btnEnableSelectedWorkflows.Name = "btnEnableSelectedWorkflows";
      this.btnEnableSelectedWorkflows.Size = new System.Drawing.Size(200, 28);
      this.btnEnableSelectedWorkflows.TabIndex = 4;
      this.btnEnableSelectedWorkflows.Text = "Enable Selected Workflows";
      this.btnEnableSelectedWorkflows.UseVisualStyleBackColor = true;
      this.btnEnableSelectedWorkflows.Click += new System.EventHandler(this.btnEnableSelectedWorkflows_Click);
      // 
      // btnDisableSelectedWorkflows
      // 
      this.btnDisableSelectedWorkflows.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDisableSelectedWorkflows.Location = new System.Drawing.Point(633, 4);
      this.btnDisableSelectedWorkflows.Margin = new System.Windows.Forms.Padding(4);
      this.btnDisableSelectedWorkflows.Name = "btnDisableSelectedWorkflows";
      this.btnDisableSelectedWorkflows.Size = new System.Drawing.Size(200, 28);
      this.btnDisableSelectedWorkflows.TabIndex = 4;
      this.btnDisableSelectedWorkflows.Text = "Disable Selected Workflows";
      this.btnDisableSelectedWorkflows.UseVisualStyleBackColor = true;
      this.btnDisableSelectedWorkflows.Click += new System.EventHandler(this.btnDisableSelectedWorkflows_Click);
      // 
      // dgPluginSteps
      // 
      this.dgPluginSteps.AllowUserToAddRows = false;
      this.dgPluginSteps.AllowUserToDeleteRows = false;
      this.dgPluginSteps.AllowUserToResizeRows = false;
      this.dgPluginSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgPluginSteps.AutoGenerateColumns = false;
      this.dgPluginSteps.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgPluginSteps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgPluginSteps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.PSName,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.idDataGridViewTextBoxColumn1});
      this.dgPluginSteps.DataMember = "PluginSteps";
      this.dgPluginSteps.DataSource = this.dsProcesses;
      this.dgPluginSteps.Location = new System.Drawing.Point(3, 41);
      this.dgPluginSteps.Margin = new System.Windows.Forms.Padding(4);
      this.dgPluginSteps.Name = "dgPluginSteps";
      this.dgPluginSteps.ReadOnly = true;
      this.dgPluginSteps.RowHeadersVisible = false;
      this.dgPluginSteps.RowHeadersWidth = 51;
      this.dgPluginSteps.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgPluginSteps.ShowCellErrors = false;
      this.dgPluginSteps.ShowEditingIcon = false;
      this.dgPluginSteps.ShowRowErrors = false;
      this.dgPluginSteps.Size = new System.Drawing.Size(993, 706);
      this.dgPluginSteps.TabIndex = 2;
      // 
      // dataGridViewTextBoxColumn1
      // 
      this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
      this.dataGridViewTextBoxColumn1.DataPropertyName = "State";
      this.dataGridViewTextBoxColumn1.HeaderText = "State";
      this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
      this.dataGridViewTextBoxColumn1.ReadOnly = true;
      this.dataGridViewTextBoxColumn1.Width = 70;
      // 
      // PSName
      // 
      this.PSName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
      this.PSName.DataPropertyName = "PSName";
      this.PSName.HeaderText = "Name";
      this.PSName.MinimumWidth = 6;
      this.PSName.Name = "PSName";
      this.PSName.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn2
      // 
      this.dataGridViewTextBoxColumn2.DataPropertyName = "PrimaryEntity";
      this.dataGridViewTextBoxColumn2.HeaderText = "PrimaryEntity";
      this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
      this.dataGridViewTextBoxColumn2.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn3
      // 
      this.dataGridViewTextBoxColumn3.DataPropertyName = "IsManaged";
      this.dataGridViewTextBoxColumn3.HeaderText = "IsManaged";
      this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
      this.dataGridViewTextBoxColumn3.ReadOnly = true;
      // 
      // idDataGridViewTextBoxColumn1
      // 
      this.idDataGridViewTextBoxColumn1.DataPropertyName = "Id";
      this.idDataGridViewTextBoxColumn1.HeaderText = "Id";
      this.idDataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.idDataGridViewTextBoxColumn1.Name = "idDataGridViewTextBoxColumn1";
      this.idDataGridViewTextBoxColumn1.ReadOnly = true;
      this.idDataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
      this.idDataGridViewTextBoxColumn1.Visible = false;
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(4, 11);
      this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(119, 17);
      this.label2.TabIndex = 0;
      this.label2.Text = "SDK Plugin Steps";
      // 
      // btnEnableSelectedPluginSteps
      // 
      this.btnEnableSelectedPluginSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnEnableSelectedPluginSteps.Location = new System.Drawing.Point(353, 5);
      this.btnEnableSelectedPluginSteps.Margin = new System.Windows.Forms.Padding(4);
      this.btnEnableSelectedPluginSteps.Name = "btnEnableSelectedPluginSteps";
      this.btnEnableSelectedPluginSteps.Size = new System.Drawing.Size(197, 28);
      this.btnEnableSelectedPluginSteps.TabIndex = 4;
      this.btnEnableSelectedPluginSteps.Text = "Enable Selected Plugin Steps";
      this.btnEnableSelectedPluginSteps.UseVisualStyleBackColor = true;
      this.btnEnableSelectedPluginSteps.Click += new System.EventHandler(this.btnEnableSelectedPluginSteps_Click);
      // 
      // btnDisableSelectPluginSteps
      // 
      this.btnDisableSelectPluginSteps.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.btnDisableSelectPluginSteps.Location = new System.Drawing.Point(557, 4);
      this.btnDisableSelectPluginSteps.Margin = new System.Windows.Forms.Padding(4);
      this.btnDisableSelectPluginSteps.Name = "btnDisableSelectPluginSteps";
      this.btnDisableSelectPluginSteps.Size = new System.Drawing.Size(195, 28);
      this.btnDisableSelectPluginSteps.TabIndex = 4;
      this.btnDisableSelectPluginSteps.Text = "Disable Selected Plugin Steps";
      this.btnDisableSelectPluginSteps.UseVisualStyleBackColor = true;
      this.btnDisableSelectPluginSteps.Click += new System.EventHandler(this.btnDisableSelectPluginSteps_Click);
      // 
      // btnDisableAllProcesses
      // 
      this.btnDisableAllProcesses.Location = new System.Drawing.Point(163, 25);
      this.btnDisableAllProcesses.Margin = new System.Windows.Forms.Padding(4);
      this.btnDisableAllProcesses.Name = "btnDisableAllProcesses";
      this.btnDisableAllProcesses.Size = new System.Drawing.Size(151, 28);
      this.btnDisableAllProcesses.TabIndex = 5;
      this.btnDisableAllProcesses.Text = "Disable All";
      this.btnDisableAllProcesses.UseVisualStyleBackColor = true;
      this.btnDisableAllProcesses.Click += new System.EventHandler(this.btnDisableAllProcesses_Click);
      // 
      // btnRetriveProcesses
      // 
      this.btnRetriveProcesses.Location = new System.Drawing.Point(4, 25);
      this.btnRetriveProcesses.Margin = new System.Windows.Forms.Padding(4);
      this.btnRetriveProcesses.Name = "btnRetriveProcesses";
      this.btnRetriveProcesses.Size = new System.Drawing.Size(151, 28);
      this.btnRetriveProcesses.TabIndex = 5;
      this.btnRetriveProcesses.Text = "Retrieve All";
      this.btnRetriveProcesses.UseVisualStyleBackColor = true;
      this.btnRetriveProcesses.Click += new System.EventHandler(this.btnRetriveProcesses_Click_1);
      // 
      // tpPreDataMigration
      // 
      this.tpPreDataMigration.Controls.Add(this.tcUserManagement);
      this.tpPreDataMigration.Location = new System.Drawing.Point(4, 25);
      this.tpPreDataMigration.Margin = new System.Windows.Forms.Padding(4);
      this.tpPreDataMigration.Name = "tpPreDataMigration";
      this.tpPreDataMigration.Size = new System.Drawing.Size(1700, 901);
      this.tpPreDataMigration.TabIndex = 4;
      this.tpPreDataMigration.Text = "Pre Data Migration";
      this.tpPreDataMigration.UseVisualStyleBackColor = true;
      // 
      // tcUserManagement
      // 
      this.tcUserManagement.Alignment = System.Windows.Forms.TabAlignment.Left;
      this.tcUserManagement.Controls.Add(this.tpBUMapping);
      this.tcUserManagement.Controls.Add(this.tpCurrencyMapping);
      this.tcUserManagement.Controls.Add(this.tpRoleMapping);
      this.tcUserManagement.Controls.Add(this.tpStubUsers);
      this.tcUserManagement.Controls.Add(this.tpUserSecurity);
      this.tcUserManagement.Controls.Add(this.tpTeamMembership);
      this.tcUserManagement.Controls.Add(this.tpTeamSecurity);
      this.tcUserManagement.Controls.Add(this.tpUOMSync);
      this.tcUserManagement.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcUserManagement.Location = new System.Drawing.Point(0, 0);
      this.tcUserManagement.Margin = new System.Windows.Forms.Padding(4);
      this.tcUserManagement.Multiline = true;
      this.tcUserManagement.Name = "tcUserManagement";
      this.tcUserManagement.SelectedIndex = 0;
      this.tcUserManagement.Size = new System.Drawing.Size(1700, 901);
      this.tcUserManagement.TabIndex = 6;
      // 
      // tpBUMapping
      // 
      this.tpBUMapping.Controls.Add(this.dgBUMapping);
      this.tpBUMapping.Controls.Add(this.btnLoadBUMapping);
      this.tpBUMapping.Controls.Add(this.btnSaveBUMapping);
      this.tpBUMapping.Controls.Add(this.btnMapBU);
      this.tpBUMapping.Location = new System.Drawing.Point(25, 4);
      this.tpBUMapping.Margin = new System.Windows.Forms.Padding(4);
      this.tpBUMapping.Name = "tpBUMapping";
      this.tpBUMapping.Padding = new System.Windows.Forms.Padding(4);
      this.tpBUMapping.Size = new System.Drawing.Size(1671, 893);
      this.tpBUMapping.TabIndex = 3;
      this.tpBUMapping.Text = "BU Mapping";
      this.tpBUMapping.UseVisualStyleBackColor = true;
      // 
      // dgBUMapping
      // 
      this.dgBUMapping.AllowUserToAddRows = false;
      this.dgBUMapping.AllowUserToDeleteRows = false;
      this.dgBUMapping.AllowUserToOrderColumns = true;
      this.dgBUMapping.AllowUserToResizeRows = false;
      this.dgBUMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgBUMapping.AutoGenerateColumns = false;
      this.dgBUMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgBUMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgBUMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sourcebuidDataGridViewTextBoxColumn,
            this.sourcebunameDataGridViewTextBoxColumn,
            this.target_buid,
            this.targetbunameDataGridViewTextBoxColumn});
      this.dgBUMapping.DataMember = "dtBusinessUnitMapping";
      this.dgBUMapping.DataSource = this.dsFSMigrationBindingSource;
      this.dgBUMapping.Location = new System.Drawing.Point(9, 46);
      this.dgBUMapping.Margin = new System.Windows.Forms.Padding(4);
      this.dgBUMapping.Name = "dgBUMapping";
      this.dgBUMapping.RowHeadersWidth = 51;
      this.dgBUMapping.Size = new System.Drawing.Size(1588, 838);
      this.dgBUMapping.TabIndex = 3;
      // 
      // sourcebuidDataGridViewTextBoxColumn
      // 
      this.sourcebuidDataGridViewTextBoxColumn.DataPropertyName = "source_buid";
      this.sourcebuidDataGridViewTextBoxColumn.HeaderText = "Source BU ID";
      this.sourcebuidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcebuidDataGridViewTextBoxColumn.Name = "sourcebuidDataGridViewTextBoxColumn";
      this.sourcebuidDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // sourcebunameDataGridViewTextBoxColumn
      // 
      this.sourcebunameDataGridViewTextBoxColumn.DataPropertyName = "source_buname";
      this.sourcebunameDataGridViewTextBoxColumn.HeaderText = "Source BU Name";
      this.sourcebunameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcebunameDataGridViewTextBoxColumn.Name = "sourcebunameDataGridViewTextBoxColumn";
      this.sourcebunameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // target_buid
      // 
      this.target_buid.DataPropertyName = "target_buid";
      this.target_buid.HeaderText = "Target BU ID";
      this.target_buid.MinimumWidth = 6;
      this.target_buid.Name = "target_buid";
      // 
      // targetbunameDataGridViewTextBoxColumn
      // 
      this.targetbunameDataGridViewTextBoxColumn.DataPropertyName = "target_buname";
      this.targetbunameDataGridViewTextBoxColumn.HeaderText = "Target BU Name";
      this.targetbunameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetbunameDataGridViewTextBoxColumn.Name = "targetbunameDataGridViewTextBoxColumn";
      // 
      // dsFSMigrationBindingSource
      // 
      this.dsFSMigrationBindingSource.DataSource = this.dsFSMigration;
      this.dsFSMigrationBindingSource.Position = 0;
      this.dsFSMigrationBindingSource.Sort = "";
      // 
      // dsFSMigration
      // 
      this.dsFSMigration.DataSetName = "dsFSMigration";
      this.dsFSMigration.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
      // 
      // btnLoadBUMapping
      // 
      this.btnLoadBUMapping.Location = new System.Drawing.Point(228, 9);
      this.btnLoadBUMapping.Margin = new System.Windows.Forms.Padding(4);
      this.btnLoadBUMapping.Name = "btnLoadBUMapping";
      this.btnLoadBUMapping.Size = new System.Drawing.Size(100, 28);
      this.btnLoadBUMapping.TabIndex = 2;
      this.btnLoadBUMapping.Text = "Load";
      this.btnLoadBUMapping.UseVisualStyleBackColor = true;
      this.btnLoadBUMapping.Click += new System.EventHandler(this.btnLoadBUMapping_Click);
      // 
      // btnSaveBUMapping
      // 
      this.btnSaveBUMapping.Location = new System.Drawing.Point(119, 9);
      this.btnSaveBUMapping.Margin = new System.Windows.Forms.Padding(4);
      this.btnSaveBUMapping.Name = "btnSaveBUMapping";
      this.btnSaveBUMapping.Size = new System.Drawing.Size(100, 28);
      this.btnSaveBUMapping.TabIndex = 1;
      this.btnSaveBUMapping.Text = "Save";
      this.btnSaveBUMapping.UseVisualStyleBackColor = true;
      this.btnSaveBUMapping.Click += new System.EventHandler(this.btnSaveBUMapping_Click);
      // 
      // btnMapBU
      // 
      this.btnMapBU.Location = new System.Drawing.Point(9, 9);
      this.btnMapBU.Margin = new System.Windows.Forms.Padding(4);
      this.btnMapBU.Name = "btnMapBU";
      this.btnMapBU.Size = new System.Drawing.Size(100, 28);
      this.btnMapBU.TabIndex = 0;
      this.btnMapBU.Text = "Map BU";
      this.btnMapBU.UseVisualStyleBackColor = true;
      this.btnMapBU.Click += new System.EventHandler(this.btnMapBU_Click);
      // 
      // tpCurrencyMapping
      // 
      this.tpCurrencyMapping.Controls.Add(this.dgCurrenyMapping);
      this.tpCurrencyMapping.Controls.Add(this.btnLoadCurrencyMapping);
      this.tpCurrencyMapping.Controls.Add(this.btnSaveCurrencyMapping);
      this.tpCurrencyMapping.Controls.Add(this.btnCurrencyMapping);
      this.tpCurrencyMapping.Location = new System.Drawing.Point(25, 4);
      this.tpCurrencyMapping.Margin = new System.Windows.Forms.Padding(4);
      this.tpCurrencyMapping.Name = "tpCurrencyMapping";
      this.tpCurrencyMapping.Size = new System.Drawing.Size(1671, 893);
      this.tpCurrencyMapping.TabIndex = 4;
      this.tpCurrencyMapping.Text = "Curreny Mapping";
      this.tpCurrencyMapping.UseVisualStyleBackColor = true;
      // 
      // dgCurrenyMapping
      // 
      this.dgCurrenyMapping.AllowUserToAddRows = false;
      this.dgCurrenyMapping.AllowUserToDeleteRows = false;
      this.dgCurrenyMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgCurrenyMapping.AutoGenerateColumns = false;
      this.dgCurrenyMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgCurrenyMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgCurrenyMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sourcetransactioncurrencyidDataGridViewTextBoxColumn,
            this.sourceisocurrencycodeDataGridViewTextBoxColumn,
            this.sourcecurrencysymbolDataGridViewTextBoxColumn,
            this.targettransactioncurrencyidDataGridViewTextBoxColumn,
            this.targetisocurrencycodeDataGridViewTextBoxColumn,
            this.targetcurrencynameDataGridViewTextBoxColumn,
            this.targetcurrencysymbolDataGridViewTextBoxColumn});
      this.dgCurrenyMapping.DataMember = "dtCurrencyMapping";
      this.dgCurrenyMapping.DataSource = this.dsFSMigrationBindingSource;
      this.dgCurrenyMapping.Location = new System.Drawing.Point(17, 50);
      this.dgCurrenyMapping.Margin = new System.Windows.Forms.Padding(4);
      this.dgCurrenyMapping.Name = "dgCurrenyMapping";
      this.dgCurrenyMapping.RowHeadersWidth = 51;
      this.dgCurrenyMapping.Size = new System.Drawing.Size(1568, 825);
      this.dgCurrenyMapping.TabIndex = 3;
      // 
      // sourcetransactioncurrencyidDataGridViewTextBoxColumn
      // 
      this.sourcetransactioncurrencyidDataGridViewTextBoxColumn.DataPropertyName = "source_transactioncurrencyid";
      this.sourcetransactioncurrencyidDataGridViewTextBoxColumn.HeaderText = "source_transactioncurrencyid";
      this.sourcetransactioncurrencyidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcetransactioncurrencyidDataGridViewTextBoxColumn.Name = "sourcetransactioncurrencyidDataGridViewTextBoxColumn";
      // 
      // sourceisocurrencycodeDataGridViewTextBoxColumn
      // 
      this.sourceisocurrencycodeDataGridViewTextBoxColumn.DataPropertyName = "source_isocurrencycode";
      this.sourceisocurrencycodeDataGridViewTextBoxColumn.HeaderText = "source_isocurrencycode";
      this.sourceisocurrencycodeDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourceisocurrencycodeDataGridViewTextBoxColumn.Name = "sourceisocurrencycodeDataGridViewTextBoxColumn";
      // 
      // sourcecurrencysymbolDataGridViewTextBoxColumn
      // 
      this.sourcecurrencysymbolDataGridViewTextBoxColumn.DataPropertyName = "source_currencysymbol";
      this.sourcecurrencysymbolDataGridViewTextBoxColumn.HeaderText = "source_currencysymbol";
      this.sourcecurrencysymbolDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcecurrencysymbolDataGridViewTextBoxColumn.Name = "sourcecurrencysymbolDataGridViewTextBoxColumn";
      // 
      // targettransactioncurrencyidDataGridViewTextBoxColumn
      // 
      this.targettransactioncurrencyidDataGridViewTextBoxColumn.DataPropertyName = "target_transactioncurrencyid";
      this.targettransactioncurrencyidDataGridViewTextBoxColumn.HeaderText = "target_transactioncurrencyid";
      this.targettransactioncurrencyidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targettransactioncurrencyidDataGridViewTextBoxColumn.Name = "targettransactioncurrencyidDataGridViewTextBoxColumn";
      // 
      // targetisocurrencycodeDataGridViewTextBoxColumn
      // 
      this.targetisocurrencycodeDataGridViewTextBoxColumn.DataPropertyName = "target_isocurrencycode";
      this.targetisocurrencycodeDataGridViewTextBoxColumn.HeaderText = "target_isocurrencycode";
      this.targetisocurrencycodeDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetisocurrencycodeDataGridViewTextBoxColumn.Name = "targetisocurrencycodeDataGridViewTextBoxColumn";
      // 
      // targetcurrencynameDataGridViewTextBoxColumn
      // 
      this.targetcurrencynameDataGridViewTextBoxColumn.DataPropertyName = "target_currencyname";
      this.targetcurrencynameDataGridViewTextBoxColumn.HeaderText = "target_currencyname";
      this.targetcurrencynameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetcurrencynameDataGridViewTextBoxColumn.Name = "targetcurrencynameDataGridViewTextBoxColumn";
      // 
      // targetcurrencysymbolDataGridViewTextBoxColumn
      // 
      this.targetcurrencysymbolDataGridViewTextBoxColumn.DataPropertyName = "target_currencysymbol";
      this.targetcurrencysymbolDataGridViewTextBoxColumn.HeaderText = "target_currencysymbol";
      this.targetcurrencysymbolDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetcurrencysymbolDataGridViewTextBoxColumn.Name = "targetcurrencysymbolDataGridViewTextBoxColumn";
      // 
      // btnLoadCurrencyMapping
      // 
      this.btnLoadCurrencyMapping.Location = new System.Drawing.Point(267, 12);
      this.btnLoadCurrencyMapping.Margin = new System.Windows.Forms.Padding(4);
      this.btnLoadCurrencyMapping.Name = "btnLoadCurrencyMapping";
      this.btnLoadCurrencyMapping.Size = new System.Drawing.Size(100, 28);
      this.btnLoadCurrencyMapping.TabIndex = 2;
      this.btnLoadCurrencyMapping.Text = "Load";
      this.btnLoadCurrencyMapping.UseVisualStyleBackColor = true;
      this.btnLoadCurrencyMapping.Click += new System.EventHandler(this.btnLoadCurrencyMapping_Click);
      // 
      // btnSaveCurrencyMapping
      // 
      this.btnSaveCurrencyMapping.Location = new System.Drawing.Point(151, 14);
      this.btnSaveCurrencyMapping.Margin = new System.Windows.Forms.Padding(4);
      this.btnSaveCurrencyMapping.Name = "btnSaveCurrencyMapping";
      this.btnSaveCurrencyMapping.Size = new System.Drawing.Size(104, 28);
      this.btnSaveCurrencyMapping.TabIndex = 1;
      this.btnSaveCurrencyMapping.Text = "Save";
      this.btnSaveCurrencyMapping.UseVisualStyleBackColor = true;
      this.btnSaveCurrencyMapping.Click += new System.EventHandler(this.btnSaveCurrencyMapping_Click);
      // 
      // btnCurrencyMapping
      // 
      this.btnCurrencyMapping.Location = new System.Drawing.Point(17, 14);
      this.btnCurrencyMapping.Margin = new System.Windows.Forms.Padding(4);
      this.btnCurrencyMapping.Name = "btnCurrencyMapping";
      this.btnCurrencyMapping.Size = new System.Drawing.Size(124, 28);
      this.btnCurrencyMapping.TabIndex = 0;
      this.btnCurrencyMapping.Text = "Map Currency";
      this.btnCurrencyMapping.UseVisualStyleBackColor = true;
      this.btnCurrencyMapping.Click += new System.EventHandler(this.btnCurrencyMapping_Click);
      // 
      // tpRoleMapping
      // 
      this.tpRoleMapping.Controls.Add(this.dgRoleMapping);
      this.tpRoleMapping.Controls.Add(this.btnSaveRoleMappings);
      this.tpRoleMapping.Controls.Add(this.btnLoadRoleMappings);
      this.tpRoleMapping.Controls.Add(this.btnMapRoles);
      this.tpRoleMapping.Location = new System.Drawing.Point(25, 4);
      this.tpRoleMapping.Margin = new System.Windows.Forms.Padding(4);
      this.tpRoleMapping.Name = "tpRoleMapping";
      this.tpRoleMapping.Padding = new System.Windows.Forms.Padding(4);
      this.tpRoleMapping.Size = new System.Drawing.Size(1671, 893);
      this.tpRoleMapping.TabIndex = 2;
      this.tpRoleMapping.Text = "Role Mapping";
      this.tpRoleMapping.UseVisualStyleBackColor = true;
      // 
      // dgRoleMapping
      // 
      this.dgRoleMapping.AllowUserToAddRows = false;
      this.dgRoleMapping.AllowUserToDeleteRows = false;
      this.dgRoleMapping.AllowUserToResizeRows = false;
      this.dgRoleMapping.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgRoleMapping.AutoGenerateColumns = false;
      this.dgRoleMapping.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgRoleMapping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgRoleMapping.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.source_businessunitname,
            this.sourceroleidDataGridViewTextBoxColumn,
            this.sourcerolenameDataGridViewTextBoxColumn,
            this.source_parentrootroleid,
            this.target_businessunitname,
            this.targetroleidDataGridViewTextBoxColumn,
            this.targetrolenameDataGridViewTextBoxColumn});
      this.dgRoleMapping.DataSource = this.dtSecurityRoleMappingBindingSource;
      this.dgRoleMapping.Location = new System.Drawing.Point(20, 44);
      this.dgRoleMapping.Margin = new System.Windows.Forms.Padding(4);
      this.dgRoleMapping.Name = "dgRoleMapping";
      this.dgRoleMapping.RowHeadersWidth = 51;
      this.dgRoleMapping.Size = new System.Drawing.Size(1576, 840);
      this.dgRoleMapping.TabIndex = 3;
      this.dgRoleMapping.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgRoleMapping_DataError);
      // 
      // source_businessunitname
      // 
      this.source_businessunitname.DataPropertyName = "source_businessunitname";
      this.source_businessunitname.HeaderText = "source BU";
      this.source_businessunitname.MinimumWidth = 6;
      this.source_businessunitname.Name = "source_businessunitname";
      this.source_businessunitname.ReadOnly = true;
      // 
      // sourceroleidDataGridViewTextBoxColumn
      // 
      this.sourceroleidDataGridViewTextBoxColumn.DataPropertyName = "source_roleid";
      this.sourceroleidDataGridViewTextBoxColumn.HeaderText = "source_roleid";
      this.sourceroleidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourceroleidDataGridViewTextBoxColumn.Name = "sourceroleidDataGridViewTextBoxColumn";
      this.sourceroleidDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // sourcerolenameDataGridViewTextBoxColumn
      // 
      this.sourcerolenameDataGridViewTextBoxColumn.DataPropertyName = "source_rolename";
      this.sourcerolenameDataGridViewTextBoxColumn.HeaderText = "source_rolename";
      this.sourcerolenameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcerolenameDataGridViewTextBoxColumn.Name = "sourcerolenameDataGridViewTextBoxColumn";
      // 
      // source_parentrootroleid
      // 
      this.source_parentrootroleid.DataPropertyName = "source_parentrootroleid";
      this.source_parentrootroleid.HeaderText = "source_parentrootroleid";
      this.source_parentrootroleid.MinimumWidth = 6;
      this.source_parentrootroleid.Name = "source_parentrootroleid";
      this.source_parentrootroleid.ReadOnly = true;
      this.source_parentrootroleid.Visible = false;
      // 
      // target_businessunitname
      // 
      this.target_businessunitname.DataPropertyName = "target_businessunitname";
      this.target_businessunitname.HeaderText = "target BU";
      this.target_businessunitname.MinimumWidth = 6;
      this.target_businessunitname.Name = "target_businessunitname";
      this.target_businessunitname.ReadOnly = true;
      // 
      // targetroleidDataGridViewTextBoxColumn
      // 
      this.targetroleidDataGridViewTextBoxColumn.DataPropertyName = "target_roleid";
      this.targetroleidDataGridViewTextBoxColumn.HeaderText = "target_roleid";
      this.targetroleidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetroleidDataGridViewTextBoxColumn.Name = "targetroleidDataGridViewTextBoxColumn";
      // 
      // targetrolenameDataGridViewTextBoxColumn
      // 
      this.targetrolenameDataGridViewTextBoxColumn.DataPropertyName = "target_rolename";
      this.targetrolenameDataGridViewTextBoxColumn.HeaderText = "target_rolename";
      this.targetrolenameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetrolenameDataGridViewTextBoxColumn.Name = "targetrolenameDataGridViewTextBoxColumn";
      // 
      // dtSecurityRoleMappingBindingSource
      // 
      this.dtSecurityRoleMappingBindingSource.DataMember = "dtSecurityRoleMapping";
      this.dtSecurityRoleMappingBindingSource.DataSource = this.dsFSMigrationBindingSource;
      // 
      // btnSaveRoleMappings
      // 
      this.btnSaveRoleMappings.Location = new System.Drawing.Point(128, 7);
      this.btnSaveRoleMappings.Margin = new System.Windows.Forms.Padding(4);
      this.btnSaveRoleMappings.Name = "btnSaveRoleMappings";
      this.btnSaveRoleMappings.Size = new System.Drawing.Size(161, 28);
      this.btnSaveRoleMappings.TabIndex = 2;
      this.btnSaveRoleMappings.Text = "Save Mappings";
      this.btnSaveRoleMappings.UseVisualStyleBackColor = true;
      this.btnSaveRoleMappings.Click += new System.EventHandler(this.btnSaveRoleMappings_Click);
      // 
      // btnLoadRoleMappings
      // 
      this.btnLoadRoleMappings.Location = new System.Drawing.Point(297, 9);
      this.btnLoadRoleMappings.Margin = new System.Windows.Forms.Padding(4);
      this.btnLoadRoleMappings.Name = "btnLoadRoleMappings";
      this.btnLoadRoleMappings.Size = new System.Drawing.Size(128, 28);
      this.btnLoadRoleMappings.TabIndex = 1;
      this.btnLoadRoleMappings.Text = "Load Mappings";
      this.btnLoadRoleMappings.UseVisualStyleBackColor = true;
      this.btnLoadRoleMappings.Click += new System.EventHandler(this.btnLoadRoleMappings_Click);
      // 
      // btnMapRoles
      // 
      this.btnMapRoles.Location = new System.Drawing.Point(20, 7);
      this.btnMapRoles.Margin = new System.Windows.Forms.Padding(4);
      this.btnMapRoles.Name = "btnMapRoles";
      this.btnMapRoles.Size = new System.Drawing.Size(100, 28);
      this.btnMapRoles.TabIndex = 0;
      this.btnMapRoles.Text = "Map Roles";
      this.btnMapRoles.UseVisualStyleBackColor = true;
      this.btnMapRoles.Click += new System.EventHandler(this.btnMapRoles_Click);
      // 
      // tpStubUsers
      // 
      this.tpStubUsers.Controls.Add(this.btnAddSPRole);
      this.tpStubUsers.Controls.Add(this.cbStubUsersHideUnlicensed);
      this.tpStubUsers.Controls.Add(this.cbHideWithSPRole);
      this.tpStubUsers.Controls.Add(this.cbCreate_z_StubUser);
      this.tpStubUsers.Controls.Add(this.cbUserSnycSettings);
      this.tpStubUsers.Controls.Add(this.cbUserSnycUserInfo);
      this.tpStubUsers.Controls.Add(this.cbStubUsersHideMatchingBU);
      this.tpStubUsers.Controls.Add(this.cbStubUsersHideDisabled);
      this.tpStubUsers.Controls.Add(this.cbSyncSettings);
      this.tpStubUsers.Controls.Add(this.cbUserSnycBusinessUnit);
      this.tpStubUsers.Controls.Add(this.btnSyncUserSettings);
      this.tpStubUsers.Controls.Add(this.dgSystemUsers);
      this.tpStubUsers.Controls.Add(this.cbHideInTarget);
      this.tpStubUsers.Controls.Add(this.btnLoadSourceUsers);
      this.tpStubUsers.Controls.Add(this.lblUsersTotalInfo);
      this.tpStubUsers.Controls.Add(this.cbAddStubUsersCheckUncheck);
      this.tpStubUsers.Controls.Add(this.btnCreateStubUsers);
      this.tpStubUsers.Location = new System.Drawing.Point(25, 4);
      this.tpStubUsers.Margin = new System.Windows.Forms.Padding(4);
      this.tpStubUsers.Name = "tpStubUsers";
      this.tpStubUsers.Padding = new System.Windows.Forms.Padding(4);
      this.tpStubUsers.Size = new System.Drawing.Size(1671, 893);
      this.tpStubUsers.TabIndex = 0;
      this.tpStubUsers.Text = "User Mapping";
      this.tpStubUsers.UseVisualStyleBackColor = true;
      // 
      // cbStubUsersHideUnlicensed
      // 
      this.cbStubUsersHideUnlicensed.AutoSize = true;
      this.cbStubUsersHideUnlicensed.Location = new System.Drawing.Point(575, 43);
      this.cbStubUsersHideUnlicensed.Margin = new System.Windows.Forms.Padding(4);
      this.cbStubUsersHideUnlicensed.Name = "cbStubUsersHideUnlicensed";
      this.cbStubUsersHideUnlicensed.Size = new System.Drawing.Size(142, 21);
      this.cbStubUsersHideUnlicensed.TabIndex = 16;
      this.cbStubUsersHideUnlicensed.Text = "Hide Un Licensed";
      this.cbStubUsersHideUnlicensed.UseVisualStyleBackColor = true;
      // 
      // cbHideWithSPRole
      // 
      this.cbHideWithSPRole.AutoSize = true;
      this.cbHideWithSPRole.Location = new System.Drawing.Point(288, 43);
      this.cbHideWithSPRole.Margin = new System.Windows.Forms.Padding(4);
      this.cbHideWithSPRole.Name = "cbHideWithSPRole";
      this.cbHideWithSPRole.Size = new System.Drawing.Size(138, 21);
      this.cbHideWithSPRole.TabIndex = 15;
      this.cbHideWithSPRole.Text = "Hide w/ SP Roles";
      this.cbHideWithSPRole.UseVisualStyleBackColor = true;
      // 
      // cbCreate_z_StubUser
      // 
      this.cbCreate_z_StubUser.AutoSize = true;
      this.cbCreate_z_StubUser.Location = new System.Drawing.Point(732, 36);
      this.cbCreate_z_StubUser.Margin = new System.Windows.Forms.Padding(4);
      this.cbCreate_z_StubUser.Name = "cbCreate_z_StubUser";
      this.cbCreate_z_StubUser.Size = new System.Drawing.Size(233, 21);
      this.cbCreate_z_StubUser.TabIndex = 14;
      this.cbCreate_z_StubUser.Text = "Create z_Stub: Check/Un-Check";
      this.cbCreate_z_StubUser.UseVisualStyleBackColor = true;
      // 
      // cbUserSnycSettings
      // 
      this.cbUserSnycSettings.AutoSize = true;
      this.cbUserSnycSettings.Location = new System.Drawing.Point(1212, 36);
      this.cbUserSnycSettings.Margin = new System.Windows.Forms.Padding(4);
      this.cbUserSnycSettings.Name = "cbUserSnycSettings";
      this.cbUserSnycSettings.Size = new System.Drawing.Size(150, 21);
      this.cbUserSnycSettings.TabIndex = 13;
      this.cbUserSnycSettings.Text = "Sync User Settings";
      this.cbUserSnycSettings.UseVisualStyleBackColor = true;
      // 
      // cbUserSnycUserInfo
      // 
      this.cbUserSnycUserInfo.AutoSize = true;
      this.cbUserSnycUserInfo.Location = new System.Drawing.Point(1076, 34);
      this.cbUserSnycUserInfo.Margin = new System.Windows.Forms.Padding(4);
      this.cbUserSnycUserInfo.Name = "cbUserSnycUserInfo";
      this.cbUserSnycUserInfo.Size = new System.Drawing.Size(122, 21);
      this.cbUserSnycUserInfo.TabIndex = 12;
      this.cbUserSnycUserInfo.Text = "Sync User Info";
      this.cbUserSnycUserInfo.UseVisualStyleBackColor = true;
      this.cbUserSnycUserInfo.CheckedChanged += new System.EventHandler(this.cbUserSnycUserInfo_CheckedChanged);
      // 
      // cbStubUsersHideMatchingBU
      // 
      this.cbStubUsersHideMatchingBU.AutoSize = true;
      this.cbStubUsersHideMatchingBU.Location = new System.Drawing.Point(129, 43);
      this.cbStubUsersHideMatchingBU.Margin = new System.Windows.Forms.Padding(4);
      this.cbStubUsersHideMatchingBU.Name = "cbStubUsersHideMatchingBU";
      this.cbStubUsersHideMatchingBU.Size = new System.Drawing.Size(143, 21);
      this.cbStubUsersHideMatchingBU.TabIndex = 10;
      this.cbStubUsersHideMatchingBU.Text = "Hide Matching BU";
      this.cbStubUsersHideMatchingBU.UseVisualStyleBackColor = true;
      this.cbStubUsersHideMatchingBU.CheckedChanged += new System.EventHandler(this.cbStubUsersHideMatchingBU_CheckedChanged);
      // 
      // cbStubUsersHideDisabled
      // 
      this.cbStubUsersHideDisabled.AutoSize = true;
      this.cbStubUsersHideDisabled.Location = new System.Drawing.Point(444, 43);
      this.cbStubUsersHideDisabled.Margin = new System.Windows.Forms.Padding(4);
      this.cbStubUsersHideDisabled.Name = "cbStubUsersHideDisabled";
      this.cbStubUsersHideDisabled.Size = new System.Drawing.Size(118, 21);
      this.cbStubUsersHideDisabled.TabIndex = 9;
      this.cbStubUsersHideDisabled.Text = "Hide Disabled";
      this.cbStubUsersHideDisabled.UseVisualStyleBackColor = true;
      this.cbStubUsersHideDisabled.CheckedChanged += new System.EventHandler(this.cbStubUsersHideDisabled_CheckedChanged);
      // 
      // cbSyncSettings
      // 
      this.cbSyncSettings.AutoSize = true;
      this.cbSyncSettings.Location = new System.Drawing.Point(977, 10);
      this.cbSyncSettings.Margin = new System.Windows.Forms.Padding(4);
      this.cbSyncSettings.Name = "cbSyncSettings";
      this.cbSyncSettings.Size = new System.Drawing.Size(204, 21);
      this.cbSyncSettings.TabIndex = 8;
      this.cbSyncSettings.Text = "Sync User Check/Un-Check";
      this.cbSyncSettings.UseVisualStyleBackColor = true;
      this.cbSyncSettings.CheckedChanged += new System.EventHandler(this.cbSyncSettings_CheckedChanged);
      // 
      // cbUserSnycBusinessUnit
      // 
      this.cbUserSnycBusinessUnit.AutoSize = true;
      this.cbUserSnycBusinessUnit.Location = new System.Drawing.Point(977, 34);
      this.cbUserSnycBusinessUnit.Margin = new System.Windows.Forms.Padding(4);
      this.cbUserSnycBusinessUnit.Name = "cbUserSnycBusinessUnit";
      this.cbUserSnycBusinessUnit.Size = new System.Drawing.Size(84, 21);
      this.cbUserSnycBusinessUnit.TabIndex = 7;
      this.cbUserSnycBusinessUnit.Text = "Sync BU";
      this.cbUserSnycBusinessUnit.UseVisualStyleBackColor = true;
      // 
      // btnSyncUserSettings
      // 
      this.btnSyncUserSettings.Location = new System.Drawing.Point(393, 7);
      this.btnSyncUserSettings.Margin = new System.Windows.Forms.Padding(4);
      this.btnSyncUserSettings.Name = "btnSyncUserSettings";
      this.btnSyncUserSettings.Size = new System.Drawing.Size(148, 28);
      this.btnSyncUserSettings.TabIndex = 6;
      this.btnSyncUserSettings.Text = "Sync User Settings";
      this.btnSyncUserSettings.UseVisualStyleBackColor = true;
      this.btnSyncUserSettings.Click += new System.EventHandler(this.btnSyncUserSettings_Click);
      // 
      // dgSystemUsers
      // 
      this.dgSystemUsers.AllowUserToAddRows = false;
      this.dgSystemUsers.AllowUserToDeleteRows = false;
      this.dgSystemUsers.AllowUserToResizeColumns = false;
      this.dgSystemUsers.AllowUserToResizeRows = false;
      dataGridViewCellStyle7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgSystemUsers.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle7;
      this.dgSystemUsers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgSystemUsers.AutoGenerateColumns = false;
      this.dgSystemUsers.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgSystemUsers.ColumnHeadersHeight = 29;
      this.dgSystemUsers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IsInTarget,
            this.target_bumatch,
            this.MissingSPRole,
            this.AddZ_StubToTarget,
            this.AddStubToTarget,
            this.SyncSettings,
            this.dataGridViewCheckBoxColumn3,
            this.source_islicensed,
            this.dataGridViewTextBoxColumn5,
            this.sourcedomainDataGridViewTextBoxColumn,
            this.source_identitiyid,
            this.fullname,
            this.source_parentsystemusername,
            this.source_territoryname,
            this.source_transactioncurrencyname,
            this.dataGridViewCheckBoxColumn4,
            this.target_islicensed,
            this.dataGridViewTextBoxColumn6,
            this.target_DomainName,
            this.target_identityid,
            this.target_FullName,
            this.target_parentsystemusername,
            this.target_territoryname,
            this.target_transactioncurrencyname});
      this.dgSystemUsers.DataMember = "dtUsers";
      this.dgSystemUsers.DataSource = this.dsFSMigrationBindingSource;
      this.dgSystemUsers.Location = new System.Drawing.Point(8, 71);
      this.dgSystemUsers.Margin = new System.Windows.Forms.Padding(4);
      this.dgSystemUsers.MultiSelect = false;
      this.dgSystemUsers.Name = "dgSystemUsers";
      this.dgSystemUsers.RowHeadersWidth = 51;
      this.dgSystemUsers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgSystemUsers.Size = new System.Drawing.Size(1588, 812);
      this.dgSystemUsers.TabIndex = 0;
      this.dgSystemUsers.VirtualMode = true;
      this.dgSystemUsers.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSourceUsers_CellValueChanged);
      this.dgSystemUsers.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgSystemUsers_DataError);
      // 
      // IsInTarget
      // 
      this.IsInTarget.DataPropertyName = "IsInTarget";
      this.IsInTarget.HeaderText = "In Target";
      this.IsInTarget.MinimumWidth = 6;
      this.IsInTarget.Name = "IsInTarget";
      this.IsInTarget.ReadOnly = true;
      this.IsInTarget.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.IsInTarget.Width = 94;
      // 
      // target_bumatch
      // 
      this.target_bumatch.DataPropertyName = "target_bumatch";
      this.target_bumatch.HeaderText = "BU Match";
      this.target_bumatch.MinimumWidth = 6;
      this.target_bumatch.Name = "target_bumatch";
      this.target_bumatch.ReadOnly = true;
      this.target_bumatch.Width = 75;
      // 
      // MissingSPRole
      // 
      this.MissingSPRole.DataPropertyName = "MissingSPRole";
      this.MissingSPRole.HeaderText = "Missing SP Role";
      this.MissingSPRole.MinimumWidth = 6;
      this.MissingSPRole.Name = "MissingSPRole";
      this.MissingSPRole.ReadOnly = true;
      this.MissingSPRole.Width = 116;
      // 
      // AddZ_StubToTarget
      // 
      this.AddZ_StubToTarget.DataPropertyName = "AddZ_StubToTarget";
      this.AddZ_StubToTarget.HeaderText = "Add Target z_Stub";
      this.AddZ_StubToTarget.MinimumWidth = 6;
      this.AddZ_StubToTarget.Name = "AddZ_StubToTarget";
      this.AddZ_StubToTarget.Width = 133;
      // 
      // AddStubToTarget
      // 
      this.AddStubToTarget.DataPropertyName = "AddStubToTarget";
      this.AddStubToTarget.HeaderText = "Add Target Stub";
      this.AddStubToTarget.MinimumWidth = 6;
      this.AddStubToTarget.Name = "AddStubToTarget";
      this.AddStubToTarget.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.AddStubToTarget.Width = 141;
      // 
      // SyncSettings
      // 
      this.SyncSettings.DataPropertyName = "SyncSettings";
      this.SyncSettings.HeaderText = "Sync User";
      this.SyncSettings.MinimumWidth = 6;
      this.SyncSettings.Name = "SyncSettings";
      this.SyncSettings.Width = 79;
      // 
      // dataGridViewCheckBoxColumn3
      // 
      this.dataGridViewCheckBoxColumn3.DataPropertyName = "source_IsDisabled";
      this.dataGridViewCheckBoxColumn3.HeaderText = "source_IsDisabled";
      this.dataGridViewCheckBoxColumn3.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn3.Name = "dataGridViewCheckBoxColumn3";
      this.dataGridViewCheckBoxColumn3.ReadOnly = true;
      this.dataGridViewCheckBoxColumn3.Width = 130;
      // 
      // source_islicensed
      // 
      this.source_islicensed.DataPropertyName = "source_islicensed";
      this.source_islicensed.HeaderText = "source_IsLicensed";
      this.source_islicensed.MinimumWidth = 6;
      this.source_islicensed.Name = "source_islicensed";
      this.source_islicensed.ReadOnly = true;
      this.source_islicensed.Width = 132;
      // 
      // dataGridViewTextBoxColumn5
      // 
      this.dataGridViewTextBoxColumn5.DataPropertyName = "source_BUName";
      this.dataGridViewTextBoxColumn5.HeaderText = "source_BU";
      this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
      this.dataGridViewTextBoxColumn5.ReadOnly = true;
      this.dataGridViewTextBoxColumn5.Width = 107;
      // 
      // sourcedomainDataGridViewTextBoxColumn
      // 
      this.sourcedomainDataGridViewTextBoxColumn.DataPropertyName = "source_domain";
      this.sourcedomainDataGridViewTextBoxColumn.HeaderText = "Source - Domain";
      this.sourcedomainDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcedomainDataGridViewTextBoxColumn.Name = "sourcedomainDataGridViewTextBoxColumn";
      this.sourcedomainDataGridViewTextBoxColumn.ReadOnly = true;
      this.sourcedomainDataGridViewTextBoxColumn.Width = 143;
      // 
      // source_identitiyid
      // 
      this.source_identitiyid.DataPropertyName = "source_identitiyid";
      this.source_identitiyid.HeaderText = "Source - Identitiyid";
      this.source_identitiyid.MinimumWidth = 6;
      this.source_identitiyid.Name = "source_identitiyid";
      this.source_identitiyid.ReadOnly = true;
      this.source_identitiyid.Width = 154;
      // 
      // fullname
      // 
      this.fullname.DataPropertyName = "source_fullname";
      this.fullname.HeaderText = "Source - Full Name";
      this.fullname.MinimumWidth = 6;
      this.fullname.Name = "fullname";
      this.fullname.ReadOnly = true;
      this.fullname.Width = 158;
      // 
      // source_parentsystemusername
      // 
      this.source_parentsystemusername.DataPropertyName = "source_parentsystemusername";
      this.source_parentsystemusername.HeaderText = "source_parentsystemusername";
      this.source_parentsystemusername.MinimumWidth = 6;
      this.source_parentsystemusername.Name = "source_parentsystemusername";
      this.source_parentsystemusername.Width = 236;
      // 
      // source_territoryname
      // 
      this.source_territoryname.DataPropertyName = "source_territoryname";
      this.source_territoryname.HeaderText = "source_territoryname";
      this.source_territoryname.MinimumWidth = 6;
      this.source_territoryname.Name = "source_territoryname";
      this.source_territoryname.Width = 172;
      // 
      // source_transactioncurrencyname
      // 
      this.source_transactioncurrencyname.DataPropertyName = "source_transactioncurrencyname";
      this.source_transactioncurrencyname.HeaderText = "source_transactioncurrencyname";
      this.source_transactioncurrencyname.MinimumWidth = 6;
      this.source_transactioncurrencyname.Name = "source_transactioncurrencyname";
      this.source_transactioncurrencyname.Width = 248;
      // 
      // dataGridViewCheckBoxColumn4
      // 
      this.dataGridViewCheckBoxColumn4.DataPropertyName = "target_IsDisabled";
      this.dataGridViewCheckBoxColumn4.HeaderText = "target_IsDisabled";
      this.dataGridViewCheckBoxColumn4.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn4.Name = "dataGridViewCheckBoxColumn4";
      this.dataGridViewCheckBoxColumn4.ReadOnly = true;
      this.dataGridViewCheckBoxColumn4.Width = 124;
      // 
      // target_islicensed
      // 
      this.target_islicensed.DataPropertyName = "target_islicensed";
      this.target_islicensed.HeaderText = "target_IsLicensed";
      this.target_islicensed.MinimumWidth = 6;
      this.target_islicensed.Name = "target_islicensed";
      this.target_islicensed.ReadOnly = true;
      this.target_islicensed.Width = 126;
      // 
      // dataGridViewTextBoxColumn6
      // 
      this.dataGridViewTextBoxColumn6.DataPropertyName = "target_BUName";
      this.dataGridViewTextBoxColumn6.HeaderText = "target_BU";
      this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
      this.dataGridViewTextBoxColumn6.ReadOnly = true;
      this.dataGridViewTextBoxColumn6.Width = 101;
      // 
      // target_DomainName
      // 
      this.target_DomainName.DataPropertyName = "target_domain";
      this.target_DomainName.HeaderText = "Target - Domain";
      this.target_DomainName.MinimumWidth = 6;
      this.target_DomainName.Name = "target_DomainName";
      this.target_DomainName.ReadOnly = true;
      this.target_DomainName.Width = 140;
      // 
      // target_identityid
      // 
      this.target_identityid.DataPropertyName = "target_identityid";
      this.target_identityid.HeaderText = "Target - Identityid";
      this.target_identityid.MinimumWidth = 6;
      this.target_identityid.Name = "target_identityid";
      this.target_identityid.ReadOnly = true;
      this.target_identityid.Width = 148;
      // 
      // target_FullName
      // 
      this.target_FullName.DataPropertyName = "target_fullname";
      this.target_FullName.HeaderText = "Target - Full Name";
      this.target_FullName.MinimumWidth = 6;
      this.target_FullName.Name = "target_FullName";
      this.target_FullName.ReadOnly = true;
      this.target_FullName.Width = 155;
      // 
      // target_parentsystemusername
      // 
      this.target_parentsystemusername.DataPropertyName = "target_parentsystemusername";
      this.target_parentsystemusername.HeaderText = "target_parentsystemusername";
      this.target_parentsystemusername.MinimumWidth = 6;
      this.target_parentsystemusername.Name = "target_parentsystemusername";
      this.target_parentsystemusername.Width = 230;
      // 
      // target_territoryname
      // 
      this.target_territoryname.DataPropertyName = "target_territoryname";
      this.target_territoryname.HeaderText = "target_territoryname";
      this.target_territoryname.MinimumWidth = 6;
      this.target_territoryname.Name = "target_territoryname";
      this.target_territoryname.Width = 166;
      // 
      // target_transactioncurrencyname
      // 
      this.target_transactioncurrencyname.DataPropertyName = "target_transactioncurrencyname";
      this.target_transactioncurrencyname.HeaderText = "target_transactioncurrencyname";
      this.target_transactioncurrencyname.MinimumWidth = 6;
      this.target_transactioncurrencyname.Name = "target_transactioncurrencyname";
      this.target_transactioncurrencyname.Width = 242;
      // 
      // cbHideInTarget
      // 
      this.cbHideInTarget.AutoSize = true;
      this.cbHideInTarget.Location = new System.Drawing.Point(8, 43);
      this.cbHideInTarget.Margin = new System.Windows.Forms.Padding(4);
      this.cbHideInTarget.Name = "cbHideInTarget";
      this.cbHideInTarget.Size = new System.Drawing.Size(120, 21);
      this.cbHideInTarget.TabIndex = 5;
      this.cbHideInTarget.Text = "Hide In Target";
      this.cbHideInTarget.UseVisualStyleBackColor = true;
      this.cbHideInTarget.CheckedChanged += new System.EventHandler(this.cbHideInTarget_CheckedChanged);
      // 
      // btnLoadSourceUsers
      // 
      this.btnLoadSourceUsers.Location = new System.Drawing.Point(8, 7);
      this.btnLoadSourceUsers.Margin = new System.Windows.Forms.Padding(4);
      this.btnLoadSourceUsers.Name = "btnLoadSourceUsers";
      this.btnLoadSourceUsers.Size = new System.Drawing.Size(167, 28);
      this.btnLoadSourceUsers.TabIndex = 1;
      this.btnLoadSourceUsers.Text = "Map Users";
      this.btnLoadSourceUsers.UseVisualStyleBackColor = true;
      this.btnLoadSourceUsers.Click += new System.EventHandler(this.btnLoadSourceUsers_Click);
      // 
      // lblUsersTotalInfo
      // 
      this.lblUsersTotalInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblUsersTotalInfo.Location = new System.Drawing.Point(1372, 14);
      this.lblUsersTotalInfo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblUsersTotalInfo.Name = "lblUsersTotalInfo";
      this.lblUsersTotalInfo.Size = new System.Drawing.Size(209, 20);
      this.lblUsersTotalInfo.TabIndex = 4;
      this.lblUsersTotalInfo.Text = "Selected 0000 of 0000";
      this.lblUsersTotalInfo.TextAlign = System.Drawing.ContentAlignment.TopRight;
      // 
      // cbAddStubUsersCheckUncheck
      // 
      this.cbAddStubUsersCheckUncheck.AutoSize = true;
      this.cbAddStubUsersCheckUncheck.Location = new System.Drawing.Point(732, 10);
      this.cbAddStubUsersCheckUncheck.Margin = new System.Windows.Forms.Padding(4);
      this.cbAddStubUsersCheckUncheck.Name = "cbAddStubUsersCheckUncheck";
      this.cbAddStubUsersCheckUncheck.Size = new System.Drawing.Size(201, 21);
      this.cbAddStubUsersCheckUncheck.TabIndex = 3;
      this.cbAddStubUsersCheckUncheck.Text = "Add Stub: Check/Un-Check";
      this.cbAddStubUsersCheckUncheck.UseVisualStyleBackColor = true;
      this.cbAddStubUsersCheckUncheck.CheckedChanged += new System.EventHandler(this.cbCheckUncheckUsers_CheckedChanged);
      // 
      // btnCreateStubUsers
      // 
      this.btnCreateStubUsers.Location = new System.Drawing.Point(183, 7);
      this.btnCreateStubUsers.Margin = new System.Windows.Forms.Padding(4);
      this.btnCreateStubUsers.Name = "btnCreateStubUsers";
      this.btnCreateStubUsers.Size = new System.Drawing.Size(204, 28);
      this.btnCreateStubUsers.TabIndex = 2;
      this.btnCreateStubUsers.Text = "Create Target Stub Users";
      this.btnCreateStubUsers.UseVisualStyleBackColor = true;
      this.btnCreateStubUsers.Click += new System.EventHandler(this.btnCreateStubUsers_Click);
      // 
      // tpUserSecurity
      // 
      this.tpUserSecurity.Controls.Add(this.cbUserSecurityHideUnLicensed);
      this.tpUserSecurity.Controls.Add(this.cbUserSecurityHideDisabled);
      this.tpUserSecurity.Controls.Add(this.ckClearTargetRoles);
      this.tpUserSecurity.Controls.Add(this.ckUserSecurityCheckUncheck);
      this.tpUserSecurity.Controls.Add(this.scUserSecurityMain);
      this.tpUserSecurity.Controls.Add(this.btnSyncSecurityRoles);
      this.tpUserSecurity.Controls.Add(this.btnCompareSecurityRoles);
      this.tpUserSecurity.Location = new System.Drawing.Point(25, 4);
      this.tpUserSecurity.Margin = new System.Windows.Forms.Padding(4);
      this.tpUserSecurity.Name = "tpUserSecurity";
      this.tpUserSecurity.Padding = new System.Windows.Forms.Padding(4);
      this.tpUserSecurity.Size = new System.Drawing.Size(1671, 893);
      this.tpUserSecurity.TabIndex = 1;
      this.tpUserSecurity.Text = "User Security";
      this.tpUserSecurity.UseVisualStyleBackColor = true;
      // 
      // cbUserSecurityHideUnLicensed
      // 
      this.cbUserSecurityHideUnLicensed.AutoSize = true;
      this.cbUserSecurityHideUnLicensed.Checked = true;
      this.cbUserSecurityHideUnLicensed.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbUserSecurityHideUnLicensed.Location = new System.Drawing.Point(1157, 7);
      this.cbUserSecurityHideUnLicensed.Margin = new System.Windows.Forms.Padding(4);
      this.cbUserSecurityHideUnLicensed.Name = "cbUserSecurityHideUnLicensed";
      this.cbUserSecurityHideUnLicensed.Size = new System.Drawing.Size(142, 21);
      this.cbUserSecurityHideUnLicensed.TabIndex = 7;
      this.cbUserSecurityHideUnLicensed.Text = "Hide Un Licensed";
      this.cbUserSecurityHideUnLicensed.UseVisualStyleBackColor = true;
      // 
      // cbUserSecurityHideDisabled
      // 
      this.cbUserSecurityHideDisabled.AutoSize = true;
      this.cbUserSecurityHideDisabled.Checked = true;
      this.cbUserSecurityHideDisabled.CheckState = System.Windows.Forms.CheckState.Checked;
      this.cbUserSecurityHideDisabled.Location = new System.Drawing.Point(1004, 9);
      this.cbUserSecurityHideDisabled.Margin = new System.Windows.Forms.Padding(4);
      this.cbUserSecurityHideDisabled.Name = "cbUserSecurityHideDisabled";
      this.cbUserSecurityHideDisabled.Size = new System.Drawing.Size(118, 21);
      this.cbUserSecurityHideDisabled.TabIndex = 6;
      this.cbUserSecurityHideDisabled.Text = "Hide Disabled";
      this.cbUserSecurityHideDisabled.UseVisualStyleBackColor = true;
      // 
      // ckClearTargetRoles
      // 
      this.ckClearTargetRoles.AutoSize = true;
      this.ckClearTargetRoles.Checked = true;
      this.ckClearTargetRoles.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckClearTargetRoles.Location = new System.Drawing.Point(693, 10);
      this.ckClearTargetRoles.Margin = new System.Windows.Forms.Padding(4);
      this.ckClearTargetRoles.Name = "ckClearTargetRoles";
      this.ckClearTargetRoles.Size = new System.Drawing.Size(262, 21);
      this.ckClearTargetRoles.TabIndex = 5;
      this.ckClearTargetRoles.Text = "Clear Target Roles: Check Un-Check";
      this.ckClearTargetRoles.UseVisualStyleBackColor = true;
      this.ckClearTargetRoles.CheckedChanged += new System.EventHandler(this.ckClearTargetRoles_CheckedChanged);
      // 
      // ckUserSecurityCheckUncheck
      // 
      this.ckUserSecurityCheckUncheck.AutoSize = true;
      this.ckUserSecurityCheckUncheck.Location = new System.Drawing.Point(419, 10);
      this.ckUserSecurityCheckUncheck.Margin = new System.Windows.Forms.Padding(4);
      this.ckUserSecurityCheckUncheck.Name = "ckUserSecurityCheckUncheck";
      this.ckUserSecurityCheckUncheck.Size = new System.Drawing.Size(222, 21);
      this.ckUserSecurityCheckUncheck.TabIndex = 4;
      this.ckUserSecurityCheckUncheck.Text = "Sync Roles: Check / Un-Check";
      this.ckUserSecurityCheckUncheck.UseVisualStyleBackColor = true;
      this.ckUserSecurityCheckUncheck.CheckedChanged += new System.EventHandler(this.ckUserSecurityCheckUncheck_CheckedChanged);
      // 
      // scUserSecurityMain
      // 
      this.scUserSecurityMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.scUserSecurityMain.Location = new System.Drawing.Point(9, 41);
      this.scUserSecurityMain.Margin = new System.Windows.Forms.Padding(4);
      this.scUserSecurityMain.Name = "scUserSecurityMain";
      this.scUserSecurityMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // scUserSecurityMain.Panel1
      // 
      this.scUserSecurityMain.Panel1.Controls.Add(this.dgUserSecurity);
      // 
      // scUserSecurityMain.Panel2
      // 
      this.scUserSecurityMain.Panel2.Controls.Add(this.scUserSecurityRoles);
      this.scUserSecurityMain.Size = new System.Drawing.Size(1588, 843);
      this.scUserSecurityMain.SplitterDistance = 414;
      this.scUserSecurityMain.SplitterWidth = 5;
      this.scUserSecurityMain.TabIndex = 2;
      // 
      // dgUserSecurity
      // 
      this.dgUserSecurity.AllowUserToAddRows = false;
      this.dgUserSecurity.AllowUserToDeleteRows = false;
      this.dgUserSecurity.AllowUserToResizeRows = false;
      dataGridViewCellStyle8.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgUserSecurity.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle8;
      this.dgUserSecurity.AutoGenerateColumns = false;
      this.dgUserSecurity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
      this.dgUserSecurity.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCellsExceptHeaders;
      this.dgUserSecurity.ColumnHeadersHeight = 29;
      this.dgUserSecurity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.SyncRoles,
            this.ClearTargetRoles,
            this.RolesMatch,
            this.source_IsDisabled,
            this.source_buname,
            this.source_domainname,
            this.sourcerolenamesDataGridViewTextBoxColumn,
            this.target_IsDisabled,
            this.target_buname,
            this.dataGridViewTextBoxColumn4,
            this.targetrolenamesDataGridViewTextBoxColumn});
      this.dgUserSecurity.DataMember = "dtUserSecurityRoles";
      this.dgUserSecurity.DataSource = this.dsFSMigrationBindingSource;
      this.dgUserSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgUserSecurity.Location = new System.Drawing.Point(0, 0);
      this.dgUserSecurity.Margin = new System.Windows.Forms.Padding(4);
      this.dgUserSecurity.MultiSelect = false;
      this.dgUserSecurity.Name = "dgUserSecurity";
      this.dgUserSecurity.RowHeadersWidth = 51;
      this.dgUserSecurity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgUserSecurity.Size = new System.Drawing.Size(1588, 414);
      this.dgUserSecurity.TabIndex = 1;
      this.dgUserSecurity.VirtualMode = true;
      this.dgUserSecurity.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgUserSecurity_DataError);
      this.dgUserSecurity.SelectionChanged += new System.EventHandler(this.dgUserSecurity_SelectionChanged);
      // 
      // SyncRoles
      // 
      this.SyncRoles.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
      this.SyncRoles.DataPropertyName = "SyncRoles";
      this.SyncRoles.HeaderText = "Sync Roles";
      this.SyncRoles.MinimumWidth = 6;
      this.SyncRoles.Name = "SyncRoles";
      this.SyncRoles.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.SyncRoles.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.SyncRoles.Width = 90;
      // 
      // ClearTargetRoles
      // 
      this.ClearTargetRoles.DataPropertyName = "ClearTargetRoles";
      this.ClearTargetRoles.HeaderText = "Clear Target Roles";
      this.ClearTargetRoles.MinimumWidth = 6;
      this.ClearTargetRoles.Name = "ClearTargetRoles";
      this.ClearTargetRoles.ToolTipText = "Clear the target roles before adding source roles";
      this.ClearTargetRoles.Width = 133;
      // 
      // RolesMatch
      // 
      this.RolesMatch.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
      this.RolesMatch.DataPropertyName = "RolesMatch";
      this.RolesMatch.HeaderText = "Roles Match";
      this.RolesMatch.MinimumWidth = 6;
      this.RolesMatch.Name = "RolesMatch";
      this.RolesMatch.Resizable = System.Windows.Forms.DataGridViewTriState.False;
      this.RolesMatch.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
      this.RolesMatch.Width = 90;
      // 
      // source_IsDisabled
      // 
      this.source_IsDisabled.DataPropertyName = "source_IsDisabled";
      this.source_IsDisabled.HeaderText = "source_IsDisabled";
      this.source_IsDisabled.MinimumWidth = 6;
      this.source_IsDisabled.Name = "source_IsDisabled";
      this.source_IsDisabled.Width = 130;
      // 
      // source_buname
      // 
      this.source_buname.DataPropertyName = "source_buname";
      this.source_buname.HeaderText = "source BU";
      this.source_buname.MinimumWidth = 6;
      this.source_buname.Name = "source_buname";
      this.source_buname.Width = 103;
      // 
      // source_domainname
      // 
      this.source_domainname.DataPropertyName = "source_domainname";
      this.source_domainname.HeaderText = "Source - Domain";
      this.source_domainname.MinimumWidth = 6;
      this.source_domainname.Name = "source_domainname";
      this.source_domainname.Width = 143;
      // 
      // sourcerolenamesDataGridViewTextBoxColumn
      // 
      this.sourcerolenamesDataGridViewTextBoxColumn.DataPropertyName = "source_rolenames";
      this.sourcerolenamesDataGridViewTextBoxColumn.HeaderText = "Source - Roles";
      this.sourcerolenamesDataGridViewTextBoxColumn.MaxInputLength = 1000000000;
      this.sourcerolenamesDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcerolenamesDataGridViewTextBoxColumn.Name = "sourcerolenamesDataGridViewTextBoxColumn";
      this.sourcerolenamesDataGridViewTextBoxColumn.Width = 131;
      // 
      // target_IsDisabled
      // 
      this.target_IsDisabled.DataPropertyName = "target_IsDisabled";
      this.target_IsDisabled.HeaderText = "target_IsDisabled";
      this.target_IsDisabled.MinimumWidth = 6;
      this.target_IsDisabled.Name = "target_IsDisabled";
      this.target_IsDisabled.Width = 124;
      // 
      // target_buname
      // 
      this.target_buname.DataPropertyName = "target_buname";
      this.target_buname.HeaderText = "target BU";
      this.target_buname.MinimumWidth = 6;
      this.target_buname.Name = "target_buname";
      this.target_buname.Width = 97;
      // 
      // dataGridViewTextBoxColumn4
      // 
      this.dataGridViewTextBoxColumn4.DataPropertyName = "target_domainname";
      this.dataGridViewTextBoxColumn4.HeaderText = "Target - Domain";
      this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
      this.dataGridViewTextBoxColumn4.Width = 140;
      // 
      // targetrolenamesDataGridViewTextBoxColumn
      // 
      this.targetrolenamesDataGridViewTextBoxColumn.DataPropertyName = "target_rolenames";
      this.targetrolenamesDataGridViewTextBoxColumn.HeaderText = "Target - Roles";
      this.targetrolenamesDataGridViewTextBoxColumn.MaxInputLength = 1000000000;
      this.targetrolenamesDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetrolenamesDataGridViewTextBoxColumn.Name = "targetrolenamesDataGridViewTextBoxColumn";
      this.targetrolenamesDataGridViewTextBoxColumn.Width = 128;
      // 
      // scUserSecurityRoles
      // 
      this.scUserSecurityRoles.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scUserSecurityRoles.Location = new System.Drawing.Point(0, 0);
      this.scUserSecurityRoles.Margin = new System.Windows.Forms.Padding(4);
      this.scUserSecurityRoles.Name = "scUserSecurityRoles";
      // 
      // scUserSecurityRoles.Panel1
      // 
      this.scUserSecurityRoles.Panel1.Controls.Add(this.lblSourceUserRoles);
      this.scUserSecurityRoles.Panel1.Controls.Add(this.dgSourceUserRoles);
      // 
      // scUserSecurityRoles.Panel2
      // 
      this.scUserSecurityRoles.Panel2.Controls.Add(this.lblTargetUserRoles);
      this.scUserSecurityRoles.Panel2.Controls.Add(this.dgTargetUserRoles);
      this.scUserSecurityRoles.Size = new System.Drawing.Size(1588, 424);
      this.scUserSecurityRoles.SplitterDistance = 815;
      this.scUserSecurityRoles.SplitterWidth = 5;
      this.scUserSecurityRoles.TabIndex = 0;
      // 
      // lblSourceUserRoles
      // 
      this.lblSourceUserRoles.BackColor = System.Drawing.Color.LightGray;
      this.lblSourceUserRoles.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblSourceUserRoles.Location = new System.Drawing.Point(0, 0);
      this.lblSourceUserRoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblSourceUserRoles.Name = "lblSourceUserRoles";
      this.lblSourceUserRoles.Size = new System.Drawing.Size(815, 16);
      this.lblSourceUserRoles.TabIndex = 1;
      this.lblSourceUserRoles.Text = "Source User Roles";
      this.lblSourceUserRoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dgSourceUserRoles
      // 
      this.dgSourceUserRoles.AllowUserToAddRows = false;
      this.dgSourceUserRoles.AllowUserToDeleteRows = false;
      this.dgSourceUserRoles.AllowUserToResizeRows = false;
      this.dgSourceUserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgSourceUserRoles.AutoGenerateColumns = false;
      this.dgSourceUserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgSourceUserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgSourceUserRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.source_roleid,
            this.source_rolename});
      this.dgSourceUserRoles.DataMember = "dtSourceUserSecurityRoles";
      this.dgSourceUserRoles.DataSource = this.dsFSMigrationBindingSource;
      this.dgSourceUserRoles.Location = new System.Drawing.Point(4, 20);
      this.dgSourceUserRoles.Margin = new System.Windows.Forms.Padding(4);
      this.dgSourceUserRoles.MultiSelect = false;
      this.dgSourceUserRoles.Name = "dgSourceUserRoles";
      this.dgSourceUserRoles.ReadOnly = true;
      this.dgSourceUserRoles.RowHeadersWidth = 51;
      this.dgSourceUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgSourceUserRoles.Size = new System.Drawing.Size(807, 401);
      this.dgSourceUserRoles.TabIndex = 0;
      this.dgSourceUserRoles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgSourceUserRoles_DataError);
      // 
      // source_roleid
      // 
      this.source_roleid.DataPropertyName = "roleid";
      this.source_roleid.HeaderText = "Role Id";
      this.source_roleid.MinimumWidth = 6;
      this.source_roleid.Name = "source_roleid";
      this.source_roleid.ReadOnly = true;
      // 
      // source_rolename
      // 
      this.source_rolename.DataPropertyName = "rolename";
      this.source_rolename.HeaderText = "Role Name";
      this.source_rolename.MinimumWidth = 6;
      this.source_rolename.Name = "source_rolename";
      this.source_rolename.ReadOnly = true;
      // 
      // lblTargetUserRoles
      // 
      this.lblTargetUserRoles.BackColor = System.Drawing.Color.LightGray;
      this.lblTargetUserRoles.Dock = System.Windows.Forms.DockStyle.Top;
      this.lblTargetUserRoles.Location = new System.Drawing.Point(0, 0);
      this.lblTargetUserRoles.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblTargetUserRoles.Name = "lblTargetUserRoles";
      this.lblTargetUserRoles.Size = new System.Drawing.Size(768, 16);
      this.lblTargetUserRoles.TabIndex = 3;
      this.lblTargetUserRoles.Text = "Target User Roles";
      this.lblTargetUserRoles.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dgTargetUserRoles
      // 
      this.dgTargetUserRoles.AllowUserToAddRows = false;
      this.dgTargetUserRoles.AllowUserToDeleteRows = false;
      this.dgTargetUserRoles.AllowUserToResizeRows = false;
      dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgTargetUserRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle9;
      this.dgTargetUserRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgTargetUserRoles.AutoGenerateColumns = false;
      this.dgTargetUserRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgTargetUserRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTargetUserRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.target_roleid,
            this.target_rolename});
      this.dgTargetUserRoles.DataMember = "dtTargetUserSecurityRoles";
      this.dgTargetUserRoles.DataSource = this.dsFSMigrationBindingSource;
      this.dgTargetUserRoles.Location = new System.Drawing.Point(4, 21);
      this.dgTargetUserRoles.Margin = new System.Windows.Forms.Padding(4);
      this.dgTargetUserRoles.MultiSelect = false;
      this.dgTargetUserRoles.Name = "dgTargetUserRoles";
      this.dgTargetUserRoles.ReadOnly = true;
      this.dgTargetUserRoles.RowHeadersWidth = 51;
      this.dgTargetUserRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgTargetUserRoles.Size = new System.Drawing.Size(785, 401);
      this.dgTargetUserRoles.TabIndex = 2;
      this.dgTargetUserRoles.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgTargetUserRoles_DataError);
      // 
      // target_roleid
      // 
      this.target_roleid.DataPropertyName = "roleid";
      this.target_roleid.HeaderText = "Role Id";
      this.target_roleid.MinimumWidth = 6;
      this.target_roleid.Name = "target_roleid";
      this.target_roleid.ReadOnly = true;
      // 
      // target_rolename
      // 
      this.target_rolename.DataPropertyName = "rolename";
      this.target_rolename.HeaderText = "Role Name";
      this.target_rolename.MinimumWidth = 6;
      this.target_rolename.Name = "target_rolename";
      this.target_rolename.ReadOnly = true;
      // 
      // btnSyncSecurityRoles
      // 
      this.btnSyncSecurityRoles.Location = new System.Drawing.Point(205, 5);
      this.btnSyncSecurityRoles.Margin = new System.Windows.Forms.Padding(4);
      this.btnSyncSecurityRoles.Name = "btnSyncSecurityRoles";
      this.btnSyncSecurityRoles.Size = new System.Drawing.Size(188, 28);
      this.btnSyncSecurityRoles.TabIndex = 0;
      this.btnSyncSecurityRoles.Text = "Sync Security Roles";
      this.btnSyncSecurityRoles.UseVisualStyleBackColor = true;
      this.btnSyncSecurityRoles.Click += new System.EventHandler(this.btnSyncSecurityRoles_Click);
      // 
      // btnCompareSecurityRoles
      // 
      this.btnCompareSecurityRoles.Location = new System.Drawing.Point(9, 5);
      this.btnCompareSecurityRoles.Margin = new System.Windows.Forms.Padding(4);
      this.btnCompareSecurityRoles.Name = "btnCompareSecurityRoles";
      this.btnCompareSecurityRoles.Size = new System.Drawing.Size(188, 28);
      this.btnCompareSecurityRoles.TabIndex = 0;
      this.btnCompareSecurityRoles.Text = "Compare User Security";
      this.btnCompareSecurityRoles.UseVisualStyleBackColor = true;
      this.btnCompareSecurityRoles.Click += new System.EventHandler(this.btnCompareSecurityRoles_Click);
      // 
      // tpTeamMembership
      // 
      this.tpTeamMembership.Controls.Add(this.splitContainer4);
      this.tpTeamMembership.Controls.Add(this.btnTeamAddUserLoadTeams);
      this.tpTeamMembership.Location = new System.Drawing.Point(25, 4);
      this.tpTeamMembership.Margin = new System.Windows.Forms.Padding(4);
      this.tpTeamMembership.Name = "tpTeamMembership";
      this.tpTeamMembership.Size = new System.Drawing.Size(1671, 893);
      this.tpTeamMembership.TabIndex = 5;
      this.tpTeamMembership.Text = "Team Members";
      this.tpTeamMembership.UseVisualStyleBackColor = true;
      // 
      // splitContainer4
      // 
      this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer4.Location = new System.Drawing.Point(0, 0);
      this.splitContainer4.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer4.Name = "splitContainer4";
      this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer4.Panel1
      // 
      this.splitContainer4.Panel1.Controls.Add(this.btnSyncTeamMembers);
      this.splitContainer4.Panel1.Controls.Add(this.cbClearTargetMembersCheckUncheck);
      this.splitContainer4.Panel1.Controls.Add(this.cbSyncTeamMembersCheckUncheck);
      this.splitContainer4.Panel1.Controls.Add(this.dgTeamMembership);
      this.splitContainer4.Panel1.Controls.Add(this.btnTeamMembershipLoadTeams);
      // 
      // splitContainer4.Panel2
      // 
      this.splitContainer4.Panel2.Controls.Add(this.splitContainer5);
      this.splitContainer4.Size = new System.Drawing.Size(1671, 893);
      this.splitContainer4.SplitterDistance = 515;
      this.splitContainer4.SplitterWidth = 5;
      this.splitContainer4.TabIndex = 1;
      // 
      // btnSyncTeamMembers
      // 
      this.btnSyncTeamMembers.Location = new System.Drawing.Point(168, 10);
      this.btnSyncTeamMembers.Margin = new System.Windows.Forms.Padding(4);
      this.btnSyncTeamMembers.Name = "btnSyncTeamMembers";
      this.btnSyncTeamMembers.Size = new System.Drawing.Size(175, 28);
      this.btnSyncTeamMembers.TabIndex = 4;
      this.btnSyncTeamMembers.Text = "Sync Team Members";
      this.btnSyncTeamMembers.UseVisualStyleBackColor = true;
      this.btnSyncTeamMembers.Click += new System.EventHandler(this.btnSyncTeamMembers_Click);
      // 
      // cbClearTargetMembersCheckUncheck
      // 
      this.cbClearTargetMembersCheckUncheck.AutoSize = true;
      this.cbClearTargetMembersCheckUncheck.Location = new System.Drawing.Point(668, 15);
      this.cbClearTargetMembersCheckUncheck.Margin = new System.Windows.Forms.Padding(4);
      this.cbClearTargetMembersCheckUncheck.Name = "cbClearTargetMembersCheckUncheck";
      this.cbClearTargetMembersCheckUncheck.Size = new System.Drawing.Size(275, 21);
      this.cbClearTargetMembersCheckUncheck.TabIndex = 3;
      this.cbClearTargetMembersCheckUncheck.Text = "Clear Target Members Check/UnCheck";
      this.cbClearTargetMembersCheckUncheck.UseVisualStyleBackColor = true;
      // 
      // cbSyncTeamMembersCheckUncheck
      // 
      this.cbSyncTeamMembersCheckUncheck.AutoSize = true;
      this.cbSyncTeamMembersCheckUncheck.Location = new System.Drawing.Point(364, 15);
      this.cbSyncTeamMembersCheckUncheck.Margin = new System.Windows.Forms.Padding(4);
      this.cbSyncTeamMembersCheckUncheck.Name = "cbSyncTeamMembersCheckUncheck";
      this.cbSyncTeamMembersCheckUncheck.Size = new System.Drawing.Size(267, 21);
      this.cbSyncTeamMembersCheckUncheck.TabIndex = 2;
      this.cbSyncTeamMembersCheckUncheck.Text = "Sync Team Members Check/UnCheck";
      this.cbSyncTeamMembersCheckUncheck.UseVisualStyleBackColor = true;
      // 
      // dgTeamMembership
      // 
      this.dgTeamMembership.AllowUserToAddRows = false;
      this.dgTeamMembership.AllowUserToDeleteRows = false;
      this.dgTeamMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgTeamMembership.AutoGenerateColumns = false;
      this.dgTeamMembership.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgTeamMembership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTeamMembership.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn6,
            this.dataGridViewCheckBoxColumn5,
            this.target_isdefault,
            this.sourceteamidDataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.dataGridViewTextBoxColumn15,
            this.targetteamidDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn17,
            this.dataGridViewTextBoxColumn18,
            this.dataGridViewTextBoxColumn19,
            this.dataGridViewTextBoxColumn20});
      this.dgTeamMembership.DataMember = "dtTeamMembership";
      this.dgTeamMembership.DataSource = this.dsFSMigrationBindingSource;
      this.dgTeamMembership.Location = new System.Drawing.Point(13, 47);
      this.dgTeamMembership.Margin = new System.Windows.Forms.Padding(4);
      this.dgTeamMembership.MultiSelect = false;
      this.dgTeamMembership.Name = "dgTeamMembership";
      this.dgTeamMembership.RowHeadersWidth = 51;
      this.dgTeamMembership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgTeamMembership.ShowEditingIcon = false;
      this.dgTeamMembership.Size = new System.Drawing.Size(1654, 464);
      this.dgTeamMembership.TabIndex = 1;
      this.dgTeamMembership.SelectionChanged += new System.EventHandler(this.dgTeamMembership_SelectionChanged);
      // 
      // dataGridViewCheckBoxColumn6
      // 
      this.dataGridViewCheckBoxColumn6.DataPropertyName = "SyncTeamMembers";
      this.dataGridViewCheckBoxColumn6.HeaderText = "Sync Membership";
      this.dataGridViewCheckBoxColumn6.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn6.Name = "dataGridViewCheckBoxColumn6";
      // 
      // dataGridViewCheckBoxColumn5
      // 
      this.dataGridViewCheckBoxColumn5.DataPropertyName = "ClearTargetTeamMembers";
      this.dataGridViewCheckBoxColumn5.HeaderText = "Clear Target";
      this.dataGridViewCheckBoxColumn5.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn5.Name = "dataGridViewCheckBoxColumn5";
      // 
      // target_isdefault
      // 
      this.target_isdefault.DataPropertyName = "target_isdefault";
      this.target_isdefault.HeaderText = "Is Default";
      this.target_isdefault.MinimumWidth = 6;
      this.target_isdefault.Name = "target_isdefault";
      this.target_isdefault.ReadOnly = true;
      // 
      // sourceteamidDataGridViewTextBoxColumn3
      // 
      this.sourceteamidDataGridViewTextBoxColumn3.DataPropertyName = "source_teamid";
      this.sourceteamidDataGridViewTextBoxColumn3.HeaderText = "Source TeamId";
      this.sourceteamidDataGridViewTextBoxColumn3.MinimumWidth = 6;
      this.sourceteamidDataGridViewTextBoxColumn3.Name = "sourceteamidDataGridViewTextBoxColumn3";
      this.sourceteamidDataGridViewTextBoxColumn3.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn12
      // 
      this.dataGridViewTextBoxColumn12.DataPropertyName = "source_teamname";
      this.dataGridViewTextBoxColumn12.HeaderText = "Source Team Name";
      this.dataGridViewTextBoxColumn12.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
      this.dataGridViewTextBoxColumn12.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn13
      // 
      this.dataGridViewTextBoxColumn13.DataPropertyName = "source_teambusinessunitid";
      this.dataGridViewTextBoxColumn13.HeaderText = "source_teambusinessunitid";
      this.dataGridViewTextBoxColumn13.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
      this.dataGridViewTextBoxColumn13.ReadOnly = true;
      this.dataGridViewTextBoxColumn13.Visible = false;
      // 
      // dataGridViewTextBoxColumn14
      // 
      this.dataGridViewTextBoxColumn14.DataPropertyName = "source_teambuname";
      this.dataGridViewTextBoxColumn14.HeaderText = "Source Team BU";
      this.dataGridViewTextBoxColumn14.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
      this.dataGridViewTextBoxColumn14.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn15
      // 
      this.dataGridViewTextBoxColumn15.DataPropertyName = "source_teammembers";
      this.dataGridViewTextBoxColumn15.HeaderText = "Source Membership";
      this.dataGridViewTextBoxColumn15.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
      this.dataGridViewTextBoxColumn15.ReadOnly = true;
      // 
      // targetteamidDataGridViewTextBoxColumn2
      // 
      this.targetteamidDataGridViewTextBoxColumn2.DataPropertyName = "target_teamid";
      this.targetteamidDataGridViewTextBoxColumn2.HeaderText = "Target TeamId";
      this.targetteamidDataGridViewTextBoxColumn2.MinimumWidth = 6;
      this.targetteamidDataGridViewTextBoxColumn2.Name = "targetteamidDataGridViewTextBoxColumn2";
      this.targetteamidDataGridViewTextBoxColumn2.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn17
      // 
      this.dataGridViewTextBoxColumn17.DataPropertyName = "target_teamname";
      this.dataGridViewTextBoxColumn17.HeaderText = "Target Team Name";
      this.dataGridViewTextBoxColumn17.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
      this.dataGridViewTextBoxColumn17.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn18
      // 
      this.dataGridViewTextBoxColumn18.DataPropertyName = "target_teambusinessunitid";
      this.dataGridViewTextBoxColumn18.HeaderText = "target_teambusinessunitid";
      this.dataGridViewTextBoxColumn18.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
      this.dataGridViewTextBoxColumn18.ReadOnly = true;
      this.dataGridViewTextBoxColumn18.Visible = false;
      // 
      // dataGridViewTextBoxColumn19
      // 
      this.dataGridViewTextBoxColumn19.DataPropertyName = "target_teambuname";
      this.dataGridViewTextBoxColumn19.HeaderText = "Target Team BU";
      this.dataGridViewTextBoxColumn19.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
      this.dataGridViewTextBoxColumn19.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn20
      // 
      this.dataGridViewTextBoxColumn20.DataPropertyName = "target_teammembers";
      this.dataGridViewTextBoxColumn20.HeaderText = "Target Membership";
      this.dataGridViewTextBoxColumn20.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
      this.dataGridViewTextBoxColumn20.ReadOnly = true;
      // 
      // btnTeamMembershipLoadTeams
      // 
      this.btnTeamMembershipLoadTeams.Location = new System.Drawing.Point(13, 10);
      this.btnTeamMembershipLoadTeams.Margin = new System.Windows.Forms.Padding(4);
      this.btnTeamMembershipLoadTeams.Name = "btnTeamMembershipLoadTeams";
      this.btnTeamMembershipLoadTeams.Size = new System.Drawing.Size(147, 28);
      this.btnTeamMembershipLoadTeams.TabIndex = 0;
      this.btnTeamMembershipLoadTeams.Text = "Compare Teams";
      this.btnTeamMembershipLoadTeams.UseVisualStyleBackColor = true;
      this.btnTeamMembershipLoadTeams.Click += new System.EventHandler(this.btnTeamAssignmentLoadTeams_Click);
      // 
      // splitContainer5
      // 
      this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer5.Location = new System.Drawing.Point(0, 0);
      this.splitContainer5.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer5.Name = "splitContainer5";
      // 
      // splitContainer5.Panel1
      // 
      this.splitContainer5.Panel1.Controls.Add(this.label14);
      this.splitContainer5.Panel1.Controls.Add(this.dgSourceTeamMembership);
      // 
      // splitContainer5.Panel2
      // 
      this.splitContainer5.Panel2.Controls.Add(this.label15);
      this.splitContainer5.Panel2.Controls.Add(this.dgTargetTeamMembership);
      this.splitContainer5.Size = new System.Drawing.Size(1671, 373);
      this.splitContainer5.SplitterDistance = 809;
      this.splitContainer5.SplitterWidth = 5;
      this.splitContainer5.TabIndex = 0;
      // 
      // label14
      // 
      this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label14.BackColor = System.Drawing.Color.LightGray;
      this.label14.Location = new System.Drawing.Point(4, 0);
      this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label14.Name = "label14";
      this.label14.Size = new System.Drawing.Size(801, 25);
      this.label14.TabIndex = 5;
      this.label14.Text = "Source Membership";
      this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dgSourceTeamMembership
      // 
      this.dgSourceTeamMembership.AllowUserToAddRows = false;
      this.dgSourceTeamMembership.AllowUserToDeleteRows = false;
      this.dgSourceTeamMembership.AllowUserToResizeRows = false;
      this.dgSourceTeamMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgSourceTeamMembership.AutoGenerateColumns = false;
      this.dgSourceTeamMembership.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgSourceTeamMembership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgSourceTeamMembership.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.sourceteamidDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn11,
            this.sourceuseridDataGridViewTextBoxColumn,
            this.sourceusernameDataGridViewTextBoxColumn,
            this.source_userisdisabled});
      this.dgSourceTeamMembership.DataSource = this.dtSourceTeamMembershipBindingSource;
      this.dgSourceTeamMembership.Location = new System.Drawing.Point(4, 28);
      this.dgSourceTeamMembership.Margin = new System.Windows.Forms.Padding(4);
      this.dgSourceTeamMembership.MultiSelect = false;
      this.dgSourceTeamMembership.Name = "dgSourceTeamMembership";
      this.dgSourceTeamMembership.ReadOnly = true;
      this.dgSourceTeamMembership.RowHeadersWidth = 51;
      this.dgSourceTeamMembership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgSourceTeamMembership.Size = new System.Drawing.Size(801, 341);
      this.dgSourceTeamMembership.TabIndex = 4;
      // 
      // sourceteamidDataGridViewTextBoxColumn2
      // 
      this.sourceteamidDataGridViewTextBoxColumn2.DataPropertyName = "source_teamid";
      this.sourceteamidDataGridViewTextBoxColumn2.HeaderText = "TeamId";
      this.sourceteamidDataGridViewTextBoxColumn2.MinimumWidth = 6;
      this.sourceteamidDataGridViewTextBoxColumn2.Name = "sourceteamidDataGridViewTextBoxColumn2";
      this.sourceteamidDataGridViewTextBoxColumn2.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn11
      // 
      this.dataGridViewTextBoxColumn11.DataPropertyName = "source_teamname";
      this.dataGridViewTextBoxColumn11.HeaderText = "Team Name";
      this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
      this.dataGridViewTextBoxColumn11.ReadOnly = true;
      // 
      // sourceuseridDataGridViewTextBoxColumn
      // 
      this.sourceuseridDataGridViewTextBoxColumn.DataPropertyName = "source_userid";
      this.sourceuseridDataGridViewTextBoxColumn.HeaderText = "UserId";
      this.sourceuseridDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourceuseridDataGridViewTextBoxColumn.Name = "sourceuseridDataGridViewTextBoxColumn";
      this.sourceuseridDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // sourceusernameDataGridViewTextBoxColumn
      // 
      this.sourceusernameDataGridViewTextBoxColumn.DataPropertyName = "source_username";
      this.sourceusernameDataGridViewTextBoxColumn.HeaderText = "User Name";
      this.sourceusernameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourceusernameDataGridViewTextBoxColumn.Name = "sourceusernameDataGridViewTextBoxColumn";
      this.sourceusernameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // source_userisdisabled
      // 
      this.source_userisdisabled.DataPropertyName = "source_userisdisabled";
      this.source_userisdisabled.HeaderText = "Is Disabled";
      this.source_userisdisabled.MinimumWidth = 6;
      this.source_userisdisabled.Name = "source_userisdisabled";
      this.source_userisdisabled.ReadOnly = true;
      // 
      // dtSourceTeamMembershipBindingSource
      // 
      this.dtSourceTeamMembershipBindingSource.DataMember = "dtSourceTeamMembership";
      this.dtSourceTeamMembershipBindingSource.DataSource = this.dsFSMigrationBindingSource;
      this.dtSourceTeamMembershipBindingSource.Sort = "source_username";
      // 
      // label15
      // 
      this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label15.BackColor = System.Drawing.Color.LightGray;
      this.label15.Location = new System.Drawing.Point(4, 2);
      this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label15.Name = "label15";
      this.label15.Size = new System.Drawing.Size(846, 25);
      this.label15.TabIndex = 7;
      this.label15.Text = "Target Membership";
      this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dgTargetTeamMembership
      // 
      this.dgTargetTeamMembership.AllowUserToAddRows = false;
      this.dgTargetTeamMembership.AllowUserToDeleteRows = false;
      this.dgTargetTeamMembership.AllowUserToResizeRows = false;
      this.dgTargetTeamMembership.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgTargetTeamMembership.AutoGenerateColumns = false;
      this.dgTargetTeamMembership.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgTargetTeamMembership.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTargetTeamMembership.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.target_teamid,
            this.target_teamname,
            this.targetuseridDataGridViewTextBoxColumn,
            this.target_username,
            this.target_userisdisabled});
      this.dgTargetTeamMembership.DataSource = this.dtTargetTeamMembershipBindingSource;
      this.dgTargetTeamMembership.Location = new System.Drawing.Point(4, 31);
      this.dgTargetTeamMembership.Margin = new System.Windows.Forms.Padding(4);
      this.dgTargetTeamMembership.MultiSelect = false;
      this.dgTargetTeamMembership.Name = "dgTargetTeamMembership";
      this.dgTargetTeamMembership.RowHeadersWidth = 51;
      this.dgTargetTeamMembership.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgTargetTeamMembership.Size = new System.Drawing.Size(846, 341);
      this.dgTargetTeamMembership.TabIndex = 6;
      // 
      // target_teamid
      // 
      this.target_teamid.DataPropertyName = "target_teamid";
      this.target_teamid.HeaderText = "TeamId";
      this.target_teamid.MinimumWidth = 6;
      this.target_teamid.Name = "target_teamid";
      this.target_teamid.ReadOnly = true;
      // 
      // target_teamname
      // 
      this.target_teamname.DataPropertyName = "target_teamname";
      this.target_teamname.HeaderText = "Team Name";
      this.target_teamname.MinimumWidth = 6;
      this.target_teamname.Name = "target_teamname";
      this.target_teamname.ReadOnly = true;
      // 
      // targetuseridDataGridViewTextBoxColumn
      // 
      this.targetuseridDataGridViewTextBoxColumn.DataPropertyName = "target_userid";
      this.targetuseridDataGridViewTextBoxColumn.HeaderText = "UserId";
      this.targetuseridDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetuseridDataGridViewTextBoxColumn.Name = "targetuseridDataGridViewTextBoxColumn";
      // 
      // target_username
      // 
      this.target_username.DataPropertyName = "target_username";
      this.target_username.HeaderText = "User Name";
      this.target_username.MinimumWidth = 6;
      this.target_username.Name = "target_username";
      // 
      // target_userisdisabled
      // 
      this.target_userisdisabled.DataPropertyName = "target_userisdisabled";
      this.target_userisdisabled.HeaderText = "Is Disabled";
      this.target_userisdisabled.MinimumWidth = 6;
      this.target_userisdisabled.Name = "target_userisdisabled";
      this.target_userisdisabled.ReadOnly = true;
      // 
      // dtTargetTeamMembershipBindingSource
      // 
      this.dtTargetTeamMembershipBindingSource.DataMember = "dtTargetTeamMembership";
      this.dtTargetTeamMembershipBindingSource.DataSource = this.dsFSMigrationBindingSource;
      this.dtTargetTeamMembershipBindingSource.Sort = "target_username";
      // 
      // btnTeamAddUserLoadTeams
      // 
      this.btnTeamAddUserLoadTeams.Location = new System.Drawing.Point(13, 10);
      this.btnTeamAddUserLoadTeams.Margin = new System.Windows.Forms.Padding(4);
      this.btnTeamAddUserLoadTeams.Name = "btnTeamAddUserLoadTeams";
      this.btnTeamAddUserLoadTeams.Size = new System.Drawing.Size(100, 28);
      this.btnTeamAddUserLoadTeams.TabIndex = 0;
      this.btnTeamAddUserLoadTeams.Text = "button1";
      this.btnTeamAddUserLoadTeams.UseVisualStyleBackColor = true;
      // 
      // tpTeamSecurity
      // 
      this.tpTeamSecurity.Controls.Add(this.scTeamSecurityMain);
      this.tpTeamSecurity.Controls.Add(this.ckClearTeamTargetRoles);
      this.tpTeamSecurity.Controls.Add(this.ckTeamSecurityCheckUncheck);
      this.tpTeamSecurity.Controls.Add(this.btnTeamSyncRoles);
      this.tpTeamSecurity.Controls.Add(this.btnCompareTeamSecurity);
      this.tpTeamSecurity.Location = new System.Drawing.Point(25, 4);
      this.tpTeamSecurity.Margin = new System.Windows.Forms.Padding(4);
      this.tpTeamSecurity.Name = "tpTeamSecurity";
      this.tpTeamSecurity.Size = new System.Drawing.Size(1671, 893);
      this.tpTeamSecurity.TabIndex = 6;
      this.tpTeamSecurity.Text = "Team Security";
      this.tpTeamSecurity.UseVisualStyleBackColor = true;
      // 
      // scTeamSecurityMain
      // 
      this.scTeamSecurityMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.scTeamSecurityMain.Location = new System.Drawing.Point(4, 49);
      this.scTeamSecurityMain.Margin = new System.Windows.Forms.Padding(4);
      this.scTeamSecurityMain.Name = "scTeamSecurityMain";
      this.scTeamSecurityMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // scTeamSecurityMain.Panel1
      // 
      this.scTeamSecurityMain.Panel1.Controls.Add(this.dgTeamSecurity);
      // 
      // scTeamSecurityMain.Panel2
      // 
      this.scTeamSecurityMain.Panel2.Controls.Add(this.scTeamSecurityRoles);
      this.scTeamSecurityMain.Size = new System.Drawing.Size(1596, 838);
      this.scTeamSecurityMain.SplitterDistance = 517;
      this.scTeamSecurityMain.SplitterWidth = 5;
      this.scTeamSecurityMain.TabIndex = 10;
      // 
      // dgTeamSecurity
      // 
      this.dgTeamSecurity.AllowUserToAddRows = false;
      this.dgTeamSecurity.AllowUserToDeleteRows = false;
      this.dgTeamSecurity.AutoGenerateColumns = false;
      this.dgTeamSecurity.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgTeamSecurity.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTeamSecurity.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rolesMatchDataGridViewCheckBoxColumn,
            this.syncRolesDataGridViewCheckBoxColumn,
            this.clearTargetRolesDataGridViewCheckBoxColumn,
            this.sourcebusinessunitidDataGridViewTextBoxColumn,
            this.sourcebunameDataGridViewTextBoxColumn1,
            this.sourceteamidDataGridViewTextBoxColumn,
            this.sourcenameDataGridViewTextBoxColumn,
            this.sourcerolenamesDataGridViewTextBoxColumn1,
            this.targetbusinessunitidDataGridViewTextBoxColumn,
            this.targetbunameDataGridViewTextBoxColumn1,
            this.targetteamidDataGridViewTextBoxColumn,
            this.targetnameDataGridViewTextBoxColumn,
            this.targetrolenamesDataGridViewTextBoxColumn1});
      this.dgTeamSecurity.DataMember = "dtTeamSecurityRoles";
      this.dgTeamSecurity.DataSource = this.dsFSMigrationBindingSource;
      this.dgTeamSecurity.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgTeamSecurity.Location = new System.Drawing.Point(0, 0);
      this.dgTeamSecurity.Margin = new System.Windows.Forms.Padding(4);
      this.dgTeamSecurity.MultiSelect = false;
      this.dgTeamSecurity.Name = "dgTeamSecurity";
      this.dgTeamSecurity.ReadOnly = true;
      this.dgTeamSecurity.RowHeadersWidth = 51;
      this.dgTeamSecurity.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgTeamSecurity.Size = new System.Drawing.Size(1596, 517);
      this.dgTeamSecurity.TabIndex = 0;
      this.dgTeamSecurity.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgTeamSecurity_DataError);
      this.dgTeamSecurity.SelectionChanged += new System.EventHandler(this.dgTeamSecurity_SelectionChanged);
      // 
      // rolesMatchDataGridViewCheckBoxColumn
      // 
      this.rolesMatchDataGridViewCheckBoxColumn.DataPropertyName = "RolesMatch";
      this.rolesMatchDataGridViewCheckBoxColumn.HeaderText = "RolesMatch";
      this.rolesMatchDataGridViewCheckBoxColumn.MinimumWidth = 6;
      this.rolesMatchDataGridViewCheckBoxColumn.Name = "rolesMatchDataGridViewCheckBoxColumn";
      this.rolesMatchDataGridViewCheckBoxColumn.ReadOnly = true;
      this.rolesMatchDataGridViewCheckBoxColumn.Visible = false;
      // 
      // syncRolesDataGridViewCheckBoxColumn
      // 
      this.syncRolesDataGridViewCheckBoxColumn.DataPropertyName = "SyncRoles";
      this.syncRolesDataGridViewCheckBoxColumn.HeaderText = "SyncRoles";
      this.syncRolesDataGridViewCheckBoxColumn.MinimumWidth = 6;
      this.syncRolesDataGridViewCheckBoxColumn.Name = "syncRolesDataGridViewCheckBoxColumn";
      this.syncRolesDataGridViewCheckBoxColumn.ReadOnly = true;
      // 
      // clearTargetRolesDataGridViewCheckBoxColumn
      // 
      this.clearTargetRolesDataGridViewCheckBoxColumn.DataPropertyName = "ClearTargetRoles";
      this.clearTargetRolesDataGridViewCheckBoxColumn.HeaderText = "ClearTargetRoles";
      this.clearTargetRolesDataGridViewCheckBoxColumn.MinimumWidth = 6;
      this.clearTargetRolesDataGridViewCheckBoxColumn.Name = "clearTargetRolesDataGridViewCheckBoxColumn";
      this.clearTargetRolesDataGridViewCheckBoxColumn.ReadOnly = true;
      // 
      // sourcebusinessunitidDataGridViewTextBoxColumn
      // 
      this.sourcebusinessunitidDataGridViewTextBoxColumn.DataPropertyName = "source_businessunitid";
      this.sourcebusinessunitidDataGridViewTextBoxColumn.HeaderText = "source_businessunitid";
      this.sourcebusinessunitidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcebusinessunitidDataGridViewTextBoxColumn.Name = "sourcebusinessunitidDataGridViewTextBoxColumn";
      this.sourcebusinessunitidDataGridViewTextBoxColumn.ReadOnly = true;
      this.sourcebusinessunitidDataGridViewTextBoxColumn.Visible = false;
      // 
      // sourcebunameDataGridViewTextBoxColumn1
      // 
      this.sourcebunameDataGridViewTextBoxColumn1.DataPropertyName = "source_buname";
      this.sourcebunameDataGridViewTextBoxColumn1.HeaderText = "source_buname";
      this.sourcebunameDataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.sourcebunameDataGridViewTextBoxColumn1.Name = "sourcebunameDataGridViewTextBoxColumn1";
      this.sourcebunameDataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // sourceteamidDataGridViewTextBoxColumn
      // 
      this.sourceteamidDataGridViewTextBoxColumn.DataPropertyName = "source_teamid";
      this.sourceteamidDataGridViewTextBoxColumn.HeaderText = "source_teamid";
      this.sourceteamidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourceteamidDataGridViewTextBoxColumn.Name = "sourceteamidDataGridViewTextBoxColumn";
      this.sourceteamidDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // sourcenameDataGridViewTextBoxColumn
      // 
      this.sourcenameDataGridViewTextBoxColumn.DataPropertyName = "source_name";
      this.sourcenameDataGridViewTextBoxColumn.HeaderText = "source_name";
      this.sourcenameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcenameDataGridViewTextBoxColumn.Name = "sourcenameDataGridViewTextBoxColumn";
      this.sourcenameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // sourcerolenamesDataGridViewTextBoxColumn1
      // 
      this.sourcerolenamesDataGridViewTextBoxColumn1.DataPropertyName = "source_rolenames";
      this.sourcerolenamesDataGridViewTextBoxColumn1.HeaderText = "source_rolenames";
      this.sourcerolenamesDataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.sourcerolenamesDataGridViewTextBoxColumn1.Name = "sourcerolenamesDataGridViewTextBoxColumn1";
      this.sourcerolenamesDataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // targetbusinessunitidDataGridViewTextBoxColumn
      // 
      this.targetbusinessunitidDataGridViewTextBoxColumn.DataPropertyName = "target_businessunitid";
      this.targetbusinessunitidDataGridViewTextBoxColumn.HeaderText = "target_businessunitid";
      this.targetbusinessunitidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetbusinessunitidDataGridViewTextBoxColumn.Name = "targetbusinessunitidDataGridViewTextBoxColumn";
      this.targetbusinessunitidDataGridViewTextBoxColumn.ReadOnly = true;
      this.targetbusinessunitidDataGridViewTextBoxColumn.Visible = false;
      // 
      // targetbunameDataGridViewTextBoxColumn1
      // 
      this.targetbunameDataGridViewTextBoxColumn1.DataPropertyName = "target_buname";
      this.targetbunameDataGridViewTextBoxColumn1.HeaderText = "target_buname";
      this.targetbunameDataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.targetbunameDataGridViewTextBoxColumn1.Name = "targetbunameDataGridViewTextBoxColumn1";
      this.targetbunameDataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // targetteamidDataGridViewTextBoxColumn
      // 
      this.targetteamidDataGridViewTextBoxColumn.DataPropertyName = "target_teamid";
      this.targetteamidDataGridViewTextBoxColumn.HeaderText = "target_teamid";
      this.targetteamidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetteamidDataGridViewTextBoxColumn.Name = "targetteamidDataGridViewTextBoxColumn";
      this.targetteamidDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // targetnameDataGridViewTextBoxColumn
      // 
      this.targetnameDataGridViewTextBoxColumn.DataPropertyName = "target_name";
      this.targetnameDataGridViewTextBoxColumn.HeaderText = "target_name";
      this.targetnameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.targetnameDataGridViewTextBoxColumn.Name = "targetnameDataGridViewTextBoxColumn";
      this.targetnameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // targetrolenamesDataGridViewTextBoxColumn1
      // 
      this.targetrolenamesDataGridViewTextBoxColumn1.DataPropertyName = "target_rolenames";
      this.targetrolenamesDataGridViewTextBoxColumn1.HeaderText = "target_rolenames";
      this.targetrolenamesDataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.targetrolenamesDataGridViewTextBoxColumn1.Name = "targetrolenamesDataGridViewTextBoxColumn1";
      this.targetrolenamesDataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // scTeamSecurityRoles
      // 
      this.scTeamSecurityRoles.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scTeamSecurityRoles.Location = new System.Drawing.Point(0, 0);
      this.scTeamSecurityRoles.Margin = new System.Windows.Forms.Padding(4);
      this.scTeamSecurityRoles.Name = "scTeamSecurityRoles";
      // 
      // scTeamSecurityRoles.Panel1
      // 
      this.scTeamSecurityRoles.Panel1.Controls.Add(this.label11);
      this.scTeamSecurityRoles.Panel1.Controls.Add(this.dgSourceTeamRoles);
      // 
      // scTeamSecurityRoles.Panel2
      // 
      this.scTeamSecurityRoles.Panel2.Controls.Add(this.label12);
      this.scTeamSecurityRoles.Panel2.Controls.Add(this.dgTargetTeamRoles);
      this.scTeamSecurityRoles.Size = new System.Drawing.Size(1596, 316);
      this.scTeamSecurityRoles.SplitterDistance = 774;
      this.scTeamSecurityRoles.SplitterWidth = 5;
      this.scTeamSecurityRoles.TabIndex = 0;
      // 
      // label11
      // 
      this.label11.BackColor = System.Drawing.Color.LightGray;
      this.label11.Dock = System.Windows.Forms.DockStyle.Top;
      this.label11.Location = new System.Drawing.Point(0, 0);
      this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label11.Name = "label11";
      this.label11.Size = new System.Drawing.Size(774, 20);
      this.label11.TabIndex = 3;
      this.label11.Text = "Source User Roles";
      this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dgSourceTeamRoles
      // 
      this.dgSourceTeamRoles.AllowUserToAddRows = false;
      this.dgSourceTeamRoles.AllowUserToDeleteRows = false;
      this.dgSourceTeamRoles.AllowUserToResizeRows = false;
      this.dgSourceTeamRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgSourceTeamRoles.AutoGenerateColumns = false;
      this.dgSourceTeamRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgSourceTeamRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgSourceTeamRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn7,
            this.dataGridViewTextBoxColumn8});
      this.dgSourceTeamRoles.DataMember = "dtSourceTeamSecurityRoles";
      this.dgSourceTeamRoles.DataSource = this.dsFSMigrationBindingSource;
      this.dgSourceTeamRoles.Location = new System.Drawing.Point(0, 23);
      this.dgSourceTeamRoles.Margin = new System.Windows.Forms.Padding(4);
      this.dgSourceTeamRoles.MultiSelect = false;
      this.dgSourceTeamRoles.Name = "dgSourceTeamRoles";
      this.dgSourceTeamRoles.ReadOnly = true;
      this.dgSourceTeamRoles.RowHeadersWidth = 51;
      this.dgSourceTeamRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgSourceTeamRoles.Size = new System.Drawing.Size(771, 289);
      this.dgSourceTeamRoles.TabIndex = 2;
      // 
      // dataGridViewTextBoxColumn7
      // 
      this.dataGridViewTextBoxColumn7.DataPropertyName = "roleid";
      this.dataGridViewTextBoxColumn7.HeaderText = "Role Id";
      this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
      this.dataGridViewTextBoxColumn7.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn8
      // 
      this.dataGridViewTextBoxColumn8.DataPropertyName = "rolename";
      this.dataGridViewTextBoxColumn8.HeaderText = "Role Name";
      this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
      this.dataGridViewTextBoxColumn8.ReadOnly = true;
      // 
      // label12
      // 
      this.label12.BackColor = System.Drawing.Color.LightGray;
      this.label12.Dock = System.Windows.Forms.DockStyle.Top;
      this.label12.Location = new System.Drawing.Point(0, 0);
      this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label12.Name = "label12";
      this.label12.Size = new System.Drawing.Size(817, 20);
      this.label12.TabIndex = 5;
      this.label12.Text = "Target User Roles";
      this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // dgTargetTeamRoles
      // 
      this.dgTargetTeamRoles.AllowUserToAddRows = false;
      this.dgTargetTeamRoles.AllowUserToDeleteRows = false;
      this.dgTargetTeamRoles.AllowUserToResizeRows = false;
      dataGridViewCellStyle10.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgTargetTeamRoles.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle10;
      this.dgTargetTeamRoles.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgTargetTeamRoles.AutoGenerateColumns = false;
      this.dgTargetTeamRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgTargetTeamRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgTargetTeamRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10});
      this.dgTargetTeamRoles.DataMember = "dtTargetTeamSecurityRoles";
      this.dgTargetTeamRoles.DataSource = this.dsFSMigrationBindingSource;
      this.dgTargetTeamRoles.Location = new System.Drawing.Point(7, 23);
      this.dgTargetTeamRoles.Margin = new System.Windows.Forms.Padding(4);
      this.dgTargetTeamRoles.MultiSelect = false;
      this.dgTargetTeamRoles.Name = "dgTargetTeamRoles";
      this.dgTargetTeamRoles.ReadOnly = true;
      this.dgTargetTeamRoles.RowHeadersWidth = 51;
      this.dgTargetTeamRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgTargetTeamRoles.Size = new System.Drawing.Size(803, 291);
      this.dgTargetTeamRoles.TabIndex = 4;
      // 
      // dataGridViewTextBoxColumn9
      // 
      this.dataGridViewTextBoxColumn9.DataPropertyName = "roleid";
      this.dataGridViewTextBoxColumn9.HeaderText = "Role Id";
      this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
      this.dataGridViewTextBoxColumn9.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn10
      // 
      this.dataGridViewTextBoxColumn10.DataPropertyName = "rolename";
      this.dataGridViewTextBoxColumn10.HeaderText = "Role Name";
      this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
      this.dataGridViewTextBoxColumn10.ReadOnly = true;
      // 
      // ckClearTeamTargetRoles
      // 
      this.ckClearTeamTargetRoles.AutoSize = true;
      this.ckClearTeamTargetRoles.Checked = true;
      this.ckClearTeamTargetRoles.CheckState = System.Windows.Forms.CheckState.Checked;
      this.ckClearTeamTargetRoles.Location = new System.Drawing.Point(700, 18);
      this.ckClearTeamTargetRoles.Margin = new System.Windows.Forms.Padding(4);
      this.ckClearTeamTargetRoles.Name = "ckClearTeamTargetRoles";
      this.ckClearTeamTargetRoles.Size = new System.Drawing.Size(262, 21);
      this.ckClearTeamTargetRoles.TabIndex = 9;
      this.ckClearTeamTargetRoles.Text = "Clear Target Roles: Check Un-Check";
      this.ckClearTeamTargetRoles.UseVisualStyleBackColor = true;
      this.ckClearTeamTargetRoles.CheckedChanged += new System.EventHandler(this.ckClearTeamTargetRoles_CheckedChanged);
      // 
      // ckTeamSecurityCheckUncheck
      // 
      this.ckTeamSecurityCheckUncheck.AutoSize = true;
      this.ckTeamSecurityCheckUncheck.Location = new System.Drawing.Point(425, 18);
      this.ckTeamSecurityCheckUncheck.Margin = new System.Windows.Forms.Padding(4);
      this.ckTeamSecurityCheckUncheck.Name = "ckTeamSecurityCheckUncheck";
      this.ckTeamSecurityCheckUncheck.Size = new System.Drawing.Size(222, 21);
      this.ckTeamSecurityCheckUncheck.TabIndex = 8;
      this.ckTeamSecurityCheckUncheck.Text = "Sync Roles: Check / Un-Check";
      this.ckTeamSecurityCheckUncheck.UseVisualStyleBackColor = true;
      this.ckTeamSecurityCheckUncheck.CheckedChanged += new System.EventHandler(this.ckTeamSecurityCheckUncheck_CheckedChanged);
      // 
      // btnTeamSyncRoles
      // 
      this.btnTeamSyncRoles.Location = new System.Drawing.Point(212, 14);
      this.btnTeamSyncRoles.Margin = new System.Windows.Forms.Padding(4);
      this.btnTeamSyncRoles.Name = "btnTeamSyncRoles";
      this.btnTeamSyncRoles.Size = new System.Drawing.Size(188, 28);
      this.btnTeamSyncRoles.TabIndex = 6;
      this.btnTeamSyncRoles.Text = "Sync Team Roles";
      this.btnTeamSyncRoles.UseVisualStyleBackColor = true;
      this.btnTeamSyncRoles.Click += new System.EventHandler(this.btnTeamSyncRoles_Click);
      // 
      // btnCompareTeamSecurity
      // 
      this.btnCompareTeamSecurity.Location = new System.Drawing.Point(16, 14);
      this.btnCompareTeamSecurity.Margin = new System.Windows.Forms.Padding(4);
      this.btnCompareTeamSecurity.Name = "btnCompareTeamSecurity";
      this.btnCompareTeamSecurity.Size = new System.Drawing.Size(188, 28);
      this.btnCompareTeamSecurity.TabIndex = 7;
      this.btnCompareTeamSecurity.Text = "Compare Team Security";
      this.btnCompareTeamSecurity.UseVisualStyleBackColor = true;
      this.btnCompareTeamSecurity.Click += new System.EventHandler(this.btnCompareTeamSecurity_Click);
      // 
      // tpUOMSync
      // 
      this.tpUOMSync.Controls.Add(this.splitContainerUOM);
      this.tpUOMSync.Location = new System.Drawing.Point(25, 4);
      this.tpUOMSync.Margin = new System.Windows.Forms.Padding(4);
      this.tpUOMSync.Name = "tpUOMSync";
      this.tpUOMSync.Size = new System.Drawing.Size(1671, 893);
      this.tpUOMSync.TabIndex = 7;
      this.tpUOMSync.Text = "UOM Sync";
      this.tpUOMSync.UseVisualStyleBackColor = true;
      // 
      // splitContainerUOM
      // 
      this.splitContainerUOM.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerUOM.Location = new System.Drawing.Point(0, 0);
      this.splitContainerUOM.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainerUOM.Name = "splitContainerUOM";
      this.splitContainerUOM.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainerUOM.Panel1
      // 
      this.splitContainerUOM.Panel1.Controls.Add(this.panel1);
      this.splitContainerUOM.Panel1.Controls.Add(this.dgUOMSchedule);
      this.splitContainerUOM.Panel1.Controls.Add(this.btnCreateTargetUOMSchedule);
      this.splitContainerUOM.Panel1.Controls.Add(this.btnMapUOMSchedule);
      // 
      // splitContainerUOM.Panel2
      // 
      this.splitContainerUOM.Panel2.Controls.Add(this.panel2);
      this.splitContainerUOM.Panel2.Controls.Add(this.dgUOM);
      this.splitContainerUOM.Panel2.Controls.Add(this.btnCreateTargetUOM);
      this.splitContainerUOM.Panel2.Controls.Add(this.btnMapUOM);
      this.splitContainerUOM.Size = new System.Drawing.Size(1671, 893);
      this.splitContainerUOM.SplitterDistance = 373;
      this.splitContainerUOM.SplitterWidth = 5;
      this.splitContainerUOM.TabIndex = 5;
      // 
      // panel1
      // 
      this.panel1.Controls.Add(this.label20);
      this.panel1.Location = new System.Drawing.Point(264, 153);
      this.panel1.Margin = new System.Windows.Forms.Padding(4);
      this.panel1.Name = "panel1";
      this.panel1.Size = new System.Drawing.Size(773, 177);
      this.panel1.TabIndex = 7;
      // 
      // label20
      // 
      this.label20.Location = new System.Drawing.Point(240, 73);
      this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label20.Name = "label20";
      this.label20.Size = new System.Drawing.Size(235, 22);
      this.label20.TabIndex = 0;
      this.label20.Text = "NOT IMPLEMENTED";
      // 
      // dgUOMSchedule
      // 
      this.dgUOMSchedule.AllowUserToAddRows = false;
      this.dgUOMSchedule.AllowUserToDeleteRows = false;
      this.dgUOMSchedule.AllowUserToResizeColumns = false;
      this.dgUOMSchedule.AllowUserToResizeRows = false;
      dataGridViewCellStyle11.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgUOMSchedule.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle11;
      this.dgUOMSchedule.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgUOMSchedule.AutoGenerateColumns = false;
      this.dgUOMSchedule.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgUOMSchedule.ColumnHeadersHeight = 29;
      this.dgUOMSchedule.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn8,
            this.dataGridViewCheckBoxColumn9,
            this.sourcecreatedbyDataGridViewTextBoxColumn,
            this.sourcecreatedonDataGridViewTextBoxColumn,
            this.dataGridViewTextBoxColumn23,
            this.sourcenameDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn21,
            this.dataGridViewTextBoxColumn27,
            this.targetnameDataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn25});
      this.dgUOMSchedule.DataMember = "dtUOMScheduleMapping";
      this.dgUOMSchedule.DataSource = this.dsFSMigrationBindingSource;
      this.dgUOMSchedule.Location = new System.Drawing.Point(4, 42);
      this.dgUOMSchedule.Margin = new System.Windows.Forms.Padding(4);
      this.dgUOMSchedule.MultiSelect = false;
      this.dgUOMSchedule.Name = "dgUOMSchedule";
      this.dgUOMSchedule.RowHeadersWidth = 51;
      this.dgUOMSchedule.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgUOMSchedule.Size = new System.Drawing.Size(1663, 326);
      this.dgUOMSchedule.TabIndex = 2;
      this.dgUOMSchedule.VirtualMode = true;
      // 
      // dataGridViewCheckBoxColumn8
      // 
      this.dataGridViewCheckBoxColumn8.DataPropertyName = "IsInTarget";
      this.dataGridViewCheckBoxColumn8.HeaderText = "In Target";
      this.dataGridViewCheckBoxColumn8.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn8.Name = "dataGridViewCheckBoxColumn8";
      this.dataGridViewCheckBoxColumn8.ReadOnly = true;
      // 
      // dataGridViewCheckBoxColumn9
      // 
      this.dataGridViewCheckBoxColumn9.DataPropertyName = "AddToTarget";
      this.dataGridViewCheckBoxColumn9.HeaderText = "Add To Target";
      this.dataGridViewCheckBoxColumn9.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn9.Name = "dataGridViewCheckBoxColumn9";
      // 
      // sourcecreatedbyDataGridViewTextBoxColumn
      // 
      this.sourcecreatedbyDataGridViewTextBoxColumn.DataPropertyName = "source_createdby";
      this.sourcecreatedbyDataGridViewTextBoxColumn.HeaderText = "source_createdby";
      this.sourcecreatedbyDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcecreatedbyDataGridViewTextBoxColumn.Name = "sourcecreatedbyDataGridViewTextBoxColumn";
      this.sourcecreatedbyDataGridViewTextBoxColumn.Visible = false;
      // 
      // sourcecreatedonDataGridViewTextBoxColumn
      // 
      this.sourcecreatedonDataGridViewTextBoxColumn.DataPropertyName = "source_createdon";
      this.sourcecreatedonDataGridViewTextBoxColumn.HeaderText = "source_createdon";
      this.sourcecreatedonDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.sourcecreatedonDataGridViewTextBoxColumn.Name = "sourcecreatedonDataGridViewTextBoxColumn";
      this.sourcecreatedonDataGridViewTextBoxColumn.Visible = false;
      // 
      // dataGridViewTextBoxColumn23
      // 
      this.dataGridViewTextBoxColumn23.DataPropertyName = "source_uomscheduleid";
      this.dataGridViewTextBoxColumn23.HeaderText = "source UOM Schedule ID";
      this.dataGridViewTextBoxColumn23.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
      this.dataGridViewTextBoxColumn23.ReadOnly = true;
      // 
      // sourcenameDataGridViewTextBoxColumn2
      // 
      this.sourcenameDataGridViewTextBoxColumn2.DataPropertyName = "source_name";
      this.sourcenameDataGridViewTextBoxColumn2.HeaderText = "source Name";
      this.sourcenameDataGridViewTextBoxColumn2.MinimumWidth = 6;
      this.sourcenameDataGridViewTextBoxColumn2.Name = "sourcenameDataGridViewTextBoxColumn2";
      this.sourcenameDataGridViewTextBoxColumn2.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn21
      // 
      this.dataGridViewTextBoxColumn21.DataPropertyName = "source_organizationid";
      this.dataGridViewTextBoxColumn21.HeaderText = "source Org ID";
      this.dataGridViewTextBoxColumn21.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
      this.dataGridViewTextBoxColumn21.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn27
      // 
      this.dataGridViewTextBoxColumn27.DataPropertyName = "target_uomscheduleid";
      this.dataGridViewTextBoxColumn27.HeaderText = "target UOM Schedule ID";
      this.dataGridViewTextBoxColumn27.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
      this.dataGridViewTextBoxColumn27.ReadOnly = true;
      // 
      // targetnameDataGridViewTextBoxColumn2
      // 
      this.targetnameDataGridViewTextBoxColumn2.DataPropertyName = "target_name";
      this.targetnameDataGridViewTextBoxColumn2.HeaderText = "target Name";
      this.targetnameDataGridViewTextBoxColumn2.MinimumWidth = 6;
      this.targetnameDataGridViewTextBoxColumn2.Name = "targetnameDataGridViewTextBoxColumn2";
      this.targetnameDataGridViewTextBoxColumn2.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn25
      // 
      this.dataGridViewTextBoxColumn25.DataPropertyName = "target_organizationid";
      this.dataGridViewTextBoxColumn25.HeaderText = "target Org ID";
      this.dataGridViewTextBoxColumn25.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
      this.dataGridViewTextBoxColumn25.ReadOnly = true;
      // 
      // btnCreateTargetUOMSchedule
      // 
      this.btnCreateTargetUOMSchedule.Enabled = false;
      this.btnCreateTargetUOMSchedule.Location = new System.Drawing.Point(179, 6);
      this.btnCreateTargetUOMSchedule.Margin = new System.Windows.Forms.Padding(4);
      this.btnCreateTargetUOMSchedule.Name = "btnCreateTargetUOMSchedule";
      this.btnCreateTargetUOMSchedule.Size = new System.Drawing.Size(272, 28);
      this.btnCreateTargetUOMSchedule.TabIndex = 4;
      this.btnCreateTargetUOMSchedule.Text = "Create Target UOM Schedule";
      this.btnCreateTargetUOMSchedule.UseVisualStyleBackColor = true;
      this.btnCreateTargetUOMSchedule.Click += new System.EventHandler(this.btnCreateTargetUOMSchedule_Click);
      // 
      // btnMapUOMSchedule
      // 
      this.btnMapUOMSchedule.Enabled = false;
      this.btnMapUOMSchedule.Location = new System.Drawing.Point(4, 6);
      this.btnMapUOMSchedule.Margin = new System.Windows.Forms.Padding(4);
      this.btnMapUOMSchedule.Name = "btnMapUOMSchedule";
      this.btnMapUOMSchedule.Size = new System.Drawing.Size(167, 28);
      this.btnMapUOMSchedule.TabIndex = 6;
      this.btnMapUOMSchedule.Text = "Map UOM Schedule";
      this.btnMapUOMSchedule.UseVisualStyleBackColor = true;
      this.btnMapUOMSchedule.Click += new System.EventHandler(this.btnMapUOMSchedule_Click);
      // 
      // panel2
      // 
      this.panel2.Controls.Add(this.label21);
      this.panel2.Location = new System.Drawing.Point(264, 143);
      this.panel2.Margin = new System.Windows.Forms.Padding(4);
      this.panel2.Name = "panel2";
      this.panel2.Size = new System.Drawing.Size(773, 177);
      this.panel2.TabIndex = 8;
      // 
      // label21
      // 
      this.label21.Location = new System.Drawing.Point(240, 73);
      this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label21.Name = "label21";
      this.label21.Size = new System.Drawing.Size(235, 22);
      this.label21.TabIndex = 0;
      this.label21.Text = "NOT IMPLEMENTED";
      // 
      // dgUOM
      // 
      this.dgUOM.AllowUserToAddRows = false;
      this.dgUOM.AllowUserToDeleteRows = false;
      this.dgUOM.AllowUserToResizeColumns = false;
      this.dgUOM.AllowUserToResizeRows = false;
      dataGridViewCellStyle12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
      this.dgUOM.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle12;
      this.dgUOM.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgUOM.AutoGenerateColumns = false;
      this.dgUOM.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgUOM.ColumnHeadersHeight = 29;
      this.dgUOM.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewCheckBoxColumn11,
            this.dataGridViewCheckBoxColumn12,
            this.dataGridViewTextBoxColumn28,
            this.dataGridViewTextBoxColumn29,
            this.dataGridViewTextBoxColumn30,
            this.dataGridViewCheckBoxColumn10,
            this.dataGridViewTextBoxColumn31,
            this.dataGridViewTextBoxColumn32,
            this.dataGridViewTextBoxColumn33,
            this.dataGridViewTextBoxColumn34,
            this.dataGridViewTextBoxColumn35,
            this.dataGridViewTextBoxColumn36,
            this.dataGridViewTextBoxColumn37,
            this.dataGridViewTextBoxColumn38,
            this.dataGridViewTextBoxColumn39});
      this.dgUOM.DataMember = "dtUOMMapping";
      this.dgUOM.DataSource = this.dsFSMigrationBindingSource;
      this.dgUOM.Location = new System.Drawing.Point(4, 44);
      this.dgUOM.Margin = new System.Windows.Forms.Padding(4);
      this.dgUOM.MultiSelect = false;
      this.dgUOM.Name = "dgUOM";
      this.dgUOM.RowHeadersWidth = 51;
      this.dgUOM.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgUOM.Size = new System.Drawing.Size(1663, 464);
      this.dgUOM.TabIndex = 5;
      this.dgUOM.VirtualMode = true;
      // 
      // dataGridViewCheckBoxColumn11
      // 
      this.dataGridViewCheckBoxColumn11.DataPropertyName = "IsInTarget";
      this.dataGridViewCheckBoxColumn11.HeaderText = "In Target";
      this.dataGridViewCheckBoxColumn11.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn11.Name = "dataGridViewCheckBoxColumn11";
      this.dataGridViewCheckBoxColumn11.ReadOnly = true;
      // 
      // dataGridViewCheckBoxColumn12
      // 
      this.dataGridViewCheckBoxColumn12.DataPropertyName = "AddToTarget";
      this.dataGridViewCheckBoxColumn12.HeaderText = "Add To Target";
      this.dataGridViewCheckBoxColumn12.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn12.Name = "dataGridViewCheckBoxColumn12";
      // 
      // dataGridViewTextBoxColumn28
      // 
      this.dataGridViewTextBoxColumn28.DataPropertyName = "source_uomid";
      this.dataGridViewTextBoxColumn28.HeaderText = "Source UOM ID";
      this.dataGridViewTextBoxColumn28.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
      this.dataGridViewTextBoxColumn28.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn29
      // 
      this.dataGridViewTextBoxColumn29.DataPropertyName = "source_createdby";
      this.dataGridViewTextBoxColumn29.HeaderText = "source_createdby";
      this.dataGridViewTextBoxColumn29.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
      this.dataGridViewTextBoxColumn29.Visible = false;
      // 
      // dataGridViewTextBoxColumn30
      // 
      this.dataGridViewTextBoxColumn30.DataPropertyName = "source_createdon";
      this.dataGridViewTextBoxColumn30.HeaderText = "source_createdon";
      this.dataGridViewTextBoxColumn30.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
      this.dataGridViewTextBoxColumn30.Visible = false;
      // 
      // dataGridViewCheckBoxColumn10
      // 
      this.dataGridViewCheckBoxColumn10.DataPropertyName = "source_isschedulebaseuom";
      this.dataGridViewCheckBoxColumn10.HeaderText = "source Is Schedule Base UOM";
      this.dataGridViewCheckBoxColumn10.MinimumWidth = 6;
      this.dataGridViewCheckBoxColumn10.Name = "dataGridViewCheckBoxColumn10";
      this.dataGridViewCheckBoxColumn10.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn31
      // 
      this.dataGridViewTextBoxColumn31.DataPropertyName = "source_name";
      this.dataGridViewTextBoxColumn31.HeaderText = "source Name";
      this.dataGridViewTextBoxColumn31.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
      this.dataGridViewTextBoxColumn31.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn32
      // 
      this.dataGridViewTextBoxColumn32.DataPropertyName = "source_organizationid";
      this.dataGridViewTextBoxColumn32.HeaderText = "source Org ID";
      this.dataGridViewTextBoxColumn32.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
      this.dataGridViewTextBoxColumn32.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn33
      // 
      this.dataGridViewTextBoxColumn33.DataPropertyName = "source_quantity";
      this.dataGridViewTextBoxColumn33.HeaderText = "source Qty";
      this.dataGridViewTextBoxColumn33.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
      this.dataGridViewTextBoxColumn33.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn34
      // 
      this.dataGridViewTextBoxColumn34.DataPropertyName = "source_uomscheduleid";
      this.dataGridViewTextBoxColumn34.HeaderText = "source UOM Schedule ID";
      this.dataGridViewTextBoxColumn34.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
      this.dataGridViewTextBoxColumn34.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn35
      // 
      this.dataGridViewTextBoxColumn35.DataPropertyName = "target_uomid";
      this.dataGridViewTextBoxColumn35.HeaderText = "target UOM ID";
      this.dataGridViewTextBoxColumn35.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
      this.dataGridViewTextBoxColumn35.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn36
      // 
      this.dataGridViewTextBoxColumn36.DataPropertyName = "target_name";
      this.dataGridViewTextBoxColumn36.HeaderText = "target Name";
      this.dataGridViewTextBoxColumn36.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
      // 
      // dataGridViewTextBoxColumn37
      // 
      this.dataGridViewTextBoxColumn37.DataPropertyName = "target_organizationid";
      this.dataGridViewTextBoxColumn37.HeaderText = "target Org ID";
      this.dataGridViewTextBoxColumn37.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
      this.dataGridViewTextBoxColumn37.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn38
      // 
      this.dataGridViewTextBoxColumn38.DataPropertyName = "target_quantity";
      this.dataGridViewTextBoxColumn38.HeaderText = "target Qty";
      this.dataGridViewTextBoxColumn38.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
      this.dataGridViewTextBoxColumn38.ReadOnly = true;
      // 
      // dataGridViewTextBoxColumn39
      // 
      this.dataGridViewTextBoxColumn39.DataPropertyName = "target_uomscheduleid";
      this.dataGridViewTextBoxColumn39.HeaderText = "target UOM Schedule ID";
      this.dataGridViewTextBoxColumn39.MinimumWidth = 6;
      this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
      this.dataGridViewTextBoxColumn39.ReadOnly = true;
      // 
      // btnCreateTargetUOM
      // 
      this.btnCreateTargetUOM.Enabled = false;
      this.btnCreateTargetUOM.Location = new System.Drawing.Point(179, 9);
      this.btnCreateTargetUOM.Margin = new System.Windows.Forms.Padding(4);
      this.btnCreateTargetUOM.Name = "btnCreateTargetUOM";
      this.btnCreateTargetUOM.Size = new System.Drawing.Size(204, 28);
      this.btnCreateTargetUOM.TabIndex = 7;
      this.btnCreateTargetUOM.Text = "Create Target UOM";
      this.btnCreateTargetUOM.UseVisualStyleBackColor = true;
      // 
      // btnMapUOM
      // 
      this.btnMapUOM.Enabled = false;
      this.btnMapUOM.Location = new System.Drawing.Point(4, 9);
      this.btnMapUOM.Margin = new System.Windows.Forms.Padding(4);
      this.btnMapUOM.Name = "btnMapUOM";
      this.btnMapUOM.Size = new System.Drawing.Size(167, 28);
      this.btnMapUOM.TabIndex = 3;
      this.btnMapUOM.Text = "Map UOM";
      this.btnMapUOM.UseVisualStyleBackColor = true;
      this.btnMapUOM.Click += new System.EventHandler(this.btnMapUOM_Click);
      // 
      // tpDataCleanup
      // 
      this.tpDataCleanup.Controls.Add(this.splitContainer6);
      this.tpDataCleanup.Controls.Add(this.btnDataCleanupCreateTestData);
      this.tpDataCleanup.Controls.Add(this.btnDataCleanupDeleteRecords);
      this.tpDataCleanup.Controls.Add(this.label10);
      this.tpDataCleanup.Controls.Add(this.txtDataCleanupTargetAttribute);
      this.tpDataCleanup.Controls.Add(this.label9);
      this.tpDataCleanup.Controls.Add(this.txtDataCleanupSourceAttribute);
      this.tpDataCleanup.Controls.Add(this.btnDataCleanupLoadTargetEntities);
      this.tpDataCleanup.Controls.Add(this.btnDataCleanupLoadSourceEntities);
      this.tpDataCleanup.Controls.Add(this.cbDataCleanupTargetEntityList);
      this.tpDataCleanup.Controls.Add(this.label8);
      this.tpDataCleanup.Controls.Add(this.btnDataCleanupValidateRecords);
      this.tpDataCleanup.Controls.Add(this.cbDataCleanupSourceEntityList);
      this.tpDataCleanup.Controls.Add(this.label7);
      this.tpDataCleanup.Controls.Add(this.label6);
      this.tpDataCleanup.Location = new System.Drawing.Point(4, 25);
      this.tpDataCleanup.Margin = new System.Windows.Forms.Padding(4);
      this.tpDataCleanup.Name = "tpDataCleanup";
      this.tpDataCleanup.Padding = new System.Windows.Forms.Padding(4);
      this.tpDataCleanup.Size = new System.Drawing.Size(1700, 901);
      this.tpDataCleanup.TabIndex = 6;
      this.tpDataCleanup.Text = "Data Cleanup";
      this.tpDataCleanup.UseVisualStyleBackColor = true;
      // 
      // splitContainer6
      // 
      this.splitContainer6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer6.Location = new System.Drawing.Point(13, 85);
      this.splitContainer6.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer6.Name = "splitContainer6";
      // 
      // splitContainer6.Panel1
      // 
      this.splitContainer6.Panel1.Controls.Add(this.dgDataCleanupResults);
      // 
      // splitContainer6.Panel2
      // 
      this.splitContainer6.Panel2.Controls.Add(this.splitContainer7);
      this.splitContainer6.Size = new System.Drawing.Size(1601, 802);
      this.splitContainer6.SplitterDistance = 1074;
      this.splitContainer6.SplitterWidth = 5;
      this.splitContainer6.TabIndex = 17;
      // 
      // dgDataCleanupResults
      // 
      this.dgDataCleanupResults.AllowUserToAddRows = false;
      this.dgDataCleanupResults.AllowUserToDeleteRows = false;
      this.dgDataCleanupResults.AutoGenerateColumns = false;
      this.dgDataCleanupResults.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgDataCleanupResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgDataCleanupResults.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.entitylogicalname,
            this.idDataGridViewTextBoxColumn3,
            this.nameDataGridViewTextBoxColumn});
      this.dgDataCleanupResults.DataMember = "dtDeletedRecords";
      this.dgDataCleanupResults.DataSource = this.dsFSMigrationBindingSource;
      this.dgDataCleanupResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgDataCleanupResults.Location = new System.Drawing.Point(0, 0);
      this.dgDataCleanupResults.Margin = new System.Windows.Forms.Padding(4);
      this.dgDataCleanupResults.Name = "dgDataCleanupResults";
      this.dgDataCleanupResults.ReadOnly = true;
      this.dgDataCleanupResults.RowHeadersWidth = 51;
      this.dgDataCleanupResults.Size = new System.Drawing.Size(1074, 802);
      this.dgDataCleanupResults.TabIndex = 7;
      // 
      // entitylogicalname
      // 
      this.entitylogicalname.DataPropertyName = "entitylogicalname";
      this.entitylogicalname.HeaderText = "Logical Name";
      this.entitylogicalname.MinimumWidth = 6;
      this.entitylogicalname.Name = "entitylogicalname";
      this.entitylogicalname.ReadOnly = true;
      // 
      // idDataGridViewTextBoxColumn3
      // 
      this.idDataGridViewTextBoxColumn3.DataPropertyName = "Id";
      this.idDataGridViewTextBoxColumn3.HeaderText = "Id";
      this.idDataGridViewTextBoxColumn3.MinimumWidth = 6;
      this.idDataGridViewTextBoxColumn3.Name = "idDataGridViewTextBoxColumn3";
      this.idDataGridViewTextBoxColumn3.ReadOnly = true;
      // 
      // nameDataGridViewTextBoxColumn
      // 
      this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
      this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
      this.nameDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // splitContainer7
      // 
      this.splitContainer7.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer7.Location = new System.Drawing.Point(0, 0);
      this.splitContainer7.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer7.Name = "splitContainer7";
      this.splitContainer7.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer7.Panel1
      // 
      this.splitContainer7.Panel1.Controls.Add(this.txtDataCleanupSourceFetchXml);
      this.splitContainer7.Panel1.Controls.Add(this.label16);
      // 
      // splitContainer7.Panel2
      // 
      this.splitContainer7.Panel2.Controls.Add(this.txtDataCleanupTargetFetchXml);
      this.splitContainer7.Panel2.Controls.Add(this.label17);
      this.splitContainer7.Size = new System.Drawing.Size(522, 802);
      this.splitContainer7.SplitterDistance = 380;
      this.splitContainer7.SplitterWidth = 5;
      this.splitContainer7.TabIndex = 0;
      // 
      // txtDataCleanupSourceFetchXml
      // 
      this.txtDataCleanupSourceFetchXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDataCleanupSourceFetchXml.Location = new System.Drawing.Point(4, 28);
      this.txtDataCleanupSourceFetchXml.Margin = new System.Windows.Forms.Padding(4);
      this.txtDataCleanupSourceFetchXml.Multiline = true;
      this.txtDataCleanupSourceFetchXml.Name = "txtDataCleanupSourceFetchXml";
      this.txtDataCleanupSourceFetchXml.Size = new System.Drawing.Size(513, 347);
      this.txtDataCleanupSourceFetchXml.TabIndex = 20;
      // 
      // label16
      // 
      this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label16.BackColor = System.Drawing.Color.Silver;
      this.label16.Location = new System.Drawing.Point(4, 2);
      this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label16.Name = "label16";
      this.label16.Size = new System.Drawing.Size(516, 22);
      this.label16.TabIndex = 19;
      this.label16.Text = "Source Fetch XML";
      this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // txtDataCleanupTargetFetchXml
      // 
      this.txtDataCleanupTargetFetchXml.AcceptsReturn = true;
      this.txtDataCleanupTargetFetchXml.AcceptsTab = true;
      this.txtDataCleanupTargetFetchXml.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtDataCleanupTargetFetchXml.Location = new System.Drawing.Point(4, 25);
      this.txtDataCleanupTargetFetchXml.Margin = new System.Windows.Forms.Padding(4);
      this.txtDataCleanupTargetFetchXml.Multiline = true;
      this.txtDataCleanupTargetFetchXml.Name = "txtDataCleanupTargetFetchXml";
      this.txtDataCleanupTargetFetchXml.Size = new System.Drawing.Size(513, 386);
      this.txtDataCleanupTargetFetchXml.TabIndex = 21;
      this.txtDataCleanupTargetFetchXml.TextChanged += new System.EventHandler(this.txtDataCleanupTargetFetchXml_TextChanged);
      // 
      // label17
      // 
      this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.label17.BackColor = System.Drawing.Color.Silver;
      this.label17.Location = new System.Drawing.Point(3, 0);
      this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label17.Name = "label17";
      this.label17.Size = new System.Drawing.Size(516, 21);
      this.label17.TabIndex = 20;
      this.label17.Text = "Target Fetch XML";
      this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
      // 
      // btnDataCleanupCreateTestData
      // 
      this.btnDataCleanupCreateTestData.Location = new System.Drawing.Point(1277, 11);
      this.btnDataCleanupCreateTestData.Margin = new System.Windows.Forms.Padding(4);
      this.btnDataCleanupCreateTestData.Name = "btnDataCleanupCreateTestData";
      this.btnDataCleanupCreateTestData.Size = new System.Drawing.Size(156, 28);
      this.btnDataCleanupCreateTestData.TabIndex = 16;
      this.btnDataCleanupCreateTestData.Text = "Create Test Data";
      this.btnDataCleanupCreateTestData.UseVisualStyleBackColor = true;
      this.btnDataCleanupCreateTestData.Click += new System.EventHandler(this.btnDataCleanupCreateTestData_Click);
      // 
      // btnDataCleanupDeleteRecords
      // 
      this.btnDataCleanupDeleteRecords.Location = new System.Drawing.Point(1137, 11);
      this.btnDataCleanupDeleteRecords.Margin = new System.Windows.Forms.Padding(4);
      this.btnDataCleanupDeleteRecords.Name = "btnDataCleanupDeleteRecords";
      this.btnDataCleanupDeleteRecords.Size = new System.Drawing.Size(132, 28);
      this.btnDataCleanupDeleteRecords.TabIndex = 15;
      this.btnDataCleanupDeleteRecords.Text = "Delete Records";
      this.btnDataCleanupDeleteRecords.UseVisualStyleBackColor = true;
      this.btnDataCleanupDeleteRecords.Click += new System.EventHandler(this.btnDataCleanupDeleteRecords_Click);
      // 
      // label10
      // 
      this.label10.AutoSize = true;
      this.label10.Location = new System.Drawing.Point(505, 49);
      this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label10.Name = "label10";
      this.label10.Size = new System.Drawing.Size(107, 17);
      this.label10.TabIndex = 14;
      this.label10.Text = "Target Attribute";
      // 
      // txtDataCleanupTargetAttribute
      // 
      this.txtDataCleanupTargetAttribute.Location = new System.Drawing.Point(627, 46);
      this.txtDataCleanupTargetAttribute.Margin = new System.Windows.Forms.Padding(4);
      this.txtDataCleanupTargetAttribute.Name = "txtDataCleanupTargetAttribute";
      this.txtDataCleanupTargetAttribute.Size = new System.Drawing.Size(304, 22);
      this.txtDataCleanupTargetAttribute.TabIndex = 13;
      // 
      // label9
      // 
      this.label9.AutoSize = true;
      this.label9.Location = new System.Drawing.Point(9, 50);
      this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label9.Name = "label9";
      this.label9.Size = new System.Drawing.Size(110, 17);
      this.label9.TabIndex = 12;
      this.label9.Text = "Source Attribute";
      // 
      // txtDataCleanupSourceAttribute
      // 
      this.txtDataCleanupSourceAttribute.Location = new System.Drawing.Point(131, 47);
      this.txtDataCleanupSourceAttribute.Margin = new System.Windows.Forms.Padding(4);
      this.txtDataCleanupSourceAttribute.Name = "txtDataCleanupSourceAttribute";
      this.txtDataCleanupSourceAttribute.Size = new System.Drawing.Size(304, 22);
      this.txtDataCleanupSourceAttribute.TabIndex = 11;
      // 
      // btnDataCleanupLoadTargetEntities
      // 
      this.btnDataCleanupLoadTargetEntities.Image = global::MSCPS.F12FSMigration.Properties.Resources.Refresh_16x;
      this.btnDataCleanupLoadTargetEntities.Location = new System.Drawing.Point(940, 11);
      this.btnDataCleanupLoadTargetEntities.Margin = new System.Windows.Forms.Padding(4);
      this.btnDataCleanupLoadTargetEntities.Name = "btnDataCleanupLoadTargetEntities";
      this.btnDataCleanupLoadTargetEntities.Size = new System.Drawing.Size(49, 28);
      this.btnDataCleanupLoadTargetEntities.TabIndex = 10;
      this.btnDataCleanupLoadTargetEntities.UseVisualStyleBackColor = true;
      this.btnDataCleanupLoadTargetEntities.Click += new System.EventHandler(this.btnDataCleanupLoadTargetEntities_Click);
      // 
      // btnDataCleanupLoadSourceEntities
      // 
      this.btnDataCleanupLoadSourceEntities.Image = global::MSCPS.F12FSMigration.Properties.Resources.Refresh_16x;
      this.btnDataCleanupLoadSourceEntities.Location = new System.Drawing.Point(444, 12);
      this.btnDataCleanupLoadSourceEntities.Margin = new System.Windows.Forms.Padding(4);
      this.btnDataCleanupLoadSourceEntities.Name = "btnDataCleanupLoadSourceEntities";
      this.btnDataCleanupLoadSourceEntities.Size = new System.Drawing.Size(49, 28);
      this.btnDataCleanupLoadSourceEntities.TabIndex = 9;
      this.btnDataCleanupLoadSourceEntities.UseVisualStyleBackColor = true;
      this.btnDataCleanupLoadSourceEntities.Click += new System.EventHandler(this.btnDataCleanupLoadSourceEntities_Click);
      // 
      // cbDataCleanupTargetEntityList
      // 
      this.cbDataCleanupTargetEntityList.FormattingEnabled = true;
      this.cbDataCleanupTargetEntityList.Location = new System.Drawing.Point(627, 12);
      this.cbDataCleanupTargetEntityList.Margin = new System.Windows.Forms.Padding(4);
      this.cbDataCleanupTargetEntityList.Name = "cbDataCleanupTargetEntityList";
      this.cbDataCleanupTargetEntityList.Size = new System.Drawing.Size(304, 24);
      this.cbDataCleanupTargetEntityList.Sorted = true;
      this.cbDataCleanupTargetEntityList.TabIndex = 8;
      this.cbDataCleanupTargetEntityList.SelectedIndexChanged += new System.EventHandler(this.cbDataCleanupTargetEntityList_SelectedIndexChanged);
      // 
      // label8
      // 
      this.label8.AutoSize = true;
      this.label8.Location = new System.Drawing.Point(515, 17);
      this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label8.Name = "label8";
      this.label8.Size = new System.Drawing.Size(100, 17);
      this.label8.TabIndex = 7;
      this.label8.Text = "Target Entities";
      // 
      // btnDataCleanupValidateRecords
      // 
      this.btnDataCleanupValidateRecords.Location = new System.Drawing.Point(997, 11);
      this.btnDataCleanupValidateRecords.Margin = new System.Windows.Forms.Padding(4);
      this.btnDataCleanupValidateRecords.Name = "btnDataCleanupValidateRecords";
      this.btnDataCleanupValidateRecords.Size = new System.Drawing.Size(132, 28);
      this.btnDataCleanupValidateRecords.TabIndex = 5;
      this.btnDataCleanupValidateRecords.Text = "Validate Records";
      this.btnDataCleanupValidateRecords.UseVisualStyleBackColor = true;
      this.btnDataCleanupValidateRecords.Click += new System.EventHandler(this.btnDataCleanupValidateRecords_Click);
      // 
      // cbDataCleanupSourceEntityList
      // 
      this.cbDataCleanupSourceEntityList.FormattingEnabled = true;
      this.cbDataCleanupSourceEntityList.Location = new System.Drawing.Point(131, 12);
      this.cbDataCleanupSourceEntityList.Margin = new System.Windows.Forms.Padding(4);
      this.cbDataCleanupSourceEntityList.Name = "cbDataCleanupSourceEntityList";
      this.cbDataCleanupSourceEntityList.Size = new System.Drawing.Size(304, 24);
      this.cbDataCleanupSourceEntityList.Sorted = true;
      this.cbDataCleanupSourceEntityList.TabIndex = 2;
      this.cbDataCleanupSourceEntityList.SelectedIndexChanged += new System.EventHandler(this.cbDataCleanupSourceEntityList_SelectedIndexChanged);
      // 
      // label7
      // 
      this.label7.AutoSize = true;
      this.label7.Location = new System.Drawing.Point(19, 17);
      this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label7.Name = "label7";
      this.label7.Size = new System.Drawing.Size(103, 17);
      this.label7.TabIndex = 1;
      this.label7.Text = "Source Entities";
      // 
      // label6
      // 
      this.label6.AutoSize = true;
      this.label6.Location = new System.Drawing.Point(9, 9);
      this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label6.Name = "label6";
      this.label6.Size = new System.Drawing.Size(0, 17);
      this.label6.TabIndex = 0;
      // 
      // tpAgreementProcessing
      // 
      this.tpAgreementProcessing.Controls.Add(this.tcAgreementProcessing);
      this.tpAgreementProcessing.Location = new System.Drawing.Point(4, 25);
      this.tpAgreementProcessing.Margin = new System.Windows.Forms.Padding(4);
      this.tpAgreementProcessing.Name = "tpAgreementProcessing";
      this.tpAgreementProcessing.Size = new System.Drawing.Size(1700, 901);
      this.tpAgreementProcessing.TabIndex = 5;
      this.tpAgreementProcessing.Text = "Agreements";
      this.tpAgreementProcessing.UseVisualStyleBackColor = true;
      // 
      // tcAgreementProcessing
      // 
      this.tcAgreementProcessing.Controls.Add(this.tpAgreementWorkflowReset);
      this.tcAgreementProcessing.Controls.Add(this.tpAgreementFailures);
      this.tcAgreementProcessing.Controls.Add(this.tpAgreementPerfTesting);
      this.tcAgreementProcessing.Controls.Add(this.tpAgreementPostDataMigration);
      this.tcAgreementProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tcAgreementProcessing.Location = new System.Drawing.Point(0, 0);
      this.tcAgreementProcessing.Margin = new System.Windows.Forms.Padding(4);
      this.tcAgreementProcessing.Name = "tcAgreementProcessing";
      this.tcAgreementProcessing.SelectedIndex = 0;
      this.tcAgreementProcessing.Size = new System.Drawing.Size(1700, 901);
      this.tcAgreementProcessing.TabIndex = 2;
      // 
      // tpAgreementWorkflowReset
      // 
      this.tpAgreementWorkflowReset.Controls.Add(this.btnAgreementWorkflowReset);
      this.tpAgreementWorkflowReset.Controls.Add(this.btnAgreementWorkflowResetSearch);
      this.tpAgreementWorkflowReset.Controls.Add(this.dgAgreementWorkflowResetAgreements);
      this.tpAgreementWorkflowReset.Controls.Add(this.btnAgreementWorkflowResetRefreshUsers);
      this.tpAgreementWorkflowReset.Controls.Add(this.label18);
      this.tpAgreementWorkflowReset.Controls.Add(this.cbAgreementWorkFlowResetUsers);
      this.tpAgreementWorkflowReset.Location = new System.Drawing.Point(4, 25);
      this.tpAgreementWorkflowReset.Margin = new System.Windows.Forms.Padding(4);
      this.tpAgreementWorkflowReset.Name = "tpAgreementWorkflowReset";
      this.tpAgreementWorkflowReset.Size = new System.Drawing.Size(1692, 872);
      this.tpAgreementWorkflowReset.TabIndex = 2;
      this.tpAgreementWorkflowReset.Text = "Workflow Reset";
      this.tpAgreementWorkflowReset.UseVisualStyleBackColor = true;
      // 
      // btnAgreementWorkflowReset
      // 
      this.btnAgreementWorkflowReset.Location = new System.Drawing.Point(572, 9);
      this.btnAgreementWorkflowReset.Margin = new System.Windows.Forms.Padding(4);
      this.btnAgreementWorkflowReset.Name = "btnAgreementWorkflowReset";
      this.btnAgreementWorkflowReset.Size = new System.Drawing.Size(148, 28);
      this.btnAgreementWorkflowReset.TabIndex = 5;
      this.btnAgreementWorkflowReset.Text = "Reset Workflows";
      this.btnAgreementWorkflowReset.UseVisualStyleBackColor = true;
      this.btnAgreementWorkflowReset.Click += new System.EventHandler(this.btnAgreementWorkflowReset_Click);
      // 
      // btnAgreementWorkflowResetSearch
      // 
      this.btnAgreementWorkflowResetSearch.Location = new System.Drawing.Point(448, 9);
      this.btnAgreementWorkflowResetSearch.Margin = new System.Windows.Forms.Padding(4);
      this.btnAgreementWorkflowResetSearch.Name = "btnAgreementWorkflowResetSearch";
      this.btnAgreementWorkflowResetSearch.Size = new System.Drawing.Size(100, 28);
      this.btnAgreementWorkflowResetSearch.TabIndex = 4;
      this.btnAgreementWorkflowResetSearch.Text = "Search Agreements";
      this.btnAgreementWorkflowResetSearch.UseVisualStyleBackColor = true;
      this.btnAgreementWorkflowResetSearch.Click += new System.EventHandler(this.btnAgreementWorkflowResetSearch_Click);
      // 
      // dgAgreementWorkflowResetAgreements
      // 
      this.dgAgreementWorkflowResetAgreements.AllowUserToAddRows = false;
      this.dgAgreementWorkflowResetAgreements.AllowUserToDeleteRows = false;
      this.dgAgreementWorkflowResetAgreements.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgAgreementWorkflowResetAgreements.AutoGenerateColumns = false;
      this.dgAgreementWorkflowResetAgreements.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
      this.dgAgreementWorkflowResetAgreements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgAgreementWorkflowResetAgreements.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.agreementnameDataGridViewTextBoxColumn1,
            this.agreementidDataGridViewTextBoxColumn});
      this.dgAgreementWorkflowResetAgreements.DataMember = "dtAgreementReset";
      this.dgAgreementWorkflowResetAgreements.DataSource = this.dsFSMigrationBindingSource;
      this.dgAgreementWorkflowResetAgreements.Location = new System.Drawing.Point(12, 63);
      this.dgAgreementWorkflowResetAgreements.Margin = new System.Windows.Forms.Padding(4);
      this.dgAgreementWorkflowResetAgreements.Name = "dgAgreementWorkflowResetAgreements";
      this.dgAgreementWorkflowResetAgreements.ReadOnly = true;
      this.dgAgreementWorkflowResetAgreements.RowHeadersWidth = 51;
      this.dgAgreementWorkflowResetAgreements.Size = new System.Drawing.Size(1660, 792);
      this.dgAgreementWorkflowResetAgreements.TabIndex = 3;
      // 
      // agreementnameDataGridViewTextBoxColumn1
      // 
      this.agreementnameDataGridViewTextBoxColumn1.DataPropertyName = "agreementname";
      this.agreementnameDataGridViewTextBoxColumn1.HeaderText = "Agreement Name";
      this.agreementnameDataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.agreementnameDataGridViewTextBoxColumn1.Name = "agreementnameDataGridViewTextBoxColumn1";
      this.agreementnameDataGridViewTextBoxColumn1.ReadOnly = true;
      // 
      // agreementidDataGridViewTextBoxColumn
      // 
      this.agreementidDataGridViewTextBoxColumn.DataPropertyName = "agreementid";
      this.agreementidDataGridViewTextBoxColumn.HeaderText = "AgreementId";
      this.agreementidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.agreementidDataGridViewTextBoxColumn.Name = "agreementidDataGridViewTextBoxColumn";
      this.agreementidDataGridViewTextBoxColumn.ReadOnly = true;
      // 
      // btnAgreementWorkflowResetRefreshUsers
      // 
      this.btnAgreementWorkflowResetRefreshUsers.AutoSize = true;
      this.btnAgreementWorkflowResetRefreshUsers.Image = global::MSCPS.F12FSMigration.Properties.Resources.Refresh_16x;
      this.btnAgreementWorkflowResetRefreshUsers.Location = new System.Drawing.Point(375, 9);
      this.btnAgreementWorkflowResetRefreshUsers.Margin = new System.Windows.Forms.Padding(4);
      this.btnAgreementWorkflowResetRefreshUsers.Name = "btnAgreementWorkflowResetRefreshUsers";
      this.btnAgreementWorkflowResetRefreshUsers.Size = new System.Drawing.Size(45, 28);
      this.btnAgreementWorkflowResetRefreshUsers.TabIndex = 2;
      this.btnAgreementWorkflowResetRefreshUsers.UseVisualStyleBackColor = true;
      this.btnAgreementWorkflowResetRefreshUsers.Click += new System.EventHandler(this.btnAgreementWorkflowResetRefreshUsers_Click);
      // 
      // label18
      // 
      this.label18.AutoSize = true;
      this.label18.Location = new System.Drawing.Point(8, 11);
      this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label18.Name = "label18";
      this.label18.Size = new System.Drawing.Size(81, 17);
      this.label18.TabIndex = 1;
      this.label18.Text = "Select User";
      // 
      // cbAgreementWorkFlowResetUsers
      // 
      this.cbAgreementWorkFlowResetUsers.FormattingEnabled = true;
      this.cbAgreementWorkFlowResetUsers.Location = new System.Drawing.Point(105, 9);
      this.cbAgreementWorkFlowResetUsers.Margin = new System.Windows.Forms.Padding(4);
      this.cbAgreementWorkFlowResetUsers.Name = "cbAgreementWorkFlowResetUsers";
      this.cbAgreementWorkFlowResetUsers.Size = new System.Drawing.Size(260, 24);
      this.cbAgreementWorkFlowResetUsers.Sorted = true;
      this.cbAgreementWorkFlowResetUsers.TabIndex = 0;
      // 
      // tpAgreementFailures
      // 
      this.tpAgreementFailures.Controls.Add(this.lbl1);
      this.tpAgreementFailures.Controls.Add(this.dtpAgreementFailuresEnd);
      this.tpAgreementFailures.Controls.Add(this.label19);
      this.tpAgreementFailures.Controls.Add(this.dtpAgreementFailuresStart);
      this.tpAgreementFailures.Controls.Add(this.btnAgreementFailuresLoad);
      this.tpAgreementFailures.Controls.Add(this.splitContainer8);
      this.tpAgreementFailures.Location = new System.Drawing.Point(4, 25);
      this.tpAgreementFailures.Margin = new System.Windows.Forms.Padding(4);
      this.tpAgreementFailures.Name = "tpAgreementFailures";
      this.tpAgreementFailures.Size = new System.Drawing.Size(1617, 865);
      this.tpAgreementFailures.TabIndex = 3;
      this.tpAgreementFailures.Text = "Agreement Failures";
      this.tpAgreementFailures.UseVisualStyleBackColor = true;
      // 
      // lbl1
      // 
      this.lbl1.AutoSize = true;
      this.lbl1.Location = new System.Drawing.Point(433, 15);
      this.lbl1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lbl1.Name = "lbl1";
      this.lbl1.Size = new System.Drawing.Size(140, 17);
      this.lbl1.TabIndex = 5;
      this.lbl1.Text = "Started On or Before";
      // 
      // dtpAgreementFailuresEnd
      // 
      this.dtpAgreementFailuresEnd.CustomFormat = "";
      this.dtpAgreementFailuresEnd.Location = new System.Drawing.Point(579, 10);
      this.dtpAgreementFailuresEnd.Margin = new System.Windows.Forms.Padding(4);
      this.dtpAgreementFailuresEnd.Name = "dtpAgreementFailuresEnd";
      this.dtpAgreementFailuresEnd.Size = new System.Drawing.Size(265, 22);
      this.dtpAgreementFailuresEnd.TabIndex = 4;
      // 
      // label19
      // 
      this.label19.AutoSize = true;
      this.label19.Location = new System.Drawing.Point(4, 15);
      this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label19.Name = "label19";
      this.label19.Size = new System.Drawing.Size(128, 17);
      this.label19.TabIndex = 3;
      this.label19.Text = "Started On or After";
      // 
      // dtpAgreementFailuresStart
      // 
      this.dtpAgreementFailuresStart.CustomFormat = "";
      this.dtpAgreementFailuresStart.Location = new System.Drawing.Point(137, 10);
      this.dtpAgreementFailuresStart.Margin = new System.Windows.Forms.Padding(4);
      this.dtpAgreementFailuresStart.Name = "dtpAgreementFailuresStart";
      this.dtpAgreementFailuresStart.Size = new System.Drawing.Size(265, 22);
      this.dtpAgreementFailuresStart.TabIndex = 2;
      // 
      // btnAgreementFailuresLoad
      // 
      this.btnAgreementFailuresLoad.Location = new System.Drawing.Point(875, 7);
      this.btnAgreementFailuresLoad.Margin = new System.Windows.Forms.Padding(4);
      this.btnAgreementFailuresLoad.Name = "btnAgreementFailuresLoad";
      this.btnAgreementFailuresLoad.Size = new System.Drawing.Size(140, 28);
      this.btnAgreementFailuresLoad.TabIndex = 1;
      this.btnAgreementFailuresLoad.Text = "Load Failed Jobs";
      this.btnAgreementFailuresLoad.UseVisualStyleBackColor = true;
      // 
      // splitContainer8
      // 
      this.splitContainer8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.splitContainer8.Location = new System.Drawing.Point(4, 42);
      this.splitContainer8.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer8.Name = "splitContainer8";
      // 
      // splitContainer8.Panel1
      // 
      this.splitContainer8.Panel1.Controls.Add(this.dgAreementFailuresSystemJobs);
      // 
      // splitContainer8.Panel2
      // 
      this.splitContainer8.Panel2.Controls.Add(this.pgAgreementObjectDetails);
      this.splitContainer8.Size = new System.Drawing.Size(1606, 813);
      this.splitContainer8.SplitterDistance = 1281;
      this.splitContainer8.SplitterWidth = 5;
      this.splitContainer8.TabIndex = 0;
      // 
      // dgAreementFailuresSystemJobs
      // 
      this.dgAreementFailuresSystemJobs.AllowUserToAddRows = false;
      this.dgAreementFailuresSystemJobs.AllowUserToDeleteRows = false;
      this.dgAreementFailuresSystemJobs.AllowUserToOrderColumns = true;
      this.dgAreementFailuresSystemJobs.AutoGenerateColumns = false;
      this.dgAreementFailuresSystemJobs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgAreementFailuresSystemJobs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn1,
            this.regardingobjectidDataGridViewTextBoxColumn,
            this.regardingobjectnameDataGridViewTextBoxColumn,
            this.operationtypenameDataGridViewTextBoxColumn,
            this.startedonDataGridViewTextBoxColumn,
            this.completedonDataGridViewTextBoxColumn,
            this.ownernameDataGridViewTextBoxColumn,
            this.owningextensionnameDataGridViewTextBoxColumn,
            this.errorcodeDataGridViewTextBoxColumn,
            this.messagenameDataGridViewTextBoxColumn,
            this.friendlynameDataGridViewTextBoxColumn,
            this.messageDataGridViewTextBoxColumn,
            this.postponeuntilDataGridViewTextBoxColumn,
            this.primaryentitytypeDataGridViewTextBoxColumn,
            this.statuscodenameDataGridViewTextBoxColumn});
      this.dgAreementFailuresSystemJobs.DataSource = this.dtAgreementFailuresBindingSource;
      this.dgAreementFailuresSystemJobs.Dock = System.Windows.Forms.DockStyle.Fill;
      this.dgAreementFailuresSystemJobs.Location = new System.Drawing.Point(0, 0);
      this.dgAreementFailuresSystemJobs.Margin = new System.Windows.Forms.Padding(4);
      this.dgAreementFailuresSystemJobs.MultiSelect = false;
      this.dgAreementFailuresSystemJobs.Name = "dgAreementFailuresSystemJobs";
      this.dgAreementFailuresSystemJobs.ReadOnly = true;
      this.dgAreementFailuresSystemJobs.RowHeadersWidth = 51;
      this.dgAreementFailuresSystemJobs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
      this.dgAreementFailuresSystemJobs.Size = new System.Drawing.Size(1281, 813);
      this.dgAreementFailuresSystemJobs.TabIndex = 0;
      // 
      // nameDataGridViewTextBoxColumn1
      // 
      this.nameDataGridViewTextBoxColumn1.DataPropertyName = "name";
      this.nameDataGridViewTextBoxColumn1.HeaderText = "Job Name";
      this.nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
      this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
      this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
      this.nameDataGridViewTextBoxColumn1.Width = 125;
      // 
      // regardingobjectidDataGridViewTextBoxColumn
      // 
      this.regardingobjectidDataGridViewTextBoxColumn.DataPropertyName = "regardingobjectid";
      this.regardingobjectidDataGridViewTextBoxColumn.HeaderText = "Regarding ID";
      this.regardingobjectidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.regardingobjectidDataGridViewTextBoxColumn.Name = "regardingobjectidDataGridViewTextBoxColumn";
      this.regardingobjectidDataGridViewTextBoxColumn.ReadOnly = true;
      this.regardingobjectidDataGridViewTextBoxColumn.Width = 125;
      // 
      // regardingobjectnameDataGridViewTextBoxColumn
      // 
      this.regardingobjectnameDataGridViewTextBoxColumn.DataPropertyName = "regardingobjectname";
      this.regardingobjectnameDataGridViewTextBoxColumn.HeaderText = "Regarding Object";
      this.regardingobjectnameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.regardingobjectnameDataGridViewTextBoxColumn.Name = "regardingobjectnameDataGridViewTextBoxColumn";
      this.regardingobjectnameDataGridViewTextBoxColumn.ReadOnly = true;
      this.regardingobjectnameDataGridViewTextBoxColumn.Width = 125;
      // 
      // operationtypenameDataGridViewTextBoxColumn
      // 
      this.operationtypenameDataGridViewTextBoxColumn.DataPropertyName = "operationtypename";
      this.operationtypenameDataGridViewTextBoxColumn.HeaderText = "Operation Type";
      this.operationtypenameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.operationtypenameDataGridViewTextBoxColumn.Name = "operationtypenameDataGridViewTextBoxColumn";
      this.operationtypenameDataGridViewTextBoxColumn.ReadOnly = true;
      this.operationtypenameDataGridViewTextBoxColumn.Width = 125;
      // 
      // startedonDataGridViewTextBoxColumn
      // 
      this.startedonDataGridViewTextBoxColumn.DataPropertyName = "startedon";
      this.startedonDataGridViewTextBoxColumn.HeaderText = "Started On";
      this.startedonDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.startedonDataGridViewTextBoxColumn.Name = "startedonDataGridViewTextBoxColumn";
      this.startedonDataGridViewTextBoxColumn.ReadOnly = true;
      this.startedonDataGridViewTextBoxColumn.Width = 125;
      // 
      // completedonDataGridViewTextBoxColumn
      // 
      this.completedonDataGridViewTextBoxColumn.DataPropertyName = "completedon";
      this.completedonDataGridViewTextBoxColumn.HeaderText = "Completed On";
      this.completedonDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.completedonDataGridViewTextBoxColumn.Name = "completedonDataGridViewTextBoxColumn";
      this.completedonDataGridViewTextBoxColumn.ReadOnly = true;
      this.completedonDataGridViewTextBoxColumn.Width = 125;
      // 
      // ownernameDataGridViewTextBoxColumn
      // 
      this.ownernameDataGridViewTextBoxColumn.DataPropertyName = "ownername";
      this.ownernameDataGridViewTextBoxColumn.HeaderText = "Owner Name";
      this.ownernameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.ownernameDataGridViewTextBoxColumn.Name = "ownernameDataGridViewTextBoxColumn";
      this.ownernameDataGridViewTextBoxColumn.ReadOnly = true;
      this.ownernameDataGridViewTextBoxColumn.Width = 125;
      // 
      // owningextensionnameDataGridViewTextBoxColumn
      // 
      this.owningextensionnameDataGridViewTextBoxColumn.DataPropertyName = "owningextensionname";
      this.owningextensionnameDataGridViewTextBoxColumn.HeaderText = "Owning Extension";
      this.owningextensionnameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.owningextensionnameDataGridViewTextBoxColumn.Name = "owningextensionnameDataGridViewTextBoxColumn";
      this.owningextensionnameDataGridViewTextBoxColumn.ReadOnly = true;
      this.owningextensionnameDataGridViewTextBoxColumn.Width = 125;
      // 
      // errorcodeDataGridViewTextBoxColumn
      // 
      this.errorcodeDataGridViewTextBoxColumn.DataPropertyName = "errorcode";
      this.errorcodeDataGridViewTextBoxColumn.HeaderText = "Error Code";
      this.errorcodeDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.errorcodeDataGridViewTextBoxColumn.Name = "errorcodeDataGridViewTextBoxColumn";
      this.errorcodeDataGridViewTextBoxColumn.ReadOnly = true;
      this.errorcodeDataGridViewTextBoxColumn.Width = 125;
      // 
      // messagenameDataGridViewTextBoxColumn
      // 
      this.messagenameDataGridViewTextBoxColumn.DataPropertyName = "messagename";
      this.messagenameDataGridViewTextBoxColumn.HeaderText = "Message Name";
      this.messagenameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.messagenameDataGridViewTextBoxColumn.Name = "messagenameDataGridViewTextBoxColumn";
      this.messagenameDataGridViewTextBoxColumn.ReadOnly = true;
      this.messagenameDataGridViewTextBoxColumn.Width = 125;
      // 
      // friendlynameDataGridViewTextBoxColumn
      // 
      this.friendlynameDataGridViewTextBoxColumn.DataPropertyName = "friendlyname";
      this.friendlynameDataGridViewTextBoxColumn.HeaderText = "Friendly Name";
      this.friendlynameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.friendlynameDataGridViewTextBoxColumn.Name = "friendlynameDataGridViewTextBoxColumn";
      this.friendlynameDataGridViewTextBoxColumn.ReadOnly = true;
      this.friendlynameDataGridViewTextBoxColumn.Width = 125;
      // 
      // messageDataGridViewTextBoxColumn
      // 
      this.messageDataGridViewTextBoxColumn.DataPropertyName = "message";
      this.messageDataGridViewTextBoxColumn.HeaderText = "Message";
      this.messageDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.messageDataGridViewTextBoxColumn.Name = "messageDataGridViewTextBoxColumn";
      this.messageDataGridViewTextBoxColumn.ReadOnly = true;
      this.messageDataGridViewTextBoxColumn.Width = 125;
      // 
      // postponeuntilDataGridViewTextBoxColumn
      // 
      this.postponeuntilDataGridViewTextBoxColumn.DataPropertyName = "postponeuntil";
      this.postponeuntilDataGridViewTextBoxColumn.HeaderText = "Postpone Until";
      this.postponeuntilDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.postponeuntilDataGridViewTextBoxColumn.Name = "postponeuntilDataGridViewTextBoxColumn";
      this.postponeuntilDataGridViewTextBoxColumn.ReadOnly = true;
      this.postponeuntilDataGridViewTextBoxColumn.Width = 125;
      // 
      // primaryentitytypeDataGridViewTextBoxColumn
      // 
      this.primaryentitytypeDataGridViewTextBoxColumn.DataPropertyName = "primaryentitytype";
      this.primaryentitytypeDataGridViewTextBoxColumn.HeaderText = "Primary Entity Type";
      this.primaryentitytypeDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.primaryentitytypeDataGridViewTextBoxColumn.Name = "primaryentitytypeDataGridViewTextBoxColumn";
      this.primaryentitytypeDataGridViewTextBoxColumn.ReadOnly = true;
      this.primaryentitytypeDataGridViewTextBoxColumn.Width = 125;
      // 
      // statuscodenameDataGridViewTextBoxColumn
      // 
      this.statuscodenameDataGridViewTextBoxColumn.DataPropertyName = "statuscodename";
      this.statuscodenameDataGridViewTextBoxColumn.HeaderText = "Status Reason";
      this.statuscodenameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.statuscodenameDataGridViewTextBoxColumn.Name = "statuscodenameDataGridViewTextBoxColumn";
      this.statuscodenameDataGridViewTextBoxColumn.ReadOnly = true;
      this.statuscodenameDataGridViewTextBoxColumn.Width = 125;
      // 
      // dtAgreementFailuresBindingSource
      // 
      this.dtAgreementFailuresBindingSource.DataMember = "dtAgreementFailures";
      this.dtAgreementFailuresBindingSource.DataSource = this.dsFSMigrationBindingSource;
      // 
      // pgAgreementObjectDetails
      // 
      this.pgAgreementObjectDetails.Dock = System.Windows.Forms.DockStyle.Fill;
      this.pgAgreementObjectDetails.Location = new System.Drawing.Point(0, 0);
      this.pgAgreementObjectDetails.Margin = new System.Windows.Forms.Padding(4);
      this.pgAgreementObjectDetails.Name = "pgAgreementObjectDetails";
      this.pgAgreementObjectDetails.Size = new System.Drawing.Size(320, 813);
      this.pgAgreementObjectDetails.TabIndex = 0;
      // 
      // tpAgreementPerfTesting
      // 
      this.tpAgreementPerfTesting.Controls.Add(this.scAgreementProcessing);
      this.tpAgreementPerfTesting.Location = new System.Drawing.Point(4, 25);
      this.tpAgreementPerfTesting.Margin = new System.Windows.Forms.Padding(4);
      this.tpAgreementPerfTesting.Name = "tpAgreementPerfTesting";
      this.tpAgreementPerfTesting.Padding = new System.Windows.Forms.Padding(4);
      this.tpAgreementPerfTesting.Size = new System.Drawing.Size(1617, 865);
      this.tpAgreementPerfTesting.TabIndex = 0;
      this.tpAgreementPerfTesting.Text = "Perf Testing";
      this.tpAgreementPerfTesting.UseVisualStyleBackColor = true;
      // 
      // scAgreementProcessing
      // 
      this.scAgreementProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
      this.scAgreementProcessing.Location = new System.Drawing.Point(4, 4);
      this.scAgreementProcessing.Margin = new System.Windows.Forms.Padding(4);
      this.scAgreementProcessing.Name = "scAgreementProcessing";
      // 
      // scAgreementProcessing.Panel1
      // 
      this.scAgreementProcessing.Panel1.Controls.Add(this.lblBookingSetupTotalRecords);
      this.scAgreementProcessing.Panel1.Controls.Add(this.cbBookingSetupCheckUncheck);
      this.scAgreementProcessing.Panel1.Controls.Add(this.btnBookingSetupUpdate);
      this.scAgreementProcessing.Panel1.Controls.Add(this.dpBookingSetupStartDate);
      this.scAgreementProcessing.Panel1.Controls.Add(this.dgBookingSetup);
      this.scAgreementProcessing.Panel1.Controls.Add(this.label5);
      this.scAgreementProcessing.Panel1.Controls.Add(this.btnRetrieveBookingSetup);
      this.scAgreementProcessing.Size = new System.Drawing.Size(1609, 857);
      this.scAgreementProcessing.SplitterDistance = 1237;
      this.scAgreementProcessing.SplitterWidth = 5;
      this.scAgreementProcessing.TabIndex = 2;
      // 
      // lblBookingSetupTotalRecords
      // 
      this.lblBookingSetupTotalRecords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.lblBookingSetupTotalRecords.AutoSize = true;
      this.lblBookingSetupTotalRecords.Location = new System.Drawing.Point(1080, 22);
      this.lblBookingSetupTotalRecords.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.lblBookingSetupTotalRecords.Name = "lblBookingSetupTotalRecords";
      this.lblBookingSetupTotalRecords.Size = new System.Drawing.Size(145, 17);
      this.lblBookingSetupTotalRecords.TabIndex = 8;
      this.lblBookingSetupTotalRecords.Text = "Total Records: 00000";
      // 
      // cbBookingSetupCheckUncheck
      // 
      this.cbBookingSetupCheckUncheck.AutoSize = true;
      this.cbBookingSetupCheckUncheck.Location = new System.Drawing.Point(455, 9);
      this.cbBookingSetupCheckUncheck.Margin = new System.Windows.Forms.Padding(4);
      this.cbBookingSetupCheckUncheck.Name = "cbBookingSetupCheckUncheck";
      this.cbBookingSetupCheckUncheck.Size = new System.Drawing.Size(136, 21);
      this.cbBookingSetupCheckUncheck.TabIndex = 7;
      this.cbBookingSetupCheckUncheck.Text = "Check / Uncheck";
      this.cbBookingSetupCheckUncheck.UseVisualStyleBackColor = true;
      this.cbBookingSetupCheckUncheck.CheckedChanged += new System.EventHandler(this.cbBookingSetupCheckUncheck_CheckedChanged);
      // 
      // btnBookingSetupUpdate
      // 
      this.btnBookingSetupUpdate.Location = new System.Drawing.Point(231, 4);
      this.btnBookingSetupUpdate.Margin = new System.Windows.Forms.Padding(4);
      this.btnBookingSetupUpdate.Name = "btnBookingSetupUpdate";
      this.btnBookingSetupUpdate.Size = new System.Drawing.Size(215, 28);
      this.btnBookingSetupUpdate.TabIndex = 6;
      this.btnBookingSetupUpdate.Text = "Update Booking Setups";
      this.btnBookingSetupUpdate.UseVisualStyleBackColor = true;
      this.btnBookingSetupUpdate.Click += new System.EventHandler(this.btnBookingSetupUpdate_Click);
      // 
      // dpBookingSetupStartDate
      // 
      this.dpBookingSetupStartDate.Location = new System.Drawing.Point(737, 6);
      this.dpBookingSetupStartDate.Margin = new System.Windows.Forms.Padding(4);
      this.dpBookingSetupStartDate.Name = "dpBookingSetupStartDate";
      this.dpBookingSetupStartDate.Size = new System.Drawing.Size(265, 22);
      this.dpBookingSetupStartDate.TabIndex = 5;
      // 
      // dgBookingSetup
      // 
      this.dgBookingSetup.AllowUserToAddRows = false;
      this.dgBookingSetup.AllowUserToDeleteRows = false;
      this.dgBookingSetup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.dgBookingSetup.AutoGenerateColumns = false;
      this.dgBookingSetup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
      this.dgBookingSetup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UpdateAgreement,
            this.msdynnameDataGridViewTextBoxColumn,
            this.msdynrecurrencesettingsDataGridViewTextBoxColumn,
            this.msdynrevisionDataGridViewTextBoxColumn,
            this.msdynpostponegenerationuntilDataGridViewTextBoxColumn,
            this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn,
            this.agreementNameDataGridViewTextBoxColumn,
            this.msdynagreementbookingsetupidDataGridViewTextBoxColumn,
            this.msdynagreementDataGridViewTextBoxColumn});
      this.dgBookingSetup.DataMember = "dtBookingSetup";
      this.dgBookingSetup.DataSource = this.dsFSMigrationBindingSource;
      this.dgBookingSetup.Location = new System.Drawing.Point(4, 41);
      this.dgBookingSetup.Margin = new System.Windows.Forms.Padding(4);
      this.dgBookingSetup.Name = "dgBookingSetup";
      this.dgBookingSetup.RowHeadersWidth = 51;
      this.dgBookingSetup.Size = new System.Drawing.Size(1229, 814);
      this.dgBookingSetup.TabIndex = 0;
      // 
      // UpdateAgreement
      // 
      this.UpdateAgreement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.UpdateAgreement.DataPropertyName = "UpdateAgreement";
      this.UpdateAgreement.HeaderText = "Update";
      this.UpdateAgreement.MinimumWidth = 6;
      this.UpdateAgreement.Name = "UpdateAgreement";
      this.UpdateAgreement.Width = 60;
      // 
      // msdynnameDataGridViewTextBoxColumn
      // 
      this.msdynnameDataGridViewTextBoxColumn.DataPropertyName = "msdyn_name";
      this.msdynnameDataGridViewTextBoxColumn.HeaderText = "Name";
      this.msdynnameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.msdynnameDataGridViewTextBoxColumn.Name = "msdynnameDataGridViewTextBoxColumn";
      this.msdynnameDataGridViewTextBoxColumn.ReadOnly = true;
      this.msdynnameDataGridViewTextBoxColumn.Width = 200;
      // 
      // msdynrecurrencesettingsDataGridViewTextBoxColumn
      // 
      this.msdynrecurrencesettingsDataGridViewTextBoxColumn.DataPropertyName = "msdyn_recurrencesettings";
      this.msdynrecurrencesettingsDataGridViewTextBoxColumn.HeaderText = "Pattern";
      this.msdynrecurrencesettingsDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.msdynrecurrencesettingsDataGridViewTextBoxColumn.Name = "msdynrecurrencesettingsDataGridViewTextBoxColumn";
      this.msdynrecurrencesettingsDataGridViewTextBoxColumn.ReadOnly = true;
      this.msdynrecurrencesettingsDataGridViewTextBoxColumn.Width = 200;
      // 
      // msdynrevisionDataGridViewTextBoxColumn
      // 
      this.msdynrevisionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.msdynrevisionDataGridViewTextBoxColumn.DataPropertyName = "msdyn_revision";
      this.msdynrevisionDataGridViewTextBoxColumn.HeaderText = "Revision";
      this.msdynrevisionDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.msdynrevisionDataGridViewTextBoxColumn.Name = "msdynrevisionDataGridViewTextBoxColumn";
      this.msdynrevisionDataGridViewTextBoxColumn.ReadOnly = true;
      this.msdynrevisionDataGridViewTextBoxColumn.Width = 91;
      // 
      // msdynpostponegenerationuntilDataGridViewTextBoxColumn
      // 
      this.msdynpostponegenerationuntilDataGridViewTextBoxColumn.DataPropertyName = "msdyn_postponegenerationuntil";
      this.msdynpostponegenerationuntilDataGridViewTextBoxColumn.HeaderText = "PGU";
      this.msdynpostponegenerationuntilDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.msdynpostponegenerationuntilDataGridViewTextBoxColumn.Name = "msdynpostponegenerationuntilDataGridViewTextBoxColumn";
      this.msdynpostponegenerationuntilDataGridViewTextBoxColumn.ReadOnly = true;
      this.msdynpostponegenerationuntilDataGridViewTextBoxColumn.Width = 200;
      // 
      // msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn
      // 
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.DataPropertyName = "msdyn_generatewodaysinadvance";
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.HeaderText = "Days In Advance";
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.Name = "msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn";
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.ReadOnly = true;
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.Visible = false;
      this.msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn.Width = 125;
      // 
      // agreementNameDataGridViewTextBoxColumn
      // 
      this.agreementNameDataGridViewTextBoxColumn.DataPropertyName = "AgreementName";
      this.agreementNameDataGridViewTextBoxColumn.HeaderText = "Agreement";
      this.agreementNameDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.agreementNameDataGridViewTextBoxColumn.Name = "agreementNameDataGridViewTextBoxColumn";
      this.agreementNameDataGridViewTextBoxColumn.ReadOnly = true;
      this.agreementNameDataGridViewTextBoxColumn.Visible = false;
      this.agreementNameDataGridViewTextBoxColumn.Width = 200;
      // 
      // msdynagreementbookingsetupidDataGridViewTextBoxColumn
      // 
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn.DataPropertyName = "msdyn_agreementbookingsetupid";
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn.HeaderText = "Booking Setup Id";
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn.Name = "msdynagreementbookingsetupidDataGridViewTextBoxColumn";
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn.ReadOnly = true;
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn.Visible = false;
      this.msdynagreementbookingsetupidDataGridViewTextBoxColumn.Width = 125;
      // 
      // msdynagreementDataGridViewTextBoxColumn
      // 
      this.msdynagreementDataGridViewTextBoxColumn.DataPropertyName = "msdyn_agreement";
      this.msdynagreementDataGridViewTextBoxColumn.HeaderText = "msdyn_agreement";
      this.msdynagreementDataGridViewTextBoxColumn.MinimumWidth = 6;
      this.msdynagreementDataGridViewTextBoxColumn.Name = "msdynagreementDataGridViewTextBoxColumn";
      this.msdynagreementDataGridViewTextBoxColumn.ReadOnly = true;
      this.msdynagreementDataGridViewTextBoxColumn.Visible = false;
      this.msdynagreementDataGridViewTextBoxColumn.Width = 125;
      // 
      // label5
      // 
      this.label5.AutoSize = true;
      this.label5.Location = new System.Drawing.Point(624, 11);
      this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label5.Name = "label5";
      this.label5.Size = new System.Drawing.Size(91, 17);
      this.label5.TabIndex = 4;
      this.label5.Text = "Starting Date";
      // 
      // btnRetrieveBookingSetup
      // 
      this.btnRetrieveBookingSetup.Location = new System.Drawing.Point(5, 6);
      this.btnRetrieveBookingSetup.Margin = new System.Windows.Forms.Padding(4);
      this.btnRetrieveBookingSetup.Name = "btnRetrieveBookingSetup";
      this.btnRetrieveBookingSetup.Size = new System.Drawing.Size(217, 28);
      this.btnRetrieveBookingSetup.TabIndex = 0;
      this.btnRetrieveBookingSetup.Text = "Retrieve Booking Setups";
      this.btnRetrieveBookingSetup.UseVisualStyleBackColor = true;
      this.btnRetrieveBookingSetup.Click += new System.EventHandler(this.btnRetrieveBookingSetup_Click);
      // 
      // tpAgreementPostDataMigration
      // 
      this.tpAgreementPostDataMigration.Controls.Add(this.splitContainer1);
      this.tpAgreementPostDataMigration.Location = new System.Drawing.Point(4, 25);
      this.tpAgreementPostDataMigration.Margin = new System.Windows.Forms.Padding(4);
      this.tpAgreementPostDataMigration.Name = "tpAgreementPostDataMigration";
      this.tpAgreementPostDataMigration.Padding = new System.Windows.Forms.Padding(4);
      this.tpAgreementPostDataMigration.Size = new System.Drawing.Size(1617, 865);
      this.tpAgreementPostDataMigration.TabIndex = 1;
      this.tpAgreementPostDataMigration.Text = "Post Data Migration";
      this.tpAgreementPostDataMigration.UseVisualStyleBackColor = true;
      // 
      // splitContainer1
      // 
      this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer1.Location = new System.Drawing.Point(4, 4);
      this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer1.Name = "splitContainer1";
      // 
      // splitContainer1.Panel1
      // 
      this.splitContainer1.Panel1.Controls.Add(this.btnAgreementResetInvoiceSetup);
      this.splitContainer1.Panel1.Controls.Add(this.btnAgreementResetBookingSetup);
      this.splitContainer1.Panel1.Controls.Add(this.txtAgreementProcessingResults);
      this.splitContainer1.Panel1.Controls.Add(this.btnAgreementMarkExpired);
      // 
      // splitContainer1.Panel2
      // 
      this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
      this.splitContainer1.Size = new System.Drawing.Size(1609, 857);
      this.splitContainer1.SplitterDistance = 1258;
      this.splitContainer1.SplitterWidth = 5;
      this.splitContainer1.TabIndex = 0;
      // 
      // btnAgreementResetInvoiceSetup
      // 
      this.btnAgreementResetInvoiceSetup.Location = new System.Drawing.Point(408, 17);
      this.btnAgreementResetInvoiceSetup.Margin = new System.Windows.Forms.Padding(4);
      this.btnAgreementResetInvoiceSetup.Name = "btnAgreementResetInvoiceSetup";
      this.btnAgreementResetInvoiceSetup.Size = new System.Drawing.Size(165, 28);
      this.btnAgreementResetInvoiceSetup.TabIndex = 3;
      this.btnAgreementResetInvoiceSetup.Text = "Reset Invoice Setup";
      this.btnAgreementResetInvoiceSetup.UseVisualStyleBackColor = true;
      // 
      // btnAgreementResetBookingSetup
      // 
      this.btnAgreementResetBookingSetup.Location = new System.Drawing.Point(227, 17);
      this.btnAgreementResetBookingSetup.Margin = new System.Windows.Forms.Padding(4);
      this.btnAgreementResetBookingSetup.Name = "btnAgreementResetBookingSetup";
      this.btnAgreementResetBookingSetup.Size = new System.Drawing.Size(172, 28);
      this.btnAgreementResetBookingSetup.TabIndex = 2;
      this.btnAgreementResetBookingSetup.Text = "Reset Booking Setup";
      this.btnAgreementResetBookingSetup.UseVisualStyleBackColor = true;
      // 
      // txtAgreementProcessingResults
      // 
      this.txtAgreementProcessingResults.Location = new System.Drawing.Point(21, 53);
      this.txtAgreementProcessingResults.Margin = new System.Windows.Forms.Padding(4);
      this.txtAgreementProcessingResults.Multiline = true;
      this.txtAgreementProcessingResults.Name = "txtAgreementProcessingResults";
      this.txtAgreementProcessingResults.Size = new System.Drawing.Size(1155, 697);
      this.txtAgreementProcessingResults.TabIndex = 1;
      // 
      // btnAgreementMarkExpired
      // 
      this.btnAgreementMarkExpired.Location = new System.Drawing.Point(21, 16);
      this.btnAgreementMarkExpired.Margin = new System.Windows.Forms.Padding(4);
      this.btnAgreementMarkExpired.Name = "btnAgreementMarkExpired";
      this.btnAgreementMarkExpired.Size = new System.Drawing.Size(197, 28);
      this.btnAgreementMarkExpired.TabIndex = 0;
      this.btnAgreementMarkExpired.Text = "Mark Agreements Expired";
      this.btnAgreementMarkExpired.UseVisualStyleBackColor = true;
      this.btnAgreementMarkExpired.Click += new System.EventHandler(this.btnAgreementMarkExpired_Click);
      // 
      // splitContainer3
      // 
      this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer3.Location = new System.Drawing.Point(0, 0);
      this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainer3.Name = "splitContainer3";
      this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // splitContainer3.Panel1
      // 
      this.splitContainer3.Panel1.Controls.Add(this.label3);
      // 
      // splitContainer3.Panel2
      // 
      this.splitContainer3.Panel2.Controls.Add(this.label13);
      this.splitContainer3.Size = new System.Drawing.Size(346, 857);
      this.splitContainer3.SplitterDistance = 419;
      this.splitContainer3.SplitterWidth = 5;
      this.splitContainer3.TabIndex = 0;
      // 
      // label3
      // 
      this.label3.BackColor = System.Drawing.Color.Silver;
      this.label3.Dock = System.Windows.Forms.DockStyle.Top;
      this.label3.Location = new System.Drawing.Point(0, 0);
      this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label3.Name = "label3";
      this.label3.Size = new System.Drawing.Size(346, 16);
      this.label3.TabIndex = 2;
      this.label3.Text = "Booking Setup FetchXML";
      this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // label13
      // 
      this.label13.BackColor = System.Drawing.Color.Silver;
      this.label13.Dock = System.Windows.Forms.DockStyle.Top;
      this.label13.Location = new System.Drawing.Point(0, 0);
      this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
      this.label13.Name = "label13";
      this.label13.Size = new System.Drawing.Size(346, 16);
      this.label13.TabIndex = 2;
      this.label13.Text = "Invoice Setup FetchXML";
      this.label13.TextAlign = System.Drawing.ContentAlignment.TopCenter;
      // 
      // tpPostDataMigration
      // 
      this.tpPostDataMigration.Controls.Add(this.splitContainerPostDataMigration);
      this.tpPostDataMigration.Location = new System.Drawing.Point(4, 25);
      this.tpPostDataMigration.Margin = new System.Windows.Forms.Padding(4);
      this.tpPostDataMigration.Name = "tpPostDataMigration";
      this.tpPostDataMigration.Size = new System.Drawing.Size(1700, 901);
      this.tpPostDataMigration.TabIndex = 2;
      this.tpPostDataMigration.Text = "Post Data Migration";
      this.tpPostDataMigration.UseVisualStyleBackColor = true;
      // 
      // splitContainerPostDataMigration
      // 
      this.splitContainerPostDataMigration.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerPostDataMigration.Location = new System.Drawing.Point(0, 0);
      this.splitContainerPostDataMigration.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainerPostDataMigration.Name = "splitContainerPostDataMigration";
      // 
      // splitContainerPostDataMigration.Panel1
      // 
      this.splitContainerPostDataMigration.Panel1.Controls.Add(this.cbProcessClosedWorkOrders);
      this.splitContainerPostDataMigration.Panel1.Controls.Add(this.cbProcessAllWorkOrders);
      this.splitContainerPostDataMigration.Panel1.Controls.Add(this.btnResourceRequirements);
      // 
      // splitContainerPostDataMigration.Panel2
      // 
      this.splitContainerPostDataMigration.Panel2.Controls.Add(this.tbPostDataMigrationResults);
      this.splitContainerPostDataMigration.Size = new System.Drawing.Size(1700, 901);
      this.splitContainerPostDataMigration.SplitterDistance = 1108;
      this.splitContainerPostDataMigration.SplitterWidth = 5;
      this.splitContainerPostDataMigration.TabIndex = 0;
      // 
      // cbProcessClosedWorkOrders
      // 
      this.cbProcessClosedWorkOrders.AutoSize = true;
      this.cbProcessClosedWorkOrders.Location = new System.Drawing.Point(24, 82);
      this.cbProcessClosedWorkOrders.Margin = new System.Windows.Forms.Padding(4);
      this.cbProcessClosedWorkOrders.Name = "cbProcessClosedWorkOrders";
      this.cbProcessClosedWorkOrders.Size = new System.Drawing.Size(213, 21);
      this.cbProcessClosedWorkOrders.TabIndex = 1;
      this.cbProcessClosedWorkOrders.Text = "Process Closed Work Orders";
      this.cbProcessClosedWorkOrders.UseVisualStyleBackColor = true;
      // 
      // cbProcessAllWorkOrders
      // 
      this.cbProcessAllWorkOrders.AutoSize = true;
      this.cbProcessAllWorkOrders.Location = new System.Drawing.Point(24, 54);
      this.cbProcessAllWorkOrders.Margin = new System.Windows.Forms.Padding(4);
      this.cbProcessAllWorkOrders.Name = "cbProcessAllWorkOrders";
      this.cbProcessAllWorkOrders.Size = new System.Drawing.Size(265, 21);
      this.cbProcessAllWorkOrders.TabIndex = 1;
      this.cbProcessAllWorkOrders.Text = "Ignore Related Records Created Flag";
      this.cbProcessAllWorkOrders.UseVisualStyleBackColor = true;
      // 
      // btnResourceRequirements
      // 
      this.btnResourceRequirements.Location = new System.Drawing.Point(24, 14);
      this.btnResourceRequirements.Margin = new System.Windows.Forms.Padding(4);
      this.btnResourceRequirements.Name = "btnResourceRequirements";
      this.btnResourceRequirements.Size = new System.Drawing.Size(277, 33);
      this.btnResourceRequirements.TabIndex = 0;
      this.btnResourceRequirements.Text = "Create Work Order Related Records";
      this.btnResourceRequirements.UseVisualStyleBackColor = true;
      this.btnResourceRequirements.Click += new System.EventHandler(this.btnResourceRequirements_Click);
      // 
      // tbPostDataMigrationResults
      // 
      this.tbPostDataMigrationResults.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tbPostDataMigrationResults.Location = new System.Drawing.Point(0, 0);
      this.tbPostDataMigrationResults.Margin = new System.Windows.Forms.Padding(4);
      this.tbPostDataMigrationResults.Multiline = true;
      this.tbPostDataMigrationResults.Name = "tbPostDataMigrationResults";
      this.tbPostDataMigrationResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.tbPostDataMigrationResults.Size = new System.Drawing.Size(587, 901);
      this.tbPostDataMigrationResults.TabIndex = 0;
      this.tbPostDataMigrationResults.WordWrap = false;
      // 
      // tpEntityCompare
      // 
      this.tpEntityCompare.Location = new System.Drawing.Point(4, 25);
      this.tpEntityCompare.Margin = new System.Windows.Forms.Padding(4);
      this.tpEntityCompare.Name = "tpEntityCompare";
      this.tpEntityCompare.Padding = new System.Windows.Forms.Padding(4);
      this.tpEntityCompare.Size = new System.Drawing.Size(1700, 901);
      this.tpEntityCompare.TabIndex = 0;
      this.tpEntityCompare.Text = "Entity Compare";
      this.tpEntityCompare.UseVisualStyleBackColor = true;
      // 
      // dtSourceRequirementsBindingSource
      // 
      this.dtSourceRequirementsBindingSource.DataMember = "dtSourceRequirements";
      this.dtSourceRequirementsBindingSource.DataSource = this.dsFSMigrationBindingSource;
      // 
      // dsMobileProjects
      // 
      this.dsMobileProjects.DataSetName = "dsMobileProjects";
      this.dsMobileProjects.Tables.AddRange(new System.Data.DataTable[] {
            this.dtMobileProject});
      // 
      // dtMobileProject
      // 
      this.dtMobileProject.Columns.AddRange(new System.Data.DataColumn[] {
            this.dc_resco_mobileprojectid,
            this.dc_resco_name,
            this.dc_resco_parents,
            this.dc_resco_priority,
            this.dc_resco_publishedon,
            this.dc_resco_publishedversion,
            this.dc_resco_roleid,
            this.dc_resco_rootmobileprojectid,
            this.dc_resco_type});
      this.dtMobileProject.TableName = "dtMobileProject";
      // 
      // dc_resco_mobileprojectid
      // 
      this.dc_resco_mobileprojectid.AllowDBNull = false;
      this.dc_resco_mobileprojectid.ColumnName = "resco_mobileprojectid";
      this.dc_resco_mobileprojectid.DataType = typeof(System.Guid);
      // 
      // dc_resco_name
      // 
      this.dc_resco_name.AllowDBNull = false;
      this.dc_resco_name.Caption = "resco_name";
      this.dc_resco_name.ColumnName = "resco_name";
      // 
      // dc_resco_parents
      // 
      this.dc_resco_parents.Caption = "resco_parents";
      this.dc_resco_parents.ColumnName = "resco_parents";
      // 
      // dc_resco_priority
      // 
      this.dc_resco_priority.ColumnName = "resco_priority";
      this.dc_resco_priority.DataType = typeof(short);
      // 
      // dc_resco_publishedon
      // 
      this.dc_resco_publishedon.ColumnName = "resco_publishedon";
      this.dc_resco_publishedon.DataType = typeof(System.DateTime);
      // 
      // dc_resco_publishedversion
      // 
      this.dc_resco_publishedversion.ColumnName = "resco_publishedversion";
      this.dc_resco_publishedversion.DataType = typeof(short);
      // 
      // dc_resco_roleid
      // 
      this.dc_resco_roleid.ColumnName = "resco_roleid";
      this.dc_resco_roleid.DataType = typeof(System.Guid);
      // 
      // dc_resco_rootmobileprojectid
      // 
      this.dc_resco_rootmobileprojectid.ColumnName = "resco_rootmobileprojectid";
      this.dc_resco_rootmobileprojectid.DataType = typeof(System.Guid);
      // 
      // dc_resco_type
      // 
      this.dc_resco_type.ColumnName = "resco_type";
      this.dc_resco_type.DataType = typeof(short);
      // 
      // bindingSourceConnections
      // 
      this.bindingSourceConnections.DataSource = typeof(McTools.Xrm.Connection.ConnectionDetail);
      // 
      // splitContainerMain
      // 
      this.splitContainerMain.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainerMain.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
      this.splitContainerMain.Location = new System.Drawing.Point(0, 31);
      this.splitContainerMain.Margin = new System.Windows.Forms.Padding(4);
      this.splitContainerMain.Name = "splitContainerMain";
      // 
      // splitContainerMain.Panel1
      // 
      this.splitContainerMain.Panel1.Controls.Add(this.txtErrorInfo);
      this.splitContainerMain.Panel1.Controls.Add(this.btnConnectSourceOrg);
      this.splitContainerMain.Panel1.Controls.Add(this.btnConnectTargetOrg);
      this.splitContainerMain.Panel1.Controls.Add(this.textSourceConnection);
      this.splitContainerMain.Panel1.Controls.Add(this.textTargetConnection);
      // 
      // splitContainerMain.Panel2
      // 
      this.splitContainerMain.Panel2.Controls.Add(this.tabMain);
      this.splitContainerMain.Size = new System.Drawing.Size(1937, 930);
      this.splitContainerMain.SplitterDistance = 224;
      this.splitContainerMain.SplitterWidth = 5;
      this.splitContainerMain.TabIndex = 9;
      // 
      // txtErrorInfo
      // 
      this.txtErrorInfo.AcceptsReturn = true;
      this.txtErrorInfo.AcceptsTab = true;
      this.txtErrorInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.txtErrorInfo.Location = new System.Drawing.Point(5, 164);
      this.txtErrorInfo.Margin = new System.Windows.Forms.Padding(4);
      this.txtErrorInfo.Multiline = true;
      this.txtErrorInfo.Name = "txtErrorInfo";
      this.txtErrorInfo.ScrollBars = System.Windows.Forms.ScrollBars.Both;
      this.txtErrorInfo.Size = new System.Drawing.Size(213, 762);
      this.txtErrorInfo.TabIndex = 14;
      // 
      // btnConnectSourceOrg
      // 
      this.btnConnectSourceOrg.Image = global::MSCPS.F12FSMigration.Properties.Resources.ConnectFilled_16x;
      this.btnConnectSourceOrg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnConnectSourceOrg.Location = new System.Drawing.Point(4, 18);
      this.btnConnectSourceOrg.Margin = new System.Windows.Forms.Padding(4);
      this.btnConnectSourceOrg.Name = "btnConnectSourceOrg";
      this.btnConnectSourceOrg.Size = new System.Drawing.Size(124, 28);
      this.btnConnectSourceOrg.TabIndex = 13;
      this.btnConnectSourceOrg.Text = "Source Org";
      this.btnConnectSourceOrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnConnectSourceOrg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnConnectSourceOrg.UseVisualStyleBackColor = true;
      // 
      // btnConnectTargetOrg
      // 
      this.btnConnectTargetOrg.Image = global::MSCPS.F12FSMigration.Properties.Resources.ConnectFilled_16x;
      this.btnConnectTargetOrg.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnConnectTargetOrg.Location = new System.Drawing.Point(5, 96);
      this.btnConnectTargetOrg.Margin = new System.Windows.Forms.Padding(4);
      this.btnConnectTargetOrg.Name = "btnConnectTargetOrg";
      this.btnConnectTargetOrg.Size = new System.Drawing.Size(123, 28);
      this.btnConnectTargetOrg.TabIndex = 12;
      this.btnConnectTargetOrg.Text = "Target Org";
      this.btnConnectTargetOrg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
      this.btnConnectTargetOrg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
      this.btnConnectTargetOrg.UseVisualStyleBackColor = true;
      this.btnConnectTargetOrg.Click += new System.EventHandler(this.btnConnectTargetOrg_Click);
      // 
      // textSourceConnection
      // 
      this.textSourceConnection.Location = new System.Drawing.Point(5, 49);
      this.textSourceConnection.Margin = new System.Windows.Forms.Padding(4);
      this.textSourceConnection.Name = "textSourceConnection";
      this.textSourceConnection.ReadOnly = true;
      this.textSourceConnection.Size = new System.Drawing.Size(271, 22);
      this.textSourceConnection.TabIndex = 11;
      // 
      // textTargetConnection
      // 
      this.textTargetConnection.Location = new System.Drawing.Point(5, 132);
      this.textTargetConnection.Margin = new System.Windows.Forms.Padding(4);
      this.textTargetConnection.Name = "textTargetConnection";
      this.textTargetConnection.ReadOnly = true;
      this.textTargetConnection.Size = new System.Drawing.Size(271, 22);
      this.textTargetConnection.TabIndex = 11;
      // 
      // filedlgSaveMapping
      // 
      this.filedlgSaveMapping.CreatePrompt = true;
      this.filedlgSaveMapping.DefaultExt = "xml";
      this.filedlgSaveMapping.Filter = "Mapping File|*.xml";
      this.filedlgSaveMapping.Title = "Save Mapping";
      // 
      // filedlgOpenRoleMapping
      // 
      this.filedlgOpenRoleMapping.DefaultExt = "xml";
      this.filedlgOpenRoleMapping.Filter = "Role Mapping|*.xml";
      // 
      // btnAddSPRole
      // 
      this.btnAddSPRole.Location = new System.Drawing.Point(549, 7);
      this.btnAddSPRole.Name = "btnAddSPRole";
      this.btnAddSPRole.Size = new System.Drawing.Size(123, 29);
      this.btnAddSPRole.TabIndex = 17;
      this.btnAddSPRole.Text = "Add SP Role";
      this.btnAddSPRole.UseVisualStyleBackColor = true;
      this.btnAddSPRole.Click += new System.EventHandler(this.btnAddSPRole_Click);
      // 
      // F12FSMigrationPluginControl
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.Controls.Add(this.splitContainerMain);
      this.Controls.Add(this.toolStripMenu);
      this.Margin = new System.Windows.Forms.Padding(4);
      this.Name = "F12FSMigrationPluginControl";
      this.Size = new System.Drawing.Size(1937, 961);
      this.Load += new System.EventHandler(this.F12FSMigrationControl_Load);
      this.toolStripMenu.ResumeLayout(false);
      this.toolStripMenu.PerformLayout();
      this.tabMain.ResumeLayout(false);
      this.tpProcessManagement.ResumeLayout(false);
      this.tpProcessManagement.PerformLayout();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel1.PerformLayout();
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
      this.splitContainer2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgWorkflows)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsProcesses)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtWorkflows)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtPluginSteps)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgPluginSteps)).EndInit();
      this.tpPreDataMigration.ResumeLayout(false);
      this.tcUserManagement.ResumeLayout(false);
      this.tpBUMapping.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgBUMapping)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsFSMigrationBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsFSMigration)).EndInit();
      this.tpCurrencyMapping.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgCurrenyMapping)).EndInit();
      this.tpRoleMapping.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgRoleMapping)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtSecurityRoleMappingBindingSource)).EndInit();
      this.tpStubUsers.ResumeLayout(false);
      this.tpStubUsers.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgSystemUsers)).EndInit();
      this.tpUserSecurity.ResumeLayout(false);
      this.tpUserSecurity.PerformLayout();
      this.scUserSecurityMain.Panel1.ResumeLayout(false);
      this.scUserSecurityMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scUserSecurityMain)).EndInit();
      this.scUserSecurityMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgUserSecurity)).EndInit();
      this.scUserSecurityRoles.Panel1.ResumeLayout(false);
      this.scUserSecurityRoles.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scUserSecurityRoles)).EndInit();
      this.scUserSecurityRoles.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgSourceUserRoles)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgTargetUserRoles)).EndInit();
      this.tpTeamMembership.ResumeLayout(false);
      this.splitContainer4.Panel1.ResumeLayout(false);
      this.splitContainer4.Panel1.PerformLayout();
      this.splitContainer4.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
      this.splitContainer4.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamMembership)).EndInit();
      this.splitContainer5.Panel1.ResumeLayout(false);
      this.splitContainer5.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
      this.splitContainer5.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgSourceTeamMembership)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtSourceTeamMembershipBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgTargetTeamMembership)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtTargetTeamMembershipBindingSource)).EndInit();
      this.tpTeamSecurity.ResumeLayout(false);
      this.tpTeamSecurity.PerformLayout();
      this.scTeamSecurityMain.Panel1.ResumeLayout(false);
      this.scTeamSecurityMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scTeamSecurityMain)).EndInit();
      this.scTeamSecurityMain.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgTeamSecurity)).EndInit();
      this.scTeamSecurityRoles.Panel1.ResumeLayout(false);
      this.scTeamSecurityRoles.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.scTeamSecurityRoles)).EndInit();
      this.scTeamSecurityRoles.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgSourceTeamRoles)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dgTargetTeamRoles)).EndInit();
      this.tpUOMSync.ResumeLayout(false);
      this.splitContainerUOM.Panel1.ResumeLayout(false);
      this.splitContainerUOM.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerUOM)).EndInit();
      this.splitContainerUOM.ResumeLayout(false);
      this.panel1.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgUOMSchedule)).EndInit();
      this.panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgUOM)).EndInit();
      this.tpDataCleanup.ResumeLayout(false);
      this.tpDataCleanup.PerformLayout();
      this.splitContainer6.Panel1.ResumeLayout(false);
      this.splitContainer6.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer6)).EndInit();
      this.splitContainer6.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgDataCleanupResults)).EndInit();
      this.splitContainer7.Panel1.ResumeLayout(false);
      this.splitContainer7.Panel1.PerformLayout();
      this.splitContainer7.Panel2.ResumeLayout(false);
      this.splitContainer7.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer7)).EndInit();
      this.splitContainer7.ResumeLayout(false);
      this.tpAgreementProcessing.ResumeLayout(false);
      this.tcAgreementProcessing.ResumeLayout(false);
      this.tpAgreementWorkflowReset.ResumeLayout(false);
      this.tpAgreementWorkflowReset.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.dgAgreementWorkflowResetAgreements)).EndInit();
      this.tpAgreementFailures.ResumeLayout(false);
      this.tpAgreementFailures.PerformLayout();
      this.splitContainer8.Panel1.ResumeLayout(false);
      this.splitContainer8.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer8)).EndInit();
      this.splitContainer8.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgAreementFailuresSystemJobs)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtAgreementFailuresBindingSource)).EndInit();
      this.tpAgreementPerfTesting.ResumeLayout(false);
      this.scAgreementProcessing.Panel1.ResumeLayout(false);
      this.scAgreementProcessing.Panel1.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.scAgreementProcessing)).EndInit();
      this.scAgreementProcessing.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dgBookingSetup)).EndInit();
      this.tpAgreementPostDataMigration.ResumeLayout(false);
      this.splitContainer1.Panel1.ResumeLayout(false);
      this.splitContainer1.Panel1.PerformLayout();
      this.splitContainer1.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
      this.splitContainer1.ResumeLayout(false);
      this.splitContainer3.Panel1.ResumeLayout(false);
      this.splitContainer3.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
      this.splitContainer3.ResumeLayout(false);
      this.tpPostDataMigration.ResumeLayout(false);
      this.splitContainerPostDataMigration.Panel1.ResumeLayout(false);
      this.splitContainerPostDataMigration.Panel1.PerformLayout();
      this.splitContainerPostDataMigration.Panel2.ResumeLayout(false);
      this.splitContainerPostDataMigration.Panel2.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerPostDataMigration)).EndInit();
      this.splitContainerPostDataMigration.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.dtSourceRequirementsBindingSource)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dsMobileProjects)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.dtMobileProject)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.bindingSourceConnections)).EndInit();
      this.splitContainerMain.Panel1.ResumeLayout(false);
      this.splitContainerMain.Panel1.PerformLayout();
      this.splitContainerMain.Panel2.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.splitContainerMain)).EndInit();
      this.splitContainerMain.ResumeLayout(false);
      this.ResumeLayout(false);
      this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip toolStripMenu;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripSeparator tssSeparator1;
        private System.Windows.Forms.TabControl tabMain;
        private System.Windows.Forms.TabPage tpEntityCompare;
        private System.Windows.Forms.TabPage tpPostDataMigration;
        private System.Windows.Forms.SplitContainer splitContainerPostDataMigration;
        private System.Windows.Forms.Button btnResourceRequirements;
        private System.Windows.Forms.TextBox tbPostDataMigrationResults;
        private System.Windows.Forms.TabPage tpProcessManagement;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnRetriveProcesses;
        private System.Windows.Forms.DataGridView dgWorkflows;
        private System.Windows.Forms.DataGridView dgPluginSteps;
        private System.Data.DataSet dsProcesses;
        private System.Data.DataTable dtWorkflows;
        private System.Data.DataColumn dcWFId;
        private System.Data.DataColumn dcWFState;
        private System.Data.DataColumn dcWFName;
        private System.Data.DataTable dtPluginSteps;
        private System.Data.DataColumn dcPSId;
        private System.Data.DataColumn dcPSState;
        private System.Data.DataColumn dcPSName;
        private System.Windows.Forms.Button btnDisableSelectPluginSteps;
        private System.Windows.Forms.Button btnDisableSelectedWorkflows;
        private System.Data.DataColumn dcWFPrimaryEntity;
        private System.Data.DataColumn dcWFIsManaged;
        private System.Data.DataColumn dcPSIsManaged;
        private System.Windows.Forms.DataGridViewTextBoxColumn State;
        private System.Windows.Forms.DataGridViewTextBoxColumn WFName;
        private System.Windows.Forms.DataGridViewTextBoxColumn PrimaryEntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn IsManaged;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnEnableSelectedWorkflows;
        private System.Windows.Forms.Button btnEnableSelectedPluginSteps;
        private System.Windows.Forms.BindingSource bindingSourceConnections;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbEntityList;
        private System.Windows.Forms.Button btnEnableAllProcessesByEntity;
        private System.Windows.Forms.Button btnDisableAllProcessesByEntity;
        private System.Windows.Forms.Button btnRetriaveAllProcessesByEntity;
        private System.Data.DataColumn dcPSPrimaryEntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn PSName;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.ToolStripButton tsbCancelOperation;
        private System.Windows.Forms.CheckBox cbProcessAllWorkOrders;
        private System.Windows.Forms.ToolStripButton tsbOpenLogFile;
        private System.Windows.Forms.Button btnDisableAllProcesses;
        private System.Windows.Forms.SplitContainer splitContainerMain;
        private System.Windows.Forms.FolderBrowserDialog dialogFSMigrationToolingPath;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.TextBox textTargetConnection;
        private System.Windows.Forms.Button btnConnectTargetOrg;
        private System.Windows.Forms.Button btnConnectSourceOrg;
        private System.Windows.Forms.TextBox textSourceConnection;
        private System.Windows.Forms.CheckBox cbProcessClosedWorkOrders;
        private System.Data.DataSet dsMobileProjects;
        private System.Data.DataTable dtMobileProject;
        private System.Data.DataColumn dc_resco_mobileprojectid;
        private System.Data.DataColumn dc_resco_name;
        private System.Data.DataColumn dc_resco_parents;
        private System.Data.DataColumn dc_resco_priority;
        private System.Data.DataColumn dc_resco_publishedon;
        private System.Data.DataColumn dc_resco_publishedversion;
        private System.Data.DataColumn dc_resco_roleid;
        private System.Data.DataColumn dc_resco_rootmobileprojectid;
        private System.Data.DataColumn dc_resco_type;
        private System.Windows.Forms.TabPage tpPreDataMigration;
        private System.Windows.Forms.DataGridView dgSystemUsers;
        private dsFSMigration dsFSMigration;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeidDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnCreateStubUsers;
        private System.Windows.Forms.Button btnLoadSourceUsers;
        private System.Windows.Forms.CheckBox cbAddStubUsersCheckUncheck;
        private System.Windows.Forms.Label lblUsersTotalInfo;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addStubToTargetDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isInTargetDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn domainnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn firstnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dsFSMigrationBindingSource;
        private System.Windows.Forms.CheckBox cbHideInTarget;
        private System.Windows.Forms.TabControl tcUserManagement;
        private System.Windows.Forms.TabPage tpStubUsers;
        private System.Windows.Forms.TabPage tpUserSecurity;
        private System.Windows.Forms.Button btnCompareSecurityRoles;
        private System.Windows.Forms.DataGridView dgUserSecurity;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcefullnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetfullnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer scUserSecurityMain;
        private System.Windows.Forms.SplitContainer scUserSecurityRoles;
        private System.Windows.Forms.Label lblSourceUserRoles;
        private System.Windows.Forms.DataGridView dgSourceUserRoles;
        private System.Windows.Forms.Label lblTargetUserRoles;
        private System.Windows.Forms.DataGridView dgTargetUserRoles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn1;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn2;
        private System.Windows.Forms.CheckBox ckUserSecurityCheckUncheck;
        private System.Windows.Forms.Button btnSyncSecurityRoles;
        private System.Windows.Forms.TabPage tpRoleMapping;
        private System.Windows.Forms.Button btnMapRoles;
        private System.Windows.Forms.DataGridView dgRoleMapping;
        private System.Windows.Forms.BindingSource dtSecurityRoleMappingBindingSource;
        private System.Windows.Forms.Button btnSaveRoleMappings;
        private System.Windows.Forms.Button btnLoadRoleMappings;
        private System.Windows.Forms.SaveFileDialog filedlgSaveMapping;
        private System.Windows.Forms.OpenFileDialog filedlgOpenRoleMapping;
        private System.Windows.Forms.CheckBox ckClearTargetRoles;
        private System.Windows.Forms.TextBox txtErrorInfo;
        private System.Windows.Forms.Button btnSyncUserSettings;
        private System.Windows.Forms.TabPage tpBUMapping;
        private System.Windows.Forms.DataGridView dgBUMapping;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetbuiidDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnLoadBUMapping;
        private System.Windows.Forms.Button btnSaveBUMapping;
        private System.Windows.Forms.Button btnMapBU;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcebuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcebunameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_buid;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetbunameDataGridViewTextBoxColumn;
        private System.Windows.Forms.TabPage tpCurrencyMapping;
        private System.Windows.Forms.DataGridView dgCurrenyMapping;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcetransactioncurrencyidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceisocurrencycodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn soucecurrencynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcecurrencysymbolDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targettransactioncurrencyidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetisocurrencycodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetcurrencynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetcurrencysymbolDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnLoadCurrencyMapping;
        private System.Windows.Forms.Button btnSaveCurrencyMapping;
        private System.Windows.Forms.Button btnCurrencyMapping;
        private System.Windows.Forms.CheckBox cbSyncSettings;
        private System.Windows.Forms.CheckBox cbUserSnycBusinessUnit;
        private System.Windows.Forms.TabPage tpAgreementProcessing;
        private System.Windows.Forms.DataGridViewTextBoxColumn source_businessunitname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceroleidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcerolenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn source_parentrootroleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_businessunitname;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetroleidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetrolenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SyncRoles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ClearTargetRoles;
        private System.Windows.Forms.DataGridViewCheckBoxColumn RolesMatch;
        private System.Windows.Forms.DataGridViewCheckBoxColumn source_IsDisabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn source_buname;
        private System.Windows.Forms.DataGridViewTextBoxColumn source_domainname;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcerolenamesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn target_IsDisabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_buname;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetrolenamesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn source_roleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn source_rolename;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_roleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_rolename;
        private System.Windows.Forms.CheckBox cbStubUsersHideDisabled;
        private System.Windows.Forms.CheckBox cbUserSecurityHideDisabled;
        private System.Windows.Forms.TabPage tpDataCleanup;
        private System.Windows.Forms.ComboBox cbDataCleanupSourceEntityList;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnDataCleanupValidateRecords;
        private System.Windows.Forms.ComboBox cbDataCleanupTargetEntityList;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnDataCleanupLoadSourceEntities;
        private System.Windows.Forms.Button btnDataCleanupLoadTargetEntities;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtDataCleanupSourceAttribute;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDataCleanupTargetAttribute;
        private System.Windows.Forms.Button btnDataCleanupDeleteRecords;
        private System.Windows.Forms.Button btnDataCleanupCreateTestData;
        private System.Windows.Forms.TabPage tpTeamMembership;
        private System.Windows.Forms.TabPage tpTeamSecurity;
        private System.Windows.Forms.SplitContainer scTeamSecurityMain;
        private System.Windows.Forms.CheckBox ckClearTeamTargetRoles;
        private System.Windows.Forms.CheckBox ckTeamSecurityCheckUncheck;
        private System.Windows.Forms.Button btnTeamSyncRoles;
        private System.Windows.Forms.Button btnCompareTeamSecurity;
        private System.Windows.Forms.SplitContainer scTeamSecurityRoles;
        private System.Windows.Forms.DataGridView dgTeamSecurity;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.DataGridView dgSourceTeamRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgTargetTeamRoles;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewCheckBoxColumn rolesMatchDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn syncRolesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clearTargetRolesDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcebusinessunitidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcebunameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteamidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcerolenamesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetbusinessunitidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetbunameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetteamidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetrolenamesDataGridViewTextBoxColumn1;
        private System.Windows.Forms.TabControl tcAgreementProcessing;
        private System.Windows.Forms.TabPage tpAgreementPerfTesting;
        private System.Windows.Forms.SplitContainer scAgreementProcessing;
        private System.Windows.Forms.Label lblBookingSetupTotalRecords;
        private System.Windows.Forms.CheckBox cbBookingSetupCheckUncheck;
        private System.Windows.Forms.Button btnBookingSetupUpdate;
        private System.Windows.Forms.DateTimePicker dpBookingSetupStartDate;
        private System.Windows.Forms.DataGridView dgBookingSetup;
        private System.Windows.Forms.DataGridViewCheckBoxColumn UpdateAgreement;
        private System.Windows.Forms.DataGridViewTextBoxColumn msdynnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msdynrecurrencesettingsDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msdynrevisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msdynpostponegenerationuntilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msdyngeneratewodaysinadvanceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn agreementNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msdynagreementbookingsetupidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn msdynagreementDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnRetrieveBookingSetup;
        private System.Windows.Forms.TabPage tpAgreementPostDataMigration;
        private System.Windows.Forms.TabPage tpAgreementWorkflowReset;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Button btnAgreementResetInvoiceSetup;
        private System.Windows.Forms.Button btnAgreementResetBookingSetup;
        private System.Windows.Forms.TextBox txtAgreementProcessingResults;
        private System.Windows.Forms.Button btnAgreementMarkExpired;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.Button btnTeamMembershipLoadTeams;
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btnTeamAddUserLoadTeams;
        private System.Windows.Forms.DataGridView dgTeamMembership;
        private System.Windows.Forms.DataGridViewCheckBoxColumn syncTeamMembersDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn clearTargetTeamMembersDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteamidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteamnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteambusinessunitidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteambunameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteammembersDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetteamidDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetteamnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetteambusinessunitidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetteambunameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetteammembersDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox cbClearTargetMembersCheckUncheck;
        private System.Windows.Forms.CheckBox cbSyncTeamMembersCheckUncheck;
        private System.Windows.Forms.Button btnSyncTeamMembers;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgSourceTeamMembership;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.DataGridView dgTargetTeamMembership;
        private System.Windows.Forms.SplitContainer splitContainer6;
        private System.Windows.Forms.DataGridView dgDataCleanupResults;
        private System.Windows.Forms.DataGridViewTextBoxColumn entitylogicalname;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainer7;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtDataCleanupSourceFetchXml;
        private System.Windows.Forms.TextBox txtDataCleanupTargetFetchXml;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn6;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn5;
        private System.Windows.Forms.DataGridViewCheckBoxColumn target_isdefault;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteamidDataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetteamidDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.CheckBox cbStubUsersHideMatchingBU;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cbAgreementWorkFlowResetUsers;
        private System.Windows.Forms.Button btnAgreementWorkflowResetRefreshUsers;
        private System.Windows.Forms.DataGridView dgAgreementWorkflowResetAgreements;
        private System.Windows.Forms.Button btnAgreementWorkflowResetSearch;
        private System.Windows.Forms.BindingSource dtTargetTeamMembershipBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_teamid;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_teamname;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetuseridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn target_username;
        private System.Windows.Forms.DataGridViewCheckBoxColumn target_userisdisabled;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceteamidDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceuseridDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceusernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn source_userisdisabled;
        private System.Windows.Forms.BindingSource dtSourceTeamMembershipBindingSource;
        private System.Windows.Forms.Button btnAgreementWorkflowReset;
        private System.Windows.Forms.DataGridViewTextBoxColumn agreementnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn agreementidDataGridViewTextBoxColumn;
        private System.Windows.Forms.CheckBox cbUserSnycUserInfo;
        private System.Windows.Forms.CheckBox cbUserSnycSettings;
        private System.Windows.Forms.TabPage tpAgreementFailures;
        private System.Windows.Forms.SplitContainer splitContainer8;
        private System.Windows.Forms.DataGridView dgAreementFailuresSystemJobs;
        private System.Windows.Forms.PropertyGrid pgAgreementObjectDetails;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn regardingobjectidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regardingobjectnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn operationtypenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startedonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn completedonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownernameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn owningextensionnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn errorcodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messagenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn friendlynameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn messageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn postponeuntilDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn primaryentitytypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statuscodenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource dtAgreementFailuresBindingSource;
        private System.Windows.Forms.DateTimePicker dtpAgreementFailuresStart;
        private System.Windows.Forms.Button btnAgreementFailuresLoad;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label lbl1;
        private System.Windows.Forms.DateTimePicker dtpAgreementFailuresEnd;
        private System.Windows.Forms.BindingSource dtSourceRequirementsBindingSource;
        private System.Windows.Forms.TabPage tpUOMSync;
        private System.Windows.Forms.DataGridView dgUOMSchedule;
        private System.Windows.Forms.Button btnMapUOM;
        private System.Windows.Forms.Button btnCreateTargetUOMSchedule;
        private System.Windows.Forms.DataGridViewCheckBoxColumn addToTargetDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcenameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcequantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetnameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetquantityDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn sourceisschedulebaseuomDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceuomscheduleidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetuomscheduleidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceorganizationidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetorganizationidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourceuomidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetuomidDataGridViewTextBoxColumn;
        private System.Windows.Forms.SplitContainer splitContainerUOM;
        private System.Windows.Forms.Button btnMapUOMSchedule;
        private System.Windows.Forms.DataGridView dgUOM;
        private System.Windows.Forms.Button btnCreateTargetUOM;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn8;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcecreatedbyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcecreatedonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private System.Windows.Forms.DataGridViewTextBoxColumn sourcenameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private System.Windows.Forms.DataGridViewTextBoxColumn targetnameDataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn11;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.CheckBox cbHideWithSPRole;
        private System.Windows.Forms.CheckBox cbCreate_z_StubUser;
    private System.Windows.Forms.CheckBox cbStubUsersHideUnlicensed;
    private System.Windows.Forms.CheckBox cbUserSecurityHideUnLicensed;
    private System.Windows.Forms.DataGridViewCheckBoxColumn IsInTarget;
    private System.Windows.Forms.DataGridViewCheckBoxColumn target_bumatch;
    private System.Windows.Forms.DataGridViewCheckBoxColumn MissingSPRole;
    private System.Windows.Forms.DataGridViewCheckBoxColumn AddZ_StubToTarget;
    private System.Windows.Forms.DataGridViewCheckBoxColumn AddStubToTarget;
    private System.Windows.Forms.DataGridViewCheckBoxColumn SyncSettings;
    private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn3;
    private System.Windows.Forms.DataGridViewCheckBoxColumn source_islicensed;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
    private System.Windows.Forms.DataGridViewTextBoxColumn sourcedomainDataGridViewTextBoxColumn;
    private System.Windows.Forms.DataGridViewTextBoxColumn source_identitiyid;
    private System.Windows.Forms.DataGridViewTextBoxColumn fullname;
    private System.Windows.Forms.DataGridViewTextBoxColumn source_parentsystemusername;
    private System.Windows.Forms.DataGridViewTextBoxColumn source_territoryname;
    private System.Windows.Forms.DataGridViewTextBoxColumn source_transactioncurrencyname;
    private System.Windows.Forms.DataGridViewCheckBoxColumn dataGridViewCheckBoxColumn4;
    private System.Windows.Forms.DataGridViewCheckBoxColumn target_islicensed;
    private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
    private System.Windows.Forms.DataGridViewTextBoxColumn target_DomainName;
    private System.Windows.Forms.DataGridViewTextBoxColumn target_identityid;
    private System.Windows.Forms.DataGridViewTextBoxColumn target_FullName;
    private System.Windows.Forms.DataGridViewTextBoxColumn target_parentsystemusername;
    private System.Windows.Forms.DataGridViewTextBoxColumn target_territoryname;
    private System.Windows.Forms.DataGridViewTextBoxColumn target_transactioncurrencyname;
    private System.Windows.Forms.Button btnAddSPRole;
  }
}
