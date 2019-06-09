using DijkstraAlgorhitm;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        /*   
             1
           >>>>>
          /     \    4
         A       B -----> C
          \     /
           <<<<< 
             2
        */
        [Test]
        public void CircleIsUseless()
        {
            var g = new Graph();
            var a = g.AddNode("a");
            var b = g.AddNode("b");
            var c = g.AddNode("c");
            g.AddEdge(a, b, 1);
            g.AddEdge(b, a, 2);
            g.AddEdge(b, c, 4);

            g.FindDijkstraShortestPathsFrom(a);
            Assert.AreEqual("source is a. to a= 0, to b= 1, to c= 5",
                DistancesFormating(g, a));
        }

        /*   
             1       1
           +----> B -----> C
          /               |  
         A                | 3
          \               |
           +----> D <-----+
             4
        */
        [Test]
        public void SmallWeightsIsUseless()
        {
            var g = new Graph();
            var a = g.AddNode("a");
            var b = g.AddNode("b");
            var c = g.AddNode("c");
            var d = g.AddNode("d");
            g.AddEdge(a, b, 1);
            g.AddEdge(a, d, 4);
            g.AddEdge(b, c, 1);
            g.AddEdge(c, d, 3);

            g.FindDijkstraShortestPathsFrom(a);
            Assert.AreEqual("source is a. to a= 0, to b= 1, to c= 2, to d= 4",
                DistancesFormating(g, a));
        }

        /*      10         2         7
               -----> B -------> D >>>>>>+
              /       | ^       ^  ^     |
             À       1|  \   8 /    \9   | 
              \       |  4\   /      \   |
            3  \      |    \ /        \  |  
                ------+-->  C ---------> E
                                2
        */
        [Test]
        public void GraphFromYouTubeLecture()
        {
            var g = new Graph();
            var a = g.AddNode("a");
            var b = g.AddNode("b");
            var c = g.AddNode("c");
            var d = g.AddNode("d");
            var e = g.AddNode("e");
            g.AddEdge(a, b, 10);
            g.AddEdge(a, c, 3);
            g.AddEdge(b, d, 2);
            g.AddEdge(b, c, 1);
            g.AddEdge(c, b, 4);
            g.AddEdge(c, d, 8); 
            g.AddEdge(c, e, 2);
            g.AddEdge(d, e, 7);
            g.AddEdge(e, d, 9);

            g.FindDijkstraShortestPathsFrom(a);
            Assert.AreEqual
                ("source is a. to a= 0, to b= 7, to c= 3, to d= 9, to e= 5",
                DistancesFormating(g, a));
            Assert.AreEqual("a -> c -> b", PathFormating(g, a, b));
        }

        private string PathFormating(Graph graph, DijkstraNode source, DijkstraNode destination)
        {
            var pathNodes = new Stack<string>();
            var currentNode = destination;

            while(currentNode != null)      // it would be null if currentNode is source
            {
                pathNodes.Push(currentNode.Name);
                currentNode = currentNode.Prev;
            }

            return string.Join(" -> ", pathNodes);
        }

        private static string DistancesFormating(Graph graph, DijkstraNode source)
        {
            var nodes = graph.AdjDict.GetVertices();
            var distances = nodes.Select(node => $"to {node.Name}= {node.Distance}");
            string formattedDistances = string.Join(", ", distances);
            return $"source is {source.Name}. {formattedDistances}";
        }
    }
}