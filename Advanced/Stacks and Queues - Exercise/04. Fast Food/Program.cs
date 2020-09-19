using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int foodAmount = int.Parse(Console.ReadLine());

            int[] orders = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Queue<int> queue = new Queue<int>(orders);

            int biggestOrder = queue.Max();

            while (queue.Count > 0)
            {
                if (foodAmount >= queue.Peek())
                {
                    foodAmount -= queue.Dequeue();
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(biggestOrder);
            if (queue.Count == 0)
            {
                Console.WriteLine("Orders complete");
            }
            else
            {
                Console.WriteLine($"Orders left: {string.Join(" ", queue)}");
            }
        }
    }
}
