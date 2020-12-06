namespace CounterStrike.Models.Guns
{
    public class Rifle : Gun
    {
        private const int FIRE_RATE = 10;
        public Rifle(string name, int bulletsCount) 
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
