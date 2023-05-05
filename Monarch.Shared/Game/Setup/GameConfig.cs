namespace Monarch.Shared.Game.Setup
{
    public class GameConfig : IGameConfig
    {
        public int LayoutSeed { get; set; }
        public int GameSeed { get; set; }
        public int PlayerCount { get; set; }
        public int TileRows { get; set; }
        public int TileColumns { get; set; }
    }
}
