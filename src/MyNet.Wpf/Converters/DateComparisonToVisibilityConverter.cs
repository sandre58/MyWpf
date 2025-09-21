// -----------------------------------------------------------------------
// <copyright file="DateComparisonToVisibilityConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

/// <summary>
/// MathConverter provides a value converter which can be used for math operations.
/// It can be used for normal binding or multi binding as well.
/// If it is used for normal binding the given parameter will be used as operands with the selected operation.
/// If it is used for multi binding then the first and second binding will be used as operands with the selected operation.
/// This class cannot be inherited.
/// </summary>
public sealed class DateComparisonToVisibilityConverter : IValueConverter, IMultiValueConverter
{
    private DateComparisonForConverter Comparison { get; set; }

    private readonly Visibility _falseVisibility;
    private readonly Visibility _trueVisibility;

    private DateComparisonToVisibilityConverter(DateComparisonForConverter operation, Visibility trueVisibility, Visibility falseVisibility)
    {
        Comparison = operation;
        _trueVisibility = trueVisibility;
        _falseVisibility = falseVisibility;
    }

    public static readonly DateComparisonToVisibilityConverter CollapsedIfIsEqualsTo = new(DateComparisonForConverter.IsEqualsTo, Visibility.Collapsed, Visibility.Visible);

    public static readonly DateComparisonToVisibilityConverter CollapsedIfIsNotEqualsTo = new(DateComparisonForConverter.IsEqualsTo, Visibility.Visible, Visibility.Collapsed);

    public static readonly DateComparisonToVisibilityConverter HiddenIfIsNotEqualsTo = new(DateComparisonForConverter.IsEqualsTo, Visibility.Visible, Visibility.Hidden);

    public static readonly DateComparisonToVisibilityConverter CollapsedIfIsGreaterThanTo = new(DateComparisonForConverter.IsGreaterThan, Visibility.Collapsed, Visibility.Visible);

    public static readonly DateComparisonToVisibilityConverter HiddenIfIsGreaterThanTo = new(DateComparisonForConverter.IsGreaterThan, Visibility.Hidden, Visibility.Visible);

    public static readonly DateComparisonToVisibilityConverter CollapsedIfIsLessThanTo = new(DateComparisonForConverter.IsLessThan, Visibility.Collapsed, Visibility.Visible);

    public static readonly DateComparisonToVisibilityConverter HiddenIfIsLessThanTo = new(DateComparisonForConverter.IsLessThan, Visibility.Hidden, Visibility.Visible);

    public static readonly DateComparisonToVisibilityConverter CollapsedIfIsBetweenThanTo = new(DateComparisonForConverter.IsBetween, Visibility.Collapsed, Visibility.Visible);

    public static readonly DateComparisonToVisibilityConverter HiddenIfIsBetweenThanTo = new(DateComparisonForConverter.IsBetween, Visibility.Hidden, Visibility.Visible);

    public static readonly DateComparisonToVisibilityConverter CollapsedIfIsNotBetweenThanTo = new(DateComparisonForConverter.IsBetween, Visibility.Visible, Visibility.Collapsed);

    public static readonly DateComparisonToVisibilityConverter HiddenIfIsNotBetweenThanTo = new(DateComparisonForConverter.IsBetween, Visibility.Visible, Visibility.Hidden);

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => DoConvert(value, parameter, null, Comparison, _trueVisibility, _falseVisibility);

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values is not { Length: >= 2 }
            ? Binding.DoNothing
            : DoConvert(values[0], values[1], values.Length > 2 ? values[2] : null, Comparison, _trueVisibility, _falseVisibility);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [.. targetTypes.Select(t => Binding.DoNothing)];

    private static object DoConvert(object firstValue, object secondValue, object? thirdValue, DateComparisonForConverter operation, Visibility trueVisibility, Visibility falseVisibility)
    {
        var result = DateComparisonToBooleanConverter.DoConvert(firstValue, secondValue, thirdValue, operation);

        return result is not bool boolean ? result : boolean ? trueVisibility : falseVisibility;
    }
}
