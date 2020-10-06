using System;
using System.Linq;

namespace _03._Count_Uppercase_Words
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<string, bool> checker = StartsWithUpperLetter;

            string[] words = Console
                .ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Where(checker)
                .ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, words));
        }

        static bool StartsWithUpperLetter(string word)
        {
            if (word[0] == word.ToUpper()[0])
            {
                return true;
            }

            return false;
        }
    }
}
