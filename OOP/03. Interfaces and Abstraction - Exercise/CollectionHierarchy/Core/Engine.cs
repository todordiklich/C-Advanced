using CollectionHierarchy.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Core
{
    public class Engine
    {
        private AddCollection addCollectionItems;
        private AddRemoveCollection addRemoveCollectionItems;
        private MyList myListItems;
        public Engine()
        {
            addCollectionItems = new AddCollection();
            addRemoveCollectionItems = new AddRemoveCollection();
            myListItems = new MyList();
        }
        public void Run()
        {
            string[] input = Console
                .ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < input.Length; i++)
            {
                addCollectionItems.Add(input[i]);
                addRemoveCollectionItems.Add(input[i]);
                myListItems.Add(input[i]);
            }

            addCollectionItems.PrintAddedIndexes();
            addRemoveCollectionItems.PrintAddedIndexes();
            myListItems.PrintAddedIndexes();

            int itemsToRemove = int.Parse(Console.ReadLine());
            for (int i = 0; i < itemsToRemove; i++)
            {
                addRemoveCollectionItems.Remove();
                myListItems.Remove();
            }

            myListItems.PrintRemovedItems();
            addRemoveCollectionItems.PrintRemovedItems();
        }
    }
}
