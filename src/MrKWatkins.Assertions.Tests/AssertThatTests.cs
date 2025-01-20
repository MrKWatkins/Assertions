namespace MrKWatkins.Assertions.Tests;

public sealed class AssertThatTests
{
    [Test]
    public async Task Invoking()
    {
        await Assert.That(() => AssertThat.Invoking(() => throw new InvalidOperationException()).Should().NotThrow()).Throws<AssertionException>();
    }
}