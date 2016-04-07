namespace ConnectedAreasInAMatrix
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ConnectedAreasInAMatrix
    {
        private static char[,] firstMatrix = new char[,]
        {
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            { ' ', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ' },
            { ' ', ' ', ' ', ' ', '*', ' ', '*', ' ', ' ' }
        };

        private static char[,] secondMatrix = new char[,]
        {
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', '*', '*', '*', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
            { '*', ' ', ' ', '*', ' ', ' ', ' ', '*', ' ', ' ' },
        };

        private static SortedSet<Area> connectedAreas = new SortedSet<Area>();

        public static void Main(string[] args)
        {
            var startCell = FindFirstEmptyCell(firstMatrix);
            if (startCell == null)
            {
                return;
            }

            var area = new Area(startCell);
            Queue<Cell> cells = new Queue<Cell>();
            cells.Enqueue(startCell);
            FindConnectedAreas(area, cells, firstMatrix);

            Console.WriteLine($"Total areas found: {connectedAreas.Count}");
            int counter = 1;
            foreach (var connectedArea in connectedAreas)
            {
                Console.WriteLine($"Area #{counter} at {connectedArea.StartCell}, size: {connectedArea.Size}");
                counter++;
            }
        }

        private static void FindConnectedAreas(Area area, Queue<Cell> cells, char[,] matrix)
        {
            while (cells.Any())
            {
                var cell = cells.Dequeue();
                if (!IsInRange(cell, matrix))
                {
                    continue;
                }
                if (matrix[cell.Row, cell.Col] == ' ')
                {
                    area.Size++;
                    matrix[cell.Row, cell.Col] = '.';
                    cells.Enqueue(new Cell(cell.Row, cell.Col - 1));
                    cells.Enqueue(new Cell(cell.Row - 1, cell.Col));
                    cells.Enqueue(new Cell(cell.Row, cell.Col + 1));
                    cells.Enqueue(new Cell(cell.Row + 1, cell.Col));
                }
            }

            connectedAreas.Add(area);
            var newCell = FindFirstEmptyCell(matrix);
            if (newCell == null)
            {
                return;
            }
            var newArea = new Area(newCell);
            cells.Enqueue(newCell);
            FindConnectedAreas(newArea, cells, matrix);
        }

        private static bool IsInRange(Cell cell, char[,] matrix)
        {
            if (cell.Row < 0 || cell.Col < 0 || cell.Row >= matrix.GetLength(0) || cell.Col >= matrix.GetLength(1))
            {
                return false;
            }

            return true;
        }

        private static Cell FindFirstEmptyCell(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == ' ')
                    {
                        return new Cell(row, col);
                    }
                }
            }

            return null;
        }
    }
}
