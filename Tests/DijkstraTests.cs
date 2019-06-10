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
                GetShortestPathsAsString(g, a));
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
                GetShortestPathsAsString(g, a));
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
            var graph = new Graph();
            var a = graph.AddNode("a");
            var b = graph.AddNode("b");
            var c = graph.AddNode("c");
            var d = graph.AddNode("d");
            var e = graph.AddNode("e");

            graph.AddEdge(a, b, 10);
            graph.AddEdge(a, c, 3);
            graph.AddEdge(b, d, 2);
            graph.AddEdge(b, c, 1);
            graph.AddEdge(c, b, 4);
            graph.AddEdge(c, d, 8);
            graph.AddEdge(c, e, 2);
            graph.AddEdge(d, e, 7);
            graph.AddEdge(e, d, 9);

            graph.FindDijkstraShortestPathsFrom(a);
            Assert.AreEqual
                ("source is a. to a= 0, to b= 7, to c= 3, to d= 9, to e= 5",
                GetShortestPathsAsString(graph, a));
            Assert.AreEqual("a -> c -> b", GetPathAsString(graph, a, b));
        }

        [Test]
        public void PreviousGraphWithBackwardVerices()
        {
            var graph = new Graph();
            var e = graph.AddNode("e");
            var d = graph.AddNode("d");
            var c = graph.AddNode("c");
            var b = graph.AddNode("b");
            var a = graph.AddNode("a");

            graph.AddEdge(a, b, 10);
            graph.AddEdge(a, c, 3);
            graph.AddEdge(b, d, 2);
            graph.AddEdge(b, c, 1);
            graph.AddEdge(c, b, 4);
            graph.AddEdge(c, d, 8);
            graph.AddEdge(c, e, 2);
            graph.AddEdge(d, e, 7);
            graph.AddEdge(e, d, 9);

            graph.FindDijkstraShortestPathsFrom(a);
            Assert.AreEqual
                ("source is a. to e= 5, to d= 9, to c= 3, to b= 7, to a= 0",
                GetShortestPathsAsString(graph, a));
            Assert.AreEqual("c -> b -> d", GetPathAsString(graph, c, d));
        }

        private string GetPathAsString(Graph graph, DijkstraNode source, DijkstraNode destination)
        {
            var pathNodes = new Stack<string>();
            var currentNode = destination;

            while (currentNode != null && !currentNode.Equals(source.Prev))      // it would be null if currentNode is source
            {
                pathNodes.Push(currentNode.Name);
                currentNode = currentNode.Prev;
            }

            return string.Join(" -> ", pathNodes);
        }

        private static string GetShortestPathsAsString(Graph graph, DijkstraNode source)
        {
            var nodes = graph.AdjDict.GetVertices();
            var distances = nodes.Select(node => $"to {node.Name}= {node.Distance}");
            string formattedDistances = string.Join(", ", distances);
            return $"source is {source.Name}. {formattedDistances}";
        }
    }
}