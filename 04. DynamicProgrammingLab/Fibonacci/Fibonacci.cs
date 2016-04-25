namespace Fibonacci
{
    using System;

    public class Fibonacci
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            long result = CalculateFibonacci(n);
            Console.WriteLine($"Fib({n}) = {result}");
        }

        private static long CalculateFibonacci(int num)
        {
            long first = 0;
            long second = 1;
            long result = 0; 
            for (int step = 1; step < num; step++)
            {
                result = first + second;
                first = second;
                second = result;
            }

            return result;
        }
    }
}
