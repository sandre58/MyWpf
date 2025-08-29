// -----------------------------------------------------------------------
// <copyright file="CountToBooleanConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

/// <summary>
/// Converts a null value to Visibility.Visible and any other value to Visibility.Collapsed.
/// </summary>
public sealed class CountToBooleanConverter
    : IValueConverter
{
    private readonly ComparisonToBooleanConverter _converter;
    private readonly int _parameter;

    public static readonly CountToBooleanConverter Any = new(ComparisonToBooleanConverter.IsGreaterThan, 0);
    public static readonly CountToBooleanConverter NotAny = new(ComparisonToBooleanConverter.IsLessThan, 1);
    public static readonly CountToBooleanConverter Many = new(ComparisonToBooleanConverter.IsGreaterThan, 1);
    public static readonly CountToBooleanConverter NotMany = new(ComparisonToBooleanConverter.IsLessThan, 2);
    public static readonly CountToBooleanConverter One = new(ComparisonToBooleanConverter.IsEqualsTo, 1);

    private CountToBooleanConverter(ComparisonToBooleanConverter converter, int parameter)
    {
        _converter = converter;
        _parameter = parameter;
    }

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => _converter.Convert(value, targetType, _parameter, culture);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => _converter.ConvertBack(value, targetType, _parameter, culture);
}
