// -----------------------------------------------------------------------
// <copyright file="DateChangedEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Wpf.Controls.Calendars;

/// <summary>
/// Provides data for the DateSelected and DisplayDateChanged events.
/// </summary>
public class DateChangedEventArgs : System.Windows.RoutedEventArgs
{
    internal DateChangedEventArgs(DateTime? removedDate, DateTime? addedDate)
    {
        RemovedDate = removedDate;
        AddedDate = addedDate;
    }

    /// <summary>
    /// Gets the date to be newly displayed.
    /// </summary>
    public DateTime? AddedDate
    {
        get;
        private set;
    }

    /// <summary>
    /// Gets the date that was previously displayed.
    /// </summary>
    public DateTime? RemovedDate
    {
        get;
        private set;
    }
}
