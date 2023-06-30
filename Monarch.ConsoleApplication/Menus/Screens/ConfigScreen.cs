using Monarch.Shared.Game;
using Monarch.Shared.Game.Setup;

namespace Monarch.ConsoleApplication.Menus.Screens
{
    public class ConfigScreen : Screen
    {
        private readonly GameConfig _config = new();

        public ConfigScreen(IGameManager game) : base(game) { }

        public IGameConfig Config => _config;

        protected override string Key => "C";
        protected override string Description => "Edit Config";

        protected override Action<IList<string>> Action => (_) =>
        {
            Console.WriteLine("Layout Seed: " + _config.LayoutSeed);
            Console.WriteLine("Game Seed: " + _config.GameSeed);
            Console.WriteLine("Player Count: " + _config.PlayerCount);
            Console.WriteLine("Row Count: " + _config.TileRows);
            Console.WriteLine("Column Count: " + _config.TileColumns);
        };

        protected override IOption[] Options => new IOption[]
        {
            new Menus.Option("L", "Layout Seed", new string[]{ "Value" }, (args) => { _config.LayoutSeed = int.Parse(args[0]); }, Array.Empty<IOption>()),
            new Menus.Option("G", "Game Seed", new string[]{ "Value" }, (args) => { _config.GameSeed = int.Parse(args[0]); }, Array.Empty<IOption>()),
            new Menus.Option("P", "Player Count", new string[]{ "Value" }, (args) => { _config.PlayerCount = int.Parse(args[0]); }, Array.Empty<IOption>()),
            new Menus.Option("R", "Row Count", new string[]{ "Value" }, (args) => { _config.TileRows = int.Parse(args[0]); }, Array.Empty<IOption>()),
            new Menus.Option("C", "Column Count", new string[]{ "Value" }, (args) => { _config.TileColumns = int.Parse(args[0]); }, Array.Empty<IOption>()),
            new Menus.Option("D", "Use Default", Array.Empty<string>(), (args) =>
            {
                var seedRandomizer = new Random();
                _config.LayoutSeed = seedRandomizer.Next();
                _config.GameSeed = seedRandomizer.Next();
                _config.PlayerCount = 3;
                _config.TileRows = 10;
                _config.TileColumns = 10;
            }, Array.Empty<IOption>())
        };
    }
}
