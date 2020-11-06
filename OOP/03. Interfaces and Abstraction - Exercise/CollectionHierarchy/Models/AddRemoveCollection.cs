using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : AddCollection, IAddRemoveCollection
    {
        protected List<string> removedItems;
        public AddRemoveCollection()
            :base()
        {
            this.removedItems = new List<string>();
        }
        public virtual void Remove()
        {
            int lastItemIndex = items.Count - 1;
            string lastItem = this.items[lastItemIndex];
            this.removedItems.Add(lastItem);

            this.items.Remove(lastItem);
        }
        public override void Add(string item)
        {
            this.indexes.Add(0);

            this.items.Add(item);
        }
        public void PrintRemovedItems()
        {
            Console.WriteLine(string.Join(" ", removedItems));
        }
    }
}
