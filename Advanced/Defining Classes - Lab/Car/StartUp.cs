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

                var make = carArgsToAdd[0];
                var model = carArgsToAdd[1];
                var year = int.Parse(carArgsToAdd[2]);
                var fuelQuantity = double.Parse(carArgsToAdd[3]);
                var fuelConsumption = double.Parse(carArgsToAdd[4]);
                var engineIndex = int.Parse(carArgsToAdd[5]);
                var tireIndex = int.Parse(carArgsToAdd[6]);

                Car car = new Car(make, model, year, fuelQuantity, fuelConsumption, engines[engineIndex], tires[tireIndex]);

                cars.Add(car);
            }

            cars = cars.Where(c => c.Year >= 2017 && c.Engine.HorsePower > 330 && c.Tires.Sum(t => t.Pressure) >= 9 && c.Tires.Sum(t => t.Pressure) <= 10).ToList();

            foreach (var car in cars)
            {
                car.Drive(20);
                Console.WriteLine(car.WhoAmI());
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
