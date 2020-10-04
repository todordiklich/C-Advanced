using System;
using System.IO;
using System.Linq;

namespace _01._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] symbolsToReplace = new char[] { '-', ',', '.', '!', '?' };
            char replacement = '@';

            using (StreamReader reader = new StreamReader("../../../text.txt"))
            {
                using (StreamWriter writer = new StreamWriter("../../../result.txt"))
                {
                    int counter = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {

                        if (counter % 2 == 0)
                        {
                            string[] toCorrect = line.Split();
                            string[] result = new string[toCorrect.Length];

                            for (int i = toCorrect.Length - 1; i >= 0; i--)
                            {
                                string word = toCorrect[i];

                                for (int j = 0; j < word.Length; j++)
                                {
                                    if (symbolsToReplace.Contains(word[j]))
                                    {
                                        word = word.Replace(word[j], replacement);
                                    }
                                }

                                result[result.Length - 1 - i] = word;
                            }

                            writer.WriteLine(string.Join(" ", result));
                        }

                        counter++;
                        line = reader.ReadLine();
                    }
                }
            }
        }
    }
}
