using System.Collections;

namespace MrKWatkins.Assertions.Tests;

[SuppressMessage("ReSharper", "PossibleMultipleEnumeration")]
public sealed class CountExtensionsTests
{
    [Test]
    public void BeEmpty()
    {
        IEnumerable<byte> nullValue = null!;
        IEnumerable<byte> notEmptyValue = [1, 2, 3];
        IEnumerable<byte> emptyValue = [];

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().BeEmpty());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be empty but has 3 items."), () => notEmptyValue.Should().BeEmpty());
        Assert.DoesNotThrow(() => emptyValue.Should().BeEmpty());
    }

    [Test]
    public void BeEmpty_Chain()
    {
        IEnumerable<byte> emptyValue = [];

        var chain = emptyValue.Should().BeEmpty();
        Assert.That(chain.Value, Is.EqualTo(emptyValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(emptyValue));
    }

    [Test]
    public void NotBeEmpty()
    {
        IEnumerable<byte> nullValue = null!;
        IEnumerable<byte> notEmptyValue = [1, 2, 3];
        IEnumerable<byte> emptyValue = [];

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().NotBeEmpty());
        Assert.DoesNotThrow(() => notEmptyValue.Should().NotBeEmpty());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be empty."), () => emptyValue.Should().NotBeEmpty());
    }

    [Test]
    public void NotBeEmpty_Chain()
    {
        IEnumerable<byte> emptyValue = [1, 2, 3];

        var chain = emptyValue.Should().NotBeEmpty();
        Assert.That(chain.Value, Is.EqualTo(emptyValue));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(emptyValue));
    }

    [Test]
    public void HaveCount()
    {
        IEnumerable nullValue = null!;
        var enumerableValue = new Enumerable(5);
        var collectionValue = new Collection(5);
        var readOnlyCollectionValue = new ReadOnlyCollection(5);

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().HaveCount(5));

        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have a count of 3 but has a count of 5."),
            () => enumerableValue.Should().HaveCount(3)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have a count of 3 but has a count of 5."),
            () => collectionValue.Should().HaveCount(3)
        );
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should have a count of 3 but has a count of 5."),
            () => readOnlyCollectionValue.Should().HaveCount(3)
        );

        Assert.DoesNotThrow(() => enumerableValue.Should().HaveCount(5));
        Assert.DoesNotThrow(() => collectionValue.Should().HaveCount(5));
        Assert.DoesNotThrow(() => readOnlyCollectionValue.Should().HaveCount(5));
    }

    [Test]
    public void HaveCount_Chain()
    {
        IEnumerable<byte> value = [1, 2, 3];

        var chain = value.Should().HaveCount(3);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void NotHaveCount()
    {
        IEnumerable nullValue = null!;
        var enumerableValue = new Enumerable(5);
        var collectionValue = new Collection(5);
        var readOnlyCollectionValue = new ReadOnlyCollection(5);

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be null."), () => nullValue.Should().NotHaveCount(5));

        Assert.DoesNotThrow(() => enumerableValue.Should().NotHaveCount(3));
        Assert.DoesNotThrow(() => collectionValue.Should().NotHaveCount(3));
        Assert.DoesNotThrow(() => readOnlyCollectionValue.Should().NotHaveCount(3));

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have a count of 5."), () => enumerableValue.Should().NotHaveCount(5));
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have a count of 5."), () => collectionValue.Should().NotHaveCount(5));
        Assert.Throws(
            Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not have a count of 5."),
            () => readOnlyCollectionValue.Should().NotHaveCount(5)
        );
    }

    [Test]
    public void NotHaveCount_Chain()
    {
        IEnumerable<byte> value = [1, 2, 3];

        var chain = value.Should().NotHaveCount(5);
        Assert.That(chain.Value, Is.EqualTo(value));

        var and = chain.And;
        Assert.That(and.Value, Is.EqualTo(value));
    }

    [Test]
    public void BeEmpty_NonCollection()
    {
        var notEmptyEnumerable = System.Linq.Enumerable.Range(0, 3).Select(x => x);
        var emptyEnumerable = System.Linq.Enumerable.Range(0, 0).Select(x => x);

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be empty."), () => notEmptyEnumerable.Should().BeEmpty());
        Assert.DoesNotThrow(() => emptyEnumerable.Should().BeEmpty());
    }

    [Test]
    public void NotBeEmpty_NonCollection()
    {
        var notEmptyEnumerable = System.Linq.Enumerable.Range(0, 3).Select(x => x);
        var emptyEnumerable = System.Linq.Enumerable.Range(0, 0).Select(x => x);

        Assert.DoesNotThrow(() => notEmptyEnumerable.Should().NotBeEmpty());
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be empty."), () => emptyEnumerable.Should().NotBeEmpty());
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