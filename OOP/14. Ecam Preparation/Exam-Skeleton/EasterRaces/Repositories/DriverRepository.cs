using System.Linq;
using System.Collections.Generic;

using EasterRaces.Repositories.Contracts;
using EasterRaces.Models.Drivers.Contracts;

namespace EasterRaces.Repositories
{
    public class DriverRepository : IRepository<IDriver>
    {
        private IList<IDriver> drivers;

        public DriverRepository()
        {
            this.drivers = new List<IDriver>();
        }
        public void Add(IDriver model)
        {
            if (!this.drivers.Contains(model))
            {
                this.drivers.Add(model);
            }
        }

        public IReadOnlyCollection<IDriver> GetAll() => this.drivers.ToList().AsReadOnly();

        public IDriver GetByName(string name)
        {
            return this.drivers.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(IDriver model)
        {
            return this.drivers.Remove(model);
        }
    }
}
