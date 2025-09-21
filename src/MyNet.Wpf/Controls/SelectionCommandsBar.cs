// -----------------------------------------------------------------------
// <copyright file="SelectionCommandsBar.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MyNet.Wpf.Controls;

public class SelectionCommandsBar : ToolBar
{
    static SelectionCommandsBar() => DefaultStyleKeyProperty.OverrideMetadata(typeof(SelectionCommandsBar), new FrameworkPropertyMetadata(typeof(SelectionCommandsBar)));

    #region SelectedCount

    public static readonly DependencyProperty SelectedCountProperty
        = DependencyProperty.RegisterAttached(nameof(SelectedCount), typeof(int), typeof(SelectionCommandsBar));

    public int SelectedCount
    {
        get => (int)GetValue(SelectedCountProperty);
        set => SetValue(SelectedCountProperty, value);
    }

    #endregion

    #region VisibilityWhenEmpty

    public static readonly DependencyProperty VisibilityWhenEmptyProperty
        = DependencyProperty.RegisterAttached(nameof(VisibilityWhenEmpty), typeof(Visibility), typeof(SelectionCommandsBar), new PropertyMetadata(Visibility.Hidden));

    public Visibility VisibilityWhenEmpty
    {
        get => (Visibility)GetValue(VisibilityWhenEmptyProperty);
        set => SetValue(VisibilityWhenEmptyProperty, value);
    }

    #endregion

    #region UnselectAllCommand

    public static readonly DependencyProperty UnselectAllCommandProperty
        = DependencyProperty.RegisterAttached(nameof(UnselectAllCommand), typeof(ICommand), typeof(SelectionCommandsBar));

    public ICommand UnselectAllCommand
    {
        get => (ICommand)GetValue(UnselectAllCommandProperty);
        set => SetValue(UnselectAllCommandProperty, value);
    }

    #endregion
}
