namespace AreasInMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class AreasInMatrix
    {
        private static char[][] matrix;

        public static void Main(string[] args)
        {
            string input = Console.ReadLine().Split().Last();
            int rows = int.Parse(input);
            matrix = new char[rows][];
            for (int row = 0; row < rows; row++)
            {
                matrix[row] = Console.ReadLine().ToCharArray();
            }

            SortedDictionary<char, int> areas = new SortedDictionary<char, int>();

            while (true)
            {
                var cell = FindNextCell();
                if (cell == null)
                {
                    break;
                }
                Queue<Cell> cells = new Queue<Cell>();
                cells.Enqueue(cell);
                char currentChar = matrix[cell.Row][cell.Col];
                while (cells.Count > 0)
                {
                    var currentCell = cells.Dequeue();
                    matrix[currentCell.Row][currentCell.Col] = ' ';

                    if (IsInRange(currentCell.Row - 1, currentCell.Col) && matrix[currentCell.Row - 1][currentCell.Col] == currentChar)
                    {
                        cells.Enqueue(new Cell(currentCell.Row - 1, currentCell.Col));
                    }
                    if (IsInRange(currentCell.Row, currentCell.Col + 1) && matrix[currentCell.Row][currentCell.Col + 1] == currentChar)
                    {
                        cells.Enqueue(new Cell(currentCell.Row, currentCell.Col + 1));
                    }
                    if (IsInRange(currentCell.Row + 1, currentCell.Col) && matrix[currentCell.Row + 1][currentCell.Col] == currentChar)
                    {
                        cells.Enqueue(new Cell(currentCell.Row + 1, currentCell.Col));
                    }
                    if (IsInRange(currentCell.Row, currentCell.Col - 1) && matrix[currentCell.Row][currentCell.Col - 1] == currentChar)
                    {
                        cells.Enqueue(new Cell(currentCell.Row, currentCell.Col - 1));
                    }
                }

                if (!areas.ContainsKey(currentChar))
                {
                    areas[currentChar] = 0;
                }
                areas[currentChar]++;
            }

            Console.WriteLine("Areas: {0}", areas.Values.Sum());
            foreach (var area in areas)
            {
                Console.WriteLine("Letter \'{0}\' -> {1}", area.Key, area.Value);
            }
        }

        private static bool IsInRange(int row, int col)
        {
            return row >= 0 && row < matrix.Length && col >= 0 && col < matrix[row].Length;
        }

        private static Cell FindNextCell()
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    if (matrix[row][col] != ' ')
                    {
                        return new Cell(row, col);
                    }
                }
            }

            return null;
        }
    }
}
