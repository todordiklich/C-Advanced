using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Product_Shop
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, double>> result = new Dictionary<string, Dictionary<string, double>>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower() == "revision")
                {
                    break;
                }

                string[] cmdArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string shop = cmdArgs[0];
                string product = cmdArgs[1];
                double price = double.Parse(cmdArgs[2]);

                if (!result.ContainsKey(shop))
                {
                    result.Add(shop, new Dictionary<string, double>());
                }
                if (!result[shop].ContainsKey(product))
                {
                    result[shop].Add(product, 0);
                }

                result[shop][product] = price;
            }

            foreach (var shop in result.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{shop.Key}->");
                foreach (var product in shop.Value)
                {
                    Console.WriteLine($"Product: {product.Key}, Price: {product.Value}");
                }
            }
        }
    }
}
