

using System;
using System.Collections.Generic;
using System.Linq;

namespace _11._The_Party_Reservation_Filter_Module
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();
            List<KeyValuePair<string,string>> commands = new List<KeyValuePair<string,string>>();

            string command = Console.ReadLine();

            while (command != "Print")
            {
                string[] cmdArgs = command.Split(";");
                string cmd = cmdArgs[0];
                string key = cmdArgs[1];
                string value = cmdArgs[2];

                if (cmd == "Add filter")
                {
                    commands.Add(new KeyValuePair<string, string>(key, value));
                }
                else // remove filter
                {

                    commands.Remove(new KeyValuePair<string, string>(key, value));
                }


                command = Console.ReadLine();
            }

            Func<List<string>, string, string, List<string>> filterFunc = (list, cmd, argument) =>
            {
                if (cmd == "Starts with")
                {
                    return list.Where(n => !n.StartsWith(argument)).ToList();
                }
                else if (cmd == "Ends with")
                {
                    return list.Where(n => !n.EndsWith(argument)).ToList();
                }
                else if (cmd == "Length")
                {
                    return list.Where(n => n.Length != int.Parse(argument)).ToList();
                }
                else if (cmd == "Contains")
                {
                    return list.Where(n => !n.Contains(argument)).ToList();
                }
                else
                {
                    return list;
                }
            };

            foreach (var kvp in commands)
            {
                names = filterFunc(names, kvp.Key, kvp.Value);
            }

            Console.WriteLine(string.Join(" ", names));
        }
    }
}
