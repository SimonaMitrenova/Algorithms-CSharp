namespace VariationsWithoutRepetitionBetterAlgorithm
{
    using System;
    using System.Linq;

    public class VariationsWithoutRepetitionBetterAlgorithm
    {
        private static int numberOfLoops;
        private static int numberOfIterations;
        private static int[] loops;
        private static int[] free;

        public static void Main(string[] args)
        {
            numberOfLoops = int.Parse(Console.ReadLine());
            numberOfIterations = int.Parse(Console.ReadLine());
            loops = new int[numberOfIterations];
            free = Enumerable.Range(1, numberOfLoops).ToArray();
            GenerateVariationsWithoutRepetition(0);
        }

        private static void GenerateVariationsWithoutRepetition(int index)
        {
            if (index >= loops.Length)
            {
                PrintVariation();
                return;
            }
            for (int i = index; i < numberOfLoops; i++)
            {
                loops[index] = free[i];
                Swap(ref free[i], ref free[index]);
                GenerateVariationsWithoutRepetition(index + 1);
                Swap(ref free[i], ref free[index]);
            }
        }

        private static void Swap(ref int first, ref int second)
        {
            int temp = first;
            first = second;
            second = temp;
        }

        private static void PrintVariation()
        {
            Console.WriteLine($"({string.Join(", ", loops)})");
        }
    }
}
