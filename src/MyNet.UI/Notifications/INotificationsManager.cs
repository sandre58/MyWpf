// -----------------------------------------------------------------------
// <copyright file="INotificationsManager.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.ObjectModel;

namespace MyNet.UI.Notifications;

/// <summary>
/// Defines the contract for a manager that handles notifications and their lifecycle.
/// </summary>
public interface INotificationsManager
{
    /// <summary>
    /// Gets the collection of notifications managed by this manager.
    /// </summary>
    ReadOnlyObservableCollection<IClosableNotification> Notifications { get; }

    /// <summary>
    /// Clears all notifications.
    /// </summary>
    void Clear();

    /// <summary>
    /// Adds a notification handler to the manager.
    /// </summary>
    /// <param name="handler">The notification handler to add.</param>
    /// <returns>The notifications manager instance for chaining.</returns>
    INotificationsManager AddHandler(INotificationHandler handler);

    /// <summary>
    /// Adds a notification handler of the specified type to the manager.
    /// </summary>
    /// <typeparam name="T">The type of notification handler to add.</typeparam>
    /// <returns>The notifications manager instance for chaining.</returns>
    INotificationsManager AddHandler<T>()
        where T : INotificationHandler, new();
}
