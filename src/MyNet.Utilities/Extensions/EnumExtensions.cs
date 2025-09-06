// -----------------------------------------------------------------------
// <copyright file="EnumExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MyNet.Utilities;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Extension methods for enum types.
/// </summary>
public static class EnumExtensions
{
    /// <summary>
    /// Counts how many flags are set on an enum value.
    /// </summary>
    /// <typeparam name="T">The enum type.</typeparam>
    /// <param name="options">The enum value to inspect.</param>
    /// <returns>The number of flags that are set.</returns>
    public static int CountFlags<T>(this T options)
        where T : Enum
        => Enum.GetValues(typeof(T)).Cast<Enum>().Count(options.HasFlag);
}
