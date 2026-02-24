namespace MrKWatkins.Assertions.Tests;

public sealed class IntegerAssertionsTests
{
    [Test]
    public async Task Equal_SameType()
    {
        const int value = 42;

        await Assert.That(() => value.Should().Equal(42)).ThrowsNothing();
        await Assert.That(() => value.Should().Equal(43)).Throws<AssertionException>().WithMessage("Value should equal 43 but was 42.");
    }

    [Test]
    public async Task Equal_DifferentTypes()
    {
        const byte byteValue = 42;
        const short shortValue = 42;
        const int intValue = 42;
        const long longValue = 42;

        // Test byte equality with different types
        await Assert.That(() => byteValue.Should().Equal(42)).ThrowsNothing();
        await Assert.That(() => byteValue.Should().Equal(42L)).ThrowsNothing();
        await Assert.That(() => byteValue.Should().Equal((short)42)).ThrowsNothing();

        // Test int equality with different types
        await Assert.That(() => intValue.Should().Equal((byte)42)).ThrowsNothing();
        await Assert.That(() => intValue.Should().Equal((short)42)).ThrowsNothing();
        await Assert.That(() => intValue.Should().Equal(42L)).ThrowsNothing();

        // Test failures with different values
        await Assert.That(() => byteValue.Should().Equal(43)).Throws<AssertionException>().WithMessage("Value should equal 43 but was 42.");
        await Assert.That(() => shortValue.Should().Equal(0)).Throws<AssertionException>().WithMessage("Value should equal 0 but was 42.");
        await Assert.That(() => longValue.Should().Equal(100)).Throws<AssertionException>().WithMessage("Value should equal 100 but was 42.");
    }

    [Test]
    public async Task Equal_Zero()
    {
        const byte byteZero = 0;
        const int intZero = 0;

        await Assert.That(() => byteZero.Should().Equal(0)).ThrowsNothing();
        await Assert.That(() => intZero.Should().Equal((byte)0)).ThrowsNothing();
    }

    [Test]
    public async Task Equal_Chain()
    {
        const int value = 42;

        var chain = value.Should().Equal(42);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotEqual_SameType()
    {
        const int value = 42;

        await Assert.That(() => value.Should().NotEqual(43)).ThrowsNothing();
        await Assert.That(() => value.Should().NotEqual(42)).Throws<AssertionException>().WithMessage("Value should not equal 42.");
    }

    [Test]
    public async Task NotEqual_DifferentTypes()
    {
        const byte byteValue = 42;
        const int intValue = 42;

        // Test byte inequality with different types
        await Assert.That(() => byteValue.Should().NotEqual(43)).ThrowsNothing();
        await Assert.That(() => byteValue.Should().NotEqual(43L)).ThrowsNothing();
        await Assert.That(() => byteValue.Should().NotEqual((short)100)).ThrowsNothing();

        // Test failures when values are equal
        await Assert.That(() => byteValue.Should().NotEqual(42)).Throws<AssertionException>().WithMessage("Value should not equal 42.");
        await Assert.That(() => intValue.Should().NotEqual((byte)42)).Throws<AssertionException>().WithMessage("Value should not equal 42.");
    }

    [Test]
    public async Task NotEqual_Chain()
    {
        const int value = 42;

        var chain = value.Should().NotEqual(43);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task Equal_Overflow()
    {
        const byte byteValue = 42;

        // Test that overflow is handled with a descriptive error message
        await Assert.That(() => byteValue.Should().Equal(300))
            .Throws<AssertionException>()
            .WithMessage("Value should equal 300 but the expected value cannot be represented as \"Byte\" (overflow).");
    }

    [Test]
    public async Task NotEqual_Overflow()
    {
        const byte byteValue = 42;

        // If the expected value can't be represented in the type, the values can't be equal
        await Assert.That(() => byteValue.Should().NotEqual(300)).ThrowsNothing();
    }

    [Test]
    public async Task BeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().BeZero()).Throws<AssertionException>().WithMessage("Value should be 0 but was 1.");
        await Assert.That(() => zero.Should().BeZero()).ThrowsNothing();
        await Assert.That(() => negative.Should().BeZero()).Throws<AssertionException>().WithMessage("Value should be 0 but was -1.");
    }

    [Test]
    public async Task BeZero_Chain()
    {
        const int zero = 0;

        var chain = zero.Should().BeZero();
        await Assert.That(chain.Value).IsEqualTo(zero);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(zero);
    }

    [Test]
    public async Task NotBeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().NotBeZero()).ThrowsNothing();
        await Assert.That(() => zero.Should().NotBeZero()).Throws<AssertionException>().WithMessage("Value should not be 0.");
        await Assert.That(() => negative.Should().NotBeZero()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeZero_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeZero();
        await Assert.That(chain.Value).IsEqualTo(positive);
        await Assert.That(chain.And.Value).IsEqualTo(positive);
    }

    [Test]
    public async Task BeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().BeNegative()).Throws<AssertionException>().WithMessage("Value should be negative but was 1.");
        await Assert.That(() => zero.Should().BeNegative()).Throws<AssertionException>().WithMessage("Value should be negative but was 0.");
        await Assert.That(() => negative.Should().BeNegative()).ThrowsNothing();
    }

    [Test]
    public async Task BeNegative_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().BeNegative();
        await Assert.That(chain.Value).IsEqualTo(negative);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(negative);
    }

    [Test]
    public async Task NotBeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        await Assert.That(() => positive.Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => zero.Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => negative.Should().NotBeNegative()).Throws<AssertionException>().WithMessage("Value should not be negative but was -1.");
    }

    [Test]
    public async Task NotBeNegative_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeNegative();
        await Assert.That(chain.Value).IsEqualTo(positive);
        await Assert.That(chain.And.Value).IsEqualTo(positive);
    }

    [Test]
    public async Task BePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        await Assert.That(() => negative.Should().BePositive()).Throws<AssertionException>().WithMessage("Value should be positive but was -1.");
        await Assert.That(() => zero.Should().BePositive()).ThrowsNothing();
        await Assert.That(() => positive.Should().BePositive()).ThrowsNothing();
    }

    [Test]
    public async Task BePositive_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().BePositive();
        await Assert.That(chain.Value).IsEqualTo(positive);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(positive);
    }

    [Test]
    public async Task NotBePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        await Assert.That(() => negative.Should().NotBePositive()).ThrowsNothing();
        await Assert.That(() => zero.Should().NotBePositive()).Throws<AssertionException>().WithMessage("Value should not be positive but was 0.");
        await Assert.That(() => positive.Should().NotBePositive()).Throws<AssertionException>().WithMessage("Value should not be positive but was 1.");
    }

    [Test]
    public async Task NotBePositive_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().NotBePositive();
        await Assert.That(chain.Value).IsEqualTo(negative);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(negative);
    }

    [Test]
    public async Task InheritedMethods_FromObjectAssertions()
    {
        const int value = 42;

        // Numeric extension methods work alongside ObjectAssertions methods
        await Assert.That(() => value.Should().NotBeNull()).ThrowsNothing();
        await Assert.That(() => value.Should().Equal(42)).ThrowsNothing();
        await Assert.That(() => value.Should().NotEqual(43)).ThrowsNothing();
    }

    [Test]
    public async Task ChainWithInheritedMethods()
    {
        const int value = 42;

        // Should be able to chain numeric-specific and object assertions
        await Assert.That(() => value.Should().BePositive().And.NotEqual(0)).ThrowsNothing();
        await Assert.That(() => value.Should().NotBeZero().And.Equal(42)).ThrowsNothing();
    }

    [Test]
    public async Task BeLessThan()
    {
        const int value = 5;

        await Assert.That(() => value.Should().BeLessThan(10)).ThrowsNothing();
        await Assert.That(() => value.Should().BeLessThan(5)).Throws<AssertionException>().WithMessage("Value should be less than 5 but was 5.");
        await Assert.That(() => value.Should().BeLessThan(1)).Throws<AssertionException>().WithMessage("Value should be less than 1 but was 5.");
    }

    [Test]
    public async Task BeLessThan_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeLessThan(10);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeLessThanOrEqualTo()
    {
        const int value = 5;

        await Assert.That(() => value.Should().BeLessThanOrEqualTo(10)).ThrowsNothing();
        await Assert.That(() => value.Should().BeLessThanOrEqualTo(5)).ThrowsNothing();
        await Assert.That(() => value.Should().BeLessThanOrEqualTo(1)).Throws<AssertionException>().WithMessage("Value should be less than or equal to 1 but was 5.");
    }

    [Test]
    public async Task BeLessThanOrEqualTo_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeLessThanOrEqualTo(5);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeGreaterThan()
    {
        const int value = 5;

        await Assert.That(() => value.Should().BeGreaterThan(1)).ThrowsNothing();
        await Assert.That(() => value.Should().BeGreaterThan(5)).Throws<AssertionException>().WithMessage("Value should be greater than 5 but was 5.");
        await Assert.That(() => value.Should().BeGreaterThan(10)).Throws<AssertionException>().WithMessage("Value should be greater than 10 but was 5.");
    }

    [Test]
    public async Task BeGreaterThan_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeGreaterThan(1);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo()
    {
        const int value = 5;

        await Assert.That(() => value.Should().BeGreaterThanOrEqualTo(1)).ThrowsNothing();
        await Assert.That(() => value.Should().BeGreaterThanOrEqualTo(5)).ThrowsNothing();
        await Assert.That(() => value.Should().BeGreaterThanOrEqualTo(10)).Throws<AssertionException>().WithMessage("Value should be greater than or equal to 10 but was 5.");
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeGreaterThanOrEqualTo(5);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }
}