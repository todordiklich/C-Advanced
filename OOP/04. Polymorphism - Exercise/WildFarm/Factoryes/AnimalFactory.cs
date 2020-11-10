using WildFarm.Contracts;
using WildFarm.Models.Animals.Birds;
using WildFarm.Models.Animals.Mammals;
using WildFarm.Models.Animals.Mammals.Felines;

namespace WildFarm.Factoryes
{
    public class AnimalFactory
    {
        public AnimalFactory()
        {

        }

        public IAnimal ProduceAnimal(string[] arguments)
        {
            IAnimal animal = null;

            string animalType = arguments[0];
            string name = arguments[1];
            double weight = double.Parse(arguments[2]);

            if (animalType == "Cat" || animalType == "Tiger")
            {
                string livingRegieon = arguments[3];
                string breed = arguments[4];

                if (animalType == "Cat")
                {
                    animal = new Cat(name, weight, livingRegieon, breed);
                }
                else
                {
                    animal = new Tiger(name, weight, livingRegieon, breed);
                }
            }
            else if (animalType == "Owl" || animalType == "Hen")
            {
                double wingSize = double.Parse(arguments[3]);

                if (animalType == "Owl")
                {
                    animal = new Owl(name, weight, wingSize);
                }
                else
                {
                    animal = new Hen(name, weight, wingSize);
                }
            }
            else if (animalType == "Dog" || animalType == "Mouse")
            {
                string livingRegion = arguments[3];

                if (animalType == "Dog")
                {
                    animal = new Dog(name, weight, livingRegion);
                }
                else
                {
                    animal = new Mouse(name, weight, livingRegion);
                }
            }

            return animal;
        }
    }
}
