using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Car_Salesman
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Engine> engines = new List<Engine>();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Engine engine = null;
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string power = input[1];

                if (input.Length == 4)
                {
                    int displacement = int.Parse(input[2]);
                    string efficiency = input[3];
                    engine = new Engine(model, power, displacement, efficiency);
                }
                else if (input.Length == 3)
                {
                    int displacement;
                    bool isDisplacement = int.TryParse(input[2], out displacement);

                    if (isDisplacement)
                    {
                        engine = new Engine(model, power, displacement);
                    }
                    else
                    {
                        engine = new Engine(model, power, 0, input[2]);
                    }
                }
                else
                {
                    engine = new Engine(model, power);
                }

                engines.Add(engine);
            }

            List<Car> cars = new List<Car>();
            int m = int.Parse(Console.ReadLine());
            for (int i = 0; i < m; i++)
            {
                Car car = null;

                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string model = input[0];
                string engineModel = input[1];
                Engine engine = engines.FirstOrDefault(e => e.Model == engineModel);

                if (input.Length == 4)
                {
                    int weight = int.Parse(input[2]);
                    string color = input[3];
                    car = new Car(model, engine, weight, color);
                }
                else if (input.Length == 3)
                {
                    int weight;
                    bool isWeight = int.TryParse(input[2], out weight);

                    if (isWeight)
                    {
                        car = new Car(model, engine, weight);
                    }
                    else
                    {
                        car = new Car(model, engine, 0, input[2]);
                    }
                }
                else
                {
                    car = new Car(model, engine);
                }

                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine(car.ToString());
            }
        }
    }
}
