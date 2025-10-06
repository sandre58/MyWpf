
<div id="top"></div>

<!-- PROJECT INFO -->
<br />
<div align="center">
  <img src="../../assets/MyWpf.png" width="128" alt="MyWpf">
</div>

<h1 align="center">My .NET WPF</h1>

[![MIT License](https://img.shields.io/github/license/sandre58/mynet?style=for-the-badge)](https://github.com/sandre58/mynet/blob/main/LICENSE)
[![NuGet](https://img.shields.io/nuget/v/MyNet.Wpf?style=for-the-badge)](https://www.nuget.org/packages/MyNet.Wpf)

A comprehensive library for advanced WPF controls, theming, dialogs, notifications, and UI helpers in .NET applications.

[![.NET 8.0](https://img.shields.io/badge/.NET-8.0-purple)](#)
[![.NET 9.0](https://img.shields.io/badge/.NET-9.0-purple)](#)
[![.NET 10.0](https://img.shields.io/badge/.NET-10.0-purple)](#)
[![C#](https://img.shields.io/badge/language-C%23-blue)](#)

---

## Installation

Install via NuGet:

```bash
dotnet add package MyNet.Wpf
```


## Features

- Rich set of WPF controls and UI helpers
- Theming and color scheme support
- Dialogs, notifications, and toasts
- ViewModel and navigation helpers
- Resource locators and XAML utilities
- Custom fonts and cursors
- Integration with MahApps.Metro, MaterialDesignThemes, WPF-UI


## Theming & Styles

MyNet.Wpf provides an advanced theming and styling system to customize the look and feel of your WPF applications.

### Using Themes

To apply the default theme, add the following resource in your `App.xaml`:

```xml
<Application.Resources>
  <ResourceDictionary>
    <ResourceDictionary.MergedDictionaries>
      <ResourceDictionary Source="pack://application:,,,/MyNet.Wpf;component/Themes/MyNet.Theme.xaml" />
    </ResourceDictionary.MergedDictionaries>
  </ResourceDictionary>
</Application.Resources>
```

You can also merge your own resource dictionaries or override existing styles.

### Customization

- Styles are grouped in `Themes/MyNet.Styles.xaml` and can be extended or replaced.
- Colors, fonts, and icons are customizable via XAML resources.
- Common controls (Button, DataGrid, TabControl, etc.) benefit from modern and adaptive styles.

### Example: Change Theme at Runtime

```csharp
// Dynamically change the theme
Application.Current.Resources.MergedDictionaries.Clear();
Application.Current.Resources.MergedDictionaries.Add(
    new ResourceDictionary { Source = new Uri("pack://application:,,,/MyNet.Wpf;component/Themes/MyNet.Theme.xaml") }
);
```


## Example Usage

### Show a toast notification
```csharp
using MyNet.Wpf.Toasting;

Toaster.Show("Hello from MyNet.Wpf!");
```

### Use a custom dialog
```csharp
using MyNet.Wpf.Dialogs;

var result = DialogService.Show<MyCustomDialog>();
```

### Change theme at runtime
```csharp
Application.Current.Resources.MergedDictionaries.Clear();
Application.Current.Resources.MergedDictionaries.Add(
  new ResourceDictionary { Source = new Uri("pack://application:,,,/MyNet.Wpf;component/Themes/MyNet.Theme.xaml") }
);
```

### Use a custom style for a button
```xml
<Button Style="{StaticResource MyNet.Styles.Button.Elevation}" Content="Styled Button" />
```

### Use a resource locator
```csharp
using MyNet.Wpf.ResourceLocator;

var resource = ResourceLocator.GetResource("MyNet.Brushes.Positive");
```

## License

Copyright © Stéphane ANDRE.

Distributed under the MIT License. See [LICENSE](../../LICENSE) for details.