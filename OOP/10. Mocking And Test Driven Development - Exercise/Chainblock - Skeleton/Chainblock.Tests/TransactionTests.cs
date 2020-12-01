using NUnit.Framework;

using Chainblock.Models;
using Chainblock.Contracts;

namespace Chainblock.Tests
{
    public class TransactionTests
    {

        [Test]
        [TestCase(1, TransactionStatus.Successfull, "From", "To", 100d)]
        public void ConstructorShouldSetPropertiesCorrectly(int id, TransactionStatus status, string from, string to, double amount)
        {
            ITransaction transaction = new Transaction(id, status, from, to, amount);

            Assert.AreEqual(id, transaction.Id);
            Assert.AreEqual(status, transaction.Status);
            Assert.AreEqual(from, transaction.From);
            Assert.AreEqual(to, transaction.To);
            Assert.AreEqual(amount, transaction.Amount);
        }
    }
}
