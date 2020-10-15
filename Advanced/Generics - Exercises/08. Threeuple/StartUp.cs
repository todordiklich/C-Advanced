using System;

namespace _08._Threeuple
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            // {first name} {last name} {address} {town}
            string[] nameArgs = Console.ReadLine().Split();
            string name = nameArgs[0] + " " + nameArgs[1];
            string adress = nameArgs[2];
            string town = "";
            for (int i = 3; i < nameArgs.Length; i++)
            {
                town += nameArgs[i] + " ";
            }

            var tuple1 = new Threeuple<string, string, string>(name, adress, town);

            // {name} {liters of beer} {drunk or not}
            string[] beerArgs = Console.ReadLine().Split();
            string nameTwo = beerArgs[0];
            int beer = int.Parse(beerArgs[1]);
            string drunkOrNot = beerArgs[2];
            bool doDrink = false;
            if (drunkOrNot == "drunk")
            {
                doDrink = true;
            }

            var tuple2 = new Threeuple<string, int, bool>(nameTwo, beer, doDrink);

            // {name} {account balance} {bank name}
            string[] bankArgs = Console.ReadLine().Split();
            string nameThree = bankArgs[0];
            double balance = double.Parse(bankArgs[1]);
            string bankName = bankArgs[2];

            var tuple3 = new Threeuple<string, double, string>(nameThree, balance, bankName);

            Console.WriteLine(tuple1);
            Console.WriteLine(tuple2);
            Console.WriteLine(tuple3);
        }
    }
}
