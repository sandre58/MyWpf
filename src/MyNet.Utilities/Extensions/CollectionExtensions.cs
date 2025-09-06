// -----------------------------------------------------------------------
// <copyright file="CollectionExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MyNet.Utilities;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Extension methods for collections.
/// </summary>
public static class CollectionExtensions
{
    /// <summary>
    /// Replaces the contents of the collection with the specified items.
    /// </summary>
    public static void Set<T>(this ICollection<T> collection, IEnumerable<T>? items)
    {
        collection.Clear();
        collection.AddRange(items);
    }

    /// <summary>
    /// Adds a range of items to the collection.
    /// </summary>
    public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T>? items)
    {
        if (collection is List<T> list)
        {
            list.AddRange(items ?? []);
        }
        else
        {
            foreach (var item in items ?? [])
                collection.Add(item);
        }
    }

    /// <summary>
    /// Sorts the collection in place using the specified key selector.
    /// </summary>
    public static void Sort<T, TKey>(this ICollection<T> collection, Func<T, TKey> keySelector)
    {
        var items = collection.OrderBy(keySelector).ToArray();
        collection.Set(items);
    }

    /// <summary>
    /// Sorts the collection in place using the specified key selector and comparer.
    /// </summary>
    public static void Sort<T, TKey>(this ICollection<T> collection, Func<T, TKey> keySelector, IComparer<TKey> comparer)
    {
        var items = collection.OrderBy(keySelector, comparer).ToArray();
        collection.Set(items);
    }

    /// <summary>
    /// Sorts the collection in descending order using the specified key selector.
    /// </summary>
    public static void SortDescending<T, TKey>(this ICollection<T> collection, Func<T, TKey> keySelector)
    {
        var items = collection.OrderByDescending(keySelector).ToArray();
        collection.Set(items);
    }
}
