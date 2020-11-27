using FakeAxeAndDummy.Contracts;
using Moq;
using NUnit.Framework;

[TestFixture]
public class HeroTests
{
    [Test]
    public void HeroGainsExperienceAfterAttackIfTargetDies()
    {
        Mock<ITarget> target = new Mock<ITarget>();
        target.Setup(t => t.Health).Returns(0);
        target.Setup(t => t.GiveExperience()).Returns(20);
        target.Setup(t => t.IsDead()).Returns(true);

        Mock<IWeapon> weapon = new Mock<IWeapon>();

        Hero hero = new Hero("Hero", weapon.Object);

        hero.Attack(target.Object);

        Assert.AreEqual(20, hero.Experience);
    }
}