using System;
using System.Collections.Generic;
using System.Linq;

namespace Exercise___Stacks_and_Queues
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> stack = new Stack<int>(numbers);

            int elementsToPush = command[0];
            int elementsToPop = command[1];
            int elementToSearch = command[2];

            for (int i = 0; i < elementsToPop; i++)
            {
                stack.Pop();
            }

            if (stack.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else if (stack.Count > 0)
            {
                Console.WriteLine(stack.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
