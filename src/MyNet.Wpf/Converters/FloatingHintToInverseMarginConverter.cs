// -----------------------------------------------------------------------
// <copyright file="FloatingHintToInverseMarginConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

public class FloatingHintToInverseMarginConverter : IValueConverter
{
    public static readonly FloatingHintToInverseMarginConverter Default = new();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is not Point offset ? new Thickness(0, 0, 0, 0) : (object)new Thickness(0, -offset.Y, 0, 0);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
