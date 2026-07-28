namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlySetAssertionsTests
{
    [Test]
    public async Task SetEquals_IReadOnlySet()
    {
        IReadOnlySet<int> nullValue = null!;
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };
        IReadOnlySet<int> empty = new HashSet<int>();

        await Assert.That(() => nullValue.Should().SetEquals(1, 2, 3)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().SetEquals(1, 2, 3, 4)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should set equal [1, 2, 3, 4] but it is missing [4].");
        await Assert.That(() => value.Should().SetEquals(1, 2)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should set equal [1, 2] but it has extra item [3].");
        await Assert.That(() => value.Should().SetEquals(1)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should set equal [1] but it has extra items [2, 3].");
        await Assert.That(() => value.Should().SetEquals(1, 2, 4)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should set equal [1, 2, 4] but it is missing [4] and has extra item [3].");
        await Assert.That(() => value.Should().SetEquals(4, 4)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should set equal [4, 4] but it is missing [4] and has extra items [1, 2, 3].");
        await Assert.That(() => value.Should().SetEquals(1, 2, 3)).ThrowsNothing();
        await Assert.That(() => value.Should().SetEquals(3, 2, 1)).ThrowsNothing();
        await Assert.That(() => value.Should().SetEquals(1, 2, 3, 3)).ThrowsNothing();
        await Assert.That(() => empty.Should().SetEquals()).ThrowsNothing();
    }

    [Test]
    public async Task SetEquals_IReadOnlySet_Chain()
    {
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().SetEquals(1, 2, 3);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task SetEquals_HashSet()
    {
        HashSet<int> nullValue = null!;
        var value = new HashSet<int> { 1, 2, 3 };

        await Assert.That(() => nullValue.Should().SetEquals(1, 2, 3)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().SetEquals(1, 2, 3, 4)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should set equal [1, 2, 3, 4] but it is missing [4].");
        await Assert.That(() => value.Should().SetEquals(1, 2)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should set equal [1, 2] but it has extra item [3].");
        await Assert.That(() => value.Should().SetEquals(1, 2, 3)).ThrowsNothing();
    }

    [Test]
    public async Task SetEquals_HashSet_Chain()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().SetEquals(1, 2, 3);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task IsSupersetOf_IReadOnlySet()
    {
        IReadOnlySet<int> nullValue = null!;
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        await Assert.That(() => nullValue.Should().IsSupersetOf(1, 2)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().IsSupersetOf(1, 4)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should be a superset of [1, 4] but it is missing [4].");
        await Assert.That(() => value.Should().IsSupersetOf(4, 5, 4)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should be a superset of [4, 5, 4] but it is missing [4, 5].");
        await Assert.That(() => value.Should().IsSupersetOf(1, 2)).ThrowsNothing();
        await Assert.That(() => value.Should().IsSupersetOf(1, 2, 3)).ThrowsNothing();
        await Assert.That(() => value.Should().IsSupersetOf()).ThrowsNothing();
    }

    [Test]
    public async Task IsSupersetOf_IReadOnlySet_Chain()
    {
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSupersetOf(1, 2);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task IsSupersetOf_HashSet()
    {
        HashSet<int> nullValue = null!;
        var value = new HashSet<int> { 1, 2, 3 };

        await Assert.That(() => nullValue.Should().IsSupersetOf(1, 2)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().IsSupersetOf(1, 4)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should be a superset of [1, 4] but it is missing [4].");
        await Assert.That(() => value.Should().IsSupersetOf(1, 2)).ThrowsNothing();
    }

    [Test]
    public async Task IsSupersetOf_HashSet_Chain()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSupersetOf(1, 2);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task IsSubsetOf_IReadOnlySet()
    {
        IReadOnlySet<int> nullValue = null!;
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };
        IReadOnlySet<int> empty = new HashSet<int>();

        await Assert.That(() => nullValue.Should().IsSubsetOf(1, 2, 3)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().IsSubsetOf(1, 2)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should be a subset of [1, 2] but it has extra item [3].");
        await Assert.That(() => value.Should().IsSubsetOf(1)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should be a subset of [1] but it has extra items [2, 3].");
        await Assert.That(() => value.Should().IsSubsetOf(1, 2, 3)).ThrowsNothing();
        await Assert.That(() => value.Should().IsSubsetOf(1, 2, 3, 4)).ThrowsNothing();
        await Assert.That(() => empty.Should().IsSubsetOf(1)).ThrowsNothing();
    }

    [Test]
    public async Task IsSubsetOf_IReadOnlySet_Chain()
    {
        IReadOnlySet<int> value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSubsetOf(1, 2, 3, 4);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }

    [Test]
    public async Task IsSubsetOf_HashSet()
    {
        HashSet<int> nullValue = null!;
        var value = new HashSet<int> { 1, 2, 3 };

        await Assert.That(() => nullValue.Should().IsSubsetOf(1, 2, 3)).Throws<AssertionException>().WithMessage("Value should not be null.");
        await Assert.That(() => value.Should().IsSubsetOf(1, 2)).Throws<AssertionException>().WithMessage("Value [1, 2, 3] should be a subset of [1, 2] but it has extra item [3].");
        await Assert.That(() => value.Should().IsSubsetOf(1, 2, 3)).ThrowsNothing();
    }

    [Test]
    public async Task IsSubsetOf_HashSet_Chain()
    {
        var value = new HashSet<int> { 1, 2, 3 };

        var chain = value.Should().IsSubsetOf(1, 2, 3, 4);
        await Assert.That(chain.Value).IsEqualTo(value);

        var and = chain.And;
        await Assert.That(and.Value).IsEqualTo(value);
    }
}
