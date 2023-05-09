namespace Monarch.Shared.Game.Boards
{
    public interface ITile
    {
        Biome Biome { get; }

        ITile? GetTile(Direction direction);
    }
}
