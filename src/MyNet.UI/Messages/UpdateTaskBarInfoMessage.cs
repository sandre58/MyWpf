// -----------------------------------------------------------------------
// <copyright file="UpdateTaskBarInfoMessage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Messages;

/// <summary>
/// Message requesting an update to the Windows taskbar progress indicator.
/// Contains the progress state and optional progress value.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UpdateTaskBarInfoMessage"/> class.
/// </remarks>
/// <param name="progressState">The state of the progress indicator.</param>
/// <param name="progressValue">The value of the progress indicator (optional).</param>
public class UpdateTaskBarInfoMessage(TaskbarProgressState progressState, double? progressValue = null)
{
    /// <summary>
    /// Gets the state of the progress indicator in the Windows taskbar.
    /// </summary>
    public TaskbarProgressState ProgressState { get; } = progressState;

    /// <summary>
    /// Gets the value of the progress indicator, if applicable.
    /// </summary>
    public double? ProgressValue { get; } = progressValue;
}
