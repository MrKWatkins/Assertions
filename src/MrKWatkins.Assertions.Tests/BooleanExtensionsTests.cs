namespace MrKWatkins.Assertions.Tests;

public sealed class BooleanExtensionsTests
{
    [Test]
    public void BeTrue_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        Assert.DoesNotThrow(() => nullableTrue.Should().BeTrue());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be true but was false."), () => nullableFalse.Should().BeTrue());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be true but was null."), () => nullableNull.Should().BeTrue());
    }

    [Test]
    public void BeTrue_NullableBoolean_Chain()
    {
        bool? nullableTrue = true;

        var chain = nullableTrue.Should().BeTrue();
        Assert.That(chain.Value, Is.True);
        Assert.That(chain.And.Value, Is.True);
    }

    [Test]
    public void NotBeTrue_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be true."), () => nullableTrue.Should().NotBeTrue());
        Assert.DoesNotThrow(() => nullableFalse.Should().NotBeTrue());
        Assert.DoesNotThrow(() => nullableNull.Should().NotBeTrue());
    }

    [Test]
    public void NotBeTrue_NullableBoolean_Chain()
    {
        bool? nullableFalse = false;

        var chain = nullableFalse.Should().NotBeTrue();
        Assert.That(chain.Value, Is.False);
        Assert.That(chain.And.Value, Is.False);
    }

    [Test]
    public void BeFalse_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be false but was true."), () => nullableTrue.Should().BeFalse());
        Assert.DoesNotThrow(() => nullableFalse.Should().BeFalse());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be false but was null."), () => nullableNull.Should().BeFalse());
    }

    [Test]
    public void BeFalse_NullableBoolean_Chain()
    {
        bool? nullableFalse = false;

        var chain = nullableFalse.Should().BeFalse();
        Assert.That(chain.Value, Is.False);
        Assert.That(chain.And.Value, Is.False);
    }

    [Test]
    public void NotBeFalse_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        Assert.DoesNotThrow(() => nullableTrue.Should().NotBeFalse());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be false."), () => nullableFalse.Should().NotBeFalse());
        Assert.DoesNotThrow(() => nullableNull.Should().NotBeFalse());
    }

    [Test]
    public void NotBeFalse_NullableBoolean_Chain()
    {
        bool? nullableFalse = true;

        var chain = nullableFalse.Should().NotBeFalse();
        Assert.That(chain.Value, Is.True);
        Assert.That(chain.And.Value, Is.True);
    }
}