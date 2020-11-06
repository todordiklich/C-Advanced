using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidMissionStateException : Exception
    {
        private const string EXC_MESSAGE = "Invalid mission state!";
        public InvalidMissionStateException()
            : base(EXC_MESSAGE)
        {

        }

        public InvalidMissionStateException(string message) : base(message)
        {

        }
    }
}
