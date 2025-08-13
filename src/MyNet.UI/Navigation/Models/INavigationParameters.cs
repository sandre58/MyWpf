// -----------------------------------------------------------------------
// <copyright file="INavigationParameters.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace MyNet.UI.Navigation.Models;

/// <summary>
/// Defines the contract for navigation parameters passed between pages.
/// </summary>
public interface INavigationParameters : IEnumerable<KeyValuePair<string, object?>>
{
    /// <summary>
    /// Adds or updates a parameter value by key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The parameter value.</param>
    void AddOrUpdate<T>(string key, T value);

    /// <summary>
    /// Determines whether the parameter with the specified key exists.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    bool Has(string key);

    /// <summary>
    /// Gets the value of the parameter by key, or a default value if not found.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The parameter key.</param>
    /// <param name="defaultValue">The default value to return if not found.</param>
    T? Get<T>(string key, T? defaultValue = default);

    /// <summary>
    /// Clears all parameters.
    /// </summary>
    void Clear();

    /// <summary>
    /// Removes parameters by their keys.
    /// </summary>
    /// <param name="keys">The keys of the parameters to remove.</param>
    void Remove(string[] keys);
}
