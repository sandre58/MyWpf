// -----------------------------------------------------------------------
// <copyright file="DeterminateBusy.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Loading.Models;

/// <summary>
/// Represents a busy indicator for operations with a known progress range.
/// Inherits cancellation and command features from <see cref="Busy"/>.
/// </summary>
public class DeterminateBusy : Busy
{
    /// <summary>
    /// Gets or sets the message displayed during the busy operation.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// Gets or sets the current progress value of the busy operation.
    /// </summary>
    public double Value { get; set; }

    /// <summary>
    /// Gets or sets the maximum value for the progress indicator.
    /// </summary>
    public double Maximum { get; set; } = 1;

    /// <summary>
    /// Gets or sets the minimum value for the progress indicator.
    /// </summary>
    public double Minimum { get; set; }
}
