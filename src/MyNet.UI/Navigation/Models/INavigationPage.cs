// -----------------------------------------------------------------------
// <copyright file="INavigationPage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Diagnostics.CodeAnalysis;

namespace MyNet.UI.Navigation.Models;

/// <summary>
/// Defines the contract for a navigation page that can participate in navigation events.
/// </summary>
public interface INavigationPage
{
    /// <summary>
    /// Gets the parent page type, if any.
    /// </summary>
    /// <returns>The parent page type, or null if none.</returns>
    Type? GetParentPageType();

    /// <summary>
    /// Called when the page has been navigated to.
    /// </summary>
    /// <param name="navigationContext">The navigation context.</param>
    void OnNavigated(NavigationContext navigationContext);

    /// <summary>
    /// Called when the page is about to be navigated from.
    /// </summary>
    /// <param name="navigatingContext">The navigating context.</param>
    [SuppressMessage("ReSharper", "UnusedParameter.Global", Justification = "Used by children classes")]
    void OnNavigatingFrom(NavigatingContext navigatingContext);

    /// <summary>
    /// Called when the page is about to be navigated to.
    /// </summary>
    /// <param name="navigatingContext">The navigating context.</param>
    void OnNavigatingTo(NavigatingContext navigatingContext);
}
