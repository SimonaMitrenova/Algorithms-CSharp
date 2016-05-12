namespace GuitarArray
{
    using System;
    using System.Linq;

    public class GuitarArray
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

            bool[] evenArray = new bool[maxVolume + 1];
            evenArray[initialVolume] = true;
            bool[] oddArray = new bool[maxVolume + 1];
            for (int row = 0; row < intervals.Length; row++)
            {
                for (int col = 0; col <= maxVolume; col++)
                {
                    if (row % 2 == 0)
                    {
                        if (evenArray[col])
                        {
                            if (col - intervals[row] >= 0)
                            {
                                oddArray[col - intervals[row]] = true;
                            }
                            if (col + intervals[row] <= maxVolume)
                            {
                                oddArray[col + intervals[row]] = true;
                            }

                            evenArray[col] = false;
                        }
                    }
                    else
                    {
                        if (oddArray[col])
                        {
                            if (col - intervals[row] >= 0)
                            {
                                evenArray[col - intervals[row]] = true;
                            }
                            if (col + intervals[row] <= maxVolume)
                            {
                                evenArray[col + intervals[row]] = true;
                            }

                            oddArray[col] = false;
                        }
                    }
                }

            }

            if (intervals.Length % 2 == 0)
            {
                int result = maxVolume;
                while (result >= 0)
                {
                    if (evenArray[result])
                    {
                        Console.WriteLine(result);
                        return;
                    }
                    result--;
                }

                Console.WriteLine(-1);
            }
            else
            {
                int result = maxVolume;
                while (result >= 0)
                {
                    if (oddArray[result])
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
}
