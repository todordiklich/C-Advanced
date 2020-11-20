﻿using System;

using CommandPattern.Core.Contracts;

namespace CommandPattern.Core.Models
{
    public class Engine : IEngine
    {
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(ICommandInterpreter commandInterpreter)
        {
            this.commandInterpreter = commandInterpreter;
        }

        public void Run()
        {
            string input = Console.ReadLine();

            Console.WriteLine(commandInterpreter.Read(input));
        }
    }
}
