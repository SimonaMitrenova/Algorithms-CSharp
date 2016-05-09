using System;
using System.Linq;

namespace LineInverter
{
    public class LineInverter
    {
        private static int n;
        private static bool[,] matrix;
        private static bool[] visitedRows;
        private static bool[] visitedCols;
        private static int[] maxWhiteInRows;
        private static int[] maxWhiteInCols;

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            matrix = new bool[n, n];
            maxWhiteInRows = new int[n];
            maxWhiteInCols = new int[n];
            for (int row = 0; row < n; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < n; col++)
                {
                    if (line[col] == 'W')
                    {
                        matrix[row, col] = true;
                        maxWhiteInRows[row]++;
                        maxWhiteInCols[col]++;
                    }
                }
            }

            visitedRows = new bool[n];
            visitedCols = new bool[n];
            int count = 0;
            bool solutionFound = false;

            for (int i = 0; i < 2 * n; i++)
            {
                int maxWhiteRow = maxWhiteInRows.Max();
                int maxWhiteCol = maxWhiteInCols.Max();
                if (maxWhiteRow == 0 || maxWhiteCol == 0)
                {
                    solutionFound = true;
                    break;
                }

                if (maxWhiteRow >= maxWhiteCol)
                {
                    InvertRow(maxWhiteRow);
                }
                else
                {
                    InvertCol(maxWhiteCol);
                }
                count++;
            }

            if (solutionFound)
            {
                Console.WriteLine(count);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }

        private static void InvertCol(int max)
        {
            int col = maxWhiteInCols.ToList().IndexOf(max);
            if (visitedCols[col])
            {
                return;
            }
            visitedCols[col] = true;
            for (int row = 0; row < n; row++)
            {
                if (matrix[row, col])
                {
                    maxWhiteInRows[row]--;
                }
                else
                {
                    maxWhiteInRows[row]++;
                }

                matrix[row, col] = !matrix[row, col];
            }
            maxWhiteInCols[col] = n - maxWhiteInCols[col];
        }

        private static void InvertRow(int max)
        {
            int row = maxWhiteInRows.ToList().IndexOf(max);
            if (visitedRows[row])
            {
                return;
            }
            visitedRows[row] = true;
            for (int col = 0; col < n; col++)
            {
                if (matrix[row, col])
                {
                    maxWhiteInCols[col]--;
                }
                else
                {
                    maxWhiteInCols[col]++;
                }

                matrix[row, col] = !matrix[row, col];
            }
            maxWhiteInRows[row] = n - maxWhiteInRows[row];
        }
    }
}
