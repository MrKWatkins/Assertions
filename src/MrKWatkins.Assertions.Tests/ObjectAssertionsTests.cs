namespace MrKWatkins.Assertions.Tests;

public sealed class ObjectAssertionsTests
{
    [Test]
    public void BeNull_ReferenceType()
    {
        const string notNullValue = "Not Null";
        string nullValue = null!;

        Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
    }

    [Test]
    public void BeNull_ValueType()
    {
        const int notNullValue = 123;

        Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
    }

    [Test]
    public void NotBeNull_ReferenceType()
    {
        string nullValue = null!;
        const string notNullValue = "Not Null";

        Assert.Throws<AssertionException>(() => nullValue.Should().NotBeNull());
        Assert.DoesNotThrow(() => notNullValue.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_ValueType()
    {
        const int notNullValue = 123;

        Assert.DoesNotThrow(() => notNullValue.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_Chain()
    {
        const string notNullValue = "Not Null";

        var chain = notNullValue.Should().NotBeNull();
        Assert.That(chain.Value, Is.EqualTo(notNullValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(notNullValue));
    }

    [Test]
    public void BeOfType()
    {
        object? nullValue = null;
        object value = "String";

        Assert.Throws<AssertionException>(() => nullValue.Should().BeOfType<object>());
        Assert.Throws<AssertionException>(() => value.Should().BeOfType<int>());
        Assert.DoesNotThrow(() => value.Should().BeOfType<string>());
    }

    [Test]
    public void BeOfType_Chain()
    {
        object value = "String";

        var chain = value.Should().BeOfType<string>();
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeOfType()
    {
        object? nullValue = null;
        object value = "String";

        Assert.Throws<AssertionException>(() => nullValue.Should().NotBeOfType<object>());
        Assert.Throws<AssertionException>(() => value.Should().NotBeOfType<string>());
        Assert.DoesNotThrow(() => value.Should().NotBeOfType<int>());
    }

    [Test]
    public void NotBeOfType_Chain()
    {
        object value = "String";

        var chain = value.Should().NotBeOfType<int>();
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }
}