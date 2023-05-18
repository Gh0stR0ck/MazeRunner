using IO.Swagger.Model;
using MazeRunner.Algorithm;
using MazeRunner.Entity;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeRunner.Core
{
    /// <summary>
    /// The class that handles the maze. 
    /// This will make sure the player knows where it can walk thro the maze.
    /// </summary>
    public class MazeHandler
    {
        private Maze Maze;
        private (int X, int Y) GoalPosition;

        public (int X, int Y) CurrentPosition;
        public string Goal;

        /// <summary>
        /// Creating a fresh new maze and let the player start in the middle.
        /// </summary>
        /// <returns></returns>
        public async Task CreateNewMaze()
        {
            Maze = new Maze();
            CurrentPosition = (Maze.maxNodes, Maze.maxNodes);
            GoalPosition = CurrentPosition;
            Goal = "Exploring";
        }

        /// <summary>
        /// Update the maze with the new node information.
        /// Would optimize with a more DRY solution.
        /// </summary>
        /// <param name="possibleActionsAndCurrentScore"></param>
        public async Task UpdateMaze(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore)
        {
            Maze.maze[CurrentPosition.X, CurrentPosition.Y].Neighbors = FillInNeighbors(possibleActionsAndCurrentScore.PossibleMoveActions);
            foreach (var moveAction in possibleActionsAndCurrentScore.PossibleMoveActions)
            {
                switch (moveAction.Direction)
                {
                    case MoveAction.DirectionEnum.Up:
                        await TryFillNode(CurrentPosition.Item1, CurrentPosition.Item2 - 1, moveAction);
                        break;

                    case MoveAction.DirectionEnum.Down:
                        await TryFillNode(CurrentPosition.Item1, CurrentPosition.Item2 + 1, moveAction);
                        break;

                    case MoveAction.DirectionEnum.Right:
                        await TryFillNode(CurrentPosition.Item1 + 1, CurrentPosition.Item2, moveAction);
                        break;

                    case MoveAction.DirectionEnum.Left:
                        await TryFillNode(CurrentPosition.Item1 - 1, CurrentPosition.Item2, moveAction);
                        break;
                }
            }
        }

        /// <summary>
        /// Finding the next steps the player will take. For this the player needs a goal position.
        /// After the player has a goal position, we will ask the algorithm for a path. 
        /// The path will be made to simple instructions for the player to understand.
        /// </summary>
        /// <returns> A list of instructions (Directions). </returns>
        public async Task<List<string>> FindNextSteps()
        {
            if (CurrentPosition == GoalPosition) await SetNewGoalPosition();
            var pathNodeList = AStarPathfinder.FindPath(Maze.maze, Maze.maze[CurrentPosition.X, CurrentPosition.Y], Maze.maze[GoalPosition.X, GoalPosition.Y]);
            return await ConvertpathNodeListToDirectionList(pathNodeList);
        }

        /// <summary>
        /// Converting the Path of the algorithm to a list of steps.
        /// </summary>
        /// <param name="pathNodeList"> List of nodes that is the path. </param>
        /// <returns> List of steps based on the path. </returns>
        private async Task<List<string>> ConvertpathNodeListToDirectionList(List<Node> pathNodeList)
        {
            List<string> directionList = new List<string>();

            Node prev = null;
            foreach (Node node in pathNodeList)
            {
                if (prev != null)
                {
                    if (prev.X < node.X) directionList.Add("Right");
                    if (prev.X > node.X) directionList.Add("Left");
                    if (prev.Y < node.Y) directionList.Add("Down");
                    if (prev.Y > node.Y) directionList.Add("Up");
                }

                prev = node;
            }

            return directionList;
        }

        /// <summary>
        /// We need a goal position. This function could use a refactor.
        /// </summary>
        /// <returns></returns>
        private async Task SetNewGoalPosition()
        {
            if (Goal == "Exploring")
            {
                // Fist Visit everything
                foreach (var node in Maze.maze)
                {
                    if (node?.HasBeenVisited == false)
                    {
                        GoalPosition = (node.X, node.Y);
                        return;
                    }
                }
            }

            if (Goal != "Leave")
            {
                // Second collect the coins
                var node = await GetClosestNodeForCollectingCoins();
                if (node != null)
                {
                    GoalPosition = (node.X, node.Y);
                    Goal = "Coins";
                    return;

                }
            }

            // Third exit the maze
            foreach (var node in Maze.maze)
            {
                if (node?.AllowsExit == true)
                {
                    GoalPosition = (node.X, node.Y);
                    Goal = "Leave";
                    return;
                }
            }

            Message.Write("Cannot set a new goal position.");
        }

        /// <summary>
        /// The the first node found to collect coins. Could recreate the function to get the 
        /// </summary>
        /// <returns> The closest node for collection the coins in hand. </returns>
        public async Task<Node> GetClosestNodeForCollectingCoins()
        {
            List<Node> coinCollectionNodeList = new List<Node>(); 
            Node closestNode = null;
            Node currentNode = Maze.maze[CurrentPosition.X, CurrentPosition.Y];

            foreach (var node in Maze.maze)
            {
                if (node?.AllowsScoreCollection == true)
                {
                    coinCollectionNodeList.Add(node);
                }
            }

            foreach (var node in coinCollectionNodeList)
            {
                if (closestNode == null) {
                    closestNode = node;
                    continue;
                }
                if (CalculateDistance(currentNode, closestNode) > (CalculateDistance(currentNode, node)))
                    closestNode = node;
            }

            return closestNode;
        }

        /// <summary>
        /// Calculating the Manhattan distance between nodes.
        /// </summary>
        /// <param name="nodeA"></param>
        /// <param name="nodeB"></param>
        /// <returns></returns>
        private static int CalculateDistance(Node nodeA, Node nodeB)
        {
            return Math.Abs(nodeA.X - nodeB.X) + Math.Abs(nodeA.Y - nodeB.Y);
        }

        /// <summary>
        /// Fill in the starting node in the maze.
        /// Set the neighbors so that the algorithm knows if there is a wall between nodes.
        /// </summary>
        /// <param name="possibleActionsAndCurrentScore"> Neighbors without a wall. </param>
        /// <returns></returns>
        public async Task FillFirstNode(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore)
        {
            Maze.maze[CurrentPosition.X, CurrentPosition.Y] = new Node
            {
                X = CurrentPosition.X,
                Y = CurrentPosition.Y,
                HasBeenVisited = true,
                IsStart = true,
                AllowsScoreCollection = (bool)possibleActionsAndCurrentScore.CanCollectScoreHere,
                AllowsExit = (bool)possibleActionsAndCurrentScore.CanExitMazeHere,
                Neighbors = FillInNeighbors(possibleActionsAndCurrentScore.PossibleMoveActions)
            };
        }

        /// <summary>
        /// The function that fills in a node's neighbor as they come. We don't have this information when create the Node.
        /// </summary>
        /// <param name="moveActionList"></param>
        /// <returns></returns>
        private List<string> FillInNeighbors(List<MoveAction> moveActionList)
        {
            List<string> result = new List<string>();

            foreach (MoveAction moveAction in moveActionList) result.Add(moveAction.Direction.Value.ToString());

            return result;
        }

        /// <summary>
        /// Try to fill in the node if it's not created yet.
        /// </summary>
        /// <param name="x"> The X position of the node. </param>
        /// <param name="y"> The Y position of the node. </param>
        /// <param name="moveAction"> More information about the node. </param>
        /// <returns></returns>
        private async Task TryFillNode(int x, int y, MoveAction moveAction)
        {
            if (Maze.maze[x, y] == null)
                Maze.maze[x, y] = new Node
                {
                    X = x,
                    Y = y,
                    IsStart = false,
                    HasBeenVisited = moveAction.HasBeenVisited.GetValueOrDefault(),
                    AllowsScoreCollection = moveAction.AllowsScoreCollection.GetValueOrDefault(),
                    AllowsExit = moveAction.AllowsExit.GetValueOrDefault(),
                    Neighbors = new List<string>()
                };
        }

        /// <summary>
        /// Changing our position in the maze. 
        /// </summary>
        /// <param name="step"> The step that has been given as a command to the server. </param>
        public void ChangeCurrentPosition(string step)
        {
            switch (step)
            {
                case "Right":
                    CurrentPosition.X++;
                    break;
                case "Left":
                    CurrentPosition.X--;
                    break;
                case "Down":
                    CurrentPosition.Y++;
                    break;
                case "Up":
                    CurrentPosition.Y--;
                    break;
            }

            Maze.maze[CurrentPosition.X, CurrentPosition.Y].HasBeenVisited = true;
        }
    }
}
