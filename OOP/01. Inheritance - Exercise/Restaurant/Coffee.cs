﻿namespace Restaurant
{
    public class Coffee : HotBeverage
    {
        public Coffee(string name, double caffeine) 
            : base(name, 3.5m, 50d)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine { get; set; }
    }
}
