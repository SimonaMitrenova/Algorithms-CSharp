namespace BridgesWithDictionary
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NonCrossingBridgesDictionary
    {
        public static void Main(string[] args)
        {
            int[] columns = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            var lastIndexFound = new Dictionary<int, int>();
            for (int i = 0; i < columns.Length; i++)
            {
                if (!lastIndexFound.ContainsKey(columns[i]))
                {
                    lastIndexFound[columns[i]] = i;
                }
            }

            List<int> bridges = new List<int>();
            int lastBridgeIndex = 0;
            for (int i = 1; i < columns.Length; i++)
            {
                if (lastIndexFound.ContainsKey(columns[i]) && lastIndexFound[columns[i]] != i && lastBridgeIndex <= lastIndexFound[columns[i]])
                {
                    bridges.Add(lastIndexFound[columns[i]]);
                    bridges.Add(i);
                    lastBridgeIndex = i;
                }

                lastIndexFound[columns[i]] = i;
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
