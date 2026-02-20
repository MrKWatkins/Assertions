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
}
