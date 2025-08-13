// -----------------------------------------------------------------------
// <copyright file="SaveFileDialogSettings.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Dialogs.FileDialogs;

/// <summary>
/// Settings for configuring the SaveFileDialog.
/// </summary>
public class SaveFileDialogSettings : FileDialogSettings
{
    /// <summary>
    /// Gets the default settings for the SaveFileDialog.
    /// </summary>
    public static SaveFileDialogSettings Default => new();

    /// <summary>
    /// Initializes a new instance of the <see cref="SaveFileDialogSettings"/> class.
    /// </summary>
    public SaveFileDialogSettings() => CheckFileExists = false;

    /// <summary>
    /// Gets or sets a value indicating whether the dialog prompts the user for permission to create a file if the specified file does not exist.
    /// </summary>
    public bool CreatePrompt { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the dialog displays a warning if the specified file name already exists.
    /// </summary>
    public bool OverwritePrompt { get; set; }
}
