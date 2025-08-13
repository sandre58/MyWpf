// -----------------------------------------------------------------------
// <copyright file="ToastEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using MyNet.UI.Notifications;

namespace MyNet.UI.Toasting;

/// <summary>
/// Provides data for toast notification events.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ToastEventArgs"/> class.
/// </remarks>
/// <param name="notification">The notification associated with the event.</param>
public class ToastEventArgs(INotification notification) : EventArgs
{
    /// <summary>
    /// Gets the notification associated with the event.
    /// </summary>
    public INotification Notification { get; } = notification;
}
