// -----------------------------------------------------------------------
// <copyright file="SelectableCollection.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reactive.Concurrency;
using DynamicData;
using DynamicData.Binding;
using MyNet.Observable.Collections;
using MyNet.Observable.Extensions;
using MyNet.UI.Selection.Models;
using MyNet.Utilities;
using MyNet.Utilities.Deferring;

namespace MyNet.UI.Selection;

/// <summary>
/// Represents a collection of selectable items, supporting single or multiple selection modes.
/// Provides selection logic, events, and access to selected items and wrappers.
/// </summary>
/// <typeparam name="T">The type of items in the collection.</typeparam>
public class SelectableCollection<T> : ExtendedWrapperCollection<T, SelectedWrapper<T>>
    where T : notnull
{
    private readonly Deferrer _selectionChangedDeferrer;
    private readonly ReadOnlyObservableCollection<SelectedWrapper<T>> _selectedWrappers;
    private readonly IObservable<IChangeSet<SelectedWrapper<T>>> _observableSelectedWrappers;

    /// <summary>
    /// Gets or sets the selection mode (single or multiple).
    /// </summary>
    public SelectionMode SelectionMode { get; set; }

    /// <summary>
    /// Gets the collection of selected wrappers.
    /// </summary>
    public ReadOnlyObservableCollection<SelectedWrapper<T>> SelectedWrappers => _selectedWrappers;

    /// <summary>
    /// Gets the collection of selected items.
    /// </summary>
    [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery", Justification = "Avoid LINQ Select allocation in hot path")]
    public IEnumerable<T> SelectedItems
    {
        get
        {
            foreach (var wrapper in _selectedWrappers)
                yield return wrapper.Item;
        }
    }

    /// <summary>
    /// Occurs when the selection changes.
    /// </summary>
    public event EventHandler? SelectionChanged;

    /// <summary>
    /// Initializes a new instance of the <see cref="SelectableCollection{T}"/> class with a source list.
    /// </summary>
    public SelectableCollection(SourceList<T> sourceList,
                                bool isReadOnly,
                                SelectionMode selectionMode = SelectionMode.Multiple,
                                IScheduler? scheduler = null,
                                Func<T, SelectedWrapper<T>>? createWrapper = null)
        : base(sourceList, isReadOnly, scheduler, createWrapper ?? (x => new(x)))
    {
        _selectionChangedDeferrer = new Deferrer(() => SelectionChanged?.Invoke(this, EventArgs.Empty));

        SelectionMode = selectionMode;

        var obs = ConnectWrappersSource();

        Disposables.AddRange(
        [
            obs.AutoRefresh(x => x.IsSelected)
                .Filter(y => y is { IsSelectable: true, IsSelected: true })
                .ObserveOnOptional(scheduler)
                .Bind(out _selectedWrappers)
                .Subscribe(),
            obs.WhenPropertyChanged(x => x.IsSelected).Subscribe(x => UpdateSelection(x.Sender)),
            _selectedWrappers.ToObservableChangeSet().Subscribe(_ => _selectionChangedDeferrer.DeferOrExecute())
        ]);

        _observableSelectedWrappers = _selectedWrappers.ToObservableChangeSet();
    }

    /// <summary>
    /// Returns an observable for changes to the selected wrappers.
    /// </summary>
    public IObservable<IChangeSet<SelectedWrapper<T>>> ConnectSelectedWrappers() => _observableSelectedWrappers;

    #region Selection

    /// <summary>
    /// Changes the selection state of the specified item.
    /// </summary>
    /// <param name="item">The item to change selection state for.</param>
    /// <param name="value">True to select; false to unselect.</param>
    public virtual void ChangeSelectState(T item, bool value)
    {
        var original = GetOrCreate(item);
        if (!original.IsSelectable)
            return;
        if (SelectionMode == SelectionMode.Single && value)
        {
            // Deselect all others first
            foreach (var wrapper in WrappersSource)
            {
                if (wrapper.IsSelected && !ReferenceEquals(wrapper, original))
                    wrapper.IsSelected = false;
            }
        }

        original.IsSelected = value;
    }

    /// <summary>
    /// Selects the specified item.
    /// </summary>
    /// <param name="item">The item to select.</param>
    public void Select(T item) => ChangeSelectState(item, true);

    /// <summary>
    /// Selects the specified items.
    /// </summary>
    /// <param name="items">The items to select.</param>
    public void Select(IEnumerable<T> items)
    {
        using (_selectionChangedDeferrer.Defer())
        {
            if (SelectionMode == SelectionMode.Single)
            {
                var first = items.FirstOrDefault();
                if (first is not null)
                    Select(first);
            }
            else
            {
                foreach (var item in items)
                    Select(item);
            }
        }
    }

    /// <summary>
    /// Selects or unselects all items in the collection.
    /// </summary>
    /// <param name="value">True to select all; false to unselect all.</param>
    public void SelectAll(bool value)
    {
        using (_selectionChangedDeferrer.Defer())
        {
            if (SelectionMode == SelectionMode.Single && value)
            {
                var first = this.FirstOrDefault();
                if (first is not null)
                    ChangeSelectState(first, true);
            }
            else
            {
                foreach (var x in this)
                    ChangeSelectState(x, value);
            }
        }
    }

    /// <summary>
    /// Unselects the specified item.
    /// </summary>
    /// <param name="item">The item to unselect.</param>
    public virtual void Unselect(T item) => ChangeSelectState(item, false);

    /// <summary>
    /// Unselects the specified items.
    /// </summary>
    /// <param name="items">The items to unselect.</param>
    public virtual void Unselect(IEnumerable<T> items)
    {
        using (_selectionChangedDeferrer.Defer())
        {
            foreach (var item in items)
                Unselect(item);
        }
    }

    /// <summary>
    /// Clears the selection of all items in the collection.
    /// </summary>
    public virtual void ClearSelection()
    {
        using (_selectionChangedDeferrer.Defer())
        {
            foreach (var x in WrappersSource)
                x.IsSelected = false;
        }
    }

    /// <summary>
    /// Sets the selection to the specified items, clearing previous selection.
    /// </summary>
    /// <param name="items">The items to select.</param>
    public void SetSelection(IEnumerable<T> items)
    {
        using (_selectionChangedDeferrer.Defer())
        {
            ClearSelection();
            Select(items);
        }
    }

    private void UpdateSelection(SelectedWrapper<T> wrapper)
    {
        if (SelectionMode != SelectionMode.Single || !wrapper.IsSelected)
            return;
    }

    #endregion Selection
}
