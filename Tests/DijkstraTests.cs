using DijkstraAlgorhitm;
using NUnit.Framework;
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
            var nodes = g.AdjDict.GetVertices();
            var distances = nodes.Select(node => $"to {node.Name}= {node.Distance}");
            string result = string.Join(", ", distances);
            var paths = $"source is a. {result}";
            Assert.AreEqual("source is a. to a= 0, to b= 1, to c= 5", paths);

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
            var paths = DijkstraResultFormating(g, a);
            Assert.AreEqual("source is a. to a= 0, to b= 1, to c= 2, to d= 4", paths);
        }

        /*      10         2         7
               -----> B -------> D >>>>>>+
           A  /       | ^       ^  ^     |
             \       1|  \   8 /    \9   | 
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
            string paths = DijkstraResultFormating(g, a);
            Assert.AreEqual
                ("source is a. to a= 0, to b= 7, to c= 3, to d= 9, to e= 5", 
                paths);
        }

        private static string DijkstraResultFormating(Graph g, DijkstraNode source)
        {
            var nodes = g.AdjDict.GetVertices();
            var distances = nodes.Select(node => $"to {node.Name}= {node.Distance}");
            string result = string.Join(", ", distances);
            var paths = $"source is {source.Name}. {result}";
            return paths;
        }
    }
}