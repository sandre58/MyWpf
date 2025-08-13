// -----------------------------------------------------------------------
// <copyright file="FileDialogSettings.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Collections.Generic;

namespace MyNet.UI.Dialogs.FileDialogs;

/// <summary>
/// Base settings for configuring file dialogs.
/// </summary>
public abstract class FileDialogSettings
{
    /// <summary>
    /// Gets or sets a value indicating whether the dialog displays a warning if the specified file name does not exist.
    /// </summary>
    public bool CheckFileExists { get; set; } = true;

    /// <summary>
    /// Gets or sets a value indicating whether the dialog displays a warning if the specified path does not exist.
    /// </summary>
    public bool CheckPathExists { get; set; } = true;

    /// <summary>
    /// Gets or sets the default file name extension.
    /// </summary>
    public string DefaultExtension { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the file name selected in the dialog.
    /// </summary>
    public string FileName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the file names of all selected files in the dialog.
    /// </summary>
    public IEnumerable<string> FileNames { get; set; } = [];

    /// <summary>
    /// Gets or sets the filter string for file types displayed in the dialog.
    /// </summary>
    public string? Filters { get; set; }

    /// <summary>
    /// Gets or sets the initial directory displayed by the dialog.
    /// </summary>
    public string InitialDirectory { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the title of the dialog.
    /// </summary>
    public string Title { get; set; } = string.Empty;
}
