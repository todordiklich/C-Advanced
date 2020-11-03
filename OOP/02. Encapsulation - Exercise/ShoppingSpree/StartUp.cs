using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class StartUp
    {
        private static List<Person> people = new List<Person>();
        private static List<Product> products = new List<Product>();
        static void Main(string[] args)
        {
            try
            {
                string[] personStr = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                CreatePerson(personStr);

                string[] productStr = Console.ReadLine().Split(";", StringSplitOptions.RemoveEmptyEntries);

                CreateProduct(productStr);

                while (true)
                {
                    string command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }

                    string[] cmdArgs = command.Split();
                    string personName = cmdArgs[0];
                    string productName = cmdArgs[1];

                    Person person = people.FirstOrDefault(p => p.Name == personName);
                    Product product = products.FirstOrDefault(p => p.Name == productName);

                    if (person != null && product != null)
                    {
                        Console.WriteLine(person.Buy(product));
                    }
                }

                foreach (var person in people)
                {
                    Console.WriteLine(person);
                }
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void CreateProduct(string[] productStr)
        {
            for (int i = 0; i < productStr.Length; i++)
            {
                string[] productArgs = productStr[i].Split("=");

                string name = productArgs[0];
                decimal cost = decimal.Parse(productArgs[1]);

                Product product = new Product(name, cost);
                products.Add(product);
            }
        }

        private static void CreatePerson(string[] personStr)
        {
            for (int i = 0; i < personStr.Length; i++)
            {
                string[] personArgs = personStr[i].Split("=");

                string name = personArgs[0];
                decimal money = decimal.Parse(personArgs[1]);

                Person person = new Person(name, money);
                people.Add(person);
            }
        }
    }
}
