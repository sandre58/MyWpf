// -----------------------------------------------------------------------
// <copyright file="ThemeChangedEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Theming;

/// <summary>
/// Provides data for the <see cref="ThemeManager.ThemeChanged"/> event.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ThemeChangedEventArgs"/> class.
/// </remarks>
/// <param name="theme">The current theme.</param>
public class ThemeChangedEventArgs(Theme theme) : EventArgs
{
    /// <summary>
    /// Gets the current theme after the change.
    /// </summary>
    public Theme CurrentTheme { get; } = theme;
}
