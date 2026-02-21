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
    public async Task BeNull_NullableValueType()
    {
        int? nullValue = null;
        int? notNullValue = 123;

        await Assert.That(() => nullValue.Should().BeNull()).ThrowsNothing();
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
    public async Task NotBeNull_NullableValueType()
    {
        int? nullValue = null;
        int? notNullValue = 123;

        await Assert.That(() => nullValue.Should().NotBeNull()).Throws<AssertionException>().WithMessage("Value should not be null.");
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
    public async Task Equal_Comparer_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        await Assert.That(() => nullValue.Should().Equal(nonNullValue, StringComparer.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should equal \"Not Null\" but was null.");
        await Assert.That(() => nullValue.Should().Equal(nullValue, StringComparer.OrdinalIgnoreCase)).ThrowsNothing();
    }

    [Test]
    public async Task Equal_Comparer()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        await Assert.That(() => value.Should().Equal(otherValue, StringComparer.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should equal \"Not Test\" but was \"Test\".");
        await Assert.That(() => value.Should().Equal(sameValueDifferentCase, StringComparer.OrdinalIgnoreCase)).ThrowsNothing();
    }

    [Test]
    public async Task Equal_Comparer_Chain()
    {
        const string value = "Test";

        var chain = value.Should().Equal("test", StringComparer.OrdinalIgnoreCase);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task Equal_Predicate_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        await Assert.That(() => nullValue.Should().Equal(nonNullValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))).Throws<AssertionException>().WithMessage("Value should equal \"Not Null\" but was null.");
        await Assert.That(() => nullValue.Should().Equal(nullValue, (a, b) => a is null && b is null)).ThrowsNothing();
    }

    [Test]
    public async Task Equal_Predicate()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        await Assert.That(() => value.Should().Equal(otherValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))).Throws<AssertionException>().WithMessage("Value should equal \"Not Test\" but was \"Test\".");
        await Assert.That(() => value.Should().Equal(sameValueDifferentCase, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))).ThrowsNothing();
    }

    [Test]
    public async Task Equal_Predicate_Chain()
    {
        const string value = "Test";

        var chain = value.Should().Equal("test", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
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

    [Test]
    public async Task NotEqual_Comparer_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        await Assert.That(() => nullValue.Should().NotEqual(nonNullValue, StringComparer.OrdinalIgnoreCase)).ThrowsNothing();
        await Assert.That(() => nullValue.Should().NotEqual(nullValue, StringComparer.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should not equal null.");
    }

    [Test]
    public async Task NotEqual_Comparer()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        await Assert.That(() => value.Should().NotEqual(otherValue, StringComparer.OrdinalIgnoreCase)).ThrowsNothing();
        await Assert.That(() => value.Should().NotEqual(sameValueDifferentCase, StringComparer.OrdinalIgnoreCase)).Throws<AssertionException>().WithMessage("Value should not equal \"test\".");
    }

    [Test]
    public async Task NotEqual_Comparer_Chain()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        var chain = value.Should().NotEqual(otherValue, StringComparer.OrdinalIgnoreCase);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotEqual_Predicate_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        await Assert.That(() => nullValue.Should().NotEqual(nonNullValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))).ThrowsNothing();
        await Assert.That(() => nullValue.Should().NotEqual(nullValue, (a, b) => a is null && b is null)).Throws<AssertionException>().WithMessage("Value should not equal null.");
    }

    [Test]
    public async Task NotEqual_Predicate()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        await Assert.That(() => value.Should().NotEqual(otherValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))).ThrowsNothing();
        await Assert.That(() => value.Should().NotEqual(sameValueDifferentCase, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))).Throws<AssertionException>().WithMessage("Value should not equal \"test\".");
    }

    [Test]
    public async Task NotEqual_Predicate_Chain()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        var chain = value.Should().NotEqual(otherValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeTheSameInstanceAs()
    {
        TestObject? nullValue = null;
        var value = new TestObject("Test");
        var otherValue = new TestObject("Other");

        await Assert.That(() => nullValue.Should().BeTheSameInstanceAs(nullValue)).ThrowsNothing();
        await Assert.That(() => value.Should().BeTheSameInstanceAs(value)).ThrowsNothing();
        await Assert.That(() => value.Should().BeTheSameInstanceAs(nullValue)).Throws<AssertionException>().WithMessage("Value should be the same instance as null but was Test.");
        await Assert.That(() => nullValue.Should().BeTheSameInstanceAs(value)).Throws<AssertionException>().WithMessage("Value should be the same instance as Test but was null.");
        await Assert.That(() => value.Should().BeTheSameInstanceAs(otherValue)).Throws<AssertionException>().WithMessage("Value should be the same instance as Other but was Test.");
        await Assert.That(() => otherValue.Should().BeTheSameInstanceAs(value)).Throws<AssertionException>().WithMessage("Value should be the same instance as Test but was Other.");
    }

    [Test]
    public async Task BeTheSameInstanceAs_Chain()
    {
        var value = new TestObject("Test");

        var chain = value.Should().BeTheSameInstanceAs(value);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotBeTheSameInstanceAs()
    {
        TestObject nullValue = null!;
        var value = new TestObject("Test");
        var otherValue = new TestObject("Other");

        await Assert.That(() => nullValue.Should().NotBeTheSameInstanceAs(nullValue)).Throws<AssertionException>().WithMessage("Value should not be the same instance as null.");
        await Assert.That(() => value.Should().NotBeTheSameInstanceAs(value)).Throws<AssertionException>().WithMessage("Value should not be the same instance as Test.");
        await Assert.That(() => value.Should().NotBeTheSameInstanceAs(nullValue)).ThrowsNothing();
        await Assert.That(() => nullValue.Should().NotBeTheSameInstanceAs(value)).ThrowsNothing();
        await Assert.That(() => value.Should().NotBeTheSameInstanceAs(otherValue)).ThrowsNothing();
        await Assert.That(() => otherValue.Should().NotBeTheSameInstanceAs(value)).ThrowsNothing();
    }

    [Test]
    public async Task NotBeTheSameInstanceAs_Chain()
    {
        var value = new TestObject("Test");
        var otherValue = new TestObject("Other");

        var chain = value.Should().NotBeTheSameInstanceAs(otherValue);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
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

    private sealed class TestObject(string name) : IEquatable<TestObject>
    {
        private readonly string name = name;

        public override string ToString() => name;

        public override bool Equals(object? obj) => Equals(obj as TestObject);

        public bool Equals(TestObject? other) => other is not null && other.name == name;

        public override int GetHashCode() => name.GetHashCode();
    }
}