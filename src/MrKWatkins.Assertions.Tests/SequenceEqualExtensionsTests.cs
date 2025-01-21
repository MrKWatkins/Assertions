namespace MrKWatkins.Assertions.Tests;

public sealed class SequenceEqualExtensionsTests
{
    [Test]
    public async Task SequenceEqual_IReadOnlyList()
    {
        IReadOnlyList<int> nullValue = null!;
        var value = new List<int> { 1, 2, 3 };
        var sequenceEqualValue = new List<int> { 1, 2, 3 };
        var sequenceDifferentValue = new List<int> { 1, 2, 4 };
        var shorterValue = new List<int> { 1, 2 };
        var longerValue = new List<int> { 1, 2, 3, 4 };

        await Assert.That(() => nullValue.Should().SequenceEqual(value)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => value.Should().SequenceEqual(shorterValue)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, 3] should sequence equal [1, 2] but it has 3 elements rather than the expected 2.");

        await Assert.That(() => value.Should().SequenceEqual(longerValue)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, 3] should sequence equal [1, 2, 3, 4] but it has 3 elements rather than the expected 4.");

        await Assert.That(() => value.Should().SequenceEqual(sequenceDifferentValue)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, *3*] should sequence equal [1, 2, *4*] but it differs at index 2.");

        await Assert.That(() => value.Should().SequenceEqual(sequenceEqualValue)).ThrowsNothing();
    }

    [Test]
    public async Task SequenceEqual_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(value);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotSequenceEqual_IReadOnlyList()
    {
        IReadOnlyList<int> nullValue = null!;
        var value = new List<int> { 1, 2, 3 };
        var sequenceDifferentValue = new List<int> { 1, 2, 4 };

        await Assert.That(() => nullValue.Should().NotSequenceEqual(value)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => value.Should().NotSequenceEqual(value)).Throws<AssertionException>()
            .WithMessage("Value should not sequence equal [1, 2, 3].");

        await Assert.That(() => value.Should().NotSequenceEqual(sequenceDifferentValue)).ThrowsNothing();
    }

    [Test]
    public async Task NotSequenceEqual_IReadOnlyList_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(value);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task SequenceEqual_IEnumerable()
    {
        IEnumerable<int> nullValue = null!;

        IEnumerable<int> valueWithCount = new List<int> { 1, 2, 3 };
        var valueWithoutCount = valueWithCount.Select(x => x);

        IEnumerable<int> sequenceEqualValueWithCount = new List<int> { 1, 2, 3 };
        var sequenceEqualValueWithoutCount = sequenceEqualValueWithCount.Select(x => x);

        IEnumerable<int> sequenceDifferentValueWithCount = new List<int> { 1, 2, 4 };
        var sequenceDifferentValueWithoutCount = sequenceDifferentValueWithCount.Select(x => x);

        IEnumerable<int> shorterWithCount = new List<int> { 1, 2 };
        var shorterWithoutCount = shorterWithCount.Select(x => x);

        IEnumerable<int> longerWithCount = new List<int> { 1, 2, 3, 4 };
        var longerWithoutCount = longerWithCount.Select(x => x);

        await Assert.That(() => nullValue.Should().SequenceEqual(valueWithCount)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => valueWithCount.Should().SequenceEqual(shorterWithCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has 3 elements rather than the expected 2.");

        await Assert.That(() => valueWithCount.Should().SequenceEqual(longerWithCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has 3 elements rather than the expected 4.");

        await Assert.That(() => valueWithCount.Should().SequenceEqual(sequenceDifferentValueWithCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.");

        await Assert.That(() => valueWithCount.Should().SequenceEqual(sequenceEqualValueWithCount)).ThrowsNothing();

        await Assert.That(() => valueWithoutCount.Should().SequenceEqual(shorterWithoutCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has more elements than the expected 2.");

        await Assert.That(() => valueWithoutCount.Should().SequenceEqual(longerWithoutCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has less elements (3) than expected.");

        await Assert.That(() => valueWithoutCount.Should().SequenceEqual(sequenceDifferentValueWithoutCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.");

        await Assert.That(() => valueWithoutCount.Should().SequenceEqual(sequenceEqualValueWithoutCount)).ThrowsNothing();
    }

    [Test]
    public async Task SequenceEqual_IEnumerable_Chain()
    {
        IEnumerable<int> value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(value);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotSequenceEqual_IEnumerable()
    {
        IEnumerable<int> nullValue = null!;
        IEnumerable<int> value = new List<int> { 1, 2, 3 };
        IEnumerable<int> sequenceEqualValue = new List<int> { 1, 2, 3 };

        IEnumerable<int> shorterValue = new List<int> { 1, 2 };

        await Assert.That(() => nullValue.Should().SequenceEqual(value)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");

        await Assert.That(() => value.Should().NotSequenceEqual(sequenceEqualValue)).Throws<AssertionException>()
            .WithMessage("Value should not sequence equal [1, 2, ...].");

        await Assert.That(() => value.Should().NotSequenceEqual(shorterValue)).ThrowsNothing();
    }

    [Test]
    public async Task NotSequenceEqual_IEnumerable_Chain()
    {
        IEnumerable<int> value = new List<int> { 1, 2, 3 };
        IEnumerable<int> otherValue = new List<int> { 1, 2 };

        var chain = value.Should().NotSequenceEqual(otherValue);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }
}