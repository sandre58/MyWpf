// -----------------------------------------------------------------------
// <copyright file="OpenFolderDialogSettings.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

namespace MyNet.UI.Dialogs.FileDialogs;

/// <summary>
/// Settings for configuring the OpenFolderDialog.
/// </summary>
public class OpenFolderDialogSettings
{
    /// <summary>
    /// Gets the default settings for the OpenFolderDialog.
    /// </summary>
    public static OpenFolderDialogSettings Default => new();

    /// <summary>
    /// Gets or sets a value indicating whether the dialog checks if the path exists.
    /// </summary>
    public bool CheckPathExists { get; set; } = true;

    /// <summary>
    /// Gets or sets the folder to select or open.
    /// </summary>
    public string Folder { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the initial directory displayed by the dialog.
    /// </summary>
    public string InitialDirectory { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the dialog.
    /// </summary>
    public string Title { get; set; } = string.Empty;
}
