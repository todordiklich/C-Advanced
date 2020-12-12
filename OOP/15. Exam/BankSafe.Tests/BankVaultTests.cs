using NUnit.Framework;
using System;

namespace BankSafe.Tests
{
    public class BankVaultTests
    {
        private Item item;
        private BankVault bank;

        [SetUp]
        public void Setup()
        {
            item = new Item("Owner", "ItemId");
            bank = new BankVault();
        }

        [Test]
        public void ItemConstructorShouldWorkProperly()
        {
            Assert.AreEqual("Owner", item.Owner);
            Assert.AreEqual("ItemId", item.ItemId);
        }

        [Test]
        public void BankConstructorShouldWorkProperly()
        {
            Assert.AreEqual(12, bank.VaultCells.Count);
        }

        [Test]
        public void BankAddShouldThrowExceptionWhenAddingInUnexistingCell()
        {
            Assert.Throws<ArgumentException>(() => bank.AddItem("Unexisting", item));
        }

        [Test]
        public void BankAddShouldThrowExceptionWhenAddingInTakenCell()
        {
            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.AddItem("A1", item));
        }

        [Test]
        public void BankAddShouldThrowExceptionWhenAddingSameItemInOtherCell()
        {
            bank.AddItem("A1", item);

            Assert.Throws<InvalidOperationException>(() => bank.AddItem("A2", item));
        }

        [Test]
        public void BankAddShouldWorkProperly()
        {
            string resultMsg = bank.AddItem("A1", item);
            string actualtMsg = $"Item:{item.ItemId} saved successfully!";

            Assert.AreEqual(actualtMsg, resultMsg);
        }

        [Test]
        public void BankRemoveShouldThrowExceptionWhenRemovingFromUnexistingCell()
        {
            Assert.Throws<ArgumentException>(() => bank.RemoveItem("Unexisting", item));
        }

        [Test]
        public void BankRemoveShouldThrowExceptionWhenRemovingUnexistingItem()
        {
            bank.AddItem("A1", item);

            Assert.Throws<ArgumentException>(() => bank.RemoveItem("A1", new Item("Invalid", "Invalid")));
        }

        [Test]
        public void BankRemoveShouldWorkProperly()
        {
            bank.AddItem("A1", item);

            string resultMsg = bank.RemoveItem("A1", item);
            string actualMsg = $"Remove item:{item.ItemId} successfully!";

            Assert.AreEqual(actualMsg, resultMsg);
        }
    }
}