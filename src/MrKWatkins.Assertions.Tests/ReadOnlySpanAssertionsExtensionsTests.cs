namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlySpanAssertionsExtensionsTests
{
    [Test]
    public void NotBeEmpty_Empty()
    {
        Assert.Throws<AssertionException>(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().NotBeEmpty();
        });
    }

    [Test]
    public void NotBeEmpty_NotEmpty()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().NotBeEmpty();
        });
    }

    [Test]
    public void NotBeEmpty_Value()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            Assert.That(value.Should().NotBeEmpty().Value == value, Is.True);
        });
    }

    [Test]
    public void NotBeEmpty_And()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            Assert.That(value.Should().NotBeEmpty().And.Value == value, Is.True);
        });
    }

    [Test]
    public void BeEmpty_NotEmpty()
    {
        Assert.Throws<AssertionException>(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().BeEmpty();
        });
    }

    [Test]
    public void BeEmpty_Empty()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().BeEmpty();
        });
    }

    [Test]
    public void BeEmpty_Value()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            Assert.That(value.Should().BeEmpty().Value == value, Is.True);
        });
    }

    [Test]
    public void BeEmpty_And()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            Assert.That(value.Should().BeEmpty().And.Value == value, Is.True);
        });
    }
}