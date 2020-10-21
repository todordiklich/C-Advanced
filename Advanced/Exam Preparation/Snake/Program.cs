using System;

namespace Snake
{
    class Program
    {
        private static int foodEaten = 0;
        private static int[] currPosition = new int[2];
        private static int[] newPosition = new int[2];
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            char[,] matrix = new char[n, n];

            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }
            // finding the starting position
            FindStartPosition(matrix);
            
            while (true)
            {                
                string cmd = Console.ReadLine();

                if (cmd == "up")
                {
                    newPosition[0] = currPosition[0] - 1;
                    newPosition[1] = currPosition[1];
                }
                else if (cmd == "down")
                {
                    newPosition[0] = currPosition[0] + 1;
                    newPosition[1] = currPosition[1];
                }
                else if (cmd == "left")
                {
                    newPosition[0] = currPosition[0];
                    newPosition[1] = currPosition[1] - 1;
                }
                else if (cmd == "right")
                {
                    newPosition[0] = currPosition[0];
                    newPosition[1] = currPosition[1] + 1;
                }
                // leave trail
                matrix[currPosition[0], currPosition[1]] = '.';

                // check if the snake is outside the field
                if (CheckIfOutsideMatrix(newPosition[0], newPosition[1], matrix))
                {
                    Console.WriteLine("Game over!");
                    break;
                }
                // check if snake step on special symbol
                CheckIfSnakeStepOnSpecialSymbol(newPosition[0], newPosition[1], matrix);

                if (foodEaten >= 10)
                {
                    Console.WriteLine("You won! You fed the snake.");
                    break;
                }
            }

            Console.WriteLine($"Food eaten: {foodEaten}");
            PrintMatrix(matrix);
        }

        private static void CheckIfSnakeStepOnSpecialSymbol(int row, int col, char[,] matrix)
        {
            if (matrix[row,col] == '*')
            {
                foodEaten++;
            }
            else if (matrix[row,col] == 'B')
            {
                FindOtherGate(matrix);
            }

            currPosition[0] = newPosition[0];
            currPosition[1] = newPosition[1];

            matrix[currPosition[0], currPosition[1]] = 'S';
        }

        private static void FindOtherGate(char[,] matrix)
        {
            char searchedSymbol = 'B';
            matrix[newPosition[0], newPosition[1]] = '.';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == searchedSymbol)
                    {
                        newPosition[0] = i;
                        newPosition[1] = j;
                        return;
                    }
                }
            }
        }

        private static bool CheckIfOutsideMatrix(int row, int col, char[,] matrix)
        {
            if (row < 0 || row >= matrix.GetLength(0) 
                || col < 0 || col >= matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static void FindStartPosition(char[,] matrix)
        {
            char searchedSymbol = 'S';

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i,j] == searchedSymbol)
                    {
                        currPosition[0] = i;
                        currPosition[1] = j;
                        return;
                    }
                }
            }
        }

        static void PrintMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j]);
                }
                Console.WriteLine();
            }
        }
    }
}
