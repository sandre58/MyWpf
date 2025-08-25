<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyNetCsvHelper.png" width="128" alt="MyNetCsvHelper">
</div>

<h1 align="center">My .NET - CsvHelper</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.CsvHelper.Extensions?style=for-the-badge)](https://www.nuget.org/packages/MyNet.CsvHelper.Extensions)

A versatile extension library for advanced CSV parsing, writing, and integration in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

---

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.CsvHelper.Extensions
```

## Features

- **Advanced CSV Parsing**: Custom mappings, dynamic parsing, and flexible object graphs.
- **Flexible CSV Writing**: Custom formatting, header management, and output control.
- **Data Manipulation and Transformation**: Filtering, validation, and transformation of CSV data.
- **Excel Integration**: Read and write Excel files using CsvHelper.

## Example Usage

```csharp
using MyNet.CsvHelper.Extensions;

// Parse CSV to objects
var records = CsvReaderExtensions.Read<MyClass>(csvStream);

// Write objects to CSV
CsvWriterExtensions.Write(records, csvStream);

// Read Excel file
var excelRecords = ExcelReader.Read<MyClass>(excelStream);
```

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](../../LICENSE) for details.