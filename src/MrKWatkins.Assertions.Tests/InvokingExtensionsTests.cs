namespace MrKWatkins.Assertions.Tests;

public sealed class InvokingExtensionsTests
{
    [Test]
    public async Task Invoking()
    {
        var value = new TestClass();
        await Assert.That(() => value.Invoking(v => v.Throw()).Should().Throw<InvalidOperationException>()).Throws<AssertionException>();
    }

    private sealed class TestClass
    {
        public void Throw() => throw new NotSupportedException();
    }
}