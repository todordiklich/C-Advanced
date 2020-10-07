using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int, int[], List<int>> resultFunc = (n, dividers) =>
              {
                  List<int> result = new List<int>();

                  for (int i = 1; i <= n; i++)
                  {
                      bool isDivisilbe = true;

                      foreach (var divider in dividers)
                      {
                          if (i % divider != 0)
                          {
                              isDivisilbe = false;
                              break;
                          }
                      }

                      if (isDivisilbe)
                      {
                          result.Add(i);
                      }
                  }

                  return result;
              };

            List<int> result = resultFunc(n, dividers);

            Console.WriteLine(string.Join(" ", result));
        }
    }
}
