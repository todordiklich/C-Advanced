using System;
using System.Collections.Generic;

namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<IHero> heroes = new List<IHero>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string name = Console.ReadLine();
                string type = Console.ReadLine();

                IHero hero = null;
                if (type == "Druid")
                {
                    hero = new Druid(name);
                }
                else if (type == "Paladin")
                {
                    hero = new Paladin(name);
                }
                else if (type == "Rogue")
                {
                    hero = new Rogue(name);
                }
                else if (type == "Warrior")
                {
                    hero = new Warrior(name);
                }
                else
                {
                    Console.WriteLine("Invalid hero!");
                    i--;
                }
                
                if (hero != null)
                {
                    heroes.Add(hero);
                }
            }

            int points = int.Parse(Console.ReadLine());

            bool hasWon = false;
            foreach (var hero in heroes)
            {
                Console.WriteLine(hero.CastAbility());
                points -= hero.Power;
                if (points <= 0)
                {
                    hasWon = true;
                }
            }

            Console.WriteLine(hasWon == true ? "Victory!" : "Defeat...");
        }
    }
}
