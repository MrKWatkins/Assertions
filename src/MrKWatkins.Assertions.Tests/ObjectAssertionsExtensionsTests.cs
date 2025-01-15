namespace MrKWatkins.Assertions.Tests;

public sealed class ObjectAssertionsExtensionsTests
{
    [Test]
    public void BeNull_ReferenceType()
    {
        const string notNullValue = "Not Null";
        string nullValue = null!;

        Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.DoesNotThrow(() => notNullValue.Should().Not.BeNull());

        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
        Assert.Throws<AssertionException>(() => nullValue.Should().Not.BeNull());
    }

    [Test]
    public void BeNull_ValueType()
    {
        const int notNullValue = 123;

        Assert.Throws<AssertionException>(() => notNullValue.Should().BeNull());
        Assert.DoesNotThrow(() => notNullValue.Should().Not.BeNull());
    }

    [Test]
    public void BeNull_Chain()
    {
        string nullValue = null!;

        var chain = nullValue.Should().BeNull();
        Assert.That(chain.Value, Is.EqualTo(nullValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(nullValue));
        Assert.That(and.IsNot, Is.False);
    }
}