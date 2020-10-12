using System;
using System.Collections.Generic;
using System.Text;

namespace Workshop___LinkedList
{
    public class CustomDoublyLinkedList
    {
        public CustomDoublyLinkedList()
        {

        }

        public Node Head { get; set; }
        public Node Tail { get; set; }
        public int Count { get; private set; }

        public void AddFirst(int element)
        {
            Node newHead = new Node(element);

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

        public void AddLast(int element)
        {
            Node newTail = new Node(element);

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

        public int RemoveFirst()
        {
            if (this.Head == null)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            Node toRemove = this.Head;

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

        public int RemoveLast()
        {
            if (this.Tail == null)
            {
                throw new InvalidOperationException("The collection is empty!");
            }

            Node toRemove = this.Tail;

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

        public void ForEach(Action<int> action)
        {
            Node current = this.Head;

            while (current != null)
            {
                action(current.Value);
                current = current.Next;
            }
        }

        public int[] ToArray()
        {
            int[] arr = new int[this.Count];
            this.ForEach(n =>
            {
                Node current = this.Head;
                for (int i = 0; i < this.Count; i++)
                {
                    arr[i] = current.Value;
                    current = current.Next;
                }
            });

            return arr;
        }
    }
}
