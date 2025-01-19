namespace MrKWatkins.Assertions.Tests;

public sealed class EqualityExtensionsTests
{
    [Test]
    public async Task Equal_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        await Assert.That(() => nullValue.Should().Equal(nonNullValue)).Throws<AssertionException>().WithMessage("Value should equal \"Not Null\" but was null.");
        await Assert.That(() => nullValue.Should().Equal(nullValue)).ThrowsNothing();
    }

    [Test]
    public async Task Equal()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        await Assert.That(() => value.Should().Equal(otherValue)).Throws<AssertionException>().WithMessage("Value should equal \"Not Test\" but was \"Test\".");
        await Assert.That(() => value.Should().Equal(value)).ThrowsNothing();
    }

    [Test]
    public async Task Equal_Enum()
    {
        const ConsoleColor value = ConsoleColor.Blue;
        const ConsoleColor otherValue = ConsoleColor.Red;

        await Assert.That(() => value.Should().Equal(otherValue)).Throws<AssertionException>().WithMessage("Value should equal Red but was Blue.");
        await Assert.That(() => value.Should().Equal(value)).ThrowsNothing();
    }

    [Test]
    public async Task Equal_Chain()
    {
        const string value = "Test";

        var chain = value.Should().Equal(value);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }
    [Test]
    public async Task NotEqual_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        await Assert.That(() => nullValue.Should().NotEqual(nonNullValue)).ThrowsNothing();
        await Assert.That(() => nullValue.Should().NotEqual(nullValue)).Throws<AssertionException>().WithMessage("Value should not equal null.");
    }

    [Test]
    public async Task NotEqual()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        await Assert.That(() => value.Should().NotEqual(otherValue)).ThrowsNothing();
        await Assert.That(() => value.Should().NotEqual(value)).Throws<AssertionException>().WithMessage("Value should not equal \"Test\".");
    }

    [Test]
    public async Task NotEqual_Chain()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        var chain = value.Should().NotEqual(otherValue);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }
}