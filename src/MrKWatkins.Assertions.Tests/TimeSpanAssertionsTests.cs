namespace MrKWatkins.Assertions.Tests;

public sealed class TimeSpanAssertionsTests
{
    private static readonly TimeSpan One = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan Five = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan Ten = TimeSpan.FromSeconds(10);
    private static readonly TimeSpan MinusFive = TimeSpan.FromSeconds(-5);

    [Test]
    public async Task Equal()
    {
        await Assert.That(() => Five.Should().Equal(TimeSpan.FromMilliseconds(5000))).ThrowsNothing();
        await Assert.That(() => Five.Should().Equal(Ten)).Throws<AssertionException>()
            .WithMessage("Value should equal 00:00:10 but was 00:00:05.");
    }

    [Test]
    public async Task NotEqual()
    {
        await Assert.That(() => Five.Should().NotEqual(Ten)).ThrowsNothing();
        await Assert.That(() => Five.Should().NotEqual(TimeSpan.FromMilliseconds(5000))).Throws<AssertionException>()
            .WithMessage("Value should not equal 00:00:05.");
    }

    [Test]
    public async Task BeZero()
    {
        await Assert.That(() => TimeSpan.Zero.Should().BeZero()).ThrowsNothing();
        await Assert.That(() => Five.Should().BeZero()).Throws<AssertionException>()
            .WithMessage("Value should be zero but was 00:00:05.");
    }

    [Test]
    public async Task BeZero_Chain()
    {
        var chain = TimeSpan.Zero.Should().BeZero();
        await Assert.That(chain.Value).IsEqualTo(TimeSpan.Zero);
        await Assert.That(chain.And.Value).IsEqualTo(TimeSpan.Zero);
    }

    [Test]
    public async Task NotBeZero()
    {
        await Assert.That(() => Five.Should().NotBeZero()).ThrowsNothing();
        await Assert.That(() => TimeSpan.Zero.Should().NotBeZero()).Throws<AssertionException>()
            .WithMessage("Value should not be zero.");
    }

    [Test]
    public async Task NotBeZero_Chain()
    {
        var chain = Five.Should().NotBeZero();
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task BeNegative()
    {
        await Assert.That(() => MinusFive.Should().BeNegative()).ThrowsNothing();
        await Assert.That(() => Five.Should().BeNegative()).Throws<AssertionException>()
            .WithMessage("Value should be negative but was 00:00:05.");
        await Assert.That(() => TimeSpan.Zero.Should().BeNegative()).Throws<AssertionException>()
            .WithMessage("Value should be negative but was 00:00:00.");
    }

    [Test]
    public async Task BeNegative_Chain()
    {
        var chain = MinusFive.Should().BeNegative();
        await Assert.That(chain.Value).IsEqualTo(MinusFive);
        await Assert.That(chain.And.Value).IsEqualTo(MinusFive);
    }

    [Test]
    public async Task NotBeNegative()
    {
        await Assert.That(() => Five.Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => TimeSpan.Zero.Should().NotBeNegative()).ThrowsNothing();
        await Assert.That(() => MinusFive.Should().NotBeNegative()).Throws<AssertionException>()
            .WithMessage("Value should not be negative but was -00:00:05.");
    }

    [Test]
    public async Task NotBeNegative_Chain()
    {
        var chain = Five.Should().NotBeNegative();
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task BePositive()
    {
        await Assert.That(() => Five.Should().BePositive()).ThrowsNothing();
        await Assert.That(() => MinusFive.Should().BePositive()).Throws<AssertionException>()
            .WithMessage("Value should be positive but was -00:00:05.");
        await Assert.That(() => TimeSpan.Zero.Should().BePositive()).Throws<AssertionException>()
            .WithMessage("Value should be positive but was 00:00:00.");
    }

    [Test]
    public async Task BePositive_Chain()
    {
        var chain = Five.Should().BePositive();
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task NotBePositive()
    {
        await Assert.That(() => MinusFive.Should().NotBePositive()).ThrowsNothing();
        await Assert.That(() => TimeSpan.Zero.Should().NotBePositive()).ThrowsNothing();
        await Assert.That(() => Five.Should().NotBePositive()).Throws<AssertionException>()
            .WithMessage("Value should not be positive but was 00:00:05.");
    }

    [Test]
    public async Task NotBePositive_Chain()
    {
        var chain = MinusFive.Should().NotBePositive();
        await Assert.That(chain.Value).IsEqualTo(MinusFive);
        await Assert.That(chain.And.Value).IsEqualTo(MinusFive);
    }

    [Test]
    public async Task BeLessThan()
    {
        await Assert.That(() => Five.Should().BeLessThan(Ten)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeLessThan(Five)).Throws<AssertionException>()
            .WithMessage("Value should be less than 00:00:05 but was 00:00:05.");
        await Assert.That(() => Five.Should().BeLessThan(One)).Throws<AssertionException>()
            .WithMessage("Value should be less than 00:00:01 but was 00:00:05.");
    }

    [Test]
    public async Task BeLessThan_Chain()
    {
        var chain = Five.Should().BeLessThan(Ten);
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task BeLessThanOrEqualTo()
    {
        await Assert.That(() => Five.Should().BeLessThanOrEqualTo(Ten)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeLessThanOrEqualTo(Five)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeLessThanOrEqualTo(One)).Throws<AssertionException>()
            .WithMessage("Value should be less than or equal to 00:00:01 but was 00:00:05.");
    }

    [Test]
    public async Task BeLessThanOrEqualTo_Chain()
    {
        var chain = Five.Should().BeLessThanOrEqualTo(Five);
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task BeGreaterThan()
    {
        await Assert.That(() => Five.Should().BeGreaterThan(One)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeGreaterThan(Five)).Throws<AssertionException>()
            .WithMessage("Value should be greater than 00:00:05 but was 00:00:05.");
        await Assert.That(() => Five.Should().BeGreaterThan(Ten)).Throws<AssertionException>()
            .WithMessage("Value should be greater than 00:00:10 but was 00:00:05.");
    }

    [Test]
    public async Task BeGreaterThan_Chain()
    {
        var chain = Five.Should().BeGreaterThan(One);
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo()
    {
        await Assert.That(() => Five.Should().BeGreaterThanOrEqualTo(One)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeGreaterThanOrEqualTo(Five)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeGreaterThanOrEqualTo(Ten)).Throws<AssertionException>()
            .WithMessage("Value should be greater than or equal to 00:00:10 but was 00:00:05.");
    }

    [Test]
    public async Task BeGreaterThanOrEqualTo_Chain()
    {
        var chain = Five.Should().BeGreaterThanOrEqualTo(Five);
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task BeInRange()
    {
        await Assert.That(() => Five.Should().BeInRange(One, Ten)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeInRange(Five, Ten)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeInRange(One, Five)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeInRange(Five, Five)).ThrowsNothing();
        await Assert.That(() => One.Should().BeInRange(Five, Ten)).Throws<AssertionException>()
            .WithMessage("Value should be in the range 00:00:05 to 00:00:10 but was 00:00:01.");
        await Assert.That(() => Ten.Should().BeInRange(One, Five)).Throws<AssertionException>()
            .WithMessage("Value should be in the range 00:00:01 to 00:00:05 but was 00:00:10.");
    }

    [Test]
    public async Task BeInRange_Chain()
    {
        var chain = Five.Should().BeInRange(One, Ten);
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task BeApproximately()
    {
        var precision = TimeSpan.FromMilliseconds(100);

        await Assert.That(() => Five.Should().BeApproximately(Five, precision)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(4900), precision)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(5100), precision)).ThrowsNothing();
        await Assert.That(() => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(4899), precision)).Throws<AssertionException>()
            .WithMessage("Value should be approximately 00:00:04.8990000 (±00:00:00.1000000) but was 00:00:05.");
        await Assert.That(() => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(5101), precision)).Throws<AssertionException>()
            .WithMessage("Value should be approximately 00:00:05.1010000 (±00:00:00.1000000) but was 00:00:05.");
    }

    [Test]
    public async Task BeApproximately_ExtremeValues()
    {
        await Assert.That(() => TimeSpan.MinValue.Should().BeApproximately(TimeSpan.MaxValue, One)).Throws<AssertionException>();
        await Assert.That(() => TimeSpan.MaxValue.Should().BeApproximately(TimeSpan.MinValue, One)).Throws<AssertionException>();
        await Assert.That(() => TimeSpan.MinValue.Should().BeApproximately(TimeSpan.MaxValue, TimeSpan.MaxValue)).Throws<AssertionException>();
        await Assert.That(() => TimeSpan.MaxValue.Should().BeApproximately(TimeSpan.Zero, TimeSpan.MaxValue)).ThrowsNothing();
    }

    [Test]
    public async Task BeApproximately_Chain()
    {
        var chain = Five.Should().BeApproximately(Five, One);
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }

    [Test]
    public async Task NotBeApproximately()
    {
        var precision = TimeSpan.FromMilliseconds(100);

        await Assert.That(() => Five.Should().NotBeApproximately(TimeSpan.FromMilliseconds(4899), precision)).ThrowsNothing();
        await Assert.That(() => Five.Should().NotBeApproximately(TimeSpan.FromMilliseconds(5101), precision)).ThrowsNothing();
        await Assert.That(() => TimeSpan.MinValue.Should().NotBeApproximately(TimeSpan.MaxValue, One)).ThrowsNothing();
        await Assert.That(() => Five.Should().NotBeApproximately(TimeSpan.FromMilliseconds(5100), precision)).Throws<AssertionException>()
            .WithMessage("Value should not be approximately 00:00:05.1000000 (±00:00:00.1000000) but was 00:00:05.");
    }

    [Test]
    public async Task NotBeApproximately_Chain()
    {
        var chain = Five.Should().NotBeApproximately(Ten, One);
        await Assert.That(chain.Value).IsEqualTo(Five);
        await Assert.That(chain.And.Value).IsEqualTo(Five);
    }
}