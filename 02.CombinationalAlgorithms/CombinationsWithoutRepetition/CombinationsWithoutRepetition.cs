namespace CombinationsWithoutRepetition
{
    using System;

    public class CombinationsWithoutRepetition
    {
        private static int numberOfLoops;
        private static int numberOfIterations;
        private static int[] loops;

        public static void Main(string[] args)
        {
            numberOfLoops = int.Parse(Console.ReadLine());
            numberOfIterations = int.Parse(Console.ReadLine());
            loops = new int[numberOfIterations];
            GenerateCombinations(0, 0);
        }

        private static void GenerateCombinations(int index, int start)
        {
            if (index >= loops.Length)
            {
                PrintCombination();
                return;
            }

            for (int i = start; i < numberOfLoops; i++)
            {
                loops[index] = i;
                GenerateCombinations(index + 1, i + 1);
            }
        }

        private static void PrintCombination()
        {
            Console.WriteLine($"({string.Join(", ", loops)})");
        }
    }
}
