// -----------------------------------------------------------------------
// <copyright file="IToasterService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using MyNet.UI.Notifications;
using MyNet.UI.Toasting.Settings;

namespace MyNet.UI.Toasting;

/// <summary>
/// Defines the contract for a service that displays and manages toast notifications.
/// </summary>
public interface IToasterService
{
    /// <summary>
    /// Occurs when a toast notification is shown.
    /// </summary>
    event EventHandler<ToastEventArgs> ToastShown;

    /// <summary>
    /// Occurs when a toast notification is closed.
    /// </summary>
    event EventHandler<ToastEventArgs> ToastClosed;

    /// <summary>
    /// Occurs when a toast notification is clicked.
    /// </summary>
    event EventHandler<ToastEventArgs> ToastClicked;

    /// <summary>
    /// Displays a toast notification with the specified settings.
    /// </summary>
    /// <param name="notification">The notification to display.</param>
    /// <param name="settings">The settings for the toast notification.</param>
    /// <param name="isUnique">If true, ensures the notification is unique.</param>
    /// <param name="onClick">Action to execute when the notification is clicked.</param>
    /// <param name="onClose">Action to execute when the notification is closed.</param>
    void Show(INotification notification, ToastSettings settings, bool isUnique = false, Action<INotification>? onClick = null, Action? onClose = null);

    /// <summary>
    /// Hides all toast notifications.
    /// </summary>
    void Clear();

    /// <summary>
    /// Hides the specified toast notification if it is displayed.
    /// </summary>
    /// <param name="notification">The notification to hide.</param>
    void Hide(INotification notification);

    /// <summary>
    /// Gets the currently active toast notifications.
    /// </summary>
    /// <returns>An enumerable of active <see cref="INotification"/> instances.</returns>
    IEnumerable<INotification> GetActiveToasts();
}
