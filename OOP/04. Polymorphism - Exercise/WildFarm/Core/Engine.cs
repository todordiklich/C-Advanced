using System;
using System.Collections.Generic;

using WildFarm.Contracts;
using WildFarm.Factoryes;

namespace WildFarm.Core
{
    public class Engine
    {
        private List<IAnimal> animals;
        private IAnimal animal;
        private IFood food;
        private AnimalFactory animalFactory;
        private FoodFactory foodFactory;
        public Engine()
        {
            this.animals = new List<IAnimal>();
            this.animalFactory = new AnimalFactory();
            this.foodFactory = new FoodFactory();
        }
        public void Run()
        {
            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                string[] animalArgs = command.Split();
                animal = animalFactory.ProduceAnimal(animalArgs);

                string[] foodArgs = Console.ReadLine().Split();
                food = foodFactory.ProduceFood(foodArgs);

                animals.Add(animal);
                animal.ProduseSound();
                animal.Eat(food);

            }

            foreach (var currAnimal in animals)
            {
                Console.WriteLine(currAnimal);
            }
        }
    }
}
