using System.Collections;

namespace MrKWatkins.Assertions.Tests;

public sealed class ExtensionsTests
{
    [Test]
    public async Task TryGetCount_ICollection()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        ICollection<int> collection = new Collection(3);

        await Assert.That(collection.TryGetCount(out var count)).IsTrue();
        await Assert.That(count).IsEqualTo(3);
    }

    [Test]
    public async Task TryGetCount_IReadOnlyCollection()
    {
        IReadOnlyCollection<int> collection = new ReadOnlyCollection(3);

        await Assert.That(collection.TryGetCount(out var count)).IsTrue();
        await Assert.That(count).IsEqualTo(3);
    }

    [Test]
    public async Task TryGetCount_Enumerable()
    {
        var enumerable = new[] { 1, 2, 3 }.Select(i => i);

        await Assert.That(enumerable.TryGetCount(out _)).IsFalse();
    }

    // Custom collection types to ensure we are testing the right interface and not accidentally testing the wrong one by using a List<T> or similar.
    private sealed class Collection(int count) : ICollection<int>
    {
        public IEnumerator<int> GetEnumerator() => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(int item) => throw new NotSupportedException();

        public void Clear() => throw new NotSupportedException();

        public bool Contains(int item) => throw new NotSupportedException();

        public void CopyTo(int[] array, int arrayIndex) => throw new NotSupportedException();

        public bool Remove(int item) => throw new NotSupportedException();

        public int Count { get; } = count;

        public bool IsReadOnly => throw new NotSupportedException();
    }

    private sealed class ReadOnlyCollection(int count) : IReadOnlyCollection<int>
    {
        public IEnumerator<int> GetEnumerator() => throw new NotSupportedException();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public int Count { get; } = count;
    }
}