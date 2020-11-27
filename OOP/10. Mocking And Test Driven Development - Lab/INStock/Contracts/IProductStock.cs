using System.Collections;
using System.Collections.Generic;

namespace INStock.Contracts
{
    public interface IProductStock
    {
        public int Count { get; }
        public IProduct this[int index] { get; set; }

        public void Add(IProduct product);
        public bool Contains(IProduct product);
        public IProduct Find(int index);
        public IProduct FindByLabel(string label);
        public IEnumerable<IProduct> FindAllInPriceRange(decimal lo, decimal hi);
        public IEnumerable<IProduct> FindAllByPrice(decimal price);
        public IEnumerable<IProduct> FindMostExpensiveProducts();
        public IEnumerable<IProduct> FindAllByQuantity(int quantityNeeded);
        public IEnumerator<IProduct> GetEnumerator();
    }
}
