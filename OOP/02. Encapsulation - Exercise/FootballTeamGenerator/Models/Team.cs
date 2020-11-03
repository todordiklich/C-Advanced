using System;
using System.Linq;
using System.Collections.Generic;

using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Models
{
    public class Team
    {
        private string name;
        private List<Player> players;
        public Team()
        {
            this.players = new List<Player>();
        }
        public Team(string name) 
            : this()
        {
            this.Name = name;
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
        public int TeamRating()
        {
            int teamRating = players.Sum(p => p.PlayerOverallSkill());

            return teamRating;
        }
        public void AddPlayer(Player player)
        {
            
            players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = players.FirstOrDefault(p => p.Name == playerName);

            if (player == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.PlayerDoesNotExistException, playerName, this.Name));
            }

            players.Remove(player);
        }
    }
}
