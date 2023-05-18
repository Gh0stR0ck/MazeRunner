namespace MazeRunner.Model
{
    public class Maze
    {
        public Node[,] maze;
        public int maxTiles = 930; // Max Size based in info 

        public Maze()
        {
            maze = new Node[maxTiles * 2, maxTiles * 2];
        }
    }
}
