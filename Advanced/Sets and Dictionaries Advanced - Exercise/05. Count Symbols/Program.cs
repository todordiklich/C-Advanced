using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<char, int> numbers = new Dictionary<char, int>();

            string text = Console.ReadLine();

            for (int i = 0; i < text.Length; i++)
            {
                char ch = text[i];

                if (!numbers.ContainsKey(ch))
                {
                    numbers.Add(ch, 0);
                }

                numbers[ch]++;
            }

            foreach (var item in numbers.OrderBy(e => e.Key))
            {
                Console.WriteLine($"{item.Key}: {item.Value} time/s");
            }
        }
    }
}
