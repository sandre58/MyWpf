// -----------------------------------------------------------------------
// <copyright file="ToasterSettings.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Toasting.Settings;

/// <summary>
/// Settings for configuring the behavior and appearance of the toaster notification area.
/// </summary>
public class ToasterSettings
{
    /// <summary>
    /// Gets the default toaster settings.
    /// </summary>
    public static ToasterSettings Default => new();

    /// <summary>
    /// Gets or sets the duration for which a toast notification is displayed.
    /// </summary>
    public TimeSpan Duration { get; set; } = TimeSpan.FromSeconds(3.5);

    /// <summary>
    /// Gets or sets the maximum number of toast notifications displayed at once.
    /// </summary>
    public int MaxItems { get; set; } = int.MaxValue;

    /// <summary>
    /// Gets or sets the position on the screen where toast notifications are displayed.
    /// </summary>
    public ToasterPosition Position { get; set; } = ToasterPosition.BottomRight;

    /// <summary>
    /// Gets or sets the horizontal offset from the screen edge.
    /// </summary>
    public double OffsetX { get; set; } = 10;

    /// <summary>
    /// Gets or sets the vertical offset from the screen edge.
    /// </summary>
    public double OffsetY { get; set; } = 10;

    /// <summary>
    /// Gets or sets the width of the toaster notification area.
    /// </summary>
    public double Width { get; set; } = 300;
}
