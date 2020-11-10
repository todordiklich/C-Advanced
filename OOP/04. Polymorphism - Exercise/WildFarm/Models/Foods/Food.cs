using WildFarm.Contracts;

namespace WildFarm.Models.Foods
{
    public abstract class Food : IFood
    {
        public Food(int quantuty)
        {
            this.Quantity = quantuty;
        }
        public int Quantity { get; private set; }
    }
}
