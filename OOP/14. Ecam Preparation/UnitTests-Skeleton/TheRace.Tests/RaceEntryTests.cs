using NUnit.Framework;
using System;
using TheRace;

namespace TheRace.Tests
{
    public class RaceEntryTests
    {
        private UnitCar car;
        private UnitDriver driver;
        private RaceEntry race;


        [SetUp]
        public void Setup()
        {
            car = new UnitCar("Car", 100, 2.0);
            driver = new UnitDriver("Driver", car);
            race = new RaceEntry();
        }

        [Test]
        public void CarConstructorShouldWorkProperly()
        {
            Assert.AreEqual("Car", car.Model);
            Assert.AreEqual(100, car.HorsePower);
            Assert.AreEqual(2.0, car.CubicCentimeters);
        }

        [Test]
        public void DriverConstructorShouldWorkProperly()
        {
            Assert.AreEqual("Driver", driver.Name);
            Assert.AreEqual(car, driver.Car);
        }

        [Test]
        public void DriverConstructorShouldThrowException()
        {
            Assert.Throws<ArgumentNullException>(() => new UnitDriver(null, car));
        }

        [Test]
        public void RaceAddDriverShouldWorkProperly()
        {
            Assert.AreEqual($"Driver {driver.Name} added in race.", race.AddDriver(driver));
            Assert.AreEqual(1, race.Counter);
        }

        [Test]
        public void RaceAddDriverShouldThrowInvalidOperationException()
        {
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(null));
        }

        [Test]
        public void RaceAddDriverShouldThrowInvalidOperationExceptionWhenDriverIsContained()
        {
            race.AddDriver(driver);
            Assert.Throws<InvalidOperationException>(() => race.AddDriver(driver));
        }

        [Test]
        public void RaceCalculateAvverageHorsePowerShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => race.CalculateAverageHorsePower());
        }

        [Test]
        public void RaceCalculateAvverageHorsePowerShouldWorkProperly()
        {
            UnitDriver secondDriver = new UnitDriver("SecondDriver", car);
            race.AddDriver(driver);
            race.AddDriver(secondDriver);

            Assert.AreEqual(100, race.CalculateAverageHorsePower());
        }
    }
}