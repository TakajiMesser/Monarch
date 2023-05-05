namespace Monarch.Shared.Game.Boards
{
    public class Tile : ITile
    {
        public Tile(Biome biome) => Biome = biome;

        public Biome Biome { get; }

        public ITile? North { get; set; }
        public ITile? South { get; set; }
        public ITile? East { get; set; }
        public ITile? West { get; set; }
    }
}
