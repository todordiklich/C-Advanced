using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals.Birds
{
    public class Owl : Bird
    {
        private const double WEIGHT_INCREASE = 0.25;
        public Owl(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
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
            Console.WriteLine("Hoot Hoot");
        }
    }
}
