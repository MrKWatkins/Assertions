namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public sealed class EnumerableAssertionsTests
{
    [Test]
    public void BeNull()
    {
        IEnumerable<byte> notNullValue = [];
        IEnumerable<byte> nullValue = null!;

        Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
    }

    [Test]
    public void NotBeNull()
    {
        IEnumerable<byte> notNullValue = [];
        IEnumerable<byte> nullValue = null!;

        Assert.DoesNotThrow(() => notNullValue.Should().NotBeNull());
        Assert.Throws<AssertionException>(() => nullValue.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_Chain()
    {
        IEnumerable<byte> nullValue = [];

        var chain = nullValue.Should().NotBeNull();
        Assert.That(chain.Value, Is.EqualTo(nullValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(nullValue));
    }

    [Test]
    public void BeEmpty()
    {
        IEnumerable<byte> nullValue = null!;
        IEnumerable<byte> notEmptyValue = [1, 2, 3];
        IEnumerable<byte> emptyValue = [];

        Assert.Throws<AssertionException>(() => nullValue.Should().BeEmpty());
        Assert.Throws<AssertionException>(() => notEmptyValue.Should().BeEmpty());
        Assert.DoesNotThrow(() => emptyValue.Should().BeEmpty());
    }

    [Test]
    public void BeEmpty_Chain()
    {
        IEnumerable<byte> emptyValue = [];

        var chain = emptyValue.Should().BeEmpty();
        Assert.That(chain.Value, Is.EqualTo(emptyValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(emptyValue));
    }

    [Test]
    public void NotBeEmpty()
    {
        IEnumerable<byte> nullValue = null!;
        IEnumerable<byte> notEmptyValue = [1, 2, 3];
        IEnumerable<byte> emptyValue = [];

        Assert.Throws<AssertionException>(() => nullValue.Should().NotBeEmpty());
        Assert.DoesNotThrow(() => notEmptyValue.Should().NotBeEmpty());
        Assert.Throws<AssertionException>(() => emptyValue.Should().NotBeEmpty());
    }

    [Test]
    public void NotBeEmpty_Chain()
    {
        IEnumerable<byte> emptyValue = [1, 2, 3];

        var chain = emptyValue.Should().NotBeEmpty();
        Assert.That(chain.Value, Is.EqualTo(emptyValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(emptyValue));
    }
}