using System;

namespace DijkstraAlgorhitm
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityQueue<int> queue = new PriorityQueue<int>(5,1,4,3,8,2,9,8,1,2);
            int a = queue.ExtractMin();
            int b = queue.GetMin();
            int c = queue.ExtractMin();
            queue.Remove(queue.Size - 1);
            queue.Insert(22);
            queue.Insert(3);
            queue.Insert(-2);

            queue.Remove(queue.Size - 1);
            queue.ChangePriority(0, 10);

        }
    }
}
