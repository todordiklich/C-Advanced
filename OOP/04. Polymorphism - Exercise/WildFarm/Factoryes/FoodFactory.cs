using WildFarm.Contracts;
using WildFarm.Models.Foods;

namespace WildFarm.Factoryes
{
    public class FoodFactory
    {
        public FoodFactory()
        {

        }

        public IFood ProduceFood(string[] arguments)
        {
            IFood food = null;

            string foodType = arguments[0];
            int foodQuantity = int.Parse(arguments[1]);

            if (foodType == "Fruit")
            {
                food = new Fruit(foodQuantity);
            }
            else if (foodType == "Meat")
            {
                food = new Meat(foodQuantity);
            }
            else if (foodType == "Seeds")
            {
                food = new Seeds(foodQuantity);
            }
            else if (foodType == "Vegetable")
            {
                food = new Vegetable(foodQuantity);
            }

            return food;
        }
    }
}
