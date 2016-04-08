namespace PermutationsWithRepetitionHashSet
{
    using System;
    using System.Collections.Generic;

    public class PermutationsWithRepetitionHashSet
    {
        public static void Main(string[] args)
        {
            int[] numbers = new[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            GeneratePermutationsWithRepetition(numbers, 0);
        }

        private static void GeneratePermutationsWithRepetition(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                PrintPermutation(numbers);
                return;
            }
            
            HashSet<int> swapped = new HashSet<int>();
            for (int i = index; i < numbers.Length; i++)
            {
                if (!swapped.Contains(numbers[i]))
                {
                    Swap(ref numbers[index], ref numbers[i]);
                    GeneratePermutationsWithRepetition(numbers, index + 1);
                    Swap(ref numbers[index], ref numbers[i]);
                    swapped.Add(numbers[i]);
                }
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        private static void PrintPermutation(int[] numbers)
        {
            Console.WriteLine($"({string.Join(", ", numbers)})");
        }
    }
}
