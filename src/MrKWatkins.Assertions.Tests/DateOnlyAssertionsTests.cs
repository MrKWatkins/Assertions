namespace MrKWatkins.Assertions.Tests;

public sealed class DateOnlyAssertionsTests
{
    private static readonly DateOnly Monday = new(2026, 9, 28);
    private static readonly DateOnly Wednesday = new(2026, 9, 30);
    private static readonly DateOnly Friday = new(2026, 10, 2);

    [Test]
    public void Equal()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().Equal(new DateOnly(2026, 9, 30)));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 2026-10-02 but was 2026-09-30."),
            () => Wednesday.Should().Equal(Friday)
        );
    }

    [Test]
    public void NotEqual()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().NotEqual(Friday));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal 2026-09-30."), () => Wednesday.Should().NotEqual(Wednesday));
    }

    [Test]
    public void Comparisons()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().BeLessThan(Friday));
        Assert.DoesNotThrow(() => Wednesday.Should().BeLessThanOrEqualTo(Wednesday));
        Assert.DoesNotThrow(() => Wednesday.Should().BeGreaterThan(Monday));
        Assert.DoesNotThrow(() => Wednesday.Should().BeGreaterThanOrEqualTo(Wednesday));
        Assert.DoesNotThrow(() => Wednesday.Should().BeInRange(Monday, Friday));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be in the range 2026-09-30 to 2026-10-02 but was 2026-09-28."),
            () => Monday.Should().BeInRange(Wednesday, Friday)
        );
    }

    [Test]
    public void BeBefore()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().BeBefore(Friday));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be before 2026-09-30 but was 2026-09-30."),
            () => Wednesday.Should().BeBefore(Wednesday)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be before 2026-09-28 but was 2026-09-30."),
            () => Wednesday.Should().BeBefore(Monday)
        );
    }

    [Test]
    public void BeBefore_Chain()
    {
        var chain = Wednesday.Should().BeBefore(Friday);
        Assert.That(chain.Value, Is.EqualTo(Wednesday));
        Assert.That(chain.And.Value, Is.EqualTo(Wednesday));
    }

    [Test]
    public void BeOnOrBefore()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().BeOnOrBefore(Friday));
        Assert.DoesNotThrow(() => Wednesday.Should().BeOnOrBefore(Wednesday));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be on or before 2026-09-28 but was 2026-09-30."),
            () => Wednesday.Should().BeOnOrBefore(Monday)
        );
    }

    [Test]
    public void BeOnOrBefore_Chain()
    {
        var chain = Wednesday.Should().BeOnOrBefore(Wednesday);
        Assert.That(chain.Value, Is.EqualTo(Wednesday));
        Assert.That(chain.And.Value, Is.EqualTo(Wednesday));
    }

    [Test]
    public void BeAfter()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().BeAfter(Monday));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be after 2026-09-30 but was 2026-09-30."),
            () => Wednesday.Should().BeAfter(Wednesday)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be after 2026-10-02 but was 2026-09-30."),
            () => Wednesday.Should().BeAfter(Friday)
        );
    }

    [Test]
    public void BeAfter_Chain()
    {
        var chain = Wednesday.Should().BeAfter(Monday);
        Assert.That(chain.Value, Is.EqualTo(Wednesday));
        Assert.That(chain.And.Value, Is.EqualTo(Wednesday));
    }

    [Test]
    public void BeOnOrAfter()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().BeOnOrAfter(Monday));
        Assert.DoesNotThrow(() => Wednesday.Should().BeOnOrAfter(Wednesday));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be on or after 2026-10-02 but was 2026-09-30."),
            () => Wednesday.Should().BeOnOrAfter(Friday)
        );
    }

    [Test]
    public void BeOnOrAfter_Chain()
    {
        var chain = Wednesday.Should().BeOnOrAfter(Wednesday);
        Assert.That(chain.Value, Is.EqualTo(Wednesday));
        Assert.That(chain.And.Value, Is.EqualTo(Wednesday));
    }

    [Test]
    public void BeOnDayOfWeek()
    {
        Assert.DoesNotThrow(() => Wednesday.Should().BeOnDayOfWeek(DayOfWeek.Wednesday));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be on a Saturday but was 2026-09-30, a Wednesday."),
            () => Wednesday.Should().BeOnDayOfWeek(DayOfWeek.Saturday)
        );
    }

    [Test]
    public void BeOnDayOfWeek_Chain()
    {
        var chain = Wednesday.Should().BeOnDayOfWeek(DayOfWeek.Wednesday);
        Assert.That(chain.Value, Is.EqualTo(Wednesday));
        Assert.That(chain.And.Value, Is.EqualTo(Wednesday));
    }
}