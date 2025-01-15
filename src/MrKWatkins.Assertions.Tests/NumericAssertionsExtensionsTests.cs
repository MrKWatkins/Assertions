namespace MrKWatkins.Assertions.Tests;

public sealed class NumericAssertionsExtensionsTests
{
    [TestCase(0)]
    [TestCase(1)]
    public void BeNegative_NotNegative(int value) => Assert.Throws<AssertionException>(() => value.Should().BeNegative());

    [Test]
    public void BeNegative_NotNegative()
    {
        const int value = -123;
        Assert.DoesNotThrow(() => value.Should().BeNegative());
    }

    [Test]
    public void BeNegative_ValueType_Value()
    {
        const int value = -123;
        Assert.That(value.Should().BeNegative().Value, Is.EqualTo(value));
    }

    [Test]
    public void BeNegative_ValueType_And()
    {
        const int value = -123;
        Assert.That(value.Should().BeNegative().And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeNegative_Negative()
    {
        const decimal value = -123M;
        Assert.Throws<AssertionException>(() => value.Should().NotBeNegative());
    }

    [TestCase(0)]
    [TestCase(1)]
    public void NotBeNegative_NotNegative(int value) => Assert.DoesNotThrow(() => value.Should().NotBeNegative());

    [Test]
    public void NotBeNegative_ValueType_Value()
    {
        const int value = 123;
        Assert.That(value.Should().NotBeNegative().Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeNegative_ValueType_And()
    {
        const int value = 123;
        Assert.That(value.Should().NotBeNegative().And.Value, Is.EqualTo(value));
    }
}