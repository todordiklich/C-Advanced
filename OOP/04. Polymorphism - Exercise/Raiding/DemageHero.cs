namespace Raiding
{
    public abstract class DemageHero : BaseHero
    {
        public DemageHero(string name, int power) 
            : base(name, power)
        {
        }

        public override string CastAbility()
        {
            return $"{this.GetType().Name} - {this.Name} hit for {this.Power} damage";
        }
    }
}
