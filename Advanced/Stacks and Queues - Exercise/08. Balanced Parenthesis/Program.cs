using System;
using System.Collections;
using System.Collections.Generic;

namespace _08._Balanced_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            string brackets = Console.ReadLine();
            Stack<char> stack = new Stack<char>();

            if (String.IsNullOrEmpty(brackets) || brackets.Length % 2 == 1 )
            {
                Console.WriteLine("NO");
                return;
            }

            foreach (var bracket in brackets)
            {
                char expectedBracket = default;

                switch (bracket)
                {
                    case ')':
                        expectedBracket = '(';
                        break;
                    case ']':
                        expectedBracket = '[';
                        break;
                    case '}':
                        expectedBracket = '{';
                        break;
                    default:
                        stack.Push(bracket);
                        break;
                }

                if (expectedBracket == default)
                {
                    continue;
                }

                if (stack.Pop() != expectedBracket)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }

            if (stack.Count == 0)
            {
                Console.WriteLine("YES");
            }
            else
            {
                Console.WriteLine("NO");
            }
        }
    }
}
