// -----------------------------------------------------------------------
// <copyright file="DateRangeChangingEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.Wpf.Controls.Calendars;

/// <summary>
/// Event arguments to notify clients that the range is changing and what the new range will be.
/// </summary>
internal class DateRangeChangingEventArgs(DateTime start, DateTime end) : EventArgs
{
    public DateTime Start { get; } = start;

    public DateTime End { get; } = end;
}
