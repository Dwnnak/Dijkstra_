﻿namespace DijkstraAlgorhitm
{
    /// <summary>
    /// Extension methods for Graph class
    /// </summary>
    public static class GraphExtensions
    {
        /// <summary>
        /// simplification: call Dijkstra algorithm from instance of Graph
        /// </summary>
        /// <param name="graph"> source graph </param>
        /// <param name="source"> source node </param>
        /// <returns> graph with filled "distances" and "prevs" of every node </returns>
        public static Graph FindDijkstraShortestPathsFrom(this Graph graph, DijkstraNode source)
        {
            var dijkstra = new DijkstraAlgorhitm();
            dijkstra.Execute(graph, source);
            return graph;
        }
    }
}
