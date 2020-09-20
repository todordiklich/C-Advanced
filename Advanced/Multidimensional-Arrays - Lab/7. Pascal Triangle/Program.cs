using System;

namespace _7._Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            long[][] jagged = new long[n][];

            for (int row = 0; row < n; row++)
            {
                jagged[row] = new long[row + 1];

                jagged[row][0] = 1;
                jagged[row][jagged[row].Length - 1] = 1;

                if (row > 1)
                {
                    for (int col = 1; col < jagged[row].Length - 1; col++)
                    {
                        jagged[row][col] = jagged[row - 1][col - 1] + jagged[row - 1][col];
                    }
                }
            }

            foreach (var arr in jagged)
            {
                Console.WriteLine(String.Join(" ", arr));
            }
        }
    }
}
