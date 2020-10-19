using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;

namespace CustomStack
{
    public class Stack<T> : IEnumerable<T>
    {
        private System.Collections.Generic.Stack<T> items;

        public Stack(params T[] items)
        {
            this.items = new System.Collections.Generic.Stack<T>(items);
        }

        public int Count => this.items.Count;

        public void Push(T element)
        {
            this.items.Push(element);
        }

        public void Pop()
        {
            if (this.EnsureNotEmpty())
            {
                this.items.Pop();
            }
            else
            {
                Console.WriteLine("No elements");
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            System.Collections.Generic.Stack<T> newItems =
                new System.Collections.Generic.Stack<T>(this.items.Reverse().ToArray());
            T current = newItems.Pop();
            while (current != null)
            {
                yield return current;

                if (newItems.Count == 0)
                {
                    break;
                }
                current = newItems.Pop();
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private bool EnsureNotEmpty()
        {
            if (this.items.Count() == 0)
            {                
                return false;
            }

            return true;
        }
    }
}
