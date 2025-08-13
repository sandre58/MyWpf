// -----------------------------------------------------------------------
// <copyright file="Busy.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows.Input;
using MyNet.Observable;
using MyNet.UI.Commands;

namespace MyNet.UI.Loading.Models;

/// <summary>
/// Represents a busy indicator that supports cancellation.
/// </summary>
public class Busy : ObservableObject, IBusy
{
    /// <summary>
    /// Gets or sets the action to execute when cancellation is requested.
    /// </summary>
    public Action? CancelAction { get; set; }

    /// <summary>
    /// Gets the command used to trigger cancellation.
    /// </summary>
    public ICommand CancelCommand { get; }

    /// <summary>
    /// Gets a value indicating whether cancellation is possible (i.e., <see cref="CancelAction"/> is not null).
    /// </summary>
    public bool IsCancellable => CancelAction is not null;

    /// <summary>
    /// Gets a value indicating whether cancellation is in progress.
    /// </summary>
    public bool IsCancelling { get; private set; }

    /// <summary>
    /// Gets or sets a value indicating whether cancellation can be triggered by the user.
    /// </summary>
    public bool CanCancel { get; set; } = true;

    /// <summary>
    /// Initializes a new instance of the <see cref="Busy"/> class.
    /// </summary>
    public Busy() => CancelCommand = CommandsManager.Create(Cancel, () => IsCancellable && CanCancel && !IsCancelling);

    /// <summary>
    /// Requests cancellation of the busy operation. Sets <see cref="IsCancelling"/> to true and invokes <see cref="CancelAction"/> if set.
    /// </summary>
    public void Cancel()
    {
        IsCancelling = true;
        CancelAction?.Invoke();
    }
}
