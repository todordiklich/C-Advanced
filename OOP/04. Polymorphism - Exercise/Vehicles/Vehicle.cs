using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double litersPerKm, double tankCapacity)
        {
            this.FuleQuantity = fuelQuantity > tankCapacity ? 0 : fuelQuantity;
            this.LitersPerKm = litersPerKm;
            this.TankCapacity = tankCapacity;
        }

        public virtual double AdditionalConsumption { get; protected set; }
        public double FuleQuantity { get; protected set; }
        public double LitersPerKm { get; protected set; }
        public double TankCapacity { get; protected set; }

        public virtual void Drive(double distance)
        {
            double neededFuel = distance * (this.LitersPerKm + AdditionalConsumption);

            if (neededFuel > this.FuleQuantity)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
            }
            else
            {
                this.FuleQuantity -= neededFuel;
                Console.WriteLine($"{this.GetType().Name} travelled {distance} km");

            }
        }
        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else
            {
                double totalLiters = this.FuleQuantity + liters;

                if (totalLiters > this.TankCapacity)
                {
                    Console.WriteLine($"Cannot fit {liters} fuel in the tank");
                }
                else
                {
                    this.FuleQuantity = totalLiters;
                }
            }
            
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuleQuantity:F2}";
        }
    }
}
