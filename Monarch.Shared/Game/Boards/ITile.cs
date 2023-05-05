namespace Monarch.Shared.Game.Boards
{
    public interface ITile
    {
        public Biome Biome { get; }

        public ITile North { get; }
        public ITile South { get; }
        public ITile East { get; }
        public ITile West { get; }
    }
}
