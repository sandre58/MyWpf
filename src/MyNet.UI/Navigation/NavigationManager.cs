// -----------------------------------------------------------------------
// <copyright file="NavigationManager.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MyNet.UI.Locators;
using MyNet.UI.Navigation.Models;

namespace MyNet.UI.Navigation;

/// <summary>
/// Provides static methods to manage navigation between pages and handle navigation parameters.
/// </summary>
public static class NavigationManager
{
    /// <summary>
    /// The default parameter key for item navigation.
    /// </summary>
    public const string ItemParameter = "Item";

    private static INavigationService? _navigationService;
    private static IViewModelLocator? _viewModelLocator;

    /// <summary>
    /// Gets the current navigation context.
    /// </summary>
    public static NavigationContext? CurrentContext => _navigationService?.CurrentContext;

    /// <summary>
    /// Initializes the navigation manager with the specified navigation service and view model locator.
    /// </summary>
    /// <param name="navigationService">The navigation service.</param>
    /// <param name="viewModelLocator">The view model locator.</param>
    public static void Initialize(INavigationService navigationService, IViewModelLocator viewModelLocator)
        => (_navigationService, _viewModelLocator) = (navigationService, viewModelLocator);

    /// <summary>
    /// Navigates to the specified page type with a parameter value and key.
    /// </summary>
    /// <typeparam name="TPage">The type of the page to navigate to.</typeparam>
    /// <param name="paramValue">The parameter value.</param>
    /// <param name="paramKey">The parameter key.</param>
    public static void NavigateTo<TPage>(object paramValue, string paramKey = ItemParameter)
        where TPage : INavigationPage
        => NavigateTo(typeof(TPage), paramValue, paramKey);

    /// <summary>
    /// Navigates to the specified page type with parameters.
    /// </summary>
    /// <typeparam name="TPage">The type of the page to navigate to.</typeparam>
    /// <param name="parameters">The navigation parameters.</param>
    /// <returns>True if navigation succeeded; otherwise, false.</returns>
    public static bool NavigateTo<TPage>(IEnumerable<KeyValuePair<string, object?>>? parameters = null)
        where TPage : INavigationPage
        => NavigateTo(typeof(TPage), parameters);

    /// <summary>
    /// Navigates to the specified page type with a parameter value and key.
    /// </summary>
    /// <param name="typePage">The type of the page to navigate to.</param>
    /// <param name="paramValue">The parameter value.</param>
    /// <param name="paramKey">The parameter key.</param>
    /// <returns>True if navigation succeeded; otherwise, false.</returns>
    public static bool NavigateTo(Type typePage, object paramValue, string paramKey = ItemParameter)
        => NavigateTo(typePage, [new(paramKey, paramValue)]);

    /// <summary>
    /// Navigates to the specified page type with parameters.
    /// </summary>
    /// <param name="typePage">The type of the page to navigate to.</param>
    /// <param name="parameters">The navigation parameters.</param>
    /// <returns>True if navigation succeeded; otherwise, false.</returns>
    public static bool NavigateTo(Type typePage, IEnumerable<KeyValuePair<string, object?>>? parameters = null)
        => _viewModelLocator?.Get(typePage) is INavigationPage page && NavigateTo(page, parameters);

    /// <summary>
    /// Navigates to the specified page with a parameter value and key.
    /// </summary>
    /// <param name="page">The page to navigate to.</param>
    /// <param name="paramValue">The parameter value.</param>
    /// <param name="paramKey">The parameter key.</param>
    /// <returns>True if navigation succeeded; otherwise, false.</returns>
    public static bool NavigateTo(INavigationPage page, object? paramValue = null, string paramKey = ItemParameter)
        => NavigateTo(page, paramValue is null ? null : new List<KeyValuePair<string, object?>>(1) { new(paramKey, paramValue) });

    /// <summary>
    /// Navigates to the specified page with parameters.
    /// </summary>
    /// <param name="page">The page to navigate to.</param>
    /// <param name="parameters">The navigation parameters.</param>
    /// <returns>True if navigation succeeded; otherwise, false.</returns>
    public static bool NavigateTo(INavigationPage page, IEnumerable<KeyValuePair<string, object?>>? parameters = null) => _navigationService?.NavigateTo(page, ToNavigationParameters(parameters)) ?? false;

    /// <summary>
    /// Navigates back in history.
    /// </summary>
    public static void GoBack() => _navigationService?.GoBack();

    /// <summary>
    /// Determines whether navigation back is possible.
    /// </summary>
    /// <returns>True if navigation back is possible; otherwise, false.</returns>
    public static bool CanGoBack() => _navigationService?.CanGoBack() ?? false;

    /// <summary>
    /// Navigates forward in history.
    /// </summary>
    public static void GoForward() => _navigationService?.GoForward();

    /// <summary>
    /// Determines whether navigation forward is possible.
    /// </summary>
    /// <returns>True if navigation forward is possible; otherwise, false.</returns>
    public static bool CanGoForward() => _navigationService?.CanGoForward() ?? false;

    /// <summary>
    /// Clears the navigation history.
    /// </summary>
    public static void ClearHistory() => _navigationService?.ClearJournal();

    /// <summary>
    /// Clears the navigation service.
    /// </summary>
    public static void Clear() => _navigationService?.Clear();

    /// <summary>
    /// Converts a collection of key-value pairs to <see cref="NavigationParameters"/>.
    /// </summary>
    /// <param name="parameters">The key-value pairs to convert.</param>
    /// <returns>A <see cref="NavigationParameters"/> instance.</returns>
    private static NavigationParameters? ToNavigationParameters(IEnumerable<KeyValuePair<string, object?>>? parameters)
    {
        if (parameters is null) return null;

        var res = new NavigationParameters();

        foreach (var parameter in parameters)
            res.Add(parameter.Key, parameter.Value);

        return res;
    }
}
