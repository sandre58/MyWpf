// -----------------------------------------------------------------------
// <copyright file="VirtualizingWrapPanel.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using VirtualizingWrapPanelBase = Wpf.Ui.Controls.VirtualizingWrapPanel;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class VirtualizingWrapPanel : VirtualizingWrapPanelBase
{
    static VirtualizingWrapPanel() => DefaultStyleKeyProperty.OverrideMetadata(typeof(VirtualizingWrapPanel), new FrameworkPropertyMetadata(typeof(VirtualizingWrapPanel)));
}
