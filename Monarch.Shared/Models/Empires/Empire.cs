using Monarch.Shared.Models.Settlements;
using Monarch.Shared.Models.Units;
using System.Collections.Generic;

namespace Monarch.Shared.Models.Empires
{
    public class Empire : IEmpire
    {
        private readonly List<ISettlement> _settlements = new();
        private readonly List<IUnit> _units = new();

        public Empire(int id, string name)
        {
            ID = id;
            Name = name;
        }

        public int ID { get; set; }
        public string Name { get; set; }
        public IEnumerable<ISettlement> Settlements => _settlements;
        public IEnumerable<IUnit> Units => _units;

        public void ExtractResources()
        {
            
        }
    }
}
