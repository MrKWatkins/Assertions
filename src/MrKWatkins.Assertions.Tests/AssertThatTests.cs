using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

public sealed class AssertThatTests
{
    [Test]
    public async Task Invoking_Action()
    {
        await Assert.That(() => AssertThat.Invoking(() => throw new InvalidOperationException()).Should().NotThrow()).Throws<AssertionException>();
    }

    [Test]
    public async Task Invoking_Func()
    {
        await Assert.That(() => AssertThat.Invoking(() => 5).Should().Throw<InvalidOperationException>()).Throws<AssertionException>();
    }
}