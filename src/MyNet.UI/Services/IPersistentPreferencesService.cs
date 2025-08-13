// -----------------------------------------------------------------------
// <copyright file="IPersistentPreferencesService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Services;

/// <summary>
/// Defines the contract for a service that manages persistent user preferences.
/// </summary>
public interface IPersistentPreferencesService
{
    /// <summary>
    /// Saves the current preferences.
    /// </summary>
    void Save();

    /// <summary>
    /// Resets the preferences to their default values.
    /// </summary>
    void Reset();

    /// <summary>
    /// Reloads the preferences from persistent storage.
    /// </summary>
    void Reload();
}
