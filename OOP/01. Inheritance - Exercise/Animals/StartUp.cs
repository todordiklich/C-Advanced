using System;

namespace Animals
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "Beast!")
                {
                    break;
                }

                string[] arguments = Console.ReadLine().Split();
                string name = arguments[0];
                int age = int.Parse(arguments[1]);
                string gender = arguments[2];

                Animal animal;
                if (input == "Dog")
                {
                    animal = new Dog(name, age, gender);
                }
                else if (input == "Cat")
                {
                    animal = new Cat(name, age, gender);
                }
                else if (input == "Frog")
                {
                    animal = new Frog(name, age, gender);
                }
                else if (input == "Kitten")
                {
                    animal = new Kitten(name, age);
                }
                else // input == "Tomcat"
                {
                    animal = new Tomcat(name, age);
                }

                Console.WriteLine(animal);
            }
        }
    }
}
