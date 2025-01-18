namespace MrKWatkins.Assertions.Tests;

public sealed class AssertionExceptionTests
{
    [Test]
    public async Task Constructor_NoInnerException()
    {
        var exception = new AssertionException("Test");
        await Assert.That(exception.Message).IsEqualTo("Test");
        await Assert.That(exception.InnerException).IsNull();
    }

    [Test]
    public async Task Constructor_WithInnerException()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new AssertionException("Test", inner);
        await Assert.That(exception.Message).IsEqualTo("Test");
        await Assert.That(exception.InnerException).IsEqualTo(inner);
    }
}