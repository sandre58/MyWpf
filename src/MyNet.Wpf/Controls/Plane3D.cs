// -----------------------------------------------------------------------
// <copyright file="Plane3D.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class Plane3D : MaterialDesignThemes.Wpf.Plane3D
{
    static Plane3D() => DefaultStyleKeyProperty.OverrideMetadata(typeof(Plane3D), new FrameworkPropertyMetadata(typeof(Plane3D)));
}
