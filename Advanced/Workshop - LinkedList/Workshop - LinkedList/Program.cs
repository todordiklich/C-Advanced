using System;

namespace Workshop___LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            CustomDoublyLinkedList list = new CustomDoublyLinkedList();

            list.AddFirst(1);
            list.AddLast(2);
            list.AddLast(3);
            list.AddFirst(77);

            int[] arr = list.ToArray();
            Console.WriteLine(string.Join(" ", arr));
        }
    }
}
