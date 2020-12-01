namespace Composite
{
    public abstract class GiftBase
    {
        protected GiftBase(string name, int price)
        {
            Name = name;
            Price = price;
        }

        public string Name { get; set; }
        public int Price { get; set; }

        public abstract int CalculateTotalPrice();
    }
}
