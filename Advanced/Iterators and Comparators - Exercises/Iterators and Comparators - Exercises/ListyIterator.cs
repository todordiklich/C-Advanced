using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Iterators_and_Comparators___Exercises
{
    public class ListyIterator<T> : IEnumerable<T>
    {
        private List<T> items;
        private int index = 0;

        public ListyIterator(params T[] inputItems)
        {
            this.items = new List<T>(inputItems.ToList());
        }

        public bool Move()
        {
            if (this.index < this.items.Count - 1)
            {
                this.index++;
                return true;
            }

            return false;
        }

        public void Print()
        {
            this.EnsureNotEmpty();
            Console.WriteLine(this.items[index]);
        }

        public void PrintAll()
        {
            this.EnsureNotEmpty();

            foreach (var item in this.items)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }

        public bool HasNext()
        {
            int nextIndex = this.index + 1;

            if (nextIndex < this.items.Count)
            {
                return true;
            }

            return false;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                yield return this.items[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private void EnsureNotEmpty()
        {
            if (this.items.Count == 0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}
