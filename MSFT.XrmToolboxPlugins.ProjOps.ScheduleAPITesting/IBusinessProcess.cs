using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSCPS.F12FSMigration {
    public interface IBusinessProcess {
        Guid Id { get; }
        string Name { get; }
        string LogicalName { get; }
        BusinessProcessType Type { get; }
        ActivationState State { get; }
    }
}
