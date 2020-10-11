using System.Collections.Generic;

namespace _09._Pokemon_Trainer
{
    public class Trainer
    {
        public Trainer(string name)
        {
            Name = name;
            Pokemons = new List<Pokemon>();
        }
        public string Name { get; set; }
        public int NumberOfBadges { get; set; }
        public List<Pokemon> Pokemons { get; set; }

        public void PokemonsLooseHealth()
        {
            foreach (var pokemon in Pokemons)
            {
                pokemon.Health -= 10;
            }

            Pokemons.RemoveAll(p => p.Health <= 0);
        }
    }
}
