<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="assets/MyNetUtilities.png" width="128" alt="MyNetUtilities">
  <img src="assets/MyNetUI.png" width="128" alt="MyNetUI">
  <img src="assets/MyNetObservable.png" width="128" alt="MyNetObservable">
  <img src="assets/MyNetHumanizer.png" width="128" alt="MyNetHumanizer">
  <img src="assets/MyNetCsvHelper.png" width="128" alt="MyNetCsvHelper">
  <img src="assets/MyNetAutoMapper.png" width="128" alt="MyNetAutoMapper">
  <img src="assets/MyNetHttp.png" width="128" alt="MyNetHttp">
</div>

<h1 align="center">My .NET</h1>

[![MIT License][license-shield]][license-url]
[![GitHub Stars](https://img.shields.io/github/stars/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/network/members)
[![GitHub Issues](https://img.shields.io/github/issues/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/issues)
[![Last Commit](https://img.shields.io/github/last-commit/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/commits/main)
[![Contributors](https://img.shields.io/github/contributors/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/graphs/contributors)
[![Repo Size](https://img.shields.io/github/repo-size/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet)

A collection of useful libraries and extensions for .NET 8.0, designed to simplify development and enhance productivity. Each package is independent and can be used separately.

## Packages

[![Build][build-shield]][build-url]
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)
[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)

| Package | Description | NuGet |
|---|---|---|
| [**MyNet.Utilities**](src/MyNet.Utilities) | Core utilities for .NET development: authentication, cache, encryption, geography, generator, Google, IO, localization, logging, mail, messaging, progress tracking, threading. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Utilities)](https://www.nuget.org/packages/MyNet.Utilities) |
| [**MyNet.UI**](src/MyNet.UI) | UI helpers for notifications, dialogs, navigation, themes, and more. | [![NuGet](https://img.shields.io/nuget/v/MyNet.UI)](https://www.nuget.org/packages/MyNet.UI) |
| [**MyNet.Observable**](src/MyNet.Observable) | Editable and validatable object base classes and utilities. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Observable)](https://www.nuget.org/packages/MyNet.Observable) |
| [**MyNet.Humanizer**](src/MyNet.Humanizer) | Convert objects and values to human-readable strings. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Humanizer)](https://www.nuget.org/packages/MyNet.Humanizer) |
| [**MyNet.CsvHelper.Extensions**](src/MyNet.CsvHelper.Extensions) | Extensions for CsvHelper to simplify CSV mapping and export. | [![NuGet](https://img.shields.io/nuget/v/MyNet.CsvHelper.Extensions)](https://www.nuget.org/packages/MyNet.CsvHelper.Extensions) |
| [**MyNet.AutoMapper.Extensions**](src/MyNet.AutoMapper.Extensions) | Extensions and helpers for AutoMapper integration. | [![NuGet](https://img.shields.io/nuget/v/MyNet.AutoMapper.Extensions)](https://www.nuget.org/packages/MyNet.AutoMapper.Extensions) |
| [**MyNet.Http**](src/MyNet.Http) | HTTP client helpers and extensions. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Http)](https://www.nuget.org/packages/MyNet.Http) |
| [**MyNet.Utilities.Generator.Extensions**](src/MyNet.Utilities.Generator.Extensions) | Generate random data for testing and simulations. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Utilities.Generator.Extensions)](https://www.nuget.org/packages/MyNet.Utilities.Generator.Extensions) |
| [**MyNet.Utilities.Geography.Extensions**](src/MyNet.Utilities.Geography.Extensions) | Access detailed geography information. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Utilities.Geography.Extensions)](https://www.nuget.org/packages/MyNet.Utilities.Geography.Extensions) |
| [**MyNet.Utilities.Localization.Extensions**](src/MyNet.Utilities.Localization.Extensions) | Localization resources and helpers. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Utilities.Localization.Extensions)](https://www.nuget.org/packages/MyNet.Utilities.Localization.Extensions) |
| [**MyNet.Utilities.Logging.NLog**](src/MyNet.Utilities.Logging.NLog) | Logging integration with NLog. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Utilities.Logging.NLog)](https://www.nuget.org/packages/MyNet.Utilities.Logging.NLog) |
| [**MyNet.Utilities.Mail.MailKit**](src/MyNet.Utilities.Mail.MailKit) | Email sending with MailKit. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Utilities.Mail.MailKit)](https://www.nuget.org/packages/MyNet.Utilities.Mail.MailKit) |

## Getting Started

To install a package, use NuGet:

```bash
# Example for core utilities
 dotnet add package MyNet.Utilities
# Example for UI helpers
 dotnet add package MyNet.UI
# Example for Observable
 dotnet add package MyNet.Observable
# Example for Humanizer
 dotnet add package MyNet.Humanizer
# Example for CsvHelper Extensions
 dotnet add package MyNet.CsvHelper.Extensions
```

See each package's README for usage details and API documentation.

## Repository Structure

- `src/` — Source code for all packages
- `tests/` — Unit tests
- `docs/` — Documentation
- `assets/` — Logos and images
- `build/` — Build configuration

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](./LICENSE) for details.

<!-- MARKDOWN LINKS & IMAGES -->
[license-shield]: https://img.shields.io/github/license/sandre58/MyNet?style=for-the-badge
[license-url]: https://github.com/sandre58/MyNet/blob/main/LICENSE
[build-shield]: https://img.shields.io/github/actions/workflow/status/sandre58/MyNet/ci.yml?logo=github&label=CI
[build-url]: https://github.com/sandre58/MyNet/actions