using System;
using System.Collections.Generic;

namespace BorderControl
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IBirthable> citizens = new List<IBirthable>();
            IBirthable citizen;

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "End")
                {
                    break;
                }

                string[] arguments = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string type = arguments[0];

                if (type == "Citizen")
                {
                    string name = arguments[1];
                    int age = int.Parse(arguments[2]);
                    string id = arguments[3];
                    string birtgdate = arguments[4];

                    citizen = new Citizen(name, age, id, birtgdate);
                    citizens.Add(citizen);
                }
                else if (type == "Pet")
                {
                    string model = arguments[1];
                    string birtgdate = arguments[2];

                    citizen = new Pet(model, birtgdate);
                    citizens.Add(citizen);
                }

            }

            string code = Console.ReadLine();

            foreach (var c in citizens)
            {
                if (c.Birthdate.EndsWith(code))
                {
                    Console.WriteLine(c.Birthdate);
                }
            }
        }
    }
}
