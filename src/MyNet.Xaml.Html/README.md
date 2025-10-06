<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyXaml.png" width="128" alt="MyXaml">
</div>

<h1 align="center">My .NET XAML to HTML</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/MyWpf?style=for-the-badge)](https://github.com/sandre58/MyWpf/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.Xaml.Html?style=for-the-badge)](https://www.nuget.org/packages/MyNet.Xaml.Html)

XAML to HTML conversion utilities and helpers for cross-platform content rendering in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.Xaml.Html
```

## Features

- 🔄 **XAML to HTML Conversion** - Convert XAML content to HTML for web rendering
- 🎨 **Style Preservation** - Maintain styling and formatting during conversion
- 🌐 **Cross-Platform Rendering** - Enable XAML content display in web browsers
- 📝 **Rich Text Support** - Handle complex XAML text formatting
- 🔧 **Extensible** - Easy to customize and extend conversion logic

## Usage

### Basic XAML to HTML Conversion

```csharp
using MyNet.Xaml.Html;

// Convert XAML string to HTML
string xamlContent = "<TextBlock>Hello World</TextBlock>";
string htmlContent = XamlToHtmlConverter.Convert(xamlContent);
```

### Converting FlowDocument

```csharp
// Convert a WPF FlowDocument to HTML
FlowDocument document = new FlowDocument();
document.Blocks.Add(new Paragraph(new Run("Sample text")));

string html = XamlToHtmlConverter.ConvertFlowDocument(document);
```

### Advanced Conversion with Options

```csharp
var options = new ConversionOptions
{
    PreserveWhitespace = true,
    IncludeStyles = true,
    CustomCssClasses = new Dictionary<string, string>()
};

string html = XamlToHtmlConverter.Convert(xamlContent, options);
```

## Common Use Cases

- **Documentation Export** - Convert rich text from WPF applications to HTML for web display
- **Content Management** - Export XAML-based content to HTML for CMS integration
- **Reporting** - Generate HTML reports from WPF FlowDocument content
- **Email Generation** - Convert formatted XAML content to HTML emails
- **Cross-Platform Content** - Display WPF content in web applications

## Related Packages

This package is part of the [MyWpf](https://github.com/sandre58/MyWpf) collection:

- **[MyNet.Wpf](../MyNet.Wpf)** - Core WPF library with controls and theming
- **[MyNet.Wpf.Presentation](../MyNet.Wpf.Presentation)** - MVVM presentation helpers
- **[MyNet.Wpf.LiveCharts](../MyNet.Wpf.LiveCharts)** - Data visualization components

## Contributing

Contributions are welcome! Please see the [Contributing Guidelines](../../CONTRIBUTING.md) for more information.

## License

Copyright © 2016-2025 Stéphane ANDRE.

MyNet.Xaml.Html is provided as-is under the MIT license. For more information see [LICENSE](../../LICENSE).