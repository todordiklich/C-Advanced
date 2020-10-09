using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace _08._Car_Salesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight = 0, string color = "n/a")
        {
            Model = model;
            Engine = engine;
            Weight = weight;
            Color = color;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{Model}:")
                .AppendLine($"{Engine.ToString()}")
                .AppendLine($"  Weight: {(Weight != 0 ? Weight.ToString() : "n/a")}")
                .AppendLine($"  Color: {Color}");

            return sb.ToString().TrimEnd();
        }
    }
}
