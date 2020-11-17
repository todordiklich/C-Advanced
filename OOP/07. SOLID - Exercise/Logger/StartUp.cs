using System;
using System.Collections.Generic;

using Logger.Core;
using Logger.Factories;
using Logger.Core.Contracts;
using Logger.Models.Contracts;

namespace Logger
{
    class StartUp
    {
        static void Main(string[] args)
        {
            int appendersCount = int.Parse(Console.ReadLine());

            ICollection<IAppender> appenders = new List<IAppender>();
            ParseAppenderInput(appendersCount, appenders);

            ILogger logger = new Logger.Models.Logger(appenders);

            IEngine engine = new Engine(logger);
            engine.Run();
        }

        private static void ParseAppenderInput(int appendersCount, ICollection<IAppender> appenders)
        {
            AppenderFactory appenderFactory = new AppenderFactory();

            for (int i = 0; i < appendersCount; i++)
            {
                string[] appenderArg = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string appenderType = appenderArg[0];
                string layoutType = appenderArg[1];
                string level = "INFO";

                if (appenderArg.Length == 3)
                {
                    level = appenderArg[2];
                }

                try
                {
                    IAppender appender = appenderFactory.ProduceAppender(appenderType, layoutType, level);

                    appenders.Add(appender);
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }
    }
}
