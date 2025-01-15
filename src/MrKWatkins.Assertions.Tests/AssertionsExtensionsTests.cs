namespace MrKWatkins.Assertions.Tests;

public sealed class AssertionsExtensionsTests
{
    [Test]
    public void BeNull_ReferenceType_NotNull()
    {
        const string value = "Not Null";
        Assert.Throws<AssertionException>(() => value.Should().BeNull());
    }

    [Test]
    public void BeNull_ReferenceType_Null()
    {
        string value = null!;
        Assert.DoesNotThrow(() => value.Should().BeNull());
    }

    [Test]
    public void BeNull_ReferenceType_Value()
    {
        string value = null!;
        Assert.That(value.Should().BeNull().Value, Is.EqualTo(value));
    }

    [Test]
    public void BeNull_ReferenceType_And()
    {
        string value = null!;
        Assert.That(value.Should().BeNull().And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeNull_ValueType()
    {
        const int value = 123;
        Assert.Throws<AssertionException>(() => value.Should().BeNull());
    }

    [Test]
    public void NotBeNull_ReferenceType_Null()
    {
        string value = null!;
        Assert.Throws<AssertionException>(() => value.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_ReferenceType_NotNull()
    {
        const string value = "Not Null";
        Assert.DoesNotThrow(() => value.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_ReferenceType_Value()
    {
        const string value = "Not Null";
        Assert.That(value.Should().NotBeNull().Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeNull_ReferenceType_And()
    {
        const string value = "Not Null";
        Assert.That(value.Should().NotBeNull().And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeNull_ValueType()
    {
        const int value = 123;
        Assert.DoesNotThrow(() => value.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_ValueType_Value()
    {
        const int value = 123;
        Assert.That(value.Should().NotBeNull().Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeNull_ValueType_And()
    {
        const int value = 123;
        Assert.That(value.Should().NotBeNull().And.Value, Is.EqualTo(value));
    }
}