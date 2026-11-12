namespace MrKWatkins.Assertions.Tests;

public sealed class AssertThatTests
{
    [Test]
    public void Invoking_Action() =>
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => AssertThat.Invoking(() => throw new InvalidOperationException()).Should().NotThrow());

    [Test]
    public void Invoking_Func() => Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => AssertThat.Invoking(() => 5).Should().Throw<InvalidOperationException>());
}