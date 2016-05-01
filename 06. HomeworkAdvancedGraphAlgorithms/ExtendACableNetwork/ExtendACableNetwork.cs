namespace ExtendACableNetwork
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtendACableNetwork
    {
        public static void Main(string[] args)
        {
            int budget = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int nodes = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int edges = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);

            var graphEdges = new List<Edge>();
            var visitedNodes = new HashSet<int>();

            for (int i = 0; i < edges; i++)
            {
                string[] input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                int startNode = int.Parse(input[0]);
                int endNode = int.Parse(input[1]);
                int weight = int.Parse(input[2]);
                var edge = new Edge(startNode, endNode, weight);
                graphEdges.Add(edge);
                if (input.Length > 3)
                {
                    visitedNodes.Add(startNode);
                    visitedNodes.Add(endNode);
                }
            }

            var connections = PrimAlgorithm.Prim(graphEdges, visitedNodes, budget);
            foreach (var connection in connections)
            {
                Console.WriteLine(connection);
            }
            Console.WriteLine("Budget used: {0}", connections.Select(c => c.Weight).Sum());
        }
    }
}
