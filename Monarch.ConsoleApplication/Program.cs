using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Monarch.ConsoleApplication.Menus;
using Monarch.ConsoleApplication.Menus.Screens;
using Monarch.Shared.Game;
using Monarch.Shared.Repositories;

Console.WriteLine("Welcome!");

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IGameManager, GameManager>();

        services.AddScoped<IEmpireRepository, EmpireRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>();
        services.AddScoped<ISettlementRepository, SettlementRepository>();
        services.AddScoped<IUnitRepository, UnitRepository>();
    })
    .Build();

await host.StartAsync();

var gameManager = host.Services.GetService<IGameManager>();
var mainScreen = new MainScreen(gameManager!);
var menuStack = new Menu(mainScreen.AsOption());
menuStack.Present();

Console.WriteLine("Exiting...");
await host.StopAsync();
