// -----------------------------------------------------------------------
// <copyright file="IThemeExtension.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace MyNet.UI.Theming;

/// <summary>
/// Defines the contract for a theme extension that can provide additional resources based on the current theme.
/// </summary>
public interface IThemeExtension
{
    /// <summary>
    /// Gets the resources provided by the extension for the specified theme.
    /// </summary>
    /// <param name="theme">The current theme.</param>
    /// <returns>A dictionary of resource keys and values.</returns>
    IDictionary<string, object?> GetResources(Theme theme);
}
