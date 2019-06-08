using System;
namespace DijkstraAlgorhitm
{
    public class Graph
    {
        public AdjacencyDictionary AdjDict { get; set; }

        public DijkstraNode AddNode (string name)
        {
            return AdjDict.AddNode(name);
        }

        public void AddEdge(DijkstraNode u, DijkstraNode v, int weight)
        {
            AdjDict.AddEdge(u, v, weight);
        }
    }
}
