using System;

namespace _2._Enter_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                ReadTenNumbers();
                return;
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }

        private static void ReadTenNumbers()
        {
            int prevNum = 1;
            int i = 0;
            while (i < 10)
            {
                int num = ReadNumber();
                if (prevNum > num)
                {
                    Console.WriteLine("The number must be greater than the previous one!");
                    i = 0;
                    prevNum = 1;
                }
                prevNum = num;
                i++;
            }
        }

        public static int ReadNumber()
        {
            int number = int.Parse(Console.ReadLine());

            if (!(1 < number && number < 100))
            {
                throw new ArgumentException("Invalid nimber");
            }

            return number;
        }
    }
}
