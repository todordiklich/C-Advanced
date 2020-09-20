using System;
using System.Linq;

namespace _6._Jagged_Array_Modification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[][] jaggedArr = new int[n][];

            for (int row = 0; row < jaggedArr.GetLength(0); row++)
            {
                int[] newArr = Console.ReadLine().Split().Select(int.Parse).ToArray();
                jaggedArr[row] = new int[newArr.Length];

                for (int col = 0; col < newArr.Length; col++)
                {
                    jaggedArr[row][col] = newArr[col];
                }
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }

                string[] cmdArgs = command.Split();
                string cmd = cmdArgs[0];
                int rowToChange = int.Parse(cmdArgs[1]);
                int colToChange = int.Parse(cmdArgs[2]);
                int value = int.Parse(cmdArgs[3]);

                if (rowToChange >= jaggedArr.Length || rowToChange < 0
                    || colToChange >= jaggedArr.Length || colToChange < 0) 
                {
                    Console.WriteLine("Invalid coordinates");
                }
                else
                {
                    if (cmd == "Add")
                    {
                        jaggedArr[rowToChange][colToChange] += value;
                    }
                    else
                    {
                        jaggedArr[rowToChange][colToChange] -= value;
                    }
                }
            }

                PrintMatrix(jaggedArr);
        }

        private static void PrintMatrix(int[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int col = 0; col < matrix[row].Length; col++)
                {
                    Console.Write(matrix[row][col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
