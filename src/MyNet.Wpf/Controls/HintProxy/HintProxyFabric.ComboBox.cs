// -----------------------------------------------------------------------
// <copyright file="HintProxyFabric.ComboBox.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;

namespace MyNet.Wpf.Controls.HintProxy;

public class ComboBoxHintProxy : IHintProxy
{
    private readonly ComboBox _comboBox;
    private readonly TextChangedEventHandler _comboBoxTextChangedEventHandler;
    private bool _disposedValue;

    public ComboBoxHintProxy(ComboBox comboBox)
    {
        ArgumentNullException.ThrowIfNull(comboBox);

        _comboBox = comboBox;
        _comboBoxTextChangedEventHandler = ComboBoxTextChanged;
        _comboBox.AddHandler(TextBoxBase.TextChangedEvent, _comboBoxTextChangedEventHandler);
        _comboBox.SelectionChanged += ComboBoxSelectionChanged;
        _comboBox.Loaded += ComboBoxLoaded;
        _comboBox.IsVisibleChanged += ComboBoxIsVisibleChanged;
        _comboBox.IsKeyboardFocusWithinChanged += ComboBoxIsKeyboardFocusWithinChanged;
    }

    public bool IsLoaded => _comboBox.IsLoaded;

    public bool IsVisible => _comboBox.IsVisible;

    public virtual bool IsEmpty() => string.IsNullOrEmpty(_comboBox.Text);

    public bool IsFocused() => _comboBox is { IsEditable: true, IsKeyboardFocusWithin: true };

    public event EventHandler? ContentChanged;

    public event EventHandler? IsVisibleChanged;

    public event EventHandler? Loaded;
    public event EventHandler? FocusedChanged;

    private void ComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        => _comboBox.Dispatcher.InvokeAsync(() => ContentChanged?.Invoke(sender, EventArgs.Empty));

    private void ComboBoxIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        => IsVisibleChanged?.Invoke(sender, EventArgs.Empty);

    private void ComboBoxLoaded(object sender, RoutedEventArgs e)
        => Loaded?.Invoke(sender, EventArgs.Empty);

    private void ComboBoxTextChanged(object sender, TextChangedEventArgs e)
        => ContentChanged?.Invoke(sender, EventArgs.Empty);

    private void ComboBoxIsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        => FocusedChanged?.Invoke(sender, EventArgs.Empty);

    protected virtual void Dispose(bool disposing)
    {
        if (!_disposedValue)
        {
            if (disposing)
            {
                _comboBox.RemoveHandler(TextBoxBase.TextChangedEvent, _comboBoxTextChangedEventHandler);
                _comboBox.Loaded -= ComboBoxLoaded;
                _comboBox.IsVisibleChanged -= ComboBoxIsVisibleChanged;
                _comboBox.SelectionChanged -= ComboBoxSelectionChanged;
                _comboBox.IsKeyboardFocusWithinChanged -= ComboBoxIsKeyboardFocusWithinChanged;
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
