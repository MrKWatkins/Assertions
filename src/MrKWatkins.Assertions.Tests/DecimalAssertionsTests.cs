namespace MrKWatkins.Assertions.Tests;

public sealed class DecimalAssertionsTests
{
    [Test]
    public async Task BeZero()
    {
        await Assert.That(() => (0m).Should().BeZero()).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeZero()).Throws<AssertionException>()
            .WithMessage("Value should be zero but was 5.");
    }

    [Test]
    public async Task BeZero_Chain()
    {
        var chain = (0m).Should().BeZero();
        await Assert.That(chain.Value).IsEqualTo(0m);
        await Assert.That(chain.And.Value).IsEqualTo(0m);
    }

    [Test]
    public async Task NotBeZero()
    {
        await Assert.That(() => (5m).Should().NotBeZero()).ThrowsNothing();
        await Assert.That(() => (0m).Should().NotBeZero()).Throws<AssertionException>()
            .WithMessage("Value should not be zero.");
    }

    [Test]
    public async Task NotBeZero_Chain()
    {
        var chain = (5m).Should().NotBeZero();
        await Assert.That(chain.Value).IsEqualTo(5m);
        await Assert.That(chain.And.Value).IsEqualTo(5m);
    }

    [Test]
    public async Task BeNegative()
    {
        await Assert.That(() => (-5m).Should().BeNegative()).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeNegative()).Throws<AssertionException>()
            .WithMessage("Value should be negative but was 5.");
        await Assert.That(() => (0m).Should().BeNegative()).Throws<AssertionException>()
            .WithMessage("Value should be negative but was 0.");
    }

    [Test]
    public async Task BeNegative_Chain()
    {
        var chain = (-5m).Should().BeNegative();
        await Assert.That(chain.Value).IsEqualTo(-5m);
        await Assert.That(chain.And.Value).IsEqualTo(-5m);
    }

    [Test]
    public async Task NotBeNegative()
    {
        await Assert.That(() => (5m).Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => (0m).Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => (-5m).Should().NotBeNegative()).Throws<AssertionException>()
            .WithMessage("Value should not be negative but was -5.");
    }

    [Test]
    public async Task NotBeNegative_Chain()
    {
        var chain = (5m).Should().NotBeNegative();
        await Assert.That(chain.Value).IsEqualTo(5m);
        await Assert.That(chain.And.Value).IsEqualTo(5m);
    }

    [Test]
    public async Task BePositive()
    {
        await Assert.That(() => (5m).Should().BePositive()).ThrowsNothing();
        await Assert.That(() => (-5m).Should().BePositive()).Throws<AssertionException>()
            .WithMessage("Value should be positive but was -5.");
        await Assert.That(() => (0m).Should().BePositive()).Throws<AssertionException>()
            .WithMessage("Value should be positive but was 0.");
    }

    [Test]
    public async Task BePositive_Chain()
    {
        var chain = (5m).Should().BePositive();
        await Assert.That(chain.Value).IsEqualTo(5m);
        await Assert.That(chain.And.Value).IsEqualTo(5m);
    }

    [Test]
    public async Task NotBePositive()
    {
        await Assert.That(() => (-5m).Should().NotBePositive()).ThrowsNothing();
        await Assert.That(() => (0m).Should().NotBePositive()).ThrowsNothing();
        await Assert.That(() => (5m).Should().NotBePositive()).Throws<AssertionException>()
            .WithMessage("Value should not be positive but was 5.");
    }

    [Test]
    public async Task NotBePositive_Chain()
    {
        var chain = (-5m).Should().NotBePositive();
        await Assert.That(chain.Value).IsEqualTo(-5m);
        await Assert.That(chain.And.Value).IsEqualTo(-5m);
    }

    [Test]
    public async Task BeLessThan()
    {
        await Assert.That(() => (5m).Should().BeLessThan(10m)).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeLessThan(5m)).Throws<AssertionException>()
            .WithMessage("Value should be less than 5 but was 5.");
        await Assert.That(() => (5m).Should().BeLessThan(1m)).Throws<AssertionException>()
            .WithMessage("Value should be less than 1 but was 5.");
    }

    [Test]
    public async Task BeLessThan_Chain()
    {
        var chain = (5m).Should().BeLessThan(10m);
        await Assert.That(chain.Value).IsEqualTo(5m);
        await Assert.That(chain.And.Value).IsEqualTo(5m);
    }

    [Test]
    public async Task BeLessThanOrEqualTo()
    {
        await Assert.That(() => (5m).Should().BeLessThanOrEqualTo(10m)).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeLessThanOrEqualTo(5m)).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeLessThanOrEqualTo(1m)).Throws<AssertionException>()
            .WithMessage("Value should be less than or equal to 1 but was 5.");
    }

    [Test]
    public async Task BeLessThanOrEqualTo_Chain()
    {
        var chain = (5m).Should().BeLessThanOrEqualTo(5m);
        await Assert.That(chain.Value).IsEqualTo(5m);
        await Assert.That(chain.And.Value).IsEqualTo(5m);
    }

    [Test]
    public async Task BeGreaterThan()
    {
        await Assert.That(() => (5m).Should().BeGreaterThan(1m)).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeGreaterThan(5m)).Throws<AssertionException>()
            .WithMessage("Value should be greater than 5 but was 5.");
        await Assert.That(() => (5m).Should().BeGreaterThan(10m)).Throws<AssertionException>()
            .WithMessage("Value should be greater than 10 but was 5.");
    }

    [Test]
    public async Task BeGreaterThan_Chain()
    {
        var chain = (5m).Should().BeGreaterThan(1m);
        await Assert.That(chain.Value).IsEqualTo(5m);
        await Assert.That(chain.And.Value).IsEqualTo(5m);
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo()
    {
        await Assert.That(() => (5m).Should().BeGreaterThanOrEqualTo(1m)).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeGreaterThanOrEqualTo(5m)).ThrowsNothing();
        await Assert.That(() => (5m).Should().BeGreaterThanOrEqualTo(10m)).Throws<AssertionException>()
            .WithMessage("Value should be greater than or equal to 10 but was 5.");
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo_Chain()
    {
        var chain = (5m).Should().BeGreaterThanOrEqualTo(5m);
        await Assert.That(chain.Value).IsEqualTo(5m);
        await Assert.That(chain.And.Value).IsEqualTo(5m);
    }
}