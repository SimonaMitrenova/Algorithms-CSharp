namespace DijkstraPriorityQueue
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int name, int distance)
        {
            this.Name = name;
            this.Distance = distance;
        }

        public int Name { get; set; }

        public int Distance { get; set; }

        public int CompareTo(Node other)
        {
            return this.Distance.CompareTo(other.Distance);
        }
    }
}
