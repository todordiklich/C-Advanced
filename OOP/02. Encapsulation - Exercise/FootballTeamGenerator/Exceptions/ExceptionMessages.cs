namespace FootballTeamGenerator.Exceptions
{
    public static class ExceptionMessages
    {
        public const string InvalidStatsException = "{0} should be between 0 and 100.";

        public const string InvalidNameException = "A name should not be empty.";

        public const string PlayerDoesNotExistException = "Player {0} is not in {1} team.";

        public const string TeamDoesNotExistException = "Team {0} does not exist.";
    }
}
