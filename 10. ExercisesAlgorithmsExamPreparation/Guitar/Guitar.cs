namespace Guitar
{
    using System;
    using System.Linq;

    public class Guitar
    {
        public static void Main(string[] args)
        {
            int[] intervals =
                Console.ReadLine()
                    .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();
            int initialVolume = int.Parse(Console.ReadLine());
            int maxVolume = int.Parse(Console.ReadLine());

            bool[,] matrix = new bool[intervals.Length + 1, maxVolume + 1];
            matrix[0, initialVolume] = true;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col])
                    {
                        if (col - intervals[row] >= 0)
                        {
                            matrix[row + 1, col - intervals[row]] = true;
                        }
                        if (col + intervals[row] <= maxVolume)
                        {
                            matrix[row + 1, col + intervals[row]] = true;
                        }
                    }
                }
            }
            int result = maxVolume;
            while (result >= 0)
            {
                if (matrix[intervals.Length, result])
                {
                    Console.WriteLine(result);
                    return;
                }
                result--;
            }

            Console.WriteLine(-1);
        }
    }
}
