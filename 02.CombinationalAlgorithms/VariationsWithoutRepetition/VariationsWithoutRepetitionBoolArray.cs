namespace VariationsWithoutRepetition
{
    using System;

    public class VariationsWithoutRepetitionBoolArray
    {
        private static int numberOfLoops;
        private static int numberOfIterations;
        private static int[] loops;
        private static bool[] used;

        public static void Main(string[] args)
        {
            numberOfLoops = int.Parse(Console.ReadLine());
            numberOfIterations = int.Parse(Console.ReadLine());
            loops = new int[numberOfIterations];
            used = new bool[numberOfLoops + 1];
            GenerateVariationsWithoutRepetition(0);
        }

        private static void GenerateVariationsWithoutRepetition(int index)
        {
            if (index >= loops.Length)
            {
                PrintVariation();
                return;
            }

            for (int i = 1; i <= numberOfLoops; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    loops[index] = i;
                    GenerateVariationsWithoutRepetition(index + 1);
                    used[i] = false;
                }
            }
        }

        private static void PrintVariation()
        {
            Console.WriteLine($"({string.Join(", ", loops)})");
        }
    }
}
