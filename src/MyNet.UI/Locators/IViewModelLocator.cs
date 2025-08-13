// -----------------------------------------------------------------------
// <copyright file="IViewModelLocator.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Locators;

/// <summary>
/// Defines the contract for a view model locator that can retrieve view model instances by type.
/// </summary>
public interface IViewModelLocator
{
    /// <summary>
    /// Gets an instance of the specified view model type.
    /// </summary>
    /// <param name="viewModelType">The type of the view model to retrieve.</param>
    /// <returns>The view model instance.</returns>
    object Get(Type viewModelType);
}
