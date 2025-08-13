// -----------------------------------------------------------------------
// <copyright file="ViewModelManager.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using MyNet.UI.Extensions;

namespace MyNet.UI.Locators;

/// <summary>
/// Static manager for view model resolution and instantiation using registered resolvers and locators.
/// </summary>
public static class ViewModelManager
{
    private static IViewModelResolver? _viewModelResolver;
    private static IViewModelLocator? _viewModelLocator;

    /// <summary>
    /// Gets the registered view model resolver.
    /// </summary>
    public static IViewModelResolver ViewModelResolver => _viewModelResolver ?? throw new InvalidOperationException("Call Initialize method before use static methods.");

    /// <summary>
    /// Gets the registered view model locator.
    /// </summary>
    public static IViewModelLocator ViewModelLocator => _viewModelLocator ?? throw new InvalidOperationException("Call Initialize method before use static methods.");

    /// <summary>
    /// Gets an instance of the specified view model type.
    /// </summary>
    /// <typeparam name="T">The type of the view model.</typeparam>
    /// <returns>The view model instance.</returns>
    public static T Get<T>() => ViewModelLocator.Get<T>();

    /// <summary>
    /// Gets an instance of the specified view model type.
    /// </summary>
    /// <param name="viewType">The type of the view model.</param>
    /// <returns>The view model instance.</returns>
    public static object Get(Type viewType) => ViewModelLocator.Get(viewType);

    /// <summary>
    /// Initializes the view model manager with the specified resolver and locator.
    /// </summary>
    /// <param name="viewModelResolver">The view model resolver to use.</param>
    /// <param name="viewModelLocator">The view model locator to use.</param>
    public static void Initialize(IViewModelResolver viewModelResolver, IViewModelLocator viewModelLocator)
    {
        _viewModelResolver = viewModelResolver;
        _viewModelLocator = viewModelLocator;
    }

    /// <summary>
    /// Gets a view model instance for the specified view type, or throws if not found.
    /// </summary>
    /// <param name="viewType">The type of the view.</param>
    /// <returns>The view model instance.</returns>
    /// <exception cref="InvalidOperationException">Thrown if the view model cannot be resolved.</exception>
    public static object GetViewModel(Type viewType)
    {
        var viewModelType = ViewModelResolver.Resolve(viewType);

        return viewModelType is null
            ? throw new InvalidOperationException($"{viewModelType} could not be resolved.")
            : ViewModelLocator.Get(viewModelType);
    }
}
