using System;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int special = int.Parse(Console.ReadLine());

            nums = nums.Where(n => n % special != 0).Reverse().ToArray();

            Console.WriteLine(string.Join(" ", nums));
        }
    }
}
