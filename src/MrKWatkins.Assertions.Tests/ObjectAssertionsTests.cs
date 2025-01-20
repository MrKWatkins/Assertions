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