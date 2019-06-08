using System;
namespace DijkstraAlgorhitm
{
    /// <summary>
    /// Extension methods for Graph class
    /// </summary>
    public static class GraphExtensions
    {
        /// <summary>
        /// simplification: call Dijkstra algorithm from instance of Graph
        /// </summary>
        /// <param source graph ="graph"></param>
        /// <param source node="source"></param>
        /// <returns></returns>
        public static Graph FindDijkstraShortestPathsFrom(this Graph graph, DijkstraNode source)
        {
            var dijkstra = new DijkstraAlgorhitm();
            dijkstra.Execute(graph, source);
            return graph;
        }
    }
}
