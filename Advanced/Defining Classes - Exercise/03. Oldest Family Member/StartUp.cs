using System;
using System.Linq;
using System.Collections.Generic;

namespace DefiningClasses
{
    class StartUp
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                Person person = new Person(input[0], int.Parse(input[1]));

                people.Add(person);
            }

            people = people.OrderByDescending(p => p.Age).ToList();

            Console.WriteLine($"{people[0].Name} {people[0].Age}");
        }
    }
}
