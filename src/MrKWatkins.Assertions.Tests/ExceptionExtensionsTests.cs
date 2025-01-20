namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class ExceptionExtensionsTests
{
    [Test]
    public async Task HaveMessage()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        await Assert.That(() => nullException.Should().HaveMessage("Test")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveMessage("Test")).ThrowsNothing();

        await Assert.That(() => exception.Should().HaveMessage("Other")).Throws<AssertionException>()
            .WithMessage("Value should have message \"Test\" but was \"Other\".");
    }

    [Test]
    public async Task HaveMessage_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().HaveMessage("Test");
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }

    [Test]
    public async Task NotHaveMessage()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        await Assert.That(() => nullException.Should().NotHaveMessage("Test")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().NotHaveMessage("Other")).ThrowsNothing();

        await Assert.That(() => exception.Should().NotHaveMessage("Test")).Throws<AssertionException>()
            .WithMessage("Value should not have message \"Test\".");
    }

    [Test]
    public async Task NotHaveMessage_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().NotHaveMessage("Other");
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }

    [Test]
    public async Task HaveParamName()
    {
        ArgumentException? nullException = null;
        var exception = new ArgumentException("Message", "Test");

        await Assert.That(() => nullException.Should().HaveParamName("Test")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveParamName("Test")).ThrowsNothing();

        await Assert.That(() => exception.Should().HaveParamName("Other")).Throws<AssertionException>()
            .WithMessage("Value should have param name \"Test\" but was \"Other\".");
    }

    [Test]
    public async Task HaveParamName_Chain()
    {
        var exception = new ArgumentException("Message", "Test");

        var chain = exception.Should().HaveParamName("Test");
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }

    [Test]
    public async Task NotHaveParamName()
    {
        ArgumentException? nullException = null;
        var exception = new ArgumentException("Message", "Test");

        await Assert.That(() => nullException.Should().NotHaveParamName("Test")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().NotHaveParamName("Other")).ThrowsNothing();

        await Assert.That(() => exception.Should().NotHaveParamName("Test")).Throws<AssertionException>()
            .WithMessage("Value should not have param name \"Test\".");
    }

    [Test]
    public async Task NotHaveParamName_Chain()
    {
        var exception = new ArgumentException("Message", "Test");

        var chain = exception.Should().NotHaveParamName("Other");
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }

    [Test]
    public async Task HaveInnerException()
    {
        ArgumentException? nullException = null;

        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var other = new InvalidOperationException("Other");

        await Assert.That(() => nullException.Should().HaveInnerException(inner)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveInnerException(inner)).ThrowsNothing();

        await Assert.That(() => exception.Should().HaveInnerException(other)).Throws<AssertionException>()
            .WithMessage("Value should have inner exception InvalidOperationException with message \"Other\" but was InvalidOperationException with message \"Inner\".");
    }

    [Test]
    public async Task HaveInnerException_Chain()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var chain = exception.Should().HaveInnerException(inner);
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }

    [Test]
    public async Task NotHaveInnerException()
    {
        ArgumentException? nullException = null;

        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var other = new InvalidOperationException("Other");

        await Assert.That(() => nullException.Should().NotHaveInnerException(inner)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().NotHaveInnerException(inner)).Throws<AssertionException>()
            .WithMessage("Value should not have inner exception InvalidOperationException with message \"Inner\".");

        await Assert.That(() => exception.Should().NotHaveInnerException(other)).ThrowsNothing();
    }

    [Test]
    public async Task NotHaveInnerException_Chain()
    {
        var other = new InvalidOperationException("Other");
        var exception = new NotSupportedException("Message");

        var chain = exception.Should().NotHaveInnerException(other);
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }
}