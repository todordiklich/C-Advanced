using System;
using System.Linq;

namespace _4._Symbol_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = CreateMatrix(n, n);
            char symbolToSearch = char.Parse(Console.ReadLine());

            int searchedRow = 0;
            int searchedCol = 0;
            bool isFound = false;

            for (int row = 0; row < n; row++)
            {
                if (!isFound)
                {
                    for (int col = 0; col < n; col++)
                    {
                        if (matrix[row, col] == symbolToSearch)
                        {
                            searchedRow = row;
                            searchedCol = col;
                            isFound = true;
                        }
                    }
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(isFound == true
                ? $"({searchedRow}, {searchedCol})"
                : $"{symbolToSearch} does not occur in the matrix");

        }

        private static char[,] CreateMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                string symbols = Console.ReadLine();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = symbols[col];
                }
            }

            return matrix;
        }
    }
}
