using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Wardrobe
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> wardrobe =
                new Dictionary<string, Dictionary<string, int>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" -> ", StringSplitOptions.RemoveEmptyEntries);
                string colour = input[0];

                string[] clothes = input[1].Split(",", StringSplitOptions.RemoveEmptyEntries);

                for (int j = 0; j < clothes.Length; j++)
                {
                    string clothe = clothes[j];
                    if (!wardrobe.ContainsKey(colour))
                    {
                        wardrobe.Add(colour, new Dictionary<string, int>());
                    }
                    if (!wardrobe[colour].ContainsKey(clothe))
                    {
                        wardrobe[colour].Add(clothe, 0);
                    }
                    wardrobe[colour][clothe]++;
                }
            }

            string[] searchedDress = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string searchedColour = searchedDress[0];
            string searchedClothe = searchedDress[1];

            foreach (var colours in wardrobe)
            {
                Console.WriteLine($"{colours.Key} clothes:");

                foreach (var clothes in colours.Value)
                {
                    if (colours.Key == searchedColour && clothes.Key == searchedClothe)
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value} (found!)");
                    }
                    else
                    {
                        Console.WriteLine($"* {clothes.Key} - {clothes.Value}");
                    }
                }
            }
        }
    }
}
