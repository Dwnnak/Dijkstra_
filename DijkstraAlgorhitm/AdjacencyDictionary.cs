using System;
using System.Collections;
using System.Collections.Generic;

namespace DijkstraAlgorhitm
{
    /// <summary>
    /// mathes every node to adjacent nodes with edges weights to them.
    /// For example from node U to V1, V2, ..., Vn 
    /// with edges weights (from U to V1, V2, ..., Vn)
    /// </summary>
    public class AdjacencyDictionary
    {
        /// <summary>
        /// keys is nodes of graph it mathes to
        /// values which are lists of all adjacent nodes with weights to them
        /// </summary>
        private Dictionary<DijkstraNode, List<(DijkstraNode node, int weight)>> AdjDictionary
        { get; set; }

        public AdjacencyDictionary()
        {
            AdjDictionary = new 
                Dictionary<DijkstraNode, List<(DijkstraNode node, int weight)>>();
        }

        public DijkstraNode AddNode(string name)
        {
            var newNode = new DijkstraNode(name);
            AdjDictionary.Add(newNode, new List<(DijkstraNode node, int weight)>());
            return newNode;
        }

        public void AddEdge(DijkstraNode source, DijkstraNode destination, int weight)
        {
            AdjDictionary[source].Add((destination, weight));
        }

        /// <summary>
        /// Get all the keys that are the vertices of the graph
        /// </summary>
        /// <returns></returns>
        public Dictionary<DijkstraNode, List<(DijkstraNode, int)>>.KeyCollection GetVertices()
        {
            return AdjDictionary.Keys;
        }

        /// <summary>
        /// Get List of adjacent nodes with edges weights to them
        /// </summary>
        /// <param the node the list of which we want to get ="node"></param>
        /// <returns></returns>
        public List<(DijkstraNode node, int weight)> this[DijkstraNode node]
        {
            get
            {
                return AdjDictionary[node];
            }
        }
    }
}
