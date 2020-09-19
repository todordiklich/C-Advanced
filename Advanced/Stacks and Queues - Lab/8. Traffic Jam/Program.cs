using System;
using System.Collections.Generic;

namespace _8._Traffic_Jam
{
    class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();

            int count = int.Parse(Console.ReadLine());
            int carsPassed = 0;

            while (true)
            {
                string command = Console.ReadLine();

                if (command.ToLower() == "end")
                {
                    break;
                }
                else if (command == "green")
                {
                    for (int i = 0; i < count; i++)
                    {
                        if (queue.Count > 0)
                        {
                            Console.WriteLine($"{queue.Dequeue()} passed!");
                            carsPassed++;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
            }

            Console.WriteLine($"{carsPassed} cars passed the crossroads.");
            
        }
    }
}
