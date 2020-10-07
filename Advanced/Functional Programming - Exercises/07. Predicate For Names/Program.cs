using System;
using System.Linq;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int l = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine().Split().Where(n => n.Length <= l).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
