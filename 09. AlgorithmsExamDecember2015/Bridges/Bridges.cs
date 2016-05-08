namespace Bridges
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NonCrossingBridges
    {
        public static void Main(string[] args)
        {
            int[] columns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();

            List<int> bridges = new List<int>();
            int lastBridgeIndex = 0;
            for (int i = 1; i < columns.Length; i++)
            {
                int last = -1;
                for (int x = lastBridgeIndex; x < i; x++)
                {
                    if (columns[i] == columns[x])
                    {
                        last = x;
                        break;
                    }
                }
                if (last != -1 && lastBridgeIndex <= last)
                {
                    bridges.Add(last);
                    bridges.Add(i);
                    lastBridgeIndex = i;
                }
            }

            int bridgesFound = bridges.Count / 2;
            string[] results = Enumerable.Repeat("X", columns.Length).ToArray();
            for (int i = 0; i < bridges.Count; i++)
            {
                results[bridges[i]] = columns[bridges[i]].ToString();
            }

            if (bridgesFound == 0)
            {
                Console.WriteLine("No bridges found");
            }
            else if (bridgesFound == 1)
            {
                Console.WriteLine("1 bridge found");
            }
            else
            {
                Console.WriteLine("{0} bridges found", bridgesFound);
            }

            Console.WriteLine(string.Join(" ", results));
        }
    }
}
