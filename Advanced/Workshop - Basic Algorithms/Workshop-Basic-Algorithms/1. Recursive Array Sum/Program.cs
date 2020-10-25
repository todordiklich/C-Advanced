using System;
using System.Linq;

namespace _1._Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] array = new int[] { 1, 2, 3 };

            Console.WriteLine(Sum(array, array.Length));
        }

        private static int Sum(int[] array, int index)
        {
            if (index <= 0)
            {
                return 0;
            }

            int current = Sum(array, index - 1);
            int sum = array[index - 1] + current;

            return sum;
        }
    }
}
