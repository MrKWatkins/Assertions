using System.Collections;

namespace MrKWatkins.Assertions.Tests;

/// <summary>
/// Tests that assertions inherited from a base class return a chain for the derived assertions class, so more specific assertions can follow <c>.And</c>.
/// The explicitly typed locals check the static types at compile time.
/// </summary>
public sealed class AssertionsChainTests
{
    [Test]
    public void Object()
    {
        var value = new object();

        var and = value.Should().NotBeNull().And;
        Assert.That(and.Value, Is.SameAs(value));

        var chain = value.Should().Equal(value);
        Assert.That(chain.That, Is.SameAs(value));
    }

    [Test]
    public void Object_BeOfType()
    {
        object value = "Test";

        var and = value.Should().BeOfType<string>().And;
        Assert.That(and.Value, Is.EqualTo("Test"));
    }

    [Test]
    public void Boolean()
    {
        var and = true.Should().Equal(true).And;
        Assert.DoesNotThrow(() => and.BeTrue());
    }

    [Test]
    public void Integer()
    {
        var and = 5.Should().NotBeNull().And;
        Assert.DoesNotThrow(() => and.BePositive().And.Equal(5L).And.BeLessThan(10).And.BeInRange(0, 10).And.NotBeZero());

        var comparer = 5.Should().Equal(5, EqualityComparer<int>.Default).And;
        Assert.That(comparer.Value, Is.EqualTo(5));
    }

    [Test]
    public void Decimal()
    {
        var and = 5m.Should().Equal(5m).And;
        Assert.DoesNotThrow(() => and.BePositive().And.BeGreaterThan(1m).And.NotEqual(0m).And.BeInRange(0m, 10m));
    }

    [Test]
    public void FloatingPoint()
    {
        var and = 5.0.Should().Equal(5.0).And;
        Assert.DoesNotThrow(() => and.BePositive().And.BeLessThan(10.0).And.BeApproximately(5.0, 0.1).And.NotBeNaN());
    }

    [Test]
    public void TimeSpan()
    {
        var and = System.TimeSpan.FromSeconds(5).Should().Equal(System.TimeSpan.FromSeconds(5)).And;
        Assert.DoesNotThrow(() => and.BePositive().And.BeLessThan(System.TimeSpan.FromMinutes(1)).And.BeApproximately(System.TimeSpan.FromSeconds(5), System.TimeSpan.Zero));
    }

    [Test]
    public void DateTimeOffset()
    {
        var value = new DateTimeOffset(2026, 9, 30, 12, 0, 0, System.TimeSpan.Zero);

        var and = value.Should().Equal(value).And;
        Assert.DoesNotThrow(() => and.BeGreaterThan(value.AddDays(-1)).And.BeBefore(value.AddDays(1)).And.HaveOffset(System.TimeSpan.Zero));
    }

    [Test]
    public void DateOnly()
    {
        var value = new DateOnly(2026, 9, 30);

        var and = value.Should().Equal(value).And;
        Assert.DoesNotThrow(() => and.BeLessThan(value.AddDays(1)).And.BeAfter(value.AddDays(-1)).And.BeOnDayOfWeek(DayOfWeek.Wednesday));
    }

    [Test]
    public void String()
    {
        var and = "Hello".Should().NotBeNull().And;
        Assert.DoesNotThrow(() => and.StartWith("He").And.Contain('l').And.HaveCount(5).And.EndWith("lo").And.SequenceEqual('H', 'e', 'l', 'l', 'o').And.HaveLength(5));
    }

    [Test]
    public void Enumerable()
    {
        IEnumerable<int> value = [1, 2, 3];

        var and = value.Should().NotBeEmpty().And;
        Assert.DoesNotThrow(() => and.Contain(2).And.HaveCount(3).And.SequenceEqual(1, 2, 3));
    }

    [Test]
    public void NonGenericEnumerable()
    {
        IEnumerable value = new[] { 1, 2, 3 };

        var and = value.Should().SequenceEqual(1, 2, 3).And;
        Assert.DoesNotThrow(() => and.HaveCount(3));
    }

    [Test]
    public void Set()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var and = value.Should().Contain(1).And;
        Assert.DoesNotThrow(() => and.SetEquals(3, 2, 1).And.HaveCount(3).And.NotBeNull().And.IsSupersetOf(1));
    }

    [Test]
    public void Dictionary()
    {
        var value = new Dictionary<string, int> { ["One"] = 1 };

        var and = value.Should().NotBeNull().And;
        Assert.DoesNotThrow(() => and.ContainKey("One").And.HaveCount(1).And.NotContainKey("Two"));
    }

    [Test]
    public void Exception()
    {
        // ReSharper disable once NotResolvedInText
        var value = new ArgumentException("Message", "param");

        var and = value.Should().NotBeNull().And;
        Assert.DoesNotThrow(() => and.HaveMessageStartingWith("Message").And.HaveParamName("param").And.NotHaveInnerException());
    }

    [Test]
    public void NullableBoolean()
    {
        bool? value = true;

        var and = value.Should().NotBeNull().And;
        Assert.DoesNotThrow(() => and.BeTrue().And.NotBeFalse());
    }
}