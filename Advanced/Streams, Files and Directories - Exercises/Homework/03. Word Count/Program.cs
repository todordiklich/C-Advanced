using System;
using System.IO;
using System.Collections.Generic;
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
                string line = reader.ReadLine();

                while (line != null)
                {
                    if (!words.ContainsKey(line))
                    {
                        words.Add(line.ToLower(), 0);
                    }

                    line = reader.ReadLine();
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

            using (var writer = new StreamWriter("../../../actualResult.txt"))
            {
                foreach (var word in words)
                {
                    string str = $"{word.Key} - {word.Value}";
                    writer.WriteLine(str);
                }
            }

            using (var writer = new StreamWriter("../../../expectedResult.txt"))
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
