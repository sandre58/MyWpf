// -----------------------------------------------------------------------
// <copyright file="ThemeBase.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Theming;

/// <summary>
/// Specifies the base theme type for the application.
/// </summary>
public enum ThemeBase
{
    /// <summary>
    /// Inherit the theme from the parent or system.
    /// </summary>
    Inherit,

    /// <summary>
    /// Dark theme.
    /// </summary>
    Dark,

    /// <summary>
    /// Light theme.
    /// </summary>
    Light,

    /// <summary>
    /// High contrast theme for accessibility.
    /// </summary>
    HighContrast
}
