// -----------------------------------------------------------------------
// <copyright file="NullableDateTimeToCurrentDateConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;

namespace MyNet.Wpf.Converters;

internal class NullableDateTimeToCurrentDateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture) => value is DateTime ? value : DateTime.Now.Date;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => value;
}
