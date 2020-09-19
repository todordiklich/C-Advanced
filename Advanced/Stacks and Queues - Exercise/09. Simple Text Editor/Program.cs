using System;
using System.Collections.Generic;

namespace _09._Simple_Text_Editor
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Stack<string> stack = new Stack<string>();
            string result = "";

            for (int i = 0; i < n; i++)
            {
                string[] cmdArgs = Console.ReadLine().Split();
                string command = cmdArgs[0];

                switch (command)
                {
                    case "1":
                        stack.Push(result);
                        result += cmdArgs[1];
                        break;
                    case "2":
                        stack.Push(result);
                        int count = int.Parse(cmdArgs[1]);
                        result = result.Substring(0, result.Length - count);
                        break;
                    case "3":
                        int index = int.Parse(cmdArgs[1]) - 1;
                        Console.WriteLine(result[index]);
                        break;
                    case "4":
                        result = stack.Pop();
                        break;
                }
            }
        }
    }
}
