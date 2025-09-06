// -----------------------------------------------------------------------
// <copyright file="DictionaryExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MyNet.Utilities;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Extension methods for dictionary-like collections.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Adds or updates a value for the specified key.
    /// </summary>
    public static TValue AddOrUpdate<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue value)
        where TKey : notnull
    {
        dictionary[key] = value;

        return dictionary[key];
    }

    /// <summary>
    /// Gets the value for the specified key or adds the provided default value if missing.
    /// </summary>
    public static TValue GetOrAdd<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue newValue)
        where TKey : notnull
    {
        _ = dictionary.TryAdd(key, newValue);

        return dictionary[key];
    }

    /// <summary>
    /// Tries to remove the key if present.
    /// </summary>
    public static void TryRemove<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key)
        where TKey : notnull
    {
        if (!dictionary.ContainsKey(key)) _ = dictionary.Remove(key);
    }

    /// <summary>
    /// Gets the value for the specified key or returns a default when missing.
    /// </summary>
    public static TValue? GetOrDefault<TKey, TValue>(this IDictionary<TKey, TValue> dictionary, TKey key, TValue? defaultValue = default)
        where TKey : notnull => dictionary.TryGetValue(key, out var value) ? value : defaultValue;

    /// <summary>
    /// Merges multiple dictionaries into a new dictionary. Keys are expected to be unique.
    /// </summary>
    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this IEnumerable<IDictionary<TKey, TValue>> enumerable)
        where TKey : notnull
        => enumerable.SelectMany(x => x).ToDictionary(x => x.Key, y => y.Value);

    /// <summary>
    /// Merges two dictionaries into a new dictionary. Keys are expected to be unique.
    /// </summary>
    public static Dictionary<TKey, TValue> Merge<TKey, TValue>(this IDictionary<TKey, TValue> dictionary1, IDictionary<TKey, TValue> dictionary2)
        where TKey : notnull
        => new[] { dictionary1, dictionary2 }.Merge();
}
