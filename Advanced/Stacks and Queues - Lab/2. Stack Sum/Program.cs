using System;
using System.Collections.Generic;
using System.Linq;

namespace _2._Stack_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> stack = new Stack<int>(numbers);

            while (true)
            {
                string[] commandArgs = Console.ReadLine().Split();
                string command = commandArgs[0].ToLower();
                if (command == "end")
                {
                    break;
                }

                if (command == "add")
                {
                    stack.Push(int.Parse(commandArgs[1]));
                    stack.Push(int.Parse(commandArgs[2]));
                }
                else if (command == "remove")
                {
                    int count = int.Parse(commandArgs[1]);

                    if (stack.Count >= count)
                    {
                        for (int i = 0; i < count; i++)
                        {
                            stack.Pop();
                        }
                    }
                }
            }

            Console.WriteLine($"Sum: {stack.Sum()}");
        }
    }
}
