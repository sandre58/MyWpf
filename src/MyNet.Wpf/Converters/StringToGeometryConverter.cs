// -----------------------------------------------------------------------
// <copyright file="StringToGeometryConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MyNet.Wpf.Converters;

public class StringToGeometryConverter : IValueConverter
{
    public static readonly StringToGeometryConverter Default = new();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => Geometry.Parse(value?.ToString());

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
