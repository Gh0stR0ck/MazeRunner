using MazeRunner.Model;
using System;
using System.Collections.Generic;

namespace MazeRunner.Algorithm
{
    public class AStarPathfinder
    {
        public static List<Node> FindPath(Node[,] grid, Node start, Node goal)
        {
            var openSet = new List<Node>();
            var closedSet = new HashSet<Node>();

            start.Cost = 0;
            start.Heuristic = CalculateHeuristic(start, goal);
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
                        neighbor.Heuristic = CalculateHeuristic(neighbor, goal);
                        neighbor.Parent = currentNode;

                        if (!openSet.Contains(neighbor))
                            openSet.Add(neighbor);
                    }
                }
            }

            return null; // No path found
        }

        private static int CalculateHeuristic(Node node, Node goal)
        {
            return Math.Abs(node.X - goal.X) + Math.Abs(node.Y - goal.Y); // Manhattan distance
        }

        private static int CalculateDistance(Node nodeA, Node nodeB)
        {
            return Math.Abs(nodeA.X - nodeB.X) + Math.Abs(nodeA.Y - nodeB.Y);
        }

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

        /*
        private static List<Node> GetNeighbors(Node[,] grid, Node node)
        {
            var neighbors = new List<Node>();
            int maxX = grid.GetLength(0) - 1;
            int maxY = grid.GetLength(1) - 1;

            if (node.X > 0)
                neighbors.Add(grid[node.X - 1, node.Y]);
            if (node.X < maxX)
                neighbors.Add(grid[node.X + 1, node.Y]);
            if (node.Y > 0)
                neighbors.Add(grid[node.X, node.Y - 1]);
            if (node.Y < maxY)
                neighbors.Add(grid[node.X, node.Y + 1]);

            return neighbors;
        }
        */

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