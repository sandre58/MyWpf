// -----------------------------------------------------------------------
// <copyright file="CalendarItemTemplateSelector.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using System.Windows.Controls;
using MyNet.Wpf.Controls;
using MyNet.Wpf.Extensions;

namespace MyNet.Wpf.Selectors;

public class CalendarItemTemplateSelector : DataTemplateSelector
{
    public override DataTemplate? SelectTemplate(object item, DependencyObject container)
    {
        var schedulerItem = container.FindVisualParent<CalendarItem>();

        return (schedulerItem?.Unit) switch
        {
            Utilities.Units.TimeUnit.Day => DayTemplate,
            Utilities.Units.TimeUnit.Month => MonthTemplate,
            Utilities.Units.TimeUnit.Year => YearTemplate,
            _ => base.SelectTemplate(item, container)
        };
    }

    public DataTemplate? DayTemplate { get; set; }

    public DataTemplate? MonthTemplate { get; set; }

    public DataTemplate? YearTemplate { get; set; }
}
