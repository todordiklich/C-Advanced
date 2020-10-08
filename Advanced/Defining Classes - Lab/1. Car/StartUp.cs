using System;
using System.Linq;
using System.Collections.Generic;

namespace CarManufacturer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> tiresArgs = GetParameters();
            List<string> engineArgs = GetParameters();
            List<string> carArgs = GetParameters();

            List<Tire[]> tires = new List<Tire[]>();
            for (int i = 0; i < tiresArgs.Count; i++)
            {
                string[] arguments = tiresArgs[i].Split();
                Tire[] tiresToAdd = new Tire[arguments.Length / 2];

                for (int j = 0; j < arguments.Length; j += 2)
                {
                    tiresToAdd[j / 2] = new Tire(int.Parse(arguments[j]), double.Parse(arguments[j + 1]));
                }

                tires.Add(tiresToAdd);
            }

            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < engineArgs.Count; i++)
            {
                string[] engineToAdd = engineArgs[i].Split();
                Engine engine = new Engine(int.Parse(engineToAdd[0]), double.Parse(engineToAdd[1]));
                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            for (int i = 0; i < carArgs.Count; i++)
            {
                string[] carArgsToAdd = carArgs[i].Split();
                Car car = new Car(carArgsToAdd[0], carArgsToAdd[1], int.Parse(carArgsToAdd[2]), double.Parse(carArgsToAdd[3]), double.Parse(carArgsToAdd[4]), engines[i], tires[i]);

                cars.Add(car);
            }

            cars.ForEach(c => c.Drive(0.2));
            cars = cars.Where(c => c.Year >= 2017).Where(c => c.Engine.HorsePower > 330).Where(c => c.Tires.Select(t => t.Pressure).Sum() > 9 && c.Tires.Select(t => t.Pressure).Sum() < 10).ToList();

            foreach (var car in cars)
            {
                Console.WriteLine($"Make: {car.Make}");
                Console.WriteLine($"Model: {car.Model}");
                Console.WriteLine($"Year: {car.Year}");
                Console.WriteLine($"HorsePowers: {car.Engine.HorsePower}");
                Console.WriteLine($"FuelQuantity: {car.FuelQuantity:F1}");
            }
        }

        public static List<string> GetParameters()
        {
            List<string> arguments = new List<string>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "Show special")
                {
                    break;
                }
                if (cmd == "Engines done")
                {
                    break;
                }
                if (cmd == "No more tires")
                {
                    break;
                }

                arguments.Add(cmd);
            }

            return arguments;
        }
    }
}
