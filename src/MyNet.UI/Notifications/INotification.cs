// -----------------------------------------------------------------------
// <copyright file="INotification.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.ComponentModel;
using MyNet.Utilities;

namespace MyNet.UI.Notifications;

/// <summary>
/// Defines the contract for a notification, including severity and identification.
/// </summary>
public interface INotification : INotifyPropertyChanged, IIdentifiable<Guid>, ISimilar
{
    /// <summary>
    /// Gets the severity of the notification.
    /// </summary>
    NotificationSeverity Severity { get; }
}
