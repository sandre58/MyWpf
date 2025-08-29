// -----------------------------------------------------------------------
// <copyright file="RatingBarButton.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.ComponentModel;
using System.Windows;
using System.Windows.Controls.Primitives;

namespace MyNet.Wpf.Controls;

[ToolboxItem(true)]
public class RatingBarButton : ButtonBase
{
    static RatingBarButton() => DefaultStyleKeyProperty.OverrideMetadata(typeof(RatingBarButton), new FrameworkPropertyMetadata(typeof(RatingBarButton)));

    private static readonly DependencyPropertyKey ValuePropertyKey =
        DependencyProperty.RegisterReadOnly(
            "Value", typeof(int), typeof(RatingBarButton),
            new PropertyMetadata(default(int)));

    public static readonly DependencyProperty ValueProperty =
        ValuePropertyKey.DependencyProperty;

    public int Value
    {
        get => (int)GetValue(ValueProperty);
        internal set => SetValue(ValuePropertyKey, value);
    }
}
