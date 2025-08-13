// -----------------------------------------------------------------------
// <copyright file="MessageNotification.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using MyNet.Observable;

namespace MyNet.UI.Notifications;

/// <summary>
/// Represents a simple notification message with a title and severity.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="MessageNotification"/> class.
/// </remarks>
/// <param name="message">The message content.</param>
/// <param name="title">The title of the notification.</param>
/// <param name="severity">The severity of the notification.</param>
public class MessageNotification(string message, string title = "", NotificationSeverity severity = NotificationSeverity.Information) : ObservableObject, INotification
{
    /// <summary>
    /// Gets the unique identifier of the notification.
    /// </summary>
    public Guid Id { get; } = Guid.NewGuid();

    /// <summary>
    /// Gets the title of the notification.
    /// </summary>
    public string Title { get; } = title;

    /// <summary>
    /// Gets the message content of the notification.
    /// </summary>
    public string Message { get; } = message;

    /// <summary>
    /// Gets the severity of the notification.
    /// </summary>
    public NotificationSeverity Severity { get; } = severity;

    #region Methods

    /// <inheritdoc/>
    public override bool Equals(object? obj) => ReferenceEquals(this, obj);

    /// <inheritdoc/>
    public override int GetHashCode() => Message.GetHashCode(StringComparison.OrdinalIgnoreCase);

    /// <inheritdoc/>
    public override string ToString() => Message;

    /// <inheritdoc/>
    public bool IsSimilar(object? obj) => obj is MessageNotification other && Equals(Message, other.Message) && Equals(Title, other.Title);

    #endregion Methods
}
