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
            Console.Write("n=");
            numberOfIterations = int.Parse(Console.ReadLine());
            Console.Write("k=");
            numberOfLoops = int.Parse(Console.ReadLine());
            loops = new int[numberOfLoops];
            NestedLoops(0, 1, numberOfIterations);
        }

        private static void NestedLoops(int index, int startIteration, int numberOfIterations)
        {
            if (index == numberOfLoops)
            {
                PrintLoop();
                return;
            }

            for (int current = startIteration; current <= numberOfIterations; current++)
            {
                loops[index] = current;
                NestedLoops(index + 1, current + 1, numberOfIterations);
            }
        }

        private static void PrintLoop()
        {
            Console.WriteLine("({0})", string.Join(" ", loops));
        }
    }
}
