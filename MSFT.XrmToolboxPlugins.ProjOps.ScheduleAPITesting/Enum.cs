using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCPS.F12FSMigration {
    public enum UpdateType : byte {
        Required = 1,
        Optional = 2,
        All = Required | Optional
    }
    public enum RequestType {
        Upsert,
        Associate,
        Create,
        Delete,
        Update,
        AddItemCampaignActivity,
        AddItemCampaign,
        AddMemberList
    }

    public enum DataStage {
        Main,
        Pre,
        Post,
        Security
    }

    public enum BusinessProcessType {
        All,
        SdkMessageProcessingStep,
        Workflow
    }

    public enum WorkflowCategory {
        Workflow,
        BusinessProcessFlow,
        Action,
        BusinessRule,
        Dialog
    }

    public enum ActivationState {
        All,
        Active,
        Inactive
    }

    public enum EntityDefinitionType {
        Entity,
        Relationship
    }

    public enum PostDataMigrationStepType {
        MarkAgreementAsExpired,
        GenerateAgreementBookingDates,
        GenerateAgreementInvoiceDates
    }

    public enum StoredProcId {
        /// <summary>
        /// Trivial stored procedure for testing
        /// </summary>
        Ping = 0,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        CreateOrganizationalUnit = 1,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        BookableResourceSetOU = 2,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        UpdateDurationOnResourceRequirement = 3,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        WorkOrdersAndAccounts = 4,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        BookableResourceBookingActualTravel = 5,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        UpdateDateWindowEndFieldOnWorkOrders = 6,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        URS_CentaurusToMCS_UpdateRequirements = 7,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        URS_JanToFebPatch_UpdateResource = 8,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        URS_PotassiumUR2ToUR3_UpdateProposedDuration = 9,
        /// <summary>
        /// Identifies one of the stored procedures that the plugin can call
        /// </summary>
        CreateResourceRequirements = 10
    }

    public enum WorkflowState {
        Draft = 0,
        Activated = 1,
    }

    public enum WorkflowStatus {
        Draft = 1,
        Activated = 2,
    }

    public enum PluginState {
        Enabled = 0,
        Disabled = 1
    }

    public enum PluginStatus {
        Enabled = 1,
        Disabled = 2
    }
}
