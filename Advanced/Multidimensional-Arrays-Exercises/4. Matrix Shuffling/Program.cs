using System;
using System.Linq;

namespace _4._Matrix_Shuffling
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            string[,] matrix = CreateMatrix(rows, cols);

            while (true)
            {
                string[] cmdArgs = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                string command = cmdArgs[0];
                if (command.ToLower() == "end")
                {
                    break;
                }
                if (command.ToLower() == "swap" && cmdArgs.Length == 5)
                {
                    int initialRow = int.Parse(cmdArgs[1]);
                    int initialCol = int.Parse(cmdArgs[2]);

                    int toSwapRow = int.Parse(cmdArgs[3]);
                    int toSwapCol = int.Parse(cmdArgs[4]);

                    if (CheckCoordinates(initialRow, initialCol, matrix) &&
                        CheckCoordinates(toSwapRow, toSwapCol, matrix))
                    {
                        var temp = matrix[initialRow, initialCol];
                        matrix[initialRow, initialCol] = matrix[toSwapRow, toSwapCol];
                        matrix[toSwapRow, toSwapCol] = temp;

                        PrintMatrix(matrix);
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }

        static string[,] CreateMatrix(int rows, int cols)
        {
            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] arr = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static bool CheckCoordinates(int row, int col, string[,] matrix)
        {
            bool areInside = true;

            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                areInside = false;
                Console.WriteLine("Invalid input!");
            }

            return areInside;
        }
    }
}
