using MazeRunner.Entity;
using System;
using System.Collections.Generic;

namespace MazeRunner.Algorithm
{
    /// <summary>
    /// Finding our path in the maze using the A* Algaritm
    /// </summary>
    public class AStarPathfinder
    {
        /// <summary>
        /// The main function to find the Path
        /// </summary>
        /// <param name="grid"> The grid of the Maze we are using.</param>
        /// <param name="start"> Our start location in the grid. </param>
        /// <param name="goal"> The place we want to go too. </param>
        /// <returns> returns a list with all the nodes you need to pass thro. </returns>
        public static List<Node> FindPath(Node[,] grid, Node start, Node goal)
        {
            var openSet = new List<Node>();
            var closedSet = new HashSet<Node>();

            start.Parent = null; // Making sure the start node doesn't have a parent.

            start.Cost = 0;
            start.Heuristic = CalculateDistance(start, goal);
            openSet.Add(start);

            while (openSet.Count > 0)
            {
                var currentNode = GetLowestCostNode(openSet);
                openSet.Remove(currentNode);
                closedSet.Add(currentNode);

                if (currentNode == goal)
                    return ReconstructPath(goal);

                foreach (var neighbor in GetNeighbors(grid, currentNode))
                {
                    if (closedSet.Contains(neighbor))
                        continue;

                    var newCost = currentNode.Cost + CalculateDistance(currentNode, neighbor);
                    if (newCost < neighbor.Cost || !openSet.Contains(neighbor))
                    {
                        neighbor.Cost = newCost;
                        neighbor.Heuristic = CalculateDistance(neighbor, goal);
                        neighbor.Parent = currentNode;

                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                    }
                }
            }

            return new List<Node>(); // No path found
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
        /// Calculating the lowest cost nodes for the best path.
        /// </summary>
        /// <param name="nodes"> List of nodes. </param>
        /// <returns> Node that cost the lowest to be added. </returns>
        private static Node GetLowestCostNode(List<Node> nodes)
        {
            var lowestCostNode = nodes[0];
            for (int i = 1; i < nodes.Count; i++)
            {
                if (nodes[i].TotalCost < lowestCostNode.TotalCost)
                    lowestCostNode = nodes[i];
            }
            return lowestCostNode;
        }

        /// <summary>
        /// Getting all the neightbors of a node.
        /// </summary>
        /// <param name="grid"> The grid of the maze. </param>
        /// <param name="node"> The current node the algorithm is looking at. </param>
        /// <returns> A list of nodes with all the neighbors nodes that it's able to access. </returns>
        private static List<Node> GetNeighbors(Node[,] grid, Node node)
        {
            var neighbors = new List<Node>();

            
            if (node.Neighbors.Contains("Left"))
                neighbors.Add(grid[node.X - 1, node.Y]);
            if (node.Neighbors.Contains("Right"))
                neighbors.Add(grid[node.X + 1, node.Y]);
            if (node.Neighbors.Contains("Up"))
                neighbors.Add(grid[node.X, node.Y - 1]);
            if (node.Neighbors.Contains("Down"))
                neighbors.Add(grid[node.X, node.Y + 1]);

            return neighbors;
        }

        /// <summary>
        /// Reconstruct Path based on the parent of the node. 
        /// Reason the start node always get's his parent removed when this algorithm starts.
        /// </summary>
        /// <param name="node"> Current node in the Algorithm. </param>
        /// <returns> The lost of nodes that is the current path. </returns>
        private static List<Node> ReconstructPath(Node node)
        {
            var path = new List<Node>();
            while (node != null)
            {
                path.Add(node);
                node = node.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}