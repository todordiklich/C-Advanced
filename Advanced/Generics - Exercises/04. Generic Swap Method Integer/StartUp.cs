using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Generic_Swap_Method_Integer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                int item = int.Parse(Console.ReadLine());
                list.Add(item);
            }

            int[] cmdArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Box<int> box = new Box<int>(list);
            box.Swap(cmdArgs[0], cmdArgs[1]);

            Console.WriteLine(box);
        }
    }
}
