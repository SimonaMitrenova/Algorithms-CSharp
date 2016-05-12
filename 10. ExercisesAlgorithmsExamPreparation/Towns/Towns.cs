namespace Towns
{
    using System;

    public class Towns
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            int[] path = new int[n];
            int[] backPath = new int[n];

            for (int i = 0; i < n; i++)
            {
                int citizens = int.Parse(Console.ReadLine().Split()[0]);
                numbers[i] = citizens;
            }

            for (int x = 0; x < n; x++)
            {
                path[x] = 1;
                for (int i = 0; i < x; i++)
                {
                    if (numbers[i] < numbers[x] && path[i] + 1 > path[x])
                    {
                        path[x] = path[i] + 1;
                    }
                }
            }

            for (int x = n - 1; x >= 0; x--)
            {
                backPath[x] = 1;
                for (int i = n - 1; i > x; i--)
                {
                    if (numbers[i] < numbers[x] && backPath[i] + 1 > backPath[x])
                    {
                        backPath[x] = backPath[i] + 1;
                    }
                }
            }

            int maxPath = 0;
            for (int i = 0; i < n; i++)
            {
                int currentSum = path[i] + backPath[i] - 1;
                if (currentSum > maxPath)
                {
                    maxPath = currentSum;
                }
            }

            Console.WriteLine(maxPath);
        }
    }
}
