// -----------------------------------------------------------------------
// <copyright file="NavigationPage.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System;
using System.Windows;
using System.Windows.Controls;
using MyNet.UI.Navigation.Models;

namespace MyNet.Wpf.Controls;

public class NavigationPage : Page, INavigationPage
{
    static NavigationPage() => DefaultStyleKeyProperty.OverrideMetadata(typeof(NavigationPage), new FrameworkPropertyMetadata(typeof(NavigationPage)));

    /// <summary>
    /// Initializes a new instance of the NavigationPage class.
    /// </summary>
    public NavigationPage()
    {
    }

    public virtual Type? GetParentPageType() => null;

    /// <inheritdoc />
    /// <summary>
    /// Called when the implementer has been navigated to.
    /// </summary>
    /// <param name="navigationContext">The navigation context.</param>
    public virtual void OnNavigated(NavigationContext navigationContext)
    {
    }

    /// <inheritdoc />
    /// <summary>
    /// Called when the implementer is being navigated away from.
    /// </summary>
    /// <param name="navigatingContext">The navigation context.</param>
    public virtual void OnNavigatingFrom(NavigatingContext navigatingContext) { }

    /// <inheritdoc />
    /// <summary>
    /// Called when the implementer is being navigated away to.
    /// </summary>
    /// <param name="navigatingContext">The navigation context.</param>
    public virtual void OnNavigatingTo(NavigatingContext navigatingContext) { }
}
