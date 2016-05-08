namespace Rectangles
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NestedRectangles
    {
        public static List<Rectangle> rectangles;

        public static void Main(string[] args)
        {
            rectangles = new List<Rectangle>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }
                string[] rectangleArgs = input.Split(':');
                string name = rectangleArgs[0];
                int[] coordinates =
                    rectangleArgs[1].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                var rectangle = new Rectangle(name, coordinates[0], coordinates[1], coordinates[2], coordinates[3]);
                rectangles.Add(rectangle);
            }

            Rectangle bestNested = null;
            foreach (var rectangle in rectangles)
            {
                FindNestedRectangles(rectangle);
                if (bestNested == null ||
                        bestNested.Depth < rectangle.Depth ||
                        (bestNested.Depth == rectangle.Depth && rectangle.Name.CompareTo(bestNested.Name) < 0))
                {
                    bestNested = rectangle;
                }
            }

            List<string> names = new List<string>();

            while (true)
            {
                if (bestNested == null)
                {
                    break;
                }
                names.Add(bestNested.Name);
                bestNested = bestNested.Prev;
            }

            Console.WriteLine(string.Join(" < ", names));
        }

        private static void FindNestedRectangles(Rectangle current)
        {
            if (current.Depth > 0)
            {
                return;
            }

            current.Depth = 1;
            Rectangle bestNested = null;
            foreach (var rectangle in rectangles)
            {
                if (current != rectangle && current.IsInside(rectangle))
                {
                    FindNestedRectangles(rectangle);
                    if (bestNested == null ||
                        bestNested.Depth < rectangle.Depth ||
                        (bestNested.Depth == rectangle.Depth && rectangle.Name.CompareTo(bestNested.Name) < 0))
                    {
                        bestNested = rectangle;
                    }
                }
            }
            if (bestNested != null)
            {
                current.Depth = bestNested.Depth + 1;
                current.Prev = bestNested;
            }
        }
    }

    public class Rectangle
    {
        public Rectangle(string name, int x1, int y1, int x2, int y2)
        {
            this.Name = name;
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
            this.Depth = 0;
        }

        public string Name { get; set; }

        public Rectangle Prev { get; set; }

        public int X1 { get; set; }

        public int Y1 { get; set; }

        public int X2 { get; set; }

        public int Y2 { get; set; }

        public int Depth { get; set; }

        public bool IsInside(Rectangle other)
        {
            return this.X1 <= other.X1 &&
                    other.X2 <= this.X2 &&
                    this.Y1 >= other.Y1 &&
                    other.Y2 >= this.Y2;
        }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
