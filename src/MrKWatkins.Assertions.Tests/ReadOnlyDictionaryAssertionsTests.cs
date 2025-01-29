using TUnit.Assertions.AssertConditions.Throws;

namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlyDictionaryAssertionsTests
{
    [Test]
    public async Task ContainKey_IReadOnlyDictionary()
    {
        IReadOnlyDictionary<string, int> nullValue = null!;
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        await Assert.That(() => nullValue.Should().ContainKey("Test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().ContainKey("Other")).Throws<AssertionException>().WithMessage("Value should contain key \"Other\".");
        await Assert.That(() => value.Should().ContainKey("Test")).ThrowsNothing();
    }

    [Test]
    public async Task ContainKey_IReadOnlyDictionary_Chain()
    {
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().ContainKey("Test");
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotContainKey_IReadOnlyDictionary()
    {
        IReadOnlyDictionary<string, int> nullValue = null!;
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        await Assert.That(() => nullValue.Should().NotContainKey("Test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().NotContainKey("Other")).ThrowsNothing();
        await Assert.That(() => value.Should().NotContainKey("Test")).Throws<AssertionException>().WithMessage("Value should not contain key \"Test\".");
    }

    [Test]
    public async Task NotContainKey_IReadOnlyDictionary_Chain()
    {
        IReadOnlyDictionary<string, int> value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().NotContainKey("Other");
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task ContainKey_Dictionary()
    {
        Dictionary<string, int> nullValue = null!;
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        await Assert.That(() => nullValue.Should().ContainKey("Test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().ContainKey("Other")).Throws<AssertionException>().WithMessage("Value should contain key \"Other\".");
        await Assert.That(() => value.Should().ContainKey("Test")).ThrowsNothing();
    }

    [Test]
    public async Task ContainKey_Dictionary_Chain()
    {
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().ContainKey("Test");
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotContainKey_Dictionary()
    {
        Dictionary<string, int> nullValue = null!;
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        await Assert.That(() => nullValue.Should().NotContainKey("Test")).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().NotContainKey("Other")).ThrowsNothing();
        await Assert.That(() => value.Should().NotContainKey("Test")).Throws<AssertionException>().WithMessage("Value should not contain key \"Test\".");
    }

    [Test]
    public async Task NotContainKey_Dictionary_Chain()
    {
        var value = new Dictionary<string, int> { ["Test"] = 123 };

        var chain = value.Should().NotContainKey("Other");
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }
}