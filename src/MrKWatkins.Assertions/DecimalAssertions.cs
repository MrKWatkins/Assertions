namespace MrKWatkins.Assertions;

/// <summary>
/// Provides assertions for <see cref="decimal" /> values.
/// </summary>
/// <param name="value">The value to assert on.</param>
public sealed class DecimalAssertions(decimal value) : NumericAssertions<DecimalAssertions, decimal>(value, 0m);