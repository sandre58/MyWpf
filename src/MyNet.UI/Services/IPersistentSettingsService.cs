// -----------------------------------------------------------------------
// <copyright file="IPersistentSettingsService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Services;

/// <summary>
/// Defines the contract for a service that manages persistent application settings.
/// </summary>
public interface IPersistentSettingsService
{
    /// <summary>
    /// Saves the current settings.
    /// </summary>
    void Save();

    /// <summary>
    /// Resets the settings to their default values.
    /// </summary>
    void Reset();

    /// <summary>
    /// Reloads the settings from persistent storage.
    /// </summary>
    void Reload();
}
