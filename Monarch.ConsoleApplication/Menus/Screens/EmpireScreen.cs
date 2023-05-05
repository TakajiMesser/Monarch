using Monarch.ConsoleApplication.Games;
using Monarch.Shared.Game;
using System;
using System.Collections.Generic;
using System.Text;

namespace Monarch.ConsoleApplication.Menus.Screens
{
    public class EmpireScreen : GameScreen
    {
        public EmpireScreen(IGameManager game, ILog log) : base(game, log)
        {
            InitializeOption();
        }

        protected override string Key => "E";
        protected override string Description => "View Empire";

        protected override Action<IList<string>> Action => (_) =>
        {
            var builder = new StringBuilder();

            //builder.AppendLine("Empire: " + _game.PlayerEmpire.Name);
            //builder.AppendLine();
            //builder.AppendLine("Number of Provinces: " + _game.PlayerEmpire.Provinces.Count);

            Console.WriteLine(builder.ToString());
        };
    }
}
