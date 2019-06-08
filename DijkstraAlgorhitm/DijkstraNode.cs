using System;
namespace DijkstraAlgorhitm
{
    public class DijkstraNode
    {
        public string Name { get; set; }        
        public int Distance { get; set; }       //from source node
        public DijkstraNode Prev { get; set; }  //previous node of shortest path

        public DijkstraNode(string name, int distance)
        {
            Name = name;
            Distance = distance;
        }
    }
}
