using System;

using WildFarm.Contracts;

namespace WildFarm.Models.Animals.Birds
{
    public class Hen : Bird
    {
        private const double WEIGHT_INCREASE = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {

        }

        public override double WeightIncrease => WEIGHT_INCREASE;

        public override void Eat(IFood food)
        {
            this.Weight += food.Quantity * this.WeightIncrease;
            this.FoodEaten += food.Quantity;
        }

        public override void ProduseSound()
        {
            Console.WriteLine("Cluck");
        }
    }
}
