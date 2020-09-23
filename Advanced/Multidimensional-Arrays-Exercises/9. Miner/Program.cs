using System;
using System.Linq;

namespace _9._Miner
{
    class Program
    {
        private static int currRow;
        private static int currCol;
        private static int totalCoals;

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string[] directions = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);
            char[,] matrix = CreateMatrix(n, n);

            GetStartingPosition(matrix);
            totalCoals = GetTotalCoalsNumber(matrix);

            for (int i = 0; i < directions.Length; i++)
            {
                if (directions[i] == "left")
                {
                    StepOnCell(currRow, currCol - 1, matrix);
                }
                else if (directions[i] == "right")
                {
                    StepOnCell(currRow, currCol + 1, matrix);
                }
                else if (directions[i] == "up")
                {
                    StepOnCell(currRow - 1, currCol, matrix);
                }
                else if (directions[i] == "down")
                {
                    StepOnCell(currRow + 1, currCol, matrix);
                }
            }

            Console.WriteLine($"{totalCoals} coals left. ({currRow}, {currCol})");
        }

        static char[,] CreateMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                char[] arr = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }

        static bool ValidateCoordinates(int row, int col, char[,] matrix)
        {
            bool areInside = true;

            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                areInside = false;
            }

            return areInside;
        }

        static int GetTotalCoalsNumber(char[,] matrix)
        {
            int coals = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'c')
                    {
                        coals++;
                    }
                }
            }

            return coals;
        }

        static void GetStartingPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 's')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
        }

        static void StepOnCell(int row, int col, char[,] matrix)
        {
            if (ValidateCoordinates(row, col, matrix))
            {
                currRow = row;
                currCol = col;

                if (matrix[row, col] == 'c')
                {
                    matrix[row, col] = '*';
                    totalCoals--;

                    if (totalCoals == 0)
                    {
                        Console.WriteLine($"You collected all coals! ({currRow}, {currCol})");

                        Environment.Exit(0);
                    }
                }
                else if (matrix[row, col] == 'e')
                {
                    Console.WriteLine($"Game over! ({currRow}, {currCol})");

                    Environment.Exit(0);
                }
            }
        }
    }
}
