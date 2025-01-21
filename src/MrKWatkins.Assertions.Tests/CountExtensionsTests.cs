namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public sealed class CountExtensionsTests
{
    [Test]
    public async Task BeEmpty()
    {
        IEnumerable<byte> nullValue = null!;
        IEnumerable<byte> notEmptyValue = [1, 2, 3];
        IEnumerable<byte> emptyValue = [];

        await Assert.That(() => nullValue.Should().BeEmpty()).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => notEmptyValue.Should().BeEmpty()).Throws<AssertionException>().WithMessage("Value should be empty but has 3 items.");
        await Assert.That(() => emptyValue.Should().BeEmpty()).ThrowsNothing();
    }

    [Test]
    public async Task BeEmpty_Chain()
    {
        IEnumerable<byte> emptyValue = [];

        var chain = emptyValue.Should().BeEmpty();
        await Assert.That(chain.Value).IsEqualTo(emptyValue);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(emptyValue);
    }

    [Test]
    public async Task NotBeEmpty()
    {
        IEnumerable<byte> nullValue = null!;
        IEnumerable<byte> notEmptyValue = [1, 2, 3];
        IEnumerable<byte> emptyValue = [];

        await Assert.That(() => nullValue.Should().NotBeEmpty()).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => notEmptyValue.Should().NotBeEmpty()).ThrowsNothing();
        await Assert.That(() => emptyValue.Should().NotBeEmpty()).Throws<AssertionException>().WithMessage("Value should not be empty.");
    }

    [Test]
    public async Task NotBeEmpty_Chain()
    {
        IEnumerable<byte> emptyValue = [1, 2, 3];

        var chain = emptyValue.Should().NotBeEmpty();
        await Assert.That(chain.Value).IsEqualTo(emptyValue);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(emptyValue);
    }
}