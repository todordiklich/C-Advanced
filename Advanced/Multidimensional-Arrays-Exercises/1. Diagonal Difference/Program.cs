using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = CreateMatrix(n, n);
            int sumPrimaryDiagonal = PrimaryDiagonal(matrix);
            int sumSecondaryDiagonal = SecondaryyDiagonal(matrix);

            Console.WriteLine(Math.Abs(sumPrimaryDiagonal - sumSecondaryDiagonal));
        }

        static int PrimaryDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, i];
            }

            return sum;
        }

        static int SecondaryyDiagonal(int[,] matrix)
        {
            int sum = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                sum += matrix[i, matrix.GetLength(0) - i - 1];
            }

            return sum;
        }

        static int[,] CreateMatrix(int rows, int cols)
        {
            int[,] matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                int[] arr = Console.ReadLine().Split().Select(int.Parse).ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = arr[col];
                }
            }

            return matrix;
        }
    }
}
