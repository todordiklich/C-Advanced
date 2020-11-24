using NUnit.Framework;
using System;

[TestFixture]
public class AxeTests
{
    [Test]
    public void AxeLoosesDurabilityAfterAttack()
    {
        //Arrange
        Axe axe = new Axe(10, 10);
        Dummy dummy = new Dummy(20, 20);

        //Act
        axe.Attack(dummy);

        //Assert
        Assert.AreEqual(axe.DurabilityPoints, 9);
    }

    [Test]
    public void AxeIsBroken()
    {
        //Arrange
        Axe axe = new Axe(10, 0);
        Dummy dummy = new Dummy(20, 20);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => axe.Attack(dummy));
    }
}