using IO.Swagger.Api;
using IO.Swagger.Model;
using System.Threading.Tasks;

namespace MazeRunner.Core
{
    /// <summary>
    /// The class that will help the playing getting thro the maze.
    /// </summary>
    public class PlayerHandler
    {
        private MazeApi MazeApi;
        private MazeHandler MazeHandler;

        /// <summary>
        /// Initialize the Handler and Api needed for the player.
        /// </summary>
        public PlayerHandler()
        {
            MazeApi = new MazeApi();
            MazeHandler = new MazeHandler();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="possibleActionsAndCurrentScore"></param>
        /// <param name="potentialReward"></param>
        /// <returns></returns>
        public async Task StartWalking(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore, int potentialReward)
        {
            // If for some reason there is no possible actions data. Get it.
            if (possibleActionsAndCurrentScore == null) possibleActionsAndCurrentScore = await MazeApi.PossibleActionsAsync();

            // Making sure we start walking in a new maze
            await MazeHandler.CreateNewMaze();

            // Already putting the starting point in the blank maze.
            await MazeHandler.FillFirstNode(possibleActionsAndCurrentScore);
            await MazeHandler.UpdateMaze(possibleActionsAndCurrentScore);

            // The loop that will get thro the maze.
            while (true)
            {
                
                if (CheckForExit(possibleActionsAndCurrentScore)) break;

                // Getting a list of steps. 
                var stepsList = await MazeHandler.FindNextSteps();

                // Stepping thro the maze.
                foreach (var step in stepsList)
                {
                    possibleActionsAndCurrentScore = await MazeApi.MoveAsync(step);
                    MazeHandler.ChangeCurrentPosition(step);
                    await MazeHandler.UpdateMaze(possibleActionsAndCurrentScore);
                }

                // We should stop exploring when we got all the coins in the maze. This doesn't work on the Example Maze.
                /*
                if (possibleActionsAndCurrentScore.CurrentScoreInHand == potentialReward && MazeHandler.GetClosestNodeForCollectingCoins() != null)
                {
                    MazeHandler.Goal = "Coins";
                }
                */

                // Should we leave the maze?
                if (MazeHandler.Goal == "Coins" && possibleActionsAndCurrentScore.CanCollectScoreHere.GetValueOrDefault() && possibleActionsAndCurrentScore.CurrentScoreInHand > 0)
                {
                    await MazeApi.CollectScoreAsync();
                    MazeHandler.Goal = "Leave";
                }
            }

            await MazeApi.ExitMazeAsync();
        }

        /// <summary>
        /// Check if we should exit the maze.
        /// </summary>
        /// <param name="possibleActionsAndCurrentScore"> Check if current node on the server is allowed to exit. </param>
        /// <returns></returns>
        private bool CheckForExit(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore) =>
            (MazeHandler.Goal == "Leave" && possibleActionsAndCurrentScore.CanExitMazeHere.GetValueOrDefault()) ? true : false ; 
    }
}
