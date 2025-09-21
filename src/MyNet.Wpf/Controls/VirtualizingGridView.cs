// -----------------------------------------------------------------------
// <copyright file="VirtualizingGridView.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using VirtualizingGridViewBase = Wpf.Ui.Controls.VirtualizingGridView;

namespace MyNet.Wpf.Controls;

public class VirtualizingGridView : VirtualizingGridViewBase
{
    static VirtualizingGridView() => DefaultStyleKeyProperty.OverrideMetadata(typeof(VirtualizingGridView), new FrameworkPropertyMetadata(typeof(VirtualizingGridView)));
}
