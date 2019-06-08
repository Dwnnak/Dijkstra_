using System;
namespace DijkstraAlgorhitm
{
    public class Graph<TNode>
    {
        public AdjacencyDictionary<TNode> AdjDict { get; set; }

        public DijkstraNode AddNode (string name)
        {
            throw new NotImplementedException();
        }

        public void AddEdge(DijkstraNode u, DijkstraNode v, int weight)
        {
            throw new NotImplementedException();
        }
    }
}
