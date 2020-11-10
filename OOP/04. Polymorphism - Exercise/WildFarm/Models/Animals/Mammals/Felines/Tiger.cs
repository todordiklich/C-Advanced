using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Tiger : Feline
    {
        private const double WEIGHT_INCREASE = 1;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightIncrease => WEIGHT_INCREASE;

        public override void Eat(IFood food)
        {
            if (food.GetType().Name == "Meat")
            {
                this.Weight += food.Quantity * this.WeightIncrease;
                this.FoodEaten += food.Quantity;
            }
            else
            {
                Console.WriteLine($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
        }

        public override void ProduseSound()
        {
            Console.WriteLine("ROAR!!!");
        }
    }
}
