using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class ExceptionAssertionsTests
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
            .WithMessage("Value should have Message \"Other\" but was \"Test\".");
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
            .WithMessage("Value should not have Message \"Test\".");
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
    public async Task HaveMessageStartingWith()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        await Assert.That(() => nullException.Should().HaveMessageStartingWith("Tes")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveMessageStartingWith("Tes")).ThrowsNothing();

        await Assert.That(() => exception.Should().HaveMessageStartingWith("Other")).Throws<AssertionException>()
            .WithMessage("Value should have Message starting with \"Other\" but was \"Test\".");
    }

    [Test]
    public async Task HaveMessageStartingWith_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().HaveMessageStartingWith("Test");
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }

    [Test]
    public async Task NotHaveMessageStartingWith()
    {
        Exception? nullException = null;
        var exception = new InvalidOperationException("Test");

        await Assert.That(() => nullException.Should().NotHaveMessageStartingWith("Test")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().NotHaveMessageStartingWith("Other")).ThrowsNothing();

        await Assert.That(() => exception.Should().NotHaveMessageStartingWith("Tes")).Throws<AssertionException>()
            .WithMessage("Value should not have Message starting with \"Tes\" but was \"Test\".");
    }

    [Test]
    public async Task NotHaveMessageStartingWith_Chain()
    {
        var exception = new InvalidOperationException("Test");

        var chain = exception.Should().NotHaveMessageStartingWith("Other");
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

        await Assert.That(() => nullException.Should().HaveInnerException<InvalidOperationException>()).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveInnerException<InvalidOperationException>()).ThrowsNothing();

        await Assert.That(() => other.Should().HaveInnerException<InvalidOperationException>()).Throws<AssertionException>()
            .WithMessage("Value should have an InnerException but was null.");

        await Assert.That(() => exception.Should().HaveInnerException<NotSupportedException>()).Throws<AssertionException>()
            .WithMessage("Value should have an InnerException of type NotSupportedException but was of type InvalidOperationException.");
    }

    [Test]
    public async Task HaveInnerException_Chain()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var chain = exception.Should().HaveInnerException<InvalidOperationException>();
        await Assert.That(chain.That).IsEqualTo(inner);
    }

    [Test]
    public async Task HaveInnerException_Exception()
    {
        ArgumentException? nullException = null;

        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var other = new InvalidOperationException("Other");

        await Assert.That(() => nullException.Should().HaveInnerException(inner)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveInnerException(inner)).ThrowsNothing();

        await Assert.That(() => exception.Should().HaveInnerException(other)).Throws<AssertionException>()
            .WithMessage("Value should have InnerException InvalidOperationException with message \"Other\" but was InvalidOperationException with message \"Inner\".");
    }

    [Test]
    public async Task HaveInnerException_Exception_Chain()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var chain = exception.Should().HaveInnerException(inner);
        await Assert.That(chain.That).IsEqualTo(inner);
    }

    [Test]
    public async Task NotHaveInnerException()
    {
        ArgumentException? nullException = null;

        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        await Assert.That(() => nullException.Should().NotHaveInnerException()).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().NotHaveInnerException()).Throws<AssertionException>()
            .WithMessage("Value should not have an InnerException but has InvalidOperationException with message \"Inner\".");

        await Assert.That(() => inner.Should().NotHaveInnerException()).ThrowsNothing();
    }

    [Test]
    public async Task NotHaveInnerException_Chain()
    {
        var exception = new NotSupportedException("Message");

        var chain = exception.Should().NotHaveInnerException();
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }
}