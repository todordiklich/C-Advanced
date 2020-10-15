using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Generic_Box_of_Integer
{
    public class Box<T>
    {
        private List<T> items;

        public Box(List<T> items)
        {
            this.items = items;
        }

        public void Swap(int firstIndex, int secondIndex)
        {
            var temp = this.items[firstIndex];
            this.items[firstIndex] = this.items[secondIndex];
            this.items[secondIndex] = temp;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < items.Count; i++)
            {
                sb.AppendLine($"{items[i].GetType().FullName}: {items[i]}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
