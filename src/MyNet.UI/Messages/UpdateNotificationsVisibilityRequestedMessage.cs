// -----------------------------------------------------------------------
// <copyright file="UpdateNotificationsVisibilityRequestedMessage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Messages;

/// <summary>
/// Message requesting an update to the visibility of notifications.
/// Contains the visibility action to perform (show, hide, toggle).
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UpdateNotificationsVisibilityRequestedMessage"/> class.
/// </remarks>
/// <param name="visibilityAction">The visibility action to perform.</param>
public class UpdateNotificationsVisibilityRequestedMessage(VisibilityAction visibilityAction)
{
    /// <summary>
    /// Gets the action to perform on the visibility of notifications.
    /// </summary>
    public VisibilityAction VisibilityAction { get; } = visibilityAction;
}
