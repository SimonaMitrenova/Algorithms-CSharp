namespace EgyptianFractions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class EgyptianFractions
    {
        public static void Main(string[] args)
        {
            int[] number =
                Console.ReadLine().Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int p = number[0];
            int q = number[1];
            if (p >= q)
            {
                Console.WriteLine("Error (fraction is equal to or greater than 1)");
                return;
            }

            int denominator = 2;
            List<string> denominators = new List<string>();
            while (p > 0)
            {
                while (p * denominator < q)
                {
                    denominator++;
                }

                p *= denominator;
                p -= q;
                q *= denominator;
                denominators.Add($"1/{denominator}");
                denominator++;
            }

            Console.WriteLine($"{number[0]}/{number[1]} = {string.Join(" + ", denominators)}");
        }
    }
}
