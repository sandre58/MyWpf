// -----------------------------------------------------------------------
// <copyright file="NavigationViewEventArgs.cs" company="Stéphane ANDRE">
// Copyright (c) Stéphane ANDRE. All rights reserved.
// </copyright>
// -----------------------------------------------------------------------

using System.Windows;
using MyNet.UI.Navigation.Models;

namespace MyNet.Wpf.Controls;

public class NavigatingCancelEventArgs(RoutedEvent routedEvent, object source) : RoutedEventArgs(routedEvent, source)
{
    public INavigationPage? Page { get; set; }

    public bool Cancel { get; set; }
}

public class NavigatedEventArgs(RoutedEvent routedEvent, object source) : RoutedEventArgs(routedEvent, source)
{
    public INavigationPage? Page { get; set; }
}
