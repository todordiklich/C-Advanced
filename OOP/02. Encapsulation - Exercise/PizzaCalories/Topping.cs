using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaCalories
{
    public class Topping
    {
        private const double DEFAULT_CAL_PER_GRAM = 2;

        private string toppingType;

        private double toppingTypePerGram;
        private double weight;

        public Topping(string toppingType, double weight)
        {
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        public string ToppingType 
        {
            get => this.toppingType;

            private set
            {
                switch (value.ToLower())
                {
                    case nameof(ToppingTypeEnum.cheese):
                        this.toppingTypePerGram = (double)ToppingTypeEnum.cheese / 100;
                        break;

                    case nameof(ToppingTypeEnum.meat):
                        this.toppingTypePerGram = (double)ToppingTypeEnum.meat / 100;
                        break;

                    case nameof(ToppingTypeEnum.sauce):
                        this.toppingTypePerGram = (double)ToppingTypeEnum.sauce / 100;
                        break;

                    case nameof(ToppingTypeEnum.veggies):
                        this.toppingTypePerGram = (double)ToppingTypeEnum.veggies / 100;
                        break;

                    default:
                        throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }

                this.toppingType = value;
            }
        }
        public double Weight 
        {
            get => this.weight;

            private set
            {
                if (value < 0 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }

                this.weight = value;
            }
        }
        public double ToppingTypePerGram => this.toppingTypePerGram;
        public double Calories => this.Weight * this.ToppingTypePerGram * DEFAULT_CAL_PER_GRAM;
    }
}
