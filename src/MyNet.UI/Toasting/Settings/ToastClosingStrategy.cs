// -----------------------------------------------------------------------
// <copyright file="ToastClosingStrategy.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Toasting.Settings;

/// <summary>
/// Specifies how a toast notification can be closed.
/// </summary>
public enum ToastClosingStrategy
{
    /// <summary>
    /// The toast cannot be closed by the user or automatically.
    /// </summary>
    None,

    /// <summary>
    /// The toast closes automatically after a duration.
    /// </summary>
    AutoClose,

    /// <summary>
    /// The toast can be closed by a close button.
    /// </summary>
    CloseButton,

    /// <summary>
    /// The toast can be closed both automatically and by a close button.
    /// </summary>
    Both
}
