using System;

namespace MilitaryElite.Exceptions
{
    public class InvalidCorpsException : Exception
    {
        private const string EXC_MESSAGE = "Ivalid corps!";
        public InvalidCorpsException()
            :base(EXC_MESSAGE)
        {

        }

        public InvalidCorpsException(string message) 
            : base(message)
        {

        }
    }
}
