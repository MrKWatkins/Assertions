namespace MrKWatkins.Assertions.Tests;

public sealed class FloatingPointAssertionsTests
{
    [Test]
    public void BeApproximately()
    {
        const double value = 17.5;

        Assert.DoesNotThrow(() => value.Should().BeApproximately(17.5, 0.1));
        Assert.DoesNotThrow(() => value.Should().BeApproximately(17.45, 0.1));
        Assert.DoesNotThrow(() => value.Should().BeApproximately(17.55, 0.1));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be approximately 17.6 (±0.1) but was 17.5."),
            () => value.Should().BeApproximately(17.6, 0.1)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be approximately 17.4 (±0.1) but was 17.5."),
            () => value.Should().BeApproximately(17.4, 0.1)
        );
    }

    [Test]
    public void BeApproximately_Float()
    {
        const float value = 17.5f;

        Assert.DoesNotThrow(() => value.Should().BeApproximately(17.5f, 0.1f));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().BeApproximately(17.6f, 0.05f));
    }

    [Test]
    public void BeApproximately_Half()
    {
        var value = (Half)17.5;

        Assert.DoesNotThrow(() => value.Should().BeApproximately((Half)17.5, (Half)0.1));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().BeApproximately((Half)17.6, (Half)0.05));
    }

    [Test]
    public void BeApproximately_Chain()
    {
        const double value = 17.5;

        var chain = value.Should().BeApproximately(17.5, 0.1);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeLessThan()
    {
        const double value = 5.0;

        Assert.DoesNotThrow(() => value.Should().BeLessThan(10.0, 0.001));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 5 (±0.001) but was 5."),
            () => value.Should().BeLessThan(5.0, 0.001)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 1 (±0.001) but was 5."),
            () => value.Should().BeLessThan(1.0, 0.001)
        );
    }

    [Test]
    public void BeLessThan_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeLessThan(10.0, 0.001);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeLessThanOrEqualTo()
    {
        const double value = 5.0;

        Assert.DoesNotThrow(() => value.Should().BeLessThanOrEqualTo(10.0, 0.001));
        Assert.DoesNotThrow(() => value.Should().BeLessThanOrEqualTo(5.0, 0.001));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than or equal to 1 (±0.001) but was 5."),
            () => value.Should().BeLessThanOrEqualTo(1.0, 0.001)
        );
    }

    [Test]
    public void BeLessThanOrEqualTo_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeLessThanOrEqualTo(5.0, 0.001);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeGreaterThan()
    {
        const double value = 5.0;

        Assert.DoesNotThrow(() => value.Should().BeGreaterThan(1.0, 0.001));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 5 (±0.001) but was 5."),
            () => value.Should().BeGreaterThan(5.0, 0.001)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 10 (±0.001) but was 5."),
            () => value.Should().BeGreaterThan(10.0, 0.001)
        );
    }

    [Test]
    public void BeGreaterThan_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeGreaterThan(1.0, 0.001);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeGreaterThanOrEqualTo()
    {
        const double value = 5.0;

        Assert.DoesNotThrow(() => value.Should().BeGreaterThanOrEqualTo(1.0, 0.001));
        Assert.DoesNotThrow(() => value.Should().BeGreaterThanOrEqualTo(5.0, 0.001));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than or equal to 10 (±0.001) but was 5."),
            () => value.Should().BeGreaterThanOrEqualTo(10.0, 0.001)
        );
    }

    [Test]
    public void BeGreaterThanOrEqualTo_Chain()
    {
        const double value = 5.0;

        var chain = value.Should().BeGreaterThanOrEqualTo(5.0, 0.001);
        Assert.That(chain.Value, Is.EqualTo(value));
        Assert.That(chain.And.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeZero()
    {
        Assert.DoesNotThrow(() => 0.0.Should().BeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be zero but was 5."), () => 5.0.Should().BeZero());
    }

    [Test]
    public void BeZero_Chain()
    {
        var chain = 0.0.Should().BeZero();
        Assert.That(chain.Value, Is.EqualTo(0.0));
        Assert.That(chain.And.Value, Is.EqualTo(0.0));
    }

    [Test]
    public void NotBeZero()
    {
        Assert.DoesNotThrow(() => 5.0.Should().NotBeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be zero."), () => 0.0.Should().NotBeZero());
    }

    [Test]
    public void NotBeZero_Chain()
    {
        var chain = 5.0.Should().NotBeZero();
        Assert.That(chain.Value, Is.EqualTo(5.0));
        Assert.That(chain.And.Value, Is.EqualTo(5.0));
    }

    [Test]
    public void BeNegative()
    {
        Assert.DoesNotThrow(() => (-5.0).Should().BeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was 5."), () => 5.0.Should().BeNegative());
    }

    [Test]
    public void BeNegative_Chain()
    {
        var chain = (-5.0).Should().BeNegative();
        Assert.That(chain.Value, Is.EqualTo(-5.0));
        Assert.That(chain.And.Value, Is.EqualTo(-5.0));
    }

    [Test]
    public void NotBeNegative()
    {
        Assert.DoesNotThrow(() => 5.0.Should().NotBeNegative());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be negative but was -5."), () => (-5.0).Should().NotBeNegative());
    }

    [Test]
    public void NotBeNegative_Chain()
    {
        var chain = 5.0.Should().NotBeNegative();
        Assert.That(chain.Value, Is.EqualTo(5.0));
        Assert.That(chain.And.Value, Is.EqualTo(5.0));
    }

    [Test]
    public void BePositive()
    {
        Assert.DoesNotThrow(() => 5.0.Should().BePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was -5."), () => (-5.0).Should().BePositive());
    }

    [Test]
    public void BePositive_Chain()
    {
        var chain = 5.0.Should().BePositive();
        Assert.That(chain.Value, Is.EqualTo(5.0));
        Assert.That(chain.And.Value, Is.EqualTo(5.0));
    }

    [Test]
    public void NotBePositive()
    {
        Assert.DoesNotThrow(() => (-5.0).Should().NotBePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be positive but was 5."), () => 5.0.Should().NotBePositive());
    }

    [Test]
    public void NotBePositive_Chain()
    {
        var chain = (-5.0).Should().NotBePositive();
        Assert.That(chain.Value, Is.EqualTo(-5.0));
        Assert.That(chain.And.Value, Is.EqualTo(-5.0));
    }

    [Test]
    public void BeNaN()
    {
        Assert.DoesNotThrow(() => double.NaN.Should().BeNaN());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be NaN but was 5."), () => 5.0.Should().BeNaN());
    }

    [Test]
    public void BeNaN_Chain()
    {
        var chain = double.NaN.Should().BeNaN();
        Assert.That(double.IsNaN(chain.Value), Is.True);
        Assert.That(double.IsNaN(chain.And.Value), Is.True);
    }

    [Test]
    public void NotBeNaN()
    {
        Assert.DoesNotThrow(() => 5.0.Should().NotBeNaN());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be NaN."), () => double.NaN.Should().NotBeNaN());
    }

    [Test]
    public void NotBeNaN_Chain()
    {
        var chain = 5.0.Should().NotBeNaN();
        Assert.That(chain.Value, Is.EqualTo(5.0));
        Assert.That(chain.And.Value, Is.EqualTo(5.0));
    }

    [Test]
    public void BeInfinity()
    {
        Assert.DoesNotThrow(() => double.PositiveInfinity.Should().BeInfinity());
        Assert.DoesNotThrow(() => double.NegativeInfinity.Should().BeInfinity());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be infinity but was 5."), () => 5.0.Should().BeInfinity());
    }

    [Test]
    public void BeInfinity_Chain()
    {
        var chain = double.PositiveInfinity.Should().BeInfinity();
        Assert.That(double.IsInfinity(chain.Value), Is.True);
        Assert.That(double.IsInfinity(chain.And.Value), Is.True);
    }

    [Test]
    public void NotBeInfinity()
    {
        Assert.DoesNotThrow(() => 5.0.Should().NotBeInfinity());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be infinity."), () => double.PositiveInfinity.Should().NotBeInfinity());
    }

    [Test]
    public void NotBeInfinity_Chain()
    {
        var chain = 5.0.Should().NotBeInfinity();
        Assert.That(chain.Value, Is.EqualTo(5.0));
        Assert.That(chain.And.Value, Is.EqualTo(5.0));
    }

    [Test]
    public void BePositiveInfinity()
    {
        Assert.DoesNotThrow(() => double.PositiveInfinity.Should().BePositiveInfinity());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive infinity but was 5."), () => 5.0.Should().BePositiveInfinity());
    }

    [Test]
    public void BePositiveInfinity_Chain()
    {
        var chain = double.PositiveInfinity.Should().BePositiveInfinity();
        Assert.That(double.IsPositiveInfinity(chain.Value), Is.True);
        Assert.That(double.IsPositiveInfinity(chain.And.Value), Is.True);
    }

    [Test]
    public void BeNegativeInfinity()
    {
        Assert.DoesNotThrow(() => double.NegativeInfinity.Should().BeNegativeInfinity());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative infinity but was 5."), () => 5.0.Should().BeNegativeInfinity());
    }

    [Test]
    public void BeNegativeInfinity_Chain()
    {
        var chain = double.NegativeInfinity.Should().BeNegativeInfinity();
        Assert.That(double.IsNegativeInfinity(chain.Value), Is.True);
        Assert.That(double.IsNegativeInfinity(chain.And.Value), Is.True);
    }

    [Test]
    public void ZeroAndSign_SignedZero()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was 0."), () => 0.0.Should().BePositive());
        Assert.DoesNotThrow(() => 0.0.Should().NotBePositive());
        Assert.DoesNotThrow(() => 0.0.Should().NotBeNegative());

        Assert.DoesNotThrow(() => (-0.0).Should().BeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was -0."), () => (-0.0).Should().BeNegative());
        Assert.DoesNotThrow(() => (-0.0).Should().NotBeNegative());
        Assert.DoesNotThrow(() => (-0.0).Should().NotBePositive());
    }

    [Test]
    public void ZeroAndSign_NaN()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be zero but was NaN."), () => double.NaN.Should().BeZero());
        Assert.DoesNotThrow(() => double.NaN.Should().NotBeZero());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be positive but was NaN."), () => double.NaN.Should().BePositive());
        Assert.DoesNotThrow(() => double.NaN.Should().NotBePositive());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be negative but was NaN."), () => double.NaN.Should().BeNegative());
        Assert.DoesNotThrow(() => double.NaN.Should().NotBeNegative());
    }

    [Test]
    public void ZeroAndSign_Infinity()
    {
        Assert.DoesNotThrow(() => double.PositiveInfinity.Should().BePositive());
        Assert.DoesNotThrow(() => double.NegativeInfinity.Should().BeNegative());
    }

    [Test]
    public void ExactComparisons()
    {
        Assert.DoesNotThrow(() => 5.0.Should().BeLessThan(10.0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 5 but was 5."), () => 5.0.Should().BeLessThan(5.0));
        Assert.DoesNotThrow(() => 5.0.Should().BeLessThanOrEqualTo(5.0));
        Assert.DoesNotThrow(() => 5.0.Should().BeGreaterThan(1.0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 5 but was 5."), () => 5.0.Should().BeGreaterThan(5.0));
        Assert.DoesNotThrow(() => 5.0.Should().BeGreaterThanOrEqualTo(5.0));
        Assert.DoesNotThrow(() => 5.0.Should().BeInRange(1.0, 10.0));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be in the range 6 to 10 but was 5."),
            () => 5.0.Should().BeInRange(6.0, 10.0)
        );
    }

    [Test]
    public void ExactComparisons_Half()
    {
        Assert.DoesNotThrow(() => ((Half)5).Should().BeLessThan((Half)10));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be greater than 10 but was 5."),
            () => ((Half)5).Should().BeGreaterThan((Half)10)
        );
    }

    [Test]
    public void ExactComparisons_NaN()
    {
        // NaN is unordered, so all comparisons fail, whichever side the NaN is on. (Comparer<double>.Default would sort NaN below all other values.)
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be less than 1 but was NaN."), () => double.NaN.Should().BeLessThan(1.0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => double.NaN.Should().BeLessThanOrEqualTo(1.0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => double.NaN.Should().BeGreaterThan(1.0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => double.NaN.Should().BeGreaterThanOrEqualTo(1.0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => double.NaN.Should().BeGreaterThanOrEqualTo(double.NaN));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => 1.0.Should().BeGreaterThan(double.NaN));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => 1.0.Should().BeLessThan(double.NaN));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => 1.0.Should().BeInRange(double.NaN, 2.0));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => double.NaN.Should().BeInRange(double.MinValue, double.MaxValue));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => float.NaN.Should().BeLessThan(1f));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => Half.NaN.Should().BeLessThan((Half)1));
    }
}