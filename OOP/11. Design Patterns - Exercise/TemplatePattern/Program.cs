using System;

namespace TemplatePattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var white = new WhiteBread();
            white.Make();

            Console.WriteLine();

            var wholegrain = new WholegrainBread();
            wholegrain.Make();
        }
    }
}
