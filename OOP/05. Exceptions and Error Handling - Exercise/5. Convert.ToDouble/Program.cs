using System;

namespace _5._Convert.ToDouble
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Convert.ToDouble(Console.ReadLine());
            }
            catch (FormatException fe)
            {
                Console.WriteLine(fe.Message);
            }
            catch (InvalidCastException ice)
            {
                Console.WriteLine(ice.Message);
            }
            catch (OverflowException oe)
            {
                Console.WriteLine(oe.Message);
            }
        }
    }
}
