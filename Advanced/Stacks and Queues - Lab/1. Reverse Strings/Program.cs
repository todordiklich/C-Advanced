using System;
using System.Collections.Generic;

namespace _1._Reverse_Strings
{
    class Program
    {
        static void Main(string[] args)
        {
            string str = Console.ReadLine();
            Stack<char> stack = new Stack<char>(str.ToCharArray());

            while (stack.Count > 0)
            {
                Console.Write(stack.Pop());
            }
        }
    }
}
