namespace PathsBetweenCellsInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class PathsBetweenCellsInMatrix
    {
        private static char[,] firstMatrix = new char[,]
        {
            { 's', ' ', ' ', ' '},
            { ' ', '*', '*', ' '},
            { ' ', '*', '*', ' '},
            { ' ', '*', 'e', ' '},
            { ' ', ' ', ' ', ' '}
        };

        private static char[,] secondMatrix = new char[,]
        {
            { 's', ' ', ' ', ' ', ' ', ' '},
            { ' ', '*', '*', ' ', '*', ' '},
            { ' ', '*', '*', ' ', '*', ' '},
            { ' ', '*', 'e', ' ', ' ', ' '},
            { ' ', ' ', ' ', '*', ' ', ' '},
        };

        private static List<char> currentPath = new List<char>();
        private static int totalPathsFound = 0;

        public static void Main(string[] args)
        {
            FindPathsRecursive(firstMatrix, 0, 0, 'S');
            Console.WriteLine($"Total paths found: {totalPathsFound}");
        }

        private static void FindPathsRecursive(char[,] matrix, int row, int col, char direction)
        {
            if (!IsInRange(row, col, matrix))
            {
                return;
            }

            currentPath.Add(direction);

            if (matrix[row, col] == 'e')
            {
                totalPathsFound++;
                PrintPath();
            }

            if (matrix[row, col] == ' ' || matrix[row, col] == 's')
            {
                matrix[row, col] = '.';

                FindPathsRecursive(matrix, row, col - 1, 'L');
                FindPathsRecursive(matrix, row - 1, col, 'U');
                FindPathsRecursive(matrix, row, col + 1, 'R');
                FindPathsRecursive(matrix, row + 1, col, 'D');

                matrix[row, col] = ' ';
            }

            currentPath.RemoveAt(currentPath.Count - 1);
        }

        private static void PrintPath()
        {
            Console.WriteLine(string.Join(" ", currentPath.Skip(1)));
        }

        private static bool IsInRange(int row, int col, char[,] matrix)
        {
            if ((row < 0) || (col < 0) || (row >= matrix.GetLength(0)) || (col >= matrix.GetLength(1)))
            {
                return false;
            }

            return true;
        }
    }
}
