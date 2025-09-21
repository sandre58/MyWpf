// -----------------------------------------------------------------------
// <copyright file="ScrollSelectedItemBehavior.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using MyNet.Wpf.Extensions;

namespace MyNet.Wpf.Behaviors;

public sealed class ScrollSelectedItemBehavior : Behavior<ListBox>
{
    public static readonly DependencyProperty ItemProperty =
DependencyProperty.Register(nameof(Item), typeof(object),
    typeof(ScrollSelectedItemBehavior));

    public object Item
    {
        get => GetValue(ItemProperty);
        set => SetValue(ItemProperty, value);
    }

    protected override void OnAttached()
    {
        base.OnAttached();

        AssociatedObject.OnLoading<ListBox>(_ => AddBehavior());
    }

    private void AddBehavior()
    {
        var scrollViewer = AssociatedObject.FindVisualChild<ScrollViewer>();
        var index = AssociatedObject.Items.IndexOf(Item);

        if (scrollViewer is null || AssociatedObject.Items.Count == 0 || index <= -1) return;

        scrollViewer.ScrollToVerticalOffset(scrollViewer.ScrollableHeight * index / AssociatedObject.Items.Count);
    }
}
