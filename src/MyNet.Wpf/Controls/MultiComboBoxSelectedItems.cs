// -----------------------------------------------------------------------
// <copyright file="MultiComboBoxSelectedItems.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace MyNet.Wpf.Controls;

public class MultiComboBoxSelectedItems : ItemsControl
{
    protected override bool IsItemItsOwnContainerOverride(object item) => item is MultiComboBoxSelectedItem;

    protected override DependencyObject GetContainerForItemOverride() => new MultiComboBoxSelectedItem();

    protected override void ClearContainerForItemOverride(DependencyObject element, object item) => base.ClearContainerForItemOverride(element, item as MultiComboBoxSelectedItem);

    protected override void PrepareContainerForItemOverride(DependencyObject element, object item) => base.PrepareContainerForItemOverride(element, item as MultiComboBoxSelectedItem);
}