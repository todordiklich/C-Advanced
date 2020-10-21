using System.Text;
using System.Collections.Generic;

namespace Parking
{
    public class Parking
    {
        private List<Car> data;
        public Parking(string type, int capacity)
        {
            this.Type = type;
            this.Capacity = capacity;
            data = new List<Car>();
        }

        public string Type { get; private set; }
        public int Capacity { get; private set; }
        public int Count => this.data.Count;

        public void Add(Car car)
        {
            if (this.Count < this.Capacity)
            {
                this.data.Add(car);
            }
        }
        public bool Remove(string manufacturer, string model)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Manufacturer == manufacturer 
                    && this.data[i].Model == model)
                {
                    this.data.RemoveAt(i);
                    return true;
                }
            }

            return false;
        }

        public Car GetLatestCar()
        {
            if (this.Count > 0)
            {
                Car currCar = this.data[0];

                for (int i = 0; i < this.Count; i++)
                {
                    if (currCar.Year < this.data[i].Year)
                    {
                        currCar = this.data[i];
                    }
                }

                return currCar;
            }

            return null;
        }

        public Car GetCar(string manufacturer, string model)
        {
            Car car = null;

            for (int i = 0; i < this.Count; i++)
            {
                if (this.data[i].Manufacturer == manufacturer
                    && this.data[i].Model == model)
                {
                    car = this.data[i];
                    break;
                }
            }

            return car;
        }

        public string GetStatistics()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"The cars are parked in {this.Type}:");
            for (int i = 0; i < this.Count; i++)
            {
                sb.AppendLine(this.data[i].ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
