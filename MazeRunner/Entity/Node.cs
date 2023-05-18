using System;
using System.Collections.Generic;

namespace MazeRunner.Model
{
    public class Node
    {
        public int X;
        public int Y;
        public bool IsStart;
        public bool HasBeenVisited;
        public bool AllowsScoreCollection;
        public bool AllowsExit;

        public int Cost { get; set; }
        public int Heuristic { get; set; }
        public int TotalCost => Cost + Heuristic;
        public Node Parent { get; set; }
        public List<string> Neighbors { get; set; }
    }
}
