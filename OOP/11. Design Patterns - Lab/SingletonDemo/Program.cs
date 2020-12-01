using System;

using SingletonDemo.Models;

namespace SingletonDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Singleton class demo
            var db = SingletonDataContainer.Instance;
            var db2 = SingletonDataContainer.Instance;
            var db3 = SingletonDataContainer.Instance;

            Console.WriteLine(db.GetPopulation("Gabrovo"));
            Console.WriteLine(db2.GetPopulation("Sevlievo"));
            Console.WriteLine(db3.GetPopulation("Sofia"));

            //Static class demo
            StaticDemo.Number = 5;
            Console.WriteLine(StaticDemo.Number);
        }
    }
}
