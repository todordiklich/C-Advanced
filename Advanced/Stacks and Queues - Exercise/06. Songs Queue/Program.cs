using System;
using System.Collections.Generic;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> queue = new Queue<string>(songs);

            while (true)
            {
                string command = Console.ReadLine();

                if (command.Contains("Add"))
                {
                    string song = command.Substring(4);

                    if (queue.Contains(song))
                    {
                        Console.WriteLine($"{song} is already contained!");
                    }
                    else
                    {
                        queue.Enqueue(song);
                    }
                }
                else if (command == "Play")
                {
                    queue.Dequeue();
                }
                else if (command == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }

                if (queue.Count == 0)
                {
                    Console.WriteLine("No more songs!");
                    break;
                }
            }
        }
    }
}
