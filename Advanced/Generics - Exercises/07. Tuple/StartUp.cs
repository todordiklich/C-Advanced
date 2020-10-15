using System;

namespace _07._Tuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // {first name} {last name} {address}
            string[] nameArgs = Console.ReadLine().Split();
            string name = nameArgs[0] + " " + nameArgs[1];
            string adress = nameArgs[2];

            Tuple<string, string> tuple1 = new Tuple<string, string>(name, adress);

            // {name} {liters of beer}
            string[] beerArgs = Console.ReadLine().Split();
            string nameTwo = beerArgs[0];
            int beer = int.Parse(beerArgs[1]);

            Tuple<string, int> tuple2 = new Tuple<string, int>(nameTwo, beer);

            // {integer} {double}
            string[] intDoubleArgs = Console.ReadLine().Split();
            int integer = int.Parse(intDoubleArgs[0]);
            double doubleArg = double.Parse(intDoubleArgs[1]);

            Tuple<int, double> tuple3 = new Tuple<int, double>(integer, doubleArg);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
