<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="assets/MyNetWpf.png" width="128" alt="MyNetWpf">
  <img src="assets/MyNetXaml.png" width="128" alt="MyNetXaml">
</div>

<h1 align="center">My .NET WPF</h1>

[![MIT License][license-shield]][license-url]
[![GitHub Stars](https://img.shields.io/github/stars/sandre58/MyWpf?style=for-the-badge)](https://github.com/sandre58/MyWpf/stargazers)
[![GitHub Forks](https://img.shields.io/github/forks/sandre58/MyWpf?style=for-the-badge)](https://github.com/sandre58/MyWpf/network/members)
[![GitHub Issues](https://img.shields.io/github/issues/sandre58/MyWpf?style=for-the-badge)](https://github.com/sandre58/MyWpf/issues)
[![Last Commit](https://img.shields.io/github/last-commit/sandre58/MyWpf?style=for-the-badge)](https://github.com/sandre58/MyWpf/commits/main)
[![Contributors](https://img.shields.io/github/contributors/sandre58/MyWpf?style=for-the-badge)](https://github.com/sandre58/MyWpf/graphs/contributors)
[![Repo Size](https://img.shields.io/github/repo-size/sandre58/MyWpf?style=for-the-badge)](https://github.com/sandre58/MyWpf)

A comprehensive collection of WPF libraries and extensions for modern .NET desktop development (8.0, 9.0, and 10.0). This repository provides specialized WPF controls, theming, drag-and-drop functionality, LiveCharts integration, presentation helpers, web components, and XAML utilities to enhance Windows desktop applications.

## ✨ Key Features

- 🎨 **Advanced Theming & Styling** - Complete theming system with Material Design integration
- 🪟 **Rich WPF Controls** - Custom controls, dialogs, notifications, and UI helpers
- 🖱️ **Drag & Drop** - Advanced drag-and-drop functionality with custom handlers and adorners
- 📊 **Data Visualization** - LiveCharts integration for beautiful, interactive charts
- 🏗️ **MVVM Architecture** - Presentation layer utilities and MVVM pattern support
- 🌐 **Web Integration** - Browser controls and web view components for hybrid applications
- 🔄 **XAML Utilities** - XAML to HTML conversion and cross-platform content rendering
- 🚀 **Production Ready** - Battle-tested libraries used in real-world applications

## Packages

[![Build][build-shield]][build-url]
[![Coverage](https://codecov.io/gh/sandre58/MyWpf/branch/main/graph/badge.svg)](https://codecov.io/gh/sandre58/MyWpf)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)
[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)

| Package | Description | NuGet |
|---|---|---|
| [**MyNet.Wpf**](src/MyNet.Wpf) | 🪟 Comprehensive WPF library with controls, theming, dialogs, notifications, and UI helpers for Windows desktop applications. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Wpf)](https://www.nuget.org/packages/MyNet.Wpf) |
| [**MyNet.Wpf.DragAndDrop**](src/MyNet.Wpf.DragAndDrop) | 🖱️ Advanced drag-and-drop functionality with custom handlers, adorners, and file/calendar integration for WPF applications. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Wpf.DragAndDrop)](https://www.nuget.org/packages/MyNet.Wpf.DragAndDrop) |
| [**MyNet.Wpf.LiveCharts**](src/MyNet.Wpf.LiveCharts) | 📈 WPF LiveCharts integration with custom formatters, series, and theming for beautiful data visualization. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Wpf.LiveCharts)](https://www.nuget.org/packages/MyNet.Wpf.LiveCharts) |
| [**MyNet.Wpf.Presentation**](src/MyNet.Wpf.Presentation) | 📽️ MVVM presentation layer with controls, converters, models, and services for structured WPF applications. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Wpf.Presentation)](https://www.nuget.org/packages/MyNet.Wpf.Presentation) |
| [**MyNet.Wpf.Web**](src/MyNet.Wpf.Web) | 🌐 WPF web integration with browser controls and web view components for hybrid applications. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Wpf.Web)](https://www.nuget.org/packages/MyNet.Wpf.Web) |
| [**MyNet.Xaml.Html**](src/MyNet.Xaml.Html) | 🔄 XAML to HTML conversion utilities and helpers for cross-platform content rendering. | [![NuGet](https://img.shields.io/nuget/v/MyNet.Xaml.Html)](https://www.nuget.org/packages/MyNet.Xaml.Html) |

## 🚀 Getting Started

### Prerequisites

- **.NET 8.0, 9.0, or 10.0** - The libraries support the latest .NET versions
- **Visual Studio 2022** (recommended for WPF development)
- **Windows 10/11** - Required for WPF applications
- **NuGet** package manager

### Installation

Install any WPF package via NuGet Package Manager, .NET CLI, or PackageReference:

**Using .NET CLI:**
```bash
# Core WPF library with controls and theming
dotnet add package MyNet.Wpf

# Advanced drag-and-drop functionality
dotnet add package MyNet.Wpf.DragAndDrop

# LiveCharts integration for data visualization
dotnet add package MyNet.Wpf.LiveCharts

# MVVM presentation helpers
dotnet add package MyNet.Wpf.Presentation

# Web integration components
dotnet add package MyNet.Wpf.Web

# XAML to HTML conversion
dotnet add package MyNet.Xaml.Html
```

**Using Package Manager Console:**
```powershell
Install-Package MyNet.Wpf
Install-Package MyNet.Wpf.DragAndDrop
Install-Package MyNet.Wpf.LiveCharts
Install-Package MyNet.Wpf.Presentation
Install-Package MyNet.Wpf.Web
Install-Package MyNet.Xaml.Html
```

**Using PackageReference:**
```xml
<PackageReference Include="MyNet.Wpf" Version="1.0.*" />
<PackageReference Include="MyNet.Wpf.DragAndDrop" Version="1.0.*" />
<PackageReference Include="MyNet.Wpf.LiveCharts" Version="1.0.*" />
```

### Quick Examples

**Basic WPF Theming:**
```xaml
<!-- App.xaml -->
<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <ResourceDictionary Source="pack://application:,,,/MyNet.Wpf;component/Themes/MyNet.xaml" />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>
```

**Drag & Drop Integration:**
```csharp
// Enable file drop handling
var dropHandler = new FileDropHandler();
myControl.AllowDrop = true;
```

**LiveCharts Data Visualization:**
```csharp
// Create a simple chart
var chartSeries = new ChartSerie<double> 
{ 
    Values = new[] { 1, 5, 3, 8, 2 },
    Title = "Sample Data"
};
```

For detailed usage examples and API references, explore the documentation in each package's directory under `src/`.

## 📁 Repository Structure

- **`src/`** — Source code for all WPF packages:
  - **`MyNet.Wpf/`** — Core WPF library with controls, theming, and UI helpers
  - **`MyNet.Wpf.DragAndDrop/`** — Drag-and-drop functionality and handlers
  - **`MyNet.Wpf.LiveCharts/`** — LiveCharts integration and chart components
  - **`MyNet.Wpf.Presentation/`** — MVVM presentation layer and utilities
  - **`MyNet.Wpf.Web/`** — Web integration and browser controls
  - **`MyNet.Xaml.Html/`** — XAML to HTML conversion utilities
  - **`LiveCharts/`** — Core LiveCharts libraries (LiveCharts, LiveCharts.Wpf)

- **`demos/`** — Example WPF applications showcasing library features
  - **`MyNet.Wpf.Demo/`** — Comprehensive WPF demo application
  
- **`assets/`** — Project logos, icons, and visual assets
- **`build/`** — MSBuild configuration and shared properties
- **`docs/`** — Documentation and contribution guidelines
- **`.github/`** — CI/CD workflows and GitHub automation

## 🛠️ Development

### Building from Source

```bash
# Clone the repository
git clone https://github.com/sandre58/MyWpf.git
cd MyWpf

# Build all projects
dotnet build

# Run tests (if available)
dotnet test

# Create NuGet packages
dotnet pack
```

### Demo Application

Explore the comprehensive demo application to see all WPF libraries in action:

```bash
# Run the WPF demo
dotnet run --project demos/MyNet.Wpf.Demo
```

### Contributing

We welcome contributions! Please see our [Contributing Guidelines](CONTRIBUTING.md) and [Code of Conduct](CODE_OF_CONDUCT.md) for details on how to get involved.

## 📄 License

Copyright © 2016-2025 Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](./LICENSE) for complete details.

<!-- MARKDOWN LINKS & IMAGES -->
[license-shield]: https://img.shields.io/github/license/sandre58/MyWpf?style=for-the-badge
[license-url]: https://github.com/sandre58/MyWpf/blob/main/LICENSE
[build-shield]: https://img.shields.io/github/actions/workflow/status/sandre58/MyWpf/ci.yml?logo=github&label=CI
[build-url]: https://github.com/sandre58/MyWpf/actions