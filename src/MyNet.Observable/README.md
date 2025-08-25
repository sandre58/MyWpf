<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyNetObservable.png" width="128" alt="MyNetObservable">
</div>

<h1 align="center">My .NET Observable</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.Observable?style=for-the-badge)](https://www.nuget.org/packages/MyNet.Observable)

A comprehensive library for creating and managing editable and validatable objects in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

---

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.Observable
```

## Features

- **Editable Objects**: Easily create objects whose properties can be edited via UI or code.
- **Validatable Objects**: Validate object properties against rules and constraints.
- **Customizable Validation**: Define custom and dynamic validation logic.
- **Error Handling**: Graceful feedback for validation errors.

## Example Usage

```csharp
using MyNet.Observable;

// Create an editable object
var obj = new EditableObject();

// Validate the object
bool isValid = obj.Validate();
```

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](../../LICENSE) for details.