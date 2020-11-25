using System;
using System.Linq;
using NUnit.Framework;

namespace Tests
{
    public class DatabaseTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWorksProperly()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();

            Database.Database database = new Database.Database(nums);

            Assert.AreEqual(nums.Length, database.Count);
        }

        [Test]
        public void AddWorksProperly()
        {
            int[] nums = Enumerable.Range(1, 10).ToArray();

            Database.Database database = new Database.Database(nums);

            database.Add(11);
            int expectedCount = 11;

            Assert.AreEqual(11, database.Fetch()[database.Count - 1]);
            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void AddThrowsException()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();

            Database.Database database = new Database.Database(nums);

            Assert.Throws<InvalidOperationException>(() => database.Add(17));
        }

        [Test]
        public void RemoveWorksProperly()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();

            Database.Database database = new Database.Database(nums);

            database.Remove();
            int expectedCount = 15;

            Assert.AreEqual(expectedCount, database.Count);
        }

        [Test]
        public void RemoveThrowsExeption()
        {
            int[] nums = new int[0];

            Database.Database database = new Database.Database(nums);

            Assert.Throws<InvalidOperationException>(() => database.Remove());
        }

        [Test]
        public void FetchWorksProperly()
        {
            int[] nums = Enumerable.Range(1, 16).ToArray();

            Database.Database database = new Database.Database(nums);

            CollectionAssert.AreEqual(nums, database.Fetch());
        }
    }
}