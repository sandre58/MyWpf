// -----------------------------------------------------------------------
// <copyright file="DialogService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Collections.ObjectModel;
using System.Threading;
using System.Threading.Tasks;
using MyNet.UI.Dialogs.CustomDialogs;
using MyNet.UI.Dialogs.MessageBox;
using MyNet.Wpf.Controls;

namespace MyNet.Wpf.Dialogs;

public abstract class DialogService : ICustomDialogService, IMessageBoxService
{
    public ObservableCollection<IDialogViewModel> OpenedDialogs { get; private set; } = [];

    public event EventHandler<DialogEventArgs>? DialogOpened;
    public event EventHandler<DialogEventArgs>? DialogClosed;
    public event EventHandler<MessageBoxEventArgs>? MessageBoxOpened;
    public event EventHandler<MessageBoxEventArgs>? MessageBoxClosed;

    /// <inheritdoc />
    public abstract Task ShowAsync(object view, IDialogViewModel viewModel);

    /// <inheritdoc />
    public virtual async Task<bool?> ShowDialogAsync(object view, IDialogViewModel viewModel)
    {
        OpenedDialogs.Add(viewModel);

        DialogOpened?.Invoke(this, new DialogEventArgs(viewModel));

        var result = await ShowDialogCoreAsync(view, viewModel).ConfigureAwait(false);

        _ = OpenedDialogs.Remove(viewModel);

        DialogClosed?.Invoke(this, new DialogEventArgs(viewModel));

        return result;
    }

    public async Task<MessageBoxResult?> ShowMessageBoxAsync(IMessageBox viewModel, CancellationToken cancellationToken = default)
    {
        var view = new MessageView(viewModel);

        MessageBoxOpened?.Invoke(this, new MessageBoxEventArgs(viewModel));

        _ = await ShowDialogAsync(view, view).ConfigureAwait(false);

        MessageBoxClosed?.Invoke(this, new MessageBoxEventArgs(viewModel));

        return view.MessageBoxResult;
    }

    protected abstract Task<bool?> ShowDialogCoreAsync(object view, IDialogViewModel viewModel);

    public void CloseDialog(IDialogViewModel dialog) => dialog.Close();
}
