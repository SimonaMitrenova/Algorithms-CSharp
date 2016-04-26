namespace BreakCycles
{
    using System;
    public class Edge : IComparable<Edge>
    {
        public Edge(string start, string end)
        {
            this.Start = start;
            this.End = end;
        }

        public string Start { get; set; }

        public string End { get; set; }

        public int CompareTo(Edge other)
        {
            int comparer = string.Compare(this.Start, other.Start, StringComparison.Ordinal);
            if (comparer == 0)
            {
                comparer = string.Compare(this.End, other.End, StringComparison.Ordinal);
            }

            return comparer;
        }

        public override string ToString()
        {
            return string.Format($"{this.Start} - {this.End}");
        }
    }
}
