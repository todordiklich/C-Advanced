using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> minNumFunc = nums =>
            {
                int minNumber = int.MaxValue;

                foreach (var number in nums)
                {
                    if (number < minNumber)
                    {
                        minNumber = number;
                    }
                }

                return minNumber;
            };

            Console.WriteLine(minNumFunc(numbers));
        }
    }
}
