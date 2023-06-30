using Monarch.WindowsApp.Managers;

Console.WriteLine("Starting...");

var gameManager = new GameManager();
gameManager.Load();
gameManager.Start();

Console.WriteLine("Ending...");
