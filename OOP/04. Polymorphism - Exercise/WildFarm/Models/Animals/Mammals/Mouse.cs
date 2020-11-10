using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals.Mammals
{
    public class Mouse : Mammal
    {
        private const double WEIGHT_INCREASE = 0.1;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {

        }

        public override double WeightIncrease => WEIGHT_INCREASE;

        public override void Eat(IFood food)
        {
            if (food.GetType().Name == "Vegetable" || food.GetType().Name == "Fruit")
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
            Console.WriteLine("Squeak");
        }
        public override string ToString()
        {
            return base.ToString() + $"{this.Weight}, {this.LivingRegion}, {this.FoodEaten}]";
        }
    }
}
