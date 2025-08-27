<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyNetHttp.png" width="128" alt="MyNetHttp">
</div>

<h1 align="center">My .NET - Http</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.Http?style=for-the-badge)](https://www.nuget.org/packages/MyNet.Http)

Helpers and extensions for HTTP client operations in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

---

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.Http
```

## Features

- Simplified HTTP client creation and configuration
- Extension methods for common HTTP operations
- Helpers for sending requests and handling responses
- Support for JSON serialization/deserialization

## Example Usage

```csharp
using MyNet.Http.Extensions;

// Create and configure HttpClient
var client = HttpClientFactory.Create();

// Send a GET request
var response = await client.GetJsonAsync<MyResponseType>("https://api.example.com/data");
```

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](../../LICENSE) for details.
