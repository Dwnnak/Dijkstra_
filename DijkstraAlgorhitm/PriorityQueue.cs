using System;
using System.Collections.Generic;

namespace DijkstraAlgorhitm
{
    public class PriorityQueue<T>
         where T : IComparable
    {
        private List<T> tree;
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
            tree = new List<T>();
        }

        public PriorityQueue(params T[] values)
        {
            tree = new List<T>();
            for (int i = 0; i < values.Length; i++)
                Insert(values[i]);
        }

        public void Insert(T element)
        {
            tree.Add(element);
            SiftUp(tree.Count - 1);
        }

        public T GetMin()
        {
            return tree[0];
        }

        public T ExtractMin()
        {
            T result = tree[0];
            tree[0] = tree[tree.Count - 1];
            tree.RemoveAt(tree.Count - 1);
            SiftDown(0);
            return result;
        }

        public void Remove(int i)
        {
            tree[i] = tree[0];
            SiftUp(i);
            ExtractMin();
        }

        public void ChangePriority(int i, T p)
        {
            T oldP = tree[i];
            tree[i] = p;

            if (p.CompareTo(oldP) < 0)
                SiftUp(i);
            else if (p.CompareTo(oldP) > 0)
                SiftDown(i);

        }

        private void SiftUp(int i)
        {
            if (i > 0 && tree[Parent(i)].CompareTo(tree[i]) > 0)
            {
                Swap(i, Parent(i));
                SiftUp(Parent(i));
            }
        }

        private void SiftDown(int i)
        {
            var minIndex = i;
            var size = tree.Count;

            var l = LeftChild(i);
            if (l < size && tree[l].CompareTo(tree[minIndex]) < 0)
                minIndex = l;

            var r = RightChild(i);
            if (r < size && tree[r].CompareTo(tree[minIndex]) < 0)
                minIndex = r;

            if (i != minIndex)
            {
                Swap(i, minIndex);
                SiftDown(minIndex);
            }
        }

        private void Swap(int i, int j)
        {
            T tempValue = tree[i];
            tree[i] = tree[j];
            tree[j] = tempValue;
        }
    }

}

