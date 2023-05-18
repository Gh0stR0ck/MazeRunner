using IO.Swagger.Api;
using IO.Swagger.Model;
using MazeRunner.Algorithm;
using MazeRunner.Model;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace MazeRunner
{
    public class PlayerHandler
    {
        private MazeApi MazeApi;
        private MazeHandler MazeHandler;

        public PlayerHandler()
        {
            MazeApi = new MazeApi();
            MazeHandler = new MazeHandler();
        }

        public async Task StartWalking(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore, int potentialReward)
        {
            // If no data. Get it.
            if (possibleActionsAndCurrentScore == null) possibleActionsAndCurrentScore = await MazeApi.PossibleActionsAsync();

            await MazeHandler.CreateNewMaze();

            //Already putting the starting point in the blank maze.
            await MazeHandler.FillFirstTile(possibleActionsAndCurrentScore);
            await MazeHandler.UpdateMaze(possibleActionsAndCurrentScore);

            while (true)
            {
                if (CheckForExit(possibleActionsAndCurrentScore))
                {
                    break;
                }

                var stepsList = await MazeHandler.FindNextSteps();

                foreach (var step in stepsList)
                {
                    possibleActionsAndCurrentScore = await MazeApi.MoveAsync(step);
                    MazeHandler.ChangeCurrentPosition(step);
                    await MazeHandler.UpdateMaze(possibleActionsAndCurrentScore);
                }

                if (MazeHandler.Goal == "Coins" && possibleActionsAndCurrentScore.CanCollectScoreHere.GetValueOrDefault() && possibleActionsAndCurrentScore.CurrentScoreInHand > 0)
                {
                    await MazeApi.CollectScoreAsync();
                    MazeHandler.Goal = "Leave";
                }
            }

            await MazeApi.ExitMazeAsync();
        }

        private bool CheckForExit(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore) => (MazeHandler.Goal == "Leave" && possibleActionsAndCurrentScore.CanExitMazeHere.GetValueOrDefault()) ? true : false ; 
    }
}
