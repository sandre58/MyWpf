// -----------------------------------------------------------------------
// <copyright file="Underline.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class Underline : MaterialDesignThemes.Wpf.Underline
{
    static Underline() => DefaultStyleKeyProperty.OverrideMetadata(typeof(Underline), new FrameworkPropertyMetadata(typeof(Underline)));
}
