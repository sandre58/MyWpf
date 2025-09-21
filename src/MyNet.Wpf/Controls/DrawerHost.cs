// -----------------------------------------------------------------------
// <copyright file="DrawerHost.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class DrawerHost : MaterialDesignThemes.Wpf.DrawerHost
{
    static DrawerHost() => DefaultStyleKeyProperty.OverrideMetadata(typeof(DrawerHost), new FrameworkPropertyMetadata(typeof(DrawerHost)));
}
