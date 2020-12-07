using System;

using RobotService.Utilities.Messages;
using RobotService.Models.Robots.Contracts;

namespace RobotService.Models.Robots
{
    public abstract class Robot : IRobot
    {
        private string name;
        private int energy;
        private int happiness;
        private int procedureTime;

        private string owner;
        private bool isBought;
        private bool isChipped;
        private bool isChecked;

        protected Robot(string name, int energy, int happiness, int procedureTime)
        {
            this.Name = name;
            this.Energy = energy;
            this.Happiness = happiness;
            this.ProcedureTime = procedureTime;

            this.Owner = "Service";
            this.IsBought = false;
            this.IsChipped = false;
            this.IsChecked = false;
        }

        public string Name
        {
            get { return this.name; }

            private set
            {
                this.name = value;
            }
        } 
        public int Energy
        {
            get { return this.energy; }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidEnergy);
                }

                this.energy = value;
            }
        }
        public int Happiness
        {
            get { return this.happiness; }

            set
            {
                if (value < 0 || value > 100)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidHappiness);
                }

                this.happiness = value;
            }
        }
        public int ProcedureTime
        {
            get { return this.procedureTime; }

            set
            {
                this.procedureTime = value;
            }
        }
        public string Owner
        {
            get { return this.owner; }

            set
            {
                this.owner = value;
            }
        }
        public bool IsBought
        {
            get { return this.isBought; }

            set
            {
                this.isBought = value;
            }
        }
        public bool IsChipped
        {
            get { return this.isChipped; }

            set
            {
                this.isChipped = value;
            }
        }
        public bool IsChecked
        {
            get { return this.isChecked; }

            set
            {
                this.isChecked = value;
            }
        }

        public override string ToString()
        {
            return $" Robot type: {this.GetType().Name} - {this.Name} - Happiness: {this.Happiness} - Energy: {this.Energy}";
        }
    }
}
