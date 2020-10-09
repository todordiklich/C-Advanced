using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Speed_Racing
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Car> cars = new List<Car>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string model = input[0];
                double fuelAmount = double.Parse(input[1]);
                double fuelConsumption = double.Parse(input[2]);

                Car car = new Car(model, fuelAmount, fuelConsumption);

                cars.Add(car);
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] cmdArgs = command.Split();
                string model = cmdArgs[1];
                double distance = double.Parse(cmdArgs[2]);

                var car = cars.FirstOrDefault(c => c.Model == model);
                car?.Drive(distance);
            }

            cars.ForEach(c => Console.WriteLine(c.ToString()));
        }
    }
}
