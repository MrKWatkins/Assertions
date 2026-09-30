# AGENTS.md

This file provides guidance to AI agents when working with code in this repository.

## Project Overview

MrKWatkins.Assertions is a .NET assertion library for unit testing, created as an MIT-licensed alternative to FluentAssertions. Key differentiators: Span support and strict ordering by default.

## Build & Test Commands

```bash
# Build
dotnet build src/Assertions.sln

# Run all tests
dotnet test src/Assertions.sln

# Run a single test by name filter
dotnet test src/MrKWatkins.Assertions.Tests --filter "FullyQualifiedName~TestMethodName"
```

## Architecture

**Single namespace:** `MrKWatkins.Assertions` — everything is in one namespace.

**Three entry points for assertions:**
- `value.Should()` — fluent API via `ShouldExtensions` (primary usage)
- `AssertThat.Invoking(() => action())` — action/exception testing
- `Verify.That(condition, message)` — direct verification

**Assertion class hierarchy:** base classes are abstract and take the derived class as a `TSelf` type parameter (CRTP), so inherited assertions return a chain for the derived class. Non-sealed
classes that are also used directly have an abstract `TSelf` version plus a sealed version with the same name and fewer type parameters (e.g. `ObjectAssertions<TSelf, T>` and `ObjectAssertions<T>`).
- `ObjectAssertions<TSelf, T>` — base: null checks, equality, type checking. `ObjectAssertions<T>` is the sealed version returned by `Should<T>()`
  - `ComparableAssertions<TSelf, T>` — `T : IComparable<T>`: BeLessThan/GreaterThan (and OrEqualTo), BeInRange. Unordered values (NaN) fail all comparisons
    - `NumericAssertions<TSelf, T>` — BeZero, BePositive/Negative and Not variants. Zero is neither positive nor negative
      - `IntegerAssertions<T>` — cross-type Equal/NotEqual
      - `DecimalAssertions`
      - `FloatingPointAssertions<T>` — BeApproximately, comparisons with precision, NaN/Infinity
      - `TimeSpanAssertions` — BeApproximately
    - `DateTimeOffsetAssertions` — BeBefore/After (and OnOr), BeApproximately, BeExactly, HaveOffset
    - `DateOnlyAssertions` — BeBefore/After (and OnOr), BeOnDayOfWeek
  - `EnumerableAssertions<TSelf, TEnumerable, T>` — SequenceEqual, OnlyContain, ContainSingle. `EnumerableAssertions<TEnumerable, T>` is the sealed version
    - `StringAssertions` — Contain, NotContain
    - `ReadOnlySetAssertions<TSet, T>` — SetEquals, IsSupersetOf, IsSubsetOf
  - `ReadOnlyDictionaryAssertions<TDict, TKey, TValue>` — dictionary assertions
  - `ExceptionAssertions<T>` — HaveMessage, HaveInnerException
  - `BooleanAssertions`
- `ReadOnlySpanAssertions<T>` — span assertions (ref struct, zero-allocation)
- `ActionAssertions` — Throw, NotThrow

**Fluent chaining:** Assertions return `AssertionsChain<TAssertions, T>`, which wraps the assertions object and enables `.And` chaining (e.g., `value.Should().NotBeNull().And.Equal(expected)`).
Return `Chain()` from assertion methods. Extension methods that apply to several assertion classes should be generic over the assertions type (`this ObjectAssertions<TAssertions, T> assertions`)
and return `assertions.Chain()` so the specific type is preserved. The exceptions are `ReadOnlySpanAssertionsChain<T>` (a ref struct), and `ActionAssertionsChain<TException>` and
`InnerExceptionAssertionsChain<TException>`, which expose an exception rather than `.And`.

**Standalone extension methods** for simple types: `BooleanExtensions`, `NumericExtensions`, `CountExtensions`, `EnumerableExtensions`, `InvokingExtensions`.

**Formatting:** `Format.cs` handles value representation in error messages. `FormatInterpolatedStringHandler` provides custom interpolation. `With.IntegerFormat()` configures integer display via `FormattingScope`.

**Exception handling:** `Verify.cs` dynamically detects NUnit at runtime and throws its `AssertionException` when available, otherwise throws `AssertionException`.

## Conventions

- **Target:** .NET 10.0 with C# preview language features
- **Nullable reference types:** enabled; warnings are errors
- **Implicit usings** include `System.Diagnostics.CodeAnalysis`, `System.Diagnostics.Contracts`, `Pure` (aliased), and `JetBrains.Annotations`
- **JetBrains.Annotations:** Use `[Pure]`, `[NoEnumeration]`, `[InstantHandle]` etc. on public API methods
- **CallerArgumentExpression:** Used for predicate parameter logging
- **OverloadResolutionPriority:** Used to disambiguate generic overloads
- **Test framework:** TUnit (not NUnit/xUnit) — tests are async by default
- **Test naming:** Underscores in test method names (CA1707 suppressed)
- **Centralized package management:** versions in `src/Directory.Packages.props`, no version overrides allowed
- **Editor:** 4-space indents, LF line endings, max 200 char line length
- **Documentation:** XML comments on public API, Markdown for the API is automatically generated

## Documentation

- Documentation is generated using MKDocs and is found in the `doc` folder.
- Documentation in `doc/docs/API` is generated from the assembly using the sesharp tool from the root of the repository: `sesharp MrKWatkins.Assertions/bin/Release/net10.0/MrKWatkins.Assertions.dll doc/docs/API`
- Documentation in the root of `doc/docs` is handwritten.
- Handwritten documentation should link to the generated API documentation and Microsoft's API docs (https://learn.microsoft.com/en-us/dotnet/api/) for types, members, etc.
- ReadMe.md gives a brief summary of the project, the reasons why and licence information. It is included in the NuGet package.