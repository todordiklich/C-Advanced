using System;
using System.Linq;

namespace _04._Add_VAT
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] nums = Console
                .ReadLine()
                .Split(", ")
                .Select(double.Parse)
                .Select( n => n*1.2)
                .ToArray();

            foreach (var num in nums)
            {
                Console.WriteLine($"{num:F2}");
            }
        }
    }
}
