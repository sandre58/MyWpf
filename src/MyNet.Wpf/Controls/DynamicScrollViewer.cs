// -----------------------------------------------------------------------
// <copyright file="DynamicScrollViewer.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

using DynamicScrollViewerBase = Wpf.Ui.Controls.DynamicScrollViewer;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class DynamicScrollViewer : DynamicScrollViewerBase
{
    static DynamicScrollViewer() => DefaultStyleKeyProperty.OverrideMetadata(typeof(DynamicScrollViewer), new FrameworkPropertyMetadata(typeof(DynamicScrollViewer)));
}
