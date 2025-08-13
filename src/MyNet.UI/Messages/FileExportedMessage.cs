// -----------------------------------------------------------------------
// <copyright file="FileExportedMessage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;

namespace MyNet.UI.Messages;

/// <summary>
/// Message indicating that a file has been exported, including its path and an action to open it.
/// </summary>
public class FileExportedMessage
{
    /// <summary>
    /// Gets the path of the exported file.
    /// </summary>
    public string FilePath { get; }

    /// <summary>
    /// Gets the action to open the exported file.
    /// </summary>
    public Action<string> OpenAction { get; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FileExportedMessage"/> class.
    /// </summary>
    /// <param name="filePath">The path of the exported file.</param>
    /// <param name="openAction">The action to open the file.</param>
    public FileExportedMessage(string filePath, Action<string> openAction) => (FilePath, OpenAction) = (filePath, openAction);
}
