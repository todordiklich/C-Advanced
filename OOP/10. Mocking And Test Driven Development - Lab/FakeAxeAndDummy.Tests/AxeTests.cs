using Moq;
using NUnit.Framework;

using FakeAxeAndDummy.Contracts;
using System;

[TestFixture]
public class AxeTests
{
    private IWeapon weapon;

    [Test]
    [TestCase(10, 10)]
    public void AxeConstructorShouldWorkProperly(int attack, int durability)
    {
        weapon = new Axe(attack, durability);

        Assert.AreEqual(attack, weapon.AttackPoints);
        Assert.AreEqual(durability, weapon.DurabilityPoints);
    }

    [Test]
    [TestCase(10, 10)]
    public void DurabilityPiontsShouldDecreasewhenAttacking(int attack, int durability)
    {
        weapon = new Axe(attack, durability);

        Mock<ITarget> target = new Mock<ITarget>();

        weapon.Attack(target.Object);

        Assert.AreEqual(9, weapon.DurabilityPoints);
    }
    [Test]
    [TestCase(10, 0)]
    [TestCase(10, -1)]
    public void AttackShouldThrowExceptionWhenAttackingWithZeroOrNegativeDurabilityPoints
        (int attack, int durability)
    {
        weapon = new Axe(attack, durability);

        Mock<ITarget> target = new Mock<ITarget>();

        Assert.Throws<InvalidOperationException>(() => weapon.Attack(target.Object));
    }
}