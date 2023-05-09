using Monarch.Shared.Models.Settlements;
using Monarch.Shared.Models.Units;
using System.Collections.Generic;

namespace Monarch.Shared.Models.Empires
{
    public interface IEmpire : IModel
    {
        string Name { get; }
        IEnumerable<ISettlement> Settlements { get; }
        IEnumerable<IUnit> Units { get; }

        void ExtractResources();
    }
}
