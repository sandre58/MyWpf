// -----------------------------------------------------------------------
// <copyright file="ConcatStringsConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

public class ConcatStringsConverter
    : IMultiValueConverter
{
    public static readonly ConcatStringsConverter Default = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        => values is null ? Binding.DoNothing : string.Join(parameter?.ToString(), values);

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotSupportedException();
}
