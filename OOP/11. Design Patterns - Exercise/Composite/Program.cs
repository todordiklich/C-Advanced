using System;

namespace Composite
{
    class Program
    {
        static void Main(string[] args)
        {
            var box = new CompositeGift("Box", 0);

            var truckToy = new SingleGift("Truck", 10);
            var carToy = new SingleGift("Car", 5);
            var airplaneToy = new SingleGift("Airplane", 15);

            box.Add(truckToy);
            box.Add(carToy);
            box.Add(airplaneToy);

            Console.WriteLine(box.CalculateTotalPrice());
        }
    }
}
