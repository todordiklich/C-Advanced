namespace INStock.Tests
{
    using System;
    using System.Linq;

    using NUnit.Framework;

    using INStock.Models;
    using INStock.Contracts;

    public class ProductStockTests
    {
        IProductStock productStock;
        IProduct product;
        IProduct[] products;

        [SetUp]
        public void SetUp()
        {
            productStock = new ProductStock();
            product = new Product("Product", 10, 1);
        }

        [Test]
        public void AddShouldWorkProperly()
        {
            productStock.Add(product);

            Assert.AreEqual(1, productStock.Count);
        }

        [Test]
        public void ContainsShouldReturnTrue()
        {
            productStock.Add(product);

            Assert.AreEqual(true, productStock.Contains(product));
        }

        [Test]
        public void ContainsShouldReturnFalse()
        {
            Assert.AreEqual(false, productStock.Contains(product));
        }

        [Test]
        public void FindShouldRetunrSearchedItem()
        {
            productStock.Add(product);

            Assert.AreEqual(product.Label, productStock.Find(0).Label);
        }

        [Test]
        public void FindShouldThrowException()
        {
            productStock.Add(product);

            Assert.Throws<IndexOutOfRangeException>(() => productStock.Find(3));
        }

        [Test]
        public void FindByLabelShouldRetunrSearchedItem()
        {
            productStock.Add(product);

            Assert.AreEqual(product.Label, productStock.FindByLabel(product.Label).Label);
        }

        [Test]
        public void FindByLabelShouldThrowException()
        {
            Assert.Throws<ArgumentException>(() => productStock.FindByLabel(product.Label));
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnThreeProducts()
        {
            GenerateProducts(10);

            foreach (var p in products)
            {
                productStock.Add(p);
            }

            int actualResult = productStock.FindAllInPriceRange(1, 3).Count();
            int expectedResult = 3;

            Assert.AreEqual(expectedResult, actualResult);
            Assert.AreEqual(3, productStock.FindByLabel("3").Price);
            Assert.AreEqual(2, productStock.FindByLabel("2").Price);
            Assert.AreEqual(1, productStock.FindByLabel("1").Price);
        }

        [Test]
        public void FindAllInPriceRangeShouldReturnEmptyCollection()
        {
            int actualResult = productStock.FindAllInPriceRange(2, 3).Count();
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindAllByPriceRangeShouldReturnTwoElements()
        {
            IProduct product2 = new Product("P2", 10, 2);
            productStock.Add(product);
            productStock.Add(product2);

            int actualResult = productStock.FindAllByPrice(10).Count();
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindAllByPriceRangeShouldReturnZeroElements()
        {
            productStock.Add(product);

            int actualResult = productStock.FindAllByPrice(100).Count();
            int expectedResult = 0;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindMostExpensiveProductsShouldReturnTwoElements()
        {
            IProduct product2 = new Product("P2", 10, 2);
            productStock.Add(product);
            productStock.Add(product2);

            int actualResult = productStock.FindMostExpensiveProducts().Count();
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindMostExpensiveProductsShouldReturnOneElements()
        {
            IProduct product2 = new Product("P2", 50, 2);
            productStock.Add(product);
            productStock.Add(product2);

            int actualResult = productStock.FindMostExpensiveProducts().Count();
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void FindAllByQuantityShouldReturnOneElements()
        {
            IProduct product2 = new Product("P2", 50, 2);
            productStock.Add(product);
            productStock.Add(product2);

            int actualResult = productStock.FindAllByQuantity(2).Count();
            int expectedResult = 1;

            Assert.AreEqual(expectedResult, actualResult);
        }
        [Test]
        public void FindAllByQuantityShouldReturnTwoElements()
        {
            IProduct product2 = new Product("P2", 50, 1);
            productStock.Add(product);
            productStock.Add(product2);

            int actualResult = productStock.FindAllByQuantity(1).Count();
            int expectedResult = 2;

            Assert.AreEqual(expectedResult, actualResult);
        }

        [Test]
        public void GetEnumeratorShouldReturnTenElements()
        {
            GenerateProducts(10);

            foreach (var p in products)
            {
                productStock.Add(p);
            }

            int expectedResult = 0;

            foreach (var product in productStock)
            {
                Assert.AreEqual(expectedResult.ToString(), product.Label);
                expectedResult++;
            }
        }

        [Test]
        public void ThisGetterShouldReturnElement()
        {
            GenerateProducts(10);

            foreach (var p in products)
            {
                productStock.Add(p);
            }

            string expectedResult = "0";

            Assert.AreEqual(expectedResult, productStock[0].Label);
        }

        [Test]
        public void ThisGetterShouldThrowException()
        {
            IProduct p;
            Assert.Throws<IndexOutOfRangeException>(() => p = productStock[1]);
        }

        [Test]
        public void ThisSetterShouldThrowIndexOutOfRangeException()
        {
            IProduct p = new Product("0", 0, 0);
            Assert.Throws<IndexOutOfRangeException>(() => productStock[1] = p);
        }

        [Test]
        public void ThisSetterShouldSetCorrectlyElement()
        {
            GenerateProducts(2);

            foreach (var p in products)
            {
                productStock.Add(p);
            }

            IProduct expectedResult = new Product("99", 99, 99);
            productStock[0] = expectedResult;

            Assert.AreEqual(expectedResult.Label, productStock[0].Label);
        }

        private void GenerateProducts(int count)
        {
            products = new Product[count];

            for (int i = 0; i < count; i++)
            {
                products[i] = new Product(i.ToString(), i, i);
            }
        }
    }
}
