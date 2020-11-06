﻿using System;

using MilitaryElite.Contracts;
using MilitaryElite.Enumerations;
using MilitaryElite.Exceptions;

namespace MilitaryElite.Models
{
    public abstract class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        protected SpecialisedSoldier(int id, string firstName, string lastName, decimal salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            this.Corps = TryParseCorps(corps);
        }

        public Corps Corps { get; private set; }
        private Corps TryParseCorps(string corpsString)
        {
            Corps corps;

            bool parsed = Enum.TryParse<Corps>(corpsString, out corps);

            if (!parsed)
            {
                throw new InvalidCorpsException();
            }

            return corps;
        }
        public override string ToString()
        {
            return base.ToString() + Environment.NewLine + $"Corps: {this.Corps.ToString()}";
        }
    }
}
