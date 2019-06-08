using System;
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
        /// <param name of future node="name"></param>
        /// <returns></returns>
        public DijkstraNode AddNode(string name)
        {
            return AdjDict.AddNode(name);
        }

        /// <summary>
        /// add edge to graph
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="weight"></param>
        public void AddEdge(DijkstraNode u, DijkstraNode v, int weight)
        {
            AdjDict.AddEdge(u, v, weight);
        }
    }
}
