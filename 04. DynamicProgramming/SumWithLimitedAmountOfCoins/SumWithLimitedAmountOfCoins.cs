namespace SumWithLimitedAmountOfCoins
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SumWithLimitedAmountOfCoins
    {
        private static int targetSum;
        private static int[] coins;
        private static int totalSums;
        private static List<int> currentCombination;
        private static HashSet<string> usedCombinations;

        public static void Main(string[] args)
        {
            targetSum = int.Parse(Console.ReadLine());
            coins = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            currentCombination = new List<int>();
            usedCombinations = new HashSet<string>();

            totalSums = 0;
            CalculatePossibleSums(0, 0);
            Console.WriteLine(totalSums);
        }

        private static void CalculatePossibleSums(int sum, int start)
        {
            if (sum == targetSum)
            {
                string combination = string.Join(" ", currentCombination.OrderBy(i => i));
                if (!usedCombinations.Contains(combination))
                {
                    usedCombinations.Add(combination);
                    totalSums++;
                }
                return;
            }
            if (sum > targetSum)
            {
                return;
            }

            for (int i = start; i < coins.Length; i++)
            {
                currentCombination.Add(coins[i]);
                CalculatePossibleSums(sum + coins[i], i + 1);
                currentCombination.Remove(coins[i]);
            }
        }
    }
}
