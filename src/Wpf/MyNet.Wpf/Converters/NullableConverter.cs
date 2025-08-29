// -----------------------------------------------------------------------
// <copyright file="NullableConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

internal class NullableConverter : IValueConverter
{
    public static IValueConverter Default { get; } = new NullableConverter();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => value?.ToString() == "NaN" ? null : value;

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => string.IsNullOrEmpty(value?.ToString()) ? null : value;
}
