// -----------------------------------------------------------------------
// <copyright file="PackIcon.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class PackIcon : MaterialDesignThemes.Wpf.PackIcon
{
    static PackIcon() => DefaultStyleKeyProperty.OverrideMetadata(typeof(PackIcon), new FrameworkPropertyMetadata(typeof(PackIcon)));
}
