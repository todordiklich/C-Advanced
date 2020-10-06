using System;
using System.Collections.Generic;

namespace _05._Filter_By_Age
{
    class Program
    {
        static void Main(string[] args)
        {

            int n = int.Parse(Console.ReadLine());
            Person[] people = new Person[n];

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(", ");
                string name = input[0];
                int age = int.Parse(input[1]);
                people[i] = new Person(name, age);
            }

            string strCondition = Console.ReadLine();
            int ageCondition = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> condition = GetCondition(strCondition, ageCondition);
            Action<Person> printer = Printer(format);

            PrintFilteredStudents(people, condition, printer);

        }

        private static void PrintFilteredStudents(Person[] people, 
            Func<Person,bool> filter,
            Action<Person> printer)
        {
            foreach (var person in people)
            {
                if (filter(person))
                {
                    printer(person);
                }
            }
        }

        private static Func<Person, bool> GetCondition(string strCondition, int ageCondition)
        {
            switch (strCondition)
            {
                case "younger": return p => p.Age < ageCondition;
                case "older": return p => p.Age >= ageCondition;
                default: return null;
            }
        }

        private static Action<Person> Printer(string format)
        {
            switch (format)
            {
                case "name": return p => Console.WriteLine(p.Name);
                case "age": return p => Console.WriteLine(p.Age);
                case "name age": return p => Console.WriteLine($"{p.Name} - {p.Age}");
                default: return null;
            }
        }
    }
    class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }
        public string Name { get; set; }

        public int Age { get; set; }
    }
}
