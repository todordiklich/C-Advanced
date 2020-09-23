using System;
using System.Linq;

namespace _7._Knight_Game
{
    class Program
    {
        private static int knightsRemoved = 0;
        private static int maxKnightsInRange = 0;
        private static int maxKnightRow = 0;
        private static int maxKnightCol = 0;
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = CreateMatrix(n, n);

            int currentKnightsInRange;
            do
            {
                currentKnightsInRange = FindKnightWithMostCollisions(n, matrix);

                if (currentKnightsInRange != 0 && ValidateCoordinates(matrix, maxKnightRow, maxKnightCol))
                {
                    matrix[maxKnightRow, maxKnightCol] = '0';
                    knightsRemoved++;
                    maxKnightsInRange = 0;
                }
            } while (currentKnightsInRange != 0);

            Console.WriteLine(knightsRemoved);
        }

        static int FindKnightWithMostCollisions(int n, char[,] matrix)
        {
            int maxCurrentKnightsInRange = 0;

            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    int currentKnightsInRange = 0;

                    if (matrix[row, col] == 'K')
                    {
                        MoveUpLeft(matrix, row, col, ref currentKnightsInRange);
                        MoveUpRight(matrix, row, col, ref currentKnightsInRange);

                        MoveLeftUp(matrix, row, col, ref currentKnightsInRange);
                        MoveLeftDown(matrix, row, col, ref currentKnightsInRange);

                        MoveDownLeft(matrix, row, col, ref currentKnightsInRange);
                        MoveDownRight(matrix, row, col, ref currentKnightsInRange);

                        MoveRightUp(matrix, row, col, ref currentKnightsInRange);
                        MoveRightDown(matrix, row, col, ref currentKnightsInRange);
                    }

                    if (currentKnightsInRange > maxKnightsInRange)
                    {
                        maxKnightsInRange = currentKnightsInRange;
                        maxKnightRow = row;
                        maxKnightCol = col;
                    }
                    if (currentKnightsInRange > maxCurrentKnightsInRange)
                    {
                        maxCurrentKnightsInRange = currentKnightsInRange;
                    }
                }
            }

            return maxCurrentKnightsInRange;
        }

        static void MoveUpLeft(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row - 2;
            int resultCol = col - 1;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }
        static void MoveUpRight(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row - 2;
            int resultCol = col + 1;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }

        static void MoveLeftUp(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row - 1;
            int resultCol = col - 2;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }
        static void MoveLeftDown(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row + 1;
            int resultCol = col - 2;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }

        static void MoveDownLeft(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row + 2;
            int resultCol = col - 1;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }
        static void MoveDownRight(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row + 2;
            int resultCol = col + 1;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }

        static void MoveRightUp(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row - 1;
            int resultCol = col + 2;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }
        static void MoveRightDown(char[,] matrix, int row, int col, ref int currentKnightsInRange)
        {
            int resultRow = row + 1;
            int resultCol = col + 2;
            ChaeckForCollision(matrix, resultRow, resultCol, ref currentKnightsInRange);
        }

        static void ChaeckForCollision(char[,] matrix, int resultRow, int resultCol, ref int currentKnightsInRange)
        {
            if (ValidateCoordinates(matrix, resultRow, resultCol))
            {
                if (matrix[resultRow, resultCol] == 'K')
                {
                    currentKnightsInRange++;
                }
            }
        }

        static char[,] CreateMatrix(int rows, int cols)
        {
            char[,] matrix = new char[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string figures = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = figures[col];
                }
            }

            return matrix;
        }

        static bool ValidateCoordinates(char[,] matrix, int row, int col)
        {
            bool areValid = true;

            if (row < 0 || row >= matrix.GetLength(0) ||
                col < 0 || col >= matrix.GetLength(1))
            {
                areValid = false;
            }

            return areValid;
        }
    }
}
