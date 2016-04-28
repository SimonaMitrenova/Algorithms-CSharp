namespace Prim
{
    using System.Collections.Generic;

    public class PrimAlgorithm
    {
        private static HashSet<int> visited;
        private static List<Edge> spanningTree;

        public static List<Edge> Prim(List<Edge> edges)
        {
            Dictionary<int, List<Edge>> vertices = BuildGraph(edges);
            visited = new HashSet<int>();
            spanningTree = new List<Edge>();

            foreach (var vertex in vertices.Keys)
            {
                if (!visited.Contains(vertex))
                {
                    FindPrim(vertex, vertices);
                }
            }

            return spanningTree;
        }

        private static void FindPrim(int vertex, Dictionary<int, List<Edge>> vertices)
        {
            visited.Add(vertex);
            var priorityQueue = new PriorityQueue<Edge>(vertices[vertex]);
            while (priorityQueue.Count > 0)
            {
                var smallestEdge = priorityQueue.ExtractMin();
                if (visited.Contains(smallestEdge.StartNode) ^ visited.Contains(smallestEdge.EndNode))
                {
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
