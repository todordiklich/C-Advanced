namespace CounterStrike.Models.Guns
{
    public class Pistol : Gun
    {
        private const int FIRE_RATE = 1;

        public Pistol(string name, int bulletsCount)
            : base(name, bulletsCount)
        { }

        public override int Fire()
        {
            if (this.BulletsCount >= FIRE_RATE)
            {
                this.BulletsCount -= FIRE_RATE;
                return FIRE_RATE;
            }
            else
            {
                return 0;
            }
        }
    }
}
