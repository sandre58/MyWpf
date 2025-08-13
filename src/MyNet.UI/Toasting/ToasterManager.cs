// -----------------------------------------------------------------------
// <copyright file="ToasterManager.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using MyNet.UI.Notifications;
using MyNet.UI.Resources;
using MyNet.UI.Toasting.Settings;
using MyNet.Utilities;

namespace MyNet.UI.Toasting;

/// <summary>
/// Provides a global access point for displaying toast notifications in the application.
/// </summary>
public static class ToasterManager
{
    private static IToasterService? _toasterService;

    /// <summary>
    /// Initializes the <see cref="ToasterManager"/> with the specified <see cref="IToasterService"/>.
    /// </summary>
    /// <param name="toasterService">The service used to display toast notifications.</param>
    public static void Initialize(IToasterService toasterService) => _toasterService = toasterService;

    /// <summary>
    /// Shows a success toast notification.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="closingStrategy">The strategy for closing the toast.</param>
    /// <param name="isUnique">If true, ensures the notification is unique.</param>
    /// <param name="onClick">Action to execute when the notification is clicked.</param>
    /// <param name="onClose">Action to execute when the notification is closed.</param>
    public static void ShowSuccess(string? message,
        ToastClosingStrategy closingStrategy = ToastClosingStrategy.AutoClose,
        bool isUnique = false,
        Action<INotification>? onClick = null,
        Action? onClose = null) => ShowMessage(message, UiResources.Success, NotificationSeverity.Success, closingStrategy, isUnique, onClick, onClose);

    /// <summary>
    /// Shows an error toast notification.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="closingStrategy">The strategy for closing the toast.</param>
    /// <param name="isUnique">If true, ensures the notification is unique.</param>
    /// <param name="onClick">Action to execute when the notification is clicked.</param>
    /// <param name="onClose">Action to execute when the notification is closed.</param>
    public static void ShowError(string? message,
        ToastClosingStrategy closingStrategy = ToastClosingStrategy.AutoClose,
        bool isUnique = false,
        Action<INotification>? onClick = null,
        Action? onClose = null) => ShowMessage(message, UiResources.Error, NotificationSeverity.Error, closingStrategy, isUnique, onClick, onClose);

    /// <summary>
    /// Shows an information toast notification.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="closingStrategy">The strategy for closing the toast.</param>
    /// <param name="isUnique">If true, ensures the notification is unique.</param>
    /// <param name="onClick">Action to execute when the notification is clicked.</param>
    /// <param name="onClose">Action to execute when the notification is closed.</param>
    public static void ShowInformation(string? message,
        ToastClosingStrategy closingStrategy = ToastClosingStrategy.AutoClose,
        bool isUnique = false,
        Action<INotification>? onClick = null,
        Action? onClose = null) => ShowMessage(message, UiResources.Information, NotificationSeverity.Information, closingStrategy, isUnique, onClick, onClose);

    /// <summary>
    /// Shows a warning toast notification.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="closingStrategy">The strategy for closing the toast.</param>
    /// <param name="isUnique">If true, ensures the notification is unique.</param>
    /// <param name="onClick">Action to execute when the notification is clicked.</param>
    /// <param name="onClose">Action to execute when the notification is closed.</param>
    public static void ShowWarning(string? message,
        ToastClosingStrategy closingStrategy = ToastClosingStrategy.AutoClose,
        bool isUnique = false,
        Action<INotification>? onClick = null,
        Action? onClose = null) => ShowMessage(message, UiResources.Warning, NotificationSeverity.Warning, closingStrategy, isUnique, onClick, onClose);

    /// <summary>
    /// Shows a custom toast notification with the specified parameters.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title of the notification.</param>
    /// <param name="severity">The severity of the notification.</param>
    /// <param name="closingStrategy">The strategy for closing the toast.</param>
    /// <param name="isUnique">If true, ensures the notification is unique.</param>
    /// <param name="onClick">Action to execute when the notification is clicked.</param>
    /// <param name="onClose">Action to execute when the notification is closed.</param>
    public static void ShowMessage(string? message,
        string title = "",
        NotificationSeverity severity = NotificationSeverity.Information,
        ToastClosingStrategy closingStrategy = ToastClosingStrategy.AutoClose,
        bool isUnique = false,
        Action<INotification>? onClick = null,
        Action? onClose = null) => Show(new MessageNotification(message.OrEmpty(), title, severity), new ToastSettings { ClosingStrategy = closingStrategy }, isUnique, onClick, onClose);

    /// <summary>
    /// Shows a toast notification with a custom notification object and settings.
    /// </summary>
    /// <param name="notification">The notification to display.</param>
    /// <param name="settings">The settings for the toast notification.</param>
    /// <param name="isUnique">If true, ensures the notification is unique.</param>
    /// <param name="onClick">Action to execute when the notification is clicked.</param>
    /// <param name="onClose">Action to execute when the notification is closed.</param>
    public static void Show(INotification notification,
        ToastSettings? settings = null,
        bool isUnique = false,
        Action<INotification>? onClick = null,
        Action? onClose = null) => _toasterService?.Show(notification, settings ?? ToastSettings.Default, isUnique, onClick, onClose);

    /// <summary>
    /// Hides all toast notifications.
    /// </summary>
    public static void Clear() => _toasterService?.Clear();

    /// <summary>
    /// Hides the specified toast notification.
    /// </summary>
    /// <param name="toast">The notification to hide.</param>
    public static void Hide(INotification toast) => _toasterService?.Hide(toast);
}
