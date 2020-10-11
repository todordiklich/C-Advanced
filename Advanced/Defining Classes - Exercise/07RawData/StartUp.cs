using System;
using System.Collections.Generic;
using System.Linq;

namespace _07RawData
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

                int engineSpeed = int.Parse(input[1]);
                int enginePower = int.Parse(input[2]);
                Engine engine = new Engine(engineSpeed, enginePower);

                int cargoWeight = int.Parse(input[3]);
                string cargoType = input[4];
                Cargo cargo = new Cargo(cargoWeight, cargoType);

                Tire[] tires = new Tire[4];
                int counter = 0;
                for (int j = 5; j < input.Length; j+=2)
                {
                    double tirePressure = double.Parse(input[j]);
                    int tireAge = int.Parse(input[j + 1]);

                    Tire tire = new Tire(tirePressure, tireAge);
                    tires[counter] = tire;
                    counter++;
                }

                Car car = new Car(model, engine, cargo, tires);

                cars.Add(car);
            }

            string cmd = Console.ReadLine();

            if (cmd == CargoTypeEnum.fragile.ToString())
            {
                cars = cars.Where(c => c.Cargo.Type == cmd && c.Tires.Any(t => t.Pressure < 1)).ToList();
            }
            else if(cmd == CargoTypeEnum.flamable.ToString())
            {
                cars = cars.Where(c => c.Cargo.Type == cmd && c.Engine.EnginePower > 250).ToList();
            }

            cars.ForEach(c => Console.WriteLine(c.ToString()));
        }
    }
}
