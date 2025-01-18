namespace MrKWatkins.Assertions.Tests;

public sealed class ObjectAssertionsTests
{
    [Test]
    public async Task BeNull_ReferenceType()
    {
        const string notNullValue = "Not Null";
        string nullValue = null!;

        await Assert.That(() => notNullValue.Should().BeNull()).Throws<AssertionException>().WithMessage("Value should be null but was \"Not Null\".");
        await Assert.That(() => nullValue.Should().BeNull()).ThrowsNothing();
    }

    [Test]
    public async Task BeNull_ValueType()
    {
        const int notNullValue = 123;

        await Assert.That(() => notNullValue.Should().BeNull()).Throws<AssertionException>().WithMessage("Value should be null but was 123.");
    }

    [Test]
    public async Task NotBeNull_ReferenceType()
    {
        string nullValue = null!;
        const string notNullValue = "Not Null";

        await Assert.That(() => nullValue.Should().NotBeNull()).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => notNullValue.Should().NotBeNull()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeNull_ValueType()
    {
        const int notNullValue = 123;

        await Assert.That(() => notNullValue.Should().NotBeNull()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeNull_Chain()
    {
        const string notNullValue = "Not Null";

        var chain = notNullValue.Should().NotBeNull();
        await Assert.That(chain.Value).IsEqualTo(notNullValue);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(notNullValue);
    }

    [Test]
    public async Task BeOfType()
    {
        object? nullValue = null;
        object value = "String";

        await Assert.That(() => nullValue.Should().BeOfType<object>()).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().BeOfType<int>()).Throws<AssertionException>().WithMessage("Value should be of type Int32 but was of type String.");
        await Assert.That(() => value.Should().BeOfType<string>()).ThrowsNothing();
    }

    [Test]
    public async Task BeOfType_Chain()
    {
        object value = "String";

        var chain = value.Should().BeOfType<string>();
        await Assert.That(chain.Value).IsEqualTo((string)value);
        await Assert.That(chain.And.Value).IsEqualTo((string)value);
    }

    [Test]
    public async Task NotBeOfType()
    {
        object? nullValue = null;
        object value = "String";

        await Assert.That(() => nullValue.Should().NotBeOfType<object>()).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().NotBeOfType<string>()).Throws<AssertionException>().WithMessage("Value should not be of type String.");
        await Assert.That(() => value.Should().NotBeOfType<int>()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeOfType_Chain()
    {
        object value = "String";

        var chain = value.Should().NotBeOfType<int>();
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }
}