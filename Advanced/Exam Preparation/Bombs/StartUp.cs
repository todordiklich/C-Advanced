using System;
using System.Linq;
using System.Collections.Generic;

namespace Bombs
{
    public class StartUp
    {
        const int DATURA = 40;
        const int CHERRY = 60;
        const int SMOKE = 120;

        static void Main(string[] args)
        {
            List<int> bombEfects = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            List<int> bombCasing = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Dictionary<int, int> bombs = new Dictionary<int, int>()
            {
                {DATURA, 0},
                {CHERRY, 0},
                {SMOKE, 0}
            };

            bool hasWon = false;
            int currentValue;

            while (bombCasing.Count > 0 && bombEfects.Count > 0)
            {
                if (bombs[DATURA] >= 3 && bombs[CHERRY] >= 3 && bombs[SMOKE] >= 3)
                {
                    hasWon = true;
                    break;
                }

                currentValue = bombEfects[0] + bombCasing[bombCasing.Count - 1];

                if (currentValue == DATURA)
                {
                    bombs[DATURA]++;
                    RemoveFirstBomb(bombEfects);
                    RemoveLastBomb(bombCasing);
                }
                else if (currentValue == CHERRY)
                {
                    bombs[CHERRY]++;
                    RemoveFirstBomb(bombEfects);
                    RemoveLastBomb(bombCasing);
                }
                else if (currentValue == SMOKE)
                {
                    bombs[SMOKE]++;
                    RemoveFirstBomb(bombEfects);
                    RemoveLastBomb(bombCasing);
                }
                else
                {
                    if (bombCasing[bombCasing.Count - 1] <= 0)
                    {
                        RemoveLastBomb(bombCasing);
                    }
                    else
                    {
                        bombCasing[bombCasing.Count - 1] -= 5;
                    }
                }
            }
            Console.WriteLine();
            if (hasWon)
            {
                Console.WriteLine("Bene! You have successfully filled the bomb pouch!");
            }
            else
            {
                Console.WriteLine("You don't have enough materials to fill the bomb pouch.");
            }

            Console.WriteLine($"Bomb Effects: {(bombEfects.Count == 0 ? "empty" : string.Join(", ", bombEfects))}");
            Console.WriteLine($"Bomb Casings: {(bombCasing.Count == 0 ? "empty" : string.Join(", ", bombCasing))}");

            Console.WriteLine($"Cherry Bombs: {bombs[CHERRY]}");
            Console.WriteLine($"Datura Bombs: {bombs[DATURA]}");
            Console.WriteLine($"Smoke Decoy Bombs: {bombs[SMOKE]}");
        }

        private static void RemoveLastBomb(List<int> bombCasing)
        {
            bombCasing.RemoveAt(bombCasing.Count - 1);
        }

        private static void RemoveFirstBomb(List<int> bombEfects)
        {
            bombEfects.RemoveAt(0);
        }
    }
}
