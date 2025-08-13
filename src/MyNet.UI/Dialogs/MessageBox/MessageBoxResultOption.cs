// -----------------------------------------------------------------------
// <copyright file="MessageBoxResultOption.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Dialogs.MessageBox;

/// <summary>
/// Specifies the buttons displayed on a message box.
/// </summary>
public enum MessageBoxResultOption
{
    /// <summary>
    /// No button is displayed.
    /// </summary>
    None,

    /// <summary>
    /// The message box displays an OK button.
    /// </summary>
    Ok,

    /// <summary>
    /// The message box displays OK and Cancel buttons.
    /// </summary>
    OkCancel,

    /// <summary>
    /// The message box displays Yes, No, and Cancel buttons.
    /// </summary>
    YesNoCancel,

    /// <summary>
    /// The message box displays Yes and No buttons.
    /// </summary>
    YesNo
}
