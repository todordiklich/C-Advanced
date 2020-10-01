using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _03._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> words = new Dictionary<string, int>();

            using (var reader = new StreamReader("../../../words.txt"))
            {
                string[] searchWords = reader.ReadToEnd().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < searchWords.Length; i++)
                {
                    string cuurentWord = searchWords[i].ToLower();

                    if (!words.ContainsKey(cuurentWord))
                    {
                        words.Add(searchWords[i].ToLower(), 0);
                    }
                }
            }

            using (var reader = new StreamReader("../../../text.txt"))
            {
                string[] lineWords = reader.ReadToEnd().Split(new char[] { ' ', ',', '.', '?', '!', '-' }, StringSplitOptions.RemoveEmptyEntries);

                for (int i = 0; i < lineWords.Length; i++)
                {
                    string currentWord = lineWords[i].ToLower();

                    if (words.ContainsKey(currentWord))
                    {
                        words[currentWord]++;
                    }
                }
            }

            using (var writer = new StreamWriter("../../../Output.txt"))
            {
                foreach (var word in words.OrderByDescending(w => w.Value))
                {
                    string str = $"{word.Key} - {word.Value}";
                    writer.WriteLine(str);
                }
            }
        }
    }
}
