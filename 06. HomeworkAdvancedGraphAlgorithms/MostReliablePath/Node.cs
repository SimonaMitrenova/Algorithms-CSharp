namespace MostReliablePath
{
    using System;

    public class Node : IComparable<Node>
    {
        public Node(int id, double reliability = double.NegativeInfinity)
        {
            this.Id = id;
            this.ReliabilityCoefficient = reliability;
        }

        public int Id { get; set; }

        public double ReliabilityCoefficient { get; set; }

        public int CompareTo(Node other)
        {
            return this.ReliabilityCoefficient.CompareTo(other.ReliabilityCoefficient);
        }
    }
}
