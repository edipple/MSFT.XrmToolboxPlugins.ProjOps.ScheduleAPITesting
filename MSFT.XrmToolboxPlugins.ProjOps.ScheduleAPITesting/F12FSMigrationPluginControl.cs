using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using XrmToolBox.Extensibility;
using Microsoft.Xrm.Sdk.Query;
using Microsoft.Xrm.Sdk;
using McTools.Xrm.Connection;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;
using System.Collections.Specialized;
using Microsoft.Xrm.Sdk.Metadata;
using XrmToolBox.Extensibility.Interfaces;
using XrmToolBox.Extensibility.Args;
using Microsoft.Web.XmlTransform;

namespace MSCPS.F12FSMigration {
  public partial class F12FSMigrationPluginControl : MultipleConnectionsPluginControlBase, IStatusBarMessenger {
    private Settings mySettings;
    private List<Workflow> workFlows;
    private ConnectionDetail cdTarget;
    private ConnectionDetail cdSource;
    private IOrganizationService svcTarget;
    private IOrganizationService svcSource;
    private UpgradeUtility upgradeUtility;

    public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
    private Entity debugSourceUserTeam { get; set; }
    private Entity debugTargetUserTeam { get; set; }
    private string debugSourceUserTeamRoles { get; set; }
    private string debugTargetUserTeamRoles { get; set; }
    private string errorMessage { get; set; }

    public F12FSMigrationPluginControl() {
      InitializeComponent();
    }

    protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs e) {
      int i = 0;
    }

    public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName = "", object parameter = null) {
      ConnectionDetail = detail;
      if (actionName == "AdditionalOrganization") {
        AdditionalConnectionDetails.Clear();
        AdditionalConnectionDetails.Add(detail);
        cdTarget = detail;
        svcTarget = cdTarget.ServiceClient.OrganizationServiceProxy;
        if (upgradeUtility != null)
          upgradeUtility.TargetService = cdTarget.ServiceClient.OrganizationServiceProxy;
        else
          upgradeUtility = new UpgradeUtility(cdTarget.ServiceClient.OrganizationServiceProxy, cdSource != null ? cdSource.ServiceClient.OrganizationServiceProxy : null);
        LoadTargetEntitiesList();
        dtPluginSteps.Clear();
        dtWorkflows.Clear();
      }
      else {
        cdSource = detail;
        svcSource = cdSource.ServiceClient.OrganizationServiceProxy;
        base.UpdateConnection(newService, detail, actionName, parameter);
        if (mySettings != null && detail != null) {
          mySettings.LastUsedOrganizationWebappUrl = detail.WebApplicationUrl;
          LogInfo("Source connection has changed to: {0}", detail.WebApplicationUrl);
        }
        if (upgradeUtility != null)
          upgradeUtility.SourceService = cdSource.ServiceClient.OrganizationServiceProxy;
        else
          upgradeUtility = new UpgradeUtility(cdSource != null ? cdSource.ServiceClient.OrganizationServiceProxy : null, cdSource.ServiceClient.OrganizationServiceProxy);
        LoadSourceEntitiesList();
      }

      if (cdSource != null)
        textSourceConnection.Text = cdSource.ConnectionName;
      else
        textSourceConnection.Text = "NOT CONNECTED";

      if (cdTarget != null)
        textTargetConnection.Text = cdTarget.ConnectionName;
      else
        textTargetConnection.Text = "NOT CONNECTED";
    }

    private void F12FSMigrationControl_Load(object sender, EventArgs e) {
      // ShowInfoNotification("This is a notification that can lead to XrmToolBox repository", new Uri("https://github.com/MscrmTools/XrmToolBox"));

      // Loads or creates the settings for the plugin
      if (!SettingsManager.Instance.TryLoad(GetType(), out mySettings))
        mySettings = new Settings();
    }

    private void tsbClose_Click(object sender, EventArgs e) {
      CloseTool();
    }

    private void F12FSMigrationControl_OnCloseTool(object sender, EventArgs e) {
      // Before leaving, save the settings
      SettingsManager.Instance.Save(GetType(), mySettings);
    }

    private void btnDisableAllProcesses_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      WorkAsync(new WorkAsyncInfo {
        Message = $"Disabeling all processes...",
        IsCancelable = true,
        Work = (worker, args) => {
          List<PluginStep> activePluginSteps = upgradeUtility.RetrieveTargetPluginStepList(ActivationState.Active);
          List<Workflow> activeWorkflows = upgradeUtility.RetrieveTargetWorkflowList(ActivationState.Active);
          int iTotalToDisable = activePluginSteps.Count + activeWorkflows.Count;
          int iCounter = 0;
          int percent = 0;
          foreach (PluginStep activeStep in activePluginSteps) {
            if (worker.CancellationPending)
              break;
            iCounter++;
            percent = upgradeUtility.Percent(iCounter, iTotalToDisable);
            worker.ReportProgress(percent, $"Disabeling Plugin Step: {activeStep.Name}{Environment.NewLine}{iCounter} of {activePluginSteps.Count}");
            upgradeUtility.DisableTargetPlugin(activeStep.Id);
          }

          if (!worker.CancellationPending) {
            foreach (Workflow activeWorkflow in activeWorkflows) {
              if (worker.CancellationPending)
                break;
              iCounter++;
              percent = upgradeUtility.Percent(iCounter, iTotalToDisable);
              if (worker.CancellationPending)
                break;
              worker.ReportProgress(percent, $"Disabeling Workflow: {activeWorkflow.Name}{Environment.NewLine}{iCounter} of {activeWorkflows.Count}");
              upgradeUtility.DeactivateTargetWorkflow(activeWorkflow.Id);
            }
          }
          worker.ReportProgress(100, "Done.");
        },
        ProgressChanged = (args) => {
          // TODO Add code to handle the progress change event.
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Disabeling Plugins and Workflows..."));
        },
        PostWorkCallBack = (args) => {
          // TODO Add code to hande the finish of this event.
          if (args.Cancelled)
            MessageBox.Show("Disable All Plugin Steps and Workflows Cancelled");
          else if (args.Error != null)
            MessageBox.Show($"ERROR Disabeling Plugin Steps and Workflows: {args.Error.Message}");
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void btnRetriveProcesses_Click_1(object sender, EventArgs e) {
      LoadPluginSteps();
      LoadWorkflows();
    }

    private void LoadTargetEntitiesList() {
      WorkAsync(new WorkAsyncInfo {
        Message = "Getting Target Entity List...",
        Work = (worker, args) => {
          args.Result = upgradeUtility.RetrieveTargetEntityList();
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          cbEntityList.Items.Clear();
          cbDataCleanupTargetEntityList.Items.Clear();
          var result = args.Result as EntityMetadata[];
          if (result != null) {
            foreach (EntityMetadata em in result) {
              cbEntityList.Items.Add(new ComboboxItem(em.LogicalName, em.PrimaryNameAttribute));
              cbDataCleanupTargetEntityList.Items.Add(new ComboboxItem(em.LogicalName, em.PrimaryNameAttribute));
            }
          }
        }
      });
    }

    private void LoadSourceEntitiesList() {
      WorkAsync(new WorkAsyncInfo {
        Message = "Getting Source Entity List...",
        Work = (worker, args) => {
          args.Result = upgradeUtility.RetrieveSourceEntityList();
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          cbDataCleanupSourceEntityList.Items.Clear();
          var result = args.Result as EntityMetadata[];
          if (result != null) {
            foreach (EntityMetadata em in result) {
              cbDataCleanupSourceEntityList.Items.Add(new ComboboxItem(em.LogicalName, em.PrimaryNameAttribute));
            }
          }
        }
      });
    }

    private void LoadPluginSteps() {
      LoadPluginSteps(ActivationState.All);
    }

    private void LoadPluginSteps(ActivationState state) {
      WorkAsync(new WorkAsyncInfo {
        Message = "Getting Plugin Steps...",
        Work = (worker, args) => {
          args.Result = upgradeUtility.RetrieveTargetPluginStepList(state);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          var result = args.Result as List<PluginStep>;
          if (result != null) {
            dtPluginSteps.Clear();
            foreach (PluginStep ps in result) {
              DataRow dr = dtPluginSteps.NewRow();
              dr["Id"] = ps.Id;
              dr["State"] = ps.State == ActivationState.Active ? "Active" : "Inactive";
              dr["PSName"] = ps.Name;
              dr["PrimaryEntity"] = ps.PrimaryEntity;
              dr["IsManaged"] = ps.IsManaged;
              dtPluginSteps.Rows.Add(dr);
            }
          }
        }
      });
    }

    private void LoadPluginSteps(string entityName) {
      WorkAsync(new WorkAsyncInfo {
        Message = "Getting Plugin Steps...",
        Work = (worker, args) => {
          args.Result = upgradeUtility.RetrieveTargetPluginStepList(entityName);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          var result = args.Result as List<PluginStep>;
          if (result != null) {
            dtPluginSteps.Clear();
            foreach (PluginStep ps in result) {
              DataRow dr = dtPluginSteps.NewRow();
              dr["Id"] = ps.Id;
              dr["State"] = ps.State == ActivationState.Active ? "Active" : "Inactive";
              dr["PSName"] = ps.Name;
              dr["PrimaryEntity"] = ps.PrimaryEntity;
              dr["IsManaged"] = ps.IsManaged;
              dtPluginSteps.Rows.Add(dr);
            }
          }
        }
      });
    }

    private void LoadWorkflows() {
      WorkAsync(new WorkAsyncInfo {
        Message = "Getting Workflows...",
        Work = (worker, args) => {
          args.Result = upgradeUtility.RetrieveTargetWorkflowList(ActivationState.All);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          var result = args.Result as List<Workflow>;
          workFlows = result;

          if (result != null) {
            dtWorkflows.Clear();
            foreach (Workflow wf in result) {
              DataRow dr = dtWorkflows.NewRow();
              dr["Id"] = wf.Id;
              dr["State"] = wf.State == ActivationState.Active ? "Active" : "Inactive";
              dr["WFName"] = wf.Name;
              dr["PrimaryEntity"] = wf.PrimaryEntity;
              dr["IsManaged"] = wf.IsManaged;
              dtWorkflows.Rows.Add(dr);
            }
            dtWorkflows.DefaultView.Sort = "State desc, WFName desc";
          }
        }
      });
    }

    private void LoadWorkflows(string entityName) {
      WorkAsync(new WorkAsyncInfo {
        Message = "Getting Workflows...",
        Work = (worker, args) => {
          args.Result = upgradeUtility.RetrieveTargetWorkflowList(entityName);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          var result = args.Result as List<Workflow>;
          workFlows = result;

          if (result != null) {
            dtWorkflows.Clear();
            foreach (Workflow wf in result) {
              DataRow dr = dtWorkflows.NewRow();
              dr["Id"] = wf.Id;
              dr["State"] = wf.State == ActivationState.Active ? "Active" : "Inactive";
              dr["WFName"] = wf.Name;
              dr["PrimaryEntity"] = wf.PrimaryEntity;
              dr["IsManaged"] = wf.IsManaged;
              dtWorkflows.Rows.Add(dr);
            }
            dtWorkflows.DefaultView.Sort = "State desc, WFName desc";
          }
        }
      });
    }

    private void ActivateWorkflows() {
      int percent = 0;
      int iCounter = 0;
      foreach (DataGridViewRow dgr in dgWorkflows.SelectedRows) {
        iCounter++;
        percent = upgradeUtility.Percent(iCounter, dgWorkflows.SelectedRows.Count);
        DataRowView dr = (DataRowView)dgr.DataBoundItem;
        Guid wfId = (Guid)dr["Id"];
        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(percent, "Activating Workflows..."));
        upgradeUtility.ActivateTargetWorkflow(wfId);
      }
    }

    private void DeactivateWorkflows(BackgroundWorker bg) {
      int percent = 0;
      int iCounter = 0;
      foreach (DataGridViewRow dgr in dgWorkflows.SelectedRows) {
        if (bg.CancellationPending)
          break;
        iCounter++;
        percent = upgradeUtility.Percent(iCounter, dgWorkflows.SelectedRows.Count);
        DataRowView dr = (DataRowView)dgr.DataBoundItem;
        Guid wfId = (Guid)dr["Id"];
        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(percent, "Deactivating Workflows..."));
        upgradeUtility.DeactivateTargetWorkflow(wfId);
      }
    }

    private void EnabledPluginSteps(BackgroundWorker bg) {
      int percent = 0;
      int iCounter = 0;
      foreach (DataGridViewRow dgr in dgPluginSteps.SelectedRows) {
        if (bg.CancellationPending)
          break;
        iCounter++;
        percent = upgradeUtility.Percent(iCounter, dgPluginSteps.SelectedRows.Count);
        DataRowView dr = (DataRowView)dgr.DataBoundItem;
        Guid psId = (Guid)dr["Id"];
        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(percent, "Enabeling Plugin Steps..."));
        upgradeUtility.EnableTargetPlugin(psId);
      }
    }

    private void DisablePluginSteps(BackgroundWorker bg) {
      int percent = 0;
      int iCounter = 0;
      foreach (DataGridViewRow dgr in dgPluginSteps.SelectedRows) {
        if (bg.CancellationPending)
          break;
        iCounter++;
        percent = upgradeUtility.Percent(iCounter, dgPluginSteps.SelectedRows.Count);
        DataRowView dr = (DataRowView)dgr.DataBoundItem;
        Guid psId = (Guid)dr["Id"];
        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(percent, "Disabeling Plugin Steps..."));
        upgradeUtility.DisableTargetPlugin(psId);
      }
    }

    private void btnDisableSelectPluginSteps_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      WorkAsync(new WorkAsyncInfo {
        Message = "Disabeling Selected Plugin Steps",
        IsCancelable = true,
        Work = (worker, args) => {
          DisablePluginSteps(worker);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else {
            LoadPluginSteps();
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void btnEnableSelectedPluginSteps_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      WorkAsync(new WorkAsyncInfo {
        Message = "Enabeling Selected Plugin Steps",
        IsCancelable = true,
        Work = (worker, args) => {
          EnabledPluginSteps(worker);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else {
            LoadPluginSteps();
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void btnDisableSelectedWorkflows_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      WorkAsync(new WorkAsyncInfo {
        Message = "Disabeling Selected Workflows",
        IsCancelable = true,
        Work = (worker, args) => {
          DeactivateWorkflows(worker);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else {
            LoadWorkflows();
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void btnEnableSelectedWorkflows_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      WorkAsync(new WorkAsyncInfo {
        Message = "Enabeling Selected Workflows",
        IsCancelable = true,
        Work = (worker, args) => {
          ActivateWorkflows();
        },
        ProgressChanged = (args) => {
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Enabeling workflows..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          else {
            LoadWorkflows();
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void btnConnectTargetOrg_Click(object sender, EventArgs e) {
      AddAdditionalOrganization();
    }

    private void btnResourceRequirements_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      tbPostDataMigrationResults.Clear();
      WorkAsync(new WorkAsyncInfo {
        Message = "Creating Work Order related records...",
        AsyncArgument = new CreateWorkOrderRelatedRecordsArgs() {
          IgnoreRelatedRecordsCreatedFlag = cbProcessAllWorkOrders.Checked,
          ProcessCompletedWorkOrders = cbProcessClosedWorkOrders.Checked
        },
        IsCancelable = true,
        ProgressChanged = (args) => {
          tbPostDataMigrationResults.Text += $"{Environment.NewLine}{args.UserState.ToString()}";
          tbPostDataMigrationResults.ScrollToCaret();
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Processing Work Order related records..."));
          LogInfo(args.UserState.ToString());
        },
        Work = (worker, args) => {
          upgradeUtility.CreateTargetWorkOrderRelatedRecords(worker, (CreateWorkOrderRelatedRecordsArgs)args.Argument);
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void btnRetriaveAllProcessesByEntity_Click(object sender, EventArgs e) {
      if (cbEntityList.Text == "")
        MessageBox.Show("Select an entity");
      else {
        LoadPluginSteps(cbEntityList.Text);
        LoadWorkflows(cbEntityList.Text);
      }
    }

    private void btnDisableAllProcessesByEntity_Click(object sender, EventArgs e) {
      if (cbEntityList.Text == "") {
        MessageBox.Show("Select an entity");
        return;
      }

      tsbCancelOperation.Enabled = true;
      WorkAsync(new WorkAsyncInfo {
        AsyncArgument = cbEntityList.Text,
        Message = $"Disable Process for entity: {cbEntityList.Text}...",
        IsCancelable = true,
        Work = (worker, args) => {
          worker.ReportProgress(1, $"Disable Workflows for entity: {args.Argument.ToString()}...");
          upgradeUtility.DeactivateAllTargetWorkflowsByEntity(worker, args.Argument.ToString());

          if (!worker.CancellationPending) {
            worker.ReportProgress(1, $"Disable Plugin Steps for entity: {args.Argument.ToString()}...");
            upgradeUtility.DisableAllTargetPluginsByEntity(worker, args.Argument.ToString());
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          LoadWorkflows();
          LoadPluginSteps();
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void btnEnableAllProcessesByEntity_Click(object sender, EventArgs e) {
      if (cbEntityList.Text == "") {
        MessageBox.Show("Select an entity");
        return;
      }

      tsbCancelOperation.Enabled = true;
      WorkAsync(new WorkAsyncInfo {
        AsyncArgument = cbEntityList.Text,
        Message = $"Enable Processes for entity: {cbEntityList.Text}...",
        IsCancelable = true,
        Work = (worker, args) => {
          worker.ReportProgress(1, $"Enable Workflows for entity: {args.Argument.ToString()}...");
          upgradeUtility.ActivateAllTargetWorkflowsByEntity(worker, args.Argument.ToString());

          if (!worker.CancellationPending) {
            worker.ReportProgress(1, $"Enable Plugin Steps for entity: {args.Argument.ToString()}...");
            upgradeUtility.EnableAllTargetPluginsByEntity(worker, args.Argument.ToString());
          }
        },
        ProgressChanged = (args) => {
          // TODO Add code to handle the progress change event.
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Enabeling processes..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          LoadWorkflows();
          LoadPluginSteps();
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
        }
      });
    }

    private void tsbCancelOperation_EnabledChanged(object sender, EventArgs e) {
      tsbClose.Enabled = !tsbCancelOperation.Enabled;
    }

    private void tsbCancelOperation_Click(object sender, EventArgs e) {
      this.CancelWorker();
      tsbCancelOperation.Enabled = false;
    }

    private void tsbOpenLogFile_Click(object sender, EventArgs e) {
      OpenLogFile();
    }

    private void btnLoadSourceUsers_Click(object sender, EventArgs e) {
      //dsFSMigration.AcceptChanges();
      LoadSystemUsers();
    }

    private void LoadSecurityRoles() {
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Loading Source Roles...",
        IsCancelable = true,
        Work = (worker, args) => {
          try {
            debugTargetUserTeam = null;
            debugSourceUserTeam = null;

            List<Entity> sourceRoles = upgradeUtility.RetrieveAllSourceRoles();
            worker.ReportProgress(1, "Loading Target Roles...");
            List<Entity> targetRoles = upgradeUtility.RetrieveAllTargetRoles();

            worker.ReportProgress(1, "Comparing Roles...");
            foreach (Entity sourceRole in sourceRoles) {
              var matchingRoles = from tr in targetRoles
                                  where (tr.GetAttributeValue<string>("name").ToLower() == sourceRole.GetAttributeValue<string>("name").ToLower() &&
                                         tr.GetAttributeValue<EntityReference>("businessunitid").Name.ToLower() == sourceRole.GetAttributeValue<EntityReference>("businessunitid").Name.ToLower())
                                  select tr;              
            }
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception processing role: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          //dsFSMigration.AcceptChanges();
          //SetUserTotalInfo(); // probably not needed but just want to be sure the label is always accurate.
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void LoadSystemUsers() {      
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Loading Source Users...",
        IsCancelable = true,
        Work = (worker, args) => {
          debugSourceUserTeam = null;
          debugTargetUserTeam = null;
          Dictionary<Guid, object> targetUserTracking = new Dictionary<Guid, object>();
          int iCounter = 0;
          string currentSourceDomainName = "";
          Entity currentTargetUser = null;
          Entity currentSourceUser = null;

          try {
            List<Entity> sourceUsers = upgradeUtility.RetrieveAllSourceUsers(cbStubUsersHideDisabled.Checked, cbStubUsersHideUnlicensed.Checked);
            worker.ReportProgress(1, "Loading Target Users...");
            List<Entity> targetUsers = upgradeUtility.RetrieveAllTargetUsers();
            worker.ReportProgress(1, "Loading Target User Security...");
            List<Entity> targetUserSecurity = upgradeUtility.RetrieveAllTargetUserSecurity();
            worker.ReportProgress(1, "Comparing Users...");

            foreach (Entity su in sourceUsers) {
              iCounter++;
              currentSourceDomainName = su.GetAttributeValue<string>("domainname").Trim();
              currentSourceUser = su;
              currentTargetUser = null;

              worker.ReportProgress(upgradeUtility.Percent(iCounter, sourceUsers.Count), $"Processing User {iCounter} of {sourceUsers.Count}");

              debugSourceUserTeam = su;
              debugTargetUserTeam = null;

              // first see if there is a match on the special z_ stub user
              var matchingUsers = targetUsers.Where(o => o.GetAttributeValue<string>("domainname").Trim().Equals($"z_{su.GetAttributeValue<string>("domainname").Trim()}", StringComparison.OrdinalIgnoreCase));
              if (matchingUsers == null || matchingUsers.Count() == 0) {
                // Need to include the "islicensed" flag when matching users.
                matchingUsers = targetUsers.Where(o => o.GetAttributeValue<string>("domainname").Trim().Equals(su.GetAttributeValue<string>("domainname").Trim(), StringComparison.OrdinalIgnoreCase) &&
                                                       o.GetAttributeValue<bool>("islicensed") == su.GetAttributeValue<bool>("islicensed"));
              }

              if (matchingUsers == null || matchingUsers.Count() == 0) {
                // Try again without the islicensed condition.
                matchingUsers = targetUsers.Where(o => o.GetAttributeValue<string>("domainname").Trim().Equals(su.GetAttributeValue<string>("domainname").Trim(), StringComparison.OrdinalIgnoreCase));
              }

              if (matchingUsers.Count() > 1) {
                int iDebug = 2;
              }

              if ((matchingUsers.Count() == 0) ||
                  (matchingUsers.Count() > 0 && !cbHideInTarget.Checked)) {
              }

              if (matchingUsers.Count() == 1) {
                var tu = matchingUsers.First<Entity>();

                currentTargetUser = tu;

                // see if this GUID is already in the collection
                if (targetUserTracking.ContainsKey(tu.Id)) {
                  MessageBox.Show($"Found 1 matching user for: {su.GetAttributeValue<string>("domainname")} - GUID: {su.Id} | Matching Domain Name: {((Entity)targetUserTracking[tu.Id]).GetAttributeValue<string>("domainname")} - SKIPPING USER");
                  continue;
                }

                targetUserTracking.Add(tu.Id, tu);

                // if the target user has the Salesperson security role.
                var colTUS = from tus in targetUserSecurity
                             where tus.GetAttributeValue<Guid>("systemuserid") == tu.Id && tus.GetAttributeValue<AliasedValue>("ur.name").Value.ToString().ToLower() == "salesperson"
                             select tus;
                if (colTUS != null && colTUS.Count() > 0) {

                }

                // There are times when the same GUID is getting added for target_id.
                // Check if the tu.Id is already in the dictionary.
                if (targetUserTracking.ContainsKey(tu.Id)) {
                  object x = targetUserTracking[tu.Id];
                  // This is a prblem.   
                  // Add this target user with a custom guid but flag the target user so we know there is a problem.
                  // I AM NOT a big fan of this design but, I need to just get this done for the OTIS UK project so I am going to hack this in.

                }
                else {

                  targetUserTracking.Add(tu.Id, tu);
                }


                // Do not pre-mao currency info.   I want to see what is actually in the source environment.
                if (tu.Contains("sus.transactioncurrencyid")) {

                }

                // Check if the user attributes match.     
                string UserAttributesCompareResults = "";
                string UserSettingsCompareResults = "";

                // territoryid
                if (su.Contains("territoryid")) {
                  if (!tu.Contains("territoryid") ||
                      su.GetAttributeValue<EntityReference>("territoryid").Id != tu.GetAttributeValue<EntityReference>("territoryid").Id) {
                    UserAttributesCompareResults += $"Territory does not match" + Environment.NewLine;
                  }
                }
                else if (tu.Contains("territoryid")) {
                  // tu does not have a values and su does.
                  UserAttributesCompareResults += $"Territory does not match" + Environment.NewLine;
                }

                // siteid
                if (su.Contains("siteid")) {
                  if (!tu.Contains("siteid") ||
                      su.GetAttributeValue<EntityReference>("siteid").Id != tu.GetAttributeValue<EntityReference>("siteid").Id) {
                    UserAttributesCompareResults += $"Site does not match" + Environment.NewLine;
                  }
                }
                else if (tu.Contains("siteid")) {
                  // tu does not have a values and su does.
                  UserAttributesCompareResults += $"Site does not match" + Environment.NewLine;
                }

                // businessunitid
                if (su.GetAttributeValue<EntityReference>("businessunitid").Name != tu.GetAttributeValue<EntityReference>("businessunitid").Name)
                  UserAttributesCompareResults += $"Business Unit does not match" + Environment.NewLine;

                // parentsystemuserid                 
                if (su.Contains("parentsystemuserid")) {
                  if (!tu.Contains("parentsystemuserid") ||
                      su.GetAttributeValue<EntityReference>("parentsystemuserid").Id != tu.GetAttributeValue<EntityReference>("parentsystemuserid").Id) {
                    UserAttributesCompareResults += $"Parent System User does not match" + Environment.NewLine;
                  }
                }
                else if (tu.Contains("parentsystemuserid")) {
                  // tu does not have a values and su does.
                  UserAttributesCompareResults += $"Parent System User does not match" + Environment.NewLine;
                }

                // TODO: Add review of user settings to log what is different.
                // Check the user settings
                //if (tu.Contains("sus.localeid")) { drTUS.localeid = (Int32)tu.GetAttributeValue<AliasedValue>("sus.localeid").Value; }
                //if (tu.Contains("sus.timezonecode")) { drTUS.timezonecode = (Int32)tu.GetAttributeValue<AliasedValue>("sus.timezonecode").Value; }
                //if (tu.Contains("sus.uilanguageid")) { drTUS.uilanguageid = (Int32)tu.GetAttributeValue<AliasedValue>("sus.uilanguageid").Value; }

                if (tu != null)
                  tu = null;
              }
              else {
              }
            }          

            // Clean up collections
            //if (sourceUsers != null && sourceUsers.Count > 0) {
            //  sourceUsers.Clear();
            //  sourceUsers = null;
            //}

            //if (targetUsers != null && targetUsers.Count > 0) {
            //  targetUsers.Clear();
            //  targetUsers = null;
            //}

            //if (targetUserSecurity != null && targetUserSecurity.Count > 0) {
            //  targetUserSecurity.Clear();
            //  targetUserSecurity = null;
            //}

          }
          catch (Exception ex) {
            
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Comparing Users..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          //dsFSMigration.AcceptChanges();
          SetUserTotalInfo(); // probably not needed but just want to be sure the label is always accurate.
          txtErrorInfo.Text = errorMessage;


        }
      });
    }

    private void LoadUserSecurity() {
      
      //dsFSMigration.AcceptChanges();
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = false,
        Work = (worker, args) => {
          worker.ReportProgress(1, "Loading Source Users...");
          List<Entity> sourceUsers = upgradeUtility.RetrieveAllSourceUsers(cbUserSecurityHideDisabled.Checked, cbUserSecurityHideUnLicensed.Checked);
          worker.ReportProgress(1, "Loading Source User Security Roles...");
          List<Entity> sourceUserSecurity = upgradeUtility.RetrieveAllSourceUserSecurity(cbUserSecurityHideDisabled.Checked);

          worker.ReportProgress(1, "Loading Target Users...");
          List<Entity> targetUsers = upgradeUtility.RetrieveAllTargetUsers();
          worker.ReportProgress(1, "Loading Target Security Roles...");
          List<Entity> targetUserSecurity = upgradeUtility.RetrieveAllTargetUserSecurity();

          worker.ReportProgress(1, "Comparing User Security...");
          int iCurrent = 0;
          // process source users and security roles.
          foreach (Entity sourceUser in sourceUsers) {
            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, sourceUsers.Count), $"Comparing User Sercurity {iCurrent} of {sourceUsers.Count}...");

            debugSourceUserTeam = null;
            debugTargetUserTeam = null;
            debugSourceUserTeamRoles = "";
            debugTargetUserTeamRoles = "";

            try {
              //dsFSMigration.BeginInit();
              debugSourceUserTeam = sourceUser;
          
              // process source user security roles.
              var colSUS = from sus in sourceUserSecurity
                           where sus.GetAttributeValue<Guid>("systemuserid") == sourceUser.Id
                           select sus;

              if (colSUS != null && colSUS.Count() > 0) {
                foreach (var sus in colSUS) {                 
                  
                }

                // see if there is a matching target user.
                var targetUser = targetUsers.FirstOrDefault<Entity>(o => o.GetAttributeValue<string>("domainname").ToLower().Trim() == sourceUser.GetAttributeValue<string>("domainname").ToLower().Trim());
                debugTargetUserTeam = targetUser;

                if (targetUser != null) {                  
                  var colTUS = from tus in targetUserSecurity
                               where tus.GetAttributeValue<Guid>("systemuserid") == targetUser.Id
                               select tus;
                  if (colTUS != null && colTUS.Count() > 0) {
                    foreach (var tus in colTUS) {
                                            
                    }
                  }
                }
                else {
                  
                }
              }
            }
            catch (Exception ex) {
              throw ex;
            }
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Comparing Users..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          //dsFSMigration.EndInit();
          //dsFSMigration.AcceptChanges();
          //SetUserTotalInfo(); // probably not needed but just want to be sure the label is always accurate.
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void LoadTeamSecurity() {     
      //dsFSMigration.AcceptChanges();
      Application.DoEvents(); // testing if adding this allows the re-loading of information works.   Currently getting an error that that a row was already removed.
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = false,
        Work = (worker, args) => {
          worker.ReportProgress(1, "Loading Source Teams...");
          List<Entity> sourceTeams = upgradeUtility.RetrieveAllSourceTeams();
          worker.ReportProgress(1, "Loading Source Team Security Roles...");
          List<Entity> sourceTeamSecurity = upgradeUtility.RetrieveAllSourceTeamSecurity();

          worker.ReportProgress(1, "Loading Target Teams...");
          List<Entity> targetTeams = upgradeUtility.RetrieveAllTargetTeams();
          worker.ReportProgress(1, "Loading Target Team Security Roles...");
          List<Entity> targetTeamSecurity = upgradeUtility.RetrieveAllTargetTeamSecurity();

          worker.ReportProgress(1, "Comparing Team Security...");
          int iCurrent = 0;
          // process source teams and security roles.
          foreach (Entity sourceTeam in sourceTeams) {
            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, sourceTeams.Count), $"Comparing Team Sercurity {iCurrent} of {sourceTeams.Count}...");

            debugSourceUserTeam = null;
            debugTargetUserTeam = null;
            debugSourceUserTeamRoles = "";
            debugTargetUserTeamRoles = "";

            try {
             // dsFSMigration.BeginInit();
              debugSourceUserTeam = sourceTeam;
              
              // process source user security roles.
              var colSTS = from sts in sourceTeamSecurity
                           where sts.GetAttributeValue<Guid>("teamid") == sourceTeam.Id
                           select sts;

              if (colSTS != null && colSTS.Count() > 0) {
                foreach (var sts in colSTS) {
                  // add the role names to the dtTeamSecurityRoles table first.
                  

                  // Create the child rows for the actual source user security roles.                 
                }

                // see if there is a matching target user.
                var targetTeam = targetTeams.FirstOrDefault<Entity>(o => o.GetAttributeValue<string>("name").ToLower().Trim() == sourceTeam.GetAttributeValue<string>("name").ToLower().Trim());
                debugTargetUserTeam = targetTeam;

                if (targetTeam != null) {
                  // add target user information to the dtUserSecurityRoles Row
                  

                  var colTTS = from tts in targetTeamSecurity
                               where tts.GetAttributeValue<Guid>("teamid") == targetTeam.Id
                               select tts;
                  if (colTTS != null && colTTS.Count() > 0) {
                    foreach (var tts in colTTS) {                     
                    }
                  }
                }
                else {
                  
                }
              }
            }
            catch (Exception ex) {
              throw ex;
            }
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Comparing Teams..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          //dsFSMigration.EndInit();
          //dsFSMigration.AcceptChanges();
          //SetUserTotalInfo(); // probably not needed but just want to be sure the label is always accurate.
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnCreateStubUsers_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      
      WorkAsync(new WorkAsyncInfo {
        Message = "Creating stub users...",
        IsCancelable = true,
        Work = (worker, args) => {
          //var results = from r in dsFSMigration.dtUsers.AsEnumerable()
          //              where r.AddStubToTarget || r.AddZ_StubToTarget
          //              select r;
          //int iCurrent = 0;
          //int iTotal = results.Count();
          //foreach (var dr in results) {
          //  if (worker.CancellationPending) {
          //    break;
          //  }
          //  iCurrent++;
          //  worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing User: {dr.source_fullname} ({iCurrent} of {iTotal})");
          //  try {
          //    string newDomainName = "";
          //    Guid newId = Guid.Empty;
          //    if (dr.AddZ_StubToTarget) {
          //      newDomainName = $"z_{dr.source_domain}";
          //      newId = Guid.NewGuid();
          //    }
          //    else {
          //      newDomainName = dr.source_domain;
          //      newId = dr.source_id;
          //    }

          //    Entity newUser = upgradeUtility.CreateTargetStubUser(worker, newId, newDomainName, dr.source_internalemailaddress, dr.source_firstname, dr.source_lastname, dr.source_businessunitid);
          //  }
          //  catch (Exception ex) {
          //    dr.RowError = ex.Message;
          //  }
          //}
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Creating Stub Users..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
        }
      });
    }

    private void cbCheckUncheckUsers_CheckedChanged(object sender, EventArgs e) {
      //dsFSMigration.BeginInit();
      //try {
      //  foreach (dsFSMigration.dtUsersRow dr in dsFSMigration.dtUsers.Rows) {
      //    if (!dr.IsIsInTargetNull() && !dr.IsInTarget) {
      //      dr.AddStubToTarget = cbAddStubUsersCheckUncheck.Checked;
      //    }
      //  }
      //}
      //catch (Exception ex) {
      //  MessageBox.Show($"ERROR: {ex.Message}");
      //}
      //dsFSMigration.EndInit();
      //dsFSMigration.AcceptChanges();
    }

    private void SetUserTotalInfo() {
      //var results = from r in dsFSMigration.dtUsers.AsEnumerable()
      //              where r.AddStubToTarget
      //              select r;
      //int selectedCount = results.Count();
      //int totalrecords = dsFSMigration.dtUsers.Rows.Count;
      //lblUsersTotalInfo.Text = $"Selected {selectedCount} of {totalrecords}";
    }

    private void dgSourceUsers_CellValueChanged(object sender, DataGridViewCellEventArgs e) {
      //if (dgSystemUsers.Columns[e.ColumnIndex].Name == "addStubToTargetDataGridViewCheckBoxColumn") {
      //  dsFSMigration.dtUsersRow dr = (dsFSMigration.dtUsersRow)dgSystemUsers.Rows[e.RowIndex].DataBoundItem;
      //  if ((!dr.IsAddStubToTargetNull() && dr.AddStubToTarget) &&
      //      (!dr.IsIsInTargetNull() && dr.IsInTarget)) {
      //    // User is already in the target and attempting to select add to target.  Do not allow this.
      //    MessageBox.Show("User is already in target", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
      //    dr.AddStubToTarget = false;
      //  }
      //  else
      //    SetUserTotalInfo();
      //}
    }

    private void cbHideInTarget_CheckedChanged(object sender, EventArgs e) {
      //LoadSystemUsers();
    }

    private void btnCompareSecurityRoles_Click(object sender, EventArgs e) {
      LoadUserSecurity();
    }

    private void dgUserSecurity_SelectionChanged(object sender, EventArgs e) {
      // filter grids.
      //if (dgUserSecurity.SelectedRows != null && dgUserSecurity.SelectedRows.Count > 0) {
      //  // get the first selected row.
      //  var dr = ((DataRowView)dgUserSecurity.SelectedRows[0].DataBoundItem).Row as dsFSMigration.dtUserSecurityRolesRow;
      //  Guid sourceId = dr.source_userid;
      //  Guid targetId = dr.Istarget_useridNull() ? Guid.Empty : dr.target_userid;
      //  dgSourceUserRoles.DataSource = dsFSMigration.dtSourceUserSecurityRoles.Select($"userid = '{sourceId}'");
      //  lblSourceUserRoles.Text = $"Source User Roles (userid = '{sourceId}')";
      //  dgTargetUserRoles.DataSource = dsFSMigration.dtTargetUserSecurityRoles.Select($"userid = '{targetId}'");
      //  lblTargetUserRoles.Text = $"Target User Roles (userid = '{targetId}')";
      //}
    }

    private void ckUserSecurityCheckUncheck_CheckedChanged(object sender, EventArgs e) {
      //foreach (dsFSMigration.dtUserSecurityRolesRow dr in dsFSMigration.dtUserSecurityRoles.Rows) {
      //  dr.SyncRoles = ckUserSecurityCheckUncheck.Checked;
      //}
    }

    private void btnSyncSecurityRoles_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      txtErrorInfo.Text = "";
      errorMessage = "";
      //Dictionary<Entity, dsFSMigration.dtUsersRow> rowsToUpdate = new Dictionary<Entity, dsFSMigration.dtUsersRow>();

      WorkAsync(new WorkAsyncInfo {
        Message = "Synchronizing Security Roles...",
        IsCancelable = true,
        Work = (worker, args) => {
          //var selectedUsers = from r in dsFSMigration.dtUserSecurityRoles.AsEnumerable()
          //                    where r.SyncRoles
          //                    select r;

          //if (selectedUsers == null || selectedUsers.Count() <= 0)
          //  return;

          int iCurrent = 0;
          //int iTotal = selectedUsers.Count();
          //foreach (var dr in selectedUsers) {
          //  try {
          //    if (worker.CancellationPending) {
          //      break;
          //    }
          //    iCurrent++;
          //    worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing User: {dr.source_domainname} ({iCurrent} of {iTotal})");
          //    Guid sourceUserId = dr.source_userid;
          //    Guid targetUserId = dr.Istarget_useridNull() ? Guid.Empty : dr.target_userid;
          //    Guid targetBUId = dr.Istarget_businessunitidNull() ? Guid.Empty : dr.target_businessunitid;

          //    var sourceUserRoles = dr.GetChildRows(dsFSMigration.dtUserSecurityRoles.ChildRelations["dtUserSecurityRoles_dtSourceUserSecurityRoles"]);
          //    if (sourceUserRoles != null && sourceUserRoles.Count() > 0) {
          //      List<Guid> targetRoleGuids = new List<Guid>();
          //      foreach (var sr in sourceUserRoles) {
          //        var sourceRole = sr as dsFSMigration.dtSourceUserSecurityRolesRow;
          //        var roleMapping = dsFSMigration.dtSecurityRoleMapping.GetTargetRole(sourceRole.roleid, sourceRole.rolebusinessunitid);
          //        targetRoleGuids.Add(roleMapping.target_roleid);
          //      }
          //      bool clearRoles = dr.IsClearTargetRolesNull() ? false : dr.ClearTargetRoles;
          //      string result = upgradeUtility.TargetAddRolesToUser(targetUserId, targetRoleGuids, clearRoles);
          //      if (result.Trim() != String.Empty) {
          //        errorMessage += $"{result}{Environment.NewLine}{Environment.NewLine}";
          //      }
          //    }
          //  }
          //  catch (Exception ex) {
          //    dr.RowError = $"{dr.RowError} | {ex.Message}";
          //    errorMessage += $"{dr.RowError} | {ex.Message}{Environment.NewLine}========================{Environment.NewLine}";
          //  }

          //  //if (targetId != Guid.Empty) {
          //  //    DataRow[] sourceRoles = dsFSMigration.dtSourceUserSecurityRoles.Select($"userid = '{sourceId}'");
          //  //    DataRow[] targetRoles = dsFSMigration.dtTargetUserSecurityRoles.Select($"userid = '{targetId}'");

          //  //    try {
          //  //        List<Guid> targetRoleGuids = new List<Guid>();
          //  //        foreach (dsFSMigration.dtSourceUserSecurityRolesRow sourceRole in sourceRoles) {
          //  //            // lookup the source role in the Role Mappings Grid.
          //  //            //var targetRoleId = from tr in dsFSMigration.dtSecurityRoleMapping.AsEnumerable()
          //  //            //                   where tr.source_roleid == role.roleid
          //  //            //                   select tr;
          //  //            //var targetMappedRoles = dsFSMigration.dtSecurityRoleMapping.Select($"source_roleid = '{sourceRole.parentrootroleid}'");
          //  //            var targetMappedRoles = 
          //  //            if (targetMappedRoles != null && targetMappedRoles.Count() > 0)
          //  //                targetRoleGuids.Add(((dsFSMigration.dtSecurityRoleMappingRow)targetMappedRoles[0]).target_roleid);
          //  //        }
          //  //        bool clearRoles = dr.IsClearTargetRolesNull() ? false : dr.ClearTargetRoles;
          //  //        string result = upgradeUtility.TargetAddRolesToUser(targetId, targetRoleGuids, clearRoles);
          //  //        if (result.Trim() != String.Empty) {
          //  //            errorMessage += $"{result}{Environment.NewLine}{Environment.NewLine}";
          //  //        }
          //  //    }
          //  //    catch (Exception ex) {
          //  //        dr.RowError = $"{dr.RowError} | {ex.Message}";
          //  //        errorMessage += $"{dr.RowError} | {ex.Message}{Environment.NewLine}========================{Environment.NewLine}";
          //  //    }
          //  //}
          //}
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Creating Stub Users..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnSaveRoleMappings_Click(object sender, EventArgs e) {
      if (filedlgSaveMapping.ShowDialog() == DialogResult.OK) {
       // dsFSMigration.dtSecurityRoleMapping.WriteXml(filedlgSaveMapping.FileName);
      }
    }

    private void btnLoadRoleMappings_Click(object sender, EventArgs e) {
      if (filedlgOpenRoleMapping.ShowDialog() == DialogResult.OK) {
       // dsFSMigration.dtSecurityRoleMapping.ReadXml(filedlgOpenRoleMapping.FileName);
      }
    }

    private void btnMapRoles_Click(object sender, EventArgs e) {
      LoadSecurityRoles();
    }

    private void dgUserSecurity_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      try {
        var x = (DataGridView)sender;
        string sourceUser = debugSourceUserTeam == null ? "null" : debugSourceUserTeam.GetAttributeValue<string>("domainname");
        string targetUser = debugTargetUserTeam == null ? "null" : debugTargetUserTeam.GetAttributeValue<string>("domainname");

        var column = x[e.ColumnIndex, e.RowIndex].OwningColumn;
        string errMsg = $"dgUserSecurity Data Error: Column: {column.Name}, Row Index: {e.RowIndex}, Exception Message: {e.Exception.Message}, sourceUser: {sourceUser}, targetUser: {debugTargetUserTeam}, sourceSecurityRoles: {debugSourceUserTeamRoles}, targetSecurityRoles: {debugTargetUserTeamRoles}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
        e.ThrowException = false;
        e.Cancel = false;
      }
      catch (Exception ex) {
        string errMsg = $"dgUserSecurity Exception: {ex.Message}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
      }
    }

    private void dgSourceUserRoles_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      try {
        var x = (DataGridView)sender;
        string sourceUser = debugSourceUserTeam == null ? "null" : debugSourceUserTeam.GetAttributeValue<string>("domainname");
        string targetUser = debugTargetUserTeam == null ? "null" : debugTargetUserTeam.GetAttributeValue<string>("domainname");

        var column = x[e.ColumnIndex, e.RowIndex].OwningColumn;
        string errMsg = $"dgSourceUserRoles Data Error: Column: {column.Name}, Row Index: {e.RowIndex}, Exception Message: {e.Exception.Message}, sourceUser: {sourceUser}, targetUser: {debugTargetUserTeam}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
        e.ThrowException = false;
        e.Cancel = false;
      }
      catch (Exception ex) {
        string errMsg = $"dgUserSecurity Exception: {ex.Message}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
      }
      e.ThrowException = false;
      e.Cancel = false;
    }

    private void dgTargetUserRoles_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      try {
        var x = (DataGridView)sender;
        string sourceUser = debugSourceUserTeam == null ? "null" : debugSourceUserTeam.GetAttributeValue<string>("domainname");
        string targetUser = debugTargetUserTeam == null ? "null" : debugTargetUserTeam.GetAttributeValue<string>("domainname");

        var column = x[e.ColumnIndex, e.RowIndex].OwningColumn;
        string errMsg = $"dgTargetUserRoles Data Error: Column: {column.Name}, Row Index: {e.RowIndex}, Exception Message: {e.Exception.Message}, sourceUser: {sourceUser}, targetUser: {debugTargetUserTeam}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
        e.ThrowException = false;
        e.Cancel = false;
      }
      catch (Exception ex) {
        string errMsg = $"dgUserSecurity Exception: {ex.Message}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
      }
      e.ThrowException = false;
      e.Cancel = false;
    }

    private void dgRoleMapping_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      try {
        var x = (DataGridView)sender;
        string sourceUser = debugSourceUserTeam == null ? "null" : debugSourceUserTeam.GetAttributeValue<string>("domainname");
        string targetUser = debugTargetUserTeam == null ? "null" : debugTargetUserTeam.GetAttributeValue<string>("domainname");

        var column = x[e.ColumnIndex, e.RowIndex].OwningColumn;
        string errMsg = $"dgRoleMapping Data Error: Column: {column.Name}, Row Index: {e.RowIndex}, Exception Message: {e.Exception.Message}, sourceUser: {sourceUser}, targetUser: {debugTargetUserTeam}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
        e.ThrowException = false;
        e.Cancel = false;
      }
      catch (Exception ex) {
        string errMsg = $"dgUserSecurity Exception: {ex.Message}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
      }
      e.ThrowException = false;
      e.Cancel = false;
    }

    private void dgSystemUsers_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      try {
        var x = (DataGridView)sender;
        string sourceUser = debugSourceUserTeam == null ? "null" : debugSourceUserTeam.GetAttributeValue<string>("domainname");
        string targetUser = debugTargetUserTeam == null ? "null" : debugTargetUserTeam.GetAttributeValue<string>("domainname");

        var column = x[e.ColumnIndex, e.RowIndex].OwningColumn;
        string errMsg = $"dgSystemUsers Data Error: Column: {column.Name}, Row Index: {e.RowIndex}, Exception Message: {e.Exception.Message}, sourceUser: {sourceUser}, targetUser: {debugTargetUserTeam}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
        e.ThrowException = false;
        e.Cancel = false;
      }
      catch (Exception ex) {
        string errMsg = $"dgUserSecurity Exception: {ex.Message}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
      }
      e.ThrowException = false;
      e.Cancel = false;
    }

    private void btnSyncUserSettings_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      errorMessage = "";
      txtErrorInfo.Text = "";
      //Dictionary<Entity, dsFSMigration.dtUsersRow> rowsToSync = new Dictionary<Entity, dsFSMigration.dtUsersRow>();

      WorkAsync(new WorkAsyncInfo {
        Message = "Syncronizing user settings...",
        IsCancelable = true,
        Work = (worker, args) => {
          //var results = dsFSMigration.dtUsers.Where(o => o.SyncSettings == true);
          int iCurrent = 0;
          //int iTotal = results.Count();
          //foreach (var dr in results) {
          //  if (worker.CancellationPending) {
          //    break;
          //  }
          //  iCurrent++;
          //  worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing User: {dr.source_fullname} ({iCurrent} of {iTotal})");
          //  try {
          //    // Target BU that we are using should come from the mapping table.
          //    Guid? targetBUId = null;
          //    Guid? targetCurrencyId = null;
          //    Guid? targetParentUserId = null; ;

          //    if (!dr.Issource_BUNameNull())
          //      targetBUId = ((dsFSMigration)dr.Table.DataSet).GetTargetBU(dr.source_BUName).target_buid;
          //    if (!dr.Issource_transactioncurrencyidNull())
          //      targetCurrencyId = ((dsFSMigration)dr.Table.DataSet).GetTargetCurrency(dr.source_transactioncurrencyid).target_transactioncurrencyid;


          //    // if the source user has a parentsystemuserid defined
          //    //  find the dtUser record where user_id = source parentsystemuserid.  that record will have the target userid we need to assign as the parentsystemuserid.
          //    targetParentUserId = null;
          //    try {
          //      if (!dr.Issource_parentsystemuseridNull()) {
          //        targetParentUserId = dsFSMigration.dtUsers.FirstOrDefault(o => o.source_id.Equals(dr.source_parentsystemuserid)).target_id;
          //      }
          //    }
          //    catch (Exception ex) {
          //      errorMessage += $"Error processing user {dr.source_fullname}, source user has a parent systemuser defined, unable to set the parent user, {ex.Message}\n";
          //      dr.RowError = errorMessage;
          //    }

          //    UserSettingSyncResult res = null;
          //    res = upgradeUtility.SyncTargetUser((Entity)dr.source_entity,
          //                                                (Entity)dr.target_entity,
          //                                                //(dr.Istarget_bumatchNull() && cbUserSnycBusinessUnit.Checked),  // BU does not match and Sync BU is checked then pass true else pass false.
          //                                                cbUserSnycBusinessUnit.Checked,
          //                                                cbUserSnycSettings.Checked,
          //                                                cbUserSnycUserInfo.Checked,
          //                                                targetBUId,
          //                                                targetCurrencyId,
          //                                                targetParentUserId);
          //    if (res.IsError) {
          //      errorMessage += $"Error processing user {dr.source_fullname}, Step: {res.Step}, Error Message: {res.ex.Message}";
          //      dr.RowError += $"Step: {res.Step}, Error Message: {res.ex.Message}";
          //    }
          //  }
          //  catch (Exception ex) {
          //    dr.RowError += ex.Message;
          //  }
          //}
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Creating Stub Users..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          txtErrorInfo.Text = errorMessage;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
        }
      });
    }

    private void btnMapBU_Click(object sender, EventArgs e) {
    //  dsFSMigration.dtBusinessUnitMapping.Clear();
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Loading Source Business Units...",
        IsCancelable = true,
        Work = (worker, args) => {
          try {
            List<Entity> sourceBUs = upgradeUtility.RetrieveAllSourceBusinessUnits();
            worker.ReportProgress(1, "Loading Target Busines Units...");
            List<Entity> targetBUs = upgradeUtility.RetrieveAllTargetBusinessUnits();

            worker.ReportProgress(1, "Comparing Business Units...");
            foreach (Entity sourceBU in sourceBUs) {
              var matchingBUs = from tr in targetBUs
                                where (tr.GetAttributeValue<string>("name").ToLower() == sourceBU.GetAttributeValue<string>("name").ToLower())
                                select tr;
            //  dsFSMigration.dtBusinessUnitMappingRow dr = dsFSMigration.dtBusinessUnitMapping.NewdtBusinessUnitMappingRow();
              //dr.source_buid = sourceBU.Id;
              //dr.source_buname = sourceBU.GetAttributeValue<string>("name");

              //if (matchingBUs.Count() > 0) {
              //  var tr = matchingBUs.First<Entity>();
              //  dr.target_buid = tr.Id;
              //  dr.target_buname = tr.GetAttributeValue<string>("name");
              //}
              //dsFSMigration.dtBusinessUnitMapping.AdddtBusinessUnitMappingRow(dr);
            }
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception processing business unit: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          //dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnSaveBUMapping_Click(object sender, EventArgs e) {
      if (filedlgSaveMapping.ShowDialog() == DialogResult.OK) {
        //dsFSMigration.dtBusinessUnitMapping.WriteXml(filedlgSaveMapping.FileName);
      }
    }

    private void btnLoadBUMapping_Click(object sender, EventArgs e) {
      if (filedlgOpenRoleMapping.ShowDialog() == DialogResult.OK) {
        //dsFSMigration.dtBusinessUnitMapping.ReadXml(filedlgOpenRoleMapping.FileName);
      }
    }

    private void btnCurrencyMapping_Click(object sender, EventArgs e) {
      //dsFSMigration.dtCurrencyMapping.Clear();
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Loading Source Currency...",
        IsCancelable = true,
        Work = (worker, args) => {
          try {
            List<Entity> sourceCurrencies = upgradeUtility.RetrieveAllSourceCurrencies();
            worker.ReportProgress(1, "Loading Target Currencies...");
            List<Entity> targetCurrencies = upgradeUtility.RetrieveAllTargetCurrencies();

            worker.ReportProgress(1, "Comparing Currencies...");
            foreach (Entity sourceCurrency in sourceCurrencies) {
              var matchingCurrencies = from tr in targetCurrencies
                                       where (tr.GetAttributeValue<string>("isocurrencycode").ToLower() == sourceCurrency.GetAttributeValue<string>("isocurrencycode").ToLower())
                                       select tr;
              //dsFSMigration.dtCurrencyMappingRow dr = dsFSMigration.dtCurrencyMapping.NewdtCurrencyMappingRow();
              //dr.source_transactioncurrencyid = sourceCurrency.Id;
              //dr.source_isocurrencycode = sourceCurrency.GetAttributeValue<string>("isocurrencycode");
              //dr.source_currencysymbol = sourceCurrency.GetAttributeValue<string>("currencysymbol");
              //dr.source_currencyname = sourceCurrency.GetAttributeValue<string>("currencyname");

              //if (matchingCurrencies.Count() > 0) {
              //  var tr = matchingCurrencies.First<Entity>();
              //  dr.target_transactioncurrencyid = tr.Id;
              //  dr.target_isocurrencycode = tr.GetAttributeValue<string>("isocurrencycode");
              //  dr.target_currencysymbol = tr.GetAttributeValue<string>("currencysymbol");
              //  dr.target_currencyname = tr.GetAttributeValue<string>("currencyname");
              //}
              //dsFSMigration.dtCurrencyMapping.AdddtCurrencyMappingRow(dr);
            }
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception processing currency: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnSaveCurrencyMapping_Click(object sender, EventArgs e) {
      if (filedlgSaveMapping.ShowDialog() == DialogResult.OK) {
        //dsFSMigration.dtCurrencyMapping.WriteXml(filedlgSaveMapping.FileName);
      }
    }

    private void btnLoadCurrencyMapping_Click(object sender, EventArgs e) {
      if (filedlgOpenRoleMapping.ShowDialog() == DialogResult.OK) {
        //dsFSMigration.dtBusinessUnitMapping.ReadXml(filedlgOpenRoleMapping.FileName);
      }
    }

    private void cbSyncSettings_CheckedChanged(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Checking Sync Settings...",
        IsCancelable = false,
        Work = (worker, args) => {
          try {
            dsFSMigration.BeginInit();
            int iCurrent = 0;
           // int iTotal = dsFSMigration.dtUsers.Rows.Count;
            //foreach (dsFSMigration.dtUsersRow dr in dsFSMigration.dtUsers.Rows) {
            //  iCurrent++;
            //  worker.ReportProgress(1, $"Processing row {iCurrent} of {iTotal}...");
            //  if ((!dr.IsIsInTargetNull() && dr.IsInTarget)) { // && (!dr.Issource_IsDisabledNull() && !dr.source_IsDisabled)) {
            //    dr.SyncSettings = cbSyncSettings.Checked;
            //  }
            //}
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception updating sync settings option: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          dsFSMigration.EndInit();
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnRetrieveBookingSetup_Click(object sender, EventArgs e) {
      //dsFSMigration.dtBookingSetup.Clear();
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Loading Agreement Booking Setups...",
        IsCancelable = true,
        Work = (worker, args) => {
          try {
            debugTargetUserTeam = null;
            debugSourceUserTeam = null;
            dsFSMigration.BeginInit();
            List<Entity> bookingSetups = upgradeUtility.RetrieveActiveTargetBookingSetups();

            foreach (Entity bs in bookingSetups) {
             // dsFSMigration.dtBookingSetupRow dr = dsFSMigration.dtBookingSetup.NewdtBookingSetupRow();
              //dr.AgreementName = bs.GetAttributeValue<EntityReference>("msdyn_agreement").Name;
              //dr.msdyn_agreement = bs.GetAttributeValue<EntityReference>("msdyn_agreement").Id;
              //dr.msdyn_agreementbookingsetupid = bs.Id;
              //dr.msdyn_generatewodaysinadvance = bs.GetAttributeValue<int>("msdyn_generatewodaysinadvance");
              //dr.msdyn_name = bs.GetAttributeValue<string>("msdyn_name");
              //dr.msdyn_postponegenerationuntil = bs.GetAttributeValue<DateTime>("msdyn_postponegenerationuntil");
              //dr.msdyn_recurrencesettings = bs.GetAttributeValue<string>("msdyn_recurrencesettings");
              //dr.msdyn_revision = bs.GetAttributeValue<int>("msdyn_revision");
              //dr.UpdateAgreement = cbBookingSetupCheckUncheck.Checked;
              //dr.bookingsetupentity = bs;
              //dsFSMigration.dtBookingSetup.AdddtBookingSetupRow(dr);
            }
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception processing booking setup: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          dsFSMigration.EndInit();
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
          //lblBookingSetupTotalRecords.Text = $"Total Records: {dsFSMigration.dtBookingSetup.Count}";
        }
      });
    }

    private void cbBookingSetupCheckUncheck_CheckedChanged(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Processing Rows...",
        IsCancelable = false,
        Work = (worker, args) => {
          try {
            int iCurrent = 0;
            int iTotal = dsFSMigration.dtUsers.Rows.Count;
            foreach (dsFSMigration.dtBookingSetupRow dr in dsFSMigration.dtBookingSetup.Rows) {
              iCurrent++;
              worker.ReportProgress(1, $"Processing row {iCurrent} of {iTotal}...");
              dr.UpdateAgreement = cbBookingSetupCheckUncheck.Checked;
            }
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception setting Update Agreement Column: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnBookingSetupUpdate_Click(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";
      int dow = -1;
      string startDate = "";

      startDate = $"{dpBookingSetupStartDate.Value.Month}/{dpBookingSetupStartDate.Value.Day}/{dpBookingSetupStartDate.Value.Year}";

      tsbCancelOperation.Enabled = true;
      Dictionary<Entity, dsFSMigration.dtBookingSetupRow> rowsToUpdate = new Dictionary<Entity, dsFSMigration.dtBookingSetupRow>();

      WorkAsync(new WorkAsyncInfo {
        Message = "Updating Booking Setups...",
        IsCancelable = true,
        Work = (worker, args) => {
          var results = from r in dsFSMigration.dtBookingSetup.AsEnumerable()
                        where r.UpdateAgreement
                        select r;
          List<Entity> bookingSetups = new List<Entity>();
          foreach (var dr in results) {
            if (worker.CancellationPending) {
              break;
            }
            bookingSetups.Add((Entity)dr.bookingsetupentity);
          }
          errorMessage = upgradeUtility.UpdateTargetBookingSetups(worker, bookingSetups, startDate);
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Updating Booking Setups..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
        }
      });
    }

    private void ckClearTargetRoles_CheckedChanged(object sender, EventArgs e) {
      try {
        dsFSMigration.BeginInit();
        foreach (dsFSMigration.dtUserSecurityRolesRow dr in dsFSMigration.dtUserSecurityRoles.Rows) {
          dr.ClearTargetRoles = ckClearTargetRoles.Checked;
        }
      }
      catch (Exception ex) {
        throw ex;
      }
      finally {
        dsFSMigration.EndInit();
        dsFSMigration.AcceptChanges();
      }
    }

    private void btnDataCleanupValidateRecords_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      errorMessage = "";
      txtErrorInfo.Text = "";
      dsFSMigration.dtDeletedRecords.Clear();

      WorkAsync(new WorkAsyncInfo {
        Message = "Validating Records...",
        IsCancelable = true,
        AsyncArgument = new ValidateDataArgs() {
          sourceEntityLogicalName = ((ComboboxItem)cbDataCleanupSourceEntityList.SelectedItem).Text,
          sourcePrimaryNameAttribute = ((ComboboxItem)cbDataCleanupSourceEntityList.SelectedItem).Value,
          targetEntityLogicalName = ((ComboboxItem)cbDataCleanupTargetEntityList.SelectedItem).Text,
          targetPrimaryNameAttribute = ((ComboboxItem)cbDataCleanupTargetEntityList.SelectedItem).Value
        },
        Work = (worker, args) => {
          int iCurrent = 0;
          int iTotal = 0;

          dsFSMigration.BeginInit();
          List<Entity> colSourceRecords = null;
          List<Entity> colTargetRecords = null;

          if (txtDataCleanupSourceFetchXml.Text.Trim() == String.Empty) {
            QueryExpression qeSource = new QueryExpression(((ValidateDataArgs)args.Argument).sourceEntityLogicalName) {
              ColumnSet = new ColumnSet(((ValidateDataArgs)args.Argument).sourcePrimaryNameAttribute)
            };
            worker.ReportProgress(1, "Retrieving all recors from source, please wait...");
            colSourceRecords = upgradeUtility.RetrieveAllSourceRecords(qeSource);
          }
          else {
            worker.ReportProgress(1, "Retrieving all recors from source, please wait...");
            colSourceRecords = upgradeUtility.RetrieveAllSourceRecords(txtDataCleanupSourceFetchXml.Text);
          }

          if (txtDataCleanupTargetFetchXml.Text.Trim() == String.Empty) {
            QueryExpression qeTarget = new QueryExpression(((ValidateDataArgs)args.Argument).targetEntityLogicalName) {
              ColumnSet = new ColumnSet(((ValidateDataArgs)args.Argument).targetPrimaryNameAttribute)
            };
            worker.ReportProgress(1, "Retrieving all records from target, please wait...");
            colTargetRecords = upgradeUtility.RetrieveAllTargetRecords(qeTarget);
          }
          else {
            worker.ReportProgress(1, "Retrieving all records from target, please wait...");
            colTargetRecords = upgradeUtility.RetrieveAllTargetRecords(txtDataCleanupTargetFetchXml.Text);
          }

          // Build the list of records to delete
          List<Entity> colEntitiesToDelete = new List<Entity>();
          iTotal = colTargetRecords.Count();
          foreach (Entity te in colTargetRecords) {
            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Validating Record {iCurrent} of {colTargetRecords.Count}");
            var ent = from se in colSourceRecords
                      where se.Id == te.Id
                      select se;
            if (ent == null || ent.Count() <= 0) {
              dsFSMigration.dtDeletedRecordsRow newRow = dsFSMigration.dtDeletedRecords.NewdtDeletedRecordsRow();
              newRow.Id = te.Id;
              newRow.Name = te.GetAttributeValue<string>(((ValidateDataArgs)args.Argument).targetPrimaryNameAttribute);
              if (newRow.IsNameNull()) { newRow.Name = "(NO NAME)"; }
              newRow.entitylogicalname = te.LogicalName.ToLower();
              dsFSMigration.dtDeletedRecords.AdddtDeletedRecordsRow(newRow);
            }
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Validating Records..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          txtErrorInfo.Text = errorMessage;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          dsFSMigration.AcceptChanges();
          tsbCancelOperation.Enabled = false;
        }
      });
    }

    private void cbDataCleanupSourceEntityList_SelectedIndexChanged(object sender, EventArgs e) {
      if (cbDataCleanupSourceEntityList.SelectedItem != null)
        txtDataCleanupSourceAttribute.Text = ((ComboboxItem)cbDataCleanupSourceEntityList.SelectedItem).Value;
    }

    private void cbDataCleanupTargetEntityList_SelectedIndexChanged(object sender, EventArgs e) {
      if (cbDataCleanupTargetEntityList.SelectedItem != null)
        txtDataCleanupTargetAttribute.Text = ((ComboboxItem)cbDataCleanupTargetEntityList.SelectedItem).Value;
    }

    private void btnDataCleanupLoadSourceEntities_Click(object sender, EventArgs e) {
      LoadSourceEntitiesList();
    }

    private void btnDataCleanupLoadTargetEntities_Click(object sender, EventArgs e) {
      LoadTargetEntitiesList();
    }

    private void btnDataCleanupDeleteRecords_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      errorMessage = "";
      txtErrorInfo.Text = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Deleting Records...",
        IsCancelable = true,
        Work = (worker, args) => {
          errorMessage = upgradeUtility.DeleteTargetRecords(worker, ref dsFSMigration);
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Creating Stub Users..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          txtErrorInfo.Text = errorMessage;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
        }
      });
    }

    private void btnDataCleanupCreateTestData_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      errorMessage = "";
      txtErrorInfo.Text = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Deleting Records...",
        IsCancelable = true,
        Work = (worker, args) => {

          for (int i = 1; i <= 55; i++) {
            worker.ReportProgress(upgradeUtility.Percent(i, 56), $"Creating test record {i} of 56");
            Entity ent = new Entity("msdyn_priority");
            ent.Attributes.Add("msdyn_name", $"Test Delete {i.ToString()}");
            svcTarget.Create(ent);
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Creating Stub Users..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          txtErrorInfo.Text = errorMessage;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
        }
      });

    }

    private void btnCompareTeamSecurity_Click(object sender, EventArgs e) {
      LoadTeamSecurity();
    }

    private void dgTeamSecurity_SelectionChanged(object sender, EventArgs e) {
      // filter grids.
      if (dgTeamSecurity.SelectedRows != null && dgTeamSecurity.SelectedRows.Count > 0) {
        // get the first selected row.
        var dr = ((DataRowView)dgTeamSecurity.SelectedRows[0].DataBoundItem).Row as dsFSMigration.dtTeamSecurityRolesRow;
        Guid sourceId = dr.source_teamid;
        Guid targetId = dr.Istarget_teamidNull() ? Guid.Empty : dr.target_teamid;
        dgSourceTeamRoles.DataSource = dsFSMigration.dtSourceTeamSecurityRoles.Select($"teamid = '{sourceId}'");
        //lblSourceUserRoles.Text = $"Source User Roles (userid = '{sourceId}')";
        dgTargetTeamRoles.DataSource = dsFSMigration.dtTargetTeamSecurityRoles.Select($"teamid = '{targetId}'");
        //lblTargetUserRoles.Text = $"Target User Roles (userid = '{targetId}')";
      }
    }

    private void dgTeamSecurity_DataError(object sender, DataGridViewDataErrorEventArgs e) {
      try {
        var x = (DataGridView)sender;
        string sourceTeam = debugSourceUserTeam == null ? "null" : debugSourceUserTeam.GetAttributeValue<string>("name");
        string targetTeam = debugTargetUserTeam == null ? "null" : debugTargetUserTeam.GetAttributeValue<string>("name");

        var column = x[e.ColumnIndex, e.RowIndex].OwningColumn;
        string errMsg = $"dgTeamSecurity Data Error: Column: {column.Name}, Row Index: {e.RowIndex}, Exception Message: {e.Exception.Message}, sourceUser: {sourceTeam}, targetUser: {debugTargetUserTeam}, sourceSecurityRoles: {debugSourceUserTeamRoles}, targetSecurityRoles: {debugTargetUserTeamRoles}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
        e.ThrowException = false;
        e.Cancel = false;
      }
      catch (Exception ex) {
        string errMsg = $"dgUserSecurity Exception: {ex.Message}";
        LogError(errMsg);
        errorMessage += $"{txtErrorInfo.Text}{errMsg}{Environment.NewLine}{Environment.NewLine}";
      }
    }

    private void ckTeamSecurityCheckUncheck_CheckedChanged(object sender, EventArgs e) {
      foreach (dsFSMigration.dtTeamSecurityRolesRow dr in dsFSMigration.dtTeamSecurityRoles.Rows) {
        dr.SyncRoles = ckTeamSecurityCheckUncheck.Checked;
      }
    }

    private void ckClearTeamTargetRoles_CheckedChanged(object sender, EventArgs e) {
      try {
        dsFSMigration.BeginInit();
        foreach (dsFSMigration.dtTeamSecurityRolesRow dr in dsFSMigration.dtTeamSecurityRoles.Rows) {
          dr.ClearTargetRoles = ckClearTeamTargetRoles.Checked;
        }
      }
      catch (Exception ex) {
        throw ex;
      }
      finally {
        dsFSMigration.EndInit();
        dsFSMigration.AcceptChanges();
      }
    }

    private void btnTeamSyncRoles_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Synchronizing Security Roles...",
        IsCancelable = true,
        Work = (worker, args) => {
          var selectedTeams = from t in dsFSMigration.dtTeamSecurityRoles.AsEnumerable()
                              where t.SyncRoles
                              select t;

          if (selectedTeams == null || selectedTeams.Count() <= 0)
            return;

          int iCurrent = 0;
          int iTotal = selectedTeams.Count();
          foreach (var dr in selectedTeams) {
            try {
              if (worker.CancellationPending) {
                break;
              }
              iCurrent++;
              worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing Team: {dr.source_name} ({iCurrent} of {iTotal})");
              Guid sourceTeamId = dr.source_teamid;
              Guid targetTeamId = dr.Istarget_teamidNull() ? Guid.Empty : dr.target_teamid;
              Guid targetBUId = dr.Istarget_businessunitidNull() ? Guid.Empty : dr.target_businessunitid;

              var sourceTeamRoles = dr.GetChildRows(dsFSMigration.dtTeamSecurityRoles.ChildRelations["dtTeamSecurityRoles_dtSourceTeamSecurityRoles"]);
              if (sourceTeamRoles != null && sourceTeamRoles.Count() > 0) {
                List<Guid> targetRoleGuids = new List<Guid>();
                foreach (var sr in sourceTeamRoles) {
                  var sourceRole = sr as dsFSMigration.dtSourceTeamSecurityRolesRow;
                  var roleMapping = dsFSMigration.dtSecurityRoleMapping.GetTargetRole(sourceRole.roleid, sourceRole.rolebusinessunitid);
                  targetRoleGuids.Add(roleMapping.target_roleid);
                }
                bool clearRoles = dr.IsClearTargetRolesNull() ? false : dr.ClearTargetRoles;
                string result = upgradeUtility.TargetAddRolesToTeam(targetTeamId, targetRoleGuids, clearRoles);
                if (result.Trim() != String.Empty) {
                  errorMessage += $"{result}{Environment.NewLine}{Environment.NewLine}";
                }
              }
            }
            catch (Exception ex) {
              dr.RowError = $"{dr.RowError} | {ex.Message}";
              errorMessage += $"{dr.RowError} | {ex.Message}{Environment.NewLine}========================{Environment.NewLine}";
            }
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Processing Teams..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnAgreementMarkExpired_Click(object sender, EventArgs e) {

    }

    private void btnTeamAssignmentLoadTeams_Click(object sender, EventArgs e) {
      dsFSMigration.dtTeamMembership.Clear();
      dsFSMigration.dtSourceTeamMembership.Clear();
      dsFSMigration.dtTargetTeamMembership.Clear();
      dsFSMigration.AcceptChanges();
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = false,
        Work = (worker, args) => {
          worker.ReportProgress(1, "Loading Source Teams...");
          List<Entity> sourceTeams = upgradeUtility.RetrieveAllSourceTeams();

          worker.ReportProgress(1, "Loading Source Team Membership...");
          List<Entity> sourceTeamMemberships = upgradeUtility.RetrieveAllSourceTeamMembership();

          worker.ReportProgress(1, "Loading Target Teams...");
          List<Entity> targetTeams = upgradeUtility.RetrieveAllTargetTeams();

          worker.ReportProgress(1, "Loading Target Team Members...");
          List<Entity> targetTeamMemberships = upgradeUtility.RetrieveAllTargetTeamMembership();

          worker.ReportProgress(1, "Comparing Team Membership...");
          int iCurrent = 0;
          // process source users and security roles.
          dsFSMigration.BeginInit();

          foreach (Entity sourceTeam in sourceTeams) {
            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, sourceTeams.Count), $"Comparing Teams {iCurrent} of {sourceTeams.Count}...");

            var targetTeam = targetTeams.FirstOrDefault<Entity>(o => o.GetAttributeValue<string>("name").Trim().Equals(sourceTeam.GetAttributeValue<string>("name").Trim(), StringComparison.OrdinalIgnoreCase));
            // do not process default target teams.
            if (targetTeam != null && targetTeam.Contains("isdefault") && targetTeam.GetAttributeValue<bool>("isdefault"))
              continue;

            try {
              debugSourceUserTeam = sourceTeam;

              var drTA = dsFSMigration.dtTeamMembership.NewdtTeamMembershipRow();
              drTA.ClearTargetTeamMembers = cbClearTargetMembersCheckUncheck.Checked;
              drTA.SyncTeamMembers = cbSyncTeamMembersCheckUncheck.Checked;
              drTA.source_teamid = sourceTeam.Id;
              drTA.source_teamname = sourceTeam.GetAttributeValue<string>("name");
              drTA.source_teambusinessunitid = sourceTeam.GetAttributeValue<EntityReference>("businessunitid").Id;
              drTA.source_teambuname = sourceTeam.GetAttributeValue<EntityReference>("businessunitid").Name;
              dsFSMigration.dtTeamMembership.AdddtTeamMembershipRow(drTA);

              // process source team mmembership
              var colSTM = sourceTeamMemberships.Where(o => o.GetAttributeValue<Guid>("teamid").Equals(sourceTeam.Id));
              if (colSTM != null && colSTM.Count() > 0) {
                foreach (var stm in colSTM) {
                  // add the team member names to the dtSourceTeamMember table first.
                  if (drTA.Issource_teammembersNull())
                    drTA.source_teammembers = stm.GetAttributeValue<AliasedValue>("su.fullname").Value.ToString();
                  else
                    drTA.source_teammembers += $", {stm.GetAttributeValue<AliasedValue>("su.fullname").Value.ToString()}";

                  // Create the child rows for the team membership.
                  var drSourceTeamMember = dsFSMigration.dtSourceTeamMembership.NewdtSourceTeamMembershipRow();
                  drSourceTeamMember.source_teamid = sourceTeam.Id;
                  drSourceTeamMember.source_teamname = sourceTeam.GetAttributeValue<string>("name");
                  drSourceTeamMember.source_userid = stm.GetAttributeValue<Guid>("systemuserid");
                  drSourceTeamMember.source_username = stm.GetAttributeValue<AliasedValue>("su.fullname").Value.ToString();
                  drSourceTeamMember.source_userisdisabled = (bool)stm.GetAttributeValue<AliasedValue>("su.isdisabled").Value;
                  dsFSMigration.dtSourceTeamMembership.AdddtSourceTeamMembershipRow(drSourceTeamMember);
                }
              }

              if (targetTeam == null) {
                drTA.target_teamid = Guid.Empty;
                drTA.target_teamname = "NOT IN TARGET";
                drTA.SyncTeamMembers = false;
              }
              else {
                // when loading target data do NOT pre-map the data.  I want to see the data that is actually in the target.
                // process the target team.
                drTA.target_teamid = targetTeam.Id;
                drTA.target_teamname = targetTeam.GetAttributeValue<string>("name");
                drTA.target_teambusinessunitid = targetTeam.GetAttributeValue<EntityReference>("businessunitid").Id;
                drTA.target_teambuname = targetTeam.GetAttributeValue<EntityReference>("businessunitid").Name;

                // If the target team happens to be a default team we are not able to add members to the target team.
                if (targetTeam.Contains("isdefault") && targetTeam.GetAttributeValue<bool>("isdefault")) {
                  drTA.SyncTeamMembers = false;
                  drTA.ClearTargetTeamMembers = false;
                  drTA.target_isdefault = true;
                }

                // Create the child rows for the team membership.
                var colTTM = targetTeamMemberships.Where(o => o.GetAttributeValue<Guid>("teamid").Equals(targetTeam.Id));
                if (colTTM != null && colTTM.Count() > 0) {
                  foreach (var ttm in colTTM) {
                    if (drTA.Istarget_teammembersNull()) {
                      drTA.target_teammembers = ttm.GetAttributeValue<AliasedValue>("su.fullname").Value.ToString();
                    }
                    else {
                      drTA.target_teammembers += $", {ttm.GetAttributeValue<AliasedValue>("su.fullname").Value.ToString()}";
                    }


                    if (!ttm.Contains("systemuserid")) {
                      int i = 0;
                    }

                    var drTargetTeamMember = dsFSMigration.dtTargetTeamMembership.NewdtTargetTeamMembershipRow();
                    drTargetTeamMember.target_teamid = targetTeam.Id;
                    drTargetTeamMember.target_teamname = targetTeam.GetAttributeValue<string>("name");
                    drTargetTeamMember.target_userid = ttm.GetAttributeValue<Guid>("systemuserid");
                    drTargetTeamMember.target_username = ttm.GetAttributeValue<AliasedValue>("su.fullname").Value.ToString();
                    drTargetTeamMember.target_userisdisabled = (bool)ttm.GetAttributeValue<AliasedValue>("su.isdisabled").Value;
                    dsFSMigration.dtTargetTeamMembership.AdddtTargetTeamMembershipRow(drTargetTeamMember);
                  }
                }
              }
            }
            catch (Exception ex) {
              errorMessage += $"{Environment.NewLine}Error processing team members for team {sourceTeam.GetAttributeValue<string>("name")}({iCurrent}): {ex.Message}";
            }
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Comparing Teams..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          dsFSMigration.EndInit();
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void txtDataCleanupTargetFetchXml_TextChanged(object sender, EventArgs e) {

    }

    private void dgTeamMembership_SelectionChanged(object sender, EventArgs e) {
      // filter grids.
      if (dgTeamMembership.SelectedRows != null && dgTeamMembership.SelectedRows.Count > 0) {
        // get the first selected row.
        var dr = ((DataRowView)dgTeamMembership.SelectedRows[0].DataBoundItem).Row as dsFSMigration.dtTeamMembershipRow;
        Guid sourceId = dr.source_teamid;
        Guid targetId = dr.Istarget_teamidNull() ? Guid.Empty : dr.target_teamid;

        //dgSourceTeamMembership.DataSource = dsFSMigration.dtSourceTeamMembership.Select($"source_teamid = '{sourceId}'");
        //dgTargetTeamMembership.DataSource = dsFSMigration.dtTargetTeamMembership.Select($"target_teamid = '{targetId}'");
        dtTargetTeamMembershipBindingSource.Filter = $"target_teamid = '{targetId}'";
        dtSourceTeamMembershipBindingSource.Filter = $"source_teamid = '{sourceId}'";
      }
    }

    private void btnSyncTeamMembers_Click(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";
      tsbCancelOperation.Enabled = true;

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = true,
        Work = (worker, args) => {
          var selectedTeams = dsFSMigration.dtTeamMembership.Where(o => o.SyncTeamMembers == true);
          if (selectedTeams == null || selectedTeams.Count() <= 0) {
            errorMessage = "NO TEAMS SELECTED";
            return;
          }

          int iCurrent = 0;
          int iTotal = selectedTeams.Count();

          foreach (var dr in selectedTeams) {
            if (worker.CancellationPending) {
              break;
            }
            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing Team: {dr.source_teamname} ({iCurrent} of {iTotal})");

            var sourceTeamUsers = dr.GetdtSourceTeamMembershipRows();
            if (sourceTeamUsers == null || sourceTeamUsers.Count() <= 0) {
              errorMessage += $"Source team {dr.source_teamname} has no users assigned, skipping team";
              continue;
            }

            Guid teamid = dr.target_teamid;
            List<Guid> usersToAdd = new List<Guid>();
            List<Guid> usersToRemove = new List<Guid>();

            var targetTeamUsers = dr.GetdtTargetTeamMembershipRows();

            // Build list of users already assigned to target and the list that will get removed.
            if (targetTeamUsers != null && targetTeamUsers.Count() > 0) {
              usersToRemove.AddRange(from y in targetTeamUsers select y.target_userid);
            }

            usersToAdd.AddRange(from y in sourceTeamUsers select ((dsFSMigration)y.Table.DataSet).GetTargetUser(y.source_userid).target_id);

            // Map to the target user based on source user id.
            var mappedTargetUsers = from y in sourceTeamUsers select ((dsFSMigration)y.Table.DataSet).GetTargetUser(y.source_userid);
            var invalidTargetUsers = mappedTargetUsers.Where(o => o.target_IsDisabled);
            if (invalidTargetUsers != null && invalidTargetUsers.Count() > 0) {
              foreach (var invalidUser in invalidTargetUsers) {
                errorMessage += $"{Environment.NewLine}User: {invalidUser.target_domain} is disabled, skipping user.{Environment.NewLine}";
                if (usersToAdd.Contains(invalidUser.target_id)) {
                  usersToAdd.Remove(invalidUser.target_id);
                }
              }
            }

            // Update the target team membership
            string results = upgradeUtility.TargetAddMembersToTeam(teamid, usersToAdd, usersToRemove);
            if (results != "")
              errorMessage += $"{results}{Environment.NewLine}================================{Environment.NewLine}";
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Processing Teams..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void cbStubUsersHideDisabled_CheckedChanged(object sender, EventArgs e) {
      //LoadSystemUsers();
    }

    private void cbStubUsersHideMatchingBU_CheckedChanged(object sender, EventArgs e) {
      //LoadSystemUsers();
    }

    private void btnAgreementWorkflowResetRefreshUsers_Click(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";
      tsbCancelOperation.Enabled = false;

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = false,
        Work = (worker, args) => {
          args.Result = upgradeUtility.RetrieveAllTargetUsers();
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          cbAgreementWorkFlowResetUsers.Items.Clear();
          var result = args.Result as List<Entity>;
          foreach (Entity ent in result) {
            cbAgreementWorkFlowResetUsers.Items.Add(new ComboboxItem(ent.GetAttributeValue<string>("fullname"), ent.Id.ToString(), ent));
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnAgreementWorkflowResetSearch_Click(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";
      tsbCancelOperation.Enabled = true;

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = true,
        AsyncArgument = cbAgreementWorkFlowResetUsers.SelectedItem,
        Work = (worker, args) => {
          dsFSMigration.BeginInit();
          var x = args.Argument as ComboboxItem;
          List<Entity> runningJobs = upgradeUtility.RetrieveTargetSystemJobsForUser(new Guid(x.Value));
          List<Guid> addedValues = new List<Guid>();
          foreach (Entity ent in runningJobs) {
            var dr = dsFSMigration.dtAgreementReset.NewdtAgreementResetRow();
            if (ent.Contains("ag1.msdyn_agreementid")) {
              Guid agreementId = new Guid(ent.GetAttributeValue<AliasedValue>("ag1.msdyn_agreementid").Value.ToString());
              if (addedValues.Contains(agreementId))
                continue;
              addedValues.Add(agreementId);
              dr.agreementid = agreementId;
              dr.agreementname = ent.GetAttributeValue<AliasedValue>("ag1.msdyn_name").Value.ToString();
            }
            else if (ent.Contains("ag2.msdyn_agreementid")) {
              Guid agreementId = new Guid(ent.GetAttributeValue<AliasedValue>("ag2.msdyn_agreementid").Value.ToString());
              if (addedValues.Contains(agreementId))
                continue;
              addedValues.Add(agreementId);
              dr.agreementid = agreementId;
              dr.agreementname = ent.GetAttributeValue<AliasedValue>("ag2.msdyn_name").Value.ToString();
            }
            else if (ent.Contains("ag3.msdyn_agreementid")) {
              Guid agreementId = new Guid(ent.GetAttributeValue<AliasedValue>("ag3.msdyn_agreementid").Value.ToString());
              if (addedValues.Contains(agreementId))
                continue;
              addedValues.Add(agreementId);
              dr.agreementid = agreementId;
              dr.agreementname = ent.GetAttributeValue<AliasedValue>("ag3.msdyn_name").Value.ToString();
            }
            else if (ent.Contains("ag4.msdyn_agreementid")) {
              Guid agreementId = new Guid(ent.GetAttributeValue<AliasedValue>("ag4.msdyn_agreementid").Value.ToString());
              if (addedValues.Contains(agreementId))
                continue;
              addedValues.Add(agreementId);
              dr.agreementid = agreementId;
              dr.agreementname = ent.GetAttributeValue<AliasedValue>("ag4.msdyn_name").Value.ToString();
            }
            else if (ent.Contains("ag5.msdyn_agreementid")) {
              Guid agreementId = new Guid(ent.GetAttributeValue<AliasedValue>("ag5.msdyn_agreementid").Value.ToString());
              if (addedValues.Contains(agreementId))
                continue;
              addedValues.Add(agreementId);
              dr.agreementid = agreementId;
              dr.agreementname = ent.GetAttributeValue<AliasedValue>("ag5.msdyn_name").Value.ToString();
            }
            dsFSMigration.dtAgreementReset.AdddtAgreementResetRow(dr);
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Processing Teams..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          dsFSMigration.EndInit();
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnAgreementWorkflowReset_Click(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";
      tsbCancelOperation.Enabled = true;

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = true,
        Work = (worker, args) => {
          int iCurrent = 0;
          int iTotal = dsFSMigration.dtAgreementReset.Count;

          foreach (var dr in dsFSMigration.dtAgreementReset) {
            if (worker.CancellationPending) {
              break;
            }

            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing Agreement: {dr.agreementname} ({iCurrent} of {iTotal})");

            // Update the target team membership
            string results = upgradeUtility.TargetResetWorkflows(dr.agreementid);
            if (results != "")
              errorMessage += $"{results}{Environment.NewLine}================================{Environment.NewLine}";
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Processing Teams..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void cbUserSnycUserInfo_CheckedChanged(object sender, EventArgs e) {

    }

    private void btnLoadRequirements_Click(object sender, EventArgs e) {
      txtErrorInfo.Text = "";
      errorMessage = "";
      tsbCancelOperation.Enabled = true;

      WorkAsync(new WorkAsyncInfo {
        Message = "Please wait...",
        IsCancelable = true,
        //AsyncArgument = cbAgreementWorkFlowResetUsers.SelectedItem,
        Work = (worker, args) => {
          dsFSMigration.BeginInit();
          //var x = args.Argument as ComboboxItem;
          List<Entity> requirements = upgradeUtility.RetrieveAllSourceRequirements();

          foreach (Entity ent in requirements) {
            var dr = dsFSMigration.dtSourceRequirements.NewdtSourceRequirementsRow();
            dr.requirementid = ent.Id;
            if (ent.Contains("msdyn_name")) {
              dr.name = ent.GetAttributeValue<string>("msdyn_name");
            }
            if (ent.Contains("msdyn_fromdate")) {
              dr.fromdate = ent.GetAttributeValue<DateTime>("msdyn_fromdate");
            }
            if (ent.Contains("msdyn_todate")) {
              dr.todate = ent.GetAttributeValue<DateTime>("msdyn_todate");
            }
            if (ent.Contains("msdyn_territory")) {
              dr.territoryid = ent.GetAttributeValue<EntityReference>("msdyn_territory").Id;
            }
            dsFSMigration.dtSourceRequirements.AdddtSourceRequirementsRow(dr);
          }
        },
        ProgressChanged = (args) => {
          if (args.ProgressPercentage == 1) {
            SetWorkingMessage(args.UserState.ToString());
          }
          else {
            SetWorkingMessage(args.UserState.ToString());
            SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Processing Teams..."));
          }
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          tsbCancelOperation.Enabled = false;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          dsFSMigration.EndInit();
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnMapUOM_Click(object sender, EventArgs e) {
      dsFSMigration.dtUOMMapping.Clear();
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Loading Source Unit of Measure...",
        IsCancelable = true,
        Work = (worker, args) => {
          try {
            List<Entity> sourceUOMs = upgradeUtility.RetrieveAllSourceUOM();
            worker.ReportProgress(1, "Loading Target Unit of Measure...");
            List<Entity> targetUOMs = upgradeUtility.RetrieveAllTargetUOM();

            worker.ReportProgress(1, "Comparing Unit of Measure...");
            foreach (Entity sourceUOM in sourceUOMs) {
              var matchingUOMs = from tr in targetUOMs
                                 where (tr.GetAttributeValue<string>("name").ToLower() == sourceUOM.GetAttributeValue<string>("name").ToLower())
                                 select tr;
              dsFSMigration.dtUOMMappingRow dr = dsFSMigration.dtUOMMapping.NewdtUOMMappingRow();
              dr.source_uomid = sourceUOM.Id;
              dr.source_name = sourceUOM.GetAttributeValue<string>("name");

              if (matchingUOMs.Count() > 0) {
                var tr = matchingUOMs.First<Entity>();
                dr.target_uomid = tr.Id;
                dr.target_name = tr.GetAttributeValue<string>("name");
              }
              dsFSMigration.dtUOMMapping.AdddtUOMMappingRow(dr);
            }
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception processing unit of measure: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnMapUOMSchedule_Click(object sender, EventArgs e) {
      dsFSMigration.dtUOMScheduleMapping.Clear();
      txtErrorInfo.Text = "";
      errorMessage = "";

      WorkAsync(new WorkAsyncInfo {
        Message = "Loading Source UOM Schedule...",
        IsCancelable = true,
        Work = (worker, args) => {
          try {
            List<Entity> sourceUOMSchedules = upgradeUtility.RetrieveAllSourceUOMSchedule();
            worker.ReportProgress(1, "Loading Target UOM Schedule...");
            List<Entity> targetUOMSchedules = upgradeUtility.RetrieveAllTargetUOMSchedule();

            worker.ReportProgress(1, "Comparing UOM Schedule...");
            foreach (Entity sourceUOMSchedule in sourceUOMSchedules) {
              var matchingUOMSchedules = from tr in targetUOMSchedules
                                         where (tr.GetAttributeValue<Guid>("uomscheduleid") == sourceUOMSchedule.GetAttributeValue<Guid>("uomscheduleid"))
                                         select tr;
              dsFSMigration.dtUOMScheduleMappingRow dr = dsFSMigration.dtUOMScheduleMapping.NewdtUOMScheduleMappingRow();
              dr.source_uomscheduleid = sourceUOMSchedule.Id;
              dr.source_name = sourceUOMSchedule.GetAttributeValue<string>("name");

              if (matchingUOMSchedules.Count() > 0) {
                var tr = matchingUOMSchedules.First<Entity>();
                dr.target_uomscheduleid = tr.Id;
                dr.target_name = tr.GetAttributeValue<string>("name");
              }
              dsFSMigration.dtUOMScheduleMapping.AdddtUOMScheduleMappingRow(dr);
            }
          }
          catch (Exception ex) {
            MessageBox.Show($"Exception processing UOM Schedule: {ex.Message}");
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          dsFSMigration.AcceptChanges();
          txtErrorInfo.Text = errorMessage;
        }
      });
    }

    private void btnCreateTargetUOMSchedule_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      Dictionary<Entity, dsFSMigration.dtUOMScheduleMappingRow> rowsToUpdate = new Dictionary<Entity, dsFSMigration.dtUOMScheduleMappingRow>();

      WorkAsync(new WorkAsyncInfo {
        Message = "Creating UOM Schedules...",
        IsCancelable = true,
        Work = (worker, args) => {
          var results = from r in dsFSMigration.dtUOMScheduleMapping.AsEnumerable()
                        where r.AddToTarget
                        select r;
          int iCurrent = 0;
          int iTotal = results.Count();
          foreach (var dr in results) {
            if (worker.CancellationPending) {
              break;
            }
            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing UOM Schedule: {dr.source_name} ({iCurrent} of {iTotal})");
            try {
              Entity newUOMSchedule = upgradeUtility.CreateTargetUOMSchedule(worker, dr.source_uomscheduleid, dr.source_name, dr.source_description, dr.source_baseuomname);
            }
            catch (Exception ex) {
              dr.RowError = ex.Message;
            }
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Creating Stub Users..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
        }
      });
    }

    private void btnAddSPRole_Click(object sender, EventArgs e) {
      tsbCancelOperation.Enabled = true;
      errorMessage = "";
      txtErrorInfo.Text = "";
      Dictionary<Entity, dsFSMigration.dtUsersRow> rowsToSync = new Dictionary<Entity, dsFSMigration.dtUsersRow>();

      WorkAsync(new WorkAsyncInfo {
        Message = "Adding Salesperson role to users...",
        IsCancelable = true,
        Work = (worker, args) => {
          var results = dsFSMigration.dtUsers.Where(o => !o.IsMissingSPRoleNull() && o.MissingSPRole == true);
          int iCurrent = 0;
          int iTotal = results.Count();

          foreach (var dr in results) {
            if (worker.CancellationPending) {
              break;
            }
            iCurrent++;
            worker.ReportProgress(upgradeUtility.Percent(iCurrent, iTotal), $"Processing User: {dr.source_fullname} ({iCurrent} of {iTotal})");
            try {
              List<Guid> spRole = new List<Guid>();
              string buName = dr.target_BUName.Trim().ToLower();
              var drSpRole = dsFSMigration.dtSecurityRoleMapping.Where(o => !o.Istarget_rolenameNull() && o.target_rolename.Trim().ToLower().Equals("salesperson") && o.target_businessunitname.Trim().ToLower() == dr.target_BUName.Trim().ToLower()).First<dsFSMigration.dtSecurityRoleMappingRow>();
              spRole.Add(drSpRole.target_roleid);
              string addRoleResult = upgradeUtility.TargetAddRolesToUser(dr.target_id, spRole, false);
              if (addRoleResult.Trim() != String.Empty) {
                errorMessage += $"{addRoleResult}{Environment.NewLine}{Environment.NewLine}";
              }
            }
            catch (Exception ex) {
              dr.RowError += ex.Message;
              errorMessage += $"{ex.Message}{Environment.NewLine}{Environment.NewLine}";
            }
          }
        },
        ProgressChanged = (args) => {
          SetWorkingMessage(args.UserState.ToString());
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(args.ProgressPercentage, "Creating Stub Users..."));
        },
        PostWorkCallBack = (args) => {
          if (args.Error != null) {
            MessageBox.Show(args.Error.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
          }
          txtErrorInfo.Text = errorMessage;
          SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs(String.Empty));
          tsbCancelOperation.Enabled = false;
        }
      });
    }
  }

  public class ComboboxItem {
    public string Text { get; set; }
    public string Value { get; set; }

    public Entity Entity { get; set; }

    public ComboboxItem(string txt, string val) {
      Text = txt;
      Value = val;
    }

    public ComboboxItem(string txt, string val, Entity ent) {
      Text = txt;
      Value = val;
      Entity = ent;
    }

    public override string ToString() {
      return Text;
    }
  }
}
 
 
 