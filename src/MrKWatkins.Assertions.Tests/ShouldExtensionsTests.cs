namespace MrKWatkins.Assertions.Tests;

public sealed class ShouldExtensionsTests
{
    [Test]
    public void Should_Span()
    {
        Assert.DoesNotThrow(() =>
        {
            Span<int> value = [1, 2, 3];
            value.Should().SequenceEqual(1, 2, 3);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            Span<int> value = [1, 2, 4];
            value.Should().SequenceEqual(1, 2, 3);
        });
    }

    [Test]
    public void Should_SByte()
    {
        sbyte value = -42;

        Assert.DoesNotThrow(() => value.Should().Equal((sbyte)-42));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().Equal((sbyte)0));
    }

    [Test]
    public void Should_UShort()
    {
        ushort value = 42;

        Assert.DoesNotThrow(() => value.Should().Equal((ushort)42));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().Equal((ushort)0));
    }

    [Test]
    public void Should_UInt()
    {
        uint value = 42;

        Assert.DoesNotThrow(() => value.Should().Equal(42u));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().Equal(0u));
    }

    [Test]
    public void Should_ULong()
    {
        ulong value = 42;

        Assert.DoesNotThrow(() => value.Should().Equal(42ul));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().Equal(0ul));
    }

    [Test]
    public void Should_NInt()
    {
        nint value = 42;

        Assert.DoesNotThrow(() => value.Should().Equal((nint)42));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().Equal((nint)0));
    }

    [Test]
    public void Should_NUInt()
    {
        nuint value = 42;

        Assert.DoesNotThrow(() => value.Should().Equal((nuint)42));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().Equal((nuint)0));
    }

    [Test]
    public void Should_Decimal()
    {
        var value = 42m;

        Assert.DoesNotThrow(() => value.Should().BeGreaterThan(0m));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().BeGreaterThan(100m));
    }

    [Test]
    public void Should_TimeSpan()
    {
        var value = TimeSpan.FromSeconds(42);

        Assert.DoesNotThrow(() => value.Should().BeGreaterThan(TimeSpan.Zero));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().BeGreaterThan(TimeSpan.FromMinutes(1)));
    }

    [Test]
    public void Should_DateTimeOffset()
    {
        var value = new DateTimeOffset(2026, 9, 30, 12, 0, 0, TimeSpan.Zero);

        Assert.DoesNotThrow(() => value.Should().BeAfter(value.AddDays(-1)));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().BeAfter(value.AddDays(1)));
    }

    [Test]
    public void Should_DateOnly()
    {
        var value = new DateOnly(2026, 9, 30);

        Assert.DoesNotThrow(() => value.Should().BeAfter(value.AddDays(-1)));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().BeAfter(value.AddDays(1)));
    }

    [Test]
    public void Should_Half()
    {
        var value = (Half)42;

        Assert.DoesNotThrow(() => value.Should().BeApproximately((Half)42, (Half)1));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () => value.Should().BeApproximately((Half)100, (Half)1));
    }
}