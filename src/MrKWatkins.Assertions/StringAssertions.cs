using System.Text.RegularExpressions;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for string values.
/// </summary>
/// <param name="value">The string value to assert on.</param>
public sealed class StringAssertions(string? value) : EnumerableAssertions<string, char>(value)
{
    /// <summary>
    /// Asserts that the string contains the specified substring.
    /// </summary>
    /// <param name="expected">The expected substring.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain Contain(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(Value.Contains(expected, comparison), $"Value should contain the string {expected}{FormatComparison(comparison):L}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string does not contain the specified substring.
    /// </summary>
    /// <param name="expected">The substring that should not be present.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotContain(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(!Value.Contains(expected, comparison), $"Value should not contain the string {expected}{FormatComparison(comparison):L}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string starts with the specified value.
    /// </summary>
    /// <param name="expected">The expected start of the string.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain StartWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(Value.StartsWith(expected, comparison), $"Value should start with {expected}{FormatComparison(comparison):L} but was {Value}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string does not start with the specified value.
    /// </summary>
    /// <param name="expected">The value the string should not start with.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotStartWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(!Value.StartsWith(expected, comparison), $"Value should not start with {expected}{FormatComparison(comparison):L}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string ends with the specified value.
    /// </summary>
    /// <param name="expected">The expected end of the string.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain EndWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(Value.EndsWith(expected, comparison), $"Value should end with {expected}{FormatComparison(comparison):L} but was {Value}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string does not end with the specified value.
    /// </summary>
    /// <param name="expected">The value the string should not end with.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotEndWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(!Value.EndsWith(expected, comparison), $"Value should not end with {expected}{FormatComparison(comparison):L}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string is empty.
    /// </summary>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain BeEmpty()
    {
        NotBeNull();
        Verify.That(Value.Length == 0, $"Value should be empty but was {Value}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string is not empty.
    /// </summary>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotBeEmpty()
    {
        NotBeNull();
        Verify.That(Value.Length > 0, "Value should not be empty.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string is <see langword="null" /> or empty.
    /// </summary>
    public void BeNullOrEmpty()
    {
        Verify.That(string.IsNullOrEmpty(Value), $"Value should be null or empty but was {Value}.");
    }

    /// <summary>
    /// Asserts that the string is not <see langword="null" /> or empty.
    /// </summary>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotBeNullOrEmpty()
    {
        Verify.That(!string.IsNullOrEmpty(Value), "Value should not be null or empty.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string is <see langword="null" />, empty, or consists only of white-space characters.
    /// </summary>
    public void BeNullOrWhiteSpace()
    {
        Verify.That(string.IsNullOrWhiteSpace(Value), $"Value should be null or white space but was {Value}.");
    }

    /// <summary>
    /// Asserts that the string is not <see langword="null" />, empty, or consisting only of white-space characters.
    /// </summary>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotBeNullOrWhiteSpace()
    {
        Verify.That(!string.IsNullOrWhiteSpace(Value), "Value should not be null or white space.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string has the specified length.
    /// </summary>
    /// <param name="expected">The expected length.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain HaveLength(int expected)
    {
        NotBeNull();
        Verify.That(Value.Length == expected, $"Value should have length {expected} but was {Value.Length}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string does not have the specified length.
    /// </summary>
    /// <param name="expected">The length the string should not have.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotHaveLength(int expected)
    {
        NotBeNull();
        Verify.That(Value.Length != expected, $"Value should not have length {expected}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string matches the specified regular expression pattern.
    /// </summary>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain Match(string pattern)
    {
        NotBeNull();
        Verify.That(Regex.IsMatch(Value, pattern), $"Value should match the pattern {pattern} but was {Value}.");

        return new StringAssertionsChain(this);
    }

    /// <summary>
    /// Asserts that the string does not match the specified regular expression pattern.
    /// </summary>
    /// <param name="pattern">The regular expression pattern the string should not match.</param>
    /// <returns>A <see cref="StringAssertionsChain" /> for chaining further assertions.</returns>
    public StringAssertionsChain NotMatch(string pattern)
    {
        NotBeNull();
        Verify.That(!Regex.IsMatch(Value, pattern), $"Value should not match the pattern {pattern}.");

        return new StringAssertionsChain(this);
    }

    [Pure]
    private static string FormatComparison(StringComparison comparison) =>
        comparison == StringComparison.Ordinal ? "" : $" (using {comparison})";
}