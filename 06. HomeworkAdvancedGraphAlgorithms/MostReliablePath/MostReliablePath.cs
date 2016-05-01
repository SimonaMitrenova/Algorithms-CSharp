namespace MostReliablePath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MostReliablePath
    {
        public static void Main(string[] args)
        {
            int nodeCount = int.Parse(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1]);
            string[] arguments = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            int source = int.Parse(arguments[1]);
            int destination = int.Parse(arguments[3]);
            int edgeCount = int.Parse(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1]);

            var nodes = new Dictionary<int, Node>();
            var graph = new Dictionary<Node, Dictionary<Node, double>>();

            for (int i = 0; i < edgeCount; i++)
            {
                int[] input =
                    Console.ReadLine()
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();

                int start = input[0];
                int end = input[1];
                double reliability = input[2] / 100d;

                if (!nodes.ContainsKey(start))
                {
                    var startNode = new Node(start);
                    nodes.Add(start, startNode);
                    graph.Add(startNode, new Dictionary<Node, double>());
                }
                if (!nodes.ContainsKey(end))
                {
                    var endNode = new Node(end);
                    nodes.Add(end, endNode);
                    graph.Add(endNode, new Dictionary<Node, double>());
                }
                var sourceNode = nodes[start];
                var destNode = nodes[end];
                graph[sourceNode].Add(destNode, reliability);
                graph[destNode].Add(sourceNode, reliability);
            }

            var path = Dijkstra.DijkstraAlgorithm(graph, nodes[source], nodes[destination]);

            if (path == null)
            {
                Console.WriteLine("no path");
            }
            else
            {
                Console.WriteLine("Most reliable path reliability: {0:f2}%", nodes[destination].ReliabilityCoefficient * 100);
                Console.WriteLine(string.Join(" -> ", path));
            }
        }
    }
}
