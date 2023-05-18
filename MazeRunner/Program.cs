using System;
using System.Threading.Tasks;

namespace MazeRunner
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            // Configure API key authorization
            IO.Swagger.Client.Configuration.Default.BasePath = "https://maze.hightechict.nl/";
            IO.Swagger.Client.Configuration.Default.AddDefaultHeader("Authorization", "HTI Thanks You [b81b]");

            var gameHandler = new GameHandler();

            await gameHandler.EndGameAsync();
            await gameHandler.SetupUpGame();
            await gameHandler.StartGame();
            //await gameHandler.EndGameAsync();

            Console.ReadLine();
        }
    }
}
