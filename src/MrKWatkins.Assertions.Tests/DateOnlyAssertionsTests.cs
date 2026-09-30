namespace MrKWatkins.Assertions.Tests;

public sealed class DateOnlyAssertionsTests
{
    private static readonly DateOnly Monday = new(2026, 9, 28);
    private static readonly DateOnly Wednesday = new(2026, 9, 30);
    private static readonly DateOnly Friday = new(2026, 10, 2);

    [Test]
    public async Task Equal()
    {
        await Assert.That(() => Wednesday.Should().Equal(new DateOnly(2026, 9, 30))).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().Equal(Friday)).Throws<AssertionException>()
            .WithMessage("Value should equal 2026-10-02 but was 2026-09-30.");
    }

    [Test]
    public async Task NotEqual()
    {
        await Assert.That(() => Wednesday.Should().NotEqual(Friday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().NotEqual(Wednesday)).Throws<AssertionException>()
            .WithMessage("Value should not equal 2026-09-30.");
    }

    [Test]
    public async Task Comparisons()
    {
        await Assert.That(() => Wednesday.Should().BeLessThan(Friday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeLessThanOrEqualTo(Wednesday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeGreaterThan(Monday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeGreaterThanOrEqualTo(Wednesday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeInRange(Monday, Friday)).ThrowsNothing();
        await Assert.That(() => Monday.Should().BeInRange(Wednesday, Friday)).Throws<AssertionException>()
            .WithMessage("Value should be in the range 2026-09-30 to 2026-10-02 but was 2026-09-28.");
    }

    [Test]
    public async Task BeBefore()
    {
        await Assert.That(() => Wednesday.Should().BeBefore(Friday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeBefore(Wednesday)).Throws<AssertionException>()
            .WithMessage("Value should be before 2026-09-30 but was 2026-09-30.");
        await Assert.That(() => Wednesday.Should().BeBefore(Monday)).Throws<AssertionException>()
            .WithMessage("Value should be before 2026-09-28 but was 2026-09-30.");
    }

    [Test]
    public async Task BeBefore_Chain()
    {
        var chain = Wednesday.Should().BeBefore(Friday);
        await Assert.That(chain.Value).IsEqualTo(Wednesday);
        await Assert.That(chain.And.Value).IsEqualTo(Wednesday);
    }

    [Test]
    public async Task BeOnOrBefore()
    {
        await Assert.That(() => Wednesday.Should().BeOnOrBefore(Friday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeOnOrBefore(Wednesday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeOnOrBefore(Monday)).Throws<AssertionException>()
            .WithMessage("Value should be on or before 2026-09-28 but was 2026-09-30.");
    }

    [Test]
    public async Task BeOnOrBefore_Chain()
    {
        var chain = Wednesday.Should().BeOnOrBefore(Wednesday);
        await Assert.That(chain.Value).IsEqualTo(Wednesday);
        await Assert.That(chain.And.Value).IsEqualTo(Wednesday);
    }

    [Test]
    public async Task BeAfter()
    {
        await Assert.That(() => Wednesday.Should().BeAfter(Monday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeAfter(Wednesday)).Throws<AssertionException>()
            .WithMessage("Value should be after 2026-09-30 but was 2026-09-30.");
        await Assert.That(() => Wednesday.Should().BeAfter(Friday)).Throws<AssertionException>()
            .WithMessage("Value should be after 2026-10-02 but was 2026-09-30.");
    }

    [Test]
    public async Task BeAfter_Chain()
    {
        var chain = Wednesday.Should().BeAfter(Monday);
        await Assert.That(chain.Value).IsEqualTo(Wednesday);
        await Assert.That(chain.And.Value).IsEqualTo(Wednesday);
    }

    [Test]
    public async Task BeOnOrAfter()
    {
        await Assert.That(() => Wednesday.Should().BeOnOrAfter(Monday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeOnOrAfter(Wednesday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeOnOrAfter(Friday)).Throws<AssertionException>()
            .WithMessage("Value should be on or after 2026-10-02 but was 2026-09-30.");
    }

    [Test]
    public async Task BeOnOrAfter_Chain()
    {
        var chain = Wednesday.Should().BeOnOrAfter(Wednesday);
        await Assert.That(chain.Value).IsEqualTo(Wednesday);
        await Assert.That(chain.And.Value).IsEqualTo(Wednesday);
    }

    [Test]
    public async Task BeOnDayOfWeek()
    {
        await Assert.That(() => Wednesday.Should().BeOnDayOfWeek(DayOfWeek.Wednesday)).ThrowsNothing();
        await Assert.That(() => Wednesday.Should().BeOnDayOfWeek(DayOfWeek.Saturday)).Throws<AssertionException>()
            .WithMessage("Value should be on a Saturday but was 2026-09-30, a Wednesday.");
    }

    [Test]
    public async Task BeOnDayOfWeek_Chain()
    {
        var chain = Wednesday.Should().BeOnDayOfWeek(DayOfWeek.Wednesday);
        await Assert.That(chain.Value).IsEqualTo(Wednesday);
        await Assert.That(chain.And.Value).IsEqualTo(Wednesday);
    }
}