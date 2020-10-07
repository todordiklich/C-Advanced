using System;
using System.Collections.Generic;
using System.Linq;

namespace _10._Predicate_Party_
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> names = Console.ReadLine().Split().ToList();

            string command = Console.ReadLine();

            Func<List<string>, string, string, List<string>> funcDouble = (list, criteria, argument) =>
            {
                List<string> result = new List<string>(list);

                switch (criteria)
                {
                    case "StartsWith":
                        foreach (var name in list)
                        {
                            if (name.StartsWith(argument))
                            {
                                int index = result.IndexOf(name);
                                result.Insert(index, name);
                            }
                        }
                        return result;
                    case "EndsWith":
                        foreach (var name in list)
                        {
                            if (name.EndsWith(argument))
                            {
                                int index = result.IndexOf(name);
                                result.Insert(index, name);
                            }
                        }
                        return result;

                    case "Length":
                        foreach (var name in list)
                        {
                            if (name.Length == int.Parse(argument))
                            {
                                int index = result.IndexOf(name);
                                result.Insert(index, name);
                            }
                        }
                        return result;

                    default:
                        return result;
                }
            };
            Func<List<string>, string, string, List<string>> funcRemove = (list, criteria, argument) =>
            {
                List<string> result = new List<string>(list);

                switch (criteria)
                {
                    case "StartsWith":
                        foreach (var name in list)
                        {
                            if (name.StartsWith(argument))
                            {
                                result.Remove(name);
                            }
                        }
                        return result;
                    case "EndsWith":
                        foreach (var name in list)
                        {
                            if (name.EndsWith(argument))
                            {
                                result.Remove(name);
                            }
                        }
                        return result;

                    case "Length":
                        foreach (var name in list)
                        {
                            if (name.Length == int.Parse(argument))
                            {
                                result.Remove(name);
                            }
                        }
                        return result;

                    default:
                        return result;
                }
            };

            while (command != "Party!")
            {
                string[] cmdArgs = command.Split();
                string cmd = cmdArgs[0];
                string criteria = cmdArgs[1];
                string argument = cmdArgs[2];

                if (cmd == "Remove")
                {
                    names = funcRemove(names, criteria, argument);
                }
                else if (cmd == "Double")
                {
                    names = funcDouble(names, criteria, argument);
                }

                command = Console.ReadLine();
            }

            Console.WriteLine(names.Count == 0 ? "Nobody is going to the party!" : $"{string.Join(", ", names)} are going to the party!");
        }
    }
}
