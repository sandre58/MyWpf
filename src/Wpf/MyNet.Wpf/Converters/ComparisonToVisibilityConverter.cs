// -----------------------------------------------------------------------
// <copyright file="ComparisonToVisibilityConverter.cs" company="Stéphane ANDRE">
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
public sealed class ComparisonToVisibilityConverter : IValueConverter, IMultiValueConverter
{
    private MathComparisonForConverter Comparison { get; set; }

    private readonly Visibility _falseVisibility;
    private readonly Visibility _trueVisibility;

    private ComparisonToVisibilityConverter(MathComparisonForConverter operation, Visibility trueVisibility, Visibility falseVisibility)
    {
        Comparison = operation;
        _trueVisibility = trueVisibility;
        _falseVisibility = falseVisibility;
    }

    public static readonly ComparisonToVisibilityConverter CollapsedIfIsEqualsTo = new(MathComparisonForConverter.IsEqualsTo, Visibility.Collapsed, Visibility.Visible);

    public static readonly ComparisonToVisibilityConverter CollapsedIfIsNotEqualsTo = new(MathComparisonForConverter.IsEqualsTo, Visibility.Visible, Visibility.Collapsed);

    public static readonly ComparisonToVisibilityConverter HiddenIfIsNotEqualsTo = new(MathComparisonForConverter.IsEqualsTo, Visibility.Visible, Visibility.Hidden);

    public static readonly ComparisonToVisibilityConverter CollapsedIfIsGreaterThanTo = new(MathComparisonForConverter.IsGreaterThan, Visibility.Collapsed, Visibility.Visible);

    public static readonly ComparisonToVisibilityConverter HiddenIfIsGreaterThanTo = new(MathComparisonForConverter.IsGreaterThan, Visibility.Hidden, Visibility.Visible);

    public static readonly ComparisonToVisibilityConverter CollapsedIfIsLessThanTo = new(MathComparisonForConverter.IsLessThan, Visibility.Collapsed, Visibility.Visible);

    public static readonly ComparisonToVisibilityConverter HiddenIfIsLessThanTo = new(MathComparisonForConverter.IsLessThan, Visibility.Hidden, Visibility.Visible);

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => DoConvert(value, parameter, Comparison, _trueVisibility, _falseVisibility);

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values is not { Length: >= 2 }
            ? Binding.DoNothing
            : DoConvert(values[0], values[1], Comparison, _trueVisibility, _falseVisibility);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [.. targetTypes.Select(t => Binding.DoNothing)];

    private static object DoConvert(object firstValue, object secondValue, MathComparisonForConverter operation, Visibility trueVisibility, Visibility falseVisibility)
    {
        var result = ComparisonToBooleanConverter.DoConvert(firstValue, secondValue, operation);

        return result is not bool boolean ? result : boolean ? trueVisibility : falseVisibility;
    }
}
