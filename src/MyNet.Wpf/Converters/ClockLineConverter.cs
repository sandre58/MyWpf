// -----------------------------------------------------------------------
// <copyright file="ClockLineConverter.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using System.Windows.Data;
using MaterialDesignThemes.Wpf;

namespace MyNet.Wpf.Converters;

internal sealed class ClockLineConverter : IValueConverter
{
    public static readonly ClockLineConverter Hours = new(ClockDisplayMode.Hours);
    public static readonly ClockLineConverter Minutes = new(ClockDisplayMode.Minutes);
    public static readonly ClockLineConverter Seconds = new(ClockDisplayMode.Seconds);

    private readonly ClockDisplayMode _displayMode;

    private ClockLineConverter(ClockDisplayMode displayMode) => _displayMode = displayMode;

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var time = (DateTime)value;

        return _displayMode == ClockDisplayMode.Hours
            ? (time.Hour > 13 ? time.Hour - 12 : time.Hour) * (360 / 12)
            : _displayMode == ClockDisplayMode.Minutes
                ? (time.Minute == 0 ? 60 : time.Minute) * (360 / 60)
                : (time.Second == 0 ? 60 : time.Second) * (360 / 60);
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) => Binding.DoNothing;
}
