using ExplicitInterfaces.Contracts;
using ExplicitInterfaces.Models;
using System;

namespace ExplicitInterfaces
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "End")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split();

                string name = cmdArgs[0];
                string country = cmdArgs[1];
                int age = int.Parse(cmdArgs[2]);

                IPerson person = new Citizen(name, country, age);
                IResident resident = new Citizen(name, country, age);

                Console.WriteLine(person.GetName());
                Console.WriteLine(resident.GetName()); 
            }
        }
    }
}
