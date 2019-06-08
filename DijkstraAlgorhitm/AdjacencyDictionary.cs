﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace DijkstraAlgorhitm
{
    public class AdjacencyDictionary 
    {
        /// <summary>
        /// mathes node to adjacent nodes with edges weights to them.
        /// For example from node U to V1, V2, ... Vn 
        /// with edges weights (from U to V1, V2, ... Vn)
        /// </summary>
        public Dictionary<DijkstraNode, List<(DijkstraNode, int)>> AdjDictionary { get; set; }

        public DijkstraNode AddNode(string name)
        {
            var newNode = new DijkstraNode(name);
            AdjDictionary.Add(newNode, null);
            return newNode;
        }

        public void AddEdge(DijkstraNode source, DijkstraNode destination, int weight)
        {
            AdjDictionary[source].Add( (destination, weight) );
        }

        public Dictionary<DijkstraNode, List<(DijkstraNode, int)>>.KeyCollection GetVertices()
        {
            return AdjDictionary.Keys;
        }
    }
}
