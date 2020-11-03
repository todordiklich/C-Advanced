using System;

using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Models
{
    public class Player
    {
        private string name;
        private Stats stats;
        public Player(string name, Stats stats)
        {
            this.Name = name;
            this.stats = stats;
        }
        public string Name
        {
            get
            {
                return this.name;
            }
            private set
            {
                if (String.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNameException);
                }

                this.name = value;
            }
        }

        public int PlayerOverallSkill()
        {
            int playerOverallSkill = (int)Math.Round((double)(stats.Endurance + stats.Sprint + stats.Dribble + stats.Passing + stats.Shooting) / 5);

            return playerOverallSkill;
        }
    }
}
