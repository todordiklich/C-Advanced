using P06FoodShortage.Contracts;
using P06FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P06FoodShortage.Core
{
    public class Engine
    {
        private Rebel rebel;
        private Citizen citizen;
        private List<IBuyer> buyers;
        public Engine()
        {
            buyers = new List<IBuyer>();
        }
        public void Run()
        {
            int number = int.Parse(Console.ReadLine());
            for (int i = 0; i < number; i++)
            {
                string[] tokens = Console
                    .ReadLine()
                    .Split();

                string name = tokens[0];
                int age = int.Parse(tokens[1]);

                if (tokens.Length == 3)
                {
                    string group = tokens[2];
                    rebel = new Rebel(name, age, group);

                    buyers.Add(rebel);
                }
                else if (tokens.Length == 4)
                {
                    string id = tokens[2];
                    string birthdate = tokens[3];
                    citizen = new Citizen(name, age, id, birthdate);

                    buyers.Add(citizen);
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                IBuyer buyer = buyers.FirstOrDefault(b => b.Name == command);

                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }

            Console.WriteLine(buyers.Sum(b => b.Food));
        }
    }
}
