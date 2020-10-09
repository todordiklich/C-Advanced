using System;
using System.Linq;

namespace _05._Date_Modifier
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string firstDate = Console.ReadLine();
            string secondDate = Console.ReadLine();

            DateModifier dateModifier = new DateModifier();

            
            Console.WriteLine(dateModifier.GetDifference(firstDate, secondDate));
        }
    }
}
