using System;
using NUnit.Framework;

using FightingArena;

namespace Tests
{
    public class ArenaTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConstructorWorksProperly()
        {
            Arena arena = new Arena();

            Assert.AreEqual(0, arena.Count);
        }

        [Test]
        public void EnrollWorksProperly()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Attacker", 10, 100);

            arena.Enroll(attacker);

            Assert.AreEqual(1, arena.Count);
        }

        [Test]
        public void EnrollThrowsException()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Attacker", 10, 100);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Enroll(attacker));
        }

        [Test]
        public void FightWorksProperly()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Attacker", 10, 100);
            Warrior defender = new Warrior("Defender", 10, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            arena.Fight(attacker.Name, defender.Name);

            Assert.AreEqual(90, attacker.HP);
            Assert.AreEqual(90, defender.HP);
        }

        [Test]
        public void FightThrowsException()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Attacker", 10, 100);
            Warrior defender = new Warrior("Defender", 10, 100);

            arena.Enroll(attacker);

            Assert.Throws<InvalidOperationException>(() => arena.Fight(attacker.Name, defender.Name));
        }

        [Test]
        public void WarriorsWorksProperly()
        {
            Arena arena = new Arena();
            Warrior attacker = new Warrior("Attacker", 10, 100);
            Warrior defender = new Warrior("Defender", 10, 100);

            arena.Enroll(attacker);
            arena.Enroll(defender);

            Assert.AreEqual(2, arena.Warriors.Count);
        }
    }
}
