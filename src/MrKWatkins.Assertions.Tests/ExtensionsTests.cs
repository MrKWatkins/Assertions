using System.Collections;

namespace MrKWatkins.Assertions.Tests;

public sealed class ExtensionsTests
{
    [Test]
    public async Task TryGetCount_IEnumerable()
    {
        IEnumerable enumerable = new Enumerable();

        await Assert.That(enumerable.TryGetCount(out _)).IsFalse();
    }

    [Test]
    public async Task TryGetCount_IEnumerable_IsICollection()
    {
        IEnumerable collection = new Collection(3);

        await Assert.That(collection.TryGetCount(out var count)).IsTrue();
        await Assert.That(count).IsEqualTo(3);
    }

    [Test]
    public async Task TryGetCount_IEnumerableOfT_IsICollectionOfT()
    {
        // ReSharper disable once CollectionNeverUpdated.Local
        ICollection<int> collection = new Collection<int>(3);

        await Assert.That(collection.TryGetCount(out var count)).IsTrue();
        await Assert.That(count).IsEqualTo(3);
    }

    [Test]
    public async Task TryGetCount_IEnumerableOfT_IsIReadOnlyCollection()
    {
        IReadOnlyCollection<int> collection = new ReadOnlyCollection<int>(3);

        await Assert.That(collection.TryGetCount(out var count)).IsTrue();
        await Assert.That(count).IsEqualTo(3);
    }

    [Test]
    public async Task TryGetCount_IEnumerableOfT()
    {
        var enumerable = new[] { 1, 2, 3 }.Select(i => i);

        await Assert.That(enumerable.TryGetCount(out _)).IsFalse();
    }

    // Custom collection types to ensure we are testing the right interface and not accidentally testing the wrong one by using a List<T> or similar.
    private sealed class Collection(int count) : ICollection
    {
        public int Count { get; } = count;

        public void CopyTo(Array array, int index) => throw new NotSupportedException();
        public bool IsSynchronized => throw new NotSupportedException();
        public object SyncRoot => throw new NotSupportedException();
        public bool IsReadOnly => throw new NotSupportedException();
        public IEnumerator GetEnumerator() => throw new NotSupportedException();
    }

    private sealed class Collection<T>(int count) : ICollection<T>
    {
        public int Count { get; } = count;

        public IEnumerator<T> GetEnumerator() => throw new NotSupportedException();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
        public void Add(T item) => throw new NotSupportedException();
        public void Clear() => throw new NotSupportedException();
        public bool Contains(T item) => throw new NotSupportedException();
        public void CopyTo(T[] array, int arrayIndex) => throw new NotSupportedException();
        public bool Remove(T item) => throw new NotSupportedException();
        public bool IsReadOnly => throw new NotSupportedException();
    }

    private sealed class ReadOnlyCollection<T>(int count) : IReadOnlyCollection<T>
    {
        public int Count { get; } = count;

        public IEnumerator<T> GetEnumerator() => throw new NotSupportedException();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }

    private sealed class Enumerable : IEnumerable
    {
        public IEnumerator GetEnumerator() => throw new NotSupportedException();
    }
}