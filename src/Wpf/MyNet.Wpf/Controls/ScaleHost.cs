// -----------------------------------------------------------------------
// <copyright file="ScaleHost.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;

namespace MyNet.Wpf.Controls;

/// <summary>
/// Internal use only.
/// </summary>
public class ScaleHost : FrameworkElement
{
    public static readonly DependencyProperty ScaleProperty = DependencyProperty.Register(
        "Scale", typeof(double), typeof(ScaleHost), new PropertyMetadata(0.0));

    public double Scale
    {
        get => (double)GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }
}
