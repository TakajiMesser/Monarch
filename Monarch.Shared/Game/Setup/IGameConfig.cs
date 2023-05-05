namespace Monarch.Shared.Game.Setup
{
    public interface IGameConfig
    {
        int LayoutSeed { get; }
        int GameSeed { get; }
        int PlayerCount { get; }
        int TileRows { get; }
        int TileColumns { get; }
    }
}
