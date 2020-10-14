using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class CustomStack
    {
        private int[] items;
        private const int INITIAL_CAPACITY = 4;

        public CustomStack(int capacity = INITIAL_CAPACITY)
        {
            this.items = new int[capacity];
        }

        public int Count { get; private set; }

        public void Push(int element)
        {
            this.ResizeIfNeeded();

            this.items[this.Count] = element;
            this.Count++;
        }

        public int Pop()
        {
            this.EnsureNotEmpty();

            int toReturn = this.items[this.Count - 1];
            this.Count--;

            return toReturn;
        }

        public int Peek()
        {
            this.EnsureNotEmpty();

            return this.items[this.Count - 1];
        }

        public void ForEach(Action<object> action)
        {
            this.EnsureNotEmpty();

            for (int i = this.Count -1; i >= 0; i--)
            {
                action(this.items[i]);
            }
        }

        private void ResizeIfNeeded()
        {
            if (this.Count == this.items.Length)
            {
                int[] copy = new int[this.items.Length * 2];
                for (int i = 0; i < this.Count; i++)
                {
                    copy[i] = this.items[i];
                }

                this.items = copy;
            }
        }

        private void EnsureNotEmpty()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("CustomStack is empty!");
            }
        }
    }
}
