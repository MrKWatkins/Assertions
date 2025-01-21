using System.Collections;

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

    [Test]
    public async Task HaveCount()
    {
        IEnumerable nullValue = null!;
        var enumerableValue = new Enumerable(5);
        var collectionValue = new Collection(5);
        var readOnlyCollectionValue = new ReadOnlyCollection(5);

        await Assert.That(() => nullValue.Should().HaveCount(5)).Throws<AssertionException>().WithMessage("Value should not be null.");

        await Assert.That(() => enumerableValue.Should().HaveCount(3)).Throws<AssertionException>().WithMessage("Value should have a count of 3 but has a count of 5.");
        await Assert.That(() => collectionValue.Should().HaveCount(3)).Throws<AssertionException>().WithMessage("Value should have a count of 3 but has a count of 5.");
        await Assert.That(() => readOnlyCollectionValue.Should().HaveCount(3)).Throws<AssertionException>().WithMessage("Value should have a count of 3 but has a count of 5.");

        await Assert.That(() => enumerableValue.Should().HaveCount(5)).ThrowsNothing();
        await Assert.That(() => collectionValue.Should().HaveCount(5)).ThrowsNothing();
        await Assert.That(() => readOnlyCollectionValue.Should().HaveCount(5)).ThrowsNothing();
    }

    [Test]
    public async Task HaveCount_Chain()
    {
        IEnumerable<byte> value = [1, 2, 3];

        var chain = value.Should().HaveCount(3);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task NotHaveCount()
    {
        IEnumerable nullValue = null!;
        var enumerableValue = new Enumerable(5);
        var collectionValue = new Collection(5);
        var readOnlyCollectionValue = new ReadOnlyCollection(5);

        await Assert.That(() => nullValue.Should().NotHaveCount(5)).Throws<AssertionException>().WithMessage("Value should not be null.");

        await Assert.That(() => enumerableValue.Should().NotHaveCount(3)).ThrowsNothing();
        await Assert.That(() => collectionValue.Should().NotHaveCount(3)).ThrowsNothing();
        await Assert.That(() => readOnlyCollectionValue.Should().NotHaveCount(3)).ThrowsNothing();

        await Assert.That(() => enumerableValue.Should().NotHaveCount(5)).Throws<AssertionException>().WithMessage("Value should not have a count of 5.");
        await Assert.That(() => collectionValue.Should().NotHaveCount(5)).Throws<AssertionException>().WithMessage("Value should not have a count of 5.");
        await Assert.That(() => readOnlyCollectionValue.Should().NotHaveCount(5)).Throws<AssertionException>().WithMessage("Value should not have a count of 5.");
    }

    [Test]
    public async Task NotHaveCount_Chain()
    {
        IEnumerable<byte> value = [1, 2, 3];

        var chain = value.Should().NotHaveCount(5);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    private sealed class Enumerable(int count) : IEnumerable
    {
        public IEnumerator GetEnumerator() => System.Linq.Enumerable.Range(0, count).GetEnumerator();
    }

    private sealed class Collection(int count) : ICollection
    {
        public int Count { get; } = count;

        public IEnumerator GetEnumerator() => throw new NotSupportedException();
        public void CopyTo(Array array, int index) => throw new NotSupportedException();
        public bool IsSynchronized => throw new NotSupportedException();
        public object SyncRoot => throw new NotSupportedException();
    }

    private sealed class ReadOnlyCollection(int count) : IReadOnlyCollection<int>
    {
        public int Count { get; } = count;
        public IEnumerator<int> GetEnumerator() => throw new NotSupportedException();
        IEnumerator IEnumerable.GetEnumerator() => throw new NotSupportedException();
    }
}