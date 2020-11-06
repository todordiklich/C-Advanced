using System;

namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] phones = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            string[] urls = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Smartphone smartphone;
            StationaryPhone stationary;

            foreach (var phone in phones)
            {
                bool isValid = ValidateNumber(phone);

                if (isValid)
                {
                    if (phone.Length == 7)
                    {
                        stationary = new StationaryPhone();
                        Console.WriteLine(stationary.Call(phone));
                    }
                    else if (phone.Length == 10)
                    {
                        smartphone = new Smartphone();
                        Console.WriteLine(smartphone.Call(phone));
                    }
                }
            }

            foreach (var url in urls)
            {
                bool isValid = ValidateURL(url);

                if (isValid)
                {
                    smartphone = new Smartphone();
                    Console.WriteLine(smartphone.Browse(url));
                }
            }
        }

        private static bool ValidateURL(string url)
        {
            foreach (var ch in url)
            {
                if (char.IsDigit(ch))
                {
                    Console.WriteLine("Invalid URL!");
                    return false;
                }
            }

            return true;
        }

        private static bool ValidateNumber(string phone)
        {
            foreach (char ch in phone)
            {
                if (char.IsLetter(ch))
                {
                    Console.WriteLine("Invalid number!");
                    return false;
                }
            }

            return true;
        }
    }
}
