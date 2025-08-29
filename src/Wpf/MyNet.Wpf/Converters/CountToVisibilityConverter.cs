// -----------------------------------------------------------------------
// <copyright file="CountToVisibilityConverter.cs" company="Stéphane ANDRE">
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
public sealed class CountToVisibilityConverter
    : IValueConverter
{
    private readonly ComparisonToVisibilityConverter _converter;
    private readonly int _parameter;

    public static readonly CountToVisibilityConverter CollapsedIfAny = new(ComparisonToVisibilityConverter.CollapsedIfIsGreaterThanTo, 0);
    public static readonly CountToVisibilityConverter CollapsedIfNotAny = new(ComparisonToVisibilityConverter.CollapsedIfIsLessThanTo, 1);
    public static readonly CountToVisibilityConverter CollapsedIfMany = new(ComparisonToVisibilityConverter.CollapsedIfIsGreaterThanTo, 1);
    public static readonly CountToVisibilityConverter CollapsedIfNotMany = new(ComparisonToVisibilityConverter.CollapsedIfIsLessThanTo, 2);
    public static readonly CountToVisibilityConverter CollapsedIfOne = new(ComparisonToVisibilityConverter.CollapsedIfIsEqualsTo, 1);
    public static readonly CountToVisibilityConverter CollapsedIfNotOne = new(ComparisonToVisibilityConverter.CollapsedIfIsNotEqualsTo, 1);
    public static readonly CountToVisibilityConverter HiddenIfAny = new(ComparisonToVisibilityConverter.HiddenIfIsGreaterThanTo, 0);
    public static readonly CountToVisibilityConverter HiddenIfNotAny = new(ComparisonToVisibilityConverter.HiddenIfIsLessThanTo, 1);
    public static readonly CountToVisibilityConverter HiddenIfMany = new(ComparisonToVisibilityConverter.HiddenIfIsGreaterThanTo, 1);
    public static readonly CountToVisibilityConverter HiddenIfNotMany = new(ComparisonToVisibilityConverter.HiddenIfIsLessThanTo, 2);

    private CountToVisibilityConverter(ComparisonToVisibilityConverter converter, int parameter)
    {
        _converter = converter;
        _parameter = parameter;
    }

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => _converter.Convert(value, targetType, _parameter, culture);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => _converter.ConvertBack(value, targetType, _parameter, culture);
}
