namespace ExtendACableNetwork
{
    using System.Collections.Generic;

    public class PrimAlgorithm
    {
        private static HashSet<int> visited;
        private static List<Edge> spanningTree;

        public static List<Edge> Prim(List<Edge> edges, HashSet<int> visitedNodes, int budget)
        {
            Dictionary<int, List<Edge>> vertices = BuildGraph(edges);
            visited = new HashSet<int>();
            spanningTree = new List<Edge>();

            foreach (var node in visitedNodes)
            {
                visited.Add(node);
            }
            var priorityQueue = new PriorityQueue<Edge>();
            foreach (var node in visitedNodes)
            {
                foreach (var edge in vertices[node])
                {
                    if (visited.Contains(edge.StartNode) ^ visited.Contains(edge.EndNode))
                    {
                        priorityQueue.Insert(edge);
                    }
                }
            }

            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if (smallestEdge.Weight > budget)
                {
                    break;
                }
                
                if ((visited.Contains(smallestEdge.StartNode) ^ visited.Contains(smallestEdge.EndNode)))
                {
                    budget -= smallestEdge.Weight;
                    spanningTree.Add(smallestEdge);
                    var node = visited.Contains(smallestEdge.StartNode) ? smallestEdge.EndNode : smallestEdge.StartNode;
                    visited.Add(node);
                    foreach (var edge in vertices[node])
                    {
                        if (!(edge.StartNode == smallestEdge.StartNode && edge.EndNode == smallestEdge.EndNode))
                        {
                            priorityQueue.Insert(edge);
                        }
                    }
                }
            }

            return spanningTree;
        }

        static Dictionary<int, List<Edge>> BuildGraph(List<Edge> edges)
        {
            var graph = new Dictionary<int, List<Edge>>();
            foreach (var edge in edges)
            {
                if (!graph.ContainsKey(edge.StartNode))
                {
                    graph.Add(edge.StartNode, new List<Edge>());
                }
                graph[edge.StartNode].Add(edge);

                if (!graph.ContainsKey(edge.EndNode))
                {
                    graph.Add(edge.EndNode, new List<Edge>());
                }
                graph[edge.EndNode].Add(edge);
            }

            return graph;
        }
    }
    
}
