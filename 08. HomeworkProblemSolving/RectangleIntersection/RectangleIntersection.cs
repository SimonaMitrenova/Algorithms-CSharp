using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RectangleIntersection
{
    public class RectangleIntersection
    {
        public static void Main(string[] args)
        {
            List<Rectangle> rectangles = new List<Rectangle>();            
            int rectangleCount = int.Parse(Console.ReadLine());
            List<int> xCoord = new List<int>();
            List<int> yCoord = new List<int>();
            
            for (int i = 0; i < rectangleCount; i++)
            {
                int[] recParams = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var rectangle = new Rectangle(recParams[0], recParams[1], recParams[2], recParams[3]);
                rectangles.Add(rectangle);
                xCoord.Add(recParams[0]);
                xCoord.Add(recParams[1]);
                yCoord.Add(recParams[2]);
                yCoord.Add(recParams[3]);
            }

            xCoord = xCoord.OrderBy(e => e).Distinct().ToList();
            yCoord = yCoord.OrderBy(e => e).Distinct().ToList();
            int allIntersectAreas = 0;

            for (int x = 0; x < xCoord.Count - 1; x++)
            {
                for (int y = 0; y < yCoord.Count - 1; y++)
                {
                    int overlapedRect = 0;                    
                    foreach (var rectangle in rectangles)
                    {
                        if (rectangle.X1 < xCoord[x + 1] && xCoord[x] < rectangle.X2 && rectangle.Y1 < yCoord[y + 1] && yCoord[y] < rectangle.Y2)
                        {
                            overlapedRect++;
                        }
                    }
                    if (overlapedRect >= 2)
                    {
                        allIntersectAreas += Math.Abs(yCoord[y] - yCoord[y + 1]) * Math.Abs(xCoord[x] - xCoord[x + 1]);
                    }                    
                }
            }

            Console.WriteLine(allIntersectAreas);
        }
    }

    public class Rectangle
    {
        public Rectangle(int x1, int x2, int y1, int y2)
        {
            this.X1 = x1;
            this.X2 = x2;
            this.Y1 = y1;
            this.Y2 = y2;
        }

        public int X1 { get; set; }

        public int X2 { get; set; }

        public int Y1 { get; set; }

        public int Y2 { get; set; }
    }
}
