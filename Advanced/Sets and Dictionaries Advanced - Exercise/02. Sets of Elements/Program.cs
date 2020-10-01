using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            HashSet<int> first = new HashSet<int>();
            HashSet<int> second = new HashSet<int>();

            AddElements(arr[0], first);
            AddElements(arr[1], second);

            var result = first.Intersect(second);

            Console.WriteLine(String.Join(" ", result));
        }

        public static void AddElements(int length, HashSet<int> set)
        {
            for (int i = 0; i < length; i++)
            {
                int number = int.Parse(Console.ReadLine());
                set.Add(number);
            }
        }
    }
}
