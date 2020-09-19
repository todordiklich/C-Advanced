using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace _5._Print_Even_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).Where(n => n % 2 == 0).ToArray();
            Queue<int> queue = new Queue<int>(numbers);

            Console.WriteLine(string.Join(", ", queue));
        }
    }
}
