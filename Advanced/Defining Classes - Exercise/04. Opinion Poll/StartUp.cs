using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
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

            foreach (var person in people.OrderBy(p => p.Name).Where(p => p.Age > 30))
            {
                Console.WriteLine($"{person.Name} - {person.Age}");
            }
        }
    }
}
