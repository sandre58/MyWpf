// -----------------------------------------------------------------------
// <copyright file="ToasterPosition.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Toasting.Settings;

/// <summary>
/// Specifies the position on the screen where toast notifications are displayed.
/// </summary>
public enum ToasterPosition
{
    /// <summary>
    /// Top center of the screen.
    /// </summary>
    TopCenter,

    /// <summary>
    /// Top right of the screen.
    /// </summary>
    TopRight,

    /// <summary>
    /// Top left of the screen.
    /// </summary>
    TopLeft,

    /// <summary>
    /// Bottom right of the screen.
    /// </summary>
    BottomRight,

    /// <summary>
    /// Bottom left of the screen.
    /// </summary>
    BottomLeft,

    /// <summary>
    /// Bottom center of the screen.
    /// </summary>
    BottomCenter
}
