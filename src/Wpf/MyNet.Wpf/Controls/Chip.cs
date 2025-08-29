// -----------------------------------------------------------------------
// <copyright file="Chip.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class Chip : MaterialDesignThemes.Wpf.Chip
{
    static Chip() => DefaultStyleKeyProperty.OverrideMetadata(typeof(Chip), new FrameworkPropertyMetadata(typeof(Chip)));
}
