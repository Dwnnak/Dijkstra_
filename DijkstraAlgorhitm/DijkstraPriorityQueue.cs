﻿using System;
using System.Collections.Generic;

namespace DijkstraAlgorhitm
{
    /// <summary>
    /// priority queue in which the DijkstraNode is used as a key
    /// </summary>
    public class DijkstraPriorityQueue
    {
        /// <summary>
        /// Stores the tree
        /// </summary>
        public List<(DijkstraNode element, int priority)> tree;

        /// <summary>
        /// Gets the size of priority queue.
        /// </summary>
        /// <value>The size.</value>
        public int Size { get { return tree.Count; } }

        /// <summary>
        /// Get parent of element by index
        /// </summary>
        /// <param name="i"></param>
        /// <returns> returns parent index </returns>
        private int Parent(int i)
        {
            if (i == 0) return 0;
            if (i % 2 == 0)
                return i / 2 - 1;
            return i / 2;
        }

        /// <summary>
        /// returns left child index
        /// </summary>
        private int LeftChild(int i) => i * 2 + 1;

        /// <summary>
        /// returns right child index
        /// </summary>
        private int RightChild(int i) => (i + 1) * 2;

        /// <summary>
        /// Counter for entering order for elements of queue
        /// </summary>
        private int Order { get; set; }

        public DijkstraPriorityQueue()
        {
            tree = new List<(DijkstraNode element, int priority)>();
        }

        /// <summary>
        /// Insert the dijkstra node and priority.
        /// </summary>
        public void Insert(DijkstraNode element, int priority)
        {
            tree.Add((element, priority));
            tree[Size - 1].element.IndexInQueue = Size - 1;
            tree[Size - 1].element.EnterNumber = Order;
            Order++;
            SiftUp(Size - 1);

        }

        /// <summary>
        /// Extracts the dijkstra node and its priority.
        /// </summary>
        public (DijkstraNode node, int priority) ExtractMin()
        {
            var result = tree[0];
            tree[0] = tree[Size - 1];
            tree[0].element.IndexInQueue = 0;
            tree.RemoveAt(Size - 1);
            SiftDown(0);
            return result;
        }

        /// <summary>
        /// Changes the priority.
        /// </summary>
        public void ChangePriority(DijkstraNode element, int priority)
        {
            var index = element.IndexInQueue;
            int oldP = tree[index].priority;
            tree[index] = (tree[index].element, priority);

            if (priority < oldP)
                SiftUp(index);
            else if (priority > oldP)
                SiftDown(index);
        }
        
        /// <summary>
        /// Sifts up the element.
        /// </summary>
        private void SiftUp(int i)
        {
            if (i > 0 && tree[Parent(i)].priority.CompareTo(tree[i].priority) > 0)
            {
                Swap(i, Parent(i));
                SiftUp(Parent(i));
            }
        }

        /// <summary>
        /// Sifts down yhe element.
        /// </summary>
        private void SiftDown(int i)
        {
            var swapIndex = i;

            var leftIndex = LeftChild(i);
            if (leftIndex < Size)
            {
                if (tree[leftIndex].priority < tree[swapIndex].priority ||
                    (tree[leftIndex].priority == tree[swapIndex].priority &&
                    tree[leftIndex].element.EnterNumber < tree[swapIndex].element.EnterNumber))
                    swapIndex = leftIndex;
            }

            var rightIndex = RightChild(i);
            if (rightIndex < Size)
            {
                if (tree[rightIndex].priority < tree[swapIndex].priority ||
                    (tree[rightIndex].priority == tree[swapIndex].priority && 
                    tree[rightIndex].element.EnterNumber < tree[swapIndex].element.EnterNumber))
                    swapIndex = rightIndex;
            }

            if (i != swapIndex)
            {
                Swap(i, swapIndex);
                SiftDown(swapIndex);
            }
        }

        /// <summary>
        /// Swap the 2 dijkstra nodes in queue.
        /// </summary>
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

