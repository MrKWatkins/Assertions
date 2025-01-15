namespace MrKWatkins.Assertions.Tests;

public sealed class EnumerableAssertionsExtensionsTests
{
    [Test]
    public void NotBeNull_Null()
    {
        IEnumerable<byte> value = null!;
        Assert.Throws<AssertionException>(() => value.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_NotNull()
    {
        IEnumerable<byte> value = [1, 2, 3];
        Assert.DoesNotThrow(() => value.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_Value()
    {
        IEnumerable<byte> value = [1, 2, 3];
        Assert.That(value.Should().NotBeNull().Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeNull_And()
    {
        IEnumerable<byte> value = [1, 2, 3];
        Assert.That(value.Should().NotBeNull().And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeEmpty_Empty()
    {
        IEnumerable<byte> value = [];
        Assert.Throws<AssertionException>(() => value.Should().NotBeEmpty());
    }

    [Test]
    public void NotBeEmpty_NotEmpty()
    {
        IEnumerable<byte> value = [1, 2, 3];
        Assert.DoesNotThrow(() => value.Should().NotBeEmpty());
    }

    [Test]
    public void NotBeEmpty_Value()
    {
        IEnumerable<byte> value = [1, 2, 3];
        Assert.That(value.Should().NotBeEmpty().Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeEmpty_And()
    {
        IEnumerable<byte> value = [1, 2, 3];
        Assert.That(value.Should().NotBeEmpty().And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeEmpty_Empty()
    {
        IEnumerable<byte> value = [1, 2, 3];
        Assert.Throws<AssertionException>(() => value.Should().BeEmpty());
    }

    [Test]
    public void BeEmpty_NotEmpty()
    {
        IEnumerable<byte> value = [];
        Assert.DoesNotThrow(() => value.Should().BeEmpty());
    }

    [Test]
    public void BeEmpty_Value()
    {
        IEnumerable<byte> value = [];
        Assert.That(value.Should().BeEmpty().Value, Is.EqualTo(value));
    }

    [Test]
    public void BeEmpty_And()
    {
        IEnumerable<byte> value = [];
        Assert.That(value.Should().BeEmpty().And.Value, Is.EqualTo(value));
    }
}