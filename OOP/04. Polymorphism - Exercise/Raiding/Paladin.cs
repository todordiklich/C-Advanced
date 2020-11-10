namespace Raiding
{
    public class Paladin : HealingHero, IHero
    {
        public Paladin(string name, int power = 100) 
            : base(name, power)
        {
        }
    }
}
