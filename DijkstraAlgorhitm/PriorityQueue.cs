using System;
using System.Collections.Generic;

namespace DijkstraAlgorhitm
{
    public class PriorityQueue<T>
    {
        public List<PQElement<T>> tree;
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
            tree = new List<PQElement<T>>();
        }

        public PriorityQueue(params PQElement<T>[] values)
        {
            tree = new List<PQElement<T>>();
            for (int i = 0; i < values.Length; i++)
                Insert(values[i].Element, values[i].Priority);
        }

        public void Insert(T element, int priority)
        {
            PQElement<T> temp = new PQElement<T>(element, priority);
            tree.Add(temp);
            SiftUp(tree.Count - 1);
        }

        public int GetMin()
        {
            return tree[0].Priority;
        }

        public PQElement<T> ExtractMin()
        {
            PQElement<T> result = tree[0];
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

        public void ChangePriority(int i, int p)
        {
            int oldP = tree[i].Priority;
            tree[i].Priority = p;

            if (p.CompareTo(oldP) < 0)
                SiftUp(i);
            else if (p.CompareTo(oldP) > 0)
                SiftDown(i);

        }

        private void SiftUp(int i)
        {
            if (i > 0 && tree[Parent(i)].Priority.CompareTo(tree[i].Priority) > 0)
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
            if (l < size && tree[l].Priority.CompareTo(tree[minIndex].Priority) < 0)
                minIndex = l;

            var r = RightChild(i);
            if (r < size && tree[r].Priority.CompareTo(tree[minIndex].Priority) < 0)
                minIndex = r;

            if (i != minIndex)
            {
                Swap(i, minIndex);
                SiftDown(minIndex);
            }
        }

        private void Swap(int i, int j)
        {
            PQElement<T> tempValue = tree[i];
            tree[i] = tree[j];
            tree[j] = tempValue;
        }
    }
}

