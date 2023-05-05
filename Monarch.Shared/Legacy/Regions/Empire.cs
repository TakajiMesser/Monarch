using Monarch.Shared.Goods;
using System.Collections.Generic;

namespace Monarch.Shared.Regions
{
    public class Empire
    {
        public string Name { get; set; }

        public List<Province> Provinces { get; } = new();
        public ResourceSet Resources { get; } = new();

        public void ExtractResources()
        {
            foreach (var province in Provinces)
            {
                Resources.AddRange(province.GetRawResources());

                foreach (var structure in province.Structures)
                {
                    foreach (var formula in structure.Formulas)
                    {
                        // TODO - Do we need to signal if this structure can't produce formulas?
                        if (Resources.CanAfford(formula))
                        {
                            var resource = Resources.Produce(formula);
                            Resources.Add(resource);
                        }
                    }
                }
            }
        }
    }
}
