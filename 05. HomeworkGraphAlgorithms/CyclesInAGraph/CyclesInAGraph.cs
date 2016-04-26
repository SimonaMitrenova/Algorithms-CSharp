namespace CyclesInAGraph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class CyclesInAGraph
    {
        private static Dictionary<string, List<string>> graph;
        private static Dictionary<string, int> predecessorsCount;

        public static void Main(string[] args)
        {
            graph = new Dictionary<string, List<string>>();
            predecessorsCount = new Dictionary<string, int>();
            while (true)
            {
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    break;
                }
                string[] arguments = input.Split(new[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (!graph.ContainsKey(arguments[0]))
                {
                    graph[arguments[0]] = new List<string>();
                    predecessorsCount[arguments[0]] = 0;
                }
                if (!graph.ContainsKey(arguments[1]))
                {
                    graph[arguments[1]] = new List<string>();
                    predecessorsCount[arguments[1]] = 0;
                }

                graph[arguments[0]].Add(arguments[1]);
                graph[arguments[1]].Add(arguments[0]);
                predecessorsCount[arguments[0]]++;
                predecessorsCount[arguments[1]]++;
            }
            
            while (true)
            {
                var currentNode = graph.Keys.FirstOrDefault(e => predecessorsCount[e] <= 1);
                if (currentNode == null)
                {
                    break;
                }

                foreach (var child in graph[currentNode])
                {
                    predecessorsCount[child]--;
                }
                
                graph.Remove(currentNode);
            }

            if (graph.Count > 0)
            {
                Console.WriteLine("Acyclic: No");
            }
            else
            {
                Console.WriteLine("Acyclic: Yes");
            }
        }
    }
}
