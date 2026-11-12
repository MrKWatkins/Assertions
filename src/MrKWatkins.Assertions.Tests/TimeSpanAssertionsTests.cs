namespace MrKWatkins.Assertions.Tests;

public sealed class TimeSpanAssertionsTests
{
    private static readonly TimeSpan One = TimeSpan.FromSeconds(1);
    private static readonly TimeSpan Five = TimeSpan.FromSeconds(5);
    private static readonly TimeSpan Ten = TimeSpan.FromSeconds(10);
    private static readonly TimeSpan MinusFive = TimeSpan.FromSeconds(-5);

    [Test]
    public void Equal()
    {
        Assert.DoesNotThrow(() => Five.Should().Equal(TimeSpan.FromMilliseconds(5000)));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should equal 00:00:10 but was 00:00:05."), () => Five.Should().Equal(Ten));
    }

    [Test]
    public void NotEqual()
    {
        Assert.DoesNotThrow(() => Five.Should().NotEqual(Ten));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not equal 00:00:05."),
            () => Five.Should().NotEqual(TimeSpan.FromMilliseconds(5000))
        );
    }

    [Test]
    public void BeZero()
    {
        Assert.DoesNotThrow(() => TimeSpan.Zero.Should().BeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be zero but was 00:00:05."), () => Five.Should().BeZero());
    }

    [Test]
    public void BeZero_Chain()
    {
        var chain = TimeSpan.Zero.Should().BeZero();
        Assert.That(chain.Value, Is.EqualTo(TimeSpan.Zero));
        Assert.That(chain.And.Value, Is.EqualTo(TimeSpan.Zero));
    }

    [Test]
    public void NotBeZero()
    {
        Assert.DoesNotThrow(() => Five.Should().NotBeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be zero."), () => TimeSpan.Zero.Should().NotBeZero());
    }

    [Test]
    public void NotBeZero_Chain()
    {
        var chain = Five.Should().NotBeZero();
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void BeNegative()
    {
        Assert.DoesNotThrow(() => MinusFive.Should().BeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was 00:00:05."), () => Five.Should().BeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was 00:00:00."), () => TimeSpan.Zero.Should().BeNegative());
    }

    [Test]
    public void BeNegative_Chain()
    {
        var chain = MinusFive.Should().BeNegative();
        Assert.That(chain.Value, Is.EqualTo(MinusFive));
        Assert.That(chain.And.Value, Is.EqualTo(MinusFive));
    }

    [Test]
    public void NotBeNegative()
    {
        Assert.DoesNotThrow(() => Five.Should().NotBeNegative());
        Assert.DoesNotThrow(() => TimeSpan.Zero.Should().NotBeNegative());
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be negative but was -00:00:05."),
            () => MinusFive.Should().NotBeNegative()
        );
    }

    [Test]
    public void NotBeNegative_Chain()
    {
        var chain = Five.Should().NotBeNegative();
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void BePositive()
    {
        Assert.DoesNotThrow(() => Five.Should().BePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was -00:00:05."), () => MinusFive.Should().BePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was 00:00:00."), () => TimeSpan.Zero.Should().BePositive());
    }

    [Test]
    public void BePositive_Chain()
    {
        var chain = Five.Should().BePositive();
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void NotBePositive()
    {
        Assert.DoesNotThrow(() => MinusFive.Should().NotBePositive());
        Assert.DoesNotThrow(() => TimeSpan.Zero.Should().NotBePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be positive but was 00:00:05."), () => Five.Should().NotBePositive());
    }

    [Test]
    public void NotBePositive_Chain()
    {
        var chain = MinusFive.Should().NotBePositive();
        Assert.That(chain.Value, Is.EqualTo(MinusFive));
        Assert.That(chain.And.Value, Is.EqualTo(MinusFive));
    }

    [Test]
    public void BeLessThan()
    {
        Assert.DoesNotThrow(() => Five.Should().BeLessThan(Ten));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 00:00:05 but was 00:00:05."),
            () => Five.Should().BeLessThan(Five)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 00:00:01 but was 00:00:05."),
            () => Five.Should().BeLessThan(One)
        );
    }

    [Test]
    public void BeLessThan_Chain()
    {
        var chain = Five.Should().BeLessThan(Ten);
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void BeLessThanOrEqualTo()
    {
        Assert.DoesNotThrow(() => Five.Should().BeLessThanOrEqualTo(Ten));
        Assert.DoesNotThrow(() => Five.Should().BeLessThanOrEqualTo(Five));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than or equal to 00:00:01 but was 00:00:05."),
            () => Five.Should().BeLessThanOrEqualTo(One)
        );
    }

    [Test]
    public void BeLessThanOrEqualTo_Chain()
    {
        var chain = Five.Should().BeLessThanOrEqualTo(Five);
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void BeGreaterThan()
    {
        Assert.DoesNotThrow(() => Five.Should().BeGreaterThan(One));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 00:00:05 but was 00:00:05."),
            () => Five.Should().BeGreaterThan(Five)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 00:00:10 but was 00:00:05."),
            () => Five.Should().BeGreaterThan(Ten)
        );
    }

    [Test]
    public void BeGreaterThan_Chain()
    {
        var chain = Five.Should().BeGreaterThan(One);
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void BeGreaterThanOrEqualTo()
    {
        Assert.DoesNotThrow(() => Five.Should().BeGreaterThanOrEqualTo(One));
        Assert.DoesNotThrow(() => Five.Should().BeGreaterThanOrEqualTo(Five));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than or equal to 00:00:10 but was 00:00:05."),
            () => Five.Should().BeGreaterThanOrEqualTo(Ten)
        );
    }

    [Test]
    public void BeGreaterThanOrEqualTo_Chain()
    {
        var chain = Five.Should().BeGreaterThanOrEqualTo(Five);
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void BeInRange()
    {
        Assert.DoesNotThrow(() => Five.Should().BeInRange(One, Ten));
        Assert.DoesNotThrow(() => Five.Should().BeInRange(Five, Ten));
        Assert.DoesNotThrow(() => Five.Should().BeInRange(One, Five));
        Assert.DoesNotThrow(() => Five.Should().BeInRange(Five, Five));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be in the range 00:00:05 to 00:00:10 but was 00:00:01."),
            () => One.Should().BeInRange(Five, Ten)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be in the range 00:00:01 to 00:00:05 but was 00:00:10."),
            () => Ten.Should().BeInRange(One, Five)
        );
    }

    [Test]
    public void BeInRange_Chain()
    {
        var chain = Five.Should().BeInRange(One, Ten);
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void BeApproximately()
    {
        var precision = TimeSpan.FromMilliseconds(100);

        Assert.DoesNotThrow(() => Five.Should().BeApproximately(Five, precision));
        Assert.DoesNotThrow(() => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(4900), precision));
        Assert.DoesNotThrow(() => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(5100), precision));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be approximately 00:00:04.8990000 (±00:00:00.1000000) but was 00:00:05."),
            () => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(4899), precision)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be approximately 00:00:05.1010000 (±00:00:00.1000000) but was 00:00:05."),
            () => Five.Should().BeApproximately(TimeSpan.FromMilliseconds(5101), precision)
        );
    }

    [Test]
    public void BeApproximately_ExtremeValues()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => TimeSpan.MinValue.Should().BeApproximately(TimeSpan.MaxValue, One));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => TimeSpan.MaxValue.Should().BeApproximately(TimeSpan.MinValue, One));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => TimeSpan.MinValue.Should().BeApproximately(TimeSpan.MaxValue, TimeSpan.MaxValue));
        Assert.DoesNotThrow(() => TimeSpan.MaxValue.Should().BeApproximately(TimeSpan.Zero, TimeSpan.MaxValue));
    }

    [Test]
    public void BeApproximately_Chain()
    {
        var chain = Five.Should().BeApproximately(Five, One);
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }

    [Test]
    public void NotBeApproximately()
    {
        var precision = TimeSpan.FromMilliseconds(100);

        Assert.DoesNotThrow(() => Five.Should().NotBeApproximately(TimeSpan.FromMilliseconds(4899), precision));
        Assert.DoesNotThrow(() => Five.Should().NotBeApproximately(TimeSpan.FromMilliseconds(5101), precision));
        Assert.DoesNotThrow(() => TimeSpan.MinValue.Should().NotBeApproximately(TimeSpan.MaxValue, One));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be approximately 00:00:05.1000000 (±00:00:00.1000000) but was 00:00:05."),
            () => Five.Should().NotBeApproximately(TimeSpan.FromMilliseconds(5100), precision)
        );
    }

    [Test]
    public void NotBeApproximately_Chain()
    {
        var chain = Five.Should().NotBeApproximately(Ten, One);
        Assert.That(chain.Value, Is.EqualTo(Five));
        Assert.That(chain.And.Value, Is.EqualTo(Five));
    }
}