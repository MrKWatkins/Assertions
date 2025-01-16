namespace MrKWatkins.Assertions.Tests;
using AssertionException = NUnit.Framework.AssertionException;

public sealed class ObjectAssertionsTests
{
    [Test]
    public void BeNull_ReferenceType()
    {
        const string notNullValue = "Not Null";
        string nullValue = null!;

        var exception = Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.That(exception, Has.Message.EqualTo("Value should be null but was \"Not Null\"."));

        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
    }

    [Test]
    public void BeNull_ValueType()
    {
        const int notNullValue = 123;

        var exception = Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.That(exception, Has.Message.EqualTo("Value should be null but was 123."));
    }

    [Test]
    public void NotBeNull_ReferenceType()
    {
        string nullValue = null!;
        const string notNullValue = "Not Null";

        var exception = Assert.Throws<AssertionException>(() => nullValue.Should().NotBeNull());
        Assert.That(exception, Has.Message.EqualTo("Value should not be null."));

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

        var exception = Assert.Throws<AssertionException>(() => nullValue.Should().BeOfType<object>());
        Assert.That(exception, Has.Message.EqualTo("Value should not be null."));

        exception = Assert.Throws<AssertionException>(() => value.Should().BeOfType<int>());
        Assert.That(exception, Has.Message.EqualTo("Value should be of type Int32 but was of type String."));

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

        var exception = Assert.Throws<AssertionException>(() => nullValue.Should().NotBeOfType<object>());
        Assert.That(exception, Has.Message.EqualTo("Value should not be null."));

        exception = Assert.Throws<AssertionException>(() => value.Should().NotBeOfType<string>());
        Assert.That(exception, Has.Message.EqualTo("Value should not be of type String."));

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