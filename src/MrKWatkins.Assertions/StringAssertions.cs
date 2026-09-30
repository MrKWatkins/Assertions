using System.Text.RegularExpressions;

namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for string values.
/// </summary>
/// <param name="value">The string value to assert on.</param>
public sealed class StringAssertions(string? value) : EnumerableAssertions<StringAssertions, string, char>(value)
{
    /// <summary>
    /// Asserts that the string contains the specified substring.
    /// </summary>
    /// <param name="expected">The expected substring.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> Contain(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(Value.Contains(expected, comparison), $"Value should contain the string {expected}{FormatComparison(comparison):L}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string does not contain the specified substring.
    /// </summary>
    /// <param name="expected">The substring that should not be present.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotContain(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(!Value.Contains(expected, comparison), $"Value should not contain the string {expected}{FormatComparison(comparison):L}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string starts with the specified value.
    /// </summary>
    /// <param name="expected">The expected start of the string.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> StartWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(Value.StartsWith(expected, comparison), $"Value should start with {expected}{FormatComparison(comparison):L} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string does not start with the specified value.
    /// </summary>
    /// <param name="expected">The value the string should not start with.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotStartWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(!Value.StartsWith(expected, comparison), $"Value should not start with {expected}{FormatComparison(comparison):L}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string ends with the specified value.
    /// </summary>
    /// <param name="expected">The expected end of the string.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> EndWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(Value.EndsWith(expected, comparison), $"Value should end with {expected}{FormatComparison(comparison):L} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string does not end with the specified value.
    /// </summary>
    /// <param name="expected">The value the string should not end with.</param>
    /// <param name="comparison">The <see cref="StringComparison" /> to use. Defaults to <see cref="StringComparison.Ordinal" />.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotEndWith(string expected, StringComparison comparison = StringComparison.Ordinal)
    {
        NotBeNull();
        Verify.That(!Value.EndsWith(expected, comparison), $"Value should not end with {expected}{FormatComparison(comparison):L}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string is empty.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> BeEmpty()
    {
        NotBeNull();
        Verify.That(Value.Length == 0, $"Value should be empty but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string is not empty.
    /// </summary>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotBeEmpty()
    {
        NotBeNull();
        Verify.That(Value.Length > 0, "Value should not be empty.");

        return Chain();
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
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotBeNullOrEmpty()
    {
        Verify.That(!string.IsNullOrEmpty(Value), "Value should not be null or empty.");

        return Chain();
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
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotBeNullOrWhiteSpace()
    {
        Verify.That(!string.IsNullOrWhiteSpace(Value), "Value should not be null or white space.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string has the specified length.
    /// </summary>
    /// <param name="expected">The expected length.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> HaveLength(int expected)
    {
        NotBeNull();
        Verify.That(Value.Length == expected, $"Value should have length {expected} but was {Value.Length}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string does not have the specified length.
    /// </summary>
    /// <param name="expected">The length the string should not have.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotHaveLength(int expected)
    {
        NotBeNull();
        Verify.That(Value.Length != expected, $"Value should not have length {expected}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string matches the specified regular expression pattern.
    /// </summary>
    /// <param name="pattern">The regular expression pattern to match.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> Match(string pattern)
    {
        NotBeNull();
        Verify.That(Regex.IsMatch(Value, pattern), $"Value should match the pattern {pattern} but was {Value}.");

        return Chain();
    }

    /// <summary>
    /// Asserts that the string does not match the specified regular expression pattern.
    /// </summary>
    /// <param name="pattern">The regular expression pattern the string should not match.</param>
    /// <returns>An <see cref="AssertionsChain{TAssertions, T}" /> for chaining further assertions.</returns>
    public AssertionsChain<StringAssertions, string> NotMatch(string pattern)
    {
        NotBeNull();
        Verify.That(!Regex.IsMatch(Value, pattern), $"Value should not match the pattern {pattern}.");

        return Chain();
    }

    [Pure]
    private static string FormatComparison(StringComparison comparison) =>
        comparison == StringComparison.Ordinal ? "" : $" (using {comparison})";
}