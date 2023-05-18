using System.Collections.Generic;

namespace MazeRunner.Entity
{
    /// <summary>
    /// The Node that is every possible position in the maze.
    /// </summary>
    public class Node
    {
        // Data for the game itself.
        public int X;
        public int Y;
        public bool IsStart;
        public bool HasBeenVisited;
        public bool AllowsScoreCollection;
        public bool AllowsExit;

        // Data for the Algorithm
        public int Cost;
        public int Heuristic;
        public int TotalCost => Cost + Heuristic;
        public Node Parent;
        public List<string> Neighbors;
    }
}
