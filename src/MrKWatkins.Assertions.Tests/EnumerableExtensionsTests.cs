using System.Collections;

namespace MrKWatkins.Assertions.Tests;

public sealed class EnumerableExtensionsTests
{
    [Test]
    public async Task SequenceEqual_Null()
    {
        IEnumerable nullEnumerable = null!;

        await Assert.That(() => nullEnumerable.Should().SequenceEqual(1)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");
    }

    [Test]
    public async Task SequenceEqual()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        await Assert.That(() => value.Should().SequenceEqual(1, 2, 3)).ThrowsNothing();
        await Assert.That(() => value.Should().SequenceEqual(1, 2)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2] but it has more elements than the expected 2.");
    }

    [Test]
    public async Task SequenceEqual_Chain()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(1, 2, 3);
        // https://github.com/thomhurst/TUnit/issues/1718
        await Assert.That(ReferenceEquals(chain.Value, value)).IsEqualTo(true);
        await Assert.That(ReferenceEquals(chain.And.Value, value)).IsEqualTo(true);
    }

    [Test]
    public async Task NotSequenceEqual_Null()
    {
        IEnumerable nullEnumerable = null!;

        await Assert.That(() => nullEnumerable.Should().NotSequenceEqual(1)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");
    }

    [Test]
    public async Task NotSequenceEqual()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        await Assert.That(() => value.Should().NotSequenceEqual(1, 2)).ThrowsNothing();
        await Assert.That(() => value.Should().NotSequenceEqual(1, 2, 3)).Throws<AssertionException>()
            .WithMessage("Value should not sequence equal [1, 2, 3].");
    }

    [Test]
    public async Task NotSequenceEqual_Chain()
    {
        IEnumerable value = new List<int> { 1, 2, 3 };

        var chain = value.Should().NotSequenceEqual(1, 2);
        // https://github.com/thomhurst/TUnit/issues/1718
        await Assert.That(ReferenceEquals(chain.Value, value)).IsEqualTo(true);
        await Assert.That(ReferenceEquals(chain.And.Value, value)).IsEqualTo(true);
    }
}