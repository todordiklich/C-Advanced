namespace P06FoodShortage.Contracts
{
    public interface IBuyer
    {
        int Food { get; }
        string Name { get; }
        void BuyFood();
    }
}
