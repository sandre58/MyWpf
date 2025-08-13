// -----------------------------------------------------------------------
// <copyright file="NavigationEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using MyNet.UI.Navigation.Models;

namespace MyNet.UI.Navigation;

/// <summary>
/// Provides data for the Navigated event after navigation is performed.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NavigationEventArgs"/> class.
/// </remarks>
/// <param name="oldPage">The previous page before navigation.</param>
/// <param name="newPage">The destination page for navigation.</param>
/// <param name="mode">The navigation mode.</param>
/// <param name="navigationParameters">The navigation parameters.</param>
public class NavigationEventArgs(INavigationPage? oldPage, INavigationPage newPage, NavigationMode mode, NavigationParameters? navigationParameters = null) : EventArgs
{
    /// <summary>
    /// Gets the previous page before navigation.
    /// </summary>
    public INavigationPage? OldPage { get; } = oldPage;

    /// <summary>
    /// Gets the destination page for navigation.
    /// </summary>
    public INavigationPage NewPage { get; } = newPage;

    /// <summary>
    /// Gets the navigation parameters.
    /// </summary>
    public NavigationParameters? Parameters { get; } = navigationParameters;

    /// <summary>
    /// Gets the navigation mode.
    /// </summary>
    public NavigationMode Mode { get; } = mode;
}
