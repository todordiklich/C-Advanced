﻿using System.Text;

namespace Cars.Contracts
{
    public abstract class Car : ICar
    {
        public Car(string model, string color)
        {
            this.Model = model;
            this.Color = color;
        }
        public string Model { get; private set; }

        public string Color { get; private set; }

        public string Start()
        {
            return "Engine start";
        }

        public string Stop()
        {
            return "Breaaak!";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"{this.Color} {this.GetType().Name} {this.Model}")
                .AppendLine(this.Start())
                .AppendLine(this.Stop());

            return sb.ToString().TrimEnd();
        }
    }
}
