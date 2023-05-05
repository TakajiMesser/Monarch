using Monarch.ConsoleApplication.Games;
using Monarch.ConsoleApplication.Menus;
using Monarch.ConsoleApplication.Menus.Screens;
using Monarch.Shared.Game;
using Monarch.Shared.Game.Setup;
using System;

namespace Monarch.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome!");

            var gameManager = InitializeGame();
            var gameLog = new GameLog();

            var mainScreen = new MainScreen(gameManager, gameLog);
            var menuStack = new Menu(mainScreen.Option);
            menuStack.Present();

            Console.WriteLine("Exiting...");
        }

        private static IGameManager InitializeGame()
        {
            var seedRandomizer = new Random();
            var config = new GameConfig()
            {
                LayoutSeed = seedRandomizer.Next(),
                GameSeed = seedRandomizer.Next(),
                PlayerCount = 3,
                TileRows = 10,
                TileColumns = 10
            };

            var manager = new GameManager();
            manager.SetUp(config);

            return manager;
        }
    }
}
