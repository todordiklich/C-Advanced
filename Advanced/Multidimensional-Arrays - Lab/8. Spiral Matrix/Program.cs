using System;
using System.Linq;

namespace _8._Spiral_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            string direction = "right";
            int row = 0;
            int col = 0;

            for (int i = 0; i < n*n; i++)
            {
                if (direction == "right")
                {
                    matrix[row,col] = i + 1;
                    col++;
                    if (col == matrix.GetLength(0) || matrix[row,col] != 0)
                    {
                        col--;
                        row++;
                        direction = "down";
                    }
                }
                else if (direction == "down")
                {
                    matrix[row, col] = i + 1;
                    row++;
                    if (row == matrix.GetLength(1) || matrix[row, col] != 0)
                    {
                        row--;
                        col--;
                        direction = "left";
                    }
                }
                else if (direction == "left")
                {
                    matrix[row, col] = i + 1;
                    col--;
                    if (col == -1 || matrix[row, col] != 0)
                    {
                        col++;
                        row--;
                        direction = "up";
                    }
                }
                else if (direction == "up")
                {
                    matrix[row, col] = i + 1;
                    row--;
                    if (row == -1 || matrix[row, col] != 0)
                    {
                        row++;
                        col++;
                        direction = "right";
                    }
                }
            }

            PrintMatrix(matrix);
        }

        
        private static void PrintMatrix(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] < 10)
                    {
                        Console.Write(" " + matrix[row, col] + " ");
                    }
                    else
                    {
                        Console.Write(matrix[row, col] + " ");
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
