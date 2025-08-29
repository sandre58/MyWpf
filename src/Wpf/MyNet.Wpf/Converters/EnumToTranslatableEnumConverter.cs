// -----------------------------------------------------------------------
// <copyright file="EnumToTranslatableEnumConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using MyNet.Observable.Translatables;

namespace MyNet.Wpf.Converters;

public class EnumToEnumTranslatableConverter : IValueConverter
{
    public static readonly EnumToEnumTranslatableConverter Default = new();

    public object? Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is not Enum val ? null : new EnumTranslatable(val);

    public object? ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value is not EnumTranslatable val ? null : val.Value;
}
