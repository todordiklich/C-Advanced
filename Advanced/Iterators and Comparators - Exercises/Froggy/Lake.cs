using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Froggy
{
    public class Lake: IEnumerable<int>
    {
        private readonly List<int> stones;

        public Lake(ICollection<int> stones)
        {
            this.stones = stones.ToList();
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.stones.Count; i+=2)
            {
                yield return this.stones[i];
            }

            for (int i = this.stones.Count - 1; i > 0; i--)
            {
                if (i % 2 != 0)
                {
                    yield return this.stones[i];
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
