// -----------------------------------------------------------------------
// <copyright file="HardwareAcceleration.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows.Media;

namespace MyNet.Wpf.Hardware;

/// <summary>
/// Set of tools for hardware acceleration.
/// </summary>
public static class HardwareAcceleration
{
    /// <summary>
    /// Determines whether the provided rendering tier is supported.
    /// </summary>
    /// <param name="tier">Hardware acceleration rendering tier to check.</param>
    /// <returns><see langword="true"/> if tier is supported.</returns>
    public static bool IsSupported(RenderingTier tier) => RenderCapability.Tier >> 16 >= (int)tier;
}
