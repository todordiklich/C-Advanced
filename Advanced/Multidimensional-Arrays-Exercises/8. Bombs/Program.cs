using System;
using System.Linq;

namespace _8._Bombs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(n, n);

            string[] bombs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < bombs.Length; i++)
            {
                int[] bombCoordinates = bombs[i].Split(',', StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                int bombRow = bombCoordinates[0];
                int bombCol = bombCoordinates[1];

                // destroing cells in the matrix
                if (ValidateCoordinates(bombRow, bombCol, matrix) && matrix[bombRow, bombCol] > 0)
                {
                    int bombValue = matrix[bombRow, bombCol];
                    matrix[bombRow, bombCol] = 0;
                    for (int r = bombRow - 1; r < bombRow + 2; r++)
                    {
                        for (int c = bombCol - 1; c < bombCol + 2; c++)
                        {
                            if (ValidateCoordinates(r, c, matrix) && matrix[r, c] > 0)
                            {
                                matrix[r, c] -= bombValue;
                            }
                        }
                    }
                }
            }

            // searching for alive cells
            int aliveSum = 0;
            int numberOfAliveCells = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] > 0)
                    {
                        aliveSum += matrix[row, col];
                        numberOfAliveCells++;
                    }
                }
            }

            Console.WriteLine($"Alive cells: {numberOfAliveCells}");
            Console.WriteLine($"Sum: {aliveSum}");
            PrintMatrix(matrix);
        }

        static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] arr = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }

        static void PrintMatrix(int[,] matrix)
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

        static bool ValidateCoordinates(int row, int col, int[,] matrix)
        {
            bool areInside = true;

            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                areInside = false;
            }

            return areInside;
        }
    }
}
