using System;
using System.IO;
using System.Linq;

namespace _02._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("../../../text.txt");
            string[] result = new string[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                int lettersCount = LettersCount(line);
                int marksCount = MarksCount(line);

                result[i] = $"Line {i + 1}: {line} ({lettersCount})({marksCount})";

            }

            File.WriteAllLines("../../../result.txt", result);
        }

        static int MarksCount(string text)
        {
            int count = 0;
            char[] marks = new char[] { '.', ',', '-', '!', '?', ':', ';', '\'' };

            for (int i = 0; i < text.Length; i++)
            {
                if (marks.Contains(text[i]))
                {
                    count++;
                }
            }

            return count;
        }

        static int LettersCount(string text)
        {
            int count = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (Char.IsLetter(text[i]))
                {
                    count++;
                }
            }

            return count;
        }
    }
}
