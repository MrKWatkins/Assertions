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
}