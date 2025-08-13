// -----------------------------------------------------------------------
// <copyright file="INavigationService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MyNet.UI.Navigation.Models;
using MyNet.Utilities.Suspending;

namespace MyNet.UI.Navigation;

/// <summary>
/// Defines the contract for a navigation service that manages navigation between pages and history.
/// </summary>
public interface INavigationService
{
    /// <summary>
    /// Occurs before navigation is performed.
    /// </summary>
    event EventHandler<NavigatingEventArgs>? Navigating;

    /// <summary>
    /// Occurs after navigation is performed.
    /// </summary>
    event EventHandler<NavigationEventArgs>? Navigated;

    /// <summary>
    /// Occurs when the navigation history is cleared.
    /// </summary>
    event EventHandler? HistoryCleared;

    /// <summary>
    /// Occurs when the navigation service is cleared.
    /// </summary>
    event EventHandler? Cleared;

    /// <summary>
    /// Gets the current navigation context.
    /// </summary>
    NavigationContext? CurrentContext { get; }

    /// <summary>
    /// Gets the suspender for the navigation journal.
    /// </summary>
    Suspender JournalSuspender { get; }

    /// <summary>
    /// Gets the back navigation journal.
    /// </summary>
    IEnumerable<NavigationContext> GetBackJournal();

    /// <summary>
    /// Gets the forward navigation journal.
    /// </summary>
    IEnumerable<NavigationContext> GetForwardJournal();

    /// <summary>
    /// Navigates back in history.
    /// </summary>
    bool GoBack();

    /// <summary>
    /// Determines whether navigation back is possible.
    /// </summary>
    bool CanGoBack();

    /// <summary>
    /// Navigates forward in history.
    /// </summary>
    bool GoForward();

    /// <summary>
    /// Determines whether navigation forward is possible.
    /// </summary>
    bool CanGoForward();

    /// <summary>
    /// Clears the navigation journal.
    /// </summary>
    void ClearJournal();

    /// <summary>
    /// Clears the navigation service.
    /// </summary>
    void Clear();

    /// <summary>
    /// Navigates to the specified page with optional parameters.
    /// </summary>
    /// <param name="page">The page to navigate to.</param>
    /// <param name="navigationParameters">Optional navigation parameters.</param>
    bool NavigateTo(INavigationPage page, NavigationParameters? navigationParameters = null);
}
