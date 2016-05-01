namespace ShortestPathsBetweenAllPairsOfNodes
{
    using System;
    using System.Linq;

    public class ShortestPathsBetweenAllPairsOfNodes
    {
        public static void Main(string[] args)
        {
            int nodes = int.Parse(Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)[1]);
            int edges = int.Parse(Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]);
            int[,] distance = new int[nodes, nodes];
            for (int row = 0; row < nodes; row++)
            {
                for (int col = 0; col < nodes; col++)
                {
                    if (row == col)
                    {
                        continue;
                    }

                    distance[row, col] = 10000;
                }
            }

            for (int i = 0; i < edges; i++)
            {
                int[] edgeParam =
                    Console.ReadLine()
                        .Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                int start = edgeParam[0];
                int end = edgeParam[1];
                int currentDistance = edgeParam[2];

                distance[start, end] = currentDistance;
                distance[end, start] = currentDistance;
            }

            for (int k = 0; k < nodes; k++)
            {
                for (int i = 0; i < nodes; i++)
                {
                    for (int j = 0; j < nodes; j++)
                    {
                        if (distance[i, j] > distance[i, k] + distance[k, j])
                        {
                            distance[i, j] = distance[i, k] + distance[k, j];
                        }
                    }
                }
            }

            Console.WriteLine("Shortest paths matrix:");
            for (int n = 0; n < nodes; n++)
            {
                Console.Write("{0, 3}", n);
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', nodes * 3));
            for (int row = 0; row < distance.GetLength(0); row++)
            {
                for (int col = 0; col < distance.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", distance[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
