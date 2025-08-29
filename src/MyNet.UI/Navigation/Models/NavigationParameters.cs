// -----------------------------------------------------------------------
// <copyright file="NavigationParameters.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MyNet.Utilities;

namespace MyNet.UI.Navigation.Models;

/// <summary>
/// Represents a collection of navigation parameters passed between pages.
/// </summary>
public class NavigationParameters : INavigationParameters, ICloneable<NavigationParameters>, ISimilar<NavigationParameters>
{
    private readonly List<KeyValuePair<string, object?>> _entries = [];

    /// <summary>
    /// Gets an empty instance of <see cref="NavigationParameters"/>.
    /// </summary>
    public static NavigationParameters Empty => [];

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationParameters"/> class.
    /// </summary>
    public NavigationParameters() { }

    /// <summary>
    /// Initializes a new instance of the <see cref="NavigationParameters"/> class from a query string.
    /// </summary>
    /// <param name="query">The query string to parse.</param>
    public NavigationParameters(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
            return;
        var num = query.Length;
        for (var i = query.Length > 0 && query[0] == '?' ? 1 : 0; i < num; i++)
        {
            var startIndex = i;
            var num4 = -1;
            while (i < num)
            {
                var ch = query[i];
                if (ch == '=')
                {
                    if (num4 < 0)
                        num4 = i;
                }
                else if (ch == '&')
                {
                    break;
                }

                i++;
            }

            string? key = null;
            string value;
            if (num4 >= 0)
            {
                key = query.Substring(startIndex, num4);
                value = query.Substring(num4 + 1, i - num4 - 1);
            }
            else
            {
                value = query.Substring(startIndex, i);
            }

            if (key is not null)
                Add(Uri.UnescapeDataString(key), Uri.UnescapeDataString(value));
        }
    }

    /// <summary>
    /// Gets the number of parameters.
    /// </summary>
    public int Count => _entries.Count;

    /// <summary>
    /// Gets the keys of all parameters.
    /// </summary>
    public IEnumerable<string> Keys => _entries.Select(x => x.Key);

    /// <summary>
    /// Gets the value of a parameter by key.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    public object? this[string key] => _entries.FirstOrDefault(x => string.Equals(x.Key, key, StringComparison.Ordinal)).Value;

    /// <summary>
    /// Returns an enumerator that iterates through the parameters.
    /// </summary>
    public IEnumerator<KeyValuePair<string, object?>> GetEnumerator() => _entries.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    /// <summary>
    /// Adds a parameter with the specified key and value.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The parameter value.</param>
    public void Add(string key, object? value) => _entries.Add(new KeyValuePair<string, object?>(key, value));

    /// <summary>
    /// Adds or updates a parameter value by key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The parameter value.</param>
    public void AddOrUpdate<T>(string key, T? value)
    {
        Remove([key]);
        Add(key, value);
    }

    /// <summary>
    /// Determines whether the parameter with the specified key exists.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    public bool ContainsKey(string key) => _entries.Any(kvp => string.Equals(kvp.Key, key, StringComparison.Ordinal));

    /// <summary>
    /// Determines whether the parameter with the specified key exists.
    /// </summary>
    /// <param name="key">The parameter key.</param>
    public bool Has(string key) => Keys.Contains(key);

    /// <summary>
    /// Gets the value of the parameter by key, or a default value if not found.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The parameter key.</param>
    /// <param name="defaultValue">The default value to return if not found.</param>
    public T? Get<T>(string key, T? defaultValue = default)
    {
        var item = _entries.FirstOrDefault(x => string.Equals(x.Key, key, StringComparison.Ordinal));

        return item.Value is null
            ? defaultValue
            : item.Value.GetType() == typeof(T) || typeof(T).GetTypeInfo().IsAssignableFrom(item.Value.GetType().GetTypeInfo())
                ? (T)item.Value
                : defaultValue;
    }

    /// <summary>
    /// Tries to get the value of the parameter by key.
    /// </summary>
    /// <typeparam name="T">The type of the value.</typeparam>
    /// <param name="key">The parameter key.</param>
    /// <param name="value">The value of the parameter if found.</param>
    /// <returns>True if the parameter exists; otherwise, false.</returns>
    public bool TryGetValue<T>(string key, out T? value)
    {
        var item = _entries.FirstOrDefault(x => string.Equals(x.Key, key, StringComparison.Ordinal));

        value = item.Value is null
            ? default
            : item.Value.GetType() == typeof(T) || typeof(T).GetTypeInfo().IsAssignableFrom(item.Value.GetType().GetTypeInfo())
                ? (T)item.Value
                : (T)Convert.ChangeType(item.Value, typeof(T), CultureInfo.InvariantCulture);

        return !Equals(value, null);
    }

    /// <summary>
    /// Gets all values for the specified key.
    /// </summary>
    /// <typeparam name="T">The type of the values.</typeparam>
    /// <param name="key">The parameter key.</param>
    /// <returns>An enumerable of values for the key.</returns>
    public IEnumerable<T?> GetValues<T>(string key)
    {
        var values = new List<T?>();
        foreach (var value in _entries.Where(kvp => string.Equals(kvp.Key, key, StringComparison.Ordinal)).Select(x => x.Value))
        {
            if (value is null)
                values.Add(default);
            else if (value.GetType() == typeof(T))
                values.Add((T)value);
            else if (typeof(T).GetTypeInfo().IsAssignableFrom(value.GetType().GetTypeInfo()))
                values.Add((T)value);
            else
                values.Add((T)Convert.ChangeType(value, typeof(T), CultureInfo.InvariantCulture));
        }

        return values.AsEnumerable();
    }

    /// <summary>
    /// Clears all parameters.
    /// </summary>
    public void Clear() => _entries.Clear();

    /// <summary>
    /// Removes parameters by their keys.
    /// </summary>
    /// <param name="keys">The keys of the parameters to remove.</param>
    public void Remove(string[] keys)
    {
        var toRemove = _entries.Where(x => keys.Contains(x.Key)).ToList();
        toRemove.ForEach(x => _entries.Remove(x));
    }

    /// <summary>
    /// Returns a string representation of the parameters.
    /// </summary>
    public override string ToString() => $"[{string.Join(", ", _entries.Select(x => $"{x.Key} = {x.Value}"))}]";

    /// <inheritdoc/>
    public override bool Equals(object? obj) => obj is NavigationParameters p && _entries.Count == p.Count && _entries.TrueForAll(x => p.ContainsKey(x.Key) && Equals(p[x.Key], x.Value));

    /// <inheritdoc/>
    public override int GetHashCode() => _entries.GetHashCode();

    /// <summary>
    /// Creates a deep copy of the navigation parameters.
    /// </summary>
    /// <returns>A cloned instance of <see cref="NavigationParameters"/>.</returns>
    public NavigationParameters Clone()
    {
        var result = new NavigationParameters();

        foreach (var item in this)
            result.Add(item.Key, item.Value);

        return result;
    }

    /// <inheritdoc/>
    public bool IsSimilar(NavigationParameters? obj) => obj?.All(x => Equals(Get<object>(x.Key), x.Value)) == true;
}
