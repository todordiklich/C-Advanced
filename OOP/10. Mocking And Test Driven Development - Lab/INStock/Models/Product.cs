using INStock.Contracts;

namespace INStock.Models
{
    public class Product : IProduct
    {
        public Product()
        { 
        }

        public Product(string label, decimal price, int quantity)
        {
            this.Label = label;
            this.Price = price;
            this.Quantity = quantity;
        }
        public string Label { get; private set; }

        public decimal Price { get; private set; }

        public int Quantity { get; private set; }
    }
}
