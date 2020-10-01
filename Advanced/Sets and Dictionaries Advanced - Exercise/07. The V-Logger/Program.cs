using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._The_V_Logger
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Vlogger> vloggers = new List<Vlogger>();



            while (true)
            {
                string cmd = Console.ReadLine();
                string[] input = cmd.Split();

                if (cmd == "Statistics")
                {
                    break;
                }

                string vloggerName = input[0];
                string command = input[1];

                if (command == "joined")
                {
                    var current = vloggers.FirstOrDefault(v => v.Name == vloggerName);
                    if (current == null)
                    {
                        var vlogger = new Vlogger(vloggerName);
                        vloggers.Add(vlogger);
                    }
                }
                else if (command == "followed")
                {
                    string secondVlogger = input[2];

                    if (vloggerName != secondVlogger)
                    {
                        var first = vloggers.FirstOrDefault(v => v.Name == vloggerName);
                        var second = vloggers.FirstOrDefault(v => v.Name == secondVlogger);

                        if (first != null && second != null)
                        {
                            if (!first.Following.Contains(secondVlogger) 
                                && !second.Followers.Contains(vloggerName))
                            {
                                first.Following.Add(secondVlogger);
                                second.Followers.Add(vloggerName);
                            }
                        }
                    }
                }
            }

            var result =
                vloggers.OrderByDescending(f => f.Followers.Count).ThenBy(f => f.Following.Count).ToList();

            Console.WriteLine($"The V-Logger has a total of {result.Count} vloggers in its logs.");

            for (int i = 0; i < vloggers.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {result[i].Name} : {result[i].Followers.Count} followers, {result[i].Following.Count} following");

                if (i == 0 && result[i].Followers.Count != 0)
                {
                    var orderFollowers = result[i].Followers.OrderBy(n => n).ToList();

                    for (int j = 0; j < orderFollowers.Count; j++)
                    {
                        Console.WriteLine($"*  {orderFollowers[j]}");
                    }
                }
            }
        }
    }

    public class Vlogger
    {
        public Vlogger(string name)
        {
            this.Name = name;
            this.Followers = new List<string>();
            this.Following = new List<string>();
        }
        public string Name { get; set; }

        public List<string> Followers { get; set; }

        public List<string> Following { get; set; }


    }
}
