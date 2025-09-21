// -----------------------------------------------------------------------
// <copyright file="DatesIntervalToStringConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using MyNet.Utilities.Units;
using MyNet.Humanizer;

namespace MyNet.Wpf.Converters;

public class DatesIntervalToStringConverter(bool withPrefix) : IMultiValueConverter
{
    private readonly bool _withPrefix = withPrefix;

    public static readonly DatesIntervalToStringConverter TimeSpan = new(false);

    public static readonly DatesIntervalToStringConverter Date = new(true);

    public object? Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        if (values is
            [
                not null, not null, ..
            ] && DateTime.TryParse(values[0].ToString(), culture, out var date1) && DateTime.TryParse(values[1].ToString(), culture, out var date2))
        {
            string? result;
            if (_withPrefix)
            {
                result = date1.Humanize(date2);
            }
            else
            {
                var duration = date1 - date2;
                result = duration.Humanize(1, TimeUnit.Year, TimeUnit.Day);
            }

            if (parameter is LetterCasing letterCasing)
            {
                result = result?.ApplyCase(letterCasing);
            }

            return result;
        }

        return string.Empty;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
