using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

public sealed class EnumerableAssertionsTests
{
    [Test]
    public async Task OnlyContain_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        await Assert.That(() => nullEnumerable.Should().OnlyContain(x => x != 2)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");
    }

    [Test]
    public async Task OnlyContain()
    {
        var value = new List<int> { 1, 2, 3 };

        await Assert.That(() => value.Should().OnlyContain(x => x != 2)).Throws<AssertionException>()
            .WithMessage("Value should only contain items that satisfy the predicate x => x != 2 but the item 2 at index 1 does not.");

        await Assert.That(() => value.Should().OnlyContain(x => x < 5)).ThrowsNothing();
    }

    [Test]
    public async Task OnlyContain_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().OnlyContain(x => x < 5);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }

    [Test]
    public async Task SequenceEqual_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        await Assert.That(() => nullEnumerable.Should().SequenceEqual(1)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");
    }

    [Test]
    [Arguments(new int[0], true, new[] { 1, 2, 3 }, true, "Value [] should sequence equal [1, 2, 3] but it has 0 elements rather than the expected 3.")]
    [Arguments(new int[0], true, new[] { 1, 2, 3 }, false, "Value [] should sequence equal [1, 2, ...] but it has less elements (0) than expected.")]
    [Arguments(new int[0], false, new[] { 1, 2, 3 }, true, "Value [] should sequence equal [1, 2, 3] but it has 0 elements rather than the expected 3.")]
    [Arguments(new int[0], false, new[] { 1, 2, 3 }, false, "Value [] should sequence equal [1, 2, ...] but it has less elements (0) than expected.")]
    [Arguments(new[] { 1 }, true, new int[0], true, "Value [1] should sequence equal [] but it has 1 element rather than the expected 0.")]
    [Arguments(new[] { 1, 2, 3 }, true, new int[0], false, "Value [1, 2, 3] should sequence equal [] but it has 3 elements rather than the expected 0.")]
    [Arguments(new[] { 1, 2, 3 }, false, new int[0], true, "Value [1, 2, ...] should sequence equal [] but it has more elements than the expected 0.")]
    [Arguments(new[] { 1, 2, 3 }, false, new int[0], false, "Value [1, 2, ...] should sequence equal [] but it has more elements than the expected 0.")]
    [Arguments(new[] { 1, 2, 3 }, true, new[] { 1, 2, 4 }, true, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    [Arguments(new[] { 1, 2, 3 }, false, new[] { 1, 2, 4 }, true, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    [Arguments(new[] { 1, 2, 3 }, true, new[] { 1, 2, 4 }, false, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    [Arguments(new[] { 1, 2, 3 }, false, new[] { 1, 2, 4 }, false, "Value [1, 2, *3*, ...] should sequence equal [1, 2, *4*, ...] but it differs at index 2.")]
    public async Task SequenceEqual_Throws(int[] actual, bool actualIsCollection, int[] expected, bool expectedIsCollection, string expectedMessage)
    {
        var actualEnumerable = actualIsCollection ? actual : actual.Select(x => x);
        var expectedEnumerable = expectedIsCollection ? expected : expected.Select(x => x);

        await Assert.That(() => actualEnumerable.Should().SequenceEqual(expectedEnumerable)).Throws<AssertionException>()
            .WithMessage(expectedMessage);
    }

    [Test]
    [Arguments(new int[0], true, new int[0], true)]
    [Arguments(new int[0], false, new int[0], true)]
    [Arguments(new int[0], true, new int[0], false)]
    [Arguments(new int[0], false, new int[0], false)]
    [Arguments(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, true)]
    [Arguments(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, true)]
    [Arguments(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, false)]
    [Arguments(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, false)]
    public async Task SequenceEqual(int[] actual, bool actualIsCollection, int[] expected, bool expectedIsCollection)
    {
        var actualEnumerable = actualIsCollection ? actual : actual.Select(x => x);
        var expectedEnumerable = expectedIsCollection ? expected : expected.Select(x => x);

        await Assert.That(() => actualEnumerable.Should().SequenceEqual(expectedEnumerable)).ThrowsNothing();
    }

    [Test]
    public async Task SequenceEqual_SubType()
    {
        var value = new List<object> { "A", "B", "C" };

        await Assert.That(() => value.Should().SequenceEqual("A", "B", "C")).ThrowsNothing();
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
    public async Task NotSequenceEqual_Null()
    {
        IEnumerable<int> nullEnumerable = null!;

        await Assert.That(() => nullEnumerable.Should().NotSequenceEqual(1)).Throws<AssertionException>()
            .WithMessage("Value should not be null.");
    }

    [Test]
    [Arguments(new int[0], true, new int[0], true, "Value should not sequence equal [].")]
    [Arguments(new int[0], false, new int[0], true, "Value should not sequence equal [].")]
    [Arguments(new int[0], true, new int[0], false, "Value should not sequence equal [].")]
    [Arguments(new int[0], false, new int[0], false, "Value should not sequence equal [].")]
    [Arguments(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, true, "Value should not sequence equal [1, 2, 3].")]
    [Arguments(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, true, "Value should not sequence equal [1, 2, 3].")]
    [Arguments(new[] { 1, 2, 3 }, true, new[] { 1, 2, 3 }, false, "Value should not sequence equal [1, 2, ...].")]
    [Arguments(new[] { 1, 2, 3 }, false, new[] { 1, 2, 3 }, false, "Value should not sequence equal [1, 2, ...].")]
    public async Task NotSequenceEqual_Throws(int[] actual, bool actualIsCollection, int[] expected, bool expectedIsCollection, string expectedMessage)
    {
        var actualEnumerable = actualIsCollection ? actual : actual.Select(x => x);
        var expectedEnumerable = expectedIsCollection ? expected : expected.Select(x => x);

        await Assert.That(() => actualEnumerable.Should().NotSequenceEqual(expectedEnumerable)).Throws<AssertionException>()
            .WithMessage(expectedMessage);
    }

    [Test]
    public async Task NotSequenceEqual_Chain()
    {
        var value = new List<int> { 1, 2, 3 };

        var chain = value.Should().SequenceEqual(value);
        await Assert.That(chain.Value).IsEqualTo(value);
        await Assert.That(chain.And.Value).IsEqualTo(value);
    }
}