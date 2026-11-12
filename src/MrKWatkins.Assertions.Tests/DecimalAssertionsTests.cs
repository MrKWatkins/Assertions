namespace MrKWatkins.Assertions.Tests;

public sealed class DecimalAssertionsTests
{
    [Test]
    public void BeZero()
    {
        Assert.DoesNotThrow(() => 0m.Should().BeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be zero but was 5."), () => 5m.Should().BeZero());
    }

    [Test]
    public void BeZero_Chain()
    {
        var chain = 0m.Should().BeZero();
        Assert.That(chain.Value, Is.EqualTo(0m));
        Assert.That(chain.And.Value, Is.EqualTo(0m));
    }

    [Test]
    public void NotBeZero()
    {
        Assert.DoesNotThrow(() => 5m.Should().NotBeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be zero."), () => 0m.Should().NotBeZero());
    }

    [Test]
    public void NotBeZero_Chain()
    {
        var chain = 5m.Should().NotBeZero();
        Assert.That(chain.Value, Is.EqualTo(5m));
        Assert.That(chain.And.Value, Is.EqualTo(5m));
    }

    [Test]
    public void BeNegative()
    {
        Assert.DoesNotThrow(() => (-5m).Should().BeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was 5."), () => 5m.Should().BeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was 0."), () => 0m.Should().BeNegative());
    }

    [Test]
    public void BeNegative_Chain()
    {
        var chain = (-5m).Should().BeNegative();
        Assert.That(chain.Value, Is.EqualTo(-5m));
        Assert.That(chain.And.Value, Is.EqualTo(-5m));
    }

    [Test]
    public void NotBeNegative()
    {
        Assert.DoesNotThrow(() => 5m.Should().NotBeNegative());
        Assert.DoesNotThrow(() => 0m.Should().NotBeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be negative but was -5."), () => (-5m).Should().NotBeNegative());
    }

    [Test]
    public void NotBeNegative_Chain()
    {
        var chain = 5m.Should().NotBeNegative();
        Assert.That(chain.Value, Is.EqualTo(5m));
        Assert.That(chain.And.Value, Is.EqualTo(5m));
    }

    [Test]
    public void BePositive()
    {
        Assert.DoesNotThrow(() => 5m.Should().BePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was -5."), () => (-5m).Should().BePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was 0."), () => 0m.Should().BePositive());
    }

    [Test]
    public void BePositive_Chain()
    {
        var chain = 5m.Should().BePositive();
        Assert.That(chain.Value, Is.EqualTo(5m));
        Assert.That(chain.And.Value, Is.EqualTo(5m));
    }

    [Test]
    public void NotBePositive()
    {
        Assert.DoesNotThrow(() => (-5m).Should().NotBePositive());
        Assert.DoesNotThrow(() => 0m.Should().NotBePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be positive but was 5."), () => 5m.Should().NotBePositive());
    }

    [Test]
    public void NotBePositive_Chain()
    {
        var chain = (-5m).Should().NotBePositive();
        Assert.That(chain.Value, Is.EqualTo(-5m));
        Assert.That(chain.And.Value, Is.EqualTo(-5m));
    }

    [Test]
    public void BeLessThan()
    {
        Assert.DoesNotThrow(() => 5m.Should().BeLessThan(10m));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 5 but was 5."), () => 5m.Should().BeLessThan(5m));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 1 but was 5."), () => 5m.Should().BeLessThan(1m));
    }

    [Test]
    public void BeLessThan_Chain()
    {
        var chain = 5m.Should().BeLessThan(10m);
        Assert.That(chain.Value, Is.EqualTo(5m));
        Assert.That(chain.And.Value, Is.EqualTo(5m));
    }

    [Test]
    public void BeLessThanOrEqualTo()
    {
        Assert.DoesNotThrow(() => 5m.Should().BeLessThanOrEqualTo(10m));
        Assert.DoesNotThrow(() => 5m.Should().BeLessThanOrEqualTo(5m));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than or equal to 1 but was 5."),
            () => 5m.Should().BeLessThanOrEqualTo(1m)
        );
    }

    [Test]
    public void BeLessThanOrEqualTo_Chain()
    {
        var chain = 5m.Should().BeLessThanOrEqualTo(5m);
        Assert.That(chain.Value, Is.EqualTo(5m));
        Assert.That(chain.And.Value, Is.EqualTo(5m));
    }

    [Test]
    public void BeGreaterThan()
    {
        Assert.DoesNotThrow(() => 5m.Should().BeGreaterThan(1m));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 5 but was 5."), () => 5m.Should().BeGreaterThan(5m));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 10 but was 5."), () => 5m.Should().BeGreaterThan(10m));
    }

    [Test]
    public void BeGreaterThan_Chain()
    {
        var chain = 5m.Should().BeGreaterThan(1m);
        Assert.That(chain.Value, Is.EqualTo(5m));
        Assert.That(chain.And.Value, Is.EqualTo(5m));
    }

    [Test]
    public void BeGreaterThanOrEqualTo()
    {
        Assert.DoesNotThrow(() => 5m.Should().BeGreaterThanOrEqualTo(1m));
        Assert.DoesNotThrow(() => 5m.Should().BeGreaterThanOrEqualTo(5m));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than or equal to 10 but was 5."),
            () => 5m.Should().BeGreaterThanOrEqualTo(10m)
        );
    }

    [Test]
    public void BeGreaterThanOrEqualTo_Chain()
    {
        var chain = 5m.Should().BeGreaterThanOrEqualTo(5m);
        Assert.That(chain.Value, Is.EqualTo(5m));
        Assert.That(chain.And.Value, Is.EqualTo(5m));
    }
}