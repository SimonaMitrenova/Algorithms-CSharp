namespace Permutations
{
    using System;
    using System.Linq;

    public class Permutations
    {
        public static void Main(string[] args)
        {
            int numberOfLoops = int.Parse(Console.ReadLine());
            int[] numbers = Enumerable.Range(1, numberOfLoops).ToArray();
            GeneratePermutations(numbers, 0);
        }

        private static void GeneratePermutations(int[] array, int index)
        {
            if (index >= array.Length)
            {
                PrintPermutation(array);
                return;
            }

            GeneratePermutations(array, index + 1);
            for (int i = index + 1; i < array.Length; i++)
            {
                Swap(ref array[index], ref array[i]);
                GeneratePermutations(array, index + 1);
                Swap(ref array[index], ref array[i]);
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
