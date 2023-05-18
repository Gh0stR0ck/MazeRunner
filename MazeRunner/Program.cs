using MazeRunner.Core;
using System;
using System.Threading.Tasks;

namespace MazeRunner
{
    internal class Program
    {
        /// <summary>
        /// The main function of this application.
        /// </summary>
        /// <param name="args"> Not using any. Useless the give the program arguments. </param>
        /// <returns></returns>
        static async Task Main(string[] args)
        {
            // Configure API key authorization
            IO.Swagger.Client.Configuration.Default.BasePath = "https://maze.hightechict.nl/";
            IO.Swagger.Client.Configuration.Default.AddDefaultHeader("Authorization", "HTI Thanks You [b81b]");

            var gameHandler = new GameHandler();

            // End the previous Game. This will make sure we have a new game.
            await gameHandler.EndGameAsync();

            // Let's get started!
            await gameHandler.SetupUpGame();
            await gameHandler.StartGame();
            //await gameHandler.EndGameAsync(); // Disable this if you wanna see your score on the leaderboard.

            // Making sure the messages can be read.
            Console.ReadLine();
        }
    }
}
