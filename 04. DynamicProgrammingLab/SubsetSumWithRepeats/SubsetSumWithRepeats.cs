namespace SubsetSumWithRepeats
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetSumWithRepeats
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            bool[] possible = CalculatePossibleSums(numbers, targetSum);
            var result = FindSubset(numbers, targetSum, possible);
            Console.WriteLine($"{targetSum} = {string.Join(" + ", result)}");
        }

        private static bool[] CalculatePossibleSums(int[] numbers, int targetSum)
        {
            bool[] possibleSums = new bool[targetSum + 1];
            possibleSums[0] = true;
            for (int sum = 0; sum < possibleSums.Length; sum++)
            {
                if (possibleSums[sum])
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        int newSum = sum + numbers[i];
                        if (newSum <= targetSum)
                        {
                            possibleSums[newSum] = true;
                        }
                    }
                }
            }

            return possibleSums;
        }

        private static IEnumerable<int> FindSubset(int[] numbers, int targetSum, bool[] possibleSum)
        {
            var subset = new List<int>();
            while (targetSum > 0)
            {
                for (int i = 0; i < numbers.Length; i++)
                {
                    int newSum = targetSum - numbers[i];
                    if (newSum >= 0 && possibleSum[newSum])
                    {
                        targetSum = newSum;
                        subset.Add(numbers[i]);
                    }
                }
            }

            return subset;
        } 
    }
}
