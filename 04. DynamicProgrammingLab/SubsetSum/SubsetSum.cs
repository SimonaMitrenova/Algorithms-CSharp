namespace SubsetSum
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class SubsetSum
    {
        public static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int targetSum = int.Parse(Console.ReadLine());
            var possibleSums = CalculatePosibleSums(nums, targetSum);
            var result = FindSubset(targetSum, possibleSums);
            Console.WriteLine("{0} = {1}",targetSum, string.Join(" + ", result));
        }

        private static IDictionary<int, int> CalculatePosibleSums(int[] numbers, int targetSum)
        {
            var possibleSums = new Dictionary<int, int>();
            possibleSums.Add(0, 0);

            for (int i = 0; i < numbers.Length; i++)
            {
                var newSums = new Dictionary<int, int>();
                foreach (var sum in possibleSums.Keys)
                {
                    int newSum = sum + numbers[i];
                    if (!possibleSums.ContainsKey(newSum))
                    {
                        newSums.Add(newSum, numbers[i]);
                    }
                }

                foreach (var newSum in newSums)
                {
                    possibleSums.Add(newSum.Key, newSum.Value);
                }
            }

            return possibleSums;
        }

        private static IEnumerable<int> FindSubset(int targetSum, IDictionary<int, int> possibleSums)
        {
            if (!possibleSums.ContainsKey(targetSum))
            {
                return Enumerable.Empty<int>();
            }

            var subset = new List<int>();
            while (targetSum > 0)
            {
                var current = possibleSums[targetSum];
                subset.Add(current);
                targetSum -= current;
            }

            subset.Reverse();
            return subset;
        }
    }
}
