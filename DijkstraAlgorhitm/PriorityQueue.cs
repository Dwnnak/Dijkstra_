using System;
using System.Collections.Generic;

namespace DijkstraAlgorhitm
{
    public class PriorityQueue
    {
        public List<(DijkstraNode element, int priority)> tree;
        public int Size { get { return tree.Count; } }

        private int Parent(int i)
        {
            if (i == 0) return 0;
            if (i % 2 == 0)
                return i / 2 - 1;
            return i / 2;
        }
        private int LeftChild(int i) => i * 2 + 1;
        private int RightChild(int i) => (i + 1) * 2;

        public PriorityQueue()
        {
            tree = new List<(DijkstraNode element, int priority)>();
        }

        /// <summary>
        /// Insert the specified element and priority.
        /// </summary>
        /// <param name="element">Element.</param>
        /// <param name="priority">Priority.</param>
        public void Insert(DijkstraNode element, int priority)
        {
            tree.Add((element, priority));
            tree[Size - 1].element.IndexInQueue = Size - 1;
            SiftUp(Size - 1);
        }

        public int GetMin()
        {
            return tree[0].priority;
        }

        public (DijkstraNode node, int priority) ExtractMin()
        {
            var result = tree[0];
            tree[0] = tree[Size - 1];
            tree[0].element.IndexInQueue = 0;
            tree.RemoveAt(Size - 1);
            SiftDown(0);
            return result;
        }

        public void ChangePriority(DijkstraNode element, int priority)
        {
            var index = element.IndexInQueue;
            int oldP = tree[index].priority;
            tree[index] = (tree[index].element, priority);

            if (priority.CompareTo(oldP) < 0)
                SiftUp(index);
            else if (priority.CompareTo(oldP) > 0)
                SiftDown(index);
        }

        public bool Contains(DijkstraNode element)
        {
            for(int i = 0; i < tree.Count; i++)
            {
                if (tree[i].element.Equals(element))
                    return true;
            }
            return false;
        }


        private void SiftUp(int i)
        {
            if (i > 0 && tree[Parent(i)].priority.CompareTo(tree[i].priority) > 0)
            {
                Swap(i, Parent(i));
                SiftUp(Parent(i));
            }
        }

        private void SiftDown(int i)
        {
            var minIndex = i;

            var l = LeftChild(i);
            if (l < Size && tree[l].priority.CompareTo(tree[minIndex].priority) < 0)
                minIndex = l;

            var r = RightChild(i);
            if (r < Size && tree[r].priority.CompareTo(tree[minIndex].priority) < 0)
                minIndex = r;

            if (i != minIndex)
            {
                Swap(i, minIndex);
                SiftDown(minIndex);
            }
        }

        private void Swap(int i, int j)
        {
            var tempValue = tree[i];
            tree[i] = tree[j];
            tree[j] = tempValue;
            tree[i].element.IndexInQueue = i;
            tree[j].element.IndexInQueue = j;
        }
    }
}

