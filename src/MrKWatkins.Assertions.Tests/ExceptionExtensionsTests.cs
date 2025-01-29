using TUnit.Assertions.AssertConditions.Throws;

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
    public async Task HaveParamName()
    {
        ArgumentException? nullException = null;
        var exception = new ArgumentException("Message", "Test");

        await Assert.That(() => nullException.Should().HaveParamName("Test")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveParamName("Test")).ThrowsNothing();

        await Assert.That(() => exception.Should().HaveParamName("Other")).Throws<AssertionException>()
            .WithMessage("Value should have ParamName \"Other\" but was \"Test\".");
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
            .WithMessage("Value should not have ParamName \"Test\".");
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
    public async Task HaveActualValue()
    {
        ArgumentOutOfRangeException? nullException = null;
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        await Assert.That(() => nullException.Should().HaveActualValue(5)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveActualValue(5)).ThrowsNothing();

        await Assert.That(() => exception.Should().HaveActualValue(4)).Throws<AssertionException>()
            .WithMessage("Value should have ActualValue 4 but was 5.");
    }

    [Test]
    public async Task HaveActualValue_Chain()
    {
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        var chain = exception.Should().HaveActualValue(5);
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
    }

    [Test]
    public async Task NotHaveActualValue()
    {
        ArgumentOutOfRangeException? nullException = null;
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        await Assert.That(() => nullException.Should().NotHaveActualValue("Test")).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().NotHaveActualValue(4)).ThrowsNothing();

        await Assert.That(() => exception.Should().NotHaveActualValue(5)).Throws<AssertionException>()
            .WithMessage("Value should not have ActualValue 5.");
    }

    [Test]
    public async Task NotHaveActualValue_Chain()
    {
        var exception = new ArgumentOutOfRangeException("Test Param", 5, "Test Message");

        var chain = exception.Should().NotHaveActualValue(4);
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

        await Assert.That(() => nullException.Should().HaveInnerException()).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => exception.Should().HaveInnerException()).ThrowsNothing();

        await Assert.That(() => other.Should().HaveInnerException()).Throws<AssertionException>()
            .WithMessage("Value should have an InnerException.");
    }

    [Test]
    public async Task HaveInnerException_Chain()
    {
        var inner = new InvalidOperationException("Inner");
        var exception = new NotSupportedException("Message", inner);

        var chain = exception.Should().HaveInnerException();
        await Assert.That(chain.Value).IsEqualTo(exception);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(exception);
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