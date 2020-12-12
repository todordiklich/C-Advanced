using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

using Bakery.Models.Tables;
using Bakery.Models.Drinks;
using Bakery.Models.BakedFoods;
using Bakery.Utilities.Messages;
using Bakery.Models.Tables.Contracts;
using Bakery.Models.Drinks.Contracts;
using Bakery.Models.BakedFoods.Contracts;

namespace Bakery.Core.Contracts
{
    public class Controller : IController
    {
        private List<IBakedFood> foods;
        private List<IDrink> drinks;
        private List<ITable> tables;

        private decimal totalIncome;

        public Controller()
        {
            this.foods = new List<IBakedFood>();
            this.drinks = new List<IDrink>();
            this.tables = new List<ITable>();
        }

        public string AddDrink(string type, string name, int portion, string brand)
        {
            IDrink drink = null;

            if (type.ToLower() == "tea")
            {
                drink = new Tea(name, portion, brand);
            }
            else if (type.ToLower() == "water")
            {
                drink = new Water(name, portion, brand);
            }

            if (drink != null)
            {
                this.drinks.Add(drink);
                return String.Format(OutputMessages.DrinkAdded, drink.Name, drink.Brand);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public string AddFood(string type, string name, decimal price)
        {
            IBakedFood food = null;

            if (type.ToLower() == "bread")
            {
                food = new Bread(name, price);
            }
            else if (type.ToLower() == "cake")
            {
                food = new Cake(name, price);
            }

            if (food != null)
            {
                this.foods.Add(food);
                return String.Format(OutputMessages.FoodAdded, food.Name, food.GetType().Name);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public string AddTable(string type, int tableNumber, int capacity)
        {
            ITable table = null;

            if (type.ToLower() == "insidetable")
            {
                table = new InsideTable(tableNumber, capacity);
            }
            else if (type.ToLower() == "outsidetable")
            {
                table = new OutsideTable(tableNumber, capacity);
            }

            if (table != null)
            {
                this.tables.Add(table);
                return String.Format(OutputMessages.TableAdded, table.TableNumber);
            }
            else
            {
                throw new ArgumentNullException();
            }
        }

        public string GetFreeTablesInfo()
        {
            List<ITable> freeTables = this.tables.Where(t => t.IsReserved == false).ToList();
            StringBuilder sb = new StringBuilder();

            foreach (var table in freeTables)
            {
                sb.AppendLine(table.GetFreeTableInfo());
            }

            return sb.ToString().TrimEnd();
        }

        public string GetTotalIncome()
        {
            //decimal currTablesIncome = this.tables.Sum(t => t.Price);

            return String.Format(OutputMessages.TotalIncome, totalIncome);
        }

        public string LeaveTable(int tableNumber)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);

            if (table == null)
            {
                throw new ArgumentNullException();
            }

            StringBuilder sb = new StringBuilder();

            sb
                .AppendLine($"Table: {tableNumber}")
                .AppendLine($"Bill: {table.GetBill():f2}");

            this.totalIncome += table.GetBill();

            table.Clear();

            return sb.ToString().TrimEnd();
        }

        public string OrderDrink(int tableNumber, string drinkName, string drinkBrand)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IDrink drink = this.drinks.FirstOrDefault(d => d.Name == drinkName && d.Brand == drinkBrand);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (drink == null)
            {
                return String.Format(OutputMessages.NonExistentDrink, drinkName, drinkBrand);
            }

            table.OrderDrink(drink);
            string str = drinkName + " " + drinkBrand;
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, str);
        }

        public string OrderFood(int tableNumber, string foodName)
        {
            ITable table = this.tables.FirstOrDefault(t => t.TableNumber == tableNumber);
            IBakedFood food = this.foods.FirstOrDefault(f => f.Name == foodName);

            if (table == null)
            {
                return String.Format(OutputMessages.WrongTableNumber, tableNumber);
            }
            if (food == null)
            {
                return String.Format(OutputMessages.NonExistentFood, foodName);
            }

            table.OrderFood(food);
            return String.Format(OutputMessages.FoodOrderSuccessful, tableNumber, foodName);
        }

        public string ReserveTable(int numberOfPeople)
        {
            ITable table = this.tables.FirstOrDefault(t => t.IsReserved == false && t.Capacity >= numberOfPeople);

            if (table == null)
            {
                return String.Format(OutputMessages.ReservationNotPossible, numberOfPeople);
            }
            else
            {
                table.Reserve(numberOfPeople);

                return String.Format(OutputMessages.TableReserved, table.TableNumber, numberOfPeople);
            }
        }
    }
}
