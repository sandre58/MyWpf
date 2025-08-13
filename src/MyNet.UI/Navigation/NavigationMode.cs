// -----------------------------------------------------------------------
// <copyright file="NavigationMode.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Navigation;

/// <summary>
/// Specifies the navigation direction or mode.
/// </summary>
public enum NavigationMode
{
    /// <summary>
    /// Normal navigation.
    /// </summary>
    Normal,

    /// <summary>
    /// Navigation backward in history.
    /// </summary>
    Back,

    /// <summary>
    /// Navigation forward in history.
    /// </summary>
    Forward
}
