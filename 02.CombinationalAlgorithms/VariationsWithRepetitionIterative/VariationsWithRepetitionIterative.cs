namespace VariationsWithRepetitionIterative
{
    using System;

    public class VariationsWithRepetitionIterative
    {
        public static void Main(string[] args)
        {
            int numberOfLoops = int.Parse(Console.ReadLine());
            int numberOfIterations = int.Parse(Console.ReadLine());
            int[] loops = new int[numberOfIterations];

            while (true)
            {
                PrintVariation(loops);
                int index = numberOfIterations - 1;
                while (index >= 0 && loops[index] == numberOfLoops - 1)
                {
                    index--;
                }
                if (index < 0)
                {
                    break;
                }
                loops[index]++;
                for (int i = index + 1; i < numberOfIterations; i++)
                {
                    loops[i] = 0;
                }
            }
        }

        private static void PrintVariation(int[] loops)
        {
            Console.WriteLine($"({string.Join(", ", loops)})");
        }
    }
}
