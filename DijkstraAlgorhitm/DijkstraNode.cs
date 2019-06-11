namespace DijkstraAlgorhitm
{
    /// <summary>
    /// implements vertice of graph 
    /// also stores elements of Dijkstra algorithm (distance, prev, index)
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

        /// <summary>
        /// index in priority queue
        /// </summary>
        public int IndexInQueue { get; set; }

        //public int EnterNumber { get; set; }

        public DijkstraNode(string name, int distance = int.MaxValue)
        {
            Name = name;
            Distance = distance;
        }
    }
}
