// -----------------------------------------------------------------------
// <copyright file="HintProxyFabric.MultiComboBox.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;

namespace MyNet.Wpf.Controls.HintProxy;

public class MultiComboBoxHintProxy : IHintProxy
{
    private readonly MultiComboBox _comboBox;
    private bool _disposedValue;

    public MultiComboBoxHintProxy(MultiComboBox comboBox)
    {
        _comboBox = comboBox ?? throw new ArgumentNullException(nameof(comboBox));

        _comboBox.Loaded += ComboBoxLoaded;
        _comboBox.IsVisibleChanged += ComboBoxIsVisibleChanged;
        _comboBox.IsKeyboardFocusWithinChanged += ComboBoxIsKeyboardFocusWithinChanged;
        _comboBox.SelectionChanged += ComboBoxSelectionChanged;
        _comboBox.TextChanged += ComboBoxTextChanged;
    }

    public bool IsLoaded => _comboBox.IsLoaded;

    public bool IsVisible => _comboBox.IsVisible;

    public bool IsEmpty() => (_comboBox.SelectedItems == null || _comboBox.SelectedItems.Count == 0) && (!_comboBox.IsEditable || string.IsNullOrEmpty(_comboBox.Text));

    public bool IsFocused() => _comboBox is { IsEditable: true, IsKeyboardFocusWithin: true };

    public event EventHandler? ContentChanged;

    public event EventHandler? IsVisibleChanged;

    public event EventHandler? Loaded;

    public event EventHandler? FocusedChanged;

    private void ComboBoxSelectionChanged(object? sender, SelectionChangedEventArgs e) => _comboBox.Dispatcher.InvokeAsync(() => ContentChanged?.Invoke(sender, EventArgs.Empty));

    private void ComboBoxTextChanged(object? sender, EventArgs e) => _comboBox.Dispatcher.InvokeAsync(() => ContentChanged?.Invoke(sender, EventArgs.Empty));

    private void ComboBoxIsVisibleChanged(object? sender, DependencyPropertyChangedEventArgs e) => IsVisibleChanged?.Invoke(sender, EventArgs.Empty);

    private void ComboBoxLoaded(object? sender, RoutedEventArgs e) => Loaded?.Invoke(sender, EventArgs.Empty);

    private void ComboBoxIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e) => FocusedChanged?.Invoke(sender, EventArgs.Empty);

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _comboBox.Loaded -= ComboBoxLoaded;
                _comboBox.IsVisibleChanged -= ComboBoxIsVisibleChanged;
                _comboBox.IsKeyboardFocusWithinChanged -= ComboBoxIsKeyboardFocusWithinChanged;
                _comboBox.SelectionChanged -= ComboBoxSelectionChanged;
                _comboBox.TextChanged -= ComboBoxTextChanged;
            }

            _disposedValue = true;
        }
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
