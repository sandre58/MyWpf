// -----------------------------------------------------------------------
// <copyright file="MultipleArrayConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

public class MultipleArrayConverter : IMultiValueConverter
{
    public static MultipleArrayConverter Default { get; } = new();

    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) => values.Clone();

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
}
