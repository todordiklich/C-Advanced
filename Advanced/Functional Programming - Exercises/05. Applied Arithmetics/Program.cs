using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<string, int[], int[]> filterFunc = (cmd, arr) =>
            {
                switch (cmd)
                {
                    case "add":
                       return arr = arr.Select(n => n + 1).ToArray();
                    case "multiply":
                       return arr = arr.Select(n => n * 2).ToArray();
                    case "subtract":
                       return arr = arr.Select(n => n - 1).ToArray();
                    default:
                        return arr;
                }
            };

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                if (command == "print")
                {
                    Console.WriteLine(string.Join(" ", nums));
                }

                nums = filterFunc(command, nums);
            }
        }
    }
}
