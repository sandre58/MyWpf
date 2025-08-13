// -----------------------------------------------------------------------
// <copyright file="ThemeManager.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Theming;

/// <summary>
/// Provides a global access point for managing and applying themes in the application.
/// </summary>
public static class ThemeManager
{
    private static IThemeService? _themeService;

    /// <summary>
    /// Gets the current theme applied to the application.
    /// </summary>
    public static Theme? CurrentTheme => _themeService?.CurrentTheme;

    /// <summary>
    /// Initializes the <see cref="ThemeManager"/> with the specified <see cref="IThemeService"/>.
    /// </summary>
    /// <param name="themeService">The service used to manage themes.</param>
    public static void Initialize(IThemeService themeService) => _themeService = themeService;

    /// <summary>
    /// Occurs when the theme is changed.
    /// </summary>
    public static event EventHandler<ThemeChangedEventArgs> ThemeChanged
    {
        add
        {
            if (_themeService is not null)
                _themeService.ThemeChanged += value;
        }

        remove
        {
            if (_themeService is not null)
                _themeService.ThemeChanged -= value;
        }
    }

    /// <summary>
    /// Applies the specified base theme.
    /// </summary>
    /// <param name="themeBase">The base theme to apply.</param>
    public static void ApplyBase(ThemeBase themeBase) => ApplyTheme(new Theme { Base = themeBase });

    /// <summary>
    /// Applies the specified primary color.
    /// </summary>
    /// <param name="color">The primary color to apply.</param>
    public static void ApplyPrimaryColor(string? color) => ApplyPrimaryColor(color, null);

    /// <summary>
    /// Applies the specified primary color and foreground color.
    /// </summary>
    /// <param name="color">The primary color to apply.</param>
    /// <param name="foreground">The foreground color for the primary color.</param>
    public static void ApplyPrimaryColor(string? color, string? foreground) => ApplyTheme(new Theme { PrimaryColor = color, PrimaryForegroundColor = foreground });

    /// <summary>
    /// Applies the specified accent color.
    /// </summary>
    /// <param name="color">The accent color to apply.</param>
    public static void ApplyAccentColor(string? color) => ApplyAccentColor(color, null);

    /// <summary>
    /// Applies the specified accent color and foreground color.
    /// </summary>
    /// <param name="color">The accent color to apply.</param>
    /// <param name="foreground">The foreground color for the accent color.</param>
    public static void ApplyAccentColor(string? color, string? foreground) => ApplyTheme(new Theme { AccentColor = color, AccentForegroundColor = foreground });

    /// <summary>
    /// Applies the specified theme configuration.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    public static void ApplyTheme(Theme theme) => _themeService?.ApplyTheme(theme);
}
