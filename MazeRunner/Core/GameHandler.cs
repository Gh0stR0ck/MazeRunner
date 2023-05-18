using IO.Swagger.Api;
using IO.Swagger.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MazeRunner.Core
{
    /// <summary>
    /// Class that is handling the game and send the player to each maze.
    /// </summary>
    public class GameHandler
    {
        private MazesApi mazesApi;
        private PlayerApi playerApi;

        private List<MazeInfo> ListMazes;

        private PlayerHandler player;


        /// <summary>
        /// Initialize the Handler and Api needed for the game.
        /// </summary>
        public GameHandler()
        {
            playerApi = new PlayerApi();
            mazesApi = new MazesApi();

            player = new PlayerHandler();
        }

        /// <summary>
        /// Register the player to the game and getting al the mazes from the server.
        /// </summary>
        /// <returns></returns>
        public async Task SetupUpGame()
        {
            await RegisterMazeRunner();
            await InitializeAllMazes();
        }

        /// <summary>
        /// Starting the process of walking thro all the mazes.
        /// </summary>
        /// <returns></returns>
        public async Task StartGame()
        {
            foreach (var maze in ListMazes)
            {
                if (maze.Name == "Example Maze") continue;
                Message.Write($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");
                
                var possibleActions = await EnterMaze(maze.Name);
                await player.StartWalking(possibleActions, maze.PotentialReward.GetValueOrDefault());

                Message.Write($"We exit the maze [{maze.Name}].");
            }

            Message.Write("All Mazes are finished.");
        }

        /// <summary>
        /// End the Game. Removing player from leaderboard.
        /// </summary>
        /// <returns></returns>
        public async Task EndGameAsync()
        {
            try
            {
                await playerApi.ForgetAsync();
            }
            catch (Exception ex)
            {
                Message.WriteToLog(ex.Message);
            }
        }

        /// <summary>
        /// Register the player on the leaderboard.
        /// </summary>
        /// <returns></returns>
        private async Task RegisterMazeRunner()
        {
            try
            {
                await playerApi.RegisterAsync(name: "MazeRunner");
            }
            catch (Exception ex)
            {
                Message.WriteToLog(ex.Message);
            }
        }

        /// <summary>
        /// Get all the mazes information and save it in the application.
        /// </summary>
        /// <returns></returns>
        private async Task InitializeAllMazes()
        {
            try
            {
                ListMazes = await mazesApi.AllAsync();
                Message.Write("All Mazes are saved to memory.");
            }
            catch (Exception ex)
            {
                Message.WriteToLog(ex.Message);
            }
        }

        /// <summary>
        /// Enter a specific maze.
        /// </summary>
        /// <param name="mazeName"> The name of the maze we are going to enter. </param>
        /// <returns></returns>
        private async Task<PossibleActionsAndCurrentScore> EnterMaze(string mazeName)
        {
            try
            {
                var possibleActionsAndCurrentScore = await mazesApi.EnterAsync(mazeName);
                Message.Write("Mazes Entered.");
                return possibleActionsAndCurrentScore;
            }  
            catch (Exception ex)
            {
                Message.WriteToLog(ex.Message);
                return null;
            }
        }
    }
}
