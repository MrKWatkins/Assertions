namespace MrKWatkins.Assertions.Tests;

public sealed class ObjectAssertionsTests
{
    [Test]
    public void BeNull_ReferenceType()
    {
        const string notNullValue = "Not Null";
        string nullValue = null!;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be null but was \"Not Null\"."), () => notNullValue.Should().BeNull());
        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
    }

    [Test]
    public void BeNull_ValueType()
    {
        const int notNullValue = 123;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be null but was 123."), () => notNullValue.Should().BeNull());
    }

    [Test]
    public void BeNull_NullableValueType()
    {
        int? nullValue = null;
        int? notNullValue = 123;

        Assert.DoesNotThrow(() => nullValue.Should().BeNull());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be null but was 123."), () => notNullValue.Should().BeNull());
    }

    [Test]
    public void NotBeNull_ReferenceType()
    {
        string nullValue = null!;
        const string notNullValue = "Not Null";

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().NotBeNull());
        Assert.DoesNotThrow(() => notNullValue.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_ValueType()
    {
        const int notNullValue = 123;

        Assert.DoesNotThrow(() => notNullValue.Should().NotBeNull());
    }

    [Test]
    public void NotBeNull_NullableValueType()
    {
        int? nullValue = null;
        int? notNullValue = 123;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().NotBeNull());
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
    public void Equal_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal \"Not Null\" but was null."),
            () => nullValue.Should().Equal(nonNullValue)
        );
        Assert.DoesNotThrow(() => nullValue.Should().Equal(nullValue));
    }

    [Test]
    public void Equal()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal \"Not Test\" but was \"Test\"."),
            () => value.Should().Equal(otherValue)
        );
        Assert.DoesNotThrow(() => value.Should().Equal(value));
    }

    [Test]
    public void Equal_Enum()
    {
        const ConsoleColor value = ConsoleColor.Blue;
        const ConsoleColor otherValue = ConsoleColor.Red;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal Red but was Blue."), () => value.Should().Equal(otherValue));
        Assert.DoesNotThrow(() => value.Should().Equal(value));
    }

    [Test]
    public void Equal_Chain()
    {
        const string value = "Test";

        var chain = value.Should().Equal(value);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void Equal_Comparer_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal \"Not Null\" but was null."),
            () => nullValue.Should().Equal(nonNullValue, StringComparer.OrdinalIgnoreCase)
        );
        Assert.DoesNotThrow(() => nullValue.Should().Equal(nullValue, StringComparer.OrdinalIgnoreCase));
    }

    [Test]
    public void Equal_Comparer()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal \"Not Test\" but was \"Test\"."),
            () => value.Should().Equal(otherValue, StringComparer.OrdinalIgnoreCase)
        );
        Assert.DoesNotThrow(() => value.Should().Equal(sameValueDifferentCase, StringComparer.OrdinalIgnoreCase));
    }

    [Test]
    public void Equal_Comparer_Chain()
    {
        const string value = "Test";

        var chain = value.Should().Equal("test", StringComparer.OrdinalIgnoreCase);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void Equal_Predicate_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal \"Not Null\" but was null."),
            () => nullValue.Should().Equal(nonNullValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
        );
        Assert.DoesNotThrow(() => nullValue.Should().Equal(nullValue, (a, b) => a is null && b is null));
    }

    [Test]
    public void Equal_Predicate()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal \"Not Test\" but was \"Test\"."),
            () => value.Should().Equal(otherValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
        );
        Assert.DoesNotThrow(() => value.Should().Equal(sameValueDifferentCase, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
    }

    [Test]
    public void Equal_Predicate_Chain()
    {
        const string value = "Test";

        var chain = value.Should().Equal("test", (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotEqual_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        Assert.DoesNotThrow(() => nullValue.Should().NotEqual(nonNullValue));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal null."), () => nullValue.Should().NotEqual(nullValue));
    }

    [Test]
    public void NotEqual()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        Assert.DoesNotThrow(() => value.Should().NotEqual(otherValue));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal \"Test\"."), () => value.Should().NotEqual(value));
    }

    [Test]
    public void NotEqual_Chain()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        var chain = value.Should().NotEqual(otherValue);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotEqual_Comparer_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        Assert.DoesNotThrow(() => nullValue.Should().NotEqual(nonNullValue, StringComparer.OrdinalIgnoreCase));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal null."),
            () => nullValue.Should().NotEqual(nullValue, StringComparer.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void NotEqual_Comparer()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        Assert.DoesNotThrow(() => value.Should().NotEqual(otherValue, StringComparer.OrdinalIgnoreCase));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal \"test\"."),
            () => value.Should().NotEqual(sameValueDifferentCase, StringComparer.OrdinalIgnoreCase)
        );
    }

    [Test]
    public void NotEqual_Comparer_Chain()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        var chain = value.Should().NotEqual(otherValue, StringComparer.OrdinalIgnoreCase);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotEqual_Predicate_Null()
    {
        string? nullValue = null;
        const string nonNullValue = "Not Null";

        Assert.DoesNotThrow(() => nullValue.Should().NotEqual(nonNullValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal null."),
            () => nullValue.Should().NotEqual(nullValue, (a, b) => a is null && b is null)
        );
    }

    [Test]
    public void NotEqual_Predicate()
    {
        const string value = "Test";
        const string sameValueDifferentCase = "test";
        const string otherValue = "Not Test";

        Assert.DoesNotThrow(() => value.Should().NotEqual(otherValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase)));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal \"test\"."),
            () => value.Should().NotEqual(sameValueDifferentCase, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase))
        );
    }

    [Test]
    public void NotEqual_Predicate_Chain()
    {
        const string value = "Test";
        const string otherValue = "Not Test";

        var chain = value.Should().NotEqual(otherValue, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeTheSameInstanceAs()
    {
        TestObject? nullValue = null;
        var value = new TestObject("Test");
        var otherValue = new TestObject("Other");

        Assert.DoesNotThrow(() => nullValue.Should().BeTheSameInstanceAs(nullValue));
        Assert.DoesNotThrow(() => value.Should().BeTheSameInstanceAs(value));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be the same instance as null but was Test."),
            () => value.Should().BeTheSameInstanceAs(nullValue)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be the same instance as Test but was null."),
            () => nullValue.Should().BeTheSameInstanceAs(value)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be the same instance as Other but was Test."),
            () => value.Should().BeTheSameInstanceAs(otherValue)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be the same instance as Test but was Other."),
            () => otherValue.Should().BeTheSameInstanceAs(value)
        );
    }

    [Test]
    public void BeTheSameInstanceAs_Chain()
    {
        var value = new TestObject("Test");

        var chain = value.Should().BeTheSameInstanceAs(value);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotBeTheSameInstanceAs()
    {
        TestObject nullValue = null!;
        var value = new TestObject("Test");
        var otherValue = new TestObject("Other");

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be the same instance as null."),
            () => nullValue.Should().NotBeTheSameInstanceAs(nullValue)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be the same instance as Test."),
            () => value.Should().NotBeTheSameInstanceAs(value)
        );
        Assert.DoesNotThrow(() => value.Should().NotBeTheSameInstanceAs(nullValue));
        Assert.DoesNotThrow(() => nullValue.Should().NotBeTheSameInstanceAs(value));
        Assert.DoesNotThrow(() => value.Should().NotBeTheSameInstanceAs(otherValue));
        Assert.DoesNotThrow(() => otherValue.Should().NotBeTheSameInstanceAs(value));
    }

    [Test]
    public void NotBeTheSameInstanceAs_Chain()
    {
        var value = new TestObject("Test");
        var otherValue = new TestObject("Other");

        var chain = value.Should().NotBeTheSameInstanceAs(otherValue);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeOfType()
    {
        object? nullValue = null;
        object value = "String";

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().BeOfType<object>());
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be of type Int32 but was of type String."),
            () => value.Should().BeOfType<int>()
        );
        Assert.DoesNotThrow(() => value.Should().BeOfType<string>());
    }

    [Test]
    public void BeOfType_Chain()
    {
        object value = "String";

        var chain = value.Should().BeOfType<string>();
        Assert.That(chain.Value, Is.EqualTo((string)value));
        Assert.That(chain.And.Value, Is.EqualTo((string)value));
    }

    [Test]
    public void NotBeOfType()
    {
        object? nullValue = null;
        object value = "String";

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().NotBeOfType<object>());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be of type String."), () => value.Should().NotBeOfType<string>());
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

    private sealed class TestObject(string name) : IEquatable<TestObject>
    {
        private readonly string name = name;

        public override string ToString() => name;

        public override bool Equals(object? obj) => Equals(obj as TestObject);

        public bool Equals(TestObject? other) => other is not null && other.name == name;

        public override int GetHashCode() => name.GetHashCode(StringComparison.Ordinal);
    }
}