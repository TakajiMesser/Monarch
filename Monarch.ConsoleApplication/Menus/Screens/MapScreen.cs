using Monarch.ConsoleApplication.Games;
using Monarch.Shared.Game;
using Monarch.Shared.Game.Boards;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monarch.ConsoleApplication.Menus.Screens
{
    public class MapScreen : GameScreen
    {
        private TileScreen _tileScreen;

        public MapScreen(IGameManager game, ILog log) : base(game, log)
        {
            _tileScreen = new(game, log);

            InitializeOption();
        }

        protected override string Key => "M";

        protected override string Description => "View Map";

        protected override Action<IList<string>> Action => (_) =>
        {
            var builder = new StringBuilder();

            builder.Append("    ");

            for (var c = 0; c < _game.Board.ColumnCount; c++)
            {
                builder.Append("   ");
                builder.Append(c);
                builder.Append("   ");
            }

            builder.AppendLine();
            builder.AppendLine();
            builder.AppendLine();

            for (var r = 0; r < _game.Board.RowCount; r++)
            {
                builder.Append(r + "   ");

                for (var c = 0; c < _game.Board.ColumnCount; c++)
                {
                    var tile = _game.Board.GetTile(new Coordinates(r, c));

                    builder.Append("   ");
                    builder.Append(GetBiomeCode(tile.Biome.BiomeType));
                    builder.Append("   ");
                }

                if (r < _game.Board.RowCount - 1)
                {
                    builder.AppendLine();
                    builder.AppendLine();
                    builder.AppendLine();
                }
            }

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

        protected override IOption[] Options => new IOption[]
        {
            _tileScreen.Option,
        };
    }
}
