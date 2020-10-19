using System;
using System.Collections;
using System.Collections.Generic;

namespace CustomDoublyLinkedList
{
    public class CustomDoublyLinkedList<T>: IEnumerable<T>
    {
        public CustomDoublyLinkedList()
        {

        }

        public Node<T> Head { get; set; }
        public Node<T> Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(T element)
        {
            Node<T> newHead = new Node<T>(element);

            if (this.Count == 0)
            {
                this.Head = this.Tail = newHead;
            }
            else
            {
                newHead.Next = this.Head;
                this.Head.Previous = newHead;
                this.Head = newHead;
            }

            this.Count++;
        }

        public void AddLast(T element)
        {
            Node<T> newTail = new Node<T>(element);

            if (this.Count == 0)
            {
                this.Tail = this.Head = newTail;
            }
            else
            {
                newTail.Previous = this.Tail;
                this.Tail.Next = newTail;
                this.Tail = newTail;
            }

            this.Count++;
        }

        public T RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            Node<T> toRemove = this.Head;

            this.Head = this.Head.Next;
            if (this.Head != null)
            {
                this.Head.Previous = null;
            }
            else
            {
                this.Head = this.Tail = null;
            }

            this.Count--;
            return toRemove.Value;
        }

        public T RemoveLast()
        {
            if (this.Tail == null)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            Node<T> toRemove = this.Tail;

            this.Tail = this.Tail.Previous;
            if (this.Tail != null)
            {
                this.Tail.Next = null;
            }
            else
            {
                this.Tail = this.Head = null;
            }

            this.Count--;
            return toRemove.Value;
        }

        public void ForEach(Action<T> action)
        {
            Node<T> current = this.Head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public T[] ToArray()
        {
            T[] arr = new T[this.Count];
            this.ForEach(n =>
            {
                Node<T> current = this.Head;
                for (int i = 0; i < this.Count; i++)
                {
                    arr[i] = current.Value;
                    current = current.Next;
                }
            });

            return arr;
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = this.Head;

            while (current != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
