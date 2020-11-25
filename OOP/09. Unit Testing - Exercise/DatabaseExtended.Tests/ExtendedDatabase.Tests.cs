using System;
using NUnit.Framework;

using ExtendedDatabase;

namespace Tests
{
    public class ExtendedDatabaseTests
    {
        private Person[] people;
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWorksProperly()
        {
            CreatePeople(16);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people); 

            int expectedresult = 16;

            Assert.AreEqual(expectedresult, extendedDatabase.Count);
        }

        [Test]
        public void ConstructorThrowsExeption()
        {
            CreatePeople(17);

            Assert.Throws<ArgumentException>(() => new ExtendedDatabase.ExtendedDatabase(people));
        }

        [Test]
        public void AddWorksProperly()
        {
            CreatePeople(10);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Person person = new Person(11, "11");
            extendedDatabase.Add(person);
            int expectedResult = 11;

            Assert.AreEqual(expectedResult, extendedDatabase.Count);
        }

        [Test]
        [TestCase(16, 20, "20")]
        [TestCase(10, 0, "20")]
        [TestCase(10, 20, "0")]
        public void AddThrowsExceptionWhenAddedMoreThan16People(int count, int id, string name)
        {
            CreatePeople(count);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Person person = new Person(id, name);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Add(person));
        }

        [Test]
        public void RemoveWorksProperly()
        {
            CreatePeople(16);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            int expecretCount = 15;
            extendedDatabase.Remove();

            Assert.AreEqual(expecretCount, extendedDatabase.Count);
        }

        [Test]
        public void RemoveThrowsException()
        {
            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase();

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.Remove());
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        public void FindByUsernameTakesNullOrEmptyName(string name)
        {
            CreatePeople(5);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<ArgumentNullException>(() => extendedDatabase.FindByUsername(name));
        }

        [Test]
        public void FindByUsernameDoesntContainsUsername()
        {
            CreatePeople(5);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindByUsername("100"));
        }

        [Test]
        public void FindByUsernameWorksProperly()
        {
            CreatePeople(5);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            Person expectedPerson = new Person(0, "0");
            Person actualPerson = extendedDatabase.FindByUsername("0");

            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);
            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
        }

        [Test]
        public void FindByIdTakesNegativeId()
        {
            CreatePeople(5);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<ArgumentOutOfRangeException>(() => extendedDatabase.FindById(-1));
        }

        [Test]
        public void FindByIdDoesntContainsId()
        {
            CreatePeople(5);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);

            Assert.Throws<InvalidOperationException>(() => extendedDatabase.FindById(100));
        }

        [Test]
        public void FindByIdWorksProperly()
        {
            CreatePeople(5);

            ExtendedDatabase.ExtendedDatabase extendedDatabase = new ExtendedDatabase.ExtendedDatabase(people);
            Person expectedPerson = new Person(0, "0");
            Person actualPerson = extendedDatabase.FindById(0);

            Assert.AreEqual(expectedPerson.Id, actualPerson.Id);
            Assert.AreEqual(expectedPerson.UserName, actualPerson.UserName);
        }

        private void CreatePeople(int count)
        {
            people = new Person[count];

            for (int i = 0; i < people.Length; i++)
            {
                people[i] = new Person(i, i.ToString());
            }
        }
    }
}