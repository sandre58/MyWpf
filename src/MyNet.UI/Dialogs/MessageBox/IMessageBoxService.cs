// -----------------------------------------------------------------------
// <copyright file="IMessageBoxService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyNet.UI.Dialogs.MessageBox;

/// <summary>
/// Service for displaying message boxes.
/// </summary>
public interface IMessageBoxService
{
    /// <summary>
    /// Occurs when a message box is opened.
    /// </summary>
    event EventHandler<MessageBoxEventArgs> MessageBoxOpened;

    /// <summary>
    /// Occurs when a message box is closed.
    /// </summary>
    event EventHandler<MessageBoxEventArgs> MessageBoxClosed;

    /// <summary>
    /// Displays a message box that has a message, title bar caption, button, and icon; and
    /// that accepts a default message box result and returns a result.
    /// Supports cancellation.
    /// </summary>
    /// <param name="viewModel">The view model for the message box.</param>
    /// <param name="cancellationToken">A token to observe for cancellation.</param>
    /// <returns>
    /// A <see cref="MessageBoxResult"/> value that specifies which message box button is
    /// clicked by the user.
    /// </returns>
    Task<MessageBoxResult?> ShowMessageBoxAsync(IMessageBox viewModel, CancellationToken cancellationToken = default);
}
