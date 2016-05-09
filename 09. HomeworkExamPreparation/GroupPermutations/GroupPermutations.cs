using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroupPermutations
{
    public class GroupPermutations
    {
        private static Dictionary<char, int> groups;
        private static StringBuilder result;
        public static void Main(string[] args)
        {            
            string input = Console.ReadLine();
            groups = input.Distinct().ToDictionary(c => c, c => input.Count(symbol => symbol == c));
            result = new StringBuilder();          
            GeneratePermutations(groups.Keys.ToArray(), 0);
            Console.Write(result);
        }

        private static void GeneratePermutations(char[] characters, int index)
        {
            if (index >= characters.Length)
            {
                PrintPermutation(characters);
            }

            for (int i = index; i < characters.Length; i++)
            {
                Swap(characters, index, i);
                GeneratePermutations(characters, index + 1);
                Swap(characters, index, i);
            }
        }

        private static void Swap(char[] characters, int first, int second)
        {
            char temp = characters[first];
            characters[first] = characters[second];
            characters[second] = temp;
        }

        private static void PrintPermutation(char[] characters)
        {            
            foreach (var item in characters)
            {
                for (int i = 0; i < groups[item]; i++)
                {
                    result.Append(item);
                }
            }

            result.AppendLine();
        }
    }
}
