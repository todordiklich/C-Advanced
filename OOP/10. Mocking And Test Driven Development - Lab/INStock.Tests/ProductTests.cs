namespace INStock.Tests
{
    using INStock.Contracts;
    using INStock.Models;
    using NUnit.Framework;

    public class ProductTests
    {
        private IProduct product;

        [Test]
        [TestCase("1", 1, 1)]
        [TestCase("2", 2, 2)]
        public void ConstructorShouldWorkCorrectly(string label, decimal price, int quantity)
        {
            product = new Product(label, price, quantity);

            Assert.AreEqual(label, product.Label);
            Assert.AreEqual(price, product.Price);
            Assert.AreEqual(quantity, product.Quantity);
        }
    }
}