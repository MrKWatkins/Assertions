namespace MrKWatkins.Assertions.Tests;

public sealed class SequenceEqualExtensionsTests
{
    [Test]
    public async Task SequenceEqual_ReadOnlySpan()
    {
        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            ReadOnlySpan<byte> differentLength = [1];
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [] should sequence equal [1] but it has 0 elements rather than the expected 1.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1];
            Span<byte> differentLength = [];
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [1] should sequence equal [] but it has 1 element rather than the expected 0.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> differentLength = [1, 2, 3, 4];
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should sequence equal [1, 2, 3, 4] but it has 3 elements rather than the expected 4.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            Span<byte> differentElements = [1, 3, 4];
            value.Should().SequenceEqual(differentElements);
        }).Throws<AssertionException>().WithMessage("Value [1, *2*, 3] should sequence equal [1, *3*, 4] but it differs at index 1.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];
            value.Should().SequenceEqual(sequenceEqual);
        }).ThrowsNothing();
    }

    [Test]
    public async Task SequenceEqual_ReadOnlySpan_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];

        var chain = value.Should().SequenceEqual(sequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task SequenceEqual_ReadOnlySpan_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];

        var and = value.Should().SequenceEqual(sequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }
}