using System.Collections.Generic;

namespace DijkstraAlgorhitm
{
    /// <summary>
    /// mathes every node to adjacent nodes with edges weights to them.
    /// For example from node U to V1, V2, ..., Vn 
    /// with edges weights (from U to V1, V2, ..., Vn)
    /// </summary>
    public class AdjacencyDictionary
    {
        /// <summary>
        /// keys is nodes of graph it mathes to
        /// values which are lists of all adjacent nodes with weights to them
        /// </summary>
        private Dictionary<DijkstraNode, List<(DijkstraNode node, int weight)>> AdjDictionary
        { get; set; }
        
        public AdjacencyDictionary()
        {
            AdjDictionary = new 
                Dictionary<DijkstraNode, List<(DijkstraNode node, int weight)>>();
        }

        /// <summary>
        /// addition new node to graph
        /// </summary>
        /// <param name="name"> of future node </param>
        /// <returns> new node with name of parameter </returns>
        public DijkstraNode AddNode(string name)
        {
            var newNode = new DijkstraNode(name);
            AdjDictionary.Add(newNode, new List<(DijkstraNode node, int weight)>());
            return newNode;
        }

        /// <summary>
        /// addition edge to source node as pair 
        /// destination node and weitght to it
        /// </summary>
        /// <param name="source"> source node </param>
        /// <param name="destination"> destination node </param>
        /// <param name="weight"> weight from source to destination </param>
        public void AddEdge(DijkstraNode source, DijkstraNode destination, int weight)
        {
            AdjDictionary[source].Add((destination, weight));
        }

        /// <summary>
        /// Get vertices of graph
        /// </summary>
        /// <returns> all the keys that are the vertices of the graph </returns>
        public Dictionary<DijkstraNode, List<(DijkstraNode, int)>>.KeyCollection GetVertices()
        {
            return AdjDictionary.Keys;
        }

        /// <summary>
        /// access to AdjacencyDictionary by index
        /// </summary>
        /// <param name ="node"> the node the list of which we want to get </param>
        /// <returns> List of adjacent nodes with edges weights to them </returns>
        public List<(DijkstraNode node, int weight)> this[DijkstraNode node]
        {
            get
            {
                return AdjDictionary[node];
            }
        }
    }
}
