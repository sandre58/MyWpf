﻿// -----------------------------------------------------------------------
// <copyright file="ComparisonToBooleanConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using MyNet.Utilities;

namespace MyNet.Wpf.Converters;

/// <summary>
/// MathConverter provides a value converter which can be used for math operations.
/// It can be used for normal binding or multi binding as well.
/// If it is used for normal binding the given parameter will be used as operands with the selected operation.
/// If it is used for multi binding then the first and second binding will be used as operands with the selected operation.
/// This class cannot be inherited.
/// </summary>
public sealed class ComparisonToBooleanConverter : IValueConverter, IMultiValueConverter
{
    private MathComparisonForConverter Comparison { get; set; }

    private ComparisonToBooleanConverter(MathComparisonForConverter operation) => Comparison = operation;

    public static readonly ComparisonToBooleanConverter IsEqualsTo = new(MathComparisonForConverter.IsEqualsTo);

    public static readonly ComparisonToBooleanConverter IsGreaterThan = new(MathComparisonForConverter.IsGreaterThan);

    public static readonly ComparisonToBooleanConverter IsLessThan = new(MathComparisonForConverter.IsLessThan);

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => DoConvert(value, parameter, Comparison);

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values is not { Length: >= 2 } ? Binding.DoNothing : DoConvert(values[0], values[1], Comparison);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [.. targetTypes.Select(t => Binding.DoNothing)];

    internal static object DoConvert(object firstValue, object secondValue, MathComparisonForConverter operation)
    {
        if (firstValue == null
            || secondValue == null
            || firstValue == DependencyProperty.UnsetValue
            || secondValue == DependencyProperty.UnsetValue
            || firstValue == DBNull.Value
            || secondValue == DBNull.Value)
        {
            return Binding.DoNothing;
        }

        try
        {
            var firstCulture = firstValue is string ? CultureInfo.CurrentCulture : CultureInfo.InvariantCulture;
            var secondCulture = secondValue is string ? CultureInfo.CurrentCulture : CultureInfo.InvariantCulture;
            var value1 = (firstValue as double?) ?? System.Convert.ToDouble(firstValue, firstCulture);
            var value2 = (secondValue as double?) ?? System.Convert.ToDouble(secondValue, secondCulture);

            return operation switch
            {
                MathComparisonForConverter.IsEqualsTo => value1.NearlyEqual(value2),
                MathComparisonForConverter.IsGreaterThan => value1 > value2,
                MathComparisonForConverter.IsLessThan => value1 < value2,
                _ => Binding.DoNothing
            };
        }
        catch (Exception)
        {
            return Binding.DoNothing;
        }
    }
}
