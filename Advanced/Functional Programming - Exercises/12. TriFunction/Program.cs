using System;
using System.Linq;

namespace _12._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int limit = int.Parse(Console.ReadLine());
            string[] names = Console.ReadLine().Split();

            Func<string, int, bool> filterFunc = (name, limit) =>
            {
                if (name.ToCharArray().Sum(c => c) >= limit)
                {
                    return true;
                }

                return false;
            };

            foreach (var name in names)
            {
                if (filterFunc(name, limit))
                {
                    Console.WriteLine(name);
                    break;
                }
            }
        }
    }
}
