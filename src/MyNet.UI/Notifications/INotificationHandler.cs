// -----------------------------------------------------------------------
// <copyright file="INotificationHandler.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Notifications;

/// <summary>
/// Defines the contract for a notification handler that can subscribe and unsubscribe to notification events.
/// </summary>
public interface INotificationHandler : IDisposable
{
    /// <summary>
    /// Subscribes to notification events with the specified action.
    /// </summary>
    /// <param name="action">The action to execute when a notification is received.</param>
    void Subscribe(Action<IClosableNotification> action);

    /// <summary>
    /// Unsubscribes from notification events with the specified predicate action.
    /// </summary>
    /// <param name="action">The action to execute to remove notifications matching a predicate.</param>
    void Unsubscribe(Action<Func<IClosableNotification, bool>> action);
}
