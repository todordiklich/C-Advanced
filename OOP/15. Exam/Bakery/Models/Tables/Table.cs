using System;
using System.Text;
using System.Linq;
using System.Collections.Generic;

using Bakery.Utilities.Messages;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Models.Tables
{
    public abstract class Table : ITable
    {
        private int tableNumber;
        private int capacity;
        private int numberOfPeople;
        private decimal pricePerPerson;
        private bool isReserved;

        private List<IBakedFood> foods;
        private List<IDrink> drinks;

        public Table(int tableNumber, int capacity, decimal pricePerPerson)
        {
            this.TableNumber = tableNumber;
            this.Capacity = capacity;
            this.PricePerPerson = pricePerPerson;

            this.IsReserved = false;

            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
        }

        public int TableNumber
        {
            get { return this.tableNumber; }
            private set
            {
                this.tableNumber = value;
            }
        }

        public int Capacity
        {
            get { return this.capacity; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidTableCapacity);
                }

                this.capacity = value;
            }
        }

        public int NumberOfPeople
        {
            get { return this.numberOfPeople; }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidNumberOfPeople);
                }

                this.numberOfPeople = value;
            }
        }


        public decimal PricePerPerson
        {
            get { return this.pricePerPerson; }
            private set
            {
                this.pricePerPerson = value;
            }
        }

        public bool IsReserved 
        {
            get { return this.isReserved; }
            private set
            {
                this.isReserved = value;
            }
        }

        public decimal Price => this.PricePerPerson * this.NumberOfPeople;

        public void Clear()
        {
            this.drinks.Clear();
            this.foods.Clear();

            this.numberOfPeople = 0;
            this.isReserved = false;
        }

        public decimal GetBill()
        {
            decimal drinksBill = this.drinks.Sum(d => d.Price);
            decimal foodsBill = this.foods.Sum(f => f.Price);
            decimal total = drinksBill + foodsBill + this.Price;

            return total;
        }

        public string GetFreeTableInfo()
        {
            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Table: {this.TableNumber}")
                .AppendLine($"Type: {this.GetType().Name}")
                .AppendLine($"Capacity: {this.Capacity}")
                .AppendLine($"Price per Person: {this.pricePerPerson}");

            return sb.ToString().TrimEnd();
        }

        public void OrderDrink(IDrink drink)
        {
            this.drinks.Add(drink);
        }

        public void OrderFood(IBakedFood food)
        {
            this.foods.Add(food);
        }

        public void Reserve(int numberOfPeople)
        {
            this.IsReserved = true;
            this.NumberOfPeople = numberOfPeople;
        }
    }
}
