﻿namespace WildFarm.Contracts
{
    public interface IAnimal
    {
        string Name { get; }
        double Weight { get; }
        int FoodEaten { get; }
        void ProduseSound();
        void Eat(IFood food);
    }
}
