namespace MrKWatkins.Assertions.Tests;

public sealed class BooleanAssertionsTests
{
    [Test]
    public async Task BeTrue()
    {
        await Assert.That(() => true.Should().BeTrue()).ThrowsNothing();
        await Assert.That(() => false.Should().BeTrue()).Throws<AssertionException>().WithMessage("Value should be true but was false.");
    }

    [Test]
    public async Task BeTrue_Chain()
    {
        var chain = true.Should().BeTrue();
        await Assert.That(chain.Value).IsEqualTo(true);
        await Assert.That(chain.And.Value).IsEqualTo(true);
    }

    [Test]
    public async Task NotBeTrue()
    {
        await Assert.That(() => true.Should().NotBeTrue()).Throws<AssertionException>().WithMessage("Value should not be true but was false.");
        await Assert.That(() => false.Should().NotBeTrue()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeTrue_Chain()
    {
        var chain = false.Should().NotBeTrue();
        await Assert.That(chain.Value).IsEqualTo(false);
        await Assert.That(chain.And.Value).IsEqualTo(false);
    }

    [Test]
    public async Task BeFalse()
    {
        await Assert.That(() => false.Should().BeFalse()).ThrowsNothing();
        await Assert.That(() => true.Should().BeFalse()).Throws<AssertionException>().WithMessage("Value should be false but was true.");
    }

    [Test]
    public async Task BeFalse_Chain()
    {
        var chain = false.Should().BeFalse();
        await Assert.That(chain.Value).IsEqualTo(false);
        await Assert.That(chain.And.Value).IsEqualTo(false);
    }

    [Test]
    public async Task NotBeFalse()
    {
        await Assert.That(() => true.Should().NotBeFalse()).ThrowsNothing();
        await Assert.That(() => false.Should().NotBeFalse()).Throws<AssertionException>().WithMessage("Value should not be false.");
    }

    [Test]
    public async Task NotBeFalse_Chain()
    {
        var chain = true.Should().NotBeFalse();
        await Assert.That(chain.Value).IsEqualTo(true);
        await Assert.That(chain.And.Value).IsEqualTo(true);
    }

    [Test]
    public async Task InheritedMethods_FromObjectAssertions()
    {
        // BooleanAssertions methods work alongside ObjectAssertions methods
        await Assert.That(() => true.Should().NotBeNull()).ThrowsNothing();
        await Assert.That(() => true.Should().Equal(true)).ThrowsNothing();
        await Assert.That(() => true.Should().NotEqual(false)).ThrowsNothing();
    }

    [Test]
    public async Task ChainWithInheritedMethods()
    {
        // Should be able to chain boolean-specific and object assertions
        await Assert.That(() => true.Should().BeTrue().And.NotEqual(false)).ThrowsNothing();
        await Assert.That(() => false.Should().BeFalse().And.NotEqual(true)).ThrowsNothing();
    }
}
