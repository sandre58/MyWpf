// -----------------------------------------------------------------------
// <copyright file="Flipper.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class Flipper : MaterialDesignThemes.Wpf.Flipper
{
    static Flipper() => DefaultStyleKeyProperty.OverrideMetadata(typeof(Flipper), new FrameworkPropertyMetadata(typeof(Flipper)));
}
