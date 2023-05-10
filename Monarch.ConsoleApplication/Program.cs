using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monarch.ConsoleApplication.Games;
using Monarch.ConsoleApplication.Menus;
using Monarch.ConsoleApplication.Menus.Screens;
using Monarch.Shared.Game;
using Monarch.Shared.Game.Setup;
using Monarch.Shared.Repositories;

Console.WriteLine("Welcome!");

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        //services.AddHostedService<GameService>();
        services.AddSingleton<IGameManager, GameManager>();

        services.AddScoped<IEmpireRepository, EmpireRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ISettlementRepository, SettlementRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
    })
    .Build();

await host.StartAsync();

//var gameManager = InitializeGame();
var gameManager = host.Services.GetService<IGameManager>();
var gameLog = new GameLog();

var seedRandomizer = new Random();
gameManager!.SetUp(new GameConfig()
{
    LayoutSeed = seedRandomizer.Next(),
    GameSeed = seedRandomizer.Next(),
    PlayerCount = 3,
    TileRows = 10,
    TileColumns = 10
});

var mainScreen = new MainScreen(gameManager!, gameLog!);
var menuStack = new Menu(mainScreen.Option);
menuStack.Present();

Console.WriteLine("Exiting...");
await host.StopAsync();

/*private static IGameManager InitializeGame()
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
}*/
