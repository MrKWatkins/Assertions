# MrKWatkins.Assertions

[![Build Status](https://github.com/MrKWatkins/Assertions/actions/workflows/build.yml/badge.svg)](https://github.com/MrKWatkins/Assertions/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/MrKWatkins.Assertions)](https://www.nuget.org/packages/MrKWatkins.Assertions)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MrKWatkins.Assertions)](https://www.nuget.org/packages/MrKWatkins.Assertions)

> A fluent assertion library for .NET unit testing.

## Installation

```
dotnet add package MrKWatkins.Assertions
```

Everything is in the `MrKWatkins.Assertions` namespace:

```csharp
using MrKWatkins.Assertions;
```

## Quick Start

Call `.Should()` on any value to begin a fluent assertion:

```csharp
// Equality
42.Should().Equal(42);
"hello".Should().Equal("hello");

// Null checks
string? value = null;
value.Should().BeNull();

// Collections
var numbers = new[] { 1, 2, 3 };
numbers.Should().SequenceEqual(1, 2, 3);
numbers.Should().Contain(2);

// Strings
"Hello, World!".Should().StartWith("Hello").And.Contain("World");

// Exceptions
(() => throw new InvalidOperationException("oops"))
    .Should().Throw<InvalidOperationException>("oops");
```

## Chaining

Most assertions return a chain object that lets you keep asserting on the same value:

```csharp
"hello world"
    .Should()
    .NotBeNull()
    .And.StartWith("hello")
    .And.EndWith("world")
    .And.HaveLength(11);
```

## Documentation

Find the full documentation at [https://mrkwatkins.github.io/Assertions/](https://mrkwatkins.github.io/Assertions/).

## Why?

FluentAssertions recently moved to a paid licence model with version 8.0. Whilst I don't have a particular problem with that, I am slightly annoyed by how they did it.
Instead of making a new package, they simply upgraded the version number and changed the licence. Which means any processes you might have in place to automatically
upgrade packages would then upgrade them and potentially leave you open to licencing costs. And yes, of course you should check your upgrades, blah blah, but I would
counter that with you shouldn't change licences on projects like that! Start a new package. Or something else. Whatever. Be better.

Anyway, it annoyed me enough that I thought I'd have a crack at my own version for a challenge and to see if I can fix a few irritations I have with FluentAssertions
on the way, such as:

* No Span support.
* Default ordering is not strict.

As such, this is purely designed for use in my other projects. If you want to use it, go for it, but don't expect me to fix bugs or add features anytime soon.

# Contributing, PRs, etc.

Not accepting contributions or PRs at the current time, as it's just a project for my own amusement and to support my other projects. Feel free to submit issues,
just don't expect me to look at them with any sense of urgency.

# Licence

MIT. And I won't change it. Honest.

## Building and documentation

Build and test with `dotnet test --solution src/Assertions.sln`. Tests use TUnit and Microsoft Testing Platform.

Handwritten documentation lives in `docs/content`; `docs/site.json` defines navigation and the API assembly input. The shared build action generates, lints and
validates the site using the documentation image. Run `python3 docs/preview.py` with Docker and the .NET 10 SDK installed, or select **Preview documentation** in a
JetBrains IDE. The preview is available at `http://localhost:5173/Assertions/`.

**Build and Test** runs on pushes and pull requests. **Release** runs the same validation and optionally publishes packages and documentation in one job. Both
publication options default to true. Leave the version blank for the next minor version, or enter an explicit stable version. For a documentation update without a
new package, turn **publish-packages** off and leave **publish-docs** on; it uses the latest released API and version. The optional `api-ref` overrides API source
for XML comment corrections. Package builds still validate documentation when deployment is disabled.
For the initial documentation update on 2.0.0, set `api-ref: main` after pushing this migration: its released XML comments fail the new prose rules. The next
package release will include those corrections, so subsequent documentation updates can use the released source normally.

Configure NuGet trusted publishing for owner `MrKWatkins`, repository `Assertions`, workflow `release.yml`, environment `github-pages` and package
`MrKWatkins.Assertions`. Set GitHub Pages to **GitHub Actions**, and allow `main` to deploy to the `github-pages` environment. No stored NuGet API key is required.
