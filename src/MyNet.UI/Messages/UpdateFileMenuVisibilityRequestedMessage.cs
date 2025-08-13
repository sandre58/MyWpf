// -----------------------------------------------------------------------
// <copyright file="UpdateFileMenuVisibilityRequestedMessage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Messages;

/// <summary>
/// Message requesting an update to the visibility of the file menu.
/// Contains the visibility action to perform (show, hide, toggle).
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UpdateFileMenuVisibilityRequestedMessage"/> class.
/// </remarks>
/// <param name="visibilityAction">The visibility action to perform.</param>
public class UpdateFileMenuVisibilityRequestedMessage(VisibilityAction visibilityAction)
{
    /// <summary>
    /// Gets the action to perform on the visibility of the file menu.
    /// </summary>
    public VisibilityAction VisibilityAction { get; } = visibilityAction;
}
