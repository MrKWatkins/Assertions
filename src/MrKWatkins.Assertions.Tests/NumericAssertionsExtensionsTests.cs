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

        Assert.DoesNotThrow(() => positive.Should().Not.BeNegative());
        Assert.DoesNotThrow(() => zero.Should().Not.BeNegative());
        Assert.Throws<AssertionException>(() => negative.Should().Not.BeNegative());
    }

    [Test]
    public void BeNull_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().BeNegative();
        Assert.That(chain.Value, Is.EqualTo(negative));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(negative));
        Assert.That(and.IsNot, Is.False);
    }
}