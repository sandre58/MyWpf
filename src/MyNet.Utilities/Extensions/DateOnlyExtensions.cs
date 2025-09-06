// -----------------------------------------------------------------------
// <copyright file="DateOnlyExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Globalization;
using MyNet.Utilities.Helpers;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MyNet.Utilities;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// <see cref="DateOnly"/> extensions related to spatial or temporal relations.
/// </summary>
public static class DateOnlyExtensions
{
    /// <summary>
    /// Returns the last day of the decade for the provided date.
    /// </summary>
    public static DateOnly EndOfDecade(this DateOnly date) => date.SetYear(date.Year - (date.Year % 10) + 9).EndOfYear();

    /// <summary>
    /// Returns the first day of the decade for the provided date.
    /// </summary>
    public static DateOnly BeginningOfDecade(this DateOnly date) => date.SetYear(date.Year - (date.Year % 10)).BeginningOfYear();

    /// <summary>
    /// Returns the same date (same Day, Month, Hour, Minute, Second etc.) in the next calendar year.
    /// If that day does not exist in next year in same month, number of missing days is added to the last day in same month next year.
    /// </summary>
    public static DateOnly NextYear(this DateOnly start)
    {
        var nextYear = start.Year + 1;
        var numberOfDaysInSameMonthNextYear = DateTime.DaysInMonth(nextYear, start.Month);

        if (numberOfDaysInSameMonthNextYear >= start.Day) return new DateOnly(nextYear, start.Month, start.Day);
        var differenceInDays = start.Day - numberOfDaysInSameMonthNextYear;
        var dateTime = new DateOnly(nextYear, start.Month, numberOfDaysInSameMonthNextYear);
        return dateTime.AddDays(differenceInDays);
    }

    /// <summary>
    /// Returns the same date (same Day, Month, Hour, Minute, Second etc.) in the previous calendar year.
    /// If that day does not exist in previous year in same month, number of missing days is added to the last day in same month previous year.
    /// </summary>
    public static DateOnly PreviousYear(this DateOnly start)
    {
        var previousYear = start.Year - 1;
        var numberOfDaysInSameMonthPreviousYear = DateTime.DaysInMonth(previousYear, start.Month);

        if (numberOfDaysInSameMonthPreviousYear >= start.Day)
            return new DateOnly(previousYear, start.Month, start.Day);
        var differenceInDays = start.Day - numberOfDaysInSameMonthPreviousYear;
        var dateTime = new DateOnly(previousYear, start.Month, numberOfDaysInSameMonthPreviousYear);
        return dateTime.AddDays(differenceInDays);
    }

    /// <summary>
    /// Returns the next calendar day.
    /// </summary>
    /// <param name="start">The starting date.</param>
    /// <returns>The date one day after <paramref name="start"/>.</returns>
    public static DateOnly NextDay(this DateOnly start) => start.AddDays(1);

    /// <summary>
    /// Returns the previous calendar day.
    /// </summary>
    /// <param name="start">The starting date.</param>
    /// <returns>The date one day before <paramref name="start"/>.</returns>
    public static DateOnly PreviousDay(this DateOnly start) => start.AddDays(-1);

    /// <summary>
    /// Returns first next occurrence of specified <see cref="DayOfWeek"/>.
    /// </summary>
    public static DateOnly Next(this DateOnly start, DayOfWeek day)
    {
        do
        {
            start = start.NextDay();
        }
        while (start.DayOfWeek != day);

        return start;
    }

    /// <summary>
    /// Returns the next occurrence of a specific day and month.
    /// </summary>
    public static DateOnly Next(this DateOnly start, int day, int month)
    {
        do
        {
            start = start.NextDay();
        }
        while (start.Month != month || start.Day != day);

        return start;
    }

    /// <summary>
    /// Returns the previous occurrence of the specified <see cref="DayOfWeek"/>.
    /// </summary>
    public static DateOnly Previous(this DateOnly start, DayOfWeek day)
    {
        do
        {
            start = start.PreviousDay();
        }
        while (start.DayOfWeek != day);

        return start;
    }

    /// <summary>
    /// Returns the previous occurrence of the specified day/month.
    /// </summary>
    public static DateOnly Previous(this DateOnly start, int day, int month)
    {
        do
        {
            start = start.PreviousDay();
        }
        while (start.Month != month || start.Day != day);

        return start;
    }

    /// <summary>
    /// Increases the date by one calendar week (number of days determined by <see cref="DateTimeHelper.NumberOfDaysInWeek"/>).
    /// </summary>
    public static DateOnly WeekAfter(this DateOnly start) => start.AddDays(DateTimeHelper.NumberOfDaysInWeek());

    /// <summary>
    /// Decreases the date by one calendar week.
    /// </summary>
    public static DateOnly WeekEarlier(this DateOnly start) => start.AddDays(-DateTimeHelper.NumberOfDaysInWeek());

    /// <summary>
    /// Returns <see cref="DateOnly"/> with changed year component.
    /// </summary>
    public static DateOnly SetYear(this DateOnly value, int year) => new(year, value.Month, value.Day);

    /// <summary>
    /// Returns <see cref="DateOnly"/> with changed month component.
    /// </summary>
    public static DateOnly SetMonth(this DateOnly value, int month) => new(value.Year, month, value.Day);

    /// <summary>
    /// Returns <see cref="DateOnly"/> with changed day component.
    /// </summary>
    public static DateOnly SetDay(this DateOnly value, int day) => new(value.Year, value.Month, day);

    /// <summary>
    /// Determines whether the current date is strictly before the specified date.
    /// </summary>
    /// <returns><c>true</c> if <paramref name="current"/> is before <paramref name="toCompareWith"/>; otherwise <c>false</c>.</returns>
    public static bool IsBefore(this DateOnly current, DateOnly toCompareWith) => current < toCompareWith;

    /// <summary>
    /// Determines whether the current date is strictly before the specified <see cref="DateTime"/> (converted to a <see cref="DateOnly"/>).
    /// </summary>
    public static bool IsBefore(this DateOnly current, DateTime toCompareWith) => current.IsBefore(toCompareWith.ToDate());

    /// <summary>
    /// Determines whether the current date is strictly after the specified date.
    /// </summary>
    public static bool IsAfter(this DateOnly current, DateOnly toCompareWith) => current > toCompareWith;

    /// <summary>
    /// Determines whether the current date is strictly after the specified <see cref="DateTime"/> (converted to a <see cref="DateOnly"/>).
    /// </summary>
    public static bool IsAfter(this DateOnly current, DateTime toCompareWith) => current.IsAfter(toCompareWith.ToDate());

    /// <summary>
    /// Determines whether the current date is between two other dates (inclusive).
    /// </summary>
    /// <param name="current">The date to test.</param>
    /// <param name="toCompareFrom">One bound of the range.</param>
    /// <param name="toCompareTo">The other bound of the range.</param>
    /// <returns><c>true</c> if <paramref name="current"/> falls between the two bounds; otherwise <c>false</c>.</returns>
    public static bool IsBetween(this DateOnly current, DateOnly toCompareFrom, DateOnly toCompareTo) => current >= DateTimeHelper.Min(toCompareFrom, toCompareTo) && current <= DateTimeHelper.Max(toCompareTo, toCompareFrom);

    /// <summary>
    /// Returns a <see cref="DateTime"/> with the time part set to the provided <see cref="TimeOnly"/>.
    /// </summary>
    /// <param name="current">The date to convert.</param>
    /// <param name="time">The time to apply.</param>
    /// <returns>A <see cref="DateTime"/> representing the combined date and time.</returns>
    public static DateTime At(this DateOnly current, TimeOnly time) => current.ToDateTime(time);

    /// <summary>
    /// Returns a <see cref="DateTime"/> with the time part set to the provided <see cref="TimeOnly"/> and specified <see cref="DateTimeKind"/>.
    /// </summary>
    public static DateTime At(this DateOnly current, TimeOnly time, DateTimeKind kind) => current.ToDateTime(time, kind);

    /// <summary>
    /// Returns a <see cref="DateTime"/> representing the provided hour and minute on the same date.
    /// </summary>
    public static DateTime At(this DateOnly current, int hour, int minute) => current.At(new TimeOnly(hour, minute));

    /// <summary>
    /// Returns a <see cref="DateTime"/> representing the provided hour, minute and second on the same date.
    /// </summary>
    public static DateTime At(this DateOnly current, int hour, int minute, int second) => current.At(new TimeOnly(hour, minute, second));

    /// <summary>
    /// Returns a <see cref="DateTime"/> representing the provided hour, minute, second and milliseconds on the same date.
    /// </summary>
    public static DateTime At(this DateOnly current, int hour, int minute, int second, int milliseconds) => current.At(new TimeOnly(hour, minute, second, milliseconds));

    /// <summary>
    /// Gets the earliest possible <see cref="DateTime"/> for the date (midnight).
    /// </summary>
    public static DateTime BeginningOfDay(this DateOnly current) => current.At(TimeOnly.MinValue);

    /// <summary>
    /// Gets the latest possible <see cref="DateTime"/> for the date (end of day).
    /// </summary>
    public static DateTime EndOfDay(this DateOnly current) => current.At(TimeOnly.MaxValue);

    /// <summary>
    /// Sets the day of the <see cref="DateOnly"/> to the first day in that calendar quarter.
    /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html.
    /// </summary>
    /// <param name="current">Current date.</param>
    /// <returns>given <see cref="DateTime"/> with the day part set to the first day in the quarter.</returns>
    public static DateOnly BeginningOfQuarter(this DateOnly current)
    {
        var currentQuarter = ((current.Month - 1) / 3) + 1;
        return new DateOnly(current.Year, (3 * currentQuarter) - 2, 1);
    }

    /// <summary>
    /// Sets the day of the <see cref="DateOnly"/> to the first day in that month.
    /// </summary>
    /// <param name="current">The current <see cref="DateOnly"/> to be changed.</param>
    /// <returns>given <see cref="DateOnly"/> with the day part set to the first day in that month.</returns>
    public static DateOnly BeginningOfMonth(this DateOnly current) => current.SetDay(1);

    /// <summary>
    /// Sets the day of the <see cref="DateOnly"/> to the last day in that calendar quarter.
    /// credit to http://www.devcurry.com/2009/05/find-first-and-last-day-of-current.html.
    /// </summary>
    /// <param name="current">Current date.</param>
    /// <returns>given <see cref="DateOnly"/> with the day part set to the last day in the quarter.</returns>
    public static DateOnly EndOfQuarter(this DateOnly current)
    {
        var currentQuarter = ((current.Month - 1) / 3) + 1;
        var firstDay = new DateOnly(current.Year, (3 * currentQuarter) - 2, 1);
        return new DateOnly(firstDay.Year, firstDay.Month + 2, 1);
    }

    /// <summary>
    /// Sets the day of the <see cref="DateOnly"/> to the last day in that month.
    /// </summary>
    /// <param name="current">The current DateOnly to be changed.</param>
    /// <returns>given <see cref="DateOnly"/> with the day part set to the last day in that month.</returns>
    public static DateOnly EndOfMonth(this DateOnly current) => current.SetDay(DateTime.DaysInMonth(current.Year, current.Month));

    /// <summary>
    /// Adds the given number of business days to the <see cref="DateOnly"/>.
    /// </summary>
    /// <param name="current">The date to be changed.</param>
    /// <param name="days">Number of business days to be added.</param>
    /// <returns>A <see cref="DateOnly"/> increased by a given number of business days.</returns>
    public static DateOnly AddBusinessDays(this DateOnly current, int days)
    {
        var sign = Math.Sign(days);
        var unsignedDays = Math.Abs(days);
        for (var i = 0; i < unsignedDays; i++)
        {
            do
            {
                current = current.AddDays(sign);
            }
            while (current.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday);
        }

        return current;
    }

    /// <summary>
    /// Subtracts the given number of business days to the <see cref="DateOnly"/>.
    /// </summary>
    /// <param name="current">The date to be changed.</param>
    /// <param name="days">Number of business days to be subtracted.</param>
    /// <returns>A <see cref="DateOnly"/> increased by a given number of business days.</returns>
    public static DateOnly SubtractBusinessDays(this DateOnly current, int days) => AddBusinessDays(current, -days);

    /// <summary>
    /// Determine if a <see cref="DateOnly"/> is in the future compared to the current UTC date.
    /// </summary>
    /// <param name="dateTime">The date to be checked.</param>
    /// <returns><c>true</c> if <paramref name="dateTime"/> is in the future; otherwise <c>false</c>.</returns>
    public static bool IsInFuture(this DateOnly dateTime) => dateTime.At(TimeOnly.MinValue) > DateTime.UtcNow;

    /// <summary>
    /// Determine if a <see cref="DateOnly"/> is in the past compared to the current UTC date.
    /// </summary>
    /// <param name="dateTime">The date to be checked.</param>
    /// <returns><c>true</c> if <paramref name="dateTime"/> is in the past; otherwise <c>false</c>.</returns>
    public static bool IsInPast(this DateOnly dateTime) => dateTime.At(TimeOnly.MinValue) < DateTime.UtcNow;

    /// <summary>
    /// Returns a DateOnly adjusted to the beginning of the week.
    /// </summary>
    /// <returns>A DateOnly instance adjusted to the beginning of the current week.</returns>
    /// <remarks>the beginning of the week is controlled by the current Culture.</remarks>
    public static DateOnly BeginningOfWeek(this DateOnly dateTime, DayOfWeek? firstDayOfWeek = null)
    {
        var currentCulture = CultureInfo.CurrentCulture;
        var firstDay = firstDayOfWeek ?? currentCulture.DateTimeFormat.FirstDayOfWeek;
        var offset = dateTime.DayOfWeek < firstDay ? 7 : 0;
        var numberOfDaysSinceBeginningOfTheWeek = dateTime.DayOfWeek + offset - firstDay;

        return dateTime.AddDays(-numberOfDaysSinceBeginningOfTheWeek);
    }

    /// <summary>
    /// Returns the first day of the year keeping the time component intact.
    /// </summary>
    /// <param name="current">The DateOnly to adjust.</param>
    /// <returns>New date.</returns>
    public static DateOnly BeginningOfYear(this DateOnly current) => new(current.Year, 1, 1);

    /// <summary>
    /// Returns the last day of the week keeping the time component intact.
    /// </summary>
    /// <returns>New date.</returns>
    public static DateOnly EndOfWeek(this DateOnly current, DayOfWeek? firstDayOfWeek = null) => current.BeginningOfWeek(firstDayOfWeek).AddDays(6);

    /// <summary>
    /// Returns the last day of the year keeping the time component intact.
    /// </summary>
    /// <param name="current">The DateOnly to adjust.</param>
    /// <returns>New date.</returns>
    public static DateOnly EndOfYear(this DateOnly current) => new(current.Year, 12, 31);

    /// <summary>
    /// Determines whether the current date is the last day of the week.
    /// </summary>
    public static bool IsLastDayOfWeek(this DateOnly current, DayOfWeek? firstDayOfWeek = null) => current.DayOfWeek == current.EndOfWeek(firstDayOfWeek).DayOfWeek;

    /// <summary>
    /// Determines whether the current date is the first day of the week.
    /// </summary>
    public static bool IsFirstDayOfWeek(this DateOnly current, DayOfWeek? firstDayOfWeek = null) => current.DayOfWeek == current.EndOfWeek(firstDayOfWeek).DayOfWeek;

    /// <summary>
    /// Determines whether the current date falls on a weekend (Saturday or Sunday).
    /// </summary>
    public static bool IsWeekend(this DateOnly current) => current.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday;

    /// <summary>
    /// Returns the previous month keeping the time component intact.
    /// </summary>
    /// <param name="current">The DateOnly to adjust.</param>
    /// <returns>New date.</returns>
    public static DateOnly PreviousMonth(this DateOnly current)
    {
        var year = current.Month == 1 ? current.Year - 1 : current.Year;

        var month = current.Month == 1 ? 12 : current.Month - 1;

        var firstDayOfPreviousMonth = new DateOnly(year, month, 1);

        var lastDayOfPreviousMonth = firstDayOfPreviousMonth.EndOfMonth().Day;

        var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

        return firstDayOfPreviousMonth.SetDay(day);
    }

    /// <summary>
    /// Returns the next month keeping the time component intact.
    /// </summary>
    /// <param name="current">The DateOnly to adjust.</param>
    /// <returns>New date.</returns>
    public static DateOnly NextMonth(this DateOnly current)
    {
        var year = current.Month == 12 ? current.Year + 1 : current.Year;

        var month = current.Month == 12 ? 1 : current.Month + 1;

        var firstDayOfNextMonth = new DateOnly(year, month, 1);

        var lastDayOfPreviousMonth = firstDayOfNextMonth.EndOfMonth().Day;

        var day = current.Day > lastDayOfPreviousMonth ? lastDayOfPreviousMonth : current.Day;

        return firstDayOfNextMonth.SetDay(day);
    }

    /// <summary>
    /// Determines whether the date corresponds to today's day (UTC based).
    /// </summary>
    public static bool IsToday(this DateOnly current) => current.Day == DateTime.UtcNow.Day;

    /// <summary>
    /// Determines whether the specified date falls in the same week as the current date.
    /// </summary>
    /// <param name="current">The current date.</param>
    /// <param name="date">Value to compare with.</param>
    /// <returns><c>true</c> if the specified date is within the same week; otherwise <c>false</c>.</returns>
    public static bool SameWeek(this DateOnly current, DateOnly date) => date.IsAfter(current.BeginningOfWeek()) && date.IsBefore(current.EndOfWeek());

    /// <summary>
    /// Determines whether the specified date is in the same month as the current date.
    /// </summary>
    public static bool SameMonth(this DateOnly current, DateOnly date) => current.Month == date.Month && current.Year == date.Year;

    /// <summary>
    /// Determines whether the specified date is in the same year as the current date.
    /// </summary>
    public static bool SameYear(this DateOnly current, DateOnly date) => current.Year == date.Year;

    /// <summary>
    /// Determines whether the specified date is in the same decade as the current date.
    /// </summary>
    public static bool SameDecade(this DateOnly current, DateOnly date) => current.BeginningOfDecade() == date.BeginningOfDecade();

    /// <summary>
    /// Returns the absolute number of days between two dates.
    /// </summary>
    public static int NumberOfDays(this DateOnly dateFrom, DateOnly dateTo) => Math.Abs((dateFrom.ToDateTime(TimeOnly.MinValue) - dateTo.ToDateTime(TimeOnly.MinValue)).Days);

    /// <summary>
    /// Returns the difference in weeks between two dates (signed integer).
    /// </summary>
    public static int CompareWeek(this DateOnly dateFrom, DateOnly dateTo)
    {
        var ts = dateTo.ToDateTime(TimeOnly.MinValue).Subtract(dateFrom.ToDateTime(TimeOnly.MinValue));
        return ts.Days / 7;
    }

    /// <summary>
    /// Returns the absolute number of weeks between two dates.
    /// </summary>
    public static int NumberOfWeeks(this DateOnly dt1, DateOnly dt2) => Math.Abs(CompareWeek(dt1, dt2));

    /// <summary>
    /// Compare two dates and return difference of months (signed integer).
    /// </summary>
    public static int CompareMonth(this DateOnly dt1, DateTime dt2) => ((dt2.Year - dt1.Year) * 12) + (dt2.Month - dt1.Month);

    /// <summary>
    /// Returns the absolute number of months between two dates.
    /// </summary>
    public static int NumberOfMonths(this DateOnly dt1, DateTime dt2) => Math.Abs(CompareMonth(dt1, dt2));

    /// <summary>
    /// Compare two dates and return difference of years (signed integer).
    /// </summary>
    public static int CompareYear(this DateOnly dt1, DateTime dt2) => dt2.Year - dt1.Year;

    /// <summary>
    /// Returns the absolute number of years between two dates.
    /// </summary>
    public static int NumberOfYears(this DateOnly dt1, DateTime dt2) => Math.Abs(CompareYear(dt1, dt2));

    /// <summary>
    /// Determines whether the date lies within the inclusive range defined by start and end.
    /// </summary>
    public static bool InRange(this DateOnly date, DateOnly start, DateOnly end) => date == start || date == end || (date.IsAfter(start) && date.IsBefore(end)) || (date.IsAfter(end) && date.IsBefore(start));

    /// <summary>
    /// Calculates the age in years from a birthdate to now (UTC based).
    /// </summary>
    /// <param name="birthdate">The birthdate to calculate age from.</param>
    /// <returns>The number of full years elapsed since <paramref name="birthdate"/>.</returns>
    public static int GetAge(this DateOnly birthdate)
    {
        var today = DateTime.UtcNow;

        var age = today.Year - birthdate.Year;

        if (today.Month < birthdate.Month || (today.Month == birthdate.Month && today.Day < birthdate.Day))
            age--;

        return age;
    }
}
