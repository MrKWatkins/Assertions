using TUnit.Assertions.AssertConditions.Throws;

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
        ReadOnlySpan<byte> value = [1, 2, 3];

        var chain = value.Should().NotBeEmpty();
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task NotBeEmpty_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];

        var and = value.Should().NotBeEmpty().And;
        await Assert.That(and.Value == value).IsTrue();
    }
    [Test]
    public async Task SequenceEqual()
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
    public async Task SequenceEqual_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];

        var chain = value.Should().SequenceEqual(sequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task SequenceEqual_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];

        var and = value.Should().SequenceEqual(sequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }

    [Test]
    public async Task SequenceEqual_IEnumerable()
    {
        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            var differentLength = CreateEnumerable(1);
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [] should sequence equal [1, ...] but it has less elements (0) than expected.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1];
            var differentLength = CreateEnumerable();
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [1] should sequence equal [] but it has 1 element rather than the expected 0.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            var differentLength = CreateEnumerable(1, 2, 3, 4);
            value.Should().SequenceEqual(differentLength);
        }).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should sequence equal [1, 2, ...] but it has less elements (3) than expected.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3, 4, 5];
            var differentElements = CreateEnumerable(1, 2, 3, 5, 5);
            value.Should().SequenceEqual(differentElements);
        }).Throws<AssertionException>().WithMessage("Value [1, 2, 3, *4*, 5] should sequence equal [1, 2, 3, *5*, ...] but it differs at index 3.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            var sequenceEqual = CreateEnumerable();
            value.Should().SequenceEqual(sequenceEqual);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            var sequenceEqual = CreateEnumerable(1, 2, 3);
            value.Should().SequenceEqual(sequenceEqual);
        }).ThrowsNothing();

        static IEnumerable<byte> CreateEnumerable(params byte[] values) => values.Select(b => b);
    }

    [Test]
    public async Task SequenceEqual_IReadOnlyCollection()
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
            ReadOnlySpan<byte> value = [1, 2, 3, 4, 5];
            IReadOnlyList<byte> differentElements = [1, 2, 3, 5, 5];
            value.Should().SequenceEqual(differentElements);
        }).Throws<AssertionException>().WithMessage("Value [1, 2, 3, *4*, 5] should sequence equal [1, 2, 3, *5*, ...] but it differs at index 3.");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [];
            IReadOnlyList<byte> sequenceEqual = [];
            value.Should().SequenceEqual(sequenceEqual);
        }).ThrowsNothing();

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> sequenceEqual = [1, 2, 3];
            value.Should().SequenceEqual(sequenceEqual);
        }).ThrowsNothing();
    }

    [Test]
    public async Task SequenceEqual_IEnumerable_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> sequenceEqual = [1, 2, 3];

        var chain = value.Should().SequenceEqual(sequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task SequenceEqual_IEnumerable_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> sequenceEqual = [1, 2, 3];

        var and = value.Should().SequenceEqual(sequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual()
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
            ReadOnlySpan<byte> value = [];
            ReadOnlySpan<byte> sequenceEqual = [];
            value.Should().NotSequenceEqual(sequenceEqual);
        }).Throws<AssertionException>().WithMessage("Value should not sequence equal [].");

        await Assert.That(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];
            value.Should().NotSequenceEqual(sequenceEqual);
        }).Throws<AssertionException>().WithMessage("Value should not sequence equal [1, 2, 3].");
    }

    [Test]
    public async Task NotSequenceEqual_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> notSequenceEqual = [1, 2];

        var chain = value.Should().NotSequenceEqual(notSequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> notSequenceEqual = [1, 2];

        var and = value.Should().NotSequenceEqual(notSequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual_IEnumerable()
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
    public async Task NotSequenceEqual_IEnumerable_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> notSequenceEqual = [1, 2];

        var chain = value.Should().NotSequenceEqual(notSequenceEqual);
        await Assert.That(chain.Value == value).IsTrue();
    }

    [Test]
    public async Task NotSequenceEqual_IEnumerable_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> notSequenceEqual = [1, 2];

        var and = value.Should().NotSequenceEqual(notSequenceEqual).And;
        await Assert.That(and.Value == value).IsTrue();
    }
}