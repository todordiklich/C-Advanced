using System;
using System.Linq;
using System.Collections.Generic;

using FootballTeamGenerator.Models;
using FootballTeamGenerator.Exceptions;

namespace FootballTeamGenerator.Core
{
    public class Engine
    {
        private List<Team> teams;

        public void Run()
        {
            teams = new List<Team>();

            while (true)
            {
                try
                {
                    string command = Console.ReadLine();
                    if (command == "END")
                    {
                        break;
                    }

                    string[] commandTokens = command.Split(';', StringSplitOptions.RemoveEmptyEntries);

                    string action = commandTokens[0];


                    switch (action)
                    {
                        case "Team":
                            AddTeam(commandTokens);
                            break;

                        case "Add":
                            AddPlayerToTeam(commandTokens);
                            break;

                        case "Remove":
                            RemovePlayerFromTeam(commandTokens);
                            break;

                        case "Rating":
                            ShowTeamRating(commandTokens);
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        public void ShowTeamRating(string[] commandTokens)
        {
            string teamName = commandTokens[1];

            Team team = ValidateTeamName(teamName);

            Console.WriteLine($"{team.Name} - {team.TeamRating()}");
        }

        public void RemovePlayerFromTeam(string[] commandTokens)
        {
            string teamName = commandTokens[1];
            string playerName = commandTokens[2];

            Team team = ValidateTeamName(teamName);

            team.RemovePlayer(playerName);
        }

        public void AddPlayerToTeam(string[] commandTokens)
        {
            string teamName = commandTokens[1];
            Team team = ValidateTeamName(teamName);

            string playerName = commandTokens[2];

            int endurance = int.Parse(commandTokens[3]);
            int sprint = int.Parse(commandTokens[4]);
            int dribble = int.Parse(commandTokens[5]);
            int passing = int.Parse(commandTokens[6]);
            int shooting = int.Parse(commandTokens[7]);

            Stats stats = new Stats(endurance, sprint, dribble, passing, shooting);

            Player player = new Player(playerName, stats);

            team.AddPlayer(player);
        }

        private Team ValidateTeamName(string teamName)
        {
            Team team = teams.FirstOrDefault(t => t.Name == teamName);

            if (team == null)
            {
                throw new ArgumentException(String.Format(ExceptionMessages.TeamDoesNotExistException, teamName));
            }

            return team;
        }

        public void AddTeam(string[] commandTokens)
        {
            string teamName = commandTokens[1];

            Team team = new Team(teamName);

            teams.Add(team);
        }
    }
}
