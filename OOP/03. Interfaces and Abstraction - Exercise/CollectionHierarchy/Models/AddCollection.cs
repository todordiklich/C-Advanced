using System.Collections.Generic;

using CollectionHierarchy.Contracts;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        protected List<string> items;
        protected List<int> indexes;
        public AddCollection()
        {
            this.items = new List<string>();
            this.indexes = new List<int>();
        }
        public virtual void Add(string item)
        {
            int index = this.items.Count;
            this.indexes.Add(index);

            this.items.Add(item);
        }
        public void PrintAddedIndexes()
        {
            System.Console.WriteLine(string.Join(" ", this.indexes));
        }
    }
}
