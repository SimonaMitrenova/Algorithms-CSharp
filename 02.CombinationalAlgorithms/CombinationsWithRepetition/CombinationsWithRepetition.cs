namespace CombinationsWithRepetition
{
    using System;

    public class CombinationsWithRepetition
    {
        private static int numberOfLoops;
        private static int numberOfIterations;
        private static int[] loops;

        public static void Main(string[] args)
        {
            numberOfLoops = int.Parse(Console.ReadLine());
            numberOfIterations = int.Parse(Console.ReadLine());
            loops = new int[numberOfIterations];
            GenerateCombinationsWithRepetition(0, 0);
        }

        private static void GenerateCombinationsWithRepetition(int index, int startIndex)
        {
            if (index >= loops.Length)
            {
                PrintCombination();
                return;
            }

            for (int i = startIndex; i < numberOfLoops; i++)
            {
                loops[index] = i;
                GenerateCombinationsWithRepetition(index + 1, i);
            }
        }

        private static void PrintCombination()
        {
            Console.WriteLine($"({string.Join(", ", loops)})");
        }
    }
}
