// -----------------------------------------------------------------------
// <copyright file="ProgressionBusy.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace MyNet.UI.Loading.Models;

/// <summary>
/// Represents a busy indicator for operations with progress reporting.
/// Inherits cancellation and command features from <see cref="Busy"/>.
/// </summary>
public class ProgressionBusy : Busy
{
    /// <summary>
    /// Gets or sets the title displayed for the busy operation.
    /// </summary>
    public string Title { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the collection of messages displayed during the busy operation.
    /// </summary>
    public IEnumerable<string>? Messages { get; set; }

    /// <summary>
    /// Gets or sets the progress value of the busy operation.
    /// </summary>
    public double Value { get; set; }
}
