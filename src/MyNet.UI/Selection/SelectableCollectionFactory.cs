// -----------------------------------------------------------------------
// <copyright file="SelectableCollectionFactory.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Reactive.Concurrency;
using DynamicData;
using MyNet.Observable.Collections.Providers;
using MyNet.UI.Selection.Models;
using MyNet.Utilities.Providers;

namespace MyNet.UI.Selection;

/// <summary>
/// Factory for creating <see cref="SelectableCollection{T}"/> instances from various sources.
/// </summary>
public static class SelectableCollectionFactory
{
    /// <summary>
    /// Creates a <see cref="SelectableCollection{T}"/> from an <see cref="ICollection{T}"/>.
    /// </summary>
    public static SelectableCollection<T> FromCollection<T>(ICollection<T> source, SelectionMode selectionMode = SelectionMode.Multiple, IScheduler? scheduler = null, Func<T, SelectedWrapper<T>>? createWrapper = null)
        where T : notnull
    {
        var collection = new SelectableCollection<T>(new SourceList<T>(), source.IsReadOnly, selectionMode, scheduler, createWrapper);
        collection.AddRange(source);
        return collection;
    }

    /// <summary>
    /// Creates a <see cref="SelectableCollection{T}"/> from an <see cref="IItemsProvider{T}"/>.
    /// </summary>
    public static SelectableCollection<T> FromItemsProvider<T>(IItemsProvider<T> source, bool loadItems = true, SelectionMode selectionMode = SelectionMode.Multiple, IScheduler? scheduler = null, Func<T, SelectedWrapper<T>>? createWrapper = null)
        where T : notnull
        => FromSourceProvider(new ItemsSourceProvider<T>(source, loadItems), selectionMode, scheduler, createWrapper);

    /// <summary>
    /// Creates a <see cref="SelectableCollection{T}"/> from an <see cref="ISourceProvider{T}"/>.
    /// </summary>
    public static SelectableCollection<T> FromSourceProvider<T>(ISourceProvider<T> source, SelectionMode selectionMode = SelectionMode.Multiple, IScheduler? scheduler = null, Func<T, SelectedWrapper<T>>? createWrapper = null)
        where T : notnull
        => FromObservable(source.Connect(), selectionMode, scheduler, createWrapper);

    /// <summary>
    /// Creates a <see cref="SelectableCollection{T}"/> from an observable change set.
    /// </summary>
    public static SelectableCollection<T> FromObservable<T>(IObservable<IChangeSet<T>> source, SelectionMode selectionMode = SelectionMode.Multiple, IScheduler? scheduler = null, Func<T, SelectedWrapper<T>>? createWrapper = null)
        where T : notnull
        => new(new SourceList<T>(source), true, selectionMode, scheduler, createWrapper);

    /// <summary>
    /// Creates an empty <see cref="SelectableCollection{T}"/> with the specified selection mode and scheduler.
    /// </summary>
    public static SelectableCollection<T> Empty<T>(SelectionMode selectionMode = SelectionMode.Multiple, IScheduler? scheduler = null, Func<T, SelectedWrapper<T>>? createWrapper = null)
        where T : notnull
        => new(new SourceList<T>(), false, selectionMode, scheduler, createWrapper);
}
