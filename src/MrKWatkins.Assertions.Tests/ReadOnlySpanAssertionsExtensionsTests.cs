namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlySpanAssertionsExtensionsTests
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

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().Not.BeEmpty();
        });

        Assert.Throws<AssertionException>(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().Not.BeEmpty();
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
        Assert.That(and.IsNot, Is.False);
    }
}