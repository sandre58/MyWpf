// -----------------------------------------------------------------------
// <copyright file="IBusy.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Loading.Models;

/// <summary>
/// Defines the contract for a busy indicator, including cancellation support.
/// </summary>
public interface IBusy
{
    /// <summary>
    /// Gets a value indicating whether the busy operation can be cancelled.
    /// </summary>
    bool IsCancellable { get; }

    /// <summary>
    /// Gets a value indicating whether a cancellation request is currently in progress.
    /// </summary>
    bool IsCancelling { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the user is allowed to trigger cancellation.
    /// </summary>
    bool CanCancel { get; set; }

    /// <summary>
    /// Requests cancellation of the busy operation.
    /// </summary>
    void Cancel();
}
