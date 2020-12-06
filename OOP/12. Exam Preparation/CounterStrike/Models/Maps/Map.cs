using System.Linq;
using System.Collections.Generic;

using CounterStrike.Models.Players;
using CounterStrike.Models.Maps.Contracts;
using CounterStrike.Models.Players.Contracts;

namespace CounterStrike.Models.Maps
{
    public class Map : IMap
    {
        private List<IPlayer> terrorists;
        private List<IPlayer> counterTerrorists;

        public Map()
        {
            this.terrorists = new List<IPlayer>();
            this.counterTerrorists = new List<IPlayer>();
        }
        public string Start(ICollection<IPlayer> players)
        {
            SeparateTeams(players);

            while (true)
            {
                AttackTeam(terrorists, counterTerrorists);
                AttackTeam(counterTerrorists, terrorists);

                if (!IsTeamAlive(terrorists))
                {
                    return "Counter Terrorist wins!";
                    break;
                }
                if (!IsTeamAlive(counterTerrorists))
                {
                    return "Terrorist wins!";
                    break;
                }
            }
        }

        private bool IsTeamAlive(List<IPlayer> team)
        {
            return team.Any(p => p.IsAlive == true);
        }

        private void AttackTeam(List<IPlayer> attackers, List<IPlayer> deffenders)
        {
            foreach (var attacker in attackers)
            {
                //if (!attacker.IsAlive)
                //{
                //    continue;
                //}

                foreach (var defender in deffenders)
                {
                    if (defender.IsAlive)
                    {
                        defender.TakeDamage(attacker.Gun.Fire());
                    }
                }
            }
        }

        private void SeparateTeams(ICollection<IPlayer> players)
        {
            foreach (var player in players)
            {
                if (player is Terrorist)
                {
                    terrorists.Add(player);
                }
                else if (player is CounterTerrorist)
                {
                    counterTerrorists.Add(player);
                }
            }
        }
    }
}
