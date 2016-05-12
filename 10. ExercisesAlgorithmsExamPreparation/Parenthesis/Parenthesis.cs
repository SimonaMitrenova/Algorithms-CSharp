namespace Parenthesis
{
    using System;
    using System.Text;

    public class Parenthesis
    {
        public static int n;
        public static StringBuilder result;
        public static char[] output;
        public static int opening = 0;
        public static int closing = 0;

        public static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            result = new StringBuilder();
            output = new char[2 * n];
            output[0] = '(';
            opening++;

            FindCombinations(1);
            Console.Write(result);
        }

        private static void FindCombinations(int index)
        {
            if (index == 2 * n)
            {
                result.AppendLine(string.Join("", output));
                return;
            }

            if (opening < n)
            {
                output[index] = '(';
                opening++;
                FindCombinations(index + 1);
                opening--;
            }
            if (closing < opening)
            {
                output[index] = ')';
                closing++;
                FindCombinations(index + 1);
                closing--;
            }
        }
    }
}
