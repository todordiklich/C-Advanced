using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop___CustomList_and_Stack
{
    public class CustomList
    {
        private int[] items;
        private const int INITIAL_CAPACITY = 2;

        public CustomList(int capacity = INITIAL_CAPACITY)
        {
            this.items = new int[capacity];
        }
        public int Count { get; private set; }

        public int this[int index]
        {
            get
            {
                this.ValidateIndex(index);

                return this.items[index];
            }
            set
            {
                this.ValidateIndex(index);

                this.items[index] = value;
            }
        }

        public void Add(int element)
        {
            this.ResizeIfNeeded();

            this.items[this.Count] = element;
            this.Count++;
        }

        public int RemoveAt(int index)
        {
            this.ValidateIndex(index);

            int toReturn = this.items[index];

            this.ShiftLeft(index);

            this.Count--;

            this.ShrinkIfNeeded();

            return toReturn;
        }

        public void Insert(int index, int item)
        {
            this.ValidateIndex(index);
            this.ResizeIfNeeded();
            this.ShiftRight(index);

            this.items[index] = item;
            this.Count++;
        }

        public bool Contains(int element)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.items[i] == element)
                {
                    return true;
                }
            }

            return false;
        }
        public void Swap(int firstIndex, int secondIndex)
        {
            this.ValidateIndex(firstIndex);
            this.ValidateIndex(secondIndex);

            int temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        private void ShiftRight(int index)
        {
            for (int i = this.Count - 1; i >= index; i--)
            {
                this.items[i + 1] = this.items[i];
            }
        }

        private void ShrinkIfNeeded()
        {
            if (this.Count <= this.items.Length / 4)
            {
                int[] copy = new int[this.items.Length / 2];
                for (int i = 0; i < this.Count; i++)
                {
                    copy[i] = this.items[i];
                }

                this.items = copy;
            }
        }

        private void ShiftLeft(int index)
        {
            for (int i = index; i < this.Count - 1; i++)
            {
                this.items[i] = this.items[i + 1];
            }
        }

        private void ResizeIfNeeded()
        {
            if (this.Count == this.items.Length)
            {
                int[] copy = new int[this.items.Length * 2];

                for (int i = 0; i < this.items.Length; i++)
                {
                    copy[i] = this.items[i];
                }

                this.items = copy;
            }
        }

        private void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new ArgumentOutOfRangeException("Invalid index");
            }
        }
    }
}
