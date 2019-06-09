namespace DijkstraAlgorhitm
{
    /// <summary>
    /// implements vertice of graph 
    /// also stores elements of Dijkstra algorithm (distance and prev)
    /// </summary>
    public class DijkstraNode
    {
        /// <summary>
        /// name of node
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// distance from source node. 
        /// int.MaxValue by default
        /// </summary>
        public int Distance { get; set; }

        /// <summary>
        /// previous node of shortest path
        /// </summary>
        public DijkstraNode Prev { get; set; } 

        public int QueueIndex { get; set; }

        public DijkstraNode(string name, int distance = int.MaxValue)
        {
            Name = name;
            Distance = distance;
        }
    }
}
