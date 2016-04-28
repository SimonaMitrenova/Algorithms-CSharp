namespace DijkstraPriorityQueue
{
    using System.Collections.Generic;

    public class Dijkstra
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
            var priorityQueue = new PriorityQueue<Node>();
           
            priorityQueue.Insert(new Node(sourceNode, 0));
            while (priorityQueue.Count > 0)
            {
                var minNode = priorityQueue.ExtractMin();
                if (minNode.Distance == int.MaxValue)
                {
                    break;
                }
                visited[minNode.Name] = true;

                for (int node = 0; node < n; node++)
                {
                    if (graph[minNode.Name, node] > 0)
                    {
                        if (!visited[node])
                        {
                            int distanseToNode = minNode.Distance + graph[minNode.Name, node];
                            if (distanseToNode < distance[node])
                            {
                                priorityQueue.Insert(new Node(node, distanseToNode));
                                distance[node] = distanseToNode;
                                previous[node] = minNode.Name;
                            }
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
