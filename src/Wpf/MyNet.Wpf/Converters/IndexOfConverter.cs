// -----------------------------------------------------------------------
// <copyright file="IndexOfConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections;
using System.Globalization;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

public class IndexOfConverter : IValueConverter
{
    public static IndexOfConverter Default { get; } = new IndexOfConverter();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is IList list && int.TryParse(parameter?.ToString(), out var index) && list.Count > index ? list[index] : Binding.DoNothing;

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
