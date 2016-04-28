namespace Dijkstra
{
    using System;
    using System.Collections.Generic;

    public static class DijkstraWithoutQueue
    {
        public static List<int> DijkstraAlgorithm(int[,] graph, int sourceNode, int destinationNode)
        {
            int n = graph.GetLength(0);
            int[] distance = new int[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
            }
            distance[sourceNode] = 0;
            var visited = new bool[n];
            int?[] previous = new int?[n];
            while (true)
            {
                var minDistance = int.MaxValue;
                int minNode = 0;
                for (int node = 0; node < n; node++)
                {
                    if (!visited[node] && distance[node] < minDistance)
                    {
                        minDistance = distance[node];
                        minNode = node;
                    }
                }

                if (minDistance == int.MaxValue)
                {
                    break;
                }
                visited[minNode] = true;

                for (int node = 0; node < n; node++)
                {
                    if (graph[minNode, node] > 0)
                    {
                        int distanseToNode = minDistance + graph[minNode, node];
                        if (distanseToNode < distance[node])
                        {
                            distance[node] = distanseToNode;
                            previous[node] = minNode;
                        }
                    }
                }
            }

            if (distance[destinationNode] == int.MaxValue)
            {
                return null;
            }

            var path = new List<int>();
            int? currentNode = destinationNode;
            while (currentNode != null)
            {
                path.Add(currentNode.Value);
                currentNode = previous[currentNode.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
