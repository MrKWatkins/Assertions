namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public sealed class EnumerableAssertionsTests
{
    [Test]
    public async Task BeNull()
    {
        IEnumerable<byte> notNullValue = [];
        IEnumerable<byte> nullValue = null!;

        await Assert.That(() => notNullValue.Should().BeNull()).Throws<AssertionException>().WithMessage("Value should be null but was System.Byte[].");
        await Assert.That(() => nullValue.Should().BeNull()).ThrowsNothing();
    }

    [Test]
    public async Task NotBeNull()
    {
        IEnumerable<byte> notNullValue = [];
        IEnumerable<byte> nullValue = null!;

        await Assert.That(() => notNullValue.Should().NotBeNull()).ThrowsNothing();
        await Assert.That(() => nullValue.Should().NotBeNull()).Throws<AssertionException>().WithMessage("Value should not be null.");
    }

    [Test]
    public async Task NotBeNull_Chain()
    {
        IEnumerable<byte> nullValue = [];

        var chain = nullValue.Should().NotBeNull();
        await Assert.That(chain.Value).IsEqualTo(nullValue);
        await Assert.That(chain.And.Value).IsEqualTo(nullValue);
    }

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