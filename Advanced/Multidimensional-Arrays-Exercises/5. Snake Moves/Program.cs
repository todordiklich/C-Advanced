using System;
using System.Linq;

namespace _5._Snake_Moves
{
    class Program
    {
        private static int i = 0;
        static void Main(string[] args)
        {
            int[] input = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = new string[rows, cols];

            string text = Console.ReadLine();

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        FillMatrix(matrix, text, row, col);
                    }
                }
                else
                {
                    for (int col = matrix.GetLength(1) - 1; col >= 0; col--)
                    {
                        FillMatrix(matrix, text, row, col);
                    }
                }

                PrintRow(matrix, row);
            }
        }

        static void FillMatrix(string[,] matrix, string text, int row, int col)
        {
            matrix[row, col] = text[i].ToString();

            if (i + 1 >= text.Length)
            {
                i = 0;
            }
            else
            {
                i++;
            }
        }

        static void PrintRow(string[,] matrix, int row)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write(matrix[row, col]);
            }
            Console.WriteLine();
        }
    }
}
