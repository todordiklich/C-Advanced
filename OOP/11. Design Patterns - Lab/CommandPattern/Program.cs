using System;

namespace CommandPattern
{
    class Program
    {
        static void Main(string[] args)
        {
            var modifyPrice = new ModifyPrice();
            var product = new Product("Phone", 500);
            Console.WriteLine(product);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Increase, 50));
            Console.WriteLine(product);

            Execute(product, modifyPrice, new ProductCommand(product, PriceAction.Decrease, 300));
            Console.WriteLine(product);
        }

        private static void Execute(Product product, ModifyPrice modifyPrice, ICommand command)
        {
            modifyPrice.SetCommand(command);
            modifyPrice.Invoke();
        }
    }
}
