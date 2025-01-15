# MrKWatkins.Assertions

[![Build Status](https://github.com/MrKWatkins/Assertions/actions/workflows/build.yml/badge.svg)](https://github.com/MrKWatkins/Assertions/actions/workflows/build.yml)
[![NuGet Version](https://img.shields.io/nuget/v/MrKWatkins.Assertions)](https://www.nuget.org/packages/MrKWatkins.Assertions)
[![NuGet Downloads](https://img.shields.io/nuget/dt/MrKWatkins.Assertions)](https://www.nuget.org/packages/MrKWatkins.Assertions)

> Assertion library for unit testing.

## Why?

FluentAssertions recently moved to a paid licence model with version 8.0. Whilst I don't have a particular problem with that I am slightly annoyed by how they did it.
Instead of making a new repository they simply upgraded the version number and changed licence. Which means any processes you might have in place to automatically
upgrade packages would then upgrade them, and potentially leave you open to licencing costs. And yes, of course you should check your upgrades, blah blah, but I would
counter that with you shouldn't change licences on projects like that! Start a new repo. Or something else. Whatever. Be better.

Anyway, it annoyed me enough that I thought I'd have a crack at my own version for a challenge, and see if I can fix a few irritations I have with FluentAssertions
on the way, such as:

* No Span support.
* Default ordering is not strict.
* Various other little things.

As such this is purely designed for use in my other projects. If you want to use it, go for it, but don't expect me to fix bugs or add features anytime soon.

## Contributing, PRs, etc.

Not accepting contributions or PRs at the current time, as it's just a project for my own amusement and to support my other projects. Feel free to submit issues,
just don't expect me to look at them with any sense of urgency.

## Licence

MIT. And I won't change it. Honest.