using System;
using System.Linq;

namespace _5._Square_With_Maximum_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];


            int[,] matrix = CreateMatrix(rows, cols);

            int sum = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 1; col++)
                {
                    int currBoxSum = matrix[row, col] + matrix[row, col + 1] + matrix[row + 1, col] + matrix[row + 1, col + 1];
                    if (currBoxSum > sum)
                    {
                        sum = currBoxSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            PrintMatrix(matrix, maxRow, maxCol);
            Console.WriteLine(sum);
        }

        private static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] elements = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = elements[col];
                }
            }

            return matrix;
        }

        private static void PrintMatrix(int[,] matrix, int startRow, int startCol)
        {
            for (int row = startRow; row < startRow+2; row++)
            {
                for (int col = startCol; col < startCol+2; col++)
                {
                    Console.Write(matrix[row,col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
