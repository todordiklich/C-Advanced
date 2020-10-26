using System;
using System.Linq;
using System.Collections.Generic;

namespace _3._Sum_of_Coins
{
    class Program
    {
        static Dictionary<int, int> usedCoins = new Dictionary<int, int>();
        static void Main(string[] args)
        {
            List<int> coins = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int sum = int.Parse(Console.ReadLine());

            CalculateCoins(coins, sum);

            Console.WriteLine($"Number of coins to take: {usedCoins.Sum(c => c.Value)}");
            foreach (var coin in usedCoins)
            {
                if (coin.Value > 0)
                {
                    Console.WriteLine($"{coin.Value} coin(s) with value {coin.Key}");
                }
            }
        }

        private static void CalculateCoins(List<int> coins, int sum)
        {
            int currSum = 0;
            int i = coins.Count - 1;

            while (currSum < sum && i >= 0)
            {
                if (currSum + coins[i] <= sum)
                {
                    currSum += coins[i];
                    if (!usedCoins.ContainsKey(coins[i]))
                    {
                        usedCoins[coins[i]] = 0;
                    }

                    usedCoins[coins[i]]++;
                }
                else
                {
                    i--;
                }
            }
            if (currSum != sum)
            {
                Console.WriteLine("Error");
                Environment.Exit(0);
            }
        }
    }
}
