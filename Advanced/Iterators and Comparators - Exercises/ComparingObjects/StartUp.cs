using System;
using System.Collections.Generic;

namespace ComparingObjects
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    break;
                }

                string[] cmdArgs = cmd.Split();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);
                string town = cmdArgs[2];

                Person person = new Person(name, age, town);

                people.Add(person);
            }

            int index = int.Parse(Console.ReadLine()) - 1;

            int equalPersons = 0;

            for (int i = 0; i < people.Count; i++)
            {
                if (i != index)
                {
                    int result = people[index].CompareTo(people[i]);
                    if (result == 0)
                    {
                        equalPersons++;
                    }
                }
            }

            if (equalPersons == 0)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                equalPersons++;
                Console.WriteLine($"{equalPersons} {people.Count - equalPersons} {people.Count}");
            }
        }
    }
}
