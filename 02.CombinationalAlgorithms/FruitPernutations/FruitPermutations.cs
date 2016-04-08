namespace FruitPermutations
{
    using System;
    using System.Linq;

    public class FruitPermutations
    {
        private static string[] fruits = new[] {"apple", "banana", "orange", "strawberry", "pineapple" };

        public static void Main(string[] args)
        {
            int[] numbers = Enumerable.Range(0, fruits.Length - 1).ToArray();
            MakeFruitSalatPermutations(numbers, 0);
        }

        private static void MakeFruitSalatPermutations(int[] numbers, int index)
        {
            if (index >= numbers.Length)
            {
                PrintFruitPermotation(numbers);
                return;
            }

            MakeFruitSalatPermutations(numbers, index + 1);
            for (int i = index + 1; i < numbers.Length; i++)
            {
                Swap(ref numbers[index], ref numbers[i]);
                MakeFruitSalatPermutations(numbers, index + 1);
                Swap(ref numbers[index], ref numbers[i]);
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        private static void PrintFruitPermotation(int[] numbers)
        {
            Console.WriteLine(string.Join(", ", numbers.Select(i => fruits[i])));
        }
    }
}
