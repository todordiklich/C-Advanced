using System;
using System.Linq;

namespace _3._Maximal_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int rows = input[0];
            int cols = input[1];

            int[,] matrix = CreateMatrix(rows, cols);

            int maxSum = 0;
            int maxRow = 0;
            int maxCol = 0;

            for (int row = 0; row < matrix.GetLength(0) - 2; row++)
            {
                for (int col = 0; col < matrix.GetLength(1) - 2; col++)
                {
                    int currSum = SumCurrent(matrix, row, col);
                    if (currSum > maxSum)
                    {
                        maxSum = currSum;
                        maxRow = row;
                        maxCol = col;
                    }
                }
            }

            Console.WriteLine("Sum = " + maxSum);
            PrintMatrix(matrix, maxRow, maxCol);
        }


        static int SumCurrent(int[,] matrix, int row, int col)
        {
            int sum = 0;

            for (int i = row; i < row + 3; i++)
            {
                for (int j = col; j < col + 3; j++)
                {
                    sum += matrix[i, j];
                }
            }

            return sum;
        }

        static void PrintMatrix(int[,] matrix, int startRow, int startCol)
        {
            for (int row = startRow; row < startRow + 3; row++)
            {
                for (int col = startCol; col < startCol + 3; col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }
                Console.WriteLine();
            }
        }

        static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] arr = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
    }
}
