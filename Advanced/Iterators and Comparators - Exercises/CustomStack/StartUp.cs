using System;
using System.Linq;

namespace CustomStack
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Stack<int> stack = new Stack<int>();
            while (true)
            {
                string cmd = Console.ReadLine();
                if (cmd == "END")
                {
                    if (stack.Count > 0)
                    {
                        PrintElements(stack);
                        PrintElements(stack);
                    }
                    break;
                }

                string[] cmdArgs = cmd.Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string command = cmdArgs[0];

                if (command == "Push")
                {
                    int[] elements = cmdArgs
                        .Skip(1)
                        .Select(int.Parse)
                        .ToArray();
                    foreach (var element in elements)
                    {
                        stack.Push(element);
                    }
                }
                else if (command == "Pop")
                {
                    stack.Pop();
                }
            }
        }

        private static void PrintElements(Stack<int> stack)
        {
            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }
        }
    }
}
