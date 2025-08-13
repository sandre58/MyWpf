// -----------------------------------------------------------------------
// <copyright file="IMessageBoxFactory.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Dialogs.MessageBox;

/// <summary>
/// Defines the contract for a factory that creates message box view models.
/// </summary>
public interface IMessageBoxFactory
{
    /// <summary>
    /// Creates a message box view model with the specified parameters.
    /// </summary>
    /// <param name="message">The message to display.</param>
    /// <param name="title">The title of the message box.</param>
    /// <param name="severity">The severity of the message.</param>
    /// <param name="buttons">The buttons to display.</param>
    /// <param name="defaultResut">The default result for the message box.</param>
    /// <returns>A new <see cref="IMessageBox"/> instance.</returns>
    IMessageBox Create(string message, string? title, MessageSeverity severity, MessageBoxResultOption buttons, MessageBoxResult defaultResut);
}
