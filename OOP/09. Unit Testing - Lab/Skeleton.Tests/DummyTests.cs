using NUnit.Framework;
using System;

[TestFixture]
public class DummyTests
{
    [Test]
    public void DummyLooseHealthWhenAttacked()
    {
        //Arrange
        Dummy dummy = new Dummy(20, 20);

        //Act
        dummy.TakeAttack(10);

        //Assert
        Assert.AreEqual(10, dummy.Health);
    }

    [Test]
    public void DummyThrowsExceptionhWhenAttacked()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 20);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.TakeAttack(10));
    }

    [Test]
    public void DummyGivesExperiance()
    {
        //Arrange
        Dummy dummy = new Dummy(0, 20);

        //Act
        int expectedResult = 20;
        int actualResult = dummy.GiveExperience();

        //Assert
        Assert.AreEqual(expectedResult, actualResult);
    }

    [Test]
    public void DummyDoesntGivesExperiance()
    {
        //Arrange
        Dummy dummy = new Dummy(20, 20);

        //Act - Assert
        Assert.Throws<InvalidOperationException>(() => dummy.GiveExperience());
    }
}
