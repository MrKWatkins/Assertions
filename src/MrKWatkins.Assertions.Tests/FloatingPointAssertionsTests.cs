namespace MrKWatkins.Assertions.Tests;

public sealed class FloatingPointAssertionsTests
{
    [Test]
    public async Task BeApproximately()
    {
        const double value = 17.5;

        await Assert.That(() => value.Should().BeApproximately(17.5, 0.1)).ThrowsNothing();
        await Assert.That(() => value.Should().BeApproximately(17.45, 0.1)).ThrowsNothing();
        await Assert.That(() => value.Should().BeApproximately(17.55, 0.1)).ThrowsNothing();
        await Assert.That(() => value.Should().BeApproximately(17.6, 0.1)).Throws<AssertionException>()
            .WithMessage("Value should be approximately 17.6 (±0.1) but was 17.5.");
        await Assert.That(() => value.Should().BeApproximately(17.4, 0.1)).Throws<AssertionException>()
            .WithMessage("Value should be approximately 17.4 (±0.1) but was 17.5.");
    }

    [Test]
    public async Task BeApproximately_Float()
    {
        const float value = 17.5f;

        await Assert.That(() => value.Should().BeApproximately(17.5f, 0.1f)).ThrowsNothing();
        await Assert.That(() => value.Should().BeApproximately(17.6f, 0.05f)).Throws<AssertionException>();
    }

    [Test]
    public async Task BeApproximately_Half()
    {
        var value = (Half)17.5;

        await Assert.That(() => value.Should().BeApproximately((Half)17.5, (Half)0.1)).ThrowsNothing();
        await Assert.That(() => value.Should().BeApproximately((Half)17.6, (Half)0.05)).Throws<AssertionException>();
    }

    [Test]
    public async Task BeApproximately_Chain()
    {
        const double value = 17.5;

        var chain = value.Should().BeApproximately(17.5, 0.1);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeLessThan()
    {
        const double value = 5.0;

        await Assert.That(() => value.Should().BeLessThan(10.0, 0.001)).ThrowsNothing();
        await Assert.That(() => value.Should().BeLessThan(5.0, 0.001)).Throws<AssertionException>()
            .WithMessage("Value should be less than 5 (±0.001) but was 5.");
        await Assert.That(() => value.Should().BeLessThan(1.0, 0.001)).Throws<AssertionException>()
            .WithMessage("Value should be less than 1 (±0.001) but was 5.");
    }

    [Test]
    public async Task BeLessThan_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeLessThan(10.0, 0.001);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeLessThanOrEqualTo()
    {
        const double value = 5.0;

        await Assert.That(() => value.Should().BeLessThanOrEqualTo(10.0, 0.001)).ThrowsNothing();
        await Assert.That(() => value.Should().BeLessThanOrEqualTo(5.0, 0.001)).ThrowsNothing();
        await Assert.That(() => value.Should().BeLessThanOrEqualTo(1.0, 0.001)).Throws<AssertionException>()
            .WithMessage("Value should be less than or equal to 1 (±0.001) but was 5.");
    }

    [Test]
    public async Task BeLessThanOrEqualTo_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeLessThanOrEqualTo(5.0, 0.001);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeGreaterThan()
    {
        const double value = 5.0;

        await Assert.That(() => value.Should().BeGreaterThan(1.0, 0.001)).ThrowsNothing();
        await Assert.That(() => value.Should().BeGreaterThan(5.0, 0.001)).Throws<AssertionException>()
            .WithMessage("Value should be greater than 5 (±0.001) but was 5.");
        await Assert.That(() => value.Should().BeGreaterThan(10.0, 0.001)).Throws<AssertionException>()
            .WithMessage("Value should be greater than 10 (±0.001) but was 5.");
    }

    [Test]
    public async Task BeGreaterThan_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeGreaterThan(1.0, 0.001);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo()
    {
        const double value = 5.0;

        await Assert.That(() => value.Should().BeGreaterThanOrEqualTo(1.0, 0.001)).ThrowsNothing();
        await Assert.That(() => value.Should().BeGreaterThanOrEqualTo(5.0, 0.001)).ThrowsNothing();
        await Assert.That(() => value.Should().BeGreaterThanOrEqualTo(10.0, 0.001)).Throws<AssertionException>()
            .WithMessage("Value should be greater than or equal to 10 (±0.001) but was 5.");
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeGreaterThanOrEqualTo(5.0, 0.001);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task BeZero()
    {
        await Assert.That(() => (0.0).Should().BeZero()).ThrowsNothing();
        await Assert.That(() => (5.0).Should().BeZero()).Throws<AssertionException>()
            .WithMessage("Value should be zero but was 5.");
    }

    [Test]
    public async Task BeZero_Chain()
    {
        var chain = (0.0).Should().BeZero();
        await Assert.That(chain.Value).IsEqualTo(0.0);
        await Assert.That(chain.And.Value).IsEqualTo(0.0);
    }

    [Test]
    public async Task NotBeZero()
    {
        await Assert.That(() => (5.0).Should().NotBeZero()).ThrowsNothing();
        await Assert.That(() => (0.0).Should().NotBeZero()).Throws<AssertionException>()
            .WithMessage("Value should not be zero.");
    }

    [Test]
    public async Task NotBeZero_Chain()
    {
        var chain = (5.0).Should().NotBeZero();
        await Assert.That(chain.Value).IsEqualTo(5.0);
        await Assert.That(chain.And.Value).IsEqualTo(5.0);
    }

    [Test]
    public async Task BeNegative()
    {
        await Assert.That(() => (-5.0).Should().BeNegative()).ThrowsNothing();
        await Assert.That(() => (5.0).Should().BeNegative()).Throws<AssertionException>()
            .WithMessage("Value should be negative but was 5.");
    }

    [Test]
    public async Task BeNegative_Chain()
    {
        var chain = (-5.0).Should().BeNegative();
        await Assert.That(chain.Value).IsEqualTo(-5.0);
        await Assert.That(chain.And.Value).IsEqualTo(-5.0);
    }

    [Test]
    public async Task NotBeNegative()
    {
        await Assert.That(() => (5.0).Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => (-5.0).Should().NotBeNegative()).Throws<AssertionException>()
            .WithMessage("Value should not be negative but was -5.");
    }

    [Test]
    public async Task NotBeNegative_Chain()
    {
        var chain = (5.0).Should().NotBeNegative();
        await Assert.That(chain.Value).IsEqualTo(5.0);
        await Assert.That(chain.And.Value).IsEqualTo(5.0);
    }

    [Test]
    public async Task BePositive()
    {
        await Assert.That(() => (5.0).Should().BePositive()).ThrowsNothing();
        await Assert.That(() => (-5.0).Should().BePositive()).Throws<AssertionException>()
            .WithMessage("Value should be positive but was -5.");
    }

    [Test]
    public async Task BePositive_Chain()
    {
        var chain = (5.0).Should().BePositive();
        await Assert.That(chain.Value).IsEqualTo(5.0);
        await Assert.That(chain.And.Value).IsEqualTo(5.0);
    }

    [Test]
    public async Task NotBePositive()
    {
        await Assert.That(() => (-5.0).Should().NotBePositive()).ThrowsNothing();
        await Assert.That(() => (5.0).Should().NotBePositive()).Throws<AssertionException>()
            .WithMessage("Value should not be positive but was 5.");
    }

    [Test]
    public async Task NotBePositive_Chain()
    {
        var chain = (-5.0).Should().NotBePositive();
        await Assert.That(chain.Value).IsEqualTo(-5.0);
        await Assert.That(chain.And.Value).IsEqualTo(-5.0);
    }

    [Test]
    public async Task BeNaN()
    {
        await Assert.That(() => double.NaN.Should().BeNaN()).ThrowsNothing();
        await Assert.That(() => (5.0).Should().BeNaN()).Throws<AssertionException>()
            .WithMessage("Value should be NaN but was 5.");
    }

    [Test]
    public async Task BeNaN_Chain()
    {
        var chain = double.NaN.Should().BeNaN();
        await Assert.That(double.IsNaN(chain.Value)).IsTrue();
        await Assert.That(double.IsNaN(chain.And.Value)).IsTrue();
    }

    [Test]
    public async Task NotBeNaN()
    {
        await Assert.That(() => (5.0).Should().NotBeNaN()).ThrowsNothing();
        await Assert.That(() => double.NaN.Should().NotBeNaN()).Throws<AssertionException>()
            .WithMessage("Value should not be NaN.");
    }

    [Test]
    public async Task NotBeNaN_Chain()
    {
        var chain = (5.0).Should().NotBeNaN();
        await Assert.That(chain.Value).IsEqualTo(5.0);
        await Assert.That(chain.And.Value).IsEqualTo(5.0);
    }

    [Test]
    public async Task BeInfinity()
    {
        await Assert.That(() => double.PositiveInfinity.Should().BeInfinity()).ThrowsNothing();
        await Assert.That(() => double.NegativeInfinity.Should().BeInfinity()).ThrowsNothing();
        await Assert.That(() => (5.0).Should().BeInfinity()).Throws<AssertionException>()
            .WithMessage("Value should be infinity but was 5.");
    }

    [Test]
    public async Task BeInfinity_Chain()
    {
        var chain = double.PositiveInfinity.Should().BeInfinity();
        await Assert.That(double.IsInfinity(chain.Value)).IsTrue();
        await Assert.That(double.IsInfinity(chain.And.Value)).IsTrue();
    }

    [Test]
    public async Task NotBeInfinity()
    {
        await Assert.That(() => (5.0).Should().NotBeInfinity()).ThrowsNothing();
        await Assert.That(() => double.PositiveInfinity.Should().NotBeInfinity()).Throws<AssertionException>()
            .WithMessage("Value should not be infinity.");
    }

    [Test]
    public async Task NotBeInfinity_Chain()
    {
        var chain = (5.0).Should().NotBeInfinity();
        await Assert.That(chain.Value).IsEqualTo(5.0);
        await Assert.That(chain.And.Value).IsEqualTo(5.0);
    }

    [Test]
    public async Task BePositiveInfinity()
    {
        await Assert.That(() => double.PositiveInfinity.Should().BePositiveInfinity()).ThrowsNothing();
        await Assert.That(() => (5.0).Should().BePositiveInfinity()).Throws<AssertionException>()
            .WithMessage("Value should be positive infinity but was 5.");
    }

    [Test]
    public async Task BePositiveInfinity_Chain()
    {
        var chain = double.PositiveInfinity.Should().BePositiveInfinity();
        await Assert.That(double.IsPositiveInfinity(chain.Value)).IsTrue();
        await Assert.That(double.IsPositiveInfinity(chain.And.Value)).IsTrue();
    }

    [Test]
    public async Task BeNegativeInfinity()
    {
        await Assert.That(() => double.NegativeInfinity.Should().BeNegativeInfinity()).ThrowsNothing();
        await Assert.That(() => (5.0).Should().BeNegativeInfinity()).Throws<AssertionException>()
            .WithMessage("Value should be negative infinity but was 5.");
    }

    [Test]
    public async Task BeNegativeInfinity_Chain()
    {
        var chain = double.NegativeInfinity.Should().BeNegativeInfinity();
        await Assert.That(double.IsNegativeInfinity(chain.Value)).IsTrue();
        await Assert.That(double.IsNegativeInfinity(chain.And.Value)).IsTrue();
    }
}