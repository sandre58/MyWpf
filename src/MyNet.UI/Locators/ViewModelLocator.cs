// -----------------------------------------------------------------------
// <copyright file="ViewModelLocator.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Locators;

/// <summary>
/// Default implementation of <see cref="IViewModelLocator"/> that retrieves view model instances using a service provider.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ViewModelLocator"/> class.
/// </remarks>
/// <param name="serviceProvider">The service provider used to resolve view model instances.</param>
public class ViewModelLocator(IServiceProvider serviceProvider) : IViewModelLocator
{
    /// <inheritdoc/>
    public object Get(Type viewModelType) => serviceProvider.GetService(viewModelType) ?? Activator.CreateInstance(viewModelType)!;
}
