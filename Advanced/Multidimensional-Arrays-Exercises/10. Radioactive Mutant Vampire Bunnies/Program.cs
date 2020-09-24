using System;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        private static int currRow;
        private static int currCol;
        private static bool hasWon = false;
        private static bool hasDied = false;
        static void Main(string[] args)
        {
            int[] input = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int rows = input[0];
            int cols = input[1];

            char[,] matrix = CreateMatrix(rows, cols);
            GetStartingPosition(matrix);
            string directions = Console.ReadLine();

            for (int i = 0; i < directions.Length; i++)
            {
                // move player
                matrix[currRow, currCol] = '.';

                if (directions[i] == 'L')
                {
                    MovePlayer(currRow, currCol - 1, matrix);
                }
                else if (directions[i] == 'R')
                {
                    MovePlayer(currRow, currCol + 1, matrix);
                }
                else if (directions[i] == 'U')
                {
                    MovePlayer(currRow - 1, currCol, matrix);
                }
                else if (directions[i] == 'D')
                {
                    MovePlayer(currRow + 1, currCol, matrix);
                }

                //spread bunnies

                //check if player won/died
                if (hasWon)
                {
                    Console.WriteLine($"won: {currRow} {currCol}");
                    break;
                }
                if (hasDied)
                {
                    Console.WriteLine($"dead: {currRow} {currCol}");
                    break;
                }
            }
        }

        static char[,] CreateMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string elements = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = elements[col];
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

        static void GetStartingPosition(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'P')
                    {
                        currRow = row;
                        currCol = col;
                    }
                }
            }
        }

        static void MovePlayer(int row, int col, char[,] matrix)
        {
            if (ValidateCoordinates(row, col, matrix))
            {
                if (matrix[row, col] != 'B')
                {
                    currRow = row;
                    currCol = col;
                    matrix[currRow, currCol] = 'P';
                }
                else
                {
                    hasDied = true;
                }
            }
            else
            {
                hasWon = true;
            }
        }
    }
}
