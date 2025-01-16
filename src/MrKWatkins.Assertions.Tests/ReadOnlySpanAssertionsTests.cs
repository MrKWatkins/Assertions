namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlySpanAssertionsTests
{
    [Test]
    public void BeEmpty()
    {
        Assert.Throws<AssertionException>(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().BeEmpty();
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().BeEmpty();
        });
    }

    [Test]
    public void BeEmpty_Chain()
    {
        ReadOnlySpan<byte> emptyValue = [];

        var chain = emptyValue.Should().BeEmpty();
        Assert.That(chain.Value == emptyValue, Is.True);

        var and = chain.And;
        Assert.That(and.Value == emptyValue, Is.True);
    }

    [Test]
    public void NotBeEmpty()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().NotBeEmpty();
        });

        Assert.Throws<AssertionException>(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().NotBeEmpty();
        });
    }

    [Test]
    public void NotBeEmpty_Chain()
    {
        ReadOnlySpan<byte> emptyValue = [1, 2, 3];

        var chain = emptyValue.Should().NotBeEmpty();
        Assert.That(chain.Value == emptyValue, Is.True);

        var and = chain.And;
        Assert.That(and.Value == emptyValue, Is.True);
    }
}