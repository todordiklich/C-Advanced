using System;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int startNumber = nums[0];
            int endNumber = nums[1];

            string condition = Console.ReadLine();

            //TODO: implement the solution
        }
    }
}
