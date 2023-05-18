using IO.Swagger.Api;
using IO.Swagger.Model;
using MazeRunner.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MazeRunner
{
    public class GameHandler
    {
        private MazesApi mazesApi;
        private PlayerApi playerApi;

        private List<MazeInfo> ListMazes;
        private PlayerHandler player;


        public GameHandler()
        {
            playerApi = new PlayerApi();
            mazesApi = new MazesApi();

            player = new PlayerHandler();
        }

        public async Task SetupUpGame()
        {
            await RegisterMazeRunner();
            await InitializeAllMazes();
        }

        public async Task StartGame()
        {
            foreach (var maze in ListMazes)
            {
                Console.WriteLine($"[{maze.Name}] has a potential reward of [{maze.PotentialReward}] and contains [{maze.TotalTiles}] tiles;");
                PossibleActionsAndCurrentScore possibleActions = await EnterMaze(maze.Name);
                await player.StartWalking(possibleActions, maze.PotentialReward.GetValueOrDefault());
            }

            Message.Write("All Mazes are finished.");
        }

        public async Task EndGameAsync()
        {
            await playerApi.ForgetAsync();
        }

        private async Task RegisterMazeRunner()
        {
            try
            {
                await playerApi.RegisterAsync(name: "MazeRunner");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private async Task InitializeAllMazes()
        {
            try
            {
                ListMazes = await mazesApi.AllAsync();
                Message.Write("Mazes Saved.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
        }

        private async Task<PossibleActionsAndCurrentScore> EnterMaze(string maze)
        {
            try
            {
                var possibleActionsAndCurrentScore = await mazesApi.EnterAsync(maze);
                Message.Write("Mazes Entered.");
                return possibleActionsAndCurrentScore;
            }  catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return null;
            }
        }
    }
}
