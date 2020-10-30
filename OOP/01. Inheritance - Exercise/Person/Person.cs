﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Person
{
    public class Person
    {
        private int age;

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }
        //public int Age 
        //{
        //    get 
        //    {
        //        return this.age; 
        //    }

        //    set
        //    {
        //        if (value < 0)
        //        {
        //            throw new ArgumentException();
        //        }

        //        this.age = value;
        //    }
        //}

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(String.Format("Name: {0}, Age: {1}",
                                 this.Name,
                                 this.Age));

            return stringBuilder.ToString();
        }

    }
}
