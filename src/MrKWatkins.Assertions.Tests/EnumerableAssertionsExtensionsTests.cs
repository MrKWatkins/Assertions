namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public sealed class EnumerableAssertionsExtensionsTests
{
    [Test]
    public void BeNull()
    {
        IEnumerable<byte> notNullValue = [];
        IEnumerable<byte> nullValue = null!;

        Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.DoesNotThrow(() => notNullValue.Should().Not.BeNull());

        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
        Assert.Throws<AssertionException>(() => nullValue.Should().Not.BeNull());
    }

    [Test]
    public void BeNull_Chain()
    {
        IEnumerable<byte> nullValue = null!;

        var chain = nullValue.Should().BeNull();
        Assert.That(chain.Value, Is.EqualTo(nullValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(nullValue));
        Assert.That(and.IsNot, Is.False);
    }

    [Test]
    public void BeEmpty()
    {
        IEnumerable<byte> nullValue = null!;
        IEnumerable<byte> notEmptyValue = [1, 2, 3];
        IEnumerable<byte> emptyValue = [];

        Assert.Throws<AssertionException>(() => nullValue.Should().BeEmpty());
        Assert.Throws<AssertionException>(() => nullValue.Should().Not.BeEmpty());

        Assert.Throws<AssertionException>(() => notEmptyValue.Should().BeEmpty());
        Assert.DoesNotThrow(() => notEmptyValue.Should().Not.BeEmpty());

        Assert.DoesNotThrow(() => emptyValue.Should().BeEmpty());
        Assert.Throws<AssertionException>(() => emptyValue.Should().Not.BeEmpty());
    }

    [Test]
    public void BeEmpty_Chain()
    {
        IEnumerable<byte> emptyValue = [];

        var chain = emptyValue.Should().BeEmpty();
        Assert.That(chain.Value, Is.EqualTo(emptyValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(emptyValue));
        Assert.That(and.IsNot, Is.False);
    }
}