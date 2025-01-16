namespace MrKWatkins.Assertions.Tests;
using AssertionException = NUnit.Framework.AssertionException;

public sealed class NumericAssertionsExtensionsTests
{
    [Test]
    public void BeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        var exception = Assert.Throws<AssertionException>(() => positive.Should().BeZero());
        Assert.That(exception, Has.Message.EqualTo("Value should be 0 but was 1."));

        Assert.DoesNotThrow(() => zero.Should().BeZero());

        exception = Assert.Throws<AssertionException>(() => negative.Should().BeZero());
        Assert.That(exception, Has.Message.EqualTo("Value should be 0 but was -1."));
    }

    [Test]
    public void BeZero_Chain()
    {
        const int zero = 0;

        var chain = zero.Should().BeZero();
        Assert.That(chain.Value, Is.EqualTo(zero));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(zero));
    }

    [Test]
    public void NotBeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        Assert.DoesNotThrow(() => positive.Should().NotBeZero());

        var exception = Assert.Throws<AssertionException>(() => zero.Should().NotBeZero());
        Assert.That(exception, Has.Message.EqualTo("Value should not be 0."));

        Assert.DoesNotThrow(() => negative.Should().NotBeZero());
    }

    [Test]
    public void NotBeZero_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeZero();
        Assert.That(chain.Value, Is.EqualTo(positive));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(positive));
    }

    [Test]
    public void BeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        var exception = Assert.Throws<AssertionException>(() => positive.Should().BeNegative());
        Assert.That(exception, Has.Message.EqualTo("Value should be negative but was 1."));

        exception = Assert.Throws<AssertionException>(() => zero.Should().BeNegative());
        Assert.That(exception, Has.Message.EqualTo("Value should be negative but was 0."));

        Assert.DoesNotThrow(() => negative.Should().BeNegative());
    }

    [Test]
    public void BeNegative_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().BeNegative();
        Assert.That(chain.Value, Is.EqualTo(negative));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(negative));
    }

    [Test]
    public void NotBeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        Assert.DoesNotThrow(() => positive.Should().NotBeNegative());

        Assert.DoesNotThrow(() => zero.Should().NotBeNegative());

        var exception = Assert.Throws<AssertionException>(() => negative.Should().NotBeNegative());
        Assert.That(exception, Has.Message.EqualTo("Value should not be negative but was -1."));
    }

    [Test]
    public void NotBeNegative_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeNegative();
        Assert.That(chain.Value, Is.EqualTo(positive));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(positive));
    }

    [Test]
    public void BePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        var exception = Assert.Throws<AssertionException>(() => negative.Should().BePositive());
        Assert.That(exception, Has.Message.EqualTo("Value should be positive but was -1."));

        Assert.DoesNotThrow(() => zero.Should().BePositive());

        Assert.DoesNotThrow(() => positive.Should().BePositive());
    }

    [Test]
    public void BePositive_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().BePositive();
        Assert.That(chain.Value, Is.EqualTo(positive));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(positive));
    }

    [Test]
    public void NotBePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        Assert.DoesNotThrow(() => negative.Should().NotBePositive());

        var exception = Assert.Throws<AssertionException>(() => zero.Should().NotBePositive());
        Assert.That(exception, Has.Message.EqualTo("Value should not be positive but was 0."));

        exception = Assert.Throws<AssertionException>(() => positive.Should().NotBePositive());
        Assert.That(exception, Has.Message.EqualTo("Value should not be positive but was 1."));
    }

    [Test]
    public void NotBePositive_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().NotBePositive();
        Assert.That(chain.Value, Is.EqualTo(negative));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(negative));
    }
}