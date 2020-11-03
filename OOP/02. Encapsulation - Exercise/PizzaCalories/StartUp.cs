using System;

namespace PizzaCalories
{
    public class StartUp
    {
        private static Dough dough;
        private static Pizza pizza;
        private static string pizzaName;
        static void Main(string[] args)
        {
            try
            {
                while (true)
                {
                    string cmd = Console.ReadLine();
                    if (cmd == "END")
                    {
                        break;
                    }

                    string[] cmdArgs = cmd.Split();
                    string type = cmdArgs[0];

                    if (type == "Dough")
                    {
                        string flourType = cmdArgs[1];
                        string backingType = cmdArgs[2];
                        double weight = double.Parse(cmdArgs[3]);

                        dough = new Dough(flourType, backingType, weight);
                        pizza = new Pizza(pizzaName, dough);
                    }
                    else if (type == "Topping")
                    {
                        string toppingType = cmdArgs[1];
                        double weight = double.Parse(cmdArgs[2]);

                        Topping topping = new Topping(toppingType, weight);
                        pizza.AddTopping(topping);
                    }
                    else if (type == "Pizza")
                    {
                        pizzaName = cmdArgs[1];
                    }
                }
                Console.WriteLine(pizza);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine(ae.Message);
            }
        }
    }
}
