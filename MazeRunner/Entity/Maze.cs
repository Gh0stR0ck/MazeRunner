namespace MazeRunner.Entity
{
    /// <summary>
    /// The model of the maze containing all the nodes.
    /// </summary>
    public class Maze
    {
        public Node[,] maze;
        public int maxNodes = 930;  

        /// <summary>
        /// Making sure the maze is big enough.
        /// </summary>
        public Maze()
        {
            maze = new Node[maxNodes * 2, maxNodes * 2];
        }
    }
}
