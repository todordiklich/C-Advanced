using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int[] commandArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();
                int command = commandArgs[0];

                if (command == 1)
                {
                    int num = commandArgs[1];
                    stack.Push(num);
                }

                if (stack.Count > 0)
                {
                    if (command == 2)
                    {
                            stack.Pop();
                    }
                    else if (command == 3)
                    {
                        Console.WriteLine(stack.Max());
                    }
                    else if (command == 4)
                    {
                        Console.WriteLine(stack.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", stack));
        }
    }
}
