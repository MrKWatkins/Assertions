namespace MrKWatkins.Assertions.Tests;

public sealed class ReadOnlySpanAssertionsTests
{
    [Test]
    public void BeEmpty()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should be empty but contained 3 elements."), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().BeEmpty();
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().BeEmpty();
        });
    }

    [Test]
    public void BeEmpty_Chain_Value()
    {
        ReadOnlySpan<byte> emptyValue = [];

        var chain = emptyValue.Should().BeEmpty();
        Assert.That(chain.Value == emptyValue, Is.True);
    }

    [Test]
    public void BeEmpty_Chain_And_Value()
    {
        ReadOnlySpan<byte> emptyValue = [];

        var and = emptyValue.Should().BeEmpty().And;
        Assert.That(and.Value == emptyValue, Is.True);
    }

    [Test]
    public void NotBeEmpty()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not be empty."), () =>
        {
            ReadOnlySpan<byte> value = [];
            value.Should().NotBeEmpty();
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            value.Should().NotBeEmpty();
        });
    }

    [Test]
    public void NotBeEmpty_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];

        var chain = value.Should().NotBeEmpty();
        Assert.That(chain.Value == value, Is.True);
    }

    [Test]
    public void NotBeEmpty_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];

        var and = value.Should().NotBeEmpty().And;
        Assert.That(and.Value == value, Is.True);
    }
    [Test]
    public void SequenceEqual()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [] should sequence equal [1] but it has 0 elements rather than the expected 1."
        ), () =>
        {
            ReadOnlySpan<byte> value = [];
            ReadOnlySpan<byte> differentLength = [1];
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1] should sequence equal [] but it has 1 element rather than the expected 0."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1];
            Span<byte> differentLength = [];
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1, 2, 3] should sequence equal [1, 2, 3, 4] but it has 3 elements rather than the expected 4."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> differentLength = [1, 2, 3, 4];
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value [1, *2*, 3] should sequence equal [1, *3*, 4] but it differs at index 1."), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            Span<byte> differentElements = [1, 3, 4];
            value.Should().SequenceEqual(differentElements);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];
            value.Should().SequenceEqual(sequenceEqual);
        });
    }

    [Test]
    public void SequenceEqual_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];

        var chain = value.Should().SequenceEqual(sequenceEqual);
        Assert.That(chain.Value == value, Is.True);
    }

    [Test]
    public void SequenceEqual_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];

        var and = value.Should().SequenceEqual(sequenceEqual).And;
        Assert.That(and.Value == value, Is.True);
    }

    [Test]
    public void SequenceEqual_Comparer()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> different = ["A", "B", "D"];
            value.Should().SequenceEqual(different, StringComparer.OrdinalIgnoreCase);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [\"a\", \"b\"] should sequence equal [\"A\", \"B\", \"C\"] but it has 2 elements rather than the expected 3."
        ), () =>
        {
            ReadOnlySpan<string> value = ["a", "b"];
            ReadOnlySpan<string> differentLength = ["A", "B", "C"];
            value.Should().SequenceEqual(differentLength, StringComparer.OrdinalIgnoreCase);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> same = ["A", "B", "C"];
            value.Should().SequenceEqual(same, StringComparer.OrdinalIgnoreCase);
        });
    }

    [Test]
    public void SequenceEqual_Predicate()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> different = ["A", "B", "D"];
            value.Should().SequenceEqual(different, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [\"a\", \"b\"] should sequence equal [\"A\", \"B\", \"C\"] but it has 2 elements rather than the expected 3."
        ), () =>
        {
            ReadOnlySpan<string> value = ["a", "b"];
            ReadOnlySpan<string> differentLength = ["A", "B", "C"];
            value.Should().SequenceEqual(differentLength, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> same = ["A", "B", "C"];
            value.Should().SequenceEqual(same, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });
    }

    [Test]
    public void SequenceEqual_IEnumerable()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [] should sequence equal [1, ...] but it has fewer elements (0) than expected."
        ), () =>
        {
            ReadOnlySpan<byte> value = [];
            var differentLength = CreateEnumerable(1);
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1] should sequence equal [] but it has 1 element rather than the expected 0."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1];
            var differentLength = CreateEnumerable();
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1, 2, 3] should sequence equal [1, 2, ...] but it has fewer elements (3) than expected."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            var differentLength = CreateEnumerable(1, 2, 3, 4);
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1, 2, 3, 4] should sequence equal [1, 2, ...] but it has more elements than the expected 3."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3, 4];
            var differentLength = CreateEnumerable(1, 2, 3);
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1, 2, 3, *4*, 5] should sequence equal [1, 2, 3, *5*, ...] but it differs at index 3."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3, 4, 5];
            var differentElements = CreateEnumerable(1, 2, 3, 5, 5);
            value.Should().SequenceEqual(differentElements);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            var sequenceEqual = CreateEnumerable();
            value.Should().SequenceEqual(sequenceEqual);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            var sequenceEqual = CreateEnumerable(1, 2, 3);
            value.Should().SequenceEqual(sequenceEqual);
        });

        static IEnumerable<byte> CreateEnumerable(params byte[] values) => values.Select(b => b);
    }

    [Test]
    public void SequenceEqual_IReadOnlyCollection()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [] should sequence equal [1] but it has 0 elements rather than the expected 1."
        ), () =>
        {
            ReadOnlySpan<byte> value = [];
            IReadOnlyList<byte> differentLength = [1];
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1] should sequence equal [] but it has 1 element rather than the expected 0."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1];
            IReadOnlyList<byte> differentLength = [];
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1, 2, 3] should sequence equal [1, 2, 3, 4] but it has 3 elements rather than the expected 4."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> differentLength = [1, 2, 3, 4];
            value.Should().SequenceEqual(differentLength);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo(
            "Value [1, 2, 3, *4*, 5] should sequence equal [1, 2, 3, *5*, ...] but it differs at index 3."
        ), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3, 4, 5];
            IReadOnlyList<byte> differentElements = [1, 2, 3, 5, 5];
            value.Should().SequenceEqual(differentElements);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            IReadOnlyList<byte> sequenceEqual = [];
            value.Should().SequenceEqual(sequenceEqual);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> sequenceEqual = [1, 2, 3];
            value.Should().SequenceEqual(sequenceEqual);
        });
    }

    [Test]
    public void SequenceEqual_IEnumerable_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> sequenceEqual = [1, 2, 3];

        var chain = value.Should().SequenceEqual(sequenceEqual);
        Assert.That(chain.Value == value, Is.True);
    }

    [Test]
    public void SequenceEqual_IEnumerable_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> sequenceEqual = [1, 2, 3];

        var and = value.Should().SequenceEqual(sequenceEqual).And;
        Assert.That(and.Value == value, Is.True);
    }

    [Test]
    public void SequenceEqual_IEnumerable_Comparer()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> different = ["A", "B", "D"];
            value.Should().SequenceEqual(different, StringComparer.OrdinalIgnoreCase);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> same = ["A", "B", "C"];
            value.Should().SequenceEqual(same, StringComparer.OrdinalIgnoreCase);
        });
    }

    [Test]
    public void SequenceEqual_IEnumerable_Predicate()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> different = ["A", "B", "D"];
            value.Should().SequenceEqual(different, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> same = ["A", "B", "C"];
            value.Should().SequenceEqual(same, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });
    }

    [Test]
    public void NotSequenceEqual()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            ReadOnlySpan<byte> differentLength = [1];
            value.Should().NotSequenceEqual(differentLength);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1];
            Span<byte> differentLength = [];
            value.Should().NotSequenceEqual(differentLength);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> differentLength = [1, 2, 3, 4];
            value.Should().NotSequenceEqual(differentLength);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            Span<byte> differentElements = [1, 3, 4];
            value.Should().NotSequenceEqual(differentElements);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not sequence equal []."), () =>
        {
            ReadOnlySpan<byte> value = [];
            ReadOnlySpan<byte> sequenceEqual = [];
            value.Should().NotSequenceEqual(sequenceEqual);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not sequence equal [1, 2, 3]."), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            ReadOnlySpan<byte> sequenceEqual = [1, 2, 3];
            value.Should().NotSequenceEqual(sequenceEqual);
        });
    }

    [Test]
    public void NotSequenceEqual_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> notSequenceEqual = [1, 2];

        var chain = value.Should().NotSequenceEqual(notSequenceEqual);
        Assert.That(chain.Value == value, Is.True);
    }

    [Test]
    public void NotSequenceEqual_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        ReadOnlySpan<byte> notSequenceEqual = [1, 2];

        var and = value.Should().NotSequenceEqual(notSequenceEqual).And;
        Assert.That(and.Value == value, Is.True);
    }

    [Test]
    public void NotSequenceEqual_Comparer()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> same = ["A", "B", "C"];
            value.Should().NotSequenceEqual(same, StringComparer.OrdinalIgnoreCase);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> different = ["A", "B", "D"];
            value.Should().NotSequenceEqual(different, StringComparer.OrdinalIgnoreCase);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b"];
            ReadOnlySpan<string> differentLength = ["A", "B", "C"];
            value.Should().NotSequenceEqual(differentLength, StringComparer.OrdinalIgnoreCase);
        });
    }

    [Test]
    public void NotSequenceEqual_Predicate()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> same = ["A", "B", "C"];
            value.Should().NotSequenceEqual(same, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            ReadOnlySpan<string> different = ["A", "B", "D"];
            value.Should().NotSequenceEqual(different, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b"];
            ReadOnlySpan<string> differentLength = ["A", "B", "C"];
            value.Should().NotSequenceEqual(differentLength, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });
    }

    [Test]
    public void NotSequenceEqual_IEnumerable()
    {
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            IReadOnlyList<byte> differentLength = [1];
            value.Should().NotSequenceEqual(differentLength);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1];
            IReadOnlyList<byte> differentLength = [];
            value.Should().NotSequenceEqual(differentLength);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> differentLength = [1, 2, 3, 4];
            value.Should().NotSequenceEqual(differentLength);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> differentElements = [1, 3, 4];
            value.Should().NotSequenceEqual(differentElements);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not sequence equal [1, 2, 3]."), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            IReadOnlyList<byte> sequenceEqual = [1, 2, 3];
            value.Should().NotSequenceEqual(sequenceEqual);
        });
    }

    [Test]
    public void NotSequenceEqual_IEnumerable_NonCollection()
    {
        // Test with lazy enumerables (no known count) to exercise the loop-based length checks
        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [];
            var moreElements = CreateEnumerable(1, 2, 3);
            value.Should().NotSequenceEqual(moreElements);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            var fewerElements = CreateEnumerable(1, 2);
            value.Should().NotSequenceEqual(fewerElements);
        });

        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>().And.Message.EqualTo("Value should not sequence equal [1, 2, ...]."), () =>
        {
            ReadOnlySpan<byte> value = [1, 2, 3];
            var sameElements = CreateEnumerable(1, 2, 3);
            value.Should().NotSequenceEqual(sameElements);
        });

        static IEnumerable<byte> CreateEnumerable(params byte[] values) => values.Select(b => b);
    }

    [Test]
    public void NotSequenceEqual_IEnumerable_Chain_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> notSequenceEqual = [1, 2];

        var chain = value.Should().NotSequenceEqual(notSequenceEqual);
        Assert.That(chain.Value == value, Is.True);
    }

    [Test]
    public void NotSequenceEqual_IEnumerable_Chain_And_Value()
    {
        ReadOnlySpan<byte> value = [1, 2, 3];
        IReadOnlyList<byte> notSequenceEqual = [1, 2];

        var and = value.Should().NotSequenceEqual(notSequenceEqual).And;
        Assert.That(and.Value == value, Is.True);
    }

    [Test]
    public void NotSequenceEqual_IEnumerable_Comparer()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> same = ["A", "B", "C"];
            value.Should().NotSequenceEqual(same, StringComparer.OrdinalIgnoreCase);
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> different = ["A", "B", "D"];
            value.Should().NotSequenceEqual(different, StringComparer.OrdinalIgnoreCase);
        });
    }

    [Test]
    public void NotSequenceEqual_IEnumerable_Predicate()
    {
        Assert.Throws(Is.TypeOf<NUnit.Framework.AssertionException>(), () =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> same = ["A", "B", "C"];
            value.Should().NotSequenceEqual(same, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });

        Assert.DoesNotThrow(() =>
        {
            ReadOnlySpan<string> value = ["a", "b", "c"];
            IReadOnlyList<string> different = ["A", "B", "D"];
            value.Should().NotSequenceEqual(different, (a, b) => string.Equals(a, b, StringComparison.OrdinalIgnoreCase));
        });
    }
}