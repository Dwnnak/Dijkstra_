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
        /// <param the node 
        /// from which we look for the shortest paths ="source"></param>
        /// <returns></returns>
        public Graph Execute(Graph graph, DijkstraNode source)
        {
            PriorityQueue<DijkstraNode> priorityQueue = null;
            Initialize(graph, source, priorityQueue);

            while (priorityQueue != null)
            {
                var start = priorityQueue.ExtractMin();
                var adjNodes = graph.AdjDict[start];

                foreach (var (node, weight) in adjNodes)
                {
                    if (priorityQueue.Contains(node))
                        Relax(start, node, weight, priorityQueue);
                }
            }
            return graph;
        }

        /// <summary>
        /// Dijkstra initialization 
        /// </summary>
        /// <param source graph="graph"></param>
        /// <param source node="source"></param>
        /// <param null priority queue="distances"></param>
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
        /// find shortest distance to vertice v 
        /// between known distance (v.Distance) 
        /// and from u across edge (u, v)
        /// </summary>
        /// <param source node="u"></param>
        /// <param adjacent node="v"></param>
        /// <param weith of edge between u and v="weight"></param>
        /// <param pririty queue with Dijkstra nodes="queue"></param>
        private void Relax(DijkstraNode u, DijkstraNode v, int weight,
            PriorityQueue<DijkstraNode> queue)
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
