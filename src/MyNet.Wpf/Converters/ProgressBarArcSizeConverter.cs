// -----------------------------------------------------------------------
// <copyright file="ProgressBarArcSizeConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

internal class ProgressBarArcSizeConverter : IValueConverter
{
    public static readonly ProgressBarArcSizeConverter Default = new();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is double @double and > 0.0 ? new Size(@double / 2, @double / 2) : (object)new Size();

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}
