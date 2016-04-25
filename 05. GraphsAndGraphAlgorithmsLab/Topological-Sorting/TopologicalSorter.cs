using System;
using System.Collections.Generic;
using System.Linq;
using Topological_Sorting_DFS;

public class TopologicalSorter
{
    private Dictionary<string, List<string>> graph;

    public TopologicalSorter(Dictionary<string, List<string>> graph)
    {
        this.graph = graph;
    }

    public ICollection<string> TopSort()
    {
        var predecessorsCount = new Dictionary<string, int>();
        foreach (var node in this.graph)
        {
            if (!predecessorsCount.ContainsKey(node.Key))
            {
                predecessorsCount[node.Key] = 0;
            }
            foreach (var childNode in node.Value)
            {
                if (!predecessorsCount.ContainsKey(childNode))
                {
                    predecessorsCount[childNode] = 0;
                }

                predecessorsCount[childNode]++;
            }
        }

        var removedNodes = new List<string>();
        while (true)
        {
            var currentNode = this.graph.Keys.FirstOrDefault(e => predecessorsCount[e] == 0);
            if (currentNode == null)
            {
                break;
            }
            
            foreach (var child in this.graph[currentNode])
            {
                predecessorsCount[child]--;
            }

            removedNodes.Add(currentNode);
            this.graph.Remove(currentNode);
        }
        if (this.graph.Count > 0)
        {
            throw new InvalidOperationException("A cycle detected in a graph");
        }
        return removedNodes;
    }
}
