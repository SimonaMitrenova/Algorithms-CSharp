using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridges
{
    public class Bridges
    {
        private static int[,] maxBridges;
        private static int[] north;
        private static int[] south;

        public static void Main(string[] args)
        {
            north = Console.ReadLine().Split().Select(int.Parse).ToArray();
            south = Console.ReadLine().Split().Select(int.Parse).ToArray();
            maxBridges = new int[north.Length, south.Length];
            for (int row = 0; row < maxBridges.GetLength(0); row++)
            {
                for (int col = 0; col < maxBridges.GetLength(1); col++)
                {
                    maxBridges[row, col] = -1;
                }
            }

            int bridgesCount = CalcMaxBridges(north.Length - 1, south.Length - 1);
            Console.WriteLine(bridgesCount);
        }

        private static int CalcMaxBridges(int x, int y)
        {
            if (x < 0 || y < 0)
            {
                return 0;
            }

            if (maxBridges[x, y] != -1)
            {
                return maxBridges[x, y];
            }

            int northLeft = CalcMaxBridges(x - 1, y);
            int sounthLeft = CalcMaxBridges(x, y - 1);

            if (north[x] == south[y])
            {
                maxBridges[x, y] = 1 + Math.Max(northLeft, sounthLeft);
            }
            else
            {
                maxBridges[x, y] = Math.Max(northLeft, sounthLeft);
            }

            return maxBridges[x, y];
        }
    }
}
