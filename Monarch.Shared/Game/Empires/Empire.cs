using System.Collections.Generic;

namespace Monarch.Shared.Game.Empires
{
    public class Empire : IEmpire
    {
        private readonly List<IProvince> _provinces = new();

        public IReadOnlyList<IProvince> Provinces => _provinces.AsReadOnly();

        public void ExtractResources()
        {
            
        }
    }
}
