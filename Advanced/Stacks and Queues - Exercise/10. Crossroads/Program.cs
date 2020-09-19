using System;
using System.Collections.Generic;

namespace _10._Crossroads
{
    class Program
    {
        static void Main(string[] args)
        {
            int seconds = int.Parse(Console.ReadLine());
            int freeWindow = int.Parse(Console.ReadLine());

            Queue<string> cars = new Queue<string>();

            int totalCarsPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "END")
                {
                    break;
                }
                else if (command == "green")
                {
                    int currSeconds = seconds;
                    int currFreeWindow = freeWindow;
                    int currentNumOfCarsPassed = 0;

                    foreach (var car in cars)
                    {
                        if (currSeconds > 0)
                        {
                            foreach (var ch in car)
                            {
                                if (currSeconds > 0)
                                {
                                    currSeconds--;
                                }
                                else if (currSeconds == 0 && currFreeWindow > 0)
                                {
                                    currFreeWindow--;
                                }
                                else
                                {
                                    Console.WriteLine("A crash happened!");
                                    Console.WriteLine($"{car} was hit at {ch}.");
                                    return;
                                }
                            }

                            totalCarsPassed++;
                            currentNumOfCarsPassed++;
                        }
                    }

                    for (int i = 0; i < currentNumOfCarsPassed; i++)
                    {
                        cars.Dequeue();
                    }
                }
                else
                {
                    cars.Enqueue(command);
                }
            }

            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{totalCarsPassed} total cars passed the crossroads.");
        }
    }
}
