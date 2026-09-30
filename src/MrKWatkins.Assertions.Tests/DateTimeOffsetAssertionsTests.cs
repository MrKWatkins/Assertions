namespace MrKWatkins.Assertions.Tests;

public sealed class DateTimeOffsetAssertionsTests
{
    private static readonly DateTimeOffset Morning = new(2026, 9, 30, 9, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset Noon = new(2026, 9, 30, 12, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset Evening = new(2026, 9, 30, 18, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset NoonPlusOne = new(2026, 9, 30, 13, 0, 0, TimeSpan.FromHours(1));

    [Test]
    public async Task Equal()
    {
        await Assert.That(() => Noon.Should().Equal(Noon)).ThrowsNothing();
        await Assert.That(() => Noon.Should().Equal(NoonPlusOne)).ThrowsNothing();
        await Assert.That(() => Noon.Should().Equal(Evening)).Throws<AssertionException>()
            .WithMessage("Value should equal 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task NotEqual()
    {
        await Assert.That(() => Noon.Should().NotEqual(Evening)).ThrowsNothing();
        await Assert.That(() => Noon.Should().NotEqual(NoonPlusOne)).Throws<AssertionException>()
            .WithMessage("Value should not equal 2026-09-30T13:00:00+01:00.");
    }

    [Test]
    public async Task Comparisons()
    {
        await Assert.That(() => Noon.Should().BeLessThan(Evening)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeLessThanOrEqualTo(NoonPlusOne)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeGreaterThan(Morning)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeGreaterThanOrEqualTo(NoonPlusOne)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeInRange(Morning, Evening)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeGreaterThan(Evening)).Throws<AssertionException>()
            .WithMessage("Value should be greater than 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task BeBefore()
    {
        await Assert.That(() => Noon.Should().BeBefore(Evening)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeBefore(Noon)).Throws<AssertionException>()
            .WithMessage("Value should be before 2026-09-30T12:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
        await Assert.That(() => Noon.Should().BeBefore(NoonPlusOne)).Throws<AssertionException>()
            .WithMessage("Value should be before 2026-09-30T13:00:00+01:00 but was 2026-09-30T12:00:00+00:00.");
        await Assert.That(() => Noon.Should().BeBefore(Morning)).Throws<AssertionException>()
            .WithMessage("Value should be before 2026-09-30T09:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task BeBefore_Chain()
    {
        var chain = Noon.Should().BeBefore(Evening);
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task BeOnOrBefore()
    {
        await Assert.That(() => Noon.Should().BeOnOrBefore(Evening)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeOnOrBefore(Noon)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeOnOrBefore(NoonPlusOne)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeOnOrBefore(Morning)).Throws<AssertionException>()
            .WithMessage("Value should be on or before 2026-09-30T09:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task BeOnOrBefore_Chain()
    {
        var chain = Noon.Should().BeOnOrBefore(Noon);
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task BeAfter()
    {
        await Assert.That(() => Noon.Should().BeAfter(Morning)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeAfter(Noon)).Throws<AssertionException>()
            .WithMessage("Value should be after 2026-09-30T12:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
        await Assert.That(() => Noon.Should().BeAfter(Evening)).Throws<AssertionException>()
            .WithMessage("Value should be after 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task BeAfter_Chain()
    {
        var chain = Noon.Should().BeAfter(Morning);
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task BeOnOrAfter()
    {
        await Assert.That(() => Noon.Should().BeOnOrAfter(Morning)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeOnOrAfter(Noon)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeOnOrAfter(NoonPlusOne)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeOnOrAfter(Evening)).Throws<AssertionException>()
            .WithMessage("Value should be on or after 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task BeOnOrAfter_Chain()
    {
        var chain = Noon.Should().BeOnOrAfter(Noon);
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task BeApproximately()
    {
        var precision = TimeSpan.FromSeconds(1);

        await Assert.That(() => Noon.Should().BeApproximately(Noon, precision)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeApproximately(NoonPlusOne, precision)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeApproximately(Noon.AddSeconds(1), precision)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeApproximately(Noon.AddSeconds(-1), precision)).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeApproximately(Noon.AddMilliseconds(1500), precision)).Throws<AssertionException>()
            .WithMessage("Value should be approximately 2026-09-30T12:00:01.5+00:00 (±00:00:01) but was 2026-09-30T12:00:00+00:00.");
        await Assert.That(() => Noon.Should().BeApproximately(Noon.AddMilliseconds(-1500), precision)).Throws<AssertionException>()
            .WithMessage("Value should be approximately 2026-09-30T11:59:58.5+00:00 (±00:00:01) but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task BeApproximately_ExtremeValues()
    {
        await Assert.That(() => DateTimeOffset.MinValue.Should().BeApproximately(DateTimeOffset.MaxValue, TimeSpan.FromDays(1))).Throws<AssertionException>();
        await Assert.That(() => DateTimeOffset.MaxValue.Should().BeApproximately(DateTimeOffset.MinValue, TimeSpan.FromDays(1))).Throws<AssertionException>();
        await Assert.That(() => DateTimeOffset.MinValue.Should().BeApproximately(DateTimeOffset.MaxValue, TimeSpan.MaxValue)).ThrowsNothing();
    }

    [Test]
    public async Task BeApproximately_Chain()
    {
        var chain = Noon.Should().BeApproximately(Noon, TimeSpan.FromSeconds(1));
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task NotBeApproximately()
    {
        var precision = TimeSpan.FromSeconds(1);

        await Assert.That(() => Noon.Should().NotBeApproximately(Evening, precision)).ThrowsNothing();
        await Assert.That(() => Noon.Should().NotBeApproximately(Noon.AddMilliseconds(1500), precision)).ThrowsNothing();
        await Assert.That(() => DateTimeOffset.MinValue.Should().NotBeApproximately(DateTimeOffset.MaxValue, precision)).ThrowsNothing();
        await Assert.That(() => Noon.Should().NotBeApproximately(Noon.AddSeconds(1), precision)).Throws<AssertionException>()
            .WithMessage("Value should not be approximately 2026-09-30T12:00:01+00:00 (±00:00:01) but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task NotBeApproximately_Chain()
    {
        var chain = Noon.Should().NotBeApproximately(Evening, TimeSpan.FromSeconds(1));
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task BeExactly()
    {
        await Assert.That(() => Noon.Should().BeExactly(new DateTimeOffset(2026, 9, 30, 12, 0, 0, TimeSpan.Zero))).ThrowsNothing();
        await Assert.That(() => Noon.Should().BeExactly(NoonPlusOne)).Throws<AssertionException>()
            .WithMessage("Value should be exactly 2026-09-30T13:00:00+01:00 but was 2026-09-30T12:00:00+00:00.");
        await Assert.That(() => Noon.Should().BeExactly(Evening)).Throws<AssertionException>()
            .WithMessage("Value should be exactly 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task BeExactly_Chain()
    {
        var chain = Noon.Should().BeExactly(Noon);
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task NotBeExactly()
    {
        await Assert.That(() => Noon.Should().NotBeExactly(NoonPlusOne)).ThrowsNothing();
        await Assert.That(() => Noon.Should().NotBeExactly(Evening)).ThrowsNothing();
        await Assert.That(() => Noon.Should().NotBeExactly(Noon)).Throws<AssertionException>()
            .WithMessage("Value should not be exactly 2026-09-30T12:00:00+00:00.");
    }

    [Test]
    public async Task NotBeExactly_Chain()
    {
        var chain = Noon.Should().NotBeExactly(NoonPlusOne);
        await Assert.That(chain.Value).IsEqualTo(Noon);
        await Assert.That(chain.And.Value).IsEqualTo(Noon);
    }

    [Test]
    public async Task HaveOffset()
    {
        await Assert.That(() => NoonPlusOne.Should().HaveOffset(TimeSpan.FromHours(1))).ThrowsNothing();
        await Assert.That(() => Noon.Should().HaveOffset(TimeSpan.FromHours(1))).Throws<AssertionException>()
            .WithMessage("Value should have offset 01:00:00 but had offset 00:00:00.");
        await Assert.That(() => NoonPlusOne.Should().HaveOffset(TimeSpan.FromHours(-5.5))).Throws<AssertionException>()
            .WithMessage("Value should have offset -05:30:00 but had offset 01:00:00.");
    }

    [Test]
    public async Task HaveOffset_Chain()
    {
        var chain = NoonPlusOne.Should().HaveOffset(TimeSpan.FromHours(1));
        await Assert.That(chain.Value).IsEqualTo(NoonPlusOne);
        await Assert.That(chain.And.Value).IsEqualTo(NoonPlusOne);
    }
}