namespace Robots.Tests
{
    using System;
    using NUnit.Framework;
    public class RobotsTests
    {
        private Robot robot;
        private RobotManager robotManager;

        [SetUp]
        public void SetUp()
        {
            robot = new Robot("Robot", 100);
            robotManager = new RobotManager(5);
        }

        [Test]
        public void Robot_Constructor_Should_WorkProperly()
        {
            Assert.AreEqual("Robot", robot.Name);
            Assert.AreEqual(100, robot.Battery);
            Assert.AreEqual(100, robot.MaximumBattery);
        }

        [Test]
        public void RobotManager_Constructor_Should_WorkProperly()
        {
            Assert.AreEqual(5, robotManager.Capacity);
        }

        [Test]
        public void RobotManager_Constructor_Should_ThrowException()
        {
            Assert.Throws<ArgumentException>(() => new RobotManager(-1));
        }

        [Test]
        public void RobotManager_Add_Should_WorkCorrectly()
        {
            robotManager.Add(robot);

            Assert.AreEqual(1, robotManager.Count);
        }

        [Test]
        public void RobotManager_Add_Should_ThrowException_When_TryToAddRobotWithSameName()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void RobotManager_Add_Should_ThrowException_When_TryToAddMoreRobotsThanCapacity()
        {
            robotManager = new RobotManager(0);

            Assert.Throws<InvalidOperationException>(() => robotManager.Add(robot));
        }

        [Test]
        public void RobotManager_Remove_Should_ThrowException_When_TryToRemoveUnexistingRobot()
        {
            robotManager.Add(robot);
            var invalid = new Robot("Invalid", 1);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(invalid.Name));
        }

        [Test]
        public void RobotManager_Remove_Should_WorkProperly()
        {
            robotManager.Add(robot);
            robotManager.Remove(robot.Name);

            Assert.AreEqual(0, robotManager.Count);
        }

        [Test]
        public void RobotManager_Work_Should_WorkProperly()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "Work", 10);

            Assert.AreEqual(90, robot.Battery);
        }

        [Test]
        public void RobotManager_Work_Should_ThrowException_When_NotEnoughtBattery()
        {
            robotManager.Add(robot);

            Assert.Throws<InvalidOperationException>(() => robotManager.Work(robot.Name, "Work", 1000));
        }

        [Test]
        public void RobotManager_Work_Should_ThrowException_When_TryToWorkWithUnexistingRobot()
        {
            robotManager.Add(robot);
            var invalid = new Robot("Invalid", 1);

            Assert.Throws<InvalidOperationException>(() => robotManager.Remove(invalid.Name));
        }

        [Test]
        public void RobotManager_Charge_Should_ThrowException_When_TryToChargeUnexistingRobot()
        {
            robotManager.Add(robot);
            var invalid = new Robot("Invalid", 1);

            Assert.Throws<InvalidOperationException>(() => robotManager.Charge(invalid.Name));
        }

        [Test]
        public void RobotManager_Charge_Should_WorkProperly()
        {
            robotManager.Add(robot);
            robotManager.Work(robot.Name, "Work", 50);
            robotManager.Charge(robot.Name);

            Assert.AreEqual(100, robot.Battery);
        }
    }
}
