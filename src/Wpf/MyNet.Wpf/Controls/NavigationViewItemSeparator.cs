// -----------------------------------------------------------------------
// <copyright file="NavigationViewItemSeparator.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class NavigationViewItemSeparator : Separator
{
    static NavigationViewItemSeparator() => DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationViewItemSeparator), new FrameworkPropertyMetadata(typeof(NavigationViewItemSeparator)));
}
