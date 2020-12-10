﻿using System.Linq;
using System.Collections.Generic;

using EasterRaces.Models.Races.Contracts;
using EasterRaces.Repositories.Contracts;

namespace EasterRaces.Repositories
{
    public class RaceRepository : IRepository<IRace>
    {
        private IList<IRace> races;

        public RaceRepository()
        {
            this.races = new List<IRace>();
        }
        public void Add(IRace model)
        {
            if (!this.races.Contains(model))
            {
                this.races.Add(model);
            }
        }

        public IReadOnlyCollection<IRace> GetAll() => this.races.ToList().AsReadOnly();

        public IRace GetByName(string name)
        {
            return this.races.FirstOrDefault(c => c.Name == name);
        }

        public bool Remove(IRace model)
        {
            return this.races.Remove(model);
        }
    }
}
