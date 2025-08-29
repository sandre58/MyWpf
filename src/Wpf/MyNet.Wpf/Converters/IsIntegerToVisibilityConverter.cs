// -----------------------------------------------------------------------
// <copyright file="IsIntegerToVisibilityConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

/// <summary>
/// Converts a boolean value to a font weight (false: normal, true: bold).
/// </summary>
public class IsIntegerToVisibilityConverter
    : IValueConverter
{
    public static readonly IsIntegerToVisibilityConverter Default = new();

    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// A converted value. If the method returns null, the valid null value is used.
    /// </returns>
    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => value != null && int.TryParse(value.ToString(), out _) ? Visibility.Visible : Visibility.Collapsed;

    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>
    /// A converted value. If the method returns null, the valid null value is used.
    /// </returns>
    public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) => throw new NotSupportedException();
}
