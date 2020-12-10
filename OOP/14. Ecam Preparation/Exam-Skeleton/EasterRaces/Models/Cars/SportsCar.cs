namespace EasterRaces.Models.Cars
{
    public class SportsCar : Car
    {
        public SportsCar(string model, 
                         int horsePower, 
                         double cubicCentimeters = 3000, 
                         int minHorsePower = 250, 
                         int maxHorsePower = 450) 
            : base(model, horsePower, cubicCentimeters, minHorsePower, maxHorsePower)
        { }
    }
}
