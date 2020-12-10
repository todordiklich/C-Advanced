namespace EasterRaces.Models.Cars
{
    public class MuscleCar : Car
    {
        public MuscleCar(string model, 
                         int horsePower, 
                         double cubicCentimeters = 5000, 
                         int minHorsePower = 400, 
                         int maxHorsePower = 600) 
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        { }
    }
}
