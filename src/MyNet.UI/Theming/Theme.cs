// -----------------------------------------------------------------------
// <copyright file="Theme.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Theming;

/// <summary>
/// Represents a theme configuration for the application, including base theme and color settings.
/// </summary>
public class Theme
{
    /// <summary>
    /// Gets or sets the base theme (e.g. Dark, Light, HighContrast).
    /// </summary>
    public ThemeBase? Base { get; set; }

    /// <summary>
    /// Gets or sets the primary color of the theme.
    /// </summary>
    public string? PrimaryColor { get; set; }

    /// <summary>
    /// Gets or sets the foreground color for the primary color.
    /// </summary>
    public string? PrimaryForegroundColor { get; set; }

    /// <summary>
    /// Gets or sets the accent color of the theme.
    /// </summary>
    public string? AccentColor { get; set; }

    /// <summary>
    /// Gets or sets the foreground color for the accent color.
    /// </summary>
    public string? AccentForegroundColor { get; set; }
}
