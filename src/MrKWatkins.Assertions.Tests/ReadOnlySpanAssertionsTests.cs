namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlySpanAssertionsTests
{
    [Test]
    public async Task BeEmpty()
    {
        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().BeEmpty();
        }).Throws<AssertionException>().WithMessage("Value should be empty but contained 3 elements.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().BeEmpty();
        }).ThrowsNothing();
    }

    [Test]
    public async Task BeEmpty_Chain_Value()
    {
        ReadOnlySpan<byte> emptyValue = [];

        var chain = emptyValue.Should().BeEmpty();
        await Assert.That(chain.Value == emptyValue).IsTrue();
    }

    [Test]
    public async Task BeEmpty_Chain_And_Value()
    {
        ReadOnlySpan<byte> emptyValue = [];

        var and = emptyValue.Should().BeEmpty().And;
        await Assert.That(and.Value == emptyValue).IsTrue();
    }

    [Test]
    public async Task NotBeEmpty()
    {
        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().NotBeEmpty();
        }).Throws<AssertionException>().WithMessage("Value should not be empty.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().NotBeEmpty();
        }).ThrowsNothing();
    }

    [Test]
    public async Task NotBeEmpty_Chain_Value()
    {
        ReadOnlySpan<byte> emptyValue = [1, 2, 3];

        var chain = emptyValue.Should().NotBeEmpty();
        await Assert.That(chain.Value == emptyValue).IsTrue();
    }

    [Test]
    public async Task NotBeEmpty_Chain_And_Value()
    {
        ReadOnlySpan<byte> emptyValue = [1, 2, 3];

        var and = emptyValue.Should().NotBeEmpty().And;
        await Assert.That(and.Value == emptyValue).IsTrue();
    }
}