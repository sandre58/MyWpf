// -----------------------------------------------------------------------
// <copyright file="SubWorkspaceNavigationService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Linq;
using System.Reactive.Disposables;
using DynamicData.Binding;
using MyNet.UI.Navigation.Models;
using MyNet.UI.ViewModels;
using MyNet.UI.ViewModels.Workspace;
using MyNet.Utilities;

namespace MyNet.UI.Navigation;

/// <summary>
/// Provides navigation logic for sub-workspaces within a workspace, allowing navigation between tabs or sub-pages.
/// Inherits from <see cref="NavigationService"/> and manages sub-workspace selection and disposal.
/// </summary>
public class SubWorkspaceNavigationService : NavigationService, IDisposable
{
    private readonly IWorkspaceViewModel _workspaceViewModel;
    private readonly CompositeDisposable _disposables = [];
    private bool _disposedValue;

    /// <summary>
    /// Initializes a new instance of the <see cref="SubWorkspaceNavigationService"/> class.
    /// </summary>
    /// <param name="workspaceViewModel">The workspace view model containing sub-workspaces.</param>
    public SubWorkspaceNavigationService(IWorkspaceViewModel workspaceViewModel)
    {
        _workspaceViewModel = workspaceViewModel;

        _disposables.Add(_workspaceViewModel.SubWorkspaces.ToObservableChangeSet().Subscribe(_ => CheckSelectedWorkspace()));
    }

    /// <summary>
    /// Navigates to a sub-workspace by index or instance.
    /// </summary>
    /// <param name="indexOrSubWorkspace">The index or sub-workspace instance to navigate to.</param>
    /// <returns>True if navigation succeeded; otherwise, false.</returns>
    internal bool NavigateTo(object indexOrSubWorkspace)
    {
        var subWorkspace = GetNavigableWorkspace(indexOrSubWorkspace);

        return subWorkspace is not null && _workspaceViewModel.SubWorkspaces.Contains(subWorkspace) && NavigateTo(page: subWorkspace);
    }

    /// <summary>
    /// Performs navigation to a sub-workspace if it exists in the workspace.
    /// </summary>
    /// <param name="oldPage">The previous page before navigation.</param>
    /// <param name="newPage">The destination page for navigation.</param>
    /// <param name="mode">The navigation mode.</param>
    /// <param name="navigationParameters">The navigation parameters.</param>
    /// <returns>True if navigation succeeded; otherwise, false.</returns>
    protected override bool Navigate(INavigationPage? oldPage, INavigationPage newPage, NavigationMode mode, NavigationParameters? navigationParameters)
        => _workspaceViewModel.SubWorkspaces.Contains(newPage)
            ? base.Navigate(oldPage, newPage, mode, navigationParameters)
            : CheckSelectedWorkspace();

    /// <summary>
    /// Gets the sub-workspace instance from an index or object.
    /// </summary>
    /// <param name="indexOrSubWorkspace">The index or sub-workspace instance.</param>
    /// <returns>The sub-workspace instance if found; otherwise, null.</returns>
    private INavigableWorkspaceViewModel? GetNavigableWorkspace(object indexOrSubWorkspace)
    {
        switch (indexOrSubWorkspace)
        {
            case Enum:
                return _workspaceViewModel.SubWorkspaces.GetByIndex((int)indexOrSubWorkspace);
            default:
                if (int.TryParse(indexOrSubWorkspace.ToString(), out var index))
                    return _workspaceViewModel.SubWorkspaces.GetByIndex(index);
                if (indexOrSubWorkspace is INavigableWorkspaceViewModel workspace)
                    return workspace;
                break;
        }

        return null;
    }

    /// <summary>
    /// Checks and selects the first sub-workspace if none is currently selected.
    /// </summary>
    /// <returns>True if navigation to the first sub-workspace succeeded; otherwise, false.</returns>
    public bool CheckSelectedWorkspace()
        => _workspaceViewModel.SubWorkspaces.Any() && (CurrentContext?.Page is not NavigableWorkspaceViewModel navigableWorkspaceViewModel || !_workspaceViewModel.SubWorkspaces.Contains(navigableWorkspaceViewModel))
                                                   && NavigateTo(_workspaceViewModel.SubWorkspaces[0]);

    /// <summary>
    /// Disposes resources used by the navigation service.
    /// </summary>
    /// <param name="disposing">Indicates whether the method is called from Dispose.</param>
    protected virtual void Dispose(bool disposing)
    {
        if (_disposedValue)
            return;
        if (disposing)
        {
            _disposables.Dispose();
        }

        _disposedValue = true;
    }

    /// <summary>
    /// Disposes the navigation service and its resources.
    /// </summary>
    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
