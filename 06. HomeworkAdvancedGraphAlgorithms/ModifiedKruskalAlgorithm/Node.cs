namespace ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;

    public class Node
    {
        public Node(int id)
        {
            this.Id = id;
            this.Parent = id;
            this.Children = new HashSet<int>();
        }

        public int Id { get; set; }

        public int Parent { get; set; }

        public HashSet<int> Children { get; set; }
    }
}
