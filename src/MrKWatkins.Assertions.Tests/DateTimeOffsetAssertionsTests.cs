namespace MrKWatkins.Assertions.Tests;

public sealed class DateTimeOffsetAssertionsTests
{
    private static readonly DateTimeOffset Morning = new(2026, 9, 30, 9, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset Noon = new(2026, 9, 30, 12, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset Evening = new(2026, 9, 30, 18, 0, 0, TimeSpan.Zero);
    private static readonly DateTimeOffset NoonPlusOne = new(2026, 9, 30, 13, 0, 0, TimeSpan.FromHours(1));

    [Test]
    public void Equal()
    {
        Assert.DoesNotThrow(() => Noon.Should().Equal(Noon));
        Assert.DoesNotThrow(() => Noon.Should().Equal(NoonPlusOne));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().Equal(Evening)
        );
    }

    [Test]
    public void NotEqual()
    {
        Assert.DoesNotThrow(() => Noon.Should().NotEqual(Evening));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal 2026-09-30T13:00:00+01:00."),
            () => Noon.Should().NotEqual(NoonPlusOne)
        );
    }

    [Test]
    public void Comparisons()
    {
        Assert.DoesNotThrow(() => Noon.Should().BeLessThan(Evening));
        Assert.DoesNotThrow(() => Noon.Should().BeLessThanOrEqualTo(NoonPlusOne));
        Assert.DoesNotThrow(() => Noon.Should().BeGreaterThan(Morning));
        Assert.DoesNotThrow(() => Noon.Should().BeGreaterThanOrEqualTo(NoonPlusOne));
        Assert.DoesNotThrow(() => Noon.Should().BeInRange(Morning, Evening));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeGreaterThan(Evening)
        );
    }

    [Test]
    public void BeBefore()
    {
        Assert.DoesNotThrow(() => Noon.Should().BeBefore(Evening));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be before 2026-09-30T12:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeBefore(Noon)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be before 2026-09-30T13:00:00+01:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeBefore(NoonPlusOne)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be before 2026-09-30T09:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeBefore(Morning)
        );
    }

    [Test]
    public void BeBefore_Chain()
    {
        var chain = Noon.Should().BeBefore(Evening);
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void BeOnOrBefore()
    {
        Assert.DoesNotThrow(() => Noon.Should().BeOnOrBefore(Evening));
        Assert.DoesNotThrow(() => Noon.Should().BeOnOrBefore(Noon));
        Assert.DoesNotThrow(() => Noon.Should().BeOnOrBefore(NoonPlusOne));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be on or before 2026-09-30T09:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeOnOrBefore(Morning)
        );
    }

    [Test]
    public void BeOnOrBefore_Chain()
    {
        var chain = Noon.Should().BeOnOrBefore(Noon);
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void BeAfter()
    {
        Assert.DoesNotThrow(() => Noon.Should().BeAfter(Morning));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be after 2026-09-30T12:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeAfter(Noon)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be after 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeAfter(Evening)
        );
    }

    [Test]
    public void BeAfter_Chain()
    {
        var chain = Noon.Should().BeAfter(Morning);
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void BeOnOrAfter()
    {
        Assert.DoesNotThrow(() => Noon.Should().BeOnOrAfter(Morning));
        Assert.DoesNotThrow(() => Noon.Should().BeOnOrAfter(Noon));
        Assert.DoesNotThrow(() => Noon.Should().BeOnOrAfter(NoonPlusOne));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be on or after 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeOnOrAfter(Evening)
        );
    }

    [Test]
    public void BeOnOrAfter_Chain()
    {
        var chain = Noon.Should().BeOnOrAfter(Noon);
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void BeApproximately()
    {
        var precision = TimeSpan.FromSeconds(1);

        Assert.DoesNotThrow(() => Noon.Should().BeApproximately(Noon, precision));
        Assert.DoesNotThrow(() => Noon.Should().BeApproximately(NoonPlusOne, precision));
        Assert.DoesNotThrow(() => Noon.Should().BeApproximately(Noon.AddSeconds(1), precision));
        Assert.DoesNotThrow(() => Noon.Should().BeApproximately(Noon.AddSeconds(-1), precision));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should be approximately 2026-09-30T12:00:01.5+00:00 (±00:00:01) but was 2026-09-30T12:00:00+00:00."
            ),
            () => Noon.Should().BeApproximately(Noon.AddMilliseconds(1500), precision)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should be approximately 2026-09-30T11:59:58.5+00:00 (±00:00:01) but was 2026-09-30T12:00:00+00:00."
            ),
            () => Noon.Should().BeApproximately(Noon.AddMilliseconds(-1500), precision)
        );
    }

    [Test]
    public void BeApproximately_ExtremeValues()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => DateTimeOffset.MinValue.Should().BeApproximately(DateTimeOffset.MaxValue, TimeSpan.FromDays(1)));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => DateTimeOffset.MaxValue.Should().BeApproximately(DateTimeOffset.MinValue, TimeSpan.FromDays(1)));
        Assert.DoesNotThrow(() => DateTimeOffset.MinValue.Should().BeApproximately(DateTimeOffset.MaxValue, TimeSpan.MaxValue));
    }

    [Test]
    public void BeApproximately_Chain()
    {
        var chain = Noon.Should().BeApproximately(Noon, TimeSpan.FromSeconds(1));
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void NotBeApproximately()
    {
        var precision = TimeSpan.FromSeconds(1);

        Assert.DoesNotThrow(() => Noon.Should().NotBeApproximately(Evening, precision));
        Assert.DoesNotThrow(() => Noon.Should().NotBeApproximately(Noon.AddMilliseconds(1500), precision));
        Assert.DoesNotThrow(() => DateTimeOffset.MinValue.Should().NotBeApproximately(DateTimeOffset.MaxValue, precision));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
                "Value should not be approximately 2026-09-30T12:00:01+00:00 (±00:00:01) but was 2026-09-30T12:00:00+00:00."
            ),
            () => Noon.Should().NotBeApproximately(Noon.AddSeconds(1), precision)
        );
    }

    [Test]
    public void NotBeApproximately_Chain()
    {
        var chain = Noon.Should().NotBeApproximately(Evening, TimeSpan.FromSeconds(1));
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void BeExactly()
    {
        Assert.DoesNotThrow(() => Noon.Should().BeExactly(new DateTimeOffset(2026, 9, 30, 12, 0, 0, TimeSpan.Zero)));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be exactly 2026-09-30T13:00:00+01:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeExactly(NoonPlusOne)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be exactly 2026-09-30T18:00:00+00:00 but was 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().BeExactly(Evening)
        );
    }

    [Test]
    public void BeExactly_Chain()
    {
        var chain = Noon.Should().BeExactly(Noon);
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void NotBeExactly()
    {
        Assert.DoesNotThrow(() => Noon.Should().NotBeExactly(NoonPlusOne));
        Assert.DoesNotThrow(() => Noon.Should().NotBeExactly(Evening));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be exactly 2026-09-30T12:00:00+00:00."),
            () => Noon.Should().NotBeExactly(Noon)
        );
    }

    [Test]
    public void NotBeExactly_Chain()
    {
        var chain = Noon.Should().NotBeExactly(NoonPlusOne);
        Assert.That(chain.Value, Is.EqualTo(Noon));
        Assert.That(chain.And.Value, Is.EqualTo(Noon));
    }

    [Test]
    public void HaveOffset()
    {
        Assert.DoesNotThrow(() => NoonPlusOne.Should().HaveOffset(TimeSpan.FromHours(1)));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have offset 01:00:00 but had offset 00:00:00."),
            () => Noon.Should().HaveOffset(TimeSpan.FromHours(1))
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have offset -05:30:00 but had offset 01:00:00."),
            () => NoonPlusOne.Should().HaveOffset(TimeSpan.FromHours(-5.5))
        );
    }

    [Test]
    public void HaveOffset_Chain()
    {
        var chain = NoonPlusOne.Should().HaveOffset(TimeSpan.FromHours(1));
        Assert.That(chain.Value, Is.EqualTo(NoonPlusOne));
        Assert.That(chain.And.Value, Is.EqualTo(NoonPlusOne));
    }
}