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

    [Test]
    public async Task SequenceEqual_IReadOnlyList()
    {
        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            IReadOnlyList<byte> differentLength = [1];
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [] should sequence equal [1] but it has 0 elements rather than the expected 1.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1];
            IReadOnlyList<byte> differentLength = [];
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [1] should sequence equal [] but it has 1 element rather than the expected 0.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> differentLength = [1, 2, 3, 4];
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should sequence equal [1, 2, 3, 4] but it has 3 elements rather than the expected 4.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> differentElements = [1, 3, 4];
            value.Should().SequenceEqual(differentElements);
        }).Throws<AssertionException>().WithMessage("Value [1, *2*, 3] should sequence equal [1, *3*, 4] but it differs at index 1.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> sequenceEqual = [1, 2, 3];
            value.Should().SequenceEqual(sequenceEqual);
        }).ThrowsNothing();
    }

    [Test]
    public async Task SequenceEqual_IReadOnlyList_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> sequenceEqual = [1, 2, 3];

        var chain = value.Should().SequenceEqual(sequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task SequenceEqual_IReadOnlyList_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> sequenceEqual = [1, 2, 3];

        var and = value.Should().SequenceEqual(sequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual_ReadOnlySpan()
    {
        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            ReadOnlySpan<byte> differentLength = [1];
            value.Should().NotSequenceEqual(differentLength);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1];
            Span<byte> differentLength = [];
            value.Should().NotSequenceEqual(differentLength);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> differentLength = [1, 2, 3, 4];
            value.Should().NotSequenceEqual(differentLength);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            Span<byte> differentElements = [1, 3, 4];
            value.Should().NotSequenceEqual(differentElements);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];
            value.Should().NotSequenceEqual(sequenceEqual);
        }).Throws<AssertionException>().WithMessage("Value should not sequence equal [1, 2, 3].");
    }

    [Test]
    public async Task NotSequenceEqual_ReadOnlySpan_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> notSequenceEqual = [1, 2];

        var chain = value.Should().NotSequenceEqual(notSequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual_ReadOnlySpan_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> notSequenceEqual = [1, 2];

        var and = value.Should().NotSequenceEqual(notSequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual_IReadOnlyList()
    {
        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            IReadOnlyList<byte> differentLength = [1];
            value.Should().NotSequenceEqual(differentLength);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1];
            IReadOnlyList<byte> differentLength = [];
            value.Should().NotSequenceEqual(differentLength);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> differentLength = [1, 2, 3, 4];
            value.Should().NotSequenceEqual(differentLength);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> differentElements = [1, 3, 4];
            value.Should().NotSequenceEqual(differentElements);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> sequenceEqual = [1, 2, 3];
            value.Should().NotSequenceEqual(sequenceEqual);
        }).Throws<AssertionException>().WithMessage("Value should not sequence equal [1, 2, 3].");
    }

    [Test]
    public async Task NotSequenceEqual_IReadOnlyList_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> notSequenceEqual = [1, 2];

        var chain = value.Should().NotSequenceEqual(notSequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual_IReadOnlyList_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> notSequenceEqual = [1, 2];

        var and = value.Should().NotSequenceEqual(notSequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }

    [Test]
    public async Task SequenceEqual_IEnumerable()
    {
        IEnumerable<int> valueWithCount = new List<int> { 1, 2, 3 };
        var valueWithoutCount = valueWithCount.Select(x => x);

        IEnumerable<int> anotherValueWithCount = new List<int> { 1, 2, 3 };
        var anotherValueWithoutCount = anotherValueWithCount.Select(x => x);

        IEnumerable<int> shorterWithCount = new List<int> { 1, 2 };
        var shorterWithoutCount = shorterWithCount.Select(x => x);

        IEnumerable<int> longerWithCount = new List<int> { 1, 2, 3, 4 };
        var longerWithoutCount = longerWithCount.Select(x => x);

        await Assert.That(() => valueWithCount.Should().SequenceEqual(shorterWithCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has 3 elements rather than the expected 2.");

        await Assert.That(() => valueWithCount.Should().SequenceEqual(longerWithCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has 3 elements rather than the expected 4.");

        await Assert.That(() => valueWithCount.Should().SequenceEqual(anotherValueWithCount)).ThrowsNothing();

        await Assert.That(() => valueWithoutCount.Should().SequenceEqual(shorterWithoutCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has more elements than the expected 2.");

        await Assert.That(() => valueWithoutCount.Should().SequenceEqual(longerWithoutCount)).Throws<AssertionException>()
            .WithMessage("Value [1, 2, ...] should sequence equal [1, 2, ...] but it has less elements (3) than expected.");

        await Assert.That(() => valueWithoutCount.Should().SequenceEqual(anotherValueWithoutCount)).ThrowsNothing();
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
        IEnumerable<int> value = new List<int> { 1, 2, 3 };
        IEnumerable<int> anotherValue = new List<int> { 1, 2, 3 };

        IEnumerable<int> shorterValue = new List<int> { 1, 2 };

        await Assert.That(() => value.Should().NotSequenceEqual(anotherValue)).Throws<AssertionException>()
            .WithMessage("Value should not sequence equal [1, 2, ...].");

        await Assert.That(() => value.Should().NotSequenceEqual(shorterValue)).ThrowsNothing();
    }
}