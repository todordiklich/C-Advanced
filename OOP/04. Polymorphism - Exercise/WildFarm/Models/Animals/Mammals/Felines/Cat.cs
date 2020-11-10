using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals.Mammals.Felines
{
    public class Cat : Feline
    {
        private const double WEIGHT_INCREASE = 0.3;
        public Cat(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {

        }

        public override double WeightIncrease => WEIGHT_INCREASE;

        public override void Eat(IFood food)
        {
            if (food.GetType().Name == "Meat" || food.GetType().Name == "Vegetable")
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
            Console.WriteLine("Meow");
        }
    }
}
