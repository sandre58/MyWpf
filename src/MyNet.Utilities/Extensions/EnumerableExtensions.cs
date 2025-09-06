// -----------------------------------------------------------------------
// <copyright file="EnumerableExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MyNet.Utilities;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Extension methods for enumerable sequences.
/// </summary>
public static class EnumerableExtensions
{
    /// <summary>
    /// Converts an <see cref="IEnumerable{T}"/> to an <see cref="ObservableCollection{T}"/>, reusing the source when possible.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <returns>An observable collection containing the sequence elements.</returns>
    public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> source)
        => source as ObservableCollection<T> ?? [.. source];

    /// <summary>
    /// Iterates the sequence and invokes the provided action for each element.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="action">The action to invoke for each element.</param>
    public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
    {
        foreach (var item in source)
        {
            action(item);
        }
    }

    /// <summary>
    /// Iterates the sequence and invokes the provided action for each element including the element index.
    /// </summary>
    /// <typeparam name="TObject">The element type.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="action">The action to invoke for each element receiving the element and its zero-based index.</param>
    public static void ForEach<TObject>(this IEnumerable<TObject> source, Action<TObject, int> action)
    {
        var i = 0;
        foreach (var item in source)
        {
            action(item, i);
            i++;
        }
    }

    /// <summary>
    /// Determines whether the non-generic <see cref="IEnumerable"/> contains the specified value.
    /// </summary>
    /// <param name="collection">The collection to search.</param>
    /// <param name="value">The value to locate.</param>
    /// <returns><c>true</c> if the sequence contains the value; otherwise <c>false</c>.</returns>
    public static bool Contains(this IEnumerable collection, object value) => collection.OfType<object>().Any(x => Equals(x, value));

    /// <summary>
    /// Sums a sequence of <see cref="TimeSpan"/> values projected from the source.
    /// </summary>
    /// <typeparam name="TSource">The source element type.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="selector">A selector that returns a <see cref="TimeSpan"/> for each element.</param>
    /// <returns>The aggregated <see cref="TimeSpan"/>.</returns>
    public static TimeSpan Sum<TSource>(this IEnumerable<TSource> source, Func<TSource, TimeSpan> selector) => source.Select(selector).Aggregate(TimeSpan.Zero, (t1, t2) => t1 + t2);

    /// <summary>
    /// Rotates the sequence by the specified offset, moving the first <paramref name="offset"/> elements to the end.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="values">The sequence to rotate.</param>
    /// <param name="offset">The number of elements to skip from the start.</param>
    /// <returns>A rotated sequence.</returns>
    public static IEnumerable<T> Rotate<T>(this IEnumerable<T> values, int offset)
    {
        var list = values.ToList();
        return list.Skip(offset).Concat(list.Take(offset));
    }

    /// <summary>
    /// Returns the average of a sequence of integers or 0 when the sequence is empty.
    /// </summary>
    public static double AverageOrDefault(this IEnumerable<int> values)
    {
        var list = values.ToList();
        return list.Count == 0 ? 0 : list.Average();
    }

    /// <summary>
    /// Returns the average of a projected integer sequence or <paramref name="defaultValue"/> when the sequence is empty.
    /// </summary>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, int> selector, int defaultValue = 0)
    {
        var list = source.ToList();
        return list.Count == 0 ? defaultValue : list.Average(selector);
    }

    /// <summary>
    /// Returns the average of a sequence of doubles or 0 when the sequence is empty.
    /// </summary>
    public static double AverageOrDefault(this IEnumerable<double> values)
    {
        var list = values.ToList();
        return list.Count == 0 ? 0 : list.Average();
    }

    /// <summary>
    /// Returns the average of a projected double sequence or <paramref name="defaultValue"/> when the sequence is empty.
    /// </summary>
    public static double AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, double> selector, double defaultValue = 0)
    {
        var list = source.ToList();
        return list.Count == 0 ? defaultValue : list.Average(selector);
    }

    /// <summary>
    /// Returns the average of a sequence of decimals or 0 when the sequence is empty.
    /// </summary>
    public static decimal AverageOrDefault(this IEnumerable<decimal> values)
    {
        var list = values.ToList();
        return list.Count == 0 ? 0 : list.Average();
    }

    /// <summary>
    /// Returns the average of a projected decimal sequence or <paramref name="defaultValue"/> when the sequence is empty.
    /// </summary>
    public static decimal AverageOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, decimal> selector, decimal defaultValue = 0)
    {
        var list = source.ToList();
        return list.Count == 0 ? defaultValue : list.Average(selector);
    }

    /// <summary>
    /// Returns the maximum value from the sequence or <paramref name="defaultValue"/> when the sequence is empty.
    /// </summary>
    public static T MaxOrDefault<T>(this IEnumerable<T> values, T defaultValue = default)
        where T : struct
    {
        var list = values.ToList();
        return list.Count == 0 ? defaultValue : list.Max();
    }

    /// <summary>
    /// Returns the maximum projected value from the sequence or <paramref name="defaultValue"/> when the sequence is empty.
    /// </summary>
    public static TResult MaxOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult defaultValue = default)
        where TResult : struct
    {
        var list = source.ToList();
        return list.Count == 0 ? defaultValue : list.Max(selector);
    }

    /// <summary>
    /// Returns the minimum value from the sequence or <paramref name="defaultValue"/> when the sequence is empty.
    /// </summary>
    public static T MinOrDefault<T>(this IEnumerable<T> values, T defaultValue = default)
        where T : struct
    {
        var list = values.ToList();
        return list.Count == 0 ? defaultValue : list.Min();
    }

    /// <summary>
    /// Returns the minimum projected value from the sequence or <paramref name="defaultValue"/> when the sequence is empty.
    /// </summary>
    public static TResult MinOrDefault<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector, TResult defaultValue = default)
        where TResult : struct
    {
        var list = source.ToList();
        return list.Count == 0 ? defaultValue : list.Min(selector);
    }

    /// <summary>
    /// Finds an item by its identifier or returns the default when not found.
    /// </summary>
    /// <typeparam name="T">The element type implementing <see cref="IIdentifiable{TId}"/>.</typeparam>
    /// <typeparam name="TId">The identifier type.</typeparam>
    /// <param name="source">The source sequence.</param>
    /// <param name="id">The identifier to search for.</param>
    /// <returns>The matching element or <c>null</c> if not found.</returns>
    public static T? GetByIdOrDefault<T, TId>(this IEnumerable<T> source, TId? id)
        where T : IIdentifiable<TId>
        => source.FirstOrDefault(x => Equals(x.Id, id));

    /// <summary>
    /// Finds an item by its identifier or throws when not found.
    /// </summary>
    public static T GetById<T, TId>(this IEnumerable<T> source, TId id)
        where T : IIdentifiable<TId>
        => source.First(x => Equals(x.Id, id));

    /// <summary>
    /// Determines whether any element in the sequence has the specified identifier.
    /// </summary>
    public static bool HasId<T, TId>(this IEnumerable<T> source, TId id)
        where T : IIdentifiable<TId>
        => source.Any(x => Equals(x.Id, id));

    /// <summary>
    /// Generates round-robin pairings for the sequence items. If the number of items is odd, a default placeholder is added to make pairing possible.
    /// </summary>
    /// <typeparam name="T">The element type.</typeparam>
    /// <param name="items">The items to pair.</param>
    /// <returns>A collection of rounds, each round being a sequence of pairs.</returns>
    public static IEnumerable<IEnumerable<(T Item1, T Item2)>> RoundRobin<T>(this IEnumerable<T> items)
    {
        var result = new List<List<(T Item1, T Item2)>>();
        var list = items.ToList();

        if (list.Count % 2 != 0)
            list.Add(default!);

        var countRounds = list.Count - 1;
        var countItemsByRound = list.Count / 2;

        for (var roundIndex = 0; roundIndex < countRounds; roundIndex++)
        {
            var round = new List<(T Item1, T Item2)>();

            for (var i = 0; i < countItemsByRound; i++)
            {
                var item1 = list[i];
                var item2 = list[list.Count - i - 1];

                if (item1 is not null && item2 is not null)
                    round.Add((item1, item2));
            }

            result.Add(round);

            // Rotate the list.
            list = [list[0], list[^1], .. list.Skip(1).Take(list.Count - 2)];
        }

        return result;
    }
}
