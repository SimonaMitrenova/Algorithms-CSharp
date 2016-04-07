namespace NestedLoopsToRecursion
{
    using System;

    public class NestedLoopsToRecursion
    {
        private static int[] array;
        private static int numberOfLoops;

        public static void Main(string[] args)
        {
            numberOfLoops = int.Parse(Console.ReadLine());
            array = new int[numberOfLoops];
            NestedLoopsRecursive(0);
        }

        private static void NestedLoopsRecursive(int index)
        {
            if (index == numberOfLoops)
            {
                PrintLoops();
                return;
            }

            for (int counter = 1; counter <= numberOfLoops; counter++)
            {
                array[index] = counter;
                NestedLoopsRecursive(index + 1);
            }
        }

        private static void PrintLoops()
        {
            Console.WriteLine(string.Join(" ", array));
        }
    }
}
