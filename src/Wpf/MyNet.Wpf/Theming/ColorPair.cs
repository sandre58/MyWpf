// -----------------------------------------------------------------------
// <copyright file="ColorPair.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Media;
using MyNet.Wpf.Extensions;

namespace MyNet.Wpf.Theming;

public struct ColorPair(Color color, Color? foreground = null)
{
    public Color Color { get; set; } = color;

    /// <summary>
    /// The foreground or opposite color. If left null, this will be calculated for you.
    /// Calculated by calling ColorAssist.ContrastingForegroundColor().
    /// </summary>
    public Color? ForegroundColor { get; set; } = foreground;

    public static implicit operator ColorPair(Color color) => new(color);

    public readonly Color GetForegroundColor() => ForegroundColor ?? Color.ContrastingForegroundColor();
}
