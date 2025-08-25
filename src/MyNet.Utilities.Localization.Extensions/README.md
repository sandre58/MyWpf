<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyNetUtilities.png" width="128" alt="MyNetUtilities">
</div>

<h1 align="center">My .NET Utilities Localization</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.Utilities.Localization.Extensions?style=for-the-badge)](https://www.nuget.org/packages/MyNet.Utilities.Localization.Extensions)
A set of resources and helpers for localization and multi-language support in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

---

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.Utilities.Localization.Extensions
```

## Features

- Manage localized strings and resources.
- Support for multi-language .NET applications.
- Utilities for working with cultures and translations.

## Example Usage

```csharp
using MyNet.Utilities.Localization.Extensions;

// Get a localized string
var localized = CultureExtensions.GetString("HelloKey");

// List supported cultures
var cultures = CultureExtensions.GetSupportedCultures();
```

## Related Packages

| Package | Description | NuGet |
|---|---|---|
| [**MyNet.Utilities**](../MyNet.Utilities) | Core utilities for .NET development. | [NuGet](https://www.nuget.org/packages/MyNet.Utilities) |
| [**MyNet.Utilities.Generator.Extensions**](../MyNet.Utilities.Generator.Extensions) | Generate random data for .NET apps. | [NuGet](https://www.nuget.org/packages/MyNet.Utilities.Generator.Extensions) |
| [**MyNet.Utilities.Geography.Extensions**](../MyNet.Utilities.Geography.Extensions) | Access detailed geography info. | [NuGet](https://www.nuget.org/packages/MyNet.Utilities.Geography.Extensions) |
| [**MyNet.Utilities.Logging.NLog**](../MyNet.Utilities.Logging.NLog) | Logging integration with NLog. | [NuGet](https://www.nuget.org/packages/MyNet.Utilities.Logging.NLog) |
| [**MyNet.Utilities.Mail.MailKit**](../MyNet.Utilities.Mail.MailKit) | Email sending with MailKit. | [NuGet](https://www.nuget.org/packages/MyNet.Utilities.Mail.MailKit) |

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](../../LICENSE) for details.