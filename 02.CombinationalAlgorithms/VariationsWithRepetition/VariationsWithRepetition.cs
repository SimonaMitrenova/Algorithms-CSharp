namespace VariationsWithRepetition
{
    using System;

    public class VariationsWithRepetition
    {
        private static int numberOfLoops;
        public static int numberOfIterations;
        private static int[] loops;

        public static void Main(string[] args)
        {
            numberOfLoops = int.Parse(Console.ReadLine());
            numberOfIterations = int.Parse(Console.ReadLine());
            loops = new int[numberOfIterations];
            GenerateVariations(0);
        }

        private static void GenerateVariations(int index)
        {
            if (index >= loops.Length)
            {
                PrintVariation();
                return;
            }

            for (int i = 1; i <= numberOfLoops; i++)
            {
                loops[index] = i;
                GenerateVariations(index + 1);
            }
        }

        private static void PrintVariation()
        {
            Console.WriteLine("({0})", string.Join(", ", loops));
        }
    }
}
