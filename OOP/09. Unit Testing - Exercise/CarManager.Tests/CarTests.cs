using System;
using NUnit.Framework;

using CarManager;

namespace Tests
{
    public class CarTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("BMW", "3", 10, 100)]
        [TestCase("Seat", "Altea", 6, 70)]
        public void ConstructorWorksProperly(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            Car car = new Car(make, model, fuelConsumption, fuelCapacity);

            var expextedMake = make;
            var expextedModel = model;
            var expextedFuelConsumption = fuelConsumption;
            var expextedFuelCapacity = fuelCapacity;

            Assert.AreEqual(expextedMake, car.Make);
            Assert.AreEqual(expextedModel, car.Model);
            Assert.AreEqual(expextedFuelConsumption, car.FuelConsumption);
            Assert.AreEqual(expextedFuelCapacity, car.FuelCapacity);
            Assert.AreEqual(0, car.FuelAmount);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void MakeTakesNullOrEmptyParameter(string make)
        {
            Assert.Throws<ArgumentException>(() => new Car(make, "model", 10, 100));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void ModelTakesNullOrEmptyParameter(string model)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", model, 10, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelConsumptionTakesZeroOrNegativeParameter(double fuelConsumption)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", fuelConsumption, 100));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void FuelCapacityTakesZeroOrNegativeParameter(double fuelCapacity)
        {
            Assert.Throws<ArgumentException>(() => new Car("make", "model", 10, fuelCapacity));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void RefuelTakesZeroOrNegativeParameter(double fuelAmount)
        {
            Car car = new Car("make", "model", 10, 100);

            Assert.Throws<ArgumentException>(() => car.Refuel(fuelAmount));
        }

        [Test]
        [TestCase(50, 50)]
        [TestCase(150, 100)]
        public void RefuelWorksProperly(double fuelAmount, double expectedFuel)
        {
            Car car = new Car("make", "model", 10, 100);

            car.Refuel(fuelAmount);

            Assert.AreEqual(expectedFuel, car.FuelAmount);
        }

        [Test]
        public void DriveWorksProperly()
        {
            Car car = new Car("make", "model", 10, 100);
            car.Refuel(100);
            car.Drive(100);

            Assert.AreEqual(90, car.FuelAmount);
        }

        [Test]
        public void DriveThrowsException()
        {
            Car car = new Car("make", "model", 10, 100);
            car.Refuel(1);

            Assert.Throws<InvalidOperationException>(() => car.Drive(100));
        }
    }
}