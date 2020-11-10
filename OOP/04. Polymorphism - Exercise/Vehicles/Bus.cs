namespace Vehicles
{
    public class Bus : Vehicle
    {
        public Bus(double fuelQuantity, double litersPerKm, double tankCapacity) 
            : base(fuelQuantity, litersPerKm, tankCapacity)
        {
        }

        public override double AdditionalConsumption { get; protected set; }

        public override void Drive(double distance)
        {
            this.AdditionalConsumption = 1.4;
            base.Drive(distance);
        }
        public void DriveEmpty(double distance)
        {
            this.AdditionalConsumption = 0;
            base.Drive(distance);
        }
    }
}
