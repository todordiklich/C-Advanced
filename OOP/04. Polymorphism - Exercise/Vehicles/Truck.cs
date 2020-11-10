using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double litersPerKm, double tankCapacity)
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public override double AdditionalConsumption => 1.6;
        public override void Refuel(double liters)
        {
            if (liters + this.FuleQuantity > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {liters} fuel in the tank");
            }
            else
            {
                base.Refuel(liters * 0.95);
            }
        }
    }
}
