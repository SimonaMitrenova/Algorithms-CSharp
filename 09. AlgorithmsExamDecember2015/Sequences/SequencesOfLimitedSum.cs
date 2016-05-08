namespace Sequences
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SequencesOfLimitedSum
    {
        public static List<int> sequences;
        public static StringBuilder resultSequences;

        public static void Main(string[] args)
        {
            int s = int.Parse(Console.ReadLine());
            sequences = new List<int>();
            resultSequences = new StringBuilder();
            for (int i = 1; i <= s; i++)
            {
                sequences.Add(i);
                GenerateSequences(i, s);
                sequences.RemoveAt(sequences.Count - 1);
            }

            Console.Write(resultSequences);
        }

        public static void GenerateSequences(int sum, int s)
        {
            if (sum > s)
            {
                return;
            }

            PrintSequence();
            for (int i = 1; i <= s; i++)
            {
                sequences.Add(i);
                GenerateSequences(sum + i, s);
                sequences.RemoveAt(sequences.Count - 1);
            }
        }

        private static void PrintSequence()
        {
            resultSequences.AppendLine(string.Join(" ", sequences));
        }
    }
}
