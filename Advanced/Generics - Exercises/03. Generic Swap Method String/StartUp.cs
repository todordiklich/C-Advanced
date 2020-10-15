using _02._Generic_Box_of_Integer;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Generic_Swap_Method_String
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                list.Add(item);
            }

            int[] cmdArgs = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Box<string> box = new Box<string>(list);
            box.Swap(cmdArgs[0], cmdArgs[1]);

            Console.WriteLine(box);
        }
    }
}
