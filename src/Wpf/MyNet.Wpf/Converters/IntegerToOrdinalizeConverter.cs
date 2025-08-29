// -----------------------------------------------------------------------
// <copyright file="IntegerToOrdinalizeConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Data;
using MyNet.Humanizer;

namespace MyNet.Wpf.Converters;

public class IntegerToOrdinalizeConverter
    : IValueConverter
{
    public static readonly IntegerToOrdinalizeConverter Default = new();

    public object? Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => value?.ToString()?.Ordinalize();

    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotSupportedException();
}
