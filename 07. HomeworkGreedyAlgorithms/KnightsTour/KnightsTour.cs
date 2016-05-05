namespace KnightsTour
{
    using System;

    public class KnightsTour
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] path = new int[n, n];
            bool[,] visited = new bool[n, n];
            int[,] posibleSteps = new int[n, n];

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int steps = CheckStepsCount(row, col, n);
                    posibleSteps[row, col] = steps;
                }
            }

            int count = 1;
            int currentRow = 0;
            int currentCol = 0;

            while (count <= n * n)
            {
                visited[currentRow, currentCol] = true;
                path[currentRow, currentCol] = count;
                count++;
                int minSteps = int.MaxValue;
                int minRow = -1;
                int minCol = -1;

                // right
                if (IsInRange(currentRow + 1, currentCol + 2, n) && !visited[currentRow + 1, currentCol + 2])
                {
                    posibleSteps[currentRow + 1, currentCol + 2]--;
                    if (posibleSteps[currentRow + 1, currentCol + 2] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow + 1, currentCol + 2];
                        minRow = currentRow + 1;
                        minCol = currentCol + 2;
                    }
                }
                if (IsInRange(currentRow - 1, currentCol + 2, n) && !visited[currentRow - 1, currentCol + 2])
                {
                    posibleSteps[currentRow - 1, currentCol + 2]--;
                    if (posibleSteps[currentRow - 1, currentCol + 2] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow - 1, currentCol + 2];
                        minRow = currentRow - 1;
                        minCol = currentCol + 2;
                    }
                }

                // left
                if (IsInRange(currentRow + 1, currentCol - 2, n) && !visited[currentRow + 1, currentCol - 2])
                {
                    posibleSteps[currentRow + 1, currentCol - 2]--;
                    if (posibleSteps[currentRow + 1, currentCol - 2] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow + 1, currentCol - 2];
                        minRow = currentRow + 1;
                        minCol = currentCol - 2;
                    }
                }
                if (IsInRange(currentRow - 1, currentCol - 2, n) && !visited[currentRow - 1, currentCol - 2])
                {
                    posibleSteps[currentRow - 1, currentCol - 2]--;
                    if (posibleSteps[currentRow - 1, currentCol - 2] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow - 1, currentCol - 2];
                        minRow = currentRow - 1;
                        minCol = currentCol - 2;
                    }
                }

                // down
                if (IsInRange(currentRow + 2, currentCol + 1, n) && !visited[currentRow + 2, currentCol + 1])
                {
                    posibleSteps[currentRow + 2, currentCol + 1]--;
                    if (posibleSteps[currentRow + 2, currentCol + 1] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow + 2, currentCol + 1];
                        minRow = currentRow + 2;
                        minCol = currentCol + 1;
                    }
                }
                if (IsInRange(currentRow + 2, currentCol - 1, n) && !visited[currentRow + 2, currentCol - 1])
                {
                    posibleSteps[currentRow + 2, currentCol - 1]--;
                    if (posibleSteps[currentRow + 2, currentCol - 1] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow + 2, currentCol - 1];
                        minRow = currentRow + 2;
                        minCol = currentCol - 1;
                    }
                }

                // up
                if (IsInRange(currentRow - 2, currentCol + 1, n) && !visited[currentRow - 2, currentCol + 1])
                {
                    posibleSteps[currentRow - 2, currentCol + 1]--;
                    if (posibleSteps[currentRow - 2, currentCol + 1] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow - 2, currentCol + 1];
                        minRow = currentRow - 2;
                        minCol = currentCol + 1;
                    }
                }
                if (IsInRange(currentRow - 2, currentCol - 1, n) && !visited[currentRow - 2, currentCol - 1])
                {
                    posibleSteps[currentRow - 2, currentCol - 1]--;
                    if (posibleSteps[currentRow - 2, currentCol - 1] < minSteps)
                    {
                        minSteps = posibleSteps[currentRow - 2, currentCol - 1];
                        minRow = currentRow - 2;
                        minCol = currentCol - 1;
                    }
                }

                currentRow = minRow;
                currentCol = minCol;
            }

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    Console.Write("{0, 4}", path[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static int CheckStepsCount(int row, int col, int n)
        {
            int count = 0;

            // up
            if (IsInRange(row - 2, col - 1, n))
            {
                count++;
            }
            if (IsInRange(row - 2, col + 1, n))
            {
                count++;
            }

            // right
            if (IsInRange(row - 1, col + 2, n))
            {
                count++;
            }
            if (IsInRange(row + 1, col + 2, n))
            {
                count++;
            }

            // down
            if (IsInRange(row + 2, col - 1, n))
            {
                count++;
            }
            if (IsInRange(row + 2, col + 1, n))
            {
                count++;
            }

            // left
            if (IsInRange(row - 1, col - 2, n))
            {
                count++;
            }
            if (IsInRange(row + 1, col - 2, n))
            {
                count++;
            }

            return count;
        }

        private static bool IsInRange(int row, int col, int n)
        {
            return row >= 0 && row < n && col >= 0 && col < n;
        }
    }
}
