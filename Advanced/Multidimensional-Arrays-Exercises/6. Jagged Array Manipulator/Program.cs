using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        private static int number = 2;
        static void Main(string[] args)
        {
            double[][] jagged = CreateJagged();

            AnalizeJagged(jagged);

            while (true)
            {
                string[] cmdArgs = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();
                string command = cmdArgs[0].ToLower();
                if (command == "end")
                {
                    break;
                }

                if (cmdArgs.Length == 4)
                {
                    int row = int.Parse(cmdArgs[1]);
                    int col = int.Parse(cmdArgs[2]);
                    int value = int.Parse(cmdArgs[3]);

                    if (ValidateRowAndCol(jagged, row, col))
                    {
                        if (command == "add")
                        {
                            jagged[row][col] += value;
                        }
                        else if (command == "subtract")
                        {
                            jagged[row][col] -= value;
                        }
                    }
                }
            }

            Print(jagged);
        }

        static void AnalizeJagged(double[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0) - 1; row++)
            {
                if (jagged[row].GetLength(0) == jagged[row + 1].GetLength(0))
                {
                    for (int col = 0; col < jagged[row].GetLength(0); col++)
                    {
                        jagged[row][col] *= number;
                        jagged[row + 1][col] *= number;
                    }
                }
                else
                {
                    for (int col = 0; col < jagged[row].GetLength(0); col++)
                    {
                        jagged[row][col] /= number;
                    }
                    for (int col = 0; col < jagged[row + 1].GetLength(0); col++)
                    {
                        jagged[row + 1][col] /= number;
                    }
                }
            }
        }

        static bool ValidateRowAndCol(double[][] jagged, int row, int col)
        {
            bool areValid = true;
            if (row < 0 || row >= jagged.GetLength(0) ||
                col < 0 || col >= jagged[row].GetLength(0))
            {
                areValid = false;
            }

            return areValid;
        }

        static double[][] CreateJagged()
        {
            int n = int.Parse(Console.ReadLine());

            double[][] jagged = new double[n][];

            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                int[] array = Console
                    .ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse).ToArray();

                jagged[row] = new double[array.Length];

                for (int col = 0; col < array.Length; col++)
                {
                    jagged[row][col] = array[col];
                }
            }

            return jagged;
        }

        static void Print(double[][] jagged)
        {
            for (int row = 0; row < jagged.GetLength(0); row++)
            {
                for (int col = 0; col < jagged[row].GetLength(0); col++)
                {
                    Console.Write(jagged[row][col] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
