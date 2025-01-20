namespace MrKWatkins.Assertions.Tests;

public sealed class InvokingExtensionsTests
{
    [Test]
    public async Task Invoking_Action()
    {
        var value = new TestClass();
        await Assert.That(() => value.Invoking(v => v.Throw()).Should().Throw<InvalidOperationException>()).Throws<AssertionException>();
    }

    [Test]
    public async Task Invoking_Func()
    {
        var value = new TestClass();
        await Assert.That(() => value.Invoking(v => v.ThrowWithReturn()).Should().Throw<InvalidOperationException>()).Throws<AssertionException>();
    }

    private sealed class TestClass
    {
        public void Throw() => throw new NotSupportedException();

        public string ThrowWithReturn() => throw new NotSupportedException();
    }
}