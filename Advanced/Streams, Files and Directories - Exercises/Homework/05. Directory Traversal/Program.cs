using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _05._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> result = new Dictionary<string, Dictionary<string, double>>();

            DirectoryInfo directoryInfo = new DirectoryInfo("../../../../");

            FileInfo[] files = directoryInfo.GetFiles();

            foreach (var file in files)
            {
                if (!result.ContainsKey(file.Extension))
                {
                    result.Add(file.Extension, new Dictionary<string, double>());
                }

                result[file.Extension].Add(file.Name, file.Length / 1024.00);
            }

            using (StreamWriter writer = new StreamWriter(
                $"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}/result.txt"))
            {
                foreach (var file in result.OrderByDescending(f => f.Value.Count).ThenBy(f => f.Key))
                {
                    writer.WriteLine($"{file.Key}");

                    foreach (var item in file.Value.OrderBy(f => f.Value))
                    {
                        writer.WriteLine($"--{item.Key} - {item.Value}kb");
                    }
                }
            }
        }
    }
}