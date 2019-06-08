using System;
namespace DijkstraAlgorhitm
{
    public class DijkstraAlgorhitm
    {
        public Graph Execute(Graph graph, DijkstraNode source)
        {
            PriorityQueue<DijkstraNode> priorityQueue = null;
            Initialize(graph, source, priorityQueue);

            while(priorityQueue != null)
            {
                //var closest
            }
        }

        private void Initialize
            (Graph graph, DijkstraNode source, PriorityQueue<DijkstraNode> distances)
        {
            source.Distance = 0;
            var vertices = graph.AdjDict.GetVertices();
            distances = new PriorityQueue<DijkstraNode>();

            //foreach (var v in vertices)
            //    distances.Insert(v, v.Distance);
        }

        private void Relax(DijkstraNode u, DijkstraNode v, int weight)
        {

        }


    }
}
