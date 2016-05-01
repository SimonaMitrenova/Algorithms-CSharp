namespace MostReliablePath
{
    using System.Collections.Generic;

    public class Dijkstra
    {
        public static List<int> DijkstraAlgorithm(Dictionary<Node, Dictionary<Node, double>> graph, Node sourceNode, Node destinationNode)
        {
            int?[] previous = new int?[graph.Count];
            bool[] visited = new bool[graph.Count];
            var priorityQueue = new PriorityQueue<Node>();
            sourceNode.ReliabilityCoefficient = 1;
            visited[sourceNode.Id] = true;
            priorityQueue.Enqueue(sourceNode);

            while (priorityQueue.Count > 0)
            {
                var currentNode = priorityQueue.ExtractMax();
                if (currentNode.Id == destinationNode.Id)
                {
                    break;
                }

                foreach (var edge in graph[currentNode])
                {
                    if (!visited[edge.Key.Id])
                    {
                        priorityQueue.Enqueue(edge.Key);
                        visited[edge.Key.Id] = true;
                    }
                    double reliability = currentNode.ReliabilityCoefficient * edge.Value;
                    if (reliability > edge.Key.ReliabilityCoefficient)
                    {
                        edge.Key.ReliabilityCoefficient = reliability;
                        previous[edge.Key.Id] = currentNode.Id;
                        priorityQueue.DecreaseKey(edge.Key);
                    }
                }
            }

            if (double.IsNegativeInfinity(destinationNode.ReliabilityCoefficient))
            {
                return null;
            }
            
            List<int> path = new List<int>();
            int? current = destinationNode.Id;
            while (current != null)
            {
                path.Add(current.Value);
                current = previous[current.Value];
            }

            path.Reverse();
            return path;
        }
    }
}
