using System;
using System.Linq;
using System.Collections.Generic;

namespace _12._Cups_and_Bottles
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] cupsArr = Console.ReadLine().Split().Select(int.Parse).Reverse().ToArray();
            int[] bottlesArr = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Stack<int> cups = new Stack<int>(cupsArr);
            Stack<int> bottles = new Stack<int>(bottlesArr);

            int wastedWater = 0;

            while (cups.Count != 0 && bottles.Count != 0)
            {
                var currentCup = cups.Pop();
                var currentBottle = bottles.Pop();

                if (currentBottle >= currentCup)
                {
                    wastedWater += currentBottle - currentCup;
                }
                else
                {
                    currentCup -= currentBottle;
                    cups.Push(currentCup);
                }
            }

            Console.WriteLine(cups.Count == 0
                ? $"Bottles: {string.Join(" ", bottles)}"
                : $"Cups: {string.Join(" ", cups)}");

            Console.WriteLine($"Wasted litters of water: {wastedWater}");
        }
    }
}
