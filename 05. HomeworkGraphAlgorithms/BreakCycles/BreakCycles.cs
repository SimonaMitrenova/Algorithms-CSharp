namespace BreakCycles
{
    using System;
    using System.Collections.Generic;

    public class BreakCycles
    {
        private static Dictionary<string, List<string>> graph;
        private static List<Edge> edges;
        private static List<Edge> edgesToRemove;
        private static HashSet<string> visited;
        private static bool isCyclic;

        public static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            edges = new List<Edge>();
            edgesToRemove = new List<Edge>();

            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                string[] arguments = input.Split(new[] {'-', '>'}, StringSplitOptions.RemoveEmptyEntries);
                string parent = arguments[0].Trim();
                string[] nodes = arguments[1].Trim().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);

                if (!graph.ContainsKey(parent))
                {
                    graph[parent] = new List<string>();
                }
                foreach (var node in nodes)
                {
                    if (!graph.ContainsKey(node))
                    {
                        graph[node] = new List<string>();
                    }

                    graph[parent].Add(node);
                    edges.Add(new Edge(parent, node));
                }
            }

            edges.Sort();
            foreach (var edge in edges)
            {
                if (!graph[edge.Start].Contains(edge.End) || !graph[edge.End].Contains(edge.Start))
                {
                    continue;
                }

                graph[edge.Start].Remove(edge.End);
                graph[edge.End].Remove(edge.Start);

                visited = new HashSet<string>();
                isCyclic = false;
                TraverseGraph(edge.Start, edge.End);
                if (isCyclic)
                {
                    edgesToRemove.Add(edge);
                }
                else
                {
                    graph[edge.Start].Add(edge.End);
                    graph[edge.End].Add(edge.Start);
                }
            }

            Console.WriteLine($"Edges to remove: {edgesToRemove.Count}");
            foreach (var edge in edgesToRemove)
            {
                Console.WriteLine(edge);
            }
        }

        private static void TraverseGraph(string start, string end)
        {
            if (visited.Contains(start))
            {
                return;
            }
            if (start == end)
            {
                isCyclic = true;
                return;
            }
            visited.Add(start);
            foreach (var child in graph[start])
            {
                TraverseGraph(child, end);
            }
        }
    }
}
