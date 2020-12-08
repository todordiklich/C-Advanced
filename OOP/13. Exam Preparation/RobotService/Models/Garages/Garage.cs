using System;
using System.Collections.Generic;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;

namespace RobotService.Models.Garages
{
    public class Garage : IGarage
    {
        private const int MAX_CAPACITY = 10;
        private Dictionary<string, IRobot> robots;

        public Garage()
        {
            this.robots = new Dictionary<string, IRobot>();
        }

        public IReadOnlyDictionary<string, IRobot> Robots => this.robots;

        public void Manufacture(IRobot robot)
        {
            if (robots.Count >= MAX_CAPACITY)
            {
                throw new InvalidOperationException(ExceptionMessages.NotEnoughCapacity);
            }
            if (robots.ContainsKey(robot.Name))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.ExistingRobot, robot.Name));
            }

            this.robots.Add(robot.Name, robot);
        }

        public void Sell(string robotName, string ownerName)
        {
            if (!this.robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }

            this.robots[robotName].Owner = ownerName;
            this.robots[robotName].IsBought = true;

            //this.robots.Remove(robotName);
        }
    }
}
