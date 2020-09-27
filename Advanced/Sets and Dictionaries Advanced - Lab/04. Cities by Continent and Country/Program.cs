using System;
using System.Collections.Generic;
using System.Globalization;

namespace _04._Cities_by_Continent_and_Country
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, List<string>>> result = 
                new Dictionary<string, Dictionary<string, List<string>>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string continent = cmdArgs[0];
                string country = cmdArgs[1];
                string city = cmdArgs[2];

                if (!result.ContainsKey(continent))
                {
                    result.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!result[continent].ContainsKey(country))
                {
                    result[continent].Add(country, new List<string>());
                }

                result[continent][country].Add(city);
            }

            foreach (var continent in result)
            {
                Console.WriteLine($"{continent.Key}:");
                foreach (var country in continent.Value)
                {
                    Console.WriteLine($"  {country.Key} -> {String.Join(", ",country.Value)}");
                }
            }
        }
    }
}
