// -----------------------------------------------------------------------
// <copyright file="IRecentFileCommandsService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;

namespace MyNet.UI.Services;

/// <summary>
/// Defines the contract for a service that provides commands for recent files (open, open copy, get image).
/// </summary>
public interface IRecentFileCommandsService
{
    /// <summary>
    /// Gets an image preview for the specified file asynchronously.
    /// </summary>
    /// <param name="file">The file path.</param>
    /// <returns>A task that returns the image as a byte array, or null if not available.</returns>
    Task<byte[]?> GetImageAsync(string file);

    /// <summary>
    /// Opens the specified file asynchronously.
    /// </summary>
    /// <param name="file">The file path.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OpenAsync(string file);

    /// <summary>
    /// Opens a copy of the specified file asynchronously.
    /// </summary>
    /// <param name="file">The file path.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task OpenCopyAsync(string file);
}
