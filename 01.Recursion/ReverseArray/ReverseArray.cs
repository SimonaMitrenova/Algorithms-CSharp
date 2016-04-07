namespace ReverseArray
{
    using System;
    using System.Linq;

    public class ReverseArray
    {
        public static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            PrintArrayRecursive(numbers);
        }

        public static void PrintArrayRecursive(int[] array, int index = 0)
        {
            if (index >= array.Length)
            {
                return;
            }

            PrintArrayRecursive(array, index + 1);
            Console.Write("{0} ", array[index]);
        }
    }
}
