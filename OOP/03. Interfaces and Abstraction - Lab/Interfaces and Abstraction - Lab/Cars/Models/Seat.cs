using Cars.Contracts;

namespace Cars.Models
{
    public class Seat : Car
    {
        public Seat(string model, string color) 
            : base(model, color)
        {
        }
    }
}
