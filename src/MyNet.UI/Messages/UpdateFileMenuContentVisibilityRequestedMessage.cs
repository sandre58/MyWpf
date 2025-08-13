// -----------------------------------------------------------------------
// <copyright file="UpdateFileMenuContentVisibilityRequestedMessage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Messages;

/// <summary>
/// Message requesting an update to the visibility of a file menu content.
/// Contains the type of content and the visibility action to perform.
/// </summary>
public class UpdateFileMenuContentVisibilityRequestedMessage
{
    /// <summary>
    /// Gets the type of the content whose visibility should be updated.
    /// </summary>
    public Type ContentType { get; }

    /// <summary>
    /// Gets the action to perform on the visibility of the content.
    /// </summary>
    public VisibilityAction VisibilityAction { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateFileMenuContentVisibilityRequestedMessage"/> class.
    /// </summary>
    /// <param name="contentType">The type of the content to update.</param>
    /// <param name="visibilityAction">The visibility action to perform.</param>
    public UpdateFileMenuContentVisibilityRequestedMessage(Type contentType, VisibilityAction visibilityAction) => (ContentType, VisibilityAction) = (contentType, visibilityAction);
}
