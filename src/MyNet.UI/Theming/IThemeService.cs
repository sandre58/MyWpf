// -----------------------------------------------------------------------
// <copyright file="IThemeService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Theming;

/// <summary>
/// Defines the contract for a service that manages themes in the application.
/// </summary>
public interface IThemeService
{
    /// <summary>
    /// Gets the current theme applied to the application.
    /// </summary>
    Theme CurrentTheme { get; }

    /// <summary>
    /// Applies the specified theme configuration.
    /// </summary>
    /// <param name="theme">The theme to apply.</param>
    void ApplyTheme(Theme theme);

    /// <summary>
    /// Adds a base theme extension to the service.
    /// </summary>
    /// <param name="extension">The base theme extension to add.</param>
    /// <returns>The theme service instance for chaining.</returns>
    IThemeService AddBaseExtension(IThemeExtension extension);

    /// <summary>
    /// Adds a primary color extension to the service.
    /// </summary>
    /// <param name="extension">The primary color extension to add.</param>
    /// <returns>The theme service instance for chaining.</returns>
    IThemeService AddPrimaryExtension(IThemeExtension extension);

    /// <summary>
    /// Adds an accent color extension to the service.
    /// </summary>
    /// <param name="extension">The accent color extension to add.</param>
    /// <returns>The theme service instance for chaining.</returns>
    IThemeService AddAccentExtension(IThemeExtension extension);

    /// <summary>
    /// Occurs when the theme is changed.
    /// </summary>
    event EventHandler<ThemeChangedEventArgs>? ThemeChanged;
}
