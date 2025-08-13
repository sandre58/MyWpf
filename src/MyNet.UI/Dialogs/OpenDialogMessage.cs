// -----------------------------------------------------------------------
// <copyright file="OpenDialogMessage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Dialogs;

/// <summary>
/// Message for opening a dialog of a specified type.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="OpenDialogMessage"/> class.
/// </remarks>
/// <param name="type">The type of dialog to open.</param>
/// <param name="dialog">The dialog instance or view model.</param>
public class OpenDialogMessage(DialogType type, object? dialog)
{
    /// <summary>
    /// Gets the type of dialog to open.
    /// </summary>
    public DialogType Type { get; } = type;

    /// <summary>
    /// Gets the dialog instance or view model.
    /// </summary>
    public object? Dialog { get; } = dialog;
}
