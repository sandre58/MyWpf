// -----------------------------------------------------------------------
// <copyright file="IndeterminateBusy.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Loading.Models;

/// <summary>
/// Represents a busy indicator for indeterminate operations (no progress value).
/// Inherits cancellation and command features from <see cref="Busy"/>.
/// </summary>
public class IndeterminateBusy : Busy
{
    /// <summary>
    /// Gets or sets the message displayed during the busy operation.
    /// </summary>
    public string? Message { get; set; }
}
