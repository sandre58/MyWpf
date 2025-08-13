// -----------------------------------------------------------------------
// <copyright file="IViewLocator.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Locators;

/// <summary>
/// Defines the contract for a view locator that can register and retrieve view instances by type.
/// </summary>
public interface IViewLocator
{
    /// <summary>
    /// Registers a view type with a factory method for instance creation.
    /// </summary>
    /// <param name="type">The type of the view to register.</param>
    /// <param name="createInstance">The factory method to create the view instance.</param>
    void Register(Type type, Func<object> createInstance);

    /// <summary>
    /// Gets an instance of the specified view type.
    /// </summary>
    /// <param name="viewType">The type of the view to retrieve.</param>
    /// <returns>The view instance.</returns>
    object Get(Type viewType);
}
