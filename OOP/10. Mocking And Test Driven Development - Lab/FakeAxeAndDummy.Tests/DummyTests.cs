using System;
using NUnit.Framework;

using FakeAxeAndDummy.Contracts;

[TestFixture]
public class DummyTests
{
    [Test]
    [TestCase(10, 10)]
    [TestCase(20, 10)]
    public void HealthSouldWorkProperly(int hp, int exp)
    {
        ITarget dummy = new Dummy(hp, exp);

        Assert.AreEqual(hp, dummy.Health);
    }

    [Test]
    [TestCase(0, 10)]
    [TestCase(-5, 10)]
    public void ExperianceSouldWorkProperly(int hp, int exp)
    {
        ITarget dummy = new Dummy(hp, exp);

        Assert.AreEqual(exp, dummy.GiveExperience());
    }

    [Test]
    public void TakeAttackShouldRemoveHealthPoints()
    {
        ITarget dummy = new Dummy(10, 10);

        var expectedResult = 5;
        dummy.TakeAttack(5);

        Assert.AreEqual(expectedResult, dummy.Health);
    }

    [Test]
    [TestCase(0, 10)]
    [TestCase(-5, 10)]
    public void TakeAttackShouldThrowExceptionWhenHealtIsEqualOrBelowZero(int hp, int exp)
    {
        ITarget dummy = new Dummy(hp, exp);

        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(5));
    }
}
