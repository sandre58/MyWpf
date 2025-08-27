<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyNetAutoMapper.png" width="128" alt="MyNetAutoMapper">
</div>

<h1 align="center">My .NET - AutoMapper Extensions</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.AutoMapper.Extensions?style=for-the-badge)](https://www.nuget.org/packages/MyNet.AutoMapper.Extensions)

Extensions and helpers for advanced AutoMapper integration in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

---

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.AutoMapper.Extensions
```

## Features

- Simplified AutoMapper configuration and profile management
- Helpers for mapping collections and complex objects
- Extension methods for common mapping scenarios
- Integration with dependency injection

## Example Usage

```csharp
using MyNet.AutoMapper.Extensions;

// Register profiles
services.AddAutoMapperProfiles(typeof(MyProfile));

// Map objects
var destination = source.MapTo<DestinationType>();
```

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](../../LICENSE) for details.