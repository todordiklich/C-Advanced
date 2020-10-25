using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Garden
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] rowsCols = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int N = rowsCols[0];
            int M = rowsCols[1];

            int[,] garden = new int[N, M];

            List<int[]> savedCoordinates = new List<int[]>();

            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Bloom Bloom Plow")
                {
                    break;
                }

                int[] coordinates = input.Split().Select(int.Parse).ToArray();
                int row = coordinates[0];
                int col = coordinates[1];

                if (row < 0 || row >= garden.GetLength(0) || col < 0 || col >= garden.GetLength(1))
                {
                    Console.WriteLine("Invalid coordinates.");
                }
                else
                {
                    savedCoordinates.Add(coordinates);
                    garden[row, col] = 1;
                }
            }

            BloomFlowers(garden, savedCoordinates);
            PrintGarden(garden);
        }

        private static void PrintGarden(int[,] garden)
        {
            for (int row = 0; row < garden.GetLength(0); row++)
            {
                for (int col = 0; col < garden.GetLength(1); col++)
                {
                    Console.Write(garden[row,col] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void BloomFlowers(int[,] garden, List<int[]> savedCoordinates)
        {
            for (int i = 0; i < savedCoordinates.Count; i++)
            {
                int currRow = savedCoordinates[i][0];
                int currCol = savedCoordinates[i][1];

                for (int r = 1; r < garden.GetLength(0); r++)
                {
                    // Up
                    if (currRow - r >= 0)
                    {
                        garden[currRow - r, currCol]++;
                    }
                    // Down
                    if (currRow + r < garden.GetLength(0))
                    {
                        garden[currRow + r, currCol]++;
                    }
                   
                }

                for (int c = 1; c < garden.GetLength(1); c++)
                {
                    // Left
                    if (currCol - c >= 0)
                    {
                        garden[currRow, currCol - c]++;
                    }
                    // Right
                    if (currCol + c < garden.GetLength(1))
                    {
                        garden[currRow, currCol + c]++;
                    }
                }
            }
        }
    }
}
