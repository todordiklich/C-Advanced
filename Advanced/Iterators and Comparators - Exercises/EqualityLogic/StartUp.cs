﻿using System;
using System.Collections.Generic;

namespace EqualityLogic
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SortedSet<Person> sortedSet = new SortedSet<Person>();
            HashSet<Person> hashSet = new HashSet<Person>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string name = cmdArgs[0];
                int age = int.Parse(cmdArgs[1]);

                Person person = new Person(name, age);

                if (!sortedSet.Contains(person))
                {
                    sortedSet.Add(person);
                    hashSet.Add(person);
                }
            }

            Console.WriteLine(sortedSet.Count);
            Console.WriteLine(hashSet.Count);
        }
    }
}
