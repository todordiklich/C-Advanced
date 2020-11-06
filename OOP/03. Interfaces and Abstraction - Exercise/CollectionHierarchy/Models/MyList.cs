using CollectionHierarchy.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList : AddRemoveCollection, IMyList
    {
        public MyList()
            : base()
        {

        }
        public int Used 
        { 
            get
            { 
                return this.items.Count; 
            }
        }
        public override void Remove()
        {
            this.removedItems.Add(items[0]);
            string itemToRemove = items[0];
            this.items.Remove(itemToRemove);
        }

    }
}
