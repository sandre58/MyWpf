// -----------------------------------------------------------------------
// <copyright file="NotificationsManager.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;
using DynamicData.Binding;
using MyNet.Utilities.Collections;

namespace MyNet.UI.Notifications;

/// <summary>
/// Manages the lifecycle and display of notifications in the application.
/// </summary>
public sealed class NotificationsManager : INotificationsManager, IDisposable
{
    private readonly OptimizedObservableCollection<IClosableNotification> _notifications = [];
    private readonly List<INotificationHandler> _handlers = [];

    /// <summary>
    /// Gets the collection of notifications managed by this manager.
    /// </summary>
    public ReadOnlyObservableCollection<IClosableNotification> Notifications { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationsManager"/> class.
    /// </summary>
    public NotificationsManager()
    {
        Notifications = new(_notifications);

        _ = _notifications.ToObservableChangeSet(x => x.Id)
            .DisposeMany()
            .OnItemAdded(x => x.CloseRequest += Notification_CloseRequest)
            .OnItemRemoved(x => x.CloseRequest -= Notification_CloseRequest)
            .Subscribe();
    }

    private void Notification_CloseRequest(object? sender, System.ComponentModel.CancelEventArgs e) => _notifications.Remove((IClosableNotification)sender!);

    /// <summary>
    /// Adds a notification handler to the manager.
    /// </summary>
    /// <param name="handler">The notification handler to add.</param>
    /// <returns>The notifications manager instance for chaining.</returns>
    public INotificationsManager AddHandler(INotificationHandler handler)
    {
        _handlers.Add(handler);
        handler.Subscribe(AddNotification);
        handler.Unsubscribe(RemoveNotifications);

        return this;
    }

    /// <summary>
    /// Adds a notification handler of the specified type to the manager.
    /// </summary>
    /// <typeparam name="T">The type of notification handler to add.</typeparam>
    /// <returns>The notifications manager instance for chaining.</returns>
    public INotificationsManager AddHandler<T>()
        where T : INotificationHandler, new()
        => AddHandler(new T());

    private void RemoveNotifications(Func<IClosableNotification, bool> predicate) => _notifications.RemoveMany([.. _notifications.Where(predicate)]);

    private void AddNotification(IClosableNotification notification)
    {
        if (!_notifications.Contains(notification))
            _notifications.Add(notification);
    }

    /// <summary>
    /// Clears all notifications.
    /// </summary>
    public void Clear() => _notifications.Clear();

    /// <summary>
    /// Disposes the notification handlers managed by this manager.
    /// </summary>
    public void Dispose() => _handlers.ForEach(x => x.Dispose());
}
