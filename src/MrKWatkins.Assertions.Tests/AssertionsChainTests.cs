using System.Collections;

namespace MrKWatkins.Assertions.Tests;

/// <summary>
/// Tests that assertions inherited from a base class return a chain for the derived assertions class, so more specific assertions can follow <c>.And</c>.
/// The explicitly typed locals check the static types at compile time.
/// </summary>
public sealed class AssertionsChainTests
{
    [Test]
    public async Task Object()
    {
        var value = new object();

        var and = value.Should().NotBeNull().And;
        await Assert.That(and.Value).IsSameReferenceAs(value);

        var chain = value.Should().Equal(value);
        await Assert.That(chain.That).IsSameReferenceAs(value);
    }

    [Test]
    public async Task Object_BeOfType()
    {
        object value = "Test";

        var and = value.Should().BeOfType<string>().And;
        await Assert.That(and.Value).IsEqualTo("Test");
    }

    [Test]
    public async Task Boolean()
    {
        var and = true.Should().Equal(true).And;
        await Assert.That(and.BeTrue).ThrowsNothing();
    }

    [Test]
    public async Task Integer()
    {
        var and = 5.Should().NotBeNull().And;
        await Assert.That(() => and.BePositive().And.Equal(5L).And.BeLessThan(10).And.BeInRange(0, 10).And.NotBeZero()).ThrowsNothing();

        var comparer = 5.Should().Equal(5, EqualityComparer<int>.Default).And;
        await Assert.That(comparer.Value).IsEqualTo(5);
    }

    [Test]
    public async Task Decimal()
    {
        var and = 5m.Should().Equal(5m).And;
        await Assert.That(() => and.BePositive().And.BeGreaterThan(1m).And.NotEqual(0m).And.BeInRange(0m, 10m)).ThrowsNothing();
    }

    [Test]
    public async Task FloatingPoint()
    {
        var and = 5.0.Should().Equal(5.0).And;
        await Assert.That(() => and.BePositive().And.BeLessThan(10.0).And.BeApproximately(5.0, 0.1).And.NotBeNaN()).ThrowsNothing();
    }

    [Test]
    public async Task TimeSpan()
    {
        var and = System.TimeSpan.FromSeconds(5).Should().Equal(System.TimeSpan.FromSeconds(5)).And;
        await Assert.That(() => and.BePositive().And.BeLessThan(System.TimeSpan.FromMinutes(1)).And.BeApproximately(System.TimeSpan.FromSeconds(5), System.TimeSpan.Zero))
            .ThrowsNothing();
    }

    [Test]
    public async Task DateTimeOffset()
    {
        var value = new DateTimeOffset(2026, 9, 30, 12, 0, 0, System.TimeSpan.Zero);

        var and = value.Should().Equal(value).And;
        await Assert.That(() => and.BeGreaterThan(value.AddDays(-1)).And.BeBefore(value.AddDays(1)).And.HaveOffset(System.TimeSpan.Zero)).ThrowsNothing();
    }

    [Test]
    public async Task DateOnly()
    {
        var value = new DateOnly(2026, 9, 30);

        var and = value.Should().Equal(value).And;
        await Assert.That(() => and.BeLessThan(value.AddDays(1)).And.BeAfter(value.AddDays(-1)).And.BeOnDayOfWeek(DayOfWeek.Wednesday)).ThrowsNothing();
    }

    [Test]
    public async Task String()
    {
        var and = "Hello".Should().NotBeNull().And;
        await Assert.That(() => and.StartWith("He").And.Contain('l').And.HaveCount(5).And.EndWith("lo").And.SequenceEqual('H', 'e', 'l', 'l', 'o').And.HaveLength(5))
            .ThrowsNothing();
    }

    [Test]
    public async Task Enumerable()
    {
        IEnumerable<int> value = [1, 2, 3];

        var and = value.Should().NotBeEmpty().And;
        await Assert.That(() => and.Contain(2).And.HaveCount(3).And.SequenceEqual(1, 2, 3)).ThrowsNothing();
    }

    [Test]
    public async Task NonGenericEnumerable()
    {
        IEnumerable value = new[] { 1, 2, 3 };

        var and = value.Should().SequenceEqual(1, 2, 3).And;
        await Assert.That(() => and.HaveCount(3)).ThrowsNothing();
    }

    [Test]
    public async Task Set()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var and = value.Should().Contain(1).And;
        await Assert.That(() => and.SetEquals(3, 2, 1).And.HaveCount(3).And.NotBeNull().And.IsSupersetOf(1)).ThrowsNothing();
    }

    [Test]
    public async Task Dictionary()
    {
        var value = new Dictionary<string, int> { ["One"] = 1 };

        var and = value.Should().NotBeNull().And;
        await Assert.That(() => and.ContainKey("One").And.HaveCount(1).And.NotContainKey("Two")).ThrowsNothing();
    }

    [Test]
    public async Task Exception()
    {
        // ReSharper disable once NotResolvedInText
        var value = new ArgumentException("Message", "param");

        var and = value.Should().NotBeNull().And;
        await Assert.That(() => and.HaveMessageStartingWith("Message").And.HaveParamName("param").And.NotHaveInnerException()).ThrowsNothing();
    }

    [Test]
    public async Task NullableBoolean()
    {
        bool? value = true;

        var and = value.Should().NotBeNull().And;
        await Assert.That(() => and.BeTrue().And.NotBeFalse()).ThrowsNothing();
    }
}