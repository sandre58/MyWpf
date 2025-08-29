// -----------------------------------------------------------------------
// <copyright file="GeometryIcon.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace MyNet.Wpf.Controls;

public class GeometryIcon : Control
{

    static GeometryIcon() => DefaultStyleKeyProperty.OverrideMetadata(typeof(GeometryIcon), new FrameworkPropertyMetadata(typeof(GeometryIcon)));

    public static readonly DependencyProperty DataProperty
        = DependencyProperty.RegisterAttached(nameof(Data), typeof(Geometry), typeof(GeometryIcon), new PropertyMetadata(null));

    /// <summary>
    /// Gets the icon path data.
    /// </summary>
    public Geometry Data
    {
        get => (Geometry)GetValue(DataProperty);
        set => SetValue(DataProperty, value);
    }
}
