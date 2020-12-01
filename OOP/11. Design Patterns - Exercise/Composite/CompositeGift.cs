using System.Collections.Generic;

namespace Composite
{
    public class CompositeGift : GiftBase, IGiftOperations
    {
        private List<GiftBase> _gifts;

        public CompositeGift(string name, int price)
            :base(name, price)
        {
            _gifts = new List<GiftBase>();
        }

        public override int CalculateTotalPrice()
        {
            var total = 0;

            foreach (var gift in _gifts)
            {
                total += gift.Price;
            }

            return total;
        }

        public void Add(GiftBase gift)
        {
            _gifts.Add(gift);
        }

        public void Remove(GiftBase gift)
        {
            _gifts.Remove(gift);
        }
    }
}
