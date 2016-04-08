namespace PermutationsWithRepetition
{
    using System;

    public class PermutationsWithRepetition
    {
        public static void Main(string[] args)
        {
            int[] numbers = new[] { 1, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5, 5 };
            Array.Sort(numbers);
            GeneratePermutationWithRepetition(numbers, 0, numbers.Length - 1);
        }

        private static void GeneratePermutationWithRepetition(int[] array, int start, int end)
        {
            PrintPermutation(array);
            for (int left = end - 1; left >= start; left--)
            {
                for (int right = left + 1; right <= end; right++)
                {
                    if (array[left] != array[right])
                    {
                        Swap(ref array[left], ref array[right]);
                        GeneratePermutationWithRepetition(array, left + 1, end);
                    }
                }

                var firstElement = array[left];
                for (int i = left; i <= end - 1; i++)
                {
                    array[i] = array[i + 1];
                }
                array[end] = firstElement;
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        private static void PrintPermutation(int[] array)
        {
            Console.WriteLine($"({string.Join(", ", array)})");
        }
    }
}
