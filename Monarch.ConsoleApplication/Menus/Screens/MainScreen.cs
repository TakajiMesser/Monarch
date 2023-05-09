using Monarch.ConsoleApplication.Games;
using Monarch.Shared.Game;
using Monarch.Shared.Game.Actions;
using System;
using System.Collections.Generic;

namespace Monarch.ConsoleApplication.Menus.Screens
{
    public class MainScreen : GameScreen
    {
        private readonly MapScreen _mapScreen;
        private readonly EmpireScreen _empireScreen;
        private int _logEntryIndex = 0;

        public MainScreen(IGameManager game, ILog log) : base(game, log)
        {
            _mapScreen = new(game, log);
            _empireScreen = new EmpireScreen(game, log);

            InitializeOption();
        }

        protected override string Key => "R";
        protected override string Description => "Main Menu";

        protected override Action<IList<string>> Action => (_) =>
        {
            while (_logEntryIndex < _game.Log.EntryCount)
            {
                var entry = _game.Log.GetEntry(_logEntryIndex);
                Console.WriteLine(entry.Text);
                _logEntryIndex++;
            }

            Console.WriteLine(IMenu.LINE);
            Console.WriteLine("Game Phase: " + _game.GamePhase);
            Console.WriteLine("Round Phase: " + _game.RoundPhase);
            Console.WriteLine("Round Number: " + _game.RoundNumber);
            Console.WriteLine("Player Turn: " + _game.PlayerTurn);
        };

        protected override IOption[] Options => new IOption[]
        {
            _mapScreen.Option,
            _empireScreen.Option,
            Menus.Option.CreateSimple("S", "Start Game", _game.Start),
            Menus.Option.CreateSimple("A", "Take Action", TakeAction),
            Menus.Option.CreateSimple("V", "View Log", ViewLog),
            Menus.Option.CreateSimple("T", "End Turn", _game.EndTurn)
        };

        private void TakeAction() => _game.TakeAction(new PlayerAction());

        private void ViewLog()
        {
            for (var i = 0; i < _game.Log.EntryCount; i++)
            {
                var entry = _game.Log.GetEntry(i);
                Console.WriteLine(entry.Text);
            }
        }
    }
}
