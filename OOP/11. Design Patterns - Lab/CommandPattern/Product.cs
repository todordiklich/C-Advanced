namespace CommandPattern
{
    public class Product
    {
        public Product(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }

        public void IncreasePrice(int amount)
        {
            Price += amount;
        }

        public void DecreasePrice(int amount)
        {
            if (Price > amount)
            {
                Price -= amount;
            }
        }

        public override string ToString() => $"Product: {Name}, Price: {Price:F2}$";
    }
}
