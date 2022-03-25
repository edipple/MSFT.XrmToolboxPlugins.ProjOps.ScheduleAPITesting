using Microsoft.Xrm.Sdk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCPS.F12FSMigration {
    public class BusinessProcessBase {
        public BusinessProcessBase(BusinessProcessType type) {
            this.LogicalName = type.ToString().ToLower();
            this.Type = type;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LogicalName { get; set; }
        public ActivationState State { get; set; }
        public BusinessProcessType Type { get; set; }
        public WorkflowCategory WorkFlowCategory { get; set; }
        public Entity Entity { get; set; }
        public string IsManaged { get; set; }
        public string EventHandler { get; set; }
        public string SDKMessage { get; set; }
        public string PrimaryEntity { get; set; }
    }

    public sealed class PluginStep : BusinessProcessBase {
        // TODO: Plugin step specific metadata?
        public PluginStep()
            : base(BusinessProcessType.SdkMessageProcessingStep) { }
    }

    public sealed class Workflow : BusinessProcessBase {
        // TODO: Workflow specific metadata?
        public Workflow()
            : base(BusinessProcessType.Workflow) { }
    }
}
