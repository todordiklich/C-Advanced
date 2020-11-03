using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;

        public Pizza(string name, Dough dough)
        {
            this.Name = name;
            this.Dought = dough;
            this.toppings = new List<Topping>();
        }

        public string Name 
        {
            get => this.name; 

            private set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length < 1 || value.Length > 15 )
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }

                this.name = value;
            }
        }
        public Dough Dought { get; private set; }
        public IReadOnlyCollection<Topping> Toppings => this.toppings.AsReadOnly();

        public void AddTopping(Topping topping)
        {
            if (this.toppings.Count > 10)
            {
                throw new ArgumentException("Number of toppings should be in range [0..10].");
            }

            this.toppings.Add(topping);
        }

        public override string ToString()
        {
            double totalCalories = this.Dought.Calories;
            foreach (var topping in this.toppings)
            {
                totalCalories += topping.Calories;
            }

            return $"{this.Name} - {totalCalories:F2} Calories.";
        }
    }
}
