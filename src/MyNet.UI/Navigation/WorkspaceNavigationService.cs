// -----------------------------------------------------------------------
// <copyright file="WorkspaceNavigationService.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using MyNet.UI.Navigation.Models;
using MyNet.UI.ViewModels;
using MyNet.UI.ViewModels.Workspace;
using MyNet.Utilities.Suspending;

namespace MyNet.UI.Navigation;

/// <summary>
/// Provides navigation logic for workspaces, handling navigation between main and sub-workspaces.
/// Inherits from <see cref="NavigationService"/> and manages sub-workspace navigation events and context updates.
/// </summary>
public class WorkspaceNavigationService : NavigationService
{
    private readonly Suspender _subWorkspaceNavigationSuspender = new();

    /// <summary>
    /// Called after navigation is completed. Manages sub-workspace navigation event subscriptions and context updates.
    /// </summary>
    /// <param name="navigatingContext">The navigation context.</param>
    protected override void OnNavigated(NavigationContext navigatingContext)
    {
        using (_subWorkspaceNavigationSuspender.Suspend())
        {
            base.OnNavigated(navigatingContext);

            if (navigatingContext.OldPage is IWorkspaceViewModel oldNavigable)
            {
                oldNavigable.NavigationService.Navigated -= OnSubWorkspaceNavigatedCallback;
            }

            if (navigatingContext.Page is IWorkspaceViewModel newNavigable)
            {
                newNavigable.NavigationService.Navigated += OnSubWorkspaceNavigatedCallback;
            }
        }
    }

    /// <summary>
    /// Callback for sub-workspace navigation events. Updates the navigation journal and context for sub-workspace navigation.
    /// </summary>
    /// <param name="sender">The event sender.</param>
    /// <param name="e">The navigation event arguments.</param>
    private void OnSubWorkspaceNavigatedCallback(object? sender, NavigationEventArgs e)
    {
        if (CurrentContext is null || _subWorkspaceNavigationSuspender.IsSuspended)
            return;
        if (e.OldPage is not null)
            UpdateJournal(NavigationMode.Normal, new SubWorskpaceNavigationContext(CurrentContext.Page, e.OldPage, e.OldPage, e.Mode, CurrentContext.Parameters));
        UpdateCurrentContext(new SubWorskpaceNavigationContext(CurrentContext.Page, e.OldPage, e.NewPage, e.Mode, CurrentContext.Parameters));
    }
}

/// <summary>
/// Represents the navigation context for sub-workspace navigation, including old and new tabs.
/// Inherits from <see cref="NavigatingContext"/>.
/// </summary>
internal sealed class SubWorskpaceNavigationContext : NavigatingContext
{
    /// <summary>
    /// Gets or sets the old tab in the sub-workspace navigation.
    /// </summary>
    public INavigationPage? OldTab { get; set; }

    /// <summary>
    /// Gets or sets the new tab in the sub-workspace navigation.
    /// </summary>
    public INavigationPage NewTab { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="SubWorskpaceNavigationContext"/> class.
    /// </summary>
    /// <param name="page">The main workspace page.</param>
    /// <param name="oldTab">The old tab in the sub-workspace.</param>
    /// <param name="newTab">The new tab in the sub-workspace.</param>
    /// <param name="mode">The navigation mode.</param>
    /// <param name="navigationParameters">The navigation parameters.</param>
    public SubWorskpaceNavigationContext(INavigationPage page, INavigationPage? oldTab, INavigationPage newTab, NavigationMode mode, NavigationParameters? navigationParameters = null)
        : base(page, page, mode, navigationParameters?.Clone() ?? [])
    {
        OldTab = oldTab;
        NewTab = newTab;

        Parameters?.AddOrUpdate(WorkspaceViewModel.TabParameterKey, newTab);
    }
}
