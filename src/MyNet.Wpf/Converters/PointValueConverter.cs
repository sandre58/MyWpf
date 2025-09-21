// -----------------------------------------------------------------------
// <copyright file="PointValueConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

public class PointValueConverter : IMultiValueConverter
{
    public static readonly PointValueConverter Default = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values is
                                                                                                      [
                                                                                                          not null, not null
                                                                                                      ] && double.TryParse(values[0].ToString(), out var x) &&
                                                                                                      double.TryParse(values[1].ToString(), out var y)
            ? new Point(x, y)
            : (object)new Point();

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => value is Point point ? ([point.X, point.Y]) : Array.Empty<object>();
}
