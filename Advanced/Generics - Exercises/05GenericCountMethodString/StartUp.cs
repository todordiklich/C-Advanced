using System;
using System.Collections.Generic;

namespace _05GenericCountMethodString
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<string> list = new List<string>();

            for (int i = 0; i < n; i++)
            {
                string item = Console.ReadLine();
                list.Add(item);
            }

            string str = Console.ReadLine();
            Console.WriteLine(Box.Comparison(list, str));
        }
    }
}
