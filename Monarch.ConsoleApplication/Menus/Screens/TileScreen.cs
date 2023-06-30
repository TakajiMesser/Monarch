using Monarch.Shared.Game;
using Monarch.Shared.Game.Boards;
using System.Text;

namespace Monarch.ConsoleApplication.Menus.Screens
{
    public class TileScreen : Screen
    {
        public TileScreen(IGameManager game) : base(game) { }

        protected override string Key => "T";

        protected override string Description => "View Tile";

        protected override string[] Arguments => new string[]
        {
            "Row",
            "Column"
        };

        protected override Action<IList<string>> Action => (arguments) =>
        {
            var builder = new StringBuilder();

            var row = int.Parse(arguments[0]);
            var column = int.Parse(arguments[1]);

            builder.AppendLine("Row: " + row);
            builder.AppendLine("Column: " + column);

            var tile = _game.Board.GetTile(new Coordinates(row, column));
            builder.Append("Biome: " + GetBiomeCode(tile.Biome.BiomeType));

            Console.WriteLine(builder.ToString());
        };

        private static string GetBiomeCode(BiomeType biomeType) => biomeType switch
        {
            BiomeType.Plains => "P",
            BiomeType.Forest => "F",
            BiomeType.Desert => "D",
            BiomeType.Tundra => "T",
            BiomeType.River => "R",
            BiomeType.Swamp => "S",
            BiomeType.Mountains => "M",
            BiomeType.Lake => "L",
            BiomeType.Sea => "S",
            _ => throw new ArgumentOutOfRangeException("Could not handle biome type " + biomeType)
        };
    }
}
