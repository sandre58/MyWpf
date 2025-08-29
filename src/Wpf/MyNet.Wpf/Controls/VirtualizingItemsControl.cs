// -----------------------------------------------------------------------
// <copyright file="VirtualizingItemsControl.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using VirtualizingItemsControlBase = Wpf.Ui.Controls.VirtualizingItemsControl;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class VirtualizingItemsControl : VirtualizingItemsControlBase
{
    static VirtualizingItemsControl() => DefaultStyleKeyProperty.OverrideMetadata(typeof(VirtualizingItemsControl), new FrameworkPropertyMetadata(typeof(VirtualizingItemsControl)));
}
