using System;
using System.Collections.Generic;

namespace ShoppingSpree
{
    public class Person
    {
        private string name;
        private decimal money;
        private List<Product> products;

        public Person(string name, decimal money)
        {
            this.Name = name;
            this.Money = money;
            this.products = new List<Product>();
        }
        public string Name 
        {
            get => this.name;

            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Name cannot be empty");
                }

                this.name = value;
            }
        }
        public decimal Money 
        {
            get => this.money;

            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Money cannot be negative");
                }

                this.money = value;
            }
        }
        public IReadOnlyCollection<Product> Products => this.products.AsReadOnly();

        public string Buy(Product product)
        {
            if (this.money >= product.Cost)
            {
                this.products.Add(product);
                this.money -= product.Cost;
                return $"{this.Name} bought {product.Name}";
            }
            else
            {
                return $"{this.Name} can't afford {product.Name}";
            }
        }

        public override string ToString()
        {
            return products.Count > 0
                ? $"{this.Name} - {string.Join(", ", products)}"
                : $"{this.Name} - Nothing bought ";
        }
    }
}
