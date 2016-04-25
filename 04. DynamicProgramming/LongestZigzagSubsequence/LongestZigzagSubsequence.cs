namespace LongestZigzagSubsequence
{
    using System;
    using System.Linq;

    public class LongestZigzagSubsequence
    {
        private static int[] numbers;
        private static int[] length;
        private static int[] prevIndex;
        private static int[] difference;

        private static int maxLength;
        private static int lastIndex;

        public static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                .Split(new[] {","}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            maxLength = 0;
            lastIndex = -1;

            length = new int[numbers.Length];
            prevIndex = new int[numbers.Length];
            difference = new int[numbers.Length];

            FindLongestZigzagSubsequence();
            var result = RestoreSubsequence();
            Console.WriteLine(string.Join(", ", result));
        }

        private static int[] RestoreSubsequence()
        {
            int[] result = new int[maxLength];
            int index = maxLength - 1;
            while (lastIndex != -1)
            {
                result[index] = numbers[lastIndex];
                lastIndex = prevIndex[lastIndex];
                index--;
            }
            return result;
        }

        private static void FindLongestZigzagSubsequence()
        {
            for (int x = 0; x < numbers.Length; x++)
            {
                length[x] = 1;
                prevIndex[x] = -1;
                difference[x] = 0;

                for (int i = 0; i < x; i++)
                {
                    int currentdiff = numbers[x] - numbers[i];
                    bool isZigzag = (difference[i] < 0 && currentdiff > 0) || (difference[i] > 0 && currentdiff < 0);
                    if ((difference[i] == 0 || isZigzag) &&
                        length[i] + 1 > length[x])
                    {
                        length[x] = length[i] + 1;
                        prevIndex[x] = i;
                        difference[x] = currentdiff;
                    }
                }
                if (length[x] > maxLength)
                {
                    maxLength = length[x];
                    lastIndex = x;
                }
            }
        }
    }
}
