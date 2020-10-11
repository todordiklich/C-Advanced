using System;
using System.Linq;
using System.Collections.Generic;

namespace _09._Pokemon_Trainer
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Trainer> trainers = new List<Trainer>();

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "Tournament")
                {
                    break;
                }

                string[] cmdArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string trainerName = cmdArgs[0];
                string pokemonName = cmdArgs[1];
                string pokemonElement = cmdArgs[2];
                int pokemonHealth = int.Parse(cmdArgs[3]);

                Pokemon pokemon = new Pokemon(pokemonName, pokemonElement, pokemonHealth);

                Trainer findTrainer = trainers.FirstOrDefault(t => t.Name == trainerName);

                if (findTrainer == null)
                {
                    Trainer trainer = new Trainer(trainerName);
                    trainer.Pokemons.Add(pokemon);
                    trainers.Add(trainer);
                }
                else
                {
                    int index = GetIndexByName(trainers, trainerName);
                    trainers[index].Pokemons.Add(pokemon);
                }

                
            }

            while (true)
            {
                string command = Console.ReadLine();
                if (command == "End")
                {
                    break;
                }

                if (command == "Fire" || command == "Water" || command == "Electricity")
                {
                    Battle(trainers, command);
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.NumberOfBadges))
            {
                Console.WriteLine($"{trainer.Name} {trainer.NumberOfBadges} {trainer.Pokemons.Count}");
            }
        }

        public static void Battle(List<Trainer> trainers, string element)
        {
            foreach (var trainer in trainers)
            {
                if (trainer.Pokemons.Any(p => p.Element == element))
                {
                    trainer.NumberOfBadges++;
                }
                else
                {
                    trainer.PokemonsLooseHealth();
                }
            }
        }

        public static int GetIndexByName(List<Trainer> trainers, string name)
        {
            for (int i = 0; i < trainers.Count; i++)
            {
                if (trainers[i].Name == name)
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
