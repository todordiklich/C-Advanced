using System;

namespace Prototype
{
    class Program
    {
        static void Main(string[] args)
        {
            var sandwich = new Sandwich("bread", "meat", "cheese", "veggies");
            var sandwich2 = sandwich.Clone() as Sandwich;

            Console.WriteLine(sandwich.Bread == sandwich2.Bread);
        }
    }
}
