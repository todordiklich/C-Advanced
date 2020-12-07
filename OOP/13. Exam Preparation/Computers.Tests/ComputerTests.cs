namespace Computers.Tests
{
    using NUnit.Framework;
    using System;

    public class ComputerTests
    {
        private Part part;
        private Computer computer;

        [SetUp]
        public void Setup()
        {
            part = new Part("Part", 100);
            computer = new Computer("Computer");
        }

        [Test]
        public void PartConstructorShouldWorkProperly()
        {
            Assert.AreEqual("Part", part.Name);
            Assert.AreEqual(100, part.Price);
        }

        [Test]
        public void ComputerConstructorShouldWorkProperly()
        {
            Assert.AreEqual("Computer", computer.Name);
        }

        [Test]
        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("")]
        public void ComputerConstructorShouldThrowException(string name)
        {
            Assert.Throws<ArgumentNullException>(() => new Computer(name));
        }

        [Test]
        public void ComputerAddShouldWorkProperly()
        {
            computer.AddPart(part);

            Assert.AreEqual(1, computer.Parts.Count);
        }

        [Test]
        public void ComputerAddShouldThrowException()
        {
            Assert.Throws<InvalidOperationException>(() => computer.AddPart(null));
        }

        [Test]
        public void ComputerTotalPriceShouldWorkProperly()
        {
            computer.AddPart(part);

            Assert.AreEqual(part.Price, computer.TotalPrice);
        }

        [Test]
        public void ComputerRemoveShouldWorkProperly()
        {
            computer.AddPart(part);

            Assert.AreEqual(true, computer.RemovePart(part));
            Assert.AreEqual(false, computer.RemovePart(part));
        }

        [Test]
        public void ComputerGetPartShouldWorkProperly()
        {
            computer.AddPart(part);

            Assert.AreEqual(part, computer.GetPart(part.Name));
            Assert.AreEqual(null, computer.GetPart("Invalid"));
        }
    }
}