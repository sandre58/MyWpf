﻿// -----------------------------------------------------------------------
// <copyright file="NotNullableConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using MyNet.Utilities;

namespace MyNet.Wpf.Converters;

internal class NotNullableConverter : IValueConverter
{
    public static IValueConverter Default { get; } = new NotNullableConverter();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => value?.ToString() == "NaN" || value is null ? targetType.GetDefault() : value;

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => string.IsNullOrEmpty(value?.ToString()) ? targetType.GetDefault() : value;
}
