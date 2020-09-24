using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Radioactive_Mutant_Vampire_Bunnies
{
    class Program
    {
        private static int currRow;
        private static int currCol;
        private static bool hasWon = false;
        private static bool hasDied = false;
        private static List<int> bunniesPositions = new List<int>();
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

                //find bunnies positions & spread bunnies
                GetBunniesPositions(matrix);
                SpreadBunnies(matrix);

                //check if player won/died
                if (hasWon)
                {
                    break;
                }
                if (hasDied)
                {
                    break;
                }
            }

            PrintMatrix(matrix);
            Console.WriteLine(hasWon == true ? $"won: {currRow} {currCol}" : $"dead: {currRow} {currCol}");
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void SpreadBunnies(char[,] matrix)
        {
            for (int i = 0; i < bunniesPositions.Count - 1; i += 2)
            {
                int row = bunniesPositions[i];
                int col = bunniesPositions[i + 1];

                //lef
                PlaceBunny(row, col - 1, matrix);
                //right
                PlaceBunny(row, col + 1, matrix);
                //up
                PlaceBunny(row - 1, col, matrix);
                //down
                PlaceBunny(row + 1, col, matrix);
            }
        }

        private static void PlaceBunny(int row, int col, char[,] matrix)
        {
            if (ValidateCoordinates(row, col, matrix))
            {
                if (matrix[row, col] == 'P')
                {
                    hasDied = true;
                }

                matrix[row, col] = 'B';
            }
        }

        static void GetBunniesPositions(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] == 'B')
                    {
                        bunniesPositions.Add(row);
                        bunniesPositions.Add(col);
                    }
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
                currRow = row;
                currCol = col;

                if (matrix[row, col] != 'B')
                {
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
