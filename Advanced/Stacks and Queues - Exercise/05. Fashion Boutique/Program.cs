using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            var clothes = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int rackCapacity = int.Parse(Console.ReadLine());

            Stack<int> prices = new Stack<int>(clothes);

            int sumOfClothes = 0;
            int racksUsed = 0;

            while (prices.Count > 0)
            {
                sumOfClothes += prices.Pop();

                if (prices.Count > 0 && sumOfClothes + prices.Peek() <= rackCapacity)
                {
                    continue;
                }
                else
                {
                    racksUsed++;
                    sumOfClothes = 0;
                }
            }

            Console.WriteLine(racksUsed);
        }
    }
}
