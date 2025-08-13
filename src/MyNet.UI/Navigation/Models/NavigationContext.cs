// -----------------------------------------------------------------------
// <copyright file="NavigationContext.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Navigation.Models;

/// <summary>
/// Encapsulates information about a navigation request, including source, destination, mode, and parameters.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NavigationContext"/> class.
/// </remarks>
/// <param name="oldPage">The previous page before navigation.</param>
/// <param name="newPage">The destination page for navigation.</param>
/// <param name="mode">The navigation mode.</param>
/// <param name="navigationParameters">The navigation parameters.</param>
public class NavigationContext(INavigationPage? oldPage, INavigationPage newPage, NavigationMode mode, NavigationParameters? navigationParameters = null)
{
    /// <summary>
    /// Gets the previous page before navigation.
    /// </summary>
    public INavigationPage? OldPage { get; } = oldPage;

    /// <summary>
    /// Gets the destination page for navigation.
    /// </summary>
    public INavigationPage Page { get; } = newPage;

    /// <summary>
    /// Gets the navigation parameters.
    /// </summary>
    public NavigationParameters? Parameters { get; } = navigationParameters;

    /// <summary>
    /// Gets the navigation mode.
    /// </summary>
    public NavigationMode Mode { get; } = mode;
}
