using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "NotResolvedInText")]
public sealed class ExceptionExtensionsTests
{
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
}