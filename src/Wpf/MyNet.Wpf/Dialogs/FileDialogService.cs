// -----------------------------------------------------------------------
// <copyright file="FileDialogService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Threading.Tasks;
using Microsoft.Win32;
using MyNet.UI.Dialogs.FileDialogs;

namespace MyNet.Wpf.Dialogs;

public class FileDialogService : IFileDialogService
{
    /// <inheritdoc />
    public virtual Task<bool?> ShowOpenFileDialogAsync(OpenFileDialogSettings settings)
    {
        var openFileDialog = new OpenFileDialog
        {
            DefaultExt = settings.DefaultExtension,
            Filter = settings.Filters,
            FileName = settings.FileName,
            CheckFileExists = settings.CheckFileExists,
            CheckPathExists = settings.CheckPathExists,
            InitialDirectory = settings.InitialDirectory,
            Multiselect = settings.Multiselect,
            Title = settings.Title
        };

        var dialogResult = openFileDialog.ShowDialog();

        settings.FileName = openFileDialog.FileName;
        settings.FileNames = openFileDialog.FileNames;
        return Task.FromResult(dialogResult);
    }

    public virtual Task<bool?> ShowSaveFileDialogAsync(SaveFileDialogSettings settings)
    {
        var saveFileDialog = new SaveFileDialog
        {
            CheckFileExists = settings.CheckFileExists,
            CheckPathExists = settings.CheckPathExists,
            CreatePrompt = settings.CreatePrompt,
            DefaultExt = settings.DefaultExtension,
            FileName = settings.FileName,
            Filter = settings.Filters,
            InitialDirectory = settings.InitialDirectory,
            OverwritePrompt = settings.OverwritePrompt,
            Title = settings.Title
        };

        var dialogResult = saveFileDialog.ShowDialog();

        settings.FileName = saveFileDialog.FileName;

        return Task.FromResult(dialogResult);
    }

    /// <inheritdoc />
    public virtual Task<bool?> ShowFolderDialogAsync(OpenFolderDialogSettings settings)
    {
        var openFolderDialog = new OpenFolderDialog
        {
            InitialDirectory = settings.InitialDirectory,
            Title = settings.Title,
            FolderName = settings.Folder
        };

        var dialogResult = openFolderDialog.ShowDialog();

        settings.Folder = openFolderDialog.FolderName;

        return Task.FromResult(dialogResult);
    }
}
