using System;

using EasterRaces.Utilities.Messages;
using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Models.Drivers
{
    public class Driver : IDriver
    {
        private string name;
        private ICar car;
        private int numberOfWins;
        private bool canParticipate;

        public Driver(string name)
        {
            this.Name = name;
            this.CanParticipate = false;
            this.NumberOfWins = 0;
        }

        public string Name
        {
            get { return this.name; }
            private set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 5)
                {
                    throw new ArgumentException(String.Format(ExceptionMessages.InvalidName, value, 5));
                }

                this.name = value;
            }
        }

        public ICar Car 
        {
            get { return this.car; }
            private set
            {
                this.car = value;
            }
        }

        public int NumberOfWins
        {
            get { return this.numberOfWins; }
            private set
            {
                this.numberOfWins = value;
            }
        }

        public bool CanParticipate
        {
            get { return this.canParticipate; }
            private set
            {
                this.canParticipate = value;
            }
        }

        public void AddCar(ICar car)
        {
            if (car == null)
            {
                throw new ArgumentNullException(ExceptionMessages.CarInvalid);
            }

            this.Car = car;
            this.CanParticipate = true;
        }

        public void WinRace()
        {
            this.numberOfWins++;
        }
    }
}
