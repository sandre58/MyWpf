// -----------------------------------------------------------------------
// <copyright file="MultipleBooleanConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

public sealed class MultipleBooleanConverter : IMultiValueConverter
{
    private enum Operator
    {
        And,

        Or
    }

    private readonly Operator _operator;

    public static MultipleBooleanConverter And { get; } = new MultipleBooleanConverter(Operator.And);

    public static MultipleBooleanConverter Or { get; } = new MultipleBooleanConverter(Operator.Or);

    private MultipleBooleanConverter(Operator @operator) => _operator = @operator;

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        foreach (var value in values)
        {
            if (value is not bool) return false;

            var result = (bool)value;
            if (_operator == Operator.Or && result)
            {
                return true;
            }

            if (_operator == Operator.And && !result)
            {
                return false;
            }
        }

        return _operator == Operator.And;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
