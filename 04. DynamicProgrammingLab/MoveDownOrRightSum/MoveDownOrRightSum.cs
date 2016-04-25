namespace MoveDownOrRightSum
{
    using System;
    using System.Collections.Generic;

    public class MoveDownOrRightSum
    {
        public static void Main(string[] args)
        {
            int[,] cell = new int[,]
            {
                { 2, 6, 1, 8, 9, 4, 2 },
                { 1, 8, 0, 3, 5, 6, 7 },
                { 3, 4, 8, 7, 2, 1, 8 },
                { 0, 9, 2, 8, 1, 7, 9 },
                { 2, 7, 1, 9, 7, 8, 2 },
                { 4, 5, 6, 1, 2, 5, 6 },
                { 9, 3, 5, 2, 8, 1, 9 },
                { 2, 3, 4, 1, 7, 2, 8 },
            };

            int[,] sums = new int[cell.GetLength(0), cell.GetLength(1)];
            sums[0, 0] = cell[0, 0];
            for (int c = 1; c < cell.GetLength(1); c++)
            {
                sums[0, c] = sums[0, c - 1] + cell[0, c];
            }
            for (int r = 1; r < cell.GetLength(0); r++)
            {
                sums[r, 0] = sums[r - 1, 0] + cell[r, 0];
            }

            for (int r = 1; r < cell.GetLength(0); r++)
            {
                for (int c = 1; c < cell.GetLength(1); c++)
                {
                    sums[r, c] = cell[r, c] + Math.Max(sums[r - 1, c], sums[r, c - 1]);
                }
            }

            HashSet<Tuple<int, int>> maxCells = new HashSet<Tuple<int, int>>();
            maxCells.Add(new Tuple<int, int>(cell.GetLength(0) - 1, cell.GetLength(1) - 1));

            int row = cell.GetLength(0) - 1;
            int col = cell.GetLength(1) - 1;

            while (row > 0 && col > 0)
            {
                if (sums[row - 1, col] > sums[row, col - 1])
                {
                    row--;
                    maxCells.Add(new Tuple<int, int>(row, col));
                }
                else
                {
                    col--;
                    maxCells.Add(new Tuple<int, int>(row, col));
                }
            }

            while (row > 0)
            {
                row--;
                maxCells.Add(new Tuple<int, int>(row , col));
            }

            while (col > 0)
            {
                col--;
                maxCells.Add(new Tuple<int, int>(row, col));
            }

            PrintMatrix(sums, maxCells);
        }

        private static void PrintMatrix(int[,] matrix, HashSet<Tuple<int, int>> path)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    var current = new Tuple<int, int>(row, col);
                    if (path.Contains(current))
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("{0,3}", matrix[row, col]);
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        Console.Write("{0,3}", matrix[row, col]);
                    }
                    
                }
                Console.WriteLine();
            }
        }
    }
}
