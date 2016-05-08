using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShortestPathInMatrix
{
    public class ShortestPathInMatrix
    {
        public static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int columns = int.Parse(Console.ReadLine());

            int[][] graph = new int[rows][];
            for (int row = 0; row < rows; row++)
            {
                graph[row] = Console.ReadLine().Split().Select(int.Parse).ToArray();
            }

            int[,] minPath = new int[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    minPath[row, col] = int.MaxValue;
                }
            }
            minPath[0, 0] = graph[0][0];
            bool[,] visited = new bool[rows, columns];
            
            while(true)
            {
                int[] currentCell = FindSmallestCell(minPath, visited);

                if (currentCell == null || (currentCell[0] == rows - 1 && currentCell[1] == columns - 1))
                {
                    break;
                }

                int row = currentCell[0];
                int col = currentCell[1];
                visited[row, col] = true;

                // top
                if (IsInRange(row - 1, col, rows, columns) && !visited[row - 1, col] && minPath[row, col] + graph[row - 1][col] < minPath[row - 1, col])
                {
                    minPath[row - 1, col] = minPath[row, col] + graph[row - 1][col];
                }

                // right
                if (IsInRange(row, col + 1, rows, columns) && !visited[row, col + 1] && minPath[row, col] + graph[row][col + 1] < minPath[row, col + 1])
                {
                    minPath[row, col + 1] = minPath[row, col] + graph[row][col + 1];
                }

                // bottom
                if (IsInRange(row + 1, col, rows, columns) && !visited[row + 1, col] && minPath[row, col] + graph[row + 1][col] < minPath[row + 1, col])
                {
                    minPath[row + 1, col] = minPath[row, col] + graph[row + 1][col];
                }

                // left
                if (IsInRange(row, col - 1, rows, columns) && !visited[row, col - 1] && minPath[row, col] + graph[row][col - 1] < minPath[row, col - 1])
                {
                    minPath[row, col - 1] = minPath[row, col] + graph[row][col - 1];
                }
            }

            var path = RecoverMinPath(graph, minPath);
            Console.WriteLine("Length: {0}", path.Sum());
            Console.WriteLine("Path: {0}", string.Join(" ", path));
            
        }

        public static List<int> RecoverMinPath(int[][] graph, int[,] minPath)
        {
            List<int> path = new List<int>();
            int rows = graph.Length;
            int cols = graph[0].Length;
            int currentRow = graph.Length - 1;
            int currentCol = graph[0].Length - 1;
            while(currentRow >= 0 && currentCol >= 0)
            {
                path.Add(graph[currentRow][currentCol]);
                if (currentRow == 0 && currentCol == 0)
                {
                    break;
                }
                int currentSum = minPath[currentRow, currentCol] - graph[currentRow][currentCol];
                if (IsInRange(currentRow - 1, currentCol, rows, cols) && currentSum == minPath[currentRow - 1, currentCol])
                {
                    currentRow--;
                }
                else if (IsInRange(currentRow, currentCol + 1, rows, cols) && currentSum == minPath[currentRow, currentCol + 1])
                {
                    currentCol++;
                }
                else if (IsInRange(currentRow + 1, currentCol, rows, cols) && currentSum == minPath[currentRow + 1, currentCol])
                {
                    currentRow++;
                }
                else if (IsInRange(currentRow, currentCol - 1, rows, cols) && currentSum == minPath[currentRow, currentCol - 1])
                {
                    currentCol--;
                }
            }
            path.Reverse();
            return path;
        }

        public static int[] FindSmallestCell(int[,] matrix, bool[,] visited)
        {
            int min = int.MaxValue;
            int bestRow = -1;
            int bestCol = -1;
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (!visited[row, col] && matrix[row, col] < min)
                    {
                        min = matrix[row, col];
                        bestRow = row;
                        bestCol = col;
                    }
                }
            }

            if (min != int.MaxValue)
            {
                return new int[] { bestRow, bestCol };
            }

            return null;
        }

        public static bool IsInRange(int row, int col, int rows, int cols)
        {
            return row >= 0 && row < rows && col >= 0 && col < cols;
        }
    }
}
