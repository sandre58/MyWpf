// -----------------------------------------------------------------------
// <copyright file="DynamicScrollBar.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

using DynamicScrollBarBase = Wpf.Ui.Controls.DynamicScrollBar;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class DynamicScrollBar : DynamicScrollBarBase
{
    static DynamicScrollBar() => DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicScrollBar), new FrameworkPropertyMetadata(typeof(DynamicScrollBar)));
}
