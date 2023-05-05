using Monarch.Shared.Legacy.Goods;
using System;

namespace Monarch.Shared.Legacy.Building
{
    public class RecipeSet
    {
        public ResourceSet Resources { get; }
        public Resource Production { get; }

        public bool CanAfford(ResourceSet resources) => Resources.IsSubsetOf(resources);

        public void Produce(ResourceSet resources)
        {
            resources.Subtract(Resources);
            resources.Add(Production);
        }
    }
}
