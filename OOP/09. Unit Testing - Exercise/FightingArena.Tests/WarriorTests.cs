using System;
using NUnit.Framework;

using FightingArena;

namespace Tests
{
    public class WarriorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("Name", 10, 10)]
        [TestCase("Name", 100, 100)]
        public void ConstructorWorksProperly(string name, int dmg, int hp)
        {
            Warrior warrior = new Warrior(name, dmg, hp);

            Assert.AreEqual(name, warrior.Name);
            Assert.AreEqual(dmg, warrior.Damage);
            Assert.AreEqual(hp, warrior.HP);
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void NameTakesNullOrWhiteSpaceParameter(string name)
        {
            Assert.Throws<ArgumentException>(() => new Warrior(name, 10, 10));
        }

        [Test]
        [TestCase(0)]
        [TestCase(-1)]
        public void DemageTakesZeroOrNegativeParameter(int dmg)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", dmg, 10));
        }

        [Test]
        [TestCase(-1)]
        public void HPTakesNegativeParameter(int hp)
        {
            Assert.Throws<ArgumentException>(() => new Warrior("Name", 10, hp));
        }

        [Test]
        [TestCase("Attacker", 10, 30, "Defender", 10, 100)]
        [TestCase("Attacker", 10, 100, "Defender", 10, 30)]
        [TestCase("Attacker", 10, 40, "Defender", 50, 100)]
        public void AttackThrowsException(string attackerName, int attackerDmg, int attackerHP, 
                                        string defenderName, int defenderDmg, int defenderHP)
        {
            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            Assert.Throws<InvalidOperationException>(() => attacker.Attack(defender));
        }

        [Test]
        [TestCase("Attacker", 10, 100, 90, "Defender", 10, 100, 90)]
        [TestCase("Attacker", 50, 100, 90, "Defender", 10, 40, 0)]
        public void AttackWorksProperly(string attackerName, int attackerDmg, int attackerHP, int expectedAttackerHP,
                                        string defenderName, int defenderDmg, int defenderHP, int expectedDefenderHP)
        {
            Warrior attacker = new Warrior(attackerName, attackerDmg, attackerHP);
            Warrior defender = new Warrior(defenderName, defenderDmg, defenderHP);

            attacker.Attack(defender);

            Assert.AreEqual(expectedAttackerHP, attacker.HP);
            Assert.AreEqual(expectedDefenderHP, defender.HP);
        }
    }
}