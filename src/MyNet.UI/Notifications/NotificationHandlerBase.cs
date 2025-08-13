// -----------------------------------------------------------------------
// <copyright file="NotificationHandlerBase.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Reactive.Subjects;

namespace MyNet.UI.Notifications;

/// <summary>
/// Base class for notification handlers, providing subscription and notification logic.
/// Implements <see cref="INotificationHandler"/> and manages notification lifecycle.
/// </summary>
public abstract class NotificationHandlerBase : INotificationHandler
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "Dispose in Cleanup")]
    private readonly Subject<IClosableNotification> _notify = new();
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "CA2213:Disposable fields should be disposed", Justification = "Dispose in Cleanup")]
    private readonly Subject<Func<IClosableNotification, bool>> _unnotify = new();
    private bool _disposedValue;

    /// <summary>
    /// Notifies subscribers with the specified notification.
    /// </summary>
    /// <param name="notification">The notification to send to subscribers.</param>
    protected void Notify(IClosableNotification notification) => _notify.OnNext(notification);

    /// <summary>
    /// Notifies subscribers to remove notifications matching the specified predicate.
    /// </summary>
    /// <param name="canRemove">Predicate to determine which notifications to remove.</param>
    protected void Unnotify(Func<IClosableNotification, bool> canRemove) => _unnotify.OnNext(canRemove);

    /// <inheritdoc/>
    public void Subscribe(Action<IClosableNotification> action) => _notify.Subscribe(action);

    /// <inheritdoc/>
    public void Unsubscribe(Action<Func<IClosableNotification, bool>> action) => _unnotify.Subscribe(action);

    /// <summary>
    /// Cleans up resources used by the notification handler.
    /// </summary>
    protected virtual void Cleanup()
    {
        _notify.Dispose();
        _unnotify.Dispose();
    }

    /// <summary>
    /// Disposes the notification handler and its resources.
    /// </summary>
    /// <param name="disposing">Indicates whether the method is called from Dispose.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue)
            return;
        if (disposing)
        {
            Cleanup();
        }

        _disposedValue = true;
    }

    /// <inheritdoc/>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
