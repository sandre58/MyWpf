<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyNetHumanizer.png" width="128" alt="MyNetHumanizer">
</div>

<h1 align="center">My .NET Humanizer</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.Humanizer?style=for-the-badge)](https://www.nuget.org/packages/MyNet.Humanizer)

A versatile library for converting objects and values into human-readable strings in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

---

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.Humanizer
```

## Features

- **Object to String Conversion**: Convert objects of various types into readable string representations.
- **Customizable Formatting**: Customize the format and structure of generated strings.
- **Localization Support**: Generate localized strings for multi-language applications.

## Example Usage

```csharp
using MyNet.Humanizer;

// Humanize a number
var readable = NumberHumanizeExtensions.Humanize(12345);

// Humanize a date
var date = DateTimeHumanizeExtensions.Humanize(DateTime.Now);

// Humanize an enum
var text = EnumHumanizeExtensions.Humanize(MyEnum.Value);
```

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](../../LICENSE) for details.