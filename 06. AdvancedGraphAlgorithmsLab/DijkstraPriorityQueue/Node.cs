namespace DijkstraPriorityQueue
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int id, double distance = double.PositiveInfinity)
        {
            this.Id = id;
            this.DistanceFromStart = distance;
        }

        public int Id { get; set; }

        public double DistanceFromStart { get; set; }

        public int CompareTo(Node other)
        {
            return this.DistanceFromStart.CompareTo(other.DistanceFromStart);
        }
    }
}
