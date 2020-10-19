using System;
using System.Linq;

namespace Iterators_and_Comparators___Exercises
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            ListyIterator<string> listy = null;
            try
            {
                while (true)
                {
                    string cmd = Console.ReadLine();
                    if (cmd == "END")
                    {
                        break;
                    }

                    string[] cmdArgs = cmd.Split();
                    string command = cmdArgs[0];
                    if (command == "Create")
                    {
                        string[] parameters = cmdArgs.Skip(1).ToArray();
                        listy = new ListyIterator<string>(parameters);
                    }
                    else if (command == "Move")
                    {
                        Console.WriteLine(listy.Move());
                    }
                    else if (command == "Print")
                    {
                        listy.Print();
                    }
                    else if (command == "PrintAll")
                    {
                        listy.PrintAll();
                    }
                    else if (command == "HasNext")
                    {
                        Console.WriteLine(listy.HasNext());
                    }
                }
            }
            catch (InvalidOperationException ioe)
            {
                Console.WriteLine(ioe.Message);
            }
        }
    }
}
