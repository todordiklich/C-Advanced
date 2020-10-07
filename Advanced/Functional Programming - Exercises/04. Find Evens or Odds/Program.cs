using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int startNumber = nums[0];
            int endNumber = nums[1];

            string condition = Console.ReadLine();

            Func<int, int, List<int>> createListFunc = (x, y) =>
             {
                 List<int> numbers = new List<int>();

                 for (int i = x; i <= y; i++)
                 {
                     numbers.Add(i);
                 }

                 return numbers;
             };
            List<int> result = createListFunc(startNumber, endNumber);

            Action<int> printer = n => Console.Write(n + " ");
            Predicate<int> conditionFunc = GetCondition(condition);


            PrintFilteredNumbers(result, printer, conditionFunc);
        }

        static Predicate<int> GetCondition(string condition)
        {
            switch (condition)
            {
                case "odd":
                    return n => n % 2 != 0;
                case "even":
                    return n => n % 2 == 0;
                default:
                    return null;
            }
        }

        static void PrintFilteredNumbers(List<int> numbers, Action<int> printer, Predicate<int> filter)
        {
            foreach (var number in numbers)
            {
                if (filter(number))
                {
                    printer(number);
                }
            }
        }
    }
}
