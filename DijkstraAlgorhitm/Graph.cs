namespace DijkstraAlgorhitm
{
    /// <summary>
    /// implements a graph structure as AdjacencyDictionary
    /// </summary>
    public class Graph
    {
        /// <summary>
        /// stores nodes of graph and adjacent nodes 
        /// with edges weights to them
        /// </summary>
        public AdjacencyDictionary AdjDict { get; set; }

        public Graph()
        {
            AdjDict = new AdjacencyDictionary();
        }

        /// <summary>
        /// add vertice to graph
        /// </summary>
        /// <param name="name"> name of future node </param>
        /// <returns></returns>
        public DijkstraNode AddNode(string name)
        {
            return AdjDict.AddNode(name);
        }

        /// <summary>
        /// add edge to graph
        /// </summary>
        /// <param name="u"> source node </param>
        /// <param name="v"> destination node </param>
        /// <param name="weight"> weight from source to destination </param>
        public void AddEdge(DijkstraNode u, DijkstraNode v, int weight)
        {
            AdjDict.AddEdge(u, v, weight);
        }
    }
}
