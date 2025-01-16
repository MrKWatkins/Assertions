namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public sealed class EnumerableAssertionsTests
{
    [Test]
    public void BeNull()
    {
        IEnumerable<byte> notNullValue = [];
        IEnumerable<byte> nullValue = null!;

        var exception = Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.That(exception, Has.Message.EqualTo("Value should be null but was System.Byte[]."));

        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
    }

    [Test]
    public void NotBeNull()
    {
        IEnumerable<byte> notNullValue = [];
        IEnumerable<byte> nullValue = null!;

        Assert.DoesNotThrow(() => notNullValue.Should().NotBeNull());

        var exception = Assert.Throws<AssertionException>(() => nullValue.Should().NotBeNull());
        Assert.That(exception, Has.Message.EqualTo("Value should not be null."));
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

        var exception = Assert.Throws<AssertionException>(() => nullValue.Should().BeEmpty());
        Assert.That(exception, Has.Message.EqualTo("Value should not be null."));

        exception = Assert.Throws<AssertionException>(() => notEmptyValue.Should().BeEmpty());
        Assert.That(exception, Has.Message.EqualTo("Value should be empty but has 3 items."));

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

        var exception = Assert.Throws<AssertionException>(() => nullValue.Should().NotBeEmpty());
        Assert.That(exception, Has.Message.EqualTo("Value should not be null."));

        Assert.DoesNotThrow(() => notEmptyValue.Should().NotBeEmpty());

        exception = Assert.Throws<AssertionException>(() => emptyValue.Should().NotBeEmpty());
        Assert.That(exception, Has.Message.EqualTo("Value should not be empty."));
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