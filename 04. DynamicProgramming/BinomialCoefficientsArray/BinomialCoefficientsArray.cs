namespace BinomialCoefficientsArray
{
    using System;

    public class BinomialCoefficientsArray
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int k = int.Parse(Console.ReadLine());

            int[] evenArray = new int[n + 1];
            evenArray[0] = 1;
            int[] oddArray = new int[n + 1];
            oddArray[0] = 1;
            oddArray[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = 1; j <= i; j++)
                    {
                        evenArray[j] = oddArray[j - 1] + oddArray[j];
                    }
                }
                else
                {
                    for (int j = 1; j <= i; j++)
                    {
                        oddArray[j] = evenArray[j - 1] + evenArray[j];
                    }
                }
            }

            if (n % 2 == 0)
            {
                Console.WriteLine(evenArray[k]);
            }
            else
            {
                Console.WriteLine(oddArray[k]);
            }
        }
    }
}
