﻿// -----------------------------------------------------------------------
// <copyright file="ExpanderAssist.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;

namespace MyNet.Wpf.Parameters;

public static class ExpanderAssist
{
    private static readonly Thickness DefaultHorizontalHeaderPadding = new(24, 12, 24, 12);
    private static readonly Thickness DefaultVerticalHeaderPadding = new(12, 24, 12, 24);

    #region AttachedProperty : HorizontalHeaderPaddingProperty
    public static readonly DependencyProperty HorizontalHeaderPaddingProperty
        = DependencyProperty.RegisterAttached("HorizontalHeaderPadding", typeof(Thickness), typeof(ExpanderAssist),
            new FrameworkPropertyMetadata(DefaultHorizontalHeaderPadding, FrameworkPropertyMetadataOptions.Inherits));

    public static Thickness GetHorizontalHeaderPadding(Expander element)
        => (Thickness)element.GetValue(HorizontalHeaderPaddingProperty);
    public static void SetHorizontalHeaderPadding(Expander element, Thickness value)
        => element.SetValue(HorizontalHeaderPaddingProperty, value);
    #endregion

    #region AttachedProperty : VerticalHeaderPaddingProperty
    public static readonly DependencyProperty VerticalHeaderPaddingProperty
        = DependencyProperty.RegisterAttached("VerticalHeaderPadding", typeof(Thickness), typeof(ExpanderAssist),
            new FrameworkPropertyMetadata(DefaultVerticalHeaderPadding, FrameworkPropertyMetadataOptions.Inherits));

    public static Thickness GetVerticalHeaderPadding(Expander element)
        => (Thickness)element.GetValue(VerticalHeaderPaddingProperty);
    public static void SetVerticalHeaderPadding(Expander element, Thickness value)
        => element.SetValue(VerticalHeaderPaddingProperty, value);
    #endregion
}
