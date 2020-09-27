using System;
using System.Collections.Generic;

namespace _06._Parking_Lot
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<string> parking = new HashSet<string>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command.ToLower() == "end")
                {
                    break;
                }

                string[] cmadArgs = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
                string direction = cmadArgs[0];
                string car = cmadArgs[1];


                if (direction.ToLower() == "in")
                {
                    parking.Add(car);
                }
                else
                {
                    if (parking.Contains(car))
                    {
                        parking.Remove(car);
                    }
                }
            }

            if (parking.Count > 0)
            {
                foreach (var car in parking)
                {
                    Console.WriteLine(car);
                }
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
