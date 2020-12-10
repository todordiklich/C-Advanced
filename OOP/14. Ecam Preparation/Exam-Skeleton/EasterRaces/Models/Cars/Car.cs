using System;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Utilities.Messages;

namespace EasterRaces.Models.Cars
{
    public abstract class Car : ICar
    {
        private string model;
        private int horsePower;
        private double cubicCentimeters;
        private int minHorsePower;
        private int maxHorsePower;

        protected Car(string model, int horsePower, double cubicCentimeters, int minHorsePower, int maxHorsePower)
        {
            this.Model = model;
            this.HorsePower = horsePower;
            this.CubicCentimeters = cubicCentimeters;
            this.MinHorsePower = minHorsePower;
            this.MaxHorsePower = maxHorsePower;
        }

        public int MinHorsePower
        {
            get { return this.minHorsePower; }

            private set
            {
                this.minHorsePower = value;
            }
        }
        public int MaxHorsePower
        {
            get { return this.maxHorsePower; }

            private set
            {
                this.maxHorsePower = value;
            }
        }
        public string Model
        {
            get { return this.model; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 4)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidModel, value, 4));
                }

                this.model = value;
            }
        }

        public int HorsePower
        {
            get { return this.horsePower; }

            private set
            {
                if (value < this.MinHorsePower || value > this.MaxHorsePower)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidHorsePower, value));
                }

                this.horsePower = value;
            }
        }

        public double CubicCentimeters 
        {
            get { return this.cubicCentimeters; }
            private set
            {
                this.cubicCentimeters = value;
            } 
        }

        public double CalculateRacePoints(int laps)
        {
            //cubic centimeters / horsepower * laps
            return this.CubicCentimeters / this.HorsePower * laps;
        }
    }
}
