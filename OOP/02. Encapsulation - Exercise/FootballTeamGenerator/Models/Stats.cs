using System;

using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Models
{
    public class Stats
    {
        private int endurance;
        private int sprint;
        private int dribble;
        private int passing;
        private int shooting;
        public Stats(int endurance, int sprint, int dribble, int passing, int shooting)
        {
            this.Endurance = endurance;
            this.Sprint = sprint;
            this.Dribble = dribble;
            this.Passing = passing;
            this.Shooting = shooting;
        }
        public int Endurance 
        {
            get 
            {
                return this.endurance;
            }

            private set
            {
                ValidateInput(value, nameof(Endurance));

                this.endurance = value;
            }
        }
        public int Sprint
        {
            get
            {
                return this.sprint;
            }
            private set
            {
                ValidateInput(value, nameof(Sprint));

                this.sprint = value;
            }
        }
        public int Dribble
        {
            get
            {
                return this.dribble;
            }
            private set
            {
                ValidateInput(value, nameof(Dribble));

                this.dribble = value;
            }
        }
        public int Passing
        {
            get
            {
                return this.passing;
            }
            private set
            {
                ValidateInput(value, nameof(Passing));

                this.passing = value;
            }
        }
        public int Shooting
        {
            get
            {
                return this.shooting;
            }
            private set
            {
                ValidateInput(value, nameof(Shooting));

                this.shooting = value;
            }
        }

        private void ValidateInput(int input, string statName)
        {
            if (input < 0 ||input > 100)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.InvalidStatsException, statName));
            }
        }
    }
}
