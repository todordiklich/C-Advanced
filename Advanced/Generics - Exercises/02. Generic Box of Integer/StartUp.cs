using System;

namespace _02._Generic_Box_of_Integer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                Box<int> box = new Box<int>(int.Parse(Console.ReadLine()));

                Console.WriteLine(box.ToString());
            }
        }
    }
}
