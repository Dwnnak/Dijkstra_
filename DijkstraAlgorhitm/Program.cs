using System;

namespace DijkstraAlgorhitm
{
    class Program
    {
        static void Main(string[] args)
        {
            PQElement<string>[] elements = {
                new PQElement<string>("a", 10),
                new PQElement<string>("a", 9),
                new PQElement<string>("a", 8),
                new PQElement<string>("a", 7),
                new PQElement<string>("a", 6),
                new PQElement<string>("a", 5),
                new PQElement<string>("a", 4),
                new PQElement<string>("a", 3),
                new PQElement<string>("a", 2),
                new PQElement<string>("a", 1)
            };

            PriorityQueue<string> queue = new PriorityQueue<string>(elements);

            var a = queue.ExtractMin();
            var b = queue.GetMin();
            var c = queue.ExtractMin();
            queue.Remove(queue.Size - 1);
            //queue.Insert(new PQElement<string>("b", 22));
            //queue.Insert(new PQElement<string>("b", 3));
            //queue.Insert(new PQElement<string>("b", -2));

            queue.Remove(queue.Size - 1);
            queue.ChangePriority(0, 10);
            var g = new Graph();
            var aaa = g.AddNode("a");
            var bbb = g.AddNode("b");
            var ccc = g.AddNode("c");
            g.AddEdge(aaa, bbb, 1);
            g.AddEdge(bbb, aaa, 2);
            g.AddEdge(bbb, ccc, 4);
            g.FindDijkstraShortestPathsFrom(aaa);
            Console.WriteLine($"{aaa.Distance} {bbb.Distance} {ccc.Distance}");
        }
    }
}
