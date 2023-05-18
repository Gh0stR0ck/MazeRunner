using IO.Swagger.Model;
using MazeRunner.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MazeRunner.Algorithm
{
    public class MazeHandler
    {
        private Maze Maze { get; set; }
        public (int X, int Y) CurrentPosition;
        private (int X, int Y) GoalPosition;
        public string Goal;

        public async Task CreateNewMaze()
        {
            Maze = new Maze();
            CurrentPosition = (Maze.maxTiles, Maze.maxTiles);
            GoalPosition = CurrentPosition;
            Goal = "Exploring";
        }

        /// <summary>
        /// Update the maze with the new tile information.
        /// Would optimize with a more DRY solution.
        /// </summary>
        /// <param name="possibleActionsAndCurrentScore"></param>
        public async Task UpdateMaze(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore)
        {
            Maze.maze[CurrentPosition.X, CurrentPosition.Y].Neighbors = FillInNeightbors(possibleActionsAndCurrentScore.PossibleMoveActions);
            foreach (var moveAction in possibleActionsAndCurrentScore.PossibleMoveActions)
            {
                switch (moveAction.Direction)
                {
                    case MoveAction.DirectionEnum.Up:
                        await TryFillTile(CurrentPosition.Item1, CurrentPosition.Item2 - 1, moveAction);
                        break;

                    case MoveAction.DirectionEnum.Down:
                        await TryFillTile(CurrentPosition.Item1, CurrentPosition.Item2 + 1, moveAction);
                        break;

                    case MoveAction.DirectionEnum.Right:
                        await TryFillTile(CurrentPosition.Item1 + 1, CurrentPosition.Item2, moveAction);
                        break;

                    case MoveAction.DirectionEnum.Left:
                        await TryFillTile(CurrentPosition.Item1 - 1, CurrentPosition.Item2, moveAction);
                        break;
                }
            }
        }

        public async Task<List<string>> FindNextSteps()
        {
            if (CurrentPosition == GoalPosition) await SetNewGoalPosition();
            var pathNodeList = AStarPathfinder.FindPath(Maze.maze, Maze.maze[CurrentPosition.X, CurrentPosition.Y], Maze.maze[GoalPosition.X, GoalPosition.Y]);
            return await ConvertpathNodeListToDirectionList(pathNodeList);
        }

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
                foreach (var node in Maze.maze)
                {
                    if (node?.AllowsScoreCollection == true)
                    {
                        GoalPosition = (node.X, node.Y);
                        Goal = "Coins";
                        return;
                    }
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

        public async Task FillFirstTile(PossibleActionsAndCurrentScore possibleActionsAndCurrentScore)
        {
            // First Tile should always be created in a new maze.
            if (Maze.maze[CurrentPosition.X, CurrentPosition.Y] != null) await CreateNewMaze();

            Maze.maze[CurrentPosition.X, CurrentPosition.Y] = new Node
            {
                X = CurrentPosition.X,
                Y = CurrentPosition.Y,
                HasBeenVisited = true,
                IsStart = true,
                AllowsScoreCollection = (bool)possibleActionsAndCurrentScore.CanCollectScoreHere,
                AllowsExit = (bool)possibleActionsAndCurrentScore.CanExitMazeHere,
                Neighbors = FillInNeightbors(possibleActionsAndCurrentScore.PossibleMoveActions)
            };
        }

        private List<string> FillInNeightbors(List<MoveAction> moveActionList)
        {
            List<string> result = new List<string>();

            foreach (MoveAction moveAction in moveActionList) result.Add(moveAction.Direction.Value.ToString());

            return result;
        }

        private async Task TryFillTile(int x, int y, MoveAction MoveAction)
        {
            if (Maze.maze[x, y] == null)
                Maze.maze[x, y] = new Node
                {
                    X = x,
                    Y = y,
                    IsStart = false,
                    HasBeenVisited = MoveAction.HasBeenVisited.GetValueOrDefault(),
                    AllowsScoreCollection = MoveAction.AllowsScoreCollection.GetValueOrDefault(),
                    AllowsExit = MoveAction.AllowsExit.GetValueOrDefault(),
                    Neighbors = new List<string>()
                };
        }

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
            Maze.maze[CurrentPosition.X, CurrentPosition.Y].Parent = null;
        }

        public bool CheckIfMovementIsPossible(List<MoveAction> possibleMoveActions, string step)
        {
            foreach (var action in possibleMoveActions)
            {
                if (action.Direction.Value.ToString() == step) return true;
            }

            return false;
        }
    }
}
