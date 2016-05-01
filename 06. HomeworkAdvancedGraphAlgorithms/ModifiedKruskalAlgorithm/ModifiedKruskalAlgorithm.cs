namespace ModifiedKruskalAlgorithm
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ModifiedKruskalAlgorithm
    {
        public static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int edgeCount = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

            List<Edge> edges = new List<Edge>();
            var nodes = new Dictionary<int, Node>();
 
            for (int i = 0; i < edgeCount; i++)
            {
                int[] edgeArgs =
                    Console.ReadLine()
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                edges.Add(new Edge(edgeArgs[0], edgeArgs[1], edgeArgs[2]));
                if (!nodes.ContainsKey(edgeArgs[0]))
                {
                    nodes.Add(edgeArgs[0], new Node(edgeArgs[0]));
                }
                if (!nodes.ContainsKey(edgeArgs[1]))
                {
                    nodes.Add(edgeArgs[1], new Node(edgeArgs[1]));
                }
            }

            var minimumSpanningForest = KruskalAlgorithm.Kruskal(nodes, edges);
            Console.WriteLine("Minimum spanning forest weight: {0}", minimumSpanningForest.Sum(e => e.Weight));

            foreach (var edge in minimumSpanningForest)
            {
                Console.WriteLine(edge);
            }
        }
    }
}
