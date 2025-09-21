// -----------------------------------------------------------------------
// <copyright file="SliderToolTipConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

internal class SliderToolTipConverter : IMultiValueConverter
{
    public static readonly SliderToolTipConverter Default = new();

    public object? Convert(object?[]? values, Type? targetType, object? parameter, CultureInfo? culture)
    {
        if (values is
            [
                _, string format, ..
            ] && !string.IsNullOrEmpty(format))
        {
            try
            {
                return string.Format(culture, format, values[0]);
            }
            catch (FormatException)
            {
                // Nothing
            }
        }

        return values?.Length >= 1 && targetType is not null
            ? System.Convert.ChangeType(values[0], targetType, culture)
            : DependencyProperty.UnsetValue;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        => throw new NotImplementedException();
}
