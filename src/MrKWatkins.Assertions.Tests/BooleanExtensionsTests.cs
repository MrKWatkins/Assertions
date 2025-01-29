using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

public sealed class BooleanExtensionsTests
{
    [Test]
    public async Task BeTrue_Boolean()
    {
        await Assert.That(() => true.Should().BeTrue()).ThrowsNothing();
        await Assert.That(() => false.Should().BeTrue()).Throws<AssertionException>().WithMessage("Value should be true but was false.");
    }

    [Test]
    public async Task BeTrue_Boolean_Chain()
    {
        var chain = true.Should().BeTrue();
        await Assert.That(chain.Value).IsEqualTo(true);
        await Assert.That(chain.And.Value).IsEqualTo(true);
    }

    [Test]
    public async Task BeTrue_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        await Assert.That(() => nullableTrue.Should().BeTrue()).ThrowsNothing();
        await Assert.That(() => nullableFalse.Should().BeTrue()).Throws<AssertionException>().WithMessage("Value should be true but was false.");
        await Assert.That(() => nullableNull.Should().BeTrue()).Throws<AssertionException>().WithMessage("Value should be true but was null.");
    }

    [Test]
    public async Task BeTrue_NullableBoolean_Chain()
    {
        bool? nullableTrue = true;

        var chain = nullableTrue.Should().BeTrue();
        await Assert.That(chain.Value).IsEqualTo(true);
        await Assert.That(chain.And.Value).IsEqualTo(true);
    }

    [Test]
    public async Task NotBeTrue_Boolean()
    {
        await Assert.That(() => true.Should().NotBeTrue()).Throws<AssertionException>().WithMessage("Value should not be true but was false.");
        await Assert.That(() => false.Should().NotBeTrue()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeTrue_Boolean_Chain()
    {
        var chain = false.Should().NotBeTrue();
        await Assert.That(chain.Value).IsEqualTo(false);
        await Assert.That(chain.And.Value).IsEqualTo(false);
    }

    [Test]
    public async Task NotBeTrue_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        await Assert.That(() => nullableTrue.Should().NotBeTrue()).Throws<AssertionException>().WithMessage("Value should not be true.");
        await Assert.That(() => nullableFalse.Should().NotBeTrue()).ThrowsNothing();
        await Assert.That(() => nullableNull.Should().NotBeTrue()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeTrue_NullableBoolean_Chain()
    {
        bool? nullableFalse = false;

        var chain = nullableFalse.Should().NotBeTrue();
        await Assert.That(chain.Value).IsEqualTo(false);
        await Assert.That(chain.And.Value).IsEqualTo(false);
    }

    [Test]
    public async Task BeFalse_Boolean()
    {
        await Assert.That(() => true.Should().BeFalse()).ThrowsNothing();
        await Assert.That(() => false.Should().BeFalse()).Throws<AssertionException>().WithMessage("Value should be false but was true.");
    }

    [Test]
    public async Task BeFalse_Boolean_Chain()
    {
        var chain = true.Should().BeFalse();
        await Assert.That(chain.Value).IsEqualTo(true);
        await Assert.That(chain.And.Value).IsEqualTo(true);
    }

    [Test]
    public async Task BeFalse_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        await Assert.That(() => nullableTrue.Should().BeFalse()).Throws<AssertionException>().WithMessage("Value should be false but was true.");
        await Assert.That(() => nullableFalse.Should().BeFalse()).ThrowsNothing();
        await Assert.That(() => nullableNull.Should().BeFalse()).Throws<AssertionException>().WithMessage("Value should be false but was null.");
    }

    [Test]
    public async Task BeFalse_NullableBoolean_Chain()
    {
        bool? nullableFalse = false;

        var chain = nullableFalse.Should().BeFalse();
        await Assert.That(chain.Value).IsEqualTo(false);
        await Assert.That(chain.And.Value).IsEqualTo(false);
    }

    [Test]
    public async Task NotBeFalse_Boolean()
    {
        await Assert.That(() => true.Should().NotBeFalse()).ThrowsNothing();
        await Assert.That(() => false.Should().NotBeFalse()).Throws<AssertionException>().WithMessage("Value should not be false.");
    }

    [Test]
    public async Task NotBeFalse_Boolean_Chain()
    {
        var chain = true.Should().NotBeFalse();
        await Assert.That(chain.Value).IsEqualTo(true);
        await Assert.That(chain.And.Value).IsEqualTo(true);
    }

    [Test]
    public async Task NotBeFalse_NullableBoolean()
    {
        bool? nullableTrue = true;
        bool? nullableFalse = false;
        bool? nullableNull = null;

        await Assert.That(() => nullableTrue.Should().NotBeFalse()).ThrowsNothing();
        await Assert.That(() => nullableFalse.Should().NotBeFalse()).Throws<AssertionException>().WithMessage("Value should not be false.");
        await Assert.That(() => nullableNull.Should().NotBeFalse()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeFalse_NullableBoolean_Chain()
    {
        bool? nullableFalse = true;

        var chain = nullableFalse.Should().NotBeFalse();
        await Assert.That(chain.Value).IsEqualTo(true);
        await Assert.That(chain.And.Value).IsEqualTo(true);
    }
}