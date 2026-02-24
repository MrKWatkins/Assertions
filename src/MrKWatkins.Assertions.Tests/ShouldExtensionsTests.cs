namespace MrKWatkins.Assertions.Tests;

public sealed class ShouldExtensionsTests
{
    [Test]
    public async Task Should_Span()
    {
        await Assert.That(() =>
        {
            Span<int> value = [1, 2, 3];
            value.Should().SequenceEqual(1, 2, 3);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            Span<int> value = [1, 2, 4];
            value.Should().SequenceEqual(1, 2, 3);
        }).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_SByte()
    {
        sbyte value = -42;

        await Assert.That(() => value.Should().Equal((sbyte)-42)).ThrowsNothing();
        await Assert.That(() => value.Should().Equal((sbyte)0)).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_UShort()
    {
        ushort value = 42;

        await Assert.That(() => value.Should().Equal((ushort)42)).ThrowsNothing();
        await Assert.That(() => value.Should().Equal((ushort)0)).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_UInt()
    {
        uint value = 42;

        await Assert.That(() => value.Should().Equal(42u)).ThrowsNothing();
        await Assert.That(() => value.Should().Equal(0u)).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_ULong()
    {
        ulong value = 42;

        await Assert.That(() => value.Should().Equal(42ul)).ThrowsNothing();
        await Assert.That(() => value.Should().Equal(0ul)).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_NInt()
    {
        nint value = 42;

        await Assert.That(() => value.Should().Equal((nint)42)).ThrowsNothing();
        await Assert.That(() => value.Should().Equal((nint)0)).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_NUInt()
    {
        nuint value = 42;

        await Assert.That(() => value.Should().Equal((nuint)42)).ThrowsNothing();
        await Assert.That(() => value.Should().Equal((nuint)0)).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_Decimal()
    {
        var value = 42m;

        await Assert.That(() => value.Should().BeGreaterThan(0m)).ThrowsNothing();
        await Assert.That(() => value.Should().BeGreaterThan(100m)).Throws<AssertionException>();
    }

    [Test]
    public async Task Should_Half()
    {
        var value = (Half)42;

        await Assert.That(() => value.Should().BeApproximately((Half)42, (Half)1)).ThrowsNothing();
        await Assert.That(() => value.Should().BeApproximately((Half)100, (Half)1)).Throws<AssertionException>();
    }
}