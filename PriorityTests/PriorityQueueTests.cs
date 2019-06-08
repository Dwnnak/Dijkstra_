using DijkstraAlgorhitm;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace PriorityTests
{
    [TestClass]
    public class PriorityQueueTests
    {
        PQElement<string>[] elements = {
                new PQElement<string>("a", 10),
                new PQElement<string>("b", 9),
                new PQElement<string>("c", 8),
                new PQElement<string>("d", 7),
                new PQElement<string>("e", 6),
                new PQElement<string>("f", 5),
                new PQElement<string>("g", 4),
                new PQElement<string>("h", 3),
                new PQElement<string>("i", 2),
                new PQElement<string>("j", 1)
            };


        [TestMethod]
        public void TreeIsCorrect()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>(elements);
            bool flag = true;
            for (int i = 0; i < queue.Size; i++)
            {
                if ((i + 1) * 2 < queue.Size && i * 2 + 1 < queue.Size)
                {
                    if (!(queue.tree[i].Priority < queue.tree[(i + 1) * 2].Priority
                      && queue.tree[i].Priority < queue.tree[i * 2 + 1].Priority))
                        flag = false;
                }
            }
            Assert.AreEqual(true, flag);
        }

        [TestMethod]
        public void ExctractMinIsCorrect()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>(elements);
            var a1 = queue.ExtractMin();
            var b1 = new PQElement<string>("j", 1);
            Assert.AreEqual(b1, a1);
        }

        [TestMethod]
        public void GetMinIsCorrect()
        {
            PriorityQueue<string> queue = new PriorityQueue<string>(elements);
            var a = queue.GetMin();
            var b = 1;
            Assert.AreEqual(b, a);
        }

        //[TestMethod]
        //public void InsertIsCorrect()
        //{
        //    PriorityQueue<string> queue = new PriorityQueue<string>(elements);
        //    var a = queue.GetMin();
        //    var b = 1;
        //    Assert.AreEqual(b, a);
        //}
    }
}
