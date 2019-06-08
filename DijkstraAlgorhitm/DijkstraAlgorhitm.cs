using System;
namespace DijkstraAlgorhitm
{
    /// <summary>
    /// Implements Dijkstra shortest paths algorithm
    /// </summary>
    public class DijkstraAlgorhitm
    {
        /// <summary>
        /// Call Dijkstra algorithm
        /// </summary>
        /// <param source graph ="graph"></param>
        /// <param source node (start node) ="source"></param>
        /// <returns></returns>
        public Graph Execute(Graph graph, DijkstraNode source)
        {
            PriorityQueue<DijkstraNode> priorityQueue = null;
            Initialize(graph, source, priorityQueue);

            while (priorityQueue != null)
            {
                var start = priorityQueue.ExtractMin();

                var adjNodes = graph.AdjDict[start];

                foreach(var (node, weight) in adjNodes)
                {
                    //if (priorityQueue.Contains(adjNode))
                    //{
                        Relax(start, node, weight, priorityQueue);
                    //}
                }
            }
            return graph;

        }

        /// <summary>
        /// Dijkstra initialization 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="source"></param>
        /// <param name="distances"></param>
        private void Initialize
            (Graph graph, DijkstraNode source, PriorityQueue<DijkstraNode> distances)
        {
            source.Distance = 0;
            var vertices = graph.AdjDict.GetVertices();
            distances = new PriorityQueue<DijkstraNode>();

            foreach (var v in vertices)
                distances.Insert(v, v.Distance);
        }

        /// <summary>
        /// Find shortest distance
        /// </summary>
        /// <param name="u"></param>
        /// <param name="v"></param>
        /// <param name="weight"></param>
        private void Relax(DijkstraNode u, DijkstraNode v, int weight, 
            PriorityQueue<DijkstraNode> queue)
        {
            var distanceThroughU = u.Distance + weight;
            if (distanceThroughU < v.Distance)
            {
                v.Distance = distanceThroughU;
                v.Prev = u;
                //queue.ChangePriority(v, distanceThroughU);
            }
                
        }


    }
}
