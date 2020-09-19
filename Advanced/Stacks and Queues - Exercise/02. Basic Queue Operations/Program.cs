using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Basic_Queue_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] command = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> queue = new Queue<int>(numbers);

            int elementsToPush = command[0];
            int elementsToPop = command[1];
            int elementToSearch = command[2];

            for (int i = 0; i < elementsToPop; i++)
            {
                queue.Dequeue();
            }

            if (queue.Contains(elementToSearch))
            {
                Console.WriteLine("true");
            }
            else if (queue.Count > 0)
            {
                Console.WriteLine(queue.Min());
            }
            else
            {
                Console.WriteLine(0);
            }
        }
    }
}
