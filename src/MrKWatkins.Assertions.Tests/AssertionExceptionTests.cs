namespace MrKWatkins.Assertions.Tests;

public sealed class AssertionExceptionTests
{
    [Test]
    public void Constructor_NoInnerException()
    {
        var exception = new AssertionException("Test");
        Assert.That(exception.Message, Is.EqualTo("Test"));
        Assert.That(exception.InnerException, Is.Null);
    }

    [Test]
    public void Constructor_WithInnerException()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new AssertionException("Test", inner);
        Assert.That(exception.Message, Is.EqualTo("Test"));
        Assert.That(exception.InnerException, Is.EqualTo(inner));
    }
}