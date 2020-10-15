using System;
using System.Collections.Generic;

namespace _06GenericCountMethodDouble
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<double> list = new List<double>();

            for (int i = 0; i < n; i++)
            {
                double item = double.Parse(Console.ReadLine());
                list.Add(item);
            }

            double num = double.Parse(Console.ReadLine());
            Console.WriteLine(Box.Comparison(list, num));
        }
    }
}
