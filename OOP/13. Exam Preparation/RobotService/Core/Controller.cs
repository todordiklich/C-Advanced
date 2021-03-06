﻿using System;

using RobotService.Models.Robots;
using RobotService.Models.Garages;
using RobotService.Core.Contracts;
using RobotService.Models.Procedures;
using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;
using RobotService.Models.Garages.Contracts;
using RobotService.Models.Procedures.Contracts;

namespace RobotService.Core
{
    public class Controller : IController
    {
        private IGarage garage;

        private IProcedure chargeProcedure;
        private IProcedure chipProcedure;
        private IProcedure polishProcedure;
        private IProcedure restProcedure;
        private IProcedure techCheckProcedure;
        private IProcedure workProcedure;
        public Controller()
        {
            this.garage = new Garage();

            this.chargeProcedure = new Charge();
            this.chipProcedure = new Chip();
            this.polishProcedure = new Polish();
            this.restProcedure = new Rest();
            this.techCheckProcedure = new TechCheck();
            this.workProcedure = new Work();
        }

        public string Charge(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            chargeProcedure.DoService(this.garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.ChargeProcedure, robotName);
        }

        public string Chip(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            chipProcedure.DoService(this.garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.ChipProcedure, robotName);
        }

        public string History(string procedureType)
        {
            if (procedureType == nameof(Charge))
            {
                return chargeProcedure.History();
            }
            else if (procedureType == nameof(Chip))
            {
                return chipProcedure.History();
            }
            else if (procedureType == nameof(Polish))
            {
                return polishProcedure.History();
            }
            else if (procedureType == nameof(Rest))
            {
                return restProcedure.History();
            }
            else if (procedureType == nameof(TechCheck))
            {
                return techCheckProcedure.History();
            }
            else if (procedureType == nameof(Work))
            {
                return workProcedure.History();
            }
            else
            {
                return "FAIL";
            }
        }

        public string Manufacture(string robotType, string name, int energy, int happiness, int procedureTime)
        {
            IRobot robot;

            if (robotType == nameof(HouseholdRobot))
            {
                robot = new HouseholdRobot(name, energy,happiness,procedureTime);
            }
            else if (robotType == nameof(PetRobot))
            {
                robot = new PetRobot(name, energy, happiness, procedureTime);
            }
            else if (robotType == nameof(WalkerRobot))
            {
                robot = new WalkerRobot(name, energy, happiness, procedureTime);
            }
            else
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidRobotType, robotType));
            }

            this.garage.Manufacture(robot);

            return String.Format(OutputMessages.RobotManufactured, name);
        }

        public string Polish(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            polishProcedure.DoService(this.garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.PolishProcedure, robotName);
        }

        public string Rest(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            restProcedure.DoService(this.garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.RestProcedure, robotName);
        }

        public string Sell(string robotName, string ownerName)
        {
            this.CheckIfRobotExists(robotName);

            if (this.garage.Robots[robotName].IsChipped == true)
            {
                return String.Format(OutputMessages.SellChippedRobot, ownerName);
            }
            else
            {
                return String.Format(OutputMessages.SellNotChippedRobot, ownerName);
            }

            this.garage.Sell(robotName, ownerName);
        }

        public string TechCheck(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            techCheckProcedure.DoService(this.garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.TechCheckProcedure, robotName);
        }

        public string Work(string robotName, int procedureTime)
        {
            this.CheckIfRobotExists(robotName);

            workProcedure.DoService(this.garage.Robots[robotName], procedureTime);

            return String.Format(OutputMessages.WorkProcedure, robotName, procedureTime);
        }

        private void CheckIfRobotExists(string robotName)
        {
            if (!this.garage.Robots.ContainsKey(robotName))
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InexistingRobot, robotName));
            }
        }
    }
}
