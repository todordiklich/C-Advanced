using System;
using System.Collections.Generic;
using System.Linq;

namespace Vehicles
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Vehicle> vehicles = new List<Vehicle>();

            for (int i = 0; i < 3; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string type = cmdArgs[0];
                double liters = double.Parse(cmdArgs[1]);
                double consumption = double.Parse(cmdArgs[2]);
                double tankCapacity = double.Parse(cmdArgs[3]);

                Vehicle vehicle;
                if (type == "Car")
                {
                    vehicle = new Car(liters, consumption, tankCapacity);
                }
                else if (type == "Truck")
                {
                    vehicle = new Truck(liters, consumption, tankCapacity);
                }
                else
                {
                    vehicle = new Bus(liters, consumption, tankCapacity);
                }

                vehicles.Add(vehicle);
            }
            

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];
                string type = cmdArgs[1];
                double argument = double.Parse(cmdArgs[2]);

                Vehicle vehicle = vehicles.FirstOrDefault(v => v.GetType().Name == type);
                if (command == "Drive")
                {
                    vehicle.Drive(argument);
                }
                else if (command == "DriveEmpty")
                {
                    ((Bus)vehicle).DriveEmpty(argument);
                }
                else
                {
                    vehicle.Refuel(argument);
                }
            }

            vehicles.ForEach(v => Console.WriteLine(v));
        }
    }
}
