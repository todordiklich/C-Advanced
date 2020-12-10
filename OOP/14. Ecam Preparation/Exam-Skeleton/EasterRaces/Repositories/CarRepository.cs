using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Cars.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class CarRepository : IRepository<ICar>
    {
        private IList<ICar> cars;

        public CarRepository()
        {
            this.cars = new List<ICar>();
        }
        public void Add(ICar model)
        {
            if (!this.cars.Contains(model))
            {
                this.cars.Add(model);
            }
        }

        public IReadOnlyCollection<ICar> GetAll() => this.cars.ToList().AsReadOnly();

        public ICar GetByName(string name)
        {
            return this.cars.FirstOrDefault(c => c.Model == name);
        }

        public bool Remove(ICar model)
        {
            return this.cars.Remove(model);
        }
    }
}
