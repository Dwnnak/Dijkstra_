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
        /// <param name="graph"> source graph </param>
        /// <param name="source"> the node 
        /// from which we look for the shortest paths </param>
        /// <returns> graph with filled "distances" and "prevs" of every node </returns>
        public Graph Execute(Graph graph, DijkstraNode source)
        {
            var priorityQueue = new PriorityQueue();
            Initialize(graph, source, priorityQueue);

            while (priorityQueue.Size != 0)
            {
                var start = priorityQueue.ExtractMin();
                var adjNodes = graph.AdjDict[start.node];
                
                foreach (var (node, weight) in adjNodes)
                {
                    if (priorityQueue.Contains(node))
                        Relax(start.node, node, weight, priorityQueue);
                }
            }
            return graph;
        }

        /// <summary>
        /// Dijkstra initialization 
        /// </summary>
        /// <param name="graph"> source graph </param>
        /// <param name="source"> source node </param>
        /// <param name="distances"> empty priority queue </param>
        private void Initialize
            (Graph graph, DijkstraNode source, PriorityQueue distances)
        {
            source.Distance = 0;
            var vertices = graph.AdjDict.GetVertices();
            foreach (var v in vertices)
                distances.Insert(v, v.Distance);
        }

        /// <summary>
        /// find shortest distance to vertice v 
        /// between known distance (v.Distance) 
        /// and from u across edge (u, v)
        /// </summary>
        /// <param name="u"> source node </param>
        /// <param name="v"> adjacent node </param>
        /// <param name="weight"> weith of edge between u and v </param>
        /// <param name="queue"> pririty queue with Dijkstra nodes </param>
        private void Relax(DijkstraNode u, DijkstraNode v, int weight,
            PriorityQueue queue)
        {
            var distanceThroughU = u.Distance + weight;
            if (distanceThroughU < v.Distance)
            {
                v.Distance = distanceThroughU;
                v.Prev = u;
                queue.ChangePriority(v, distanceThroughU);
            }
        }
    }
}
