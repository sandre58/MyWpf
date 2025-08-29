// -----------------------------------------------------------------------
// <copyright file="DateComparisonToBooleanConverter.cs" company="Stéphane ANDRE">
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
public sealed class DateComparisonToBooleanConverter : IValueConverter, IMultiValueConverter
{
    private DateComparisonForConverter Comparison { get; set; }

    private DateComparisonToBooleanConverter(DateComparisonForConverter operation) => Comparison = operation;

    public static readonly DateComparisonToBooleanConverter IsEqualsTo = new(DateComparisonForConverter.IsEqualsTo);

    public static readonly DateComparisonToBooleanConverter IsGreaterThan = new(DateComparisonForConverter.IsGreaterThan);

    public static readonly DateComparisonToBooleanConverter IsLessThan = new(DateComparisonForConverter.IsLessThan);

    public static readonly DateComparisonToBooleanConverter IsBetween = new(DateComparisonForConverter.IsBetween);

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => DoConvert(value, parameter, null, Comparison);

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values is not { Length: >= 2 } ? Binding.DoNothing : DoConvert(values[0], values[1], values.Length > 2 ? values[2] : null, Comparison);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => [.. targetTypes.Select(t => Binding.DoNothing)];

    internal static object DoConvert(object firstValue, object secondValue, object? thirdValue, DateComparisonForConverter operation)
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
            var thirdCulture = thirdValue is string ? CultureInfo.CurrentCulture : CultureInfo.InvariantCulture;
            var value1 = (firstValue as DateTime?) ?? System.Convert.ToDateTime(firstValue, firstCulture);
            var value2 = (secondValue as DateTime?) ?? System.Convert.ToDateTime(secondValue, secondCulture);
            var value3 = (thirdValue as DateTime?) ?? System.Convert.ToDateTime(thirdValue, thirdCulture);

            return operation switch
            {
                DateComparisonForConverter.IsEqualsTo => value1 == value2,
                DateComparisonForConverter.IsGreaterThan => value1 > value2,
                DateComparisonForConverter.IsLessThan => value1 < value2,
                DateComparisonForConverter.IsBetween => value1 >= value2 && value1 <= value3,
                _ => Binding.DoNothing
            };
        }
        catch (Exception)
        {
            return Binding.DoNothing;
        }
    }
}
