using Monarch.Shared.Statistics;

namespace Monarch.Shared.Game.Boards
{
    public class Biome
    {
        public Biome(BiomeType type, int strength)
        {
            BiomeType = type;
            Strength = new Percentage(strength);
        }

        public BiomeType BiomeType { get; }
        public Percentage Strength { get; }
    }
}
