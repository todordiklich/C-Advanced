using System;

namespace Facade
{
    class Program
    {
        static void Main(string[] args)
        {
            var car = new CarBuilderFacade()
                .Info
                    .WithType("BMW")
                    .WithColor("Red")
                    .WithNumberOfDoors(5)
                .Built
                    .InCity("Leipzig")
                    .AtAddress("Some address 255")
                .Build();

            Console.WriteLine(car);
        }
    }
}
