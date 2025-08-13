// -----------------------------------------------------------------------
// <copyright file="NavigatingContext.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Navigation.Models;

/// <summary>
/// Provides context information for a navigation operation, including cancellation support.
/// Inherits from <see cref="NavigationContext"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="NavigatingContext"/> class.
/// </remarks>
/// <param name="oldPage">The previous page before navigation.</param>
/// <param name="newPage">The destination page for navigation.</param>
/// <param name="mode">The navigation mode.</param>
/// <param name="navigationParameters">The navigation parameters.</param>
public class NavigatingContext(INavigationPage? oldPage, INavigationPage newPage, NavigationMode mode, NavigationParameters? navigationParameters = null) : NavigationContext(oldPage, newPage, mode, navigationParameters)
{
    /// <summary>
    /// Gets or sets a value indicating whether navigation should be canceled.
    /// </summary>
    public bool Cancel { get; set; }
}
