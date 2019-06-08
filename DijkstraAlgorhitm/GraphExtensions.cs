using System;
namespace DijkstraAlgorhitm
{
    public static class GraphExtensions
    {
        public static Graph FindDijkstraShortestPathsFrom(this Graph graph, DijkstraNode source)
        {
            var dijkstra = new DijkstraAlgorhitm();
            dijkstra.Execute(graph, source);
            return graph;
        }
    }
}
