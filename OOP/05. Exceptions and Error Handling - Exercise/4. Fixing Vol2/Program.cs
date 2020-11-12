using System;

namespace _4._Fixing_Vol2
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                int num1, num2;
                byte result;

                num1 = 30;
                num2 = 60;
                result = Convert.ToByte(num1 * num2);
                Console.WriteLine($"{num1} * {num2} = {result}");
                Console.ReadLine();
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
