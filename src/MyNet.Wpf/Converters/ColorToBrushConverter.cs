// -----------------------------------------------------------------------
// <copyright file="ColorToBrushConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using MyNet.Wpf.Extensions;

namespace MyNet.Wpf.Converters;

public class ColorToBrushConverter : IValueConverter
{
    public static ColorToBrushConverter Default { get; } = new ColorToBrushConverter();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is not SolidColorBrush and not Color and not string) return Binding.DoNothing;

        var color = value is SolidColorBrush b ? b.Color : value is Color c ? c : value is string s ? s.ToColor().GetValueOrDefault() : Colors.White;

        return new SolidColorBrush(color);
    }

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value is SolidColorBrush brush ? brush.Color : (object)default(Color);
}
