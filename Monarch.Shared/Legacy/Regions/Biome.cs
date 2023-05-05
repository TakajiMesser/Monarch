using Monarch.Shared.Legacy.Goods;
using Monarch.Shared.Statistics;
using System.Collections.Generic;

namespace Monarch.Shared.Legacy.Regions
{
    public enum BiomeType
    {
        Plains,
        Forest,
        Desert,
        Tundra,
        River,
        Swamp,
        Mountains,
        Lake,
        Sea
    }

    public class Biome
    {
        private List<string> _resourceNames = new();

        public Biome(BiomeType type, int percentage)
        {
            BiomeType = type;
            Percentage = new Percentage(percentage);
        }

        public BiomeType BiomeType { get; set; }
        public Percentage Percentage { get; set; }

        public IEnumerable<Resource> GetResources()
        {
            foreach (var name in _resourceNames)
            {
                yield return new Resource(name, Percentage.Value);
            }
        }
    }
}
