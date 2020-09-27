using System;
using System.Collections.Generic;

namespace _01._Count_Same_Values_in_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> nums = new Dictionary<string, int>();

            string[] input = Console.ReadLine().Split();

            for (int i = 0; i < input.Length; i++)
            {
                if (!nums.ContainsKey(input[i]))
                {
                    nums.Add(input[i], 0);
                }

                nums[input[i]]++;
            }

            foreach (var item in nums)
            {
                Console.WriteLine($"{item.Key} - {item.Value} times");
            }
        }
    }
}
