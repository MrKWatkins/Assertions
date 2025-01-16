namespace MrKWatkins.Assertions.Tests;

public sealed class NumericAssertionsExtensionsTests
{
    [Test]
    public void BeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        Assert.Throws<AssertionException>(() => positive.Should().BeNegative());
        Assert.Throws<AssertionException>(() => zero.Should().BeNegative());
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
        Assert.Throws<AssertionException>(() => negative.Should().NotBeNegative());
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

        Assert.Throws<AssertionException>(() => negative.Should().BePositive());
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
        Assert.Throws<AssertionException>(() => zero.Should().NotBePositive());
        Assert.Throws<AssertionException>(() => positive.Should().NotBePositive());
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