// -----------------------------------------------------------------------
// <copyright file="NavigatingEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.UI.Navigation.Models;

namespace MyNet.UI.Navigation;

/// <summary>
/// Provides data for the Navigating event before navigation is performed, including cancellation support.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NavigatingEventArgs"/> class.
/// </remarks>
/// <param name="oldPage">The previous page before navigation.</param>
/// <param name="newPage">The destination page for navigation.</param>
/// <param name="mode">The navigation mode.</param>
/// <param name="navigationParameters">The navigation parameters.</param>
public class NavigatingEventArgs(INavigationPage? oldPage, INavigationPage newPage, NavigationMode mode, NavigationParameters? navigationParameters = null) : NavigationEventArgs(oldPage, newPage, mode, navigationParameters)
{
    /// <summary>
    /// Gets or sets a value indicating whether navigation should be canceled.
    /// </summary>
    public bool Cancel { get; set; }
}
