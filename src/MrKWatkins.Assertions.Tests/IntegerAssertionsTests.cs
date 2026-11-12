namespace MrKWatkins.Assertions.Tests;

public sealed class IntegerAssertionsTests
{
    [Test]
    public void Equal_SameType()
    {
        const int value = 42;

        Assert.DoesNotThrow(() => value.Should().Equal(42));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 43 but was 42."), () => value.Should().Equal(43));
    }

    [Test]
    public void Equal_DifferentTypes()
    {
        const byte byteValue = 42;
        const short shortValue = 42;
        const int intValue = 42;
        const long longValue = 42;

        // Test byte equality with different types
        Assert.DoesNotThrow(() => byteValue.Should().Equal(42));
        Assert.DoesNotThrow(() => byteValue.Should().Equal(42L));
        Assert.DoesNotThrow(() => byteValue.Should().Equal((short)42));

        // Test int equality with different types
        Assert.DoesNotThrow(() => intValue.Should().Equal((byte)42));
        Assert.DoesNotThrow(() => intValue.Should().Equal((short)42));
        Assert.DoesNotThrow(() => intValue.Should().Equal(42L));

        // Test failures with different values
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 43 but was 42."), () => byteValue.Should().Equal(43));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 0 but was 42."), () => shortValue.Should().Equal(0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 100 but was 42."), () => longValue.Should().Equal(100));
    }

    [Test]
    public void Equal_Zero()
    {
        const byte byteZero = 0;
        const int intZero = 0;

        Assert.DoesNotThrow(() => byteZero.Should().Equal(0));
        Assert.DoesNotThrow(() => intZero.Should().Equal((byte)0));
    }

    [Test]
    public void Equal_Chain()
    {
        const int value = 42;

        var chain = value.Should().Equal(42);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotEqual_SameType()
    {
        const int value = 42;

        Assert.DoesNotThrow(() => value.Should().NotEqual(43));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal 42."), () => value.Should().NotEqual(42));
    }

    [Test]
    public void NotEqual_DifferentTypes()
    {
        const byte byteValue = 42;
        const int intValue = 42;

        // Test byte inequality with different types
        Assert.DoesNotThrow(() => byteValue.Should().NotEqual(43));
        Assert.DoesNotThrow(() => byteValue.Should().NotEqual(43L));
        Assert.DoesNotThrow(() => byteValue.Should().NotEqual((short)100));

        // Test failures when values are equal
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal 42."), () => byteValue.Should().NotEqual(42));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal 42."), () => intValue.Should().NotEqual((byte)42));
    }

    [Test]
    public void NotEqual_Chain()
    {
        const int value = 42;

        var chain = value.Should().NotEqual(43);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void Equal_Overflow()
    {
        const byte byteValue = 42;

        // Test that overflow is handled with a descriptive error message
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 300 but the expected value cannot be represented as \"Byte\" (overflow)."),
            () => byteValue.Should().Equal(300)
        );
    }

    [Test]
    public void NotEqual_Overflow()
    {
        const byte byteValue = 42;

        // If the expected value can't be represented in the type, the values can't be equal
        Assert.DoesNotThrow(() => byteValue.Should().NotEqual(300));
    }

    [Test]
    public void BeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be zero but was 1."), () => positive.Should().BeZero());
        Assert.DoesNotThrow(() => zero.Should().BeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be zero but was -1."), () => negative.Should().BeZero());
    }

    [Test]
    public void BeZero_Chain()
    {
        const int zero = 0;

        var chain = zero.Should().BeZero();
        Assert.That(chain.Value, Is.EqualTo(zero));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(zero));
    }

    [Test]
    public void NotBeZero()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        Assert.DoesNotThrow(() => positive.Should().NotBeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be zero."), () => zero.Should().NotBeZero());
        Assert.DoesNotThrow(() => negative.Should().NotBeZero());
    }

    [Test]
    public void NotBeZero_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeZero();
        Assert.That(chain.Value, Is.EqualTo(positive));
        Assert.That(chain.And.Value, Is.EqualTo(positive));
    }

    [Test]
    public void BeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was 1."), () => positive.Should().BeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was 0."), () => zero.Should().BeNegative());
        Assert.DoesNotThrow(() => negative.Should().BeNegative());
    }

    [Test]
    public void BeNegative_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().BeNegative();
        Assert.That(chain.Value, Is.EqualTo(negative));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(negative));
    }

    [Test]
    public void NotBeNegative()
    {
        const int positive = 1;
        const int zero = 0;
        const int negative = -1;

        Assert.DoesNotThrow(() => positive.Should().NotBeNegative());
        Assert.DoesNotThrow(() => zero.Should().NotBeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be negative but was -1."), () => negative.Should().NotBeNegative());
    }

    [Test]
    public void NotBeNegative_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().NotBeNegative();
        Assert.That(chain.Value, Is.EqualTo(positive));
        Assert.That(chain.And.Value, Is.EqualTo(positive));
    }

    [Test]
    public void BePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was -1."), () => negative.Should().BePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was 0."), () => zero.Should().BePositive());
        Assert.DoesNotThrow(() => positive.Should().BePositive());
    }

    [Test]
    public void BePositive_Chain()
    {
        const int positive = 1;

        var chain = positive.Should().BePositive();
        Assert.That(chain.Value, Is.EqualTo(positive));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(positive));
    }

    [Test]
    public void NotBePositive()
    {
        const int negative = -1;
        const int zero = 0;
        const int positive = 1;

        Assert.DoesNotThrow(() => negative.Should().NotBePositive());
        Assert.DoesNotThrow(() => zero.Should().NotBePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be positive but was 1."), () => positive.Should().NotBePositive());
    }

    [Test]
    public void NotBePositive_Chain()
    {
        const int negative = -1;

        var chain = negative.Should().NotBePositive();
        Assert.That(chain.Value, Is.EqualTo(negative));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(negative));
    }

    [Test]
    public void InheritedMethods_FromObjectAssertions()
    {
        const int value = 42;

        // Numeric extension methods work alongside ObjectAssertions methods
        Assert.DoesNotThrow(() => value.Should().NotBeNull());
        Assert.DoesNotThrow(() => value.Should().Equal(42));
        Assert.DoesNotThrow(() => value.Should().NotEqual(43));
    }

    [Test]
    public void ChainWithInheritedMethods()
    {
        const int value = 42;

        // Should be able to chain numeric-specific and object assertions
        Assert.DoesNotThrow(() => value.Should().BePositive().And.NotEqual(0));
        Assert.DoesNotThrow(() => value.Should().NotBeZero().And.Equal(42));
    }

    [Test]
    public void BeLessThan()
    {
        const int value = 5;

        Assert.DoesNotThrow(() => value.Should().BeLessThan(10));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 5 but was 5."), () => value.Should().BeLessThan(5));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 1 but was 5."), () => value.Should().BeLessThan(1));
    }

    [Test]
    public void BeLessThan_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeLessThan(10);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeLessThanOrEqualTo()
    {
        const int value = 5;

        Assert.DoesNotThrow(() => value.Should().BeLessThanOrEqualTo(10));
        Assert.DoesNotThrow(() => value.Should().BeLessThanOrEqualTo(5));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than or equal to 1 but was 5."),
            () => value.Should().BeLessThanOrEqualTo(1)
        );
    }

    [Test]
    public void BeLessThanOrEqualTo_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeLessThanOrEqualTo(5);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeGreaterThan()
    {
        const int value = 5;

        Assert.DoesNotThrow(() => value.Should().BeGreaterThan(1));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 5 but was 5."), () => value.Should().BeGreaterThan(5));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 10 but was 5."), () => value.Should().BeGreaterThan(10));
    }

    [Test]
    public void BeGreaterThan_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeGreaterThan(1);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeGreaterThanOrEqualTo()
    {
        const int value = 5;

        Assert.DoesNotThrow(() => value.Should().BeGreaterThanOrEqualTo(1));
        Assert.DoesNotThrow(() => value.Should().BeGreaterThanOrEqualTo(5));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than or equal to 10 but was 5."),
            () => value.Should().BeGreaterThanOrEqualTo(10)
        );
    }

    [Test]
    public void BeGreaterThanOrEqualTo_Chain()
    {
        const int value = 5;

        var chain = value.Should().BeGreaterThanOrEqualTo(5);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }
}