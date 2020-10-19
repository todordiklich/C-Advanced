using System;
using System.Collections;
using System.Collections.Generic;

namespace Froggy
{
    public class Lake: IEnumerable<int>
    {
        private List<int> stones;
        private List<int> path;

        public Lake(List<int> stones)
        {
            this.stones = stones;
            this.path = new List<int>();

            this.MoveForward();
            this.MoveBackwards();
        }

        private void MoveForward()
        {
            for (int i = 0; i < this.stones.Count; i++)
            {
                if (i % 2 == 0)
                {
                    this.path.Add(stones[i]);
                }
            }
        }

        private void MoveBackwards()
        {
            for (int i = this.stones.Count - 1; i >= 0; i--)
            {
                if (i % 2 != 0)
                {
                    this.path.Add(this.stones[i]);
                }
            }
        }

        public void Print()
        {
            Console.WriteLine(string.Join(", ", this.path));
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.path.Count; i++)
            {
                yield return this.path[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
