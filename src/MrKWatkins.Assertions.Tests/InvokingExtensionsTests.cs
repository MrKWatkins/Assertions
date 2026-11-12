namespace MrKWatkins.Assertions.Tests;

public sealed class InvokingExtensionsTests
{
    [Test]
    public void Invoking_Action()
    {
        var value = new TestClass();
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Invoking(v => v.Throw()).Should().Throw<InvalidOperationException>());
    }

    [Test]
    public void Invoking_Func()
    {
        var value = new TestClass();
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Invoking(v => v.ThrowWithReturn()).Should().Throw<InvalidOperationException>());
    }

    private sealed class TestClass
    {
        public void Throw() => throw new NotSupportedException();

        public string ThrowWithReturn() => throw new NotSupportedException();
    }
}