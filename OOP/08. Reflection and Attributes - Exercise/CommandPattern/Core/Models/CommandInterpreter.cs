using System;
using System.Linq;
using System.Reflection;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_SUFFIX = "Command";

        public string Read(string args)
        {
            string[] cmdArgs = args.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();
            string command = cmdArgs[0] + COMMAND_SUFFIX;

            Assembly assembly = Assembly.GetCallingAssembly();

            Type commandType = assembly.GetTypes().FirstOrDefault(t => t.Name.ToLower() == command.ToLower());

            if (commandType == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            ICommand commandInstance = (ICommand)Activator.CreateInstance(commandType);

            string[] result = cmdArgs.Skip(1).ToArray();

            return commandInstance.Execute(result);
        }
    }
}
