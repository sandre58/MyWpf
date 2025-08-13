// -----------------------------------------------------------------------
// <copyright file="ViewManager.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Locators;

/// <summary>
/// Static manager for view resolution and instantiation using registered resolvers and locators.
/// </summary>
public static class ViewManager
{
    private static IViewResolver? _viewResolver;
    private static IViewLocator? _viewLocator;

    /// <summary>
    /// Gets the registered view resolver.
    /// </summary>
    public static IViewResolver ViewResolver => _viewResolver ?? throw new InvalidOperationException("Call Initialize method before use static methods.");

    /// <summary>
    /// Gets the registered view locator.
    /// </summary>
    public static IViewLocator ViewLocator => _viewLocator ?? throw new InvalidOperationException("Call Initialize method before use static methods.");

    /// <summary>
    /// Initializes the view manager with the specified resolver and locator.
    /// </summary>
    /// <param name="viewResolver">The view resolver to use.</param>
    /// <param name="viewLocator">The view locator to use.</param>
    public static void Initialize(IViewResolver viewResolver, IViewLocator viewLocator)
    {
        _viewResolver = viewResolver;
        _viewLocator = viewLocator;
    }

    /// <summary>
    /// Gets a view instance for the specified view model type, or null if not found.
    /// </summary>
    /// <param name="viewModelType">The type of the view model.</param>
    /// <returns>The view instance or null.</returns>
    public static object? GetNullableView(Type viewModelType)
    {
        var viewType = ViewResolver.Resolve(viewModelType);

        return viewType is null ? null : ViewLocator.Get(viewType);
    }

    /// <summary>
    /// Gets a view instance for the specified view model type, or throws if not found.
    /// </summary>
    /// <param name="viewModelType">The type of the view model.</param>
    /// <returns>The view instance.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the view cannot be resolved.</exception>
    public static object GetView(Type viewModelType) => GetNullableView(viewModelType) ?? throw new InvalidOperationException($"{viewModelType} could not be resolved.");

    /// <summary>
    /// Gets a view instance for the specified view type.
    /// </summary>
    /// <param name="viewType">The type of the view.</param>
    /// <returns>The view instance.</returns>
    public static object Get(Type viewType) => ViewLocator.Get(viewType);
}
