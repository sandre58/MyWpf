// -----------------------------------------------------------------------
// <copyright file="DriveExtensions.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.IO;

#pragma warning disable IDE0130 // Namespace does not match folder structure
namespace MyNet.Utilities;
#pragma warning restore IDE0130 // Namespace does not match folder structure

/// <summary>
/// Result codes used by disk drive checks.
/// </summary>
public enum DiskDriveInfo
{
    /// <summary>No error detected.</summary>
    NoError,

    /// <summary>Drive is not found or not ready.</summary>
    DiskNotFound,

    /// <summary>Drive has not enough free space for requested operation.</summary>
    InsufficientSpace
}

/// <summary>
/// Extension methods for <see cref="DriveInfo"/>.
/// </summary>
public static class DriveExtensions
{
    /// <summary>
    /// Checks whether the drive has at least the requested amount of free space.
    /// </summary>
    /// <param name="driveInfo">The drive to check.</param>
    /// <param name="space">Minimum required free space in bytes.</param>
    /// <returns>A <see cref="DiskDriveInfo"/> value describing the result.</returns>
    public static DiskDriveInfo HasEnoughSpace(this DriveInfo driveInfo, double space) => !driveInfo.IsReady
        ? DiskDriveInfo.DiskNotFound
        : driveInfo.TotalFreeSpace >= space ? DiskDriveInfo.NoError : DiskDriveInfo.InsufficientSpace;
}
